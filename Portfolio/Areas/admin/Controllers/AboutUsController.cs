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
    public class AboutUsController : Controller
    {
        IAboutUs oClsAboutUs;
        IToastNotification oToastNotification;
        public AboutUsController(IAboutUs _oClsAboutUs, IToastNotification _oToastNotification)
        {
            oClsAboutUs = _oClsAboutUs;
            oToastNotification = _oToastNotification;
        }

        public IActionResult List()
        {
            var about = new TbAbout();
            if (oClsAboutUs.GetAll() != null)
            {
                about = oClsAboutUs.GetAll();
            }
            return View(about);
        }

        public IActionResult Edit(int? id)
        {
            var about = new TbAbout();
            if (id != 0)
            {
                about = oClsAboutUs.GetById(Convert.ToInt32(id));
            }
            return View(about);
        }

        public IActionResult Save(TbAbout about)
        {
            if (!ModelState.IsValid)
                return View("List");

            oClsAboutUs.Save(about);
            oToastNotification.AddSuccessToastMessage("Saved");

            return RedirectToAction("List");

        }

    }
}
