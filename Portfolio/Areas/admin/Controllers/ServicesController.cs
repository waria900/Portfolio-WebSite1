using Microsoft.AspNetCore.Mvc;
using Domains;
using Bl;
using Portfolio.Utilities;
using Microsoft.AspNetCore.Authorization;
using NToastNotify;

namespace Portfolio.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class ServicesController : Controller
    {
        IServices oClsServices;
        IToastNotification oToastNotification;
        public ServicesController(IServices _oClsServices, IToastNotification _oToastNotification)
        {
            oClsServices = _oClsServices;
            oToastNotification = _oToastNotification;
        }

        public IActionResult List()
        {
            var listServices = new List<TbService>();
            if (oClsServices.GetAll().Count() != 0)
            {
                listServices = oClsServices.GetAll();
            }
            return View(listServices);
        }


        public IActionResult Edit(int? id)
        {
            var service = new TbService();
            if (id != null)
            {
                service = oClsServices.GetById(Convert.ToInt32(id));
            }

            return View(service);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbService service, List<IFormFile> Images)
        {
            if (!ModelState.IsValid)
                return View("Edit",service);

            service.ImageName = Images.Count() == 0 ? service.ImageName : await Helper.UploadImage(Images, "services");

            oClsServices.Save(service);
            // For toast alert.
            oToastNotification.AddSuccessToastMessage("Saved");

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            oClsServices.Delete(id);
            // For toast alert.
            oToastNotification.AddSuccessToastMessage("One service has removed");
            return RedirectToAction("List");
        }


    }
}
