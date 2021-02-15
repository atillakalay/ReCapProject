using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorService _colorService;

        public ColorManager(IColorService colorService)
        {
            _colorService = colorService;
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>();
        }

        public IResult Add(Color color)
        {
            _colorService.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorService.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IResult Update(Color color)
        {
            _colorService.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
