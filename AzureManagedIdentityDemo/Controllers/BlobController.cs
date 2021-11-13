using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AzureManagedIdentityDemo.Controllers
{
    [ApiController]
    [Route("/")]
    public class BlobController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string stgConnection = "https://mnl.blob.core.windows.net/container1";
            BlobContainerClient blobContainerClient = new BlobContainerClient(new Uri(stgConnection), new DefaultAzureCredential());
            BlobClient blobClient = blobContainerClient.GetBlobClient("MyPic.jpg");
            var content = blobClient.DownloadContent().Value.Content.ToArray();
            return File(content, "img/png", "a.jpg");
        }
    }
}
