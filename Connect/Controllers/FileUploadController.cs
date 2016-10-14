using ApplicationServices;
using Connect.Helpers;
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
                var userId = CurrentUser.GetParameterByKey("email").ToString();
                imagesHandler.HandleFile(uploadedPicture, userId);
            }
            else
            {
                ModelState.AddModelError("uploadedPicture", "Please select a file.");
            }

            return RedirectToAction("Profile", "Profile", null);
        }
    }
}