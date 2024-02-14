using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Dtos.MachineDetail
{
    public class MachineDetailCreateDto
    {


        public Nullable<int> MachineId { get; set; }
        public Nullable<int> MirrorSizeID { get; set; }
        public Nullable<int> ControlUnitID { get; set; }
        public Nullable<int> NumberOfAxesID { get; set; }
        public Nullable<int> SpindleRPMID { get; set; }
        public Nullable<int> SpecificType { get; set; }
        public Nullable<int> XAxisSizeID { get; set; }
        public Nullable<int> YAxisSizeID { get; set; }
        public Nullable<int> NumberOfTablesID { get; set; }
        public Nullable<int> DailyPrice { get; set; }
        public Nullable<int> WeeklyPrice { get; set; }
        public Nullable<int> MonthlyPrice { get; set; }
        public Nullable<int> CountryId { get; set; }
    }
}