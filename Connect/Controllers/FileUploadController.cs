using ApplicationServices;
using Connect.Helpers;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Mvc;

namespace Connect.Controllers
{
    public class FileUploadController : BaseController
    {
        private readonly IFileHandler imagesHandler;

        public FileUploadController(IFileHandler imagesHandler)
        {
            this.imagesHandler = imagesHandler;
        }

        [HttpPost]
        public ActionResult UploadPicture(HttpPostedFileBase uploadedPicture)
        {
            if (uploadedPicture != null)
            {
                var userId = User.Identity.GetUserId();
                imagesHandler.HandleFile(uploadedPicture, int.Parse(userId));
            }
            else
            {
                ModelState.AddModelError("uploadedPicture", "Please select a file.");
            }

            return RedirectToAction("Profile", "Profile", null);
        }
    }
}