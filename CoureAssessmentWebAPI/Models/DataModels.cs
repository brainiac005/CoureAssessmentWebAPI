using CoureAssessmentWebAPI.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoureAssessmentWebAPI.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public int CountryCode { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }
        public IEnumerable<CountryDetails> CountryDetails { get; set; }

    }

    public class CountryDetails
    {
        [Key]
        public int CountryDetailsId { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string Operator { get; set; }
        public string OperatorCode { get; set; }

    }

    public class Tokens
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }



    public class SeedTestData
    {
        public static void TestData(IServiceProvider serviceProvider)
        {
            using (var context = new CoureDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<CoureDbContext>>()))
            {
                if (context.Country.Any())
                {
                    return;
                }

                var country = new Country[]
                                {
            new Country {CountryId = 1, CountryCode = 234, Name = "Nigeria", CountryIso = "NG" },
            new Country {CountryId = 2, CountryCode = 233, Name = "Ghana", CountryIso = "GH" },
            new Country {CountryId = 3, CountryCode = 229, Name = "Benin Republic", CountryIso = "BN" },
            new Country {CountryId = 4, CountryCode = 225, Name = "Cote d'Ivoire", CountryIso = "CIV" },

                                };
                context.Country.AddRange(country);
                context.SaveChanges();

                var countryDetails = new CountryDetails[]
                {
            new CountryDetails {CountryDetailsId = 1, CountryId = 1, Country= context.Country.FirstOrDefault(m =>m.CountryId == 1), Operator = "MTN Nigeria", OperatorCode = "MTN NG"},
            new CountryDetails {CountryDetailsId = 2, CountryId = 1, Country= context.Country.FirstOrDefault(m =>m.CountryId == 1), Operator = "Airel Nigeria", OperatorCode = "ANG"},
            new CountryDetails {CountryDetailsId = 3, CountryId = 1, Country= context.Country.FirstOrDefault(m =>m.CountryId == 1), Operator = "9 Mobile Nigeria", OperatorCode = "ETN"},
            new CountryDetails {CountryDetailsId = 4, CountryId = 1, Country= context.Country.FirstOrDefault(m =>m.CountryId == 1), Operator = "Globacom Nigeria", OperatorCode = "GLO NG"},
            new CountryDetails {CountryDetailsId = 5, CountryId = 2, Country= context.Country.FirstOrDefault(m =>m.CountryId == 2), Operator = "Vodafone Ghana", OperatorCode = "Vodafone GH"},
            new CountryDetails {CountryDetailsId = 6, CountryId = 2, Country= context.Country.FirstOrDefault(m =>m.CountryId == 2), Operator = "MTN Ghana", OperatorCode = "MTN GH"},
            new CountryDetails {CountryDetailsId = 7, CountryId = 2, Country= context.Country.FirstOrDefault(m =>m.CountryId == 2), Operator = "Tigo Ghana", OperatorCode = "Tigo GH"},
            new CountryDetails {CountryDetailsId = 8, CountryId = 3, Country= context.Country.FirstOrDefault(m =>m.CountryId == 3), Operator = "MTN Benin", OperatorCode = "MTN Benin"},
            new CountryDetails {CountryDetailsId = 9, CountryId = 3, Country= context.Country.FirstOrDefault(m =>m.CountryId == 3), Operator = "Moov Benin", OperatorCode = "Moov Benin"},
            new CountryDetails {CountryDetailsId = 10, CountryId = 3, Country= context.Country.FirstOrDefault(m =>m.CountryId == 3), Operator = "MTN Cote d'Ivoire", OperatorCode = "MTN CIV"},
                };
                context.CountryDetails.AddRange(countryDetails);
                context.SaveChanges();
            }


        }
    }




}
