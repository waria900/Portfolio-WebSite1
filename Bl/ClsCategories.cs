//using Portfolio.Models;
//using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains;


namespace Bl
{

    public interface ICategories
    {
        public List<TbCategory> GetAll();
        public TbCategory GetById(int id);
        public bool Save(TbCategory category);
        public bool Delete( int id );

    }
    public class ClsCategories : ICategories
    {
        Portfolio1Context ctx;
        public ClsCategories(Portfolio1Context _ctx) 
        {
            ctx = _ctx;
        }


        public List<TbCategory> GetAll()
        {
            try
            {
                var listCategories = ctx.TbCategories.Where(x=>x.CurrentState == 1).ToList();
                return listCategories;
            }
            catch
            {
                return new List<TbCategory>();
            }
        }

        public TbCategory GetById(int id)
        {
            try
            {
                var category = ctx.TbCategories.FirstOrDefault(x=>x.CategoryId== id && x.CurrentState == 1);
                return category;
            }
            catch
            {
                return new TbCategory();
            }
        }

        public bool Save(TbCategory category)
        {
            try
            {
                if (category.CategoryId == 0)
                {
                    category.CreatedBy = "1";
                    category.CreatedDate = DateTime.Now;
                    category.CurrentState = 1;
                    ctx.TbCategories.Add(category);
                }
                else
                {
                    category.UpdatedDate = DateTime.Now;
                    category.UpdatedBy = "1";
                    ctx.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var category = GetById(id);
                category.CurrentState = 0;
                ctx.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
