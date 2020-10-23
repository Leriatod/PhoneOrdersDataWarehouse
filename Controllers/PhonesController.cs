using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PhoneDataWarehouse.Data;
using PhoneDataWarehouse.Data.Models;
using PhoneDataWarehouse.Dtos;

namespace PhoneDataWarehouse.Controllers
{
    public class PhonesController : Controller
    {
        private const string ROZETKA_PHONES_URL = "http://my-json-server.typicode.com/Leriatod/PhonesFakeApiService/rozetkaPhones/";
        private const string ALLO_PHONES_URL = "http://my-json-server.typicode.com/Leriatod/PhonesFakeApiService/alloPhones/";
        private readonly PhoneDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _clientFactory;

        public PhonesController(PhoneDbContext context, IMapper mapper, IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
            this._mapper = mapper;
            this._context = context;
        }

        [HttpGet]
        [Route("/api/phones")]
        public async Task<IActionResult> GetPhonesAsync()
        {
            var phones = await _context.Phones.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<Phone>, IEnumerable<PhoneDto>>(phones));
        }


        [HttpPost]
        [Route("/api/reload-phones")] // ADMIN ROUTE
        public async Task<IActionResult> ReloadPhonesAsync()
        {
            var phones = new List<Phone>();

            var phonesFromAllo = await deserializePhoneFromRequestAsync<IEnumerable<AlloPhoneDto>>(ALLO_PHONES_URL);
            var phonesFromRozetka = await deserializePhoneFromRequestAsync<IEnumerable<RozetkaPhoneDto>>(ROZETKA_PHONES_URL);

            phones.AddRange(phonesFromAllo);
            phones.AddRange(phonesFromRozetka);

            _context.Phones.RemoveRange(_context.Phones);
            await _context.Phones.AddRangeAsync(phones);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<IEnumerable<Phone>, IEnumerable<PhoneDto>>(phones));
        }

        private async Task<IEnumerable<Phone>> deserializePhoneFromRequestAsync<T>(string url)
        {
            var client = _clientFactory.CreateClient();
            var json = await client.GetStringAsync(url);
            var phonesDto = JsonConvert.DeserializeObject<T>(json);
            var phones = _mapper.Map<T, IEnumerable<Phone>>(phonesDto);

            return phones;
        }

    }
}