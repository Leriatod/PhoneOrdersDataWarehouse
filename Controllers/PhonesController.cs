using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneDataWarehouse.Data;
using PhoneDataWarehouse.Data.Models;
using PhoneDataWarehouse.Dtos;

namespace PhoneDataWarehouse.Controllers
{
    [Route("/api/phones")]
    public class PhonesController : Controller
    {
        private readonly PhoneDbContext _context; 
        private readonly IMapper _mapper;
        public PhonesController(PhoneDbContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context; 
        }

        [HttpGet]
        public async Task<IActionResult> GetPhonesAsync()
        {
            var phones = await _context.Phones.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<Phone>, IEnumerable<PhoneDto>>(phones));
        }
    }
}