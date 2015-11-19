using AutoMapper;
using NUnit.Framework;

namespace ProgrammingTests.TimeSpanTests
{
    public class AutoMapperTests
    {
        public enum FrappeFlavour
        {
            Chocolate,
            Strawberry,
            Bananna,
            Orange,
            Vanilla
        }

        public class IceCreamDto
        {
            public FrappeFlavour Flavour { get; set; }
            public int Price { get; set; }
        }

        public class IceCreamViewModel
        {
            public FrappeFlavour Flavour { get; set; }
            public int Cost { get; set; }
        }

        [SetUp]
        public void SetUp()
        {
            Mapper.CreateMap<IceCreamDto, IceCreamViewModel>()
                .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Price));
        }

        [Test]
        public void AutoMapper_MapManuallyHalfProperties_AllPropertiesMapped()
        {
            var iceCreamEntity = new IceCreamDto {Flavour = FrappeFlavour.Chocolate, Price = 10};
            var iceCreamViewModel = Mapper.Map<IceCreamViewModel>(iceCreamEntity);

            Assert.That(iceCreamViewModel.Cost.Equals(10));
            Assert.That(iceCreamViewModel.Flavour.Equals(FrappeFlavour.Chocolate));
        }

        [Test]
        public void AutoMapper_MapManuallyHalfProperties_AllPropertiesMapped_MapperFailedException()
        {
            Assert.Throws<AutoMapperMappingException>(
                () => { Mapper.Map<IceCreamDto>(new IceCreamViewModel {Cost = 10, Flavour = FrappeFlavour.Chocolate}); });
        }

        [Test]
        public void AutoMapper_MapManuallyHalfProperties_AllPropertiesMapped_Reverse()
        {
            Mapper.CreateMap<IceCreamViewModel, IceCreamDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Cost));

            var iceCreamViewModel = new IceCreamViewModel {Cost = 10, Flavour = FrappeFlavour.Chocolate};
            var iceCreamDto = Mapper.Map<IceCreamDto>(iceCreamViewModel);

            Assert.That(iceCreamDto.Flavour.Equals(FrappeFlavour.Chocolate));
        }
    }
}