using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface ISkills
    {
        public List<TbSkill> GetAll();
        public TbSkill GetById(int id);
        public bool Save(TbSkill skill);
       
    }
    public class ClsSkills : ISkills
    {
        Portfolio1Context ctx;
        public ClsSkills(Portfolio1Context _ctx)
        {
            ctx = _ctx;
        }

        public List<TbSkill> GetAll()
        {
            try
            {

                var skill = ctx.TbSkills.ToList();
                return skill;
            }
            catch
            {
                return new List<TbSkill>();
            }

        }

        public TbSkill GetById(int id)
        {
            try
            {
                var skill = ctx.TbSkills.FirstOrDefault(x => x.Id == id);
                return skill;
            }
            catch
            {
                return new TbSkill();
            }
        }

        public bool Save(TbSkill skill)
        {

            try
            {
                if (skill.Id == 0)
                {
                    ctx.TbSkills.Add(skill);
                }
                else
                {
                    ctx.Entry(skill).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
