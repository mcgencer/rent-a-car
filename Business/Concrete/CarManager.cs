using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        public IResult Add(Car car)
        {
            FluentValidationTool.Validate(new FVCarValidator(),car);
            FluentValidationTool.Validate(new FVCarValidator(), car);
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public void Delete(Car car)
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public List<Car> GetAll()
        public IDataResult<List<Car>> GetAll()
        {
            return _carDal.GetAll();
            var result = _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(result, Messages.Listed);
        }

        public List<Car> GetAllByBrandId(int brandId)
        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            return _carDal.GetAll(c=>c.BrandId==brandId);
            var result = _carDal.GetAll(c => c.BrandId == brandId);
            return new SuccessDataResult<List<Car>>(result, Messages.Listed);
        }

        public List<Car> GetAllByColorId(int colorId)
        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.BrandId == colorId);
            var result = _carDal.GetAll(c => c.ColorId == colorId);
            return new SuccessDataResult<List<Car>>(result, Messages.Listed);
        }

        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(c => c.Id == id);
            return new SuccessDataResult<Car>(result, Messages.Geted);
        }

        public Car GetById(int id)
        public IDataResult<List<CarDetailDTO>> GetDetails()
        {
            return _carDal.Get(c=>c.Id==id);
            var result = _carDal.GetDetails();
            return new SuccessDataResult<List<CarDetailDTO>>(result,Messages.Listed);
        }

        public void Update(Car car)
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}