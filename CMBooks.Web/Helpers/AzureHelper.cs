using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Web;
using System.IO;

namespace CMBooks.Web.Helpers
{
    public class AzureHelper
    {
        public static string Upload(HttpPostedFileBase file, string name)
        {
            CloudStorageAccount AzureStorage = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=cmbooks;AccountKey=4SjV5X1PIRShvLxSRmvREag12HEtfBOkQAhIyIUBVNkr98zfB03foIZK/JTF254DJD41y1bG4OP1YI3eiZrveQ==;EndpointSuffix=core.windows.net");
            CloudBlobClient BlobClient = AzureStorage.CreateCloudBlobClient();
            CloudBlobContainer Container = BlobClient.GetContainerReference("cmbooks-photos");
            var extension = Path.GetExtension(file.FileName);

            CloudBlockBlob BlockBlob = Container.GetBlockBlobReference($"{name}-{Guid.NewGuid()}{extension}"); //the name of the file: we should use somtething like: photo-issueID

            var fileStream = file.InputStream;
            BlockBlob.UploadFromStream(fileStream); //actual upload

            return BlockBlob.Uri.AbsoluteUri;
        }
        
    }
}