using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace TravelerCoreProject.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        //ctor içinde mapleme işlemi yapacagız.
        public MapProfile()
        {
            //for AnnouncementAdd:
            CreateMap<AnnouncementAddDto, Announcement>();
            CreateMap<Announcement, AnnouncementAddDto>();
            //for AnnouncementList:
            CreateMap<AnnouncementListDto, Announcement>();
            CreateMap<Announcement, AnnouncementListDto>();
            //for AnnouncementUpdate:
            CreateMap<AnnouncementUpdateDto, Announcement>();
            CreateMap<Announcement, AnnouncementUpdateDto>();
            //for AppUserRegister:
            CreateMap<AppUserRegisterDTOs, AppUser>();
            CreateMap<AppUser, AppUserRegisterDTOs>();
            //For AppUserLogin:
            CreateMap<AppUserLoginDTOs, AppUser>();
            CreateMap<AppUser, AppUserLoginDTOs>();
            //For ContactController wiew:
            CreateMap<SendMessageDto, ContactUs>().ReverseMap();
            

        }
    }
}
