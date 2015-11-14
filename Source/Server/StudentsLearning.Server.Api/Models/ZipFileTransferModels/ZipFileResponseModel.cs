namespace StudentsLearning.Server.Api.Models.ZipFileTransferModels
{
    public class ZipFileResponseModel
    {
        public int TopicId { get; set; }

        public string OriginalName { get; set; }

        public string DbName { get; set; }

        public string Path { get; set; }
    }
}