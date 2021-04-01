using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.FileUpload;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId);

            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }

            List<CarImage> images = new List<CarImage>();
            images.Add(new CarImage() { CarId = 0, Id = 0, ImagePath = "/images/car-rent.png" });

            return new SuccessDataResult<List<CarImage>>(images);
        }

        public IDataResult<CarImage> GetById(int carId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.CarId == carId));
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile image, CarImage carImage)
        {

            var imageCount = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;

            if (imageCount >= 5)
            {
                return new ErrorResult("One car must have 5 or less images");
            }

            var imageResult = FileUpload.Upload(image);
            carImage.ImagePath = imageResult.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult("Car image added");
        }

        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }

            FileUpload.Delete(image.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult("Image was deleted successfully");
        }

        public IResult Update(IFormFile image, CarImage carImage)
        {
            var isImage = _carImageDal.Get(c => c.Id == carImage.Id);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }



            var updatedFile = FileUpload.Update(image, isImage.ImagePath);
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult("Car image updated");

        }
        private IResult CheckIfCarImageLimitExcited()
        {
            var result = _carImageDal.GetAll().Count();
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageLimitExcited);
            }
            return new SuccessResult(null);
        }
        private string ImagePath(int carId, string fileExtension)
        {
            string GuidKey = Guid.NewGuid().ToString();
            return FilePaths.ImageFolderPath + GuidKey + fileExtension;
        }
        private IResult CheckCarImageCount(int carId)
        {
            if (_carImageDal.GetAll(p => p.CarId == carId).Count > 4)
            {
                return new ErrorResult(Messages.CarImageLimitExcited);
            }
            return new SuccessResult(null);
        }
        private IResult CheckIfFileExtension(string path)
        {
            string acceptableExtensions = ".png|.jpeg|.jpg";
            if (String.Compare(Path.GetExtension(path).ToLower(), acceptableExtensions) == 0)
            {
                return new ErrorResult(Messages.IncorrectFileExtension);
            }
            return new SuccessResult(null);
        }
    }
}
