using System;
using AutoMapper;
using NUnit.Framework;

namespace SealedClassMocking.MappingTests
{
    public class TestMapper
    {
        private DateTime? _signingDate;

        [SetUp]
        public void SetUp()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<CbMapperWithResolver>(); });
            _signingDate = new DateTime(2099, 01, 01);
        }

        [Test]
        public void Test_cb_Mapper()
        {
            var claimBenefitViewModel =
                Mapper.Map<ClaimBenefitViewModel>(new ClaimBenefitDto {SigningDate = _signingDate});

            Assert.That(claimBenefitViewModel.SigningDate.Equals("Jan 01"));
        }

        [Test]
        public void Test_cb_Mapper_ResolveNull()
        {
            _signingDate = null;
            var claimBenefitViewModel =
                Mapper.Map<ClaimBenefitViewModel>(new ClaimBenefitDto
                {
                    SigningDate = _signingDate,
                    CloseDate = DateTime.Now
                });

            Assert.That(claimBenefitViewModel.SigningDate.Equals("Jan 01"));
        }


        [Test]
        public void TestMapper_NullObject_Result()
        {
            var claimBenefitViewModel = Mapper.Map<ClaimBenefitViewModel>(null);
        }
    }
}