using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHouse.DAL.PageSort
{
    public class PageSortParam
    {
        public int pageSize { get; set; } = 10;  //default page size
        public int pageNumber { get; set; } = 1;

        public Attribute attribute { get; set; } 
        public Order order { get; set; }
    }

    public enum Order
    {
        asc,   //default as ascending
        desc
    }

    public enum Attribute
    {
        none,   //default as none
        Id,
        Name,
        TailLength,
        Weight
    }
}
