using DogHouse.DAL.Interfaces;
using DogHouse.DAL.PageSort;
using DogHouse.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHouse.DAL.Repositories
{
    public class DogRepository : IBaseRepository<Dog>
    {
        private readonly ApplicationDbContext _db;

        public DogRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PageList<Dog>> GetByParams(PageSortParam pageSortParam)
        {
            PageList<Dog> list = new PageList<Dog>(pageSortParam);

            await list.GetData(_db.Dogs);
            return list;
        }

        public async Task Create(Dog entity)
        {
            await _db.Dogs.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Dog entity)
        {
            _db.Dogs.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Dog> GetAll()
        {
            return _db.Dogs;
        }

        public async Task<Dog> Update(Dog entity)
        {
            _db.Dogs.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
