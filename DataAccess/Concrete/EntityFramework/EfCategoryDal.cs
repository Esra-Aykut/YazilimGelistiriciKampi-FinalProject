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
    public class EfCategoryDal : ICategoryDal
    {
        public void Add(Category entity)
        {
            //bir şeyi bellekten hızlıca atmak için =>using 

            using (NorthwindContext context=new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //referansını bul 
                addedEntity.State = EntityState.Added;   //ekle
                context.SaveChanges();                   //kaydet
            }
        }

        public void Delete(Category entity)
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Category entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Category>().SingleOrDefault(filter);
            }
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            using (NorthwindContext c= new NorthwindContext())
            {
                return filter == null ? c.Set<Category>().ToList()   // filtre yok => select * Category
                                      : c.Set<Category>().Where(filter).ToList();
            }
        }

       
    }
}
