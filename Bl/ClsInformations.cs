using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains;

namespace Bl
{
    public interface IInformations
    {
        public TbInformation GetAll();
        public TbInformation GetById(int id);
        public bool Save(TbInformation info);

    }
    public class ClsInformations : IInformations
    {
        Portfolio1Context ctx;
        public ClsInformations(Portfolio1Context _ctx) 
        {
            ctx = _ctx;
        }
        public TbInformation GetAll()
        {
            try
            {

                var info = ctx.TbInformations.FirstOrDefault();
                return info;
            }
            catch
            {
                return new TbInformation();
            }
        }

        public TbInformation GetById(int id)
        {
            try
            {
                var info = ctx.TbInformations.FirstOrDefault(x => x.Id == id);
                return info;
            }
            catch
            {
                return new TbInformation();
            }
        }

        public bool Save(TbInformation info)
        {
            if(info.Id == 0)
            {
                ctx.TbInformations.Add(info);
                
            }
            else
            {
                ctx.Entry(info).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            ctx.SaveChanges();
            return true;
        }
    }
}
