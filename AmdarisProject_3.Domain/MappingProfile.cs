using AmdarisProject_3.Domain.Models.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmdarisProject_3.Domain.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
            //It is redundant
            //.ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
            //.ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName));

            CreateMap<User, UserDto>();

            CreateMap<CommentReactionDto, CommentReaction>();

            CreateMap<CommentReaction, CommentReactionDto>();

            CreateMap<SentimentReactionDto, SentimentReaction>();

            CreateMap<SentimentReaction, SentimentReactionDto>();

            CreateMap<EventDto, Event>();
                /*.ForMember(x => x.Authors, y => y.MapFrom(z => z.Authors))*/

            CreateMap<Event, EventDto>();

            CreateMap<ImagePostDto, ImagePost>();

            CreateMap<ImagePost, ImagePostDto>();

            CreateMap<VideoPostDto, VideoPost>();

            CreateMap<VideoPost, VideoPostDto>();

            CreateMap<TextPostDto, TextPost>();

            CreateMap<TextPost, TextPostDto>();

            CreateMap<MessageDto, Message>();

            CreateMap<Message, MessageDto>();

            CreateMap<RelationshipDto, Relationship>();

            CreateMap<Relationship, RelationshipDto>();
        }
    }
}
