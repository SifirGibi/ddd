using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.ServiceExpertiz
{
    public class ListOfUsersRequestingServiceByIdDto
    {
        public string UserNameRequestingService {  get; set; }  
   
        public string UserEmailRequestingService {  get; set; }  
        public string CategoryNameRequestingService {  get; set; }  
        public string SubCategoryNameRequestingService {  get; set; }  
        public string MachineTitleRequestingService {  get; set; }  
        public string MachineBrandNameRequestingService {  get; set; }  
        public int MachineYearRequestingService {  get; set; }  
        public Nullable<bool> Durum {  get; set; }  
        public Nullable<bool> Yanit {  get; set; }  

    
      public Nullable<DateTime> ScheduledDate {  get; set; }  
        public Nullable<DateTime> CreatedDate { get; set; }
        public int UserIdRequestingService {  get; set; }  
        public int ExpertizID {  get; set; }  



    }
}