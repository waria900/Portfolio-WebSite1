using Microsoft.AspNetCore.Mvc;
using Domains;
using Bl;
using Microsoft.AspNetCore.Authorization;
using NToastNotify;

namespace Portfolio.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class InformationsController : Controller
    {
        IInformations oClsInformations;
        IToastNotification oToastNotification;
        public InformationsController(IInformations _oClsInformations , IToastNotification _oToastNotification)
        {
            oClsInformations = _oClsInformations;
            oToastNotification = _oToastNotification;
        }

        public IActionResult List()
        {
            var info = new TbInformation();
            if(oClsInformations.GetAll() !=  null) 
                info = oClsInformations.GetAll();


            return View(info);
        }

        public IActionResult Edit(int? id)
        {
            var info = new TbInformation();
            if (id != null)
                info = oClsInformations.GetById(Convert.ToInt32(id));

            return View(info);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbInformation info)
        {
            if(!ModelState.IsValid)
                return View("Edit",info);
            
            oClsInformations.Save(info);
            // For toast alert.
            oToastNotification.AddSuccessToastMessage("Saved");

            return RedirectToAction("List");
        }
    }
}
