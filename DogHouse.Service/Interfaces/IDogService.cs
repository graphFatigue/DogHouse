using DogHouse.Domain.Entity;
using DogHouse.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHouse.Service.Interfaces
{
    public interface IDogService
    {
        IBaseResponse<List<Dog>> GetDogs();
        Task<IBaseResponse<Dog>> GetDog(int id);
        Task<IBaseResponse<Dog>> Create(Dog model);
        Task<IBaseResponse<bool>> DeleteDog(int id);
        IBaseResponse<List<Dog>> Search(Dog model);
        Task<IBaseResponse<Dog>> Edit(int id, Dog model);
    }
}
