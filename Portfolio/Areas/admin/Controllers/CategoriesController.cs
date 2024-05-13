using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Bl;
using Domains;
using Microsoft.AspNetCore.Authorization;
using NToastNotify;

namespace Portfolio.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class CategoriesController : Controller
    {
        ICategories oClsCategories;

        IToastNotification oToastNotification;
        public CategoriesController(ICategories _oClsCategories, IToastNotification _oToastNotification) 
        {
            oClsCategories = _oClsCategories;
            oToastNotification = _oToastNotification;
        }

        public IActionResult List()
        {
            var listCategories = new List<TbCategory>();
            if(oClsCategories != null) 
            {
                listCategories = oClsCategories.GetAll();
            }
            return View(listCategories);
        }

        public IActionResult Edit(int? id)
        {
            var category = new TbCategory();
            if(id != null)
            {
                category = oClsCategories.GetById(Convert.ToInt32(id));
            }
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbCategory category)
        {
            if (!ModelState.IsValid)
                return View("Edit",category);

            oClsCategories.Save(category);
            // For toast alert.
            oToastNotification.AddSuccessToastMessage("Saved");

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            oClsCategories.Delete(id);
            // For toast alert.
            oToastNotification.AddSuccessToastMessage("One Category has removed");
            return RedirectToAction("List");
        }

    }
}
