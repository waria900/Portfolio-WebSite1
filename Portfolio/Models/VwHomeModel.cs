using Domains;

namespace Portfolio.Models
{
    public class VwHomeModel
    {
        public VwHomeModel()
        {
            Home = new TbHome();
            AboutUs = new TbAbout();
            Categories = new List<TbCategory>();
            listProjects = new List<VwProject>();
            Services = new List<TbService>();
            Messages = new TbMessage();
            listWebApp = new List<VwProject>();
            listMobileApp = new List<VwProject>();
            listBlogs = new List<VwProject>();
            listSkills = new List<TbSkill>();
        }


        public TbHome Home { get; set; }
        public List<TbCategory> Categories { get; set; }
        public List<VwProject> listProjects { get; set; }
        public List<VwProject> listWebApp { get; set; }
        public List<VwProject> listMobileApp { get; set; }
        public List<VwProject> listBlogs { get; set; }
        public TbAbout AboutUs { get; set; }
        public List<TbService> Services { get; set; }
        public TbMessage Messages { get; set; }
      
         public List<TbSkill> listSkills { get; set; }

    }
}
