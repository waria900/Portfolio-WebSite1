using Microsoft.AspNetCore.Mvc;
using Bl;
using Domains;
using Microsoft.AspNetCore.Authorization;
using NToastNotify;

namespace Portfolio.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class MessagesController : Controller
    {
        IMessages oClsMessages;

        // For toast alert.
        IToastNotification oToastNotification;
        public MessagesController(IMessages _oClsMessages, IToastNotification _oToastNotification)
        {
            oClsMessages = _oClsMessages;
            oToastNotification = _oToastNotification;
        }

        public IActionResult List()
        {
            var listMessages = new List<TbMessage>();
            if (oClsMessages.GetAll().Count() > 0)
            {
                listMessages = oClsMessages.GetAll();
            }
            return View(listMessages);

        }

        public IActionResult Delete(int id)
        {
            oClsMessages.Delete(id);
            // For toast alert.
            oToastNotification.AddSuccessToastMessage("Message has removed");

            return RedirectToAction("List");
        }
    }
}
