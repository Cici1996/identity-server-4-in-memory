using Sample.BusinnesLayer.Contracts;
using Sample.Core.DataTransperObjects;
using Sample.Repository.Contracts;

namespace Sample.BusinnesLayer
{
    public class MeetingEventBLL : IMeetingEventBLL
    {
        private readonly IMeetingEventRepository _meetingEventRepository;

        public MeetingEventBLL(IMeetingEventRepository meetingEventRepository)
        {
            _meetingEventRepository = meetingEventRepository;
        }

        public async Task<bool> Delete(Guid id, string userName)
        {
            return await _meetingEventRepository.Delete(id, userName);
        }

        public async Task<MeetingEventDTO> GetById(Guid id)
        {
            return await _meetingEventRepository.GetById(id);
        }

        public async Task<MeetingEventDTO> Insert(MeetingEventDTO dto)
        {
            return await _meetingEventRepository.Insert(dto);
        }

        public bool IsvalidDate(MeetingEventDTO dto)
        {
            return dto.EndDate >= dto.StartDate;
        }

        public async Task<MeetingEventDTO> Update(MeetingEventDTO dto)
        {
            return await _meetingEventRepository.Update(dto);
        }

        public async Task<PagedResponseDTO<MeetingEventDTO>> GetAll(int page, int limit)
        {
            return await _meetingEventRepository.GetAll(page,limit);
        }
    }
}