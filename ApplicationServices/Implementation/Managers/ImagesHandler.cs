using System.Web;

using Models;

namespace ApplicationServices
{
    public class ImagesHandler : IFileHandler
    {
        private readonly IFileManagementApplicationService imageManagementApplicationService;

        public ImagesHandler(IFileManagementApplicationService imageManagementApplicationService)
        {
            this.imageManagementApplicationService = imageManagementApplicationService;
        }

        public void HandleFile(HttpPostedFileBase uploadedPicture, int userId)
        {
            var fileBuffer = new byte[uploadedPicture.InputStream.Length];
            uploadedPicture.InputStream.Read(fileBuffer, 0, fileBuffer.Length);

            var postedFileModel = new File(uploadedPicture.FileName, fileBuffer, userId);

            imageManagementApplicationService.Execute(postedFileModel);
        }
    }
}
