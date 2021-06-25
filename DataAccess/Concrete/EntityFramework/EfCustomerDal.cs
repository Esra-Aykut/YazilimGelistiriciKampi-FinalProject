using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : ICustomerDal
    {
        public void Add(Customer entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var addedCustomer = context.Entry(entity);
                addedCustomer.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Customer entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedCustomer = context.Entry(entity);
                deletedCustomer.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Customer entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedCustomer = context.Entry(entity);
                updatedCustomer.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Customer Get(Expression<Func<Customer, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Customer>().SingleOrDefault(filter);
            }
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter==null ? context.Set<Customer>().ToList() 
                                    : context.Set<Customer>().Where(filter).ToList();
            }
        }

        
    }
}
