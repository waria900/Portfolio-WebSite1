using Bl;
using Domains;
using Portfolio.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NToastNotify;

namespace Portfolio.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class HomesController : Controller
    {
        IHome oClsHome;
        IToastNotification oToastNotification;
        public HomesController(IHome _oClsHome, IToastNotification _oToastNotification) 
        {
            oClsHome = _oClsHome;
            oToastNotification = _oToastNotification;
        }
        public IActionResult List()
        {
            var home = new TbHome();
            if(oClsHome.GetAll() != null)
            {
                home = oClsHome.GetAll();
            }
            return View(home);
        }

        public IActionResult Edit(int? id)
        {
            var home = new TbHome();
            if (id != 0)
            {
                home = oClsHome.GetById(Convert.ToInt32(id));
            }
            return View(home);
        }

        public async Task<IActionResult> Save(TbHome home, List<IFormFile> Images, List<IFormFile> Files)
        {
            if (!ModelState.IsValid)
                return View("Edit",home);

            home.ImageName = Images.Count() == 0 ? home.ImageName : await Helper.UploadImage(Images, "home");
            home.FileName = Files.Count() == 0 ? home.FileName : await Helper.UploadFile(Files, "resume");

            oClsHome.Save(home);
            // For toast alert.
            oToastNotification.AddSuccessToastMessage("Saved");

            return RedirectToAction("List");

        }


    }
}
