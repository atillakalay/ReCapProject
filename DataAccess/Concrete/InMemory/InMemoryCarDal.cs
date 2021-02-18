using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car
                {
                    BrandId = 1, ColorId = 1, DailyPrice = 187000, Description = "Siyah dört çeker araba 500 beygir .",
                    CarId = 1
                },
                new Car
                {
                    BrandId = 1, ColorId = 2, DailyPrice = 195000, Description = "Beyaz dört çeker araba 500 beygir .",
                    CarId = 2
                },
                new Car
                {
                    BrandId = 2, ColorId = 3, DailyPrice = 225000, Description = "Mavi dört çeker araba 500 beygir .",
                    CarId = 3
                },
                new Car
                {
                    BrandId = 2, ColorId = 1, DailyPrice = 113000, Description = "Siyah dört çeker araba 500 beygir .",
                    CarId = 4, 
                },
                new Car
                {
                    BrandId = 3, ColorId = 3, DailyPrice = 147000, Description = "Mavi dört çeker araba 500 beygir .",
                    CarId = 5
                }
            };
        }



        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete = _cars.First(x => x.CarId == car.CarId);
            _cars.Remove(carDelete);
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public Car GeById(Car car)
        {
            Car carGetById = _cars.Find(x => x.CarId == car.CarId);
            return carGetById;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.Find(x => x.CarId == car.CarId);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
     
        }
    }
}
