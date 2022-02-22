using CoureAssessmentWebAPI.DbContext;
using CoureAssessmentWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoureAssessmentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CoureDbContext _context;

        public CountryController(CoureDbContext context)
        {
            _context = context;
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public Country Get(string id)
        {
            var num = id.Substring(0, 3);
            var country = _context.Country.FirstOrDefault(m =>m.CountryCode == Convert.ToInt32(num));
            return country;
        }

        [HttpGet]
        public IEnumerable<Country> Get()
        {
            var country = _context.Country;
            return country;
        }


    }
}
