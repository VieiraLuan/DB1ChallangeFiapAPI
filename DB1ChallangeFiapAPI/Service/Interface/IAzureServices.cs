namespace DB1ChallangeFiapAPI.Service.Interface
{
    public interface IAzureServices
    {

        public Task<string> UploadFileToAzure(byte[] file, string container);
    }
}
