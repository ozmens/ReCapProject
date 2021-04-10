using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;
        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        [ValidationAspect(typeof(ImageValidator))]
            public IResult Add(IFormFile file, Image image)
            {
                IResult result = BusinessRules.Run(CheckCountOfImage(image.CarId));

                if (result != null)
                {
                    return result;
                }

                image.ImagePath = FileHelper.AddAsync(file);
                image.Date = DateTime.Now;
                _imageDal.Add(image);
                return new SuccessResult(Messages.ImageAdded);
            }

            [ValidationAspect(typeof(ImageValidator))]
            public IResult Update(IFormFile file, Image image)
            {
                var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\Root")) + 
                _imageDal.Get(p => p.Id == image.Id).ImagePath;
                image.ImagePath = FileHelper.UpdateAsync(oldpath, file);
                image.Date = DateTime.Now;
                _imageDal.Update(image);
                return new SuccessResult(Messages.ImageUpdated);

            }

            [ValidationAspect(typeof(ImageValidator))]
            public IResult Delete(Image image)
            {
                var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\Root")) + 
                _imageDal.Get(p => p.Id == image.Id).ImagePath;

                IResult result = BusinessRules.Run(
                    FileHelper.DeleteAsync(oldpath));

                if (result != null)
                {
                    return result;
                }

                _imageDal.Delete(image);
                return new SuccessResult(Messages.ImageDeleted);
            }

            public IDataResult<Image> GetByImageId(int id)
            {
                return new SuccessDataResult<Image>(_imageDal.Get(p => p.Id == id));
            }

            public IDataResult<List<Image>> GetAll()
            {
                return new SuccessDataResult<List<Image>>(_imageDal.GetAll());
            }

            public IDataResult<List<Image>> GetByCarId(int carId)
            {
                return new SuccessDataResult<List<Image>>(_imageDal.GetAll(c => c.CarId == carId));
            }

            private IDataResult<List<Image>> CheckIfCarImageNull(int id)
            {
                try
                {
                    string path = @"\Images\defaultimage.png";
                    var result = _imageDal.GetAll(c => c.CarId == id).Any();
                    if (!result)
                    {
                        List<Image> carImage = new List<Image>();
                        carImage.Add(new Image { CarId = id, ImagePath = path, Date = DateTime.Now });
                        return new SuccessDataResult<List<Image>>(carImage);
                    }
                }
                catch (Exception exception)
                {

                    return new ErrorDataResult<List<Image>>(exception.Message);
                }

                return new SuccessDataResult<List<Image>>(_imageDal.GetAll(p => p.CarId == id).ToList());
            }


            private IResult CheckCountOfImage(int carId)
            {
                var carImagecount = _imageDal.GetAll(p => p.CarId == carId).Count;
                if (carImagecount >= 5)
                {
                    return new ErrorResult(Messages.AddImageOperationFailed);
                }

                return new SuccessResult();
            }

        }
    }
