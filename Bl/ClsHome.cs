using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface IHome
    {
        public TbHome GetAll();
        public TbHome GetById(int id);
        public bool Save(TbHome home);

    }
    public class ClsHome : IHome
    {
        Portfolio1Context ctx;
        public ClsHome(Portfolio1Context _ctx) 
        { 
            ctx = _ctx;
        }
        public TbHome GetAll()
        {
            try
            {
                var home = ctx.TbHomes.FirstOrDefault();
                return home;
            }
            catch
            {
                return new TbHome();
            }
           
        }

        public TbHome GetById(int id)
        {
            try
            {
                var home = ctx.TbHomes.FirstOrDefault(x => x.Id == id);
                return home;
            }
            catch
            {
                return new TbHome();
            }
        }

        public bool Save(TbHome home)
        {

            try
            {
                if (home.Id == 0)
                {
                    ctx.TbHomes.Add(home);
                }
                else
                {
                    ctx.Entry(home).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
