using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains;

namespace Bl
{
    public interface IMessages
    {
        public List<TbMessage> GetAll();
        public TbMessage GetById(int id);
        public bool Save(TbMessage message);
        public bool Delete(int id);
    }
    public class ClsMessages : IMessages
    {
        Portfolio1Context ctx;
        public ClsMessages(Portfolio1Context _ctx)
        {
            ctx = _ctx;
        }

        public List<TbMessage> GetAll()
        {
            try
            {
                var listMessages = ctx.TbMessages.Where(x=>x.CurrentState ==1).OrderByDescending(x => x.CreatedDate).ToList();
                return listMessages;
            }
            catch
            {
                return new List<TbMessage>();
            }

        }

        public TbMessage GetById(int id)
        {
            try
            {
                var message = ctx.TbMessages.FirstOrDefault(x => x.Id == id );
                return message;
            }
            catch
            {
                return new TbMessage();
            }

        }

        public bool Save(TbMessage message)
        {
            try
            {
                if (message.Id == 0)
                {
                    message.CurrentState = 1;
                    message.CreatedDate = DateTime.Now;
                    ctx.TbMessages.Add(message);
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
                var message = GetById(id);
                message.CurrentState = 0;
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
