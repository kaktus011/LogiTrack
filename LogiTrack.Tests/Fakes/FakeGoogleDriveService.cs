using Google.Apis.Drive.v3;
using LogiTrack.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiTrack.Tests.Fakes
{
    public class FakeGoogleDriveService : IGoogleDriveService
    {
        public Task<string> UploadFileAsync(string filePath, string mimeType, string parentFolderId)
        {
            
            return Task.FromResult("TEST_FILE_ID");
        }

        public Task<string> GetFileUrlAsync(string fileId)
        {
            
            return Task.FromResult($"https://test.google.com/{fileId}");
        }

        public DriveService GetDriveServiceAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Google.Apis.Drive.v3.Data.File>> ListFilesAsync(int pageSize = 10)
        {
            throw new NotImplementedException();
        }
    }
}
