using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface IProjects
    {
        public List<TbProject> GetAll();
        public List<VwProject> GetAllDataProjects(int? CategoryId);
        public TbProject GetById(int id);
        public bool Save(TbProject project);
        public bool Delete(int id);

    }

    public class ClsProjects : IProjects
    {
        Portfolio1Context ctx;
        public ClsProjects(Portfolio1Context _ctx) 
        {
            ctx = _ctx;
        }

        public List<TbProject> GetAll()
        {
            try
            {
                var listProjects = ctx.TbProjects.Where(x =>x.CurrentState == 1).ToList();
                return listProjects;
            }
            catch
            {
                return new List<TbProject>();
            }
        }

        public List<VwProject> GetAllDataProjects(int? CategoryId)
        {
            try
            {
                var listProjects = ctx.VwProjects.Where(x => (x.CategoryId == CategoryId || CategoryId == null || CategoryId == 0) && x.CurrentState == 1 && !string.IsNullOrEmpty(x.ProjectName)).OrderByDescending(x => x.CreatedDate).ToList();
                return listProjects;
            }
            catch
            {
                return new List<VwProject>();
            }
        }

        public TbProject GetById(int id)
        {
            try
            {
                var project = ctx.TbProjects.FirstOrDefault(x => x.ProjectId == id && x.CurrentState == 1);
                return project;
            }
            catch
            {
                return new TbProject();
            }
        }

        public bool Save(TbProject project)
        {
            try
            {
                if (project.ProjectId == 0)
                {
                    project.CreatedBy = "1";
                    project.CreatedDate = DateTime.Now;
                    project.CurrentState = 1;
                    ctx.TbProjects.Add(project);
                }
                else
                {
                    project.UpdatedDate = DateTime.Now;
                    project.UpdatedBy = "1";
                    ctx.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var project = GetById(id);
                project.CurrentState = 0;
                ctx.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
