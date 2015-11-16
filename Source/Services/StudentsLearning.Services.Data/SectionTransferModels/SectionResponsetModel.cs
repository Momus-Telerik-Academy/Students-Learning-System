namespace StudentsLearning.Server.Api.Models.SectionTransferModels
{
    #region

    using System.Collections.Generic;

    #endregion

    public class SectionResponsetModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<TopicResponseMinifiedModel> Topics { get; set; }
    }
}