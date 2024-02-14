using AutoMapper;
using SifirGibiMakina.Dtos.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Mapper
{
    public class MachineProfile:Profile
    {
        public MachineProfile()
        {

        
            CreateMap<tbl_Makinalar,MachineShowcaseListDto>().ReverseMap();
            CreateMap<tbl_Makinalar,MachineCreateDto>().ReverseMap();
     

       
 
        
       
        }
                    
        
    }
}