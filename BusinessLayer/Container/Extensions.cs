using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUOW;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.ConcreteUOW;
using BusinessLayer.ValidationRules;
using BusinessLayer.ValidationRules.AnnouncementValidationRules;
using BusinessLayer.ValidationRules.ContactUsValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        //Startup service metotları için:
        public static void ContainerDependencies(this IServiceCollection services)
        {
            //Ef bağımlığından kurtulmak ve service ile erişim sağlamak için(admin-commentcontroller):
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();
            //Ef bağımlığından kurtulmak ve service ile erişim sağlamak için(admin-destinationcontroller):
            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EfDestinationDal>();
            //Ef bağımlığından kurtulmak ve service ile erişim sağlamak için(admin-reservationconfirmcontroller):
            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EfReservationDal>();
            //Ef bağımlığından kurtulmak ve service ile erişim sağlamak için(admin-Usercontroller):
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();
            //usercontroller-reservationuser için (admin-Usercontroller):
            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EfReservationDal>();
            //GuideController-Index için (admin-Guidecontroller):
            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EfGuideDal>();
            //ExcelController  için (UI-ExcelController):
            services.AddScoped<IExcelService, ExcelManager>();
            //PdfReportController  için (UI-PdfReportController):
            services.AddScoped<IPdfService, PdfManager>();
            //ContactUsController için (admin-ContactUsController):
            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EfContactUsDal>();
            //AnnouncementController için (admin-AnnouncementController):
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

            //AccountController için(admin-AccountController):
            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountDal, EfAccountDal>();
            //UOW
            services.AddScoped<IUowDal,UowDal>();



        }

        //AnnouncementAddDTOs
        public static void CustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AnnouncementAddDto>, AnnouncementAddValidator>();
            services.AddTransient<IValidator<AnnouncementUpdateDto>, AnnouncementUpdateValidator>();
        }
        //SendMessageDto
        public static void SendContactUsValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<SendMessageDto>, SendContactUsValidator>();
        }
    }
}
