using Remotion.Linq.Clauses;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.Machine;
using SifirGibiMakina.Dtos.SerivceDescription;
using SifirGibiMakina.Dtos.ServiceComment;
using SifirGibiMakina.Dtos.ServiceEquipment;
using SifirGibiMakina.Dtos.ServiceUserDetail;
using SifirGibiMakina.Dtos.UserServıces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace SifirGibiMakina.Business.Concrete
{
    public class ServiceUserDetailManager : IServiceUserDetailService
    {
        private readonly IServiceUserDetailDal _serviceUserDetailDal;
        private readonly IServiceDescriptionDal _serviceDescriptionDal;
        private readonly IServiceEquipmentDetailDal _serviceEquipmentDetailDal;
        private readonly IUserDal _userDal;
        private readonly IServiceUserCommentDal _userCommentDal;

        public ServiceUserDetailManager(IServiceUserDetailDal serviceUserDetailDal, IServiceDescriptionDal serviceDescriptionDal, IServiceEquipmentDetailDal serviceEquipmentDetailDal, IUserDal userDal, IServiceUserCommentDal userCommentDal)
        {
            _serviceUserDetailDal = serviceUserDetailDal;
            _serviceDescriptionDal = serviceDescriptionDal;
            _serviceEquipmentDetailDal = serviceEquipmentDetailDal;
            _userDal = userDal;
            _userCommentDal = userCommentDal;
        }

        public bool isSerivePhotoExists(int id)
        {
            return _serviceUserDetailDal.GetAny(x=>x.ServiceUserID  == id);
            
        }
        public bool isSeriveDescriptionExists(int id)
        {
            return _serviceDescriptionDal.GetAny(x => x.ServiceUserID == id);
       
           
        }

        public void AddServiceUserLogo(CreateServiceUserDetailDto createServiceUserDetailDto)
        {

            tbl_ServiceUserDetail tbl_ServiceUserDetail = new tbl_ServiceUserDetail()
            {
                ServiceUserID = createServiceUserDetailDto.ServiceUserID,
                ServiceUserLogo = createServiceUserDetailDto.ServiceUserLogo,
                ServiceUserBigLogo = createServiceUserDetailDto.ServiceUserBigLogo,
            
                CreatedDate = DateTime.Now,

            };

            _serviceUserDetailDal.Add(tbl_ServiceUserDetail);
            _serviceUserDetailDal.SaveChanges();



        }
        public void DeleteEquipment(int id)
        {

            var serviceEquipment = _serviceEquipmentDetailDal.Get(x=>x.ServiceEquipmentDetailID == id);

            if(serviceEquipment != null)
            {

                _serviceEquipmentDetailDal.Delete(serviceEquipment);
                _serviceEquipmentDetailDal.SaveChanges();
            }

        }

        public void AddEquipment(CreateEquipmentDto createEquipmentDto)
        {


            tbl_ServiceEquipmentDetail tbl_ServiceEquipmentDetail = new tbl_ServiceEquipmentDetail
            {
                ServiceUserID = createEquipmentDto.ServiceUserID,
                ServiceEquipmentDetailName = createEquipmentDto.ServiceEquipmentDetailName,
                CreatedDate = DateTime.Now,

            };
            _serviceEquipmentDetailDal.Add(tbl_ServiceEquipmentDetail);
            _serviceEquipmentDetailDal.SaveChanges();




        }
        public List<tbl_ServiceEquipmentDetail> GetlistServiceEquipmentDetail(int id)
        {
        

            var result = _serviceEquipmentDetailDal.GetList(x => x.ServiceUserID == id);
            if(result != null)
            return result.ToList();


            return new List<tbl_ServiceEquipmentDetail>();
        }
        public void UpdateServiceUserLogo(CreateServiceUserDetailDto updateServiceUserDetailDto)
        {

            var serviceUserDetail = _serviceUserDetailDal.Get(x => x.ServiceUserID == updateServiceUserDetailDto.ServiceUserID);

            if (serviceUserDetail != null)
            {

      
                if(updateServiceUserDetailDto.ServiceUserLogo == null)
                {

                    serviceUserDetail.ServiceUserBigLogo = updateServiceUserDetailDto.ServiceUserBigLogo;

                }
                else if(updateServiceUserDetailDto.ServiceUserBigLogo == null)
                {

                    serviceUserDetail.ServiceUserLogo = updateServiceUserDetailDto.ServiceUserLogo;
                }
                else
                {

                    serviceUserDetail.ServiceUserBigLogo = updateServiceUserDetailDto.ServiceUserBigLogo;
                    serviceUserDetail.ServiceUserLogo = updateServiceUserDetailDto.ServiceUserLogo;
                }
               
                serviceUserDetail.UpdatedDate = DateTime.Now;






            }
            _serviceUserDetailDal.Update(serviceUserDetail);
            _serviceUserDetailDal.SaveChanges();




        }


        public void CreateDespriction(CreateSerivceDescriptionDto createSerivceDescriptionDto)
        {

            
            tbl_ServiceDescription tbl_ServiceDescription = new tbl_ServiceDescription
            {

                ServiceUserID = createSerivceDescriptionDto.ServiceUserID,
                ServiceDescriptionTr = createSerivceDescriptionDto.ServiceDescriptionTr,
                ServiceDescriptionEng = Translate.OtomatikCeviri(createSerivceDescriptionDto.ServiceDescriptionTr, "EN"),
                ServiceDescriptionDe = Translate.OtomatikCeviri(createSerivceDescriptionDto.ServiceDescriptionTr, "DE"),
                ServiceDescriptionRu = Translate.OtomatikCeviri(createSerivceDescriptionDto.ServiceDescriptionTr, "RU"),



            };

       
            _serviceDescriptionDal.Add(tbl_ServiceDescription);  
            _serviceDescriptionDal.SaveChanges();







        }
        public void UpdateDespriction(CreateSerivceDescriptionDto createSerivceDescriptionDto)
        {
            var serviceUserDetail = _serviceDescriptionDal.Get(x => x.ServiceUserID == createSerivceDescriptionDto.ServiceUserID);
            if(serviceUserDetail != null)
            {

                serviceUserDetail.ServiceDescriptionTr = createSerivceDescriptionDto.ServiceDescriptionTr;
                     serviceUserDetail.ServiceDescriptionEng = Translate.OtomatikCeviri(createSerivceDescriptionDto.ServiceDescriptionTr, "EN");
             serviceUserDetail.ServiceDescriptionDe = Translate.OtomatikCeviri(createSerivceDescriptionDto.ServiceDescriptionTr, "DE");
                serviceUserDetail.ServiceDescriptionRu = Translate.OtomatikCeviri(createSerivceDescriptionDto.ServiceDescriptionTr, "RU");




            }
        


            _serviceDescriptionDal.Update(serviceUserDetail);
            _serviceDescriptionDal.SaveChanges();







        }

      
        public List<GetListServiceFirmDto> GetListServiceFirm(int id)
        {
        
      
            var result = _userDal.GetListServiceFirm(id);

            if(result.Count() != 0)
            return result.ToList();

            return null;





        }


        public GetServiceUserWithIDDto GetServiceUserWithDetails(int id)
        {


            var result = _userDal.GetServiceUserWithDetails(id);
            if (result != null)
            {
                return result;

            }

            return null;


        }


        public int  UserCommentAvarge(int id)
        {

         


            var list = _userCommentDal.GetList(x=>x.ServiceTargetUserID == id);

            if(list != null)
            {
                var ratingAverage = list.Average(comment => comment.CommentRating);



                return Convert.ToInt32(ratingAverage);

            }

          return 0;



        }



        public List<GetListServiceCommentByUserId> GetCommentList(int id)
        {


            var result = _userCommentDal.GetCommentsByServiceUserID(id);

            if(result != null)
            {


                return result;
            }

            return null;
        }

        public List<ListServiceUserDto> ListServiceUser()
        {
            var result = _userDal.ListServiceUser();

            if (result != null)
            {


                return result;
            }

            return null;




        }

        public void AddServiceComment(CreateCommentDto dto)
        {

            tbl_ServiceUserComment userComment = new tbl_ServiceUserComment
            {
                CommentText = dto.CommentText,
                CommentRating = dto.CommentRating,
                ServiceCommenterUserID = dto.ServiceCommenterUserID,    
                ServiceTargetUserID = dto.ServiceTargetUserID,
                CreatedDate = DateTime.Now,
                


            };
            _userCommentDal.Add(userComment);
            _userCommentDal.SaveChanges();
        }
    }
}