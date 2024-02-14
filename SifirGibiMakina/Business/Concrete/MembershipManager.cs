using AutoMapper;
using SifirGibiMakina.Business.Abstract;
using SifirGibiMakina.DataLayer.İnterfaces;
using SifirGibiMakina.Dtos.Membership;
using System;
using System.Collections.Generic;


namespace SifirGibiMakina.Business.Concrete
{
    public class MembershipManager : IMembershipService
    {
        private readonly IMembershipDal _membershipDal;
        private readonly IMapper _mapper;

        public MembershipManager(IMembershipDal membershipDal, IMapper mapper)
        {
            _membershipDal = membershipDal;
            _mapper = mapper;
        }

        public List<GetListMembershipDto> ListMembership()
        {
            var result = _membershipDal.GetList();

            var mapperList = _mapper.Map<List<GetListMembershipDto>>(result);

            return mapperList;
        }

        public void CreateMembership(CreateMemberShipDto createMemberShipDto)
        {

            var createMembership = _mapper.Map<tbl_Membership>(createMemberShipDto);

            _membershipDal.Add(createMembership);
            _membershipDal.SaveChanges();



        }
    }
}