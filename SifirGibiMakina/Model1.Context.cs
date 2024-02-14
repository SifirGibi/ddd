﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SifirGibiMakina
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_SifirGibiMakinaEntities : DbContext
    {
        public db_SifirGibiMakinaEntities()
            : base("name=db_SifirGibiMakinaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<tbl_Ayarlar> tbl_Ayarlar { get; set; }
        public virtual DbSet<tbl_BeniHaberdarEt> tbl_BeniHaberdarEt { get; set; }
        public virtual DbSet<tbl_Diller> tbl_Diller { get; set; }
        public virtual DbSet<tbl_Duyurular> tbl_Duyurular { get; set; }
        public virtual DbSet<tbl_DuyurularCat> tbl_DuyurularCat { get; set; }
        public virtual DbSet<tbl_Expertiz> tbl_Expertiz { get; set; }
        public virtual DbSet<tbl_Firmalar> tbl_Firmalar { get; set; }
        public virtual DbSet<tbl_FirmaLogolari> tbl_FirmaLogolari { get; set; }
        public virtual DbSet<tbl_Icerikler> tbl_Icerikler { get; set; }
        public virtual DbSet<tbl_Ihale> tbl_Ihale { get; set; }
        public virtual DbSet<tbl_Iletisim> tbl_Iletisim { get; set; }
        public virtual DbSet<tbl_ilanFavorileri> tbl_ilanFavorileri { get; set; }
        public virtual DbSet<tbl_ilanKategoriListeleme> tbl_ilanKategoriListeleme { get; set; }
        public virtual DbSet<tbl_ilanMesajlari> tbl_ilanMesajlari { get; set; }
        public virtual DbSet<tbl_Kullanicilar> tbl_Kullanicilar { get; set; }
        public virtual DbSet<tbl_MakinaAltTurleri> tbl_MakinaAltTurleri { get; set; }
        public virtual DbSet<tbl_MakinaAltTurleri2> tbl_MakinaAltTurleri2 { get; set; }
        public virtual DbSet<tbl_MakinaEksper> tbl_MakinaEksper { get; set; }
        public virtual DbSet<tbl_MakinaEksperSecimi> tbl_MakinaEksperSecimi { get; set; }
        public virtual DbSet<tbl_MakinaIhale> tbl_MakinaIhale { get; set; }
        public virtual DbSet<tbl_MakinaIslemler> tbl_MakinaIslemler { get; set; }
        public virtual DbSet<tbl_MakinaMarkalari> tbl_MakinaMarkalari { get; set; }
        public virtual DbSet<tbl_MakinamNeEder> tbl_MakinamNeEder { get; set; }
        public virtual DbSet<tbl_MakinamNeEderResimler> tbl_MakinamNeEderResimler { get; set; }
        public virtual DbSet<tbl_MakinaResimler> tbl_MakinaResimler { get; set; }
        public virtual DbSet<tbl_MakinaTurleri> tbl_MakinaTurleri { get; set; }
        public virtual DbSet<tbl_MakinaYillar> tbl_MakinaYillar { get; set; }
        public virtual DbSet<tbl_OdemeBildirimleri> tbl_OdemeBildirimleri { get; set; }
        public virtual DbSet<tbl_SagMenu> tbl_SagMenu { get; set; }
        public virtual DbSet<tbl_Servis> tbl_Servis { get; set; }
        public virtual DbSet<tbl_Slider> tbl_Slider { get; set; }
        public virtual DbSet<tbl_SosyalMedya> tbl_SosyalMedya { get; set; }
        public virtual DbSet<tbl_SSS> tbl_SSS { get; set; }
        public virtual DbSet<tbl_TeknikDestek> tbl_TeknikDestek { get; set; }
        public virtual DbSet<tbl_Makinalar> tbl_Makinalar { get; set; }
        public virtual DbSet<tbl_Ulkeler> tbl_Ulkeler { get; set; }
        public virtual DbSet<tbl_ReklamAlanlari> tbl_ReklamAlanlari { get; set; }
        public virtual DbSet<tbl_Reklamlar> tbl_Reklamlar { get; set; }
        public virtual DbSet<tbl_ilanEmail> tbl_ilanEmail { get; set; }
        public virtual DbSet<Sehirler> Sehirler { get; set; }
        public virtual DbSet<Ilceler> Ilceler { get; set; }
        public virtual DbSet<tbl_ServiceDescription> tbl_ServiceDescription { get; set; }
        public virtual DbSet<tbl_ServiceUserComment> tbl_ServiceUserComment { get; set; }
        public virtual DbSet<tbl_ServiceUserDetail> tbl_ServiceUserDetail { get; set; }
        public virtual DbSet<tbl_ServiceUsersCategory> tbl_ServiceUsersCategory { get; set; }
        public virtual DbSet<tbl_ServiceWorkZone> tbl_ServiceWorkZone { get; set; }
        public virtual DbSet<tbl_ControlUnit> tbl_ControlUnit { get; set; }
        public virtual DbSet<tbl_MirrorSize> tbl_MirrorSize { get; set; }
        public virtual DbSet<tbl_NumberOfAxes> tbl_NumberOfAxes { get; set; }
        public virtual DbSet<tbl_NumberOfTables> tbl_NumberOfTables { get; set; }
        public virtual DbSet<tbl_SpindleRPM> tbl_SpindleRPM { get; set; }
        public virtual DbSet<tbl_XAxisSize> tbl_XAxisSize { get; set; }
        public virtual DbSet<tbl_YAxisSize> tbl_YAxisSize { get; set; }
        public virtual DbSet<tbl_MachineDetail> tbl_MachineDetail { get; set; }
        public virtual DbSet<tbl_ServiceEquipmentDetail> tbl_ServiceEquipmentDetail { get; set; }
        public virtual DbSet<tbl_Membership> tbl_Membership { get; set; }
        public virtual DbSet<tbl_PaymentPlan> tbl_PaymentPlan { get; set; }
        public virtual DbSet<tbl_CardInfo> tbl_CardInfo { get; set; }
        public virtual DbSet<tbl_PaymentInfo> tbl_PaymentInfo { get; set; }
        public virtual DbSet<tbl_PaymentProduct> tbl_PaymentProduct { get; set; }
        public virtual DbSet<tbl_PaymentProdcutPayPlan> tbl_PaymentProdcutPayPlan { get; set; }
        public virtual DbSet<tbl_PaymentSubscriber> tbl_PaymentSubscriber { get; set; }
        public virtual DbSet<tbl_PaymentLog> tbl_PaymentLog { get; set; }
        public virtual DbSet<tbl_MembershipVersion> tbl_MembershipVersion { get; set; }
        public virtual DbSet<tbl_Uyeler> tbl_Uyeler { get; set; }
        public virtual DbSet<tbl_SubsReturnPaymentLog> tbl_SubsReturnPaymentLog { get; set; }
        public virtual DbSet<tbl_UserMembership> tbl_UserMembership { get; set; }
    }
}