using System;
using System.Globalization;
using AutoMapper;

namespace SealedClassMocking.MappingTests
{
    public class DateResolver : ValueResolver<ClaimBenefitDto, string>
    {
        /// <summary>
        /// Resolves the core.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>Some stuff</returns>
        protected override string ResolveCore(ClaimBenefitDto source)
        {
            if (source.SigningDate != null)
            {
                if (source.SigningDate.Value != null)
                {
                    return source.SigningDate.Value.ToString("MMM dd");
                }
            }

            return new DateTime(2099, 1, 1).ToString("MMM dd");
        }
    }
}