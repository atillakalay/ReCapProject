using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                                 on c.BrandId equals b.BrandId
                             join co in context.Colors
                                 on c.ColorId equals co.ColorId
                             join ca in context.Cars
                                 on c.CarName equals ca.CarName
                           
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName =ca.CarName,
                                 DailyPrice = c.DailyPrice,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 ColorId =c.ColorId,
                                 BrandId = b.BrandId
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                                 on car.ColorId equals color.ColorId
                             join brand in context.Brands
                                 on car.BrandId equals brand.BrandId
                             join ca in context.Cars
                                 on car.CarName equals ca.CarName
                             select new CarDetailDto()
                             {
                                 CarId = car.CarId, BrandName = brand.BrandName, ColorName = color.ColorName, DailyPrice = car.DailyPrice, Description = car.Description, ModelYear = car.ModelYear,CarName =ca.CarName,ColorId =color.ColorId,BrandId = brand.BrandId

                             };

                return result.ToList();
            }
        }
    }
}