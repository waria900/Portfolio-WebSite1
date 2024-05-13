using Bl;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Diagnostics;
using Portfolio.Utilities;
using Domains;
using NToastNotify;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IHome oClsHome;
        ISkills oClsSkills;
        IProjects oClsProjects;
        IServices oClsServices;
        IAboutUs oClsAboutUs;
        IMessages oClsMessages;

        IToastNotification oToastNotification;

        public HomeController(ILogger<HomeController> logger, IHome _oClsHome , IProjects _oClsProjects, IServices _oClsServices, IAboutUs _oClsAboutUs, IMessages _oClsMessages, ISkills _oClsSkills, IToastNotification _oToastNotification)
        {
            _logger = logger;
            oClsHome = _oClsHome;
            oClsProjects = _oClsProjects;
            oClsServices = _oClsServices;
            oClsAboutUs = _oClsAboutUs;
            oClsMessages = _oClsMessages;
            oClsSkills = _oClsSkills;

            oToastNotification = _oToastNotification;
        }

        public IActionResult Index()
        {

            var home = new VwHomeModel();

            home.Home = oClsHome.GetAll();
            home.AboutUs = oClsAboutUs.GetAll();
            home.Services = oClsServices.GetAll();
            home.listProjects = oClsProjects.GetAllDataProjects(null);
            home.listWebApp = oClsProjects.GetAllDataProjects(1);
            home.listMobileApp = oClsProjects.GetAllDataProjects(2);
            home.listBlogs = oClsProjects.GetAllDataProjects(3);
            home.listSkills = oClsSkills.GetAll();

            return View(home);
        }


        public IActionResult DownloadFile(int id)
        {
            var values = oClsHome.GetById(id);
            var fileName = values.FileName;
                                             // File name.              // File path.
            var memory = Helper.DownloadSinghFile(fileName, "wwwroot\\Downloads\\resume");

            //File type.       
            return File(memory.ToArray(), "application/pdf", fileName);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbMessage messags)
        {
            
            if (!ModelState.IsValid)
                return View("Index",messags);

            oClsMessages.Save(messags);

            // For toast alert.
            oToastNotification.AddSuccessToastMessage("Message Delivered");

            return RedirectToAction("Index");
        }
        



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}