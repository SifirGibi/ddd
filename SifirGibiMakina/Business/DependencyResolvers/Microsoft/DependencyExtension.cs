using Autofac;
using AutoMapper;
using SifirGibiMakina.Business;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.Business.Concrete;
using SifirGibiMakina.Business.Mapper;
using SifirGibiMakina.DataLayer;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.DataLayer.Repositories;
using SifirGibiMakina.DataLayer.Services;
using SifirGibiMakina.DataLayer.UnitOfWork;
using SifirGibiMakina.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.DependencyResolvers.Microsoft
{
    public class DependencyExtension:Module
    {

        public DependencyExtension(ContainerBuilder builder)
        {
            builder.RegisterType<db_SifirGibiMakinaEntities>()
               .InstancePerLifetimeScope();
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BlogProfile()); 
                cfg.AddProfile(new MachineProfile()); 
                cfg.AddProfile(new CompanyLogoProfile()); 
                cfg.AddProfile(new SocialMediaProfile()); 
                cfg.AddProfile(new MachineYearProfile()); 
                cfg.AddProfile(new MachineBrandProfile()); 
                cfg.AddProfile(new CountryProfile()); 
                cfg.AddProfile(new ExpertProfile()); 
                cfg.AddProfile(new FavoriteProfile()); 
                cfg.AddProfile(new MachinePhotoProfile()); 
                cfg.AddProfile(new ServiceEkspertizProfile()); 
                cfg.AddProfile(new MembershipProfile()); 
                cfg.AddProfile(new PaymentInfoProfile()); 
                cfg.AddProfile(new MembershipVersionProfile()); 
                cfg.AddProfile(new UserMemberShipProfile()); 
                cfg.AddProfile(new CardInfoProfile()); 
                cfg.AddProfile(new MachineDetailProfile()); 
                cfg.AddProfile(new PaymentProductPlanProfile()); 
                cfg.AddProfile(new PaymentProductPayPlanProfile()); 
                cfg.AddProfile(new PaymentSubscriberProfile()); 
                cfg.AddProfile(new PaymentLogProfile()); 
                cfg.AddProfile(new SubsReturnPaymentLogProfile()); 
            });

         
         

         
            builder.Register(c => mapperConfiguration.CreateMapper()).As<IMapper>().SingleInstance();

            
                 builder.RegisterType<EfMessageDal>().As<IMessageDal>().InstancePerRequest();
            builder.RegisterType<MessageManager>().As<IMessageService>().InstancePerRequest();

            builder.RegisterType<EfMachineDetailDal>().As<IMachineDetailDal>().InstancePerRequest();
            builder.RegisterType<MachineDetailManager>().As<IMachineDetailService>().InstancePerRequest();

            builder.RegisterType<EfMachinePhotoDal>().As<IMachinePhotoDal>().InstancePerRequest();
            builder.RegisterType<MachinePhotoManager>().As<IMachinePhotoService>().InstancePerRequest();

            builder.RegisterType<EfMachineExpertDal>().As<IMachineExpertDal>().InstancePerRequest();
            builder.RegisterType<MachineExpertManager>().As<IMachineExpertService>().InstancePerRequest();


            builder.RegisterType<EfMachineYearDal>().As<IMachineYearDal>().InstancePerRequest();
            builder.RegisterType<MachineYearManager>().As<IMachineYearService>().InstancePerRequest();


            builder.RegisterType<EfFavoriteDal>().As<IFavoriteDal>().InstancePerRequest();
            builder.RegisterType<FavoriteManager>().As<IFavoriteService>().InstancePerRequest();

            builder.RegisterType<EfExpertDal>().As<IExpertDal>().InstancePerRequest();
            builder.RegisterType<ExperManager>().As<IExpertService>().InstancePerRequest();

            builder.RegisterType<EfUserDal>().As<IUserDal>().InstancePerRequest();
            builder.RegisterType<UserManager>().As<IUserService>().InstancePerRequest();

            builder.RegisterType<EfDistrictDal>().As<IDistrictDal>().InstancePerRequest();


            builder.RegisterType<EfSubCategoryDal>().As<ISubCategoryDal>().InstancePerRequest();

            builder.RegisterType<EfSubSubCategoryDal>().As<ISubSubCategoryDal>().InstancePerRequest();

            builder.RegisterType<EfCountryDal>().As<ICountryDal>().InstancePerRequest();
            builder.RegisterType<CountryManager>().As<ICountryService>().InstancePerRequest();

            builder.RegisterType<EfCityDal>().As<ICityDal>().InstancePerRequest();
            builder.RegisterType<CityManager>().As<ICityService>().InstancePerRequest();

            builder.RegisterType<EfMachineBrandDal>().As<IMachineBrandDal>().InstancePerRequest();
            builder.RegisterType<MachineBrandManager>().As<IMachineBrandService>().InstancePerRequest();

            builder.RegisterType<EfSocialMediaDal>().As<ISocialMediaDal>().InstancePerRequest();
            builder.RegisterType<SocialMediaManager>().As<ISocialMediaService>().InstancePerRequest();

            builder.RegisterType<EfCompanyLogoDal>().As<ICompanyLogoDal>().InstancePerRequest();
            builder.RegisterType<CompanyLogoManager>().As<ICompanyLogoService>().InstancePerRequest();

            builder.RegisterType<BlogManager>().As<IBlogService>().InstancePerRequest();
            builder.RegisterType<EfBlogDal>().As<IBlogDal>().InstancePerRequest();

            builder.RegisterType<EfAdvertisementDal>().As<IAdvertisementDal>().InstancePerRequest();
            builder.RegisterType<AdvertisementManager>().As<IAdvertisementService>().InstancePerRequest();

            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().InstancePerRequest();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().InstancePerRequest();

            builder.RegisterType<EfMachineDal>().As<IMachineDal>().InstancePerRequest();
            builder.RegisterType<MachineManager>().As<IMachineService>().InstancePerRequest();


            builder.RegisterType<EfServiceExpertizDal>().As<IServiceExpertizDal>().InstancePerRequest();
            builder.RegisterType<ServiceExpertizManager>().As<IServiceExpertizService>().InstancePerRequest();



            builder.RegisterType<EfServiceDescriptionDal>().As<IServiceDescriptionDal>().InstancePerRequest();


            builder.RegisterType<EfServiceUserCommentDal>().As<IServiceUserCommentDal>().InstancePerRequest();


            builder.RegisterType<EfServiceEquipmentDetailDal>().As<IServiceEquipmentDetailDal>().InstancePerRequest();


            builder.RegisterType<EfServiceUserDetailDal>().As<IServiceUserDetailDal>().InstancePerRequest();


            builder.RegisterType<EfServiceUsersCategoryDal>().As<IServiceUsersCategoryDal>().InstancePerRequest();
            builder.RegisterType<ServiceUsersCategoryManager>().As<IServiceUsersCategoryService>().InstancePerRequest();


            builder.RegisterType<EfServiceWorkZoneDal>().As<IServiceWorkZoneDal>().InstancePerRequest();
            builder.RegisterType<ServiceWorkZoneManager>().As<IServiceWorkZoneService>().InstancePerRequest();


            builder.RegisterType<ServiceUserDetailManager>().As<IServiceUserDetailService>().InstancePerRequest();



            //Machine DEtails

            builder.RegisterType<MachineCncDetailManager>().As<IMachineCncDetailService>().InstancePerRequest();
            builder.RegisterType<MachineIslemeDetailManager>().As<IMachineIslemeDetailService>().InstancePerRequest();

            builder.RegisterType<EfMirrorSizeDal>().As<IMirrorSizeDal>().InstancePerRequest();
            builder.RegisterType<EfControlUnitDal>().As<IControlUnitDal>().InstancePerRequest();
            builder.RegisterType<EfNumberOfAxesDal>().As<INumberOfAxesDal>().InstancePerRequest();
            builder.RegisterType<EfSpindleRPMDal>().As<ISpindleRPMDal>().InstancePerRequest();
            builder.RegisterType<EfXAxisSizeDal>().As<IXAxisSizeDal>().InstancePerRequest();
            builder.RegisterType<EfYAxisSizeDal>().As<IYAxisSizeDal>().InstancePerRequest();
            builder.RegisterType<EFNumberOfTablesDal>().As<INumberOfTablesDal>().InstancePerRequest();



            builder.RegisterType<AuthManager>().As<IAuthService>().InstancePerRequest();
            builder.RegisterType<EfPaymentProductDal>().As<IPaymentProductDal>().InstancePerRequest();
            builder.RegisterType<EfPaymentProdcutPayPlanDal>().As<IPaymentProdcutPayPlanDal>().InstancePerRequest();


            builder.RegisterType<PaymentManager>().As<IPaymentService>().InstancePerRequest();


            builder.RegisterType<EfPaymentInfoDal>().As<IPaymentInfoDal>().InstancePerRequest();
            builder.RegisterType<EfCardInfoDal>().As<ICardInfoDal>().InstancePerRequest();
            builder.RegisterType<EfPaymentSubscriberDal>().As<IPaymentSubscriberDal>().InstancePerRequest();
            builder.RegisterType<PaymentSubscriberManager>().As<IPaymentSubscriberService>().InstancePerRequest();
            builder.RegisterType<PaymentPlanManager>().As<IPaymentPlanService>().InstancePerRequest();

            builder.RegisterType<EfPaymentLogDal>().As<IPaymentLogDal>().InstancePerRequest();
            builder.RegisterType<PaymentLogManager>().As<IPaymentLogService>().InstancePerRequest();

            builder.RegisterType<EfSubsReturnPaymentLogDal>().As<ISubsReturnPaymentLogDal>().InstancePerRequest();
            builder.RegisterType<SubsReturnPaymentLogManager>().As<ISubsReturnPaymentLogService>().InstancePerRequest();







            builder.RegisterType<EfMembershipDal>().As<IMembershipDal>().InstancePerRequest();
            builder.RegisterType<MembershipManager>().As<IMembershipService>().InstancePerRequest();


            builder.RegisterType<EfMembershipVersionDal>().As<IMembershipVersionDal>().InstancePerRequest();
            builder.RegisterType<MembershipVersionManager>().As<IMembershipVersionService>().InstancePerRequest();


            builder.RegisterType<EfUserMembershipDal>().As<IUserMembershipDal>().InstancePerRequest();
            builder.RegisterType<UserMemberShipManager>().As<IUserMemberShipService>().InstancePerRequest();
            builder.RegisterType<UserMemberShipManager>().As<IUserMemberShipService>().InstancePerRequest();



        }
    }
}