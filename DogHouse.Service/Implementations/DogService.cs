using DogHouse.DAL.Interfaces;
using DogHouse.DAL.PageSort;
using DogHouse.Domain.Entity;
using DogHouse.Domain.Enum;
using DogHouse.Domain.Response;
using DogHouse.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHouse.Service.Implementations
{
    public class DogService : IDogService
    {
        private readonly IBaseRepository<Dog> _dogRepository;

        public DogService(IBaseRepository<Dog> dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public async Task<IBaseResponse<Dog>> Create(Dog model)
        {
            try
            {
                var dog = new Dog()
                {
                    Name = model.Name,
                    Color = model.Color,
                    TailLength = model.TailLength,
                    Weight = model.Weight,
                };
                await _dogRepository.Create(dog);

                return new BaseResponse<Dog>()
                {
                    StatusCode = StatusCode.OK,
                    Data = dog
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dog>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteDog(int id)
        {
            try
            {
                var dog = await _dogRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (dog == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Dog not found",
                        StatusCode = StatusCode.UserNotFound,
                        Data = false
                    };
                }

                await _dogRepository.Delete(dog);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteDog] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Dog>> Edit(int id, Dog model)
        {
            try
            {
                var dog = await _dogRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (dog == null)
                {
                    return new BaseResponse<Dog>()
                    {
                        Description = "Dog not found",
                        StatusCode = StatusCode.DogNotFound
                    };
                }

                dog.Name = model.Name;
                dog.Color = model.Color;
                dog.TailLength = model.TailLength;
                dog.Weight = model.Weight;

                await _dogRepository.Update(dog);

                return new BaseResponse<Dog>()
                {
                    Data = dog,
                    StatusCode = StatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dog>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Dog>> GetDog(int id)
        {
            try
            {
                var dog = await _dogRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (dog == null)
                {
                    return new BaseResponse<Dog>()
                    {
                        Description = "Dog not found",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var data = new Dog()
                {
                    Id = id,
                    Name = dog.Name,
                    Color = dog.Color,
                    TailLength = dog.TailLength,
                    Weight = dog.Weight,
                };

                return new BaseResponse<Dog>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dog>()
                {
                    Description = $"[GetDog] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<List<Dog>> GetDogs()
        {
            try
            {
                var dogs = _dogRepository.GetAll().ToList();
                if (!dogs.Any())
                {
                    return new BaseResponse<List<Dog>>()
                    {
                        Description = "Found 0 elements",
                        StatusCode = StatusCode.OK
                    };
                }
                return new BaseResponse<List<Dog>>()
                {
                    Data = dogs,
                    StatusCode = StatusCode.OK
                };
            }

            catch (Exception ex)
            {

                return new BaseResponse<List<Dog>>()
                {
                    Description = $"[GetDogs] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<List<Dog>>> GetDogsByParamsAsync(PageSortParam pageSortParam)
        {
            try
            {
                var dogs = _dogRepository.GetAll();
                PageList<Dog> list = new PageList<Dog>(pageSortParam);
                await list.GetData(dogs);
                if (!list.Any())
                {
                    return new BaseResponse<List<Dog>>()
                    {
                        Description = "Found 0 elements",
                        StatusCode = StatusCode.OK
                    };
                }
                return new BaseResponse<List<Dog>>()
                {
                    Data = list,
                    StatusCode = StatusCode.OK
                };
            }

            catch (Exception ex)
            {

                return new BaseResponse<List<Dog>>()
                {
                    Description = $"[GetDogs] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
