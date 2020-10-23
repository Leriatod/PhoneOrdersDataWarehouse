using System.Reflection.Metadata.Ecma335;
using System.Collections;
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
    public class UpdatePhoneDWHController : Controller
    {
        
        private readonly PhoneDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _clientFactory;

        public UpdatePhoneDWHController(PhoneDbContext context, IMapper mapper, IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
            this._mapper = mapper;
            this._context = context;
        }

        
    }
}