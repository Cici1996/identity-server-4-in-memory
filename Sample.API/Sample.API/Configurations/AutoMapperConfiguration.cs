using AutoMapper;
using Sample.API.Models;
using Sample.API.Models.Requests;
using Sample.Core.DataTransperObjects;
using Sample.DataAccessLayer.Entities;

namespace Sample.API.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            RegisterMeetingEvent();
        }

        public void RegisterMeetingEvent()
        {
            CreateMap<MeetingEventRequest, MeetingEventModel>();
            CreateMap<MeetingEvent, MeetingEventDTO>().ReverseMap();
            CreateMap<MeetingEventDTO, MeetingEventModel>().ReverseMap();
        }
    }
}