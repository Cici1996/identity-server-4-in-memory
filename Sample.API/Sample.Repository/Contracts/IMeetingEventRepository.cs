using Sample.Core.DataTransperObjects;

namespace Sample.Repository.Contracts
{
    public interface IMeetingEventRepository
    {
        Task<MeetingEventDTO> Insert(MeetingEventDTO dto);

        Task<MeetingEventDTO> Update(MeetingEventDTO dto);

        Task<bool> Delete(Guid id, string userName);

        Task<MeetingEventDTO> GetById(Guid id);
        Task<PagedResponseDTO<MeetingEventDTO>> GetAll(int page, int limit);
    }
}