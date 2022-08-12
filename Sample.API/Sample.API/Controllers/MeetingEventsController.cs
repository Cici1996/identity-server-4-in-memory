using AutoMapper;
using AutoWrapper.Extensions;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sample.API.Models;
using Sample.API.Models.Requests;
using Sample.BusinnesLayer.Contracts;
using Sample.Core.Contants;
using Sample.Core.DataTransperObjects;

namespace Sample.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class MeetingEventController : ControllerBase
    {
        private static IMeetingEventBLL _meetingEventBLL;
        private static IMapper _mapper;

        public MeetingEventController(IMeetingEventBLL meetingEventBLL, IMapper mapper)
        {
            _meetingEventBLL = meetingEventBLL;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MeetingEventRequest request)
        {
            var model = _mapper.Map<MeetingEventRequest, MeetingEventModel>(request);
            var dto = _mapper.Map<MeetingEventModel, MeetingEventDTO>(model);
            bool isValidDate = _meetingEventBLL.IsvalidDate(dto);
            if(!isValidDate) throw new ApiException(GlobalContant.ErrorMessageDate, 500);
            var response = await _meetingEventBLL.Insert(dto);
            return Ok(response);
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll(int page, int limit)
        {
            var response = await _meetingEventBLL.GetAll(page,limit);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _meetingEventBLL.GetById(id);
            if(response == null) throw new ApiException(string.Format(GlobalContant.ErrorMessageIdNotExists,id), 404);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MeetingEventRequest request)
        {
            var model = _mapper.Map<MeetingEventRequest, MeetingEventModel>(request);
            var dto = _mapper.Map<MeetingEventModel, MeetingEventDTO>(model);
            bool isValidDate = _meetingEventBLL.IsvalidDate(dto);
            if (!isValidDate) throw new ApiException(GlobalContant.ErrorMessageDate, 500);
            var response = await _meetingEventBLL.Update(dto);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {   var responseDelete = await _meetingEventBLL.Delete(id,string.Empty);
            return Ok(responseDelete);
        }
    }
}