using System;
using Models;
using Connect.Helpers;

namespace ApplicationServices
{
    public class FileManagementApplicationService : IFileManagementApplicationService
    {
        public File Execute(File command)
        {
            var uploadedFile = WebServiceProvider<File>.Post(command, UrlHelper.UploadFileUrl);
            return uploadedFile;
        }
    }
}
