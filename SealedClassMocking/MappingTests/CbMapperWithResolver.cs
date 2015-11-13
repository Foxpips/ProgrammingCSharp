using AutoMapper;

namespace SealedClassMocking.MappingTests
{
    public class CbMapperWithResolver : Profile
    {
        protected override void Configure()
        {
            CreateMap<ClaimBenefitDto, ClaimBenefitViewModel>()
                .ForMember(dest => dest.SigningDate, opt => opt.ResolveUsing<DateResolver>());
        }
    }
}