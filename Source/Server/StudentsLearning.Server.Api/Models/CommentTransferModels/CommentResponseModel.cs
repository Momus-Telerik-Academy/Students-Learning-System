namespace StudentsLearning.Server.Api.Models.CommentTransferModels
{
    using System;
    using AutoMapper;
    using StudentsLearning.Data.Models;
    using StudentsLearning.Server.Api.Infrastructure.Mapping;

    public class CommentResponseModel : IHaveCustomMappings, IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public int TopicId { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Comment, CommentResponseModel>()
                .ForMember(m => m.Username, opt => opt.MapFrom(u => u.User.UserName));
        }
    }
}