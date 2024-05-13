using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface IServices
    {
        public List<TbService> GetAll();
        public TbService GetById(int id);
        public bool Save(TbService service);
        public bool Delete(int id);

    }
    public class ClsServices : IServices
    {
        Portfolio1Context ctx;
        public ClsServices(Portfolio1Context _ctx)
        {
            ctx = _ctx;
        }

        public List<TbService> GetAll()
        {
            try
            {
                var listServices = ctx.TbServices.Where(x=>x.CurrentState == 1).ToList();
                return listServices;
            }
            catch
            {
                return new List<TbService>();
            }
        }

     

        public TbService GetById(int id)
        {
            try
            {
                var service = ctx.TbServices.FirstOrDefault(x => x.ServiceId == id && x.CurrentState == 1);
                return service;
            }
            catch
            {
                return new TbService();
            }
        }

        public bool Save(TbService service)
        {
            try
            {
                if (service.ServiceId == 0)
                {
                    service.CreatedBy = "1";
                    service.CreatedDate = DateTime.Now;
                    service.CurrentState = 1;
                    ctx.TbServices.Add(service);
                }
                else
                {
                    service.UpdatedDate = DateTime.Now;
                    service.UpdatedBy = "1";
                    ctx.Entry(service).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var service = GetById(id);
                service.CurrentState = 0;
                ctx.Entry(service).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

