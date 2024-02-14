using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SifirGibiMakina.Business.Concrete
{
    public class MachineIslemeDetailManager : IMachineIslemeDetailService
    {
        private readonly IControlUnitDal _controlUnitDal;
        private readonly INumberOfAxesDal _numberOfAxesDal;
        private readonly INumberOfTablesDal _numberOfTablesDal;
        private readonly ISpindleRPMDal _spindleRPMDal;
        private readonly IXAxisSizeDal _xAxisSizeDal;
        private readonly IYAxisSizeDal _yAxisSizeDal;

        public MachineIslemeDetailManager(IControlUnitDal controlUnitDal, INumberOfAxesDal numberOfAxesDal, INumberOfTablesDal numberOfTablesDal, ISpindleRPMDal spindleRPMDal, IXAxisSizeDal xAxisSizeDal, IYAxisSizeDal yAxisSizeDal)
        {
            _controlUnitDal = controlUnitDal;
            _numberOfAxesDal = numberOfAxesDal;
            _numberOfTablesDal = numberOfTablesDal;
            _spindleRPMDal = spindleRPMDal;
            _xAxisSizeDal = xAxisSizeDal;
            _yAxisSizeDal = yAxisSizeDal;
        }

        public List<tbl_ControlUnit> ControlUnitList()
        {
            return _controlUnitDal.GetList().ToList();
        }

        public List<tbl_NumberOfAxes> NumberOfAxesList()
        {
            return _numberOfAxesDal.GetList().ToList();
        }

        public List<tbl_NumberOfTables> NumberOfTablesList()
        {
            return _numberOfTablesDal.GetList().ToList();
        }

        public List<tbl_SpindleRPM> SpindleRPMsList()
        {
            return _spindleRPMDal.GetList().ToList();
        }

        public List<tbl_XAxisSize> XAxisSizeList()
        {
            return _xAxisSizeDal.GetList().ToList();
        }

        public List<tbl_YAxisSize> YAxisSizeList()
        {
           return _yAxisSizeDal.GetList().ToList();
        }
    }
}