using AutoMapper;
using MessagingToolkit.QRCode.Codec;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.Machine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Data.SqlTypes;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using MessagingToolkit.QRCode;
using System.Configuration;
using System.Runtime.Remoting.Contexts;
using SifirGibiMakina.Dtos.UserMembership;
using SifirGibiMakina.Models;

namespace SifirGibiMakina.Business.Concrete
{
    public class MachineManager : IMachineService
    {

        private readonly IMapper _mapper;
        private readonly IMachineDal _machineDal;
        private readonly IUserMembershipDal _userMemberShipDal;



        public MachineManager(IMapper mapper, IMachineDal machineDal, IUserMembershipDal userMemberShipDal)
        {
            _mapper = mapper;
            _machineDal = machineDal;
            _userMemberShipDal = userMemberShipDal;
        }

        public List<MachineShowcaseListDto> GetMachineList()
        {
            var cachedData = DataCacheHelper.GetDataFromCacheOrDB(
                "MachineListCacheKey",
                () => _machineDal.GetMachineDetails(),
                TimeSpan.FromMinutes(10)
            );

            return cachedData;
        }


        public int CreateMachine(MachineCreateDto machineCreateDto)
        {
            try
            {
               var createdMachine = _mapper.Map<tbl_Makinalar>(machineCreateDto);

                _machineDal.Add(createdMachine);
                _machineDal.SaveChanges();


                var id = createdMachine.makina_ID;

                createdMachine.IlanNo = DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString() + id.ToString();
                _machineDal.Update(createdMachine);
                _machineDal.SaveChanges();




              


                return id;
            }
            catch 
            {


                return -1;


            }

        }

     
        public tbl_Makinalar GetMachine(int id)
        {


            return _machineDal.Get(x => x.makina_ID == id);


        }

        public CheckCountModel GetNoticeCount(int id)
        {
           var user = _userMemberShipDal.GetUserMembership(id);
            CheckCountModel model = new CheckCountModel();  
            if (user == null)
            {
               var machineCount=  _machineDal.GetCount(x => x.Ekleyen == id && (x.Statu == 1 || x.Statu == 2 || x.Statu == 5 || x.Statu == 8));
                model.CountActiveMachine = machineCount;
                model.IsUser = false;
                model.MaxAds = 3;
                return model;

            }
            else
            {

                var machineCount = _machineDal.GetCount(x => x.Ekleyen == id && (x.Statu == 1 || x.Statu == 2 || x.Statu == 5 || x.Statu == 8) && x.Kayit_Tarihi >= user.CreatedDate);
               
                model.CountActiveMachine = machineCount;
                model.IsUser = true;
                model.MaxAds = user.MaxAds;
                return model;

            }
              
           
        }
        public bool machineGetUrls(string url)
        {
            return _machineDal.GetAny(c => c.SEOUrl == url || c.SEOUrlEN == url || c.SEOUrlDE == url);

        }
        public int GetIdBySeoUrl(string seoUrl)
        {
            return _machineDal.Get(x => x.SEOUrl == seoUrl)?.makina_ID ?? 0;
        }

        public void IncreaseFavoriteCount(int machineId)
        {
            var machine = _machineDal.Find(machineId);

            if (machine != null)
            {
                machine.FavoriSayisi++;
                _machineDal.SaveChanges();


            }

        }

        public int FavoriteCount(int machineId)
        {

            var machine = _machineDal?.Find(machineId);
            if (machine != null)
            {
                if (machine.FavoriSayisi.HasValue)
                {
                    return machine.FavoriSayisi.Value;
                }
                return 0;
            }
            return 0;
        }

        public void ReduceFavoriteCount(int machineId)
        {
            var machine = _machineDal.Find(machineId);

            if (machine != null)
            {
                machine.FavoriSayisi--;
                _machineDal.SaveChanges();


            }
        }

        public void IncreaseVisiblePhoneCount(int machineId)
        {
            var machine = _machineDal.Find(machineId);

            if (machine != null)
            {
                machine.TelefonNumarasiGostermeSayisi++;
                _machineDal.SaveChanges();


            }
        }

        public GetMachineDetailListWithIdDto GetMachineWithIdDetails(int id)
        {
            var result = _machineDal.GetMachineIdDetails(id);
              
           

            return result;
           
        }
        public void IncreaseViewMachineCount(int machineId)
        {
            var machine = _machineDal.Find(machineId);

            if (machine != null)
            {
                machine.GoruntulenmeSayisi++;
                _machineDal.SaveChanges();


            }
        }

      
    }
}