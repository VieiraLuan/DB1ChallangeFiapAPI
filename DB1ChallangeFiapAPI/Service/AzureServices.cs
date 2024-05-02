using Azure.Storage.Blobs;
using DB1ChallangeFiapAPI.Service.Interface;

namespace DB1ChallangeFiapAPI.Service
{
    public class AzureServices : IAzureServices
    {
        private string connectionString = "belelelelele";
        public async Task<string> UploadFileToAzure(byte[] file, string container)
        {
            if (file != null)
            {
                try
                {
                    var filename = Guid.NewGuid().ToString() + ".png";
                    var blobClient = new BlobClient(connectionString, container, filename);

                    await blobClient.UploadAsync(new MemoryStream(file));

                    var result = blobClient.Uri.ToString();

                    if (!String.IsNullOrEmpty(result))
                    {
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);

                }

            }
            else
            {
                return null;
            }

        }


    }
}
