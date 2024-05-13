using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface IAboutUs
    {
        public TbAbout GetAll();
        public TbAbout GetById(int id);
        public bool Save(TbAbout about);
    }
    public class ClsAboutUs : IAboutUs
    {
        Portfolio1Context ctx;
        public ClsAboutUs(Portfolio1Context _ctx)
        {
            ctx = _ctx;
        }
        public TbAbout GetAll()
        {
            try
            {
                var about = ctx.TbAbouts.FirstOrDefault();
                return about;
            }
            catch
            {
                return new TbAbout();
            }

        }

        public TbAbout GetById(int id)
        {
            try
            {
                var about = ctx.TbAbouts.FirstOrDefault(x => x.Id == id);
                return about;
            }
            catch
            {
                return new TbAbout();
            }
        }

        public bool Save(TbAbout about)
        {

            try
            {
                if (about.Id == 0)
                {
                    ctx.TbAbouts.Add(about);
                }
                else
                {
                    ctx.Entry(about).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
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
