using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.AutoFact;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;


namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;


        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [CacheAspect()]
        public IDataResult<List<CarDetailDto>> GetAll()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarList);
        }

        public IDataResult<List<CarDetailDto>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(b=>b.BrandId==id).ToList());
        }


        public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => Convert.ToDecimal(p.DailyPrice) >= min && Convert.ToDecimal(p.DailyPrice) <= max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(x=>x.CarId==carId).ToList());
        }

        [SecuredOperation(" product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarNameExist(car.CarName));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new Result(true, Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 50000)
            {
                throw new Exception("");
            }

            Add(car);
            return null;
        }

        public IDataResult<List<CarDetailDto>> GetAllByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(c=>c.ColorId==colorId).ToList());
        }

        [CacheAspect()]
        [PerformanceAspect(5)]
        public IDataResult<CarDetailDto> GetById(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetails().Where(x=>x.CarId==carId).ToString());
        }
        private IResult CheckIfCarNameExist(string carName)
        {
            var result = _carDal.GetAll(c => c.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExist);
            }
            return new SuccessResult(null);
        }
    }
}
