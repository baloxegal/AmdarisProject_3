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

            CreateMap<User, UserDto>();

            CreateMap<Event, EventDto>();

            CreateMap<EventDto, Event>();            

            CreateMap<CommentReactionDto, CommentReaction>()
                .ForPath(x => x.Author.UserName, y => y.MapFrom(z => z.Author));

            CreateMap<CommentReaction, CommentReactionDto>()
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author.UserName));

            CreateMap<SentimentReactionDto, SentimentReaction>()
                .ForPath(x => x.Author.UserName, y => y.MapFrom(z => z.Author));

            CreateMap<SentimentReaction, SentimentReactionDto>()
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author.UserName));

            CreateMap<ImagePostDto, ImagePost>()
                .ForPath(x => x.Author.UserName, y => y.MapFrom(z => z.Author));

            CreateMap<ImagePost, ImagePostDto>()
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author.UserName));

            CreateMap<VideoPostDto, VideoPost>()
                .ForPath(x => x.Author.UserName, y => y.MapFrom(z => z.Author));

            CreateMap<VideoPost, VideoPostDto>()
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author.UserName));

            CreateMap<TextPostDto, TextPost>()
                .ForPath(x => x.Author.UserName, y => y.MapFrom(z => z.Author));

            CreateMap<TextPost, TextPostDto>()
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author.UserName));

            CreateMap<MessageDto, Message>()
                .ForPath(x => x.Sender.UserName, y => y.MapFrom(z => z.Sender))
                .ForPath(x => x.Receiver.UserName, y => y.MapFrom(z => z.Receiver));

            CreateMap<Message, MessageDto>()
                .ForMember(x => x.Sender, y => y.MapFrom(z => z.Sender.UserName))
                .ForMember(x => x.Receiver, y => y.MapFrom(z => z.Receiver.UserName));

            CreateMap<RelationshipDto, Relationship>()
                .ForPath(x => x.Initiator.UserName, y => y.MapFrom(z => z.Initiator))
                .ForPath(x => x.Respondent.UserName, y => y.MapFrom(z => z.Respondent));

            CreateMap<Relationship, RelationshipDto>()
                .ForMember(x => x.Initiator, y => y.MapFrom(z => z.Initiator.UserName))
                .ForMember(x => x.Respondent, y => y.MapFrom(z => z.Respondent.UserName));
        }
    }
}
