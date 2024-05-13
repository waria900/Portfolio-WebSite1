using Bl;
using Domains;
using Portfolio.Models;
using Portfolio.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using NToastNotify;

namespace Portfolio.Areas.admin.Controllers
{

    [Area("admin")]
    [Authorize]
    public class ProjectsController : Controller
    {
        IProjects oClsProjects;
        ICategories oClsCategories;
        IToastNotification oToastNotification;
        public ProjectsController(IProjects _oClsProjects, ICategories _oClsCategories, IToastNotification _oToastNotification)
        {
            oClsProjects = _oClsProjects;
            oClsCategories = _oClsCategories;
            oToastNotification = _oToastNotification;
        }

        public IActionResult List()
        {
            var listProjects = new List<VwProject>();
            if (oClsProjects.GetAllDataProjects(null).Count() != 0)
            {
                listProjects = oClsProjects.GetAllDataProjects(null);
            }
            ViewBag.listCategories = oClsCategories.GetAll();

            

            return View(listProjects);
        }

        public IActionResult Search(int id)
        {
            
            var listProjects = oClsProjects.GetAllDataProjects(id);
            ViewBag.listCategories = oClsCategories.GetAll();
            // For toast alert.
            oToastNotification.AddInfoToastMessage("Selected Project");
            return View("List",listProjects);

        }

        public IActionResult Edit(int? id)
        {
            var project = new TbProject();
            ViewBag.listCategories = oClsCategories.GetAll();
            if (id != null)
            {
                project = oClsProjects.GetById(Convert.ToInt32(id));
            }

           // string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(project);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbProject project, List<IFormFile> Images)
        {
            if (!ModelState.IsValid)
                return View("Edit",project);

            

            project.ImageName = Images.Count() == 0 ? project.ImageName : await Helper.UploadImage(Images, "projects");

            oClsProjects.Save(project);
            // For toast alert.
            oToastNotification.AddSuccessToastMessage("Saved");

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            oClsProjects.Delete(id);
            // For toast alert.
            oToastNotification.AddSuccessToastMessage("Project has removed");
            return RedirectToAction("List");
        }
    }
}
