using Sample.Core.DataTransperObjects;

namespace Sample.BusinnesLayer.Contracts
{
    public interface IMeetingEventBLL
    {
        Task<MeetingEventDTO> Insert(MeetingEventDTO dto);

        Task<MeetingEventDTO> Update(MeetingEventDTO dto);

        Task<bool> Delete(Guid id, string userName);

        Task<MeetingEventDTO> GetById(Guid id);
        bool IsvalidDate(MeetingEventDTO dto);
        Task<PagedResponseDTO<MeetingEventDTO>> GetAll(int page, int limit);
    }
}