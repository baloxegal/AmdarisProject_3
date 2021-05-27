using AmdarisProject_3.Domain.Models.Dtos;
using AmdarisProject_3.Domain.Models;
using AutoMapper;

namespace AmdarisProject_3.Domain
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

            CreateMap<EventDto, Event>();

            CreateMap<Event, EventDto>();

            CreateMap<CommentReactionDto, CommentReaction>()
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author));

            CreateMap<CommentReaction, CommentReactionDto>()
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author));

            CreateMap<SentimentReactionDto, SentimentReaction>()
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author));

            CreateMap<SentimentReaction, SentimentReactionDto>()
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author));

            CreateMap<ImagePostDto, ImagePost>()
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author));

            CreateMap<ImagePost, ImagePostDto>()
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author));

            CreateMap<VideoPostDto, VideoPost>()
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author));

            CreateMap<VideoPost, VideoPostDto>()
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author));

            CreateMap<TextPostDto, TextPost>()
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author));

            CreateMap<TextPost, TextPostDto>()
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author));

            CreateMap<MessageDto, Message>()
                .ForMember(x => x.Sender, y => y.MapFrom(z => z.Sender))
                .ForMember(x => x.Receiver, y => y.MapFrom(z => z.Receiver));

            CreateMap<Message, MessageDto>()
                .ForMember(x => x.Sender, y => y.MapFrom(z => z.Sender))
                .ForMember(x => x.Receiver, y => y.MapFrom(z => z.Receiver));

            CreateMap<RelationshipDto, Relationship>()
                .ForMember(x => x.Initiator, y => y.MapFrom(z => z.Initiator))
                .ForMember(x => x.Respondent, y => y.MapFrom(z => z.Respondent));

            CreateMap<Relationship, RelationshipDto>()
                .ForMember(x => x.Initiator, y => y.MapFrom(z => z.Initiator))
                .ForMember(x => x.Respondent, y => y.MapFrom(z => z.Respondent));
        }
    }
}
