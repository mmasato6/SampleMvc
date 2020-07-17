using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebApi.Data;
using SampleWebApi.Models;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrefecturesController : ControllerBase
    {
        private readonly ApplicationDbConttext _context;

        public PrefecturesController(ApplicationDbConttext context)
        {
            _context = context;
        }

        // GET: api/Prefectures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prefecture>>> GetPrefecture()
        {
            return await _context.Prefecture.ToListAsync();
        }

    }
}
