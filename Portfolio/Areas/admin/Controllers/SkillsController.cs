using Bl;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Portfolio.Utilities;

namespace Portfolio.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class SkillsController : Controller
    {
        ISkills oClsSkills;
        IToastNotification oToastNotification;
        public SkillsController(ISkills _oClsSkills, IToastNotification _oToastNotification) 
        {
            oClsSkills = _oClsSkills;
            oToastNotification = _oToastNotification;
        }

        public IActionResult List()
        {
            var listSkills = new List<TbSkill>();
            if (oClsSkills.GetAll().Count() != 0)
            {
                listSkills = oClsSkills.GetAll();
            }
    
            return View(listSkills);
        }


        public IActionResult Edit(int? id)
        {
            var skill = new TbSkill();

            if (id != null)
            {
                skill = oClsSkills.GetById(Convert.ToInt32(id));
            }


            return View(skill);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbSkill skill, List<IFormFile> Images)
        {
            if (!ModelState.IsValid)
                return View("Edit",skill);

            skill.ImageName = Images.Count() == 0 ? skill.ImageName : await Helper.UploadImage(Images, "skills");

            oClsSkills.Save(skill);
            // For toast alert.
            oToastNotification.AddSuccessToastMessage("Saved");

            return RedirectToAction("List");
        }
    }
}
