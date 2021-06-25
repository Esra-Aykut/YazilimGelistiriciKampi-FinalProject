using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
           
            
            
              foreach (var p in productManager.GetAllByCategoryId(2))  //GetAll(), GetAllByCategoryId(2), GetByUnitPrice(50, 100)
              {
                Console.WriteLine(p.ProductName);
              }

        }
    }
}
