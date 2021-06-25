using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();

        //burda şöyle extra fonk.lar da tanımlayabilirsin
        public List<Product> GetAllByCategoryId(int id);   // GetAll(p => p.CategoryId == id)
        List<Product> GetByUnitPrice(decimal min,decimal max);

    }
}
