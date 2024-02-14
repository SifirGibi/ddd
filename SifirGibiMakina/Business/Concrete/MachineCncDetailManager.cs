using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class MachineCncDetailManager : IMachineCncDetailService
    {

        private readonly IControlUnitDal _controlUnitDal;
        private readonly IMirrorSizeDal _mirrorSizeDal;
        private readonly INumberOfAxesDal _numberOfAxesDal;
        private readonly ISpindleRPMDal _spindleRPMDal;
        private readonly IYAxisSizeDal _yAxisSizeDal;

        public MachineCncDetailManager(IControlUnitDal controlUnitDal, IMirrorSizeDal mirrorSizeDal, INumberOfAxesDal numberOfAxesDal, ISpindleRPMDal spindleRPMDal, IYAxisSizeDal yAxisSizeDal)
        {
            _controlUnitDal = controlUnitDal;
            _mirrorSizeDal = mirrorSizeDal;
            _numberOfAxesDal = numberOfAxesDal;
            _spindleRPMDal = spindleRPMDal;
            _yAxisSizeDal = yAxisSizeDal;
        }

        public List<tbl_ControlUnit> ControlUnitList()
        {
            return _controlUnitDal.GetList().ToList();
        }

        public List<tbl_MirrorSize> MirrorSizeList()
        {
           return _mirrorSizeDal.GetList().ToList();    
        }

        public List<tbl_NumberOfAxes> NumberOfAxesList()
        {
           return _numberOfAxesDal.GetList().ToList();  
        }

        public List<tbl_SpindleRPM> SpindleRPMsList()
        {
            return _spindleRPMDal.GetList().ToList();
        }

        public List<tbl_YAxisSize> TurningLenghtList()
        {
          return _yAxisSizeDal.GetList().ToList();
        }
    }
}