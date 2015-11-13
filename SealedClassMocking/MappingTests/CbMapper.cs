using AutoMapper;

namespace SealedClassMocking.MappingTests
{
    public class CbMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<ClaimBenefitDto, ClaimBenefitViewModel>()
                .ForMember(dest => dest.SigningDate, opt => opt.MapFrom(src => src.SigningDate.Value.ToString("MMM dd")));
        }
    }
}