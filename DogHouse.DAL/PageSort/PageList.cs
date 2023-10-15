using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace DogHouse.DAL.PageSort
{
    public class PageList<T> : List<T>
    {
        public PageSortParam Param { get; }
        public PageSortResult Result { get; }

        public PageList(PageSortParam param)
        {
            Param = param;
            Result = new PageSortResult();
        }

        public async Task GetData(IQueryable<T> query)
        {
            //get the total count
            Result.TotalCount = await query.CountAsync();
            //find the number of pages
            Result.TotalPages = (int)Math.Ceiling(Result.TotalCount / (double)Param.pageSize);
            //find previous and next page number
            if (Param.pageNumber - 1 > 0)
                Result.PreviousPage = Param.pageNumber - 1;
            if (Param.pageNumber + 1 <= Result.TotalPages)
                Result.NextPage = Param.pageNumber + 1;
            //find first row and last row on the page
            if (Result.TotalCount == 0)  //if no record found
                Result.FirstRowOnPage = Result.LastRowOnPage = 0;
            else
            {
                Result.FirstRowOnPage = (Param.pageNumber - 1) * Param.pageSize + 1;
                Result.LastRowOnPage =
                  Math.Min(Param.pageNumber * Param.pageSize, Result.TotalCount);
            }

            //if has sorting criteria
            if (Param.attribute.ToString() != "none")
                query = query.OrderBy(Param.attribute +
                 (Param.order == Order.asc ? " ascending" : " descending"));

            List<T> list = await query.Skip((Param.pageNumber - 1) *
                           Param.pageSize).Take(Param.pageSize).ToListAsync();
            AddRange(list);  //add the list of items
        }
    }
}
