using Bl;
using Portfolio.Areas.admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Area.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class HomeController : Controller
    {

        ICategories oClsCategories;
        ISkills oClsSkills;
        IProjects oClsProjects;
        IServices oClsServices;
        IMessages oClsMessages;
        public HomeController(IProjects _oClsProjects, IServices _oClsServices, IMessages _oClsMessages, ISkills _oClsSkills, ICategories _oClsCategories) 
        {
            oClsProjects = _oClsProjects;
            oClsServices = _oClsServices;
            oClsCategories = _oClsCategories;
            oClsSkills = _oClsSkills;
            oClsMessages = _oClsMessages;

        }


        public IActionResult Index()
        {

            VwDashboardModel vm = new VwDashboardModel();
            vm.NumOfCategories = oClsCategories.GetAll().Count();
            vm.NumOfProjects = oClsProjects.GetAll().ToList().Count();
            vm.NumOfServices= oClsServices.GetAll().Count();
            vm.NumOfSkills= oClsSkills.GetAll().Count();
            vm.NumOfMessages= oClsMessages.GetAll().Count();
            return View(vm);
        }
    }
}
