using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using gm_repositories;
using models;
using Microsoft.AspNetCore.Mvc;

namespace aspnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetEntryController : ControllerBase
    {
        private ITimeSheetRepository TimeSheetRepository;
        private readonly IMapper _mapper;

        public TimeSheetEntryController(ITimeSheetRepository timeSheetRepository, IMapper mapper)
        {
            TimeSheetRepository = timeSheetRepository;
            _mapper = mapper;
        }
        // GET api/TimeSheetEntries
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetTimeSheetEntries()
        {
            var timeSheetEntries = TimeSheetRepository.GetTimeSheetEntries();
            var result = _mapper.Map<List<TimeSheetEntryDTO>>(timeSheetEntries);
            return Ok(result);
            
        }

        // GET api/TimeSheetEntries/Clientid
        [HttpGet("{ClientId}")]
        public ActionResult<string> Get(string clientId)
        {
            var timeSheetEntries = TimeSheetRepository.GetTimeSheetEntriesForClient(clientId);
            var result = _mapper.Map<List<TimeSheetEntryDTO>>(timeSheetEntries);
            return Ok(result);
        }

        // POST api/TimeSheetEntries
        [HttpPost]
        public void Post([FromBody] TimeSheetEntry entry)
        {
            TimeSheetRepository.CreateTimeSheetEntry(entry);
        }
    }
}
