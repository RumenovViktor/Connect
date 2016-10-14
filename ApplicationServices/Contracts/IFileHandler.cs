using System.Web;

namespace ApplicationServices
{
    public interface IFileHandler
    {
        void HandleFile(HttpPostedFileBase uploadedPicture, string userId);
    }
}
