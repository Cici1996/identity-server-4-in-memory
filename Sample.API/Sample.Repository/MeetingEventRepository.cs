using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sample.Core.DataTransperObjects;
using Sample.Core.Extensions;
using Sample.DataAccessLayer;
using Sample.DataAccessLayer.Entities;
using Sample.Repository.Contracts;

namespace Sample.Repository
{
    public class MeetingEventRepository : IMeetingEventRepository
    {
        private readonly IMapper _mapper;
        private readonly CoreDBContext _coreDbContext;

        public MeetingEventRepository(IMapper mapper, CoreDBContext coreDbContext)
        {
            _mapper = mapper;
            _coreDbContext = coreDbContext;
        }

        public async Task<bool> Delete(Guid id, string userName)
        {
            MeetingEvent data = await _coreDbContext.MeetingEvents.FindAsync(id);
            _coreDbContext.MeetingEvents.Remove(data);
            int result = await _coreDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<MeetingEventDTO> GetById(Guid id)
        {
            MeetingEvent data = await _coreDbContext.MeetingEvents.FindAsync(id);
            MeetingEventDTO entity = _mapper.Map<MeetingEvent, MeetingEventDTO>(data);
            return entity;
        }

        public async Task<MeetingEventDTO> Insert(MeetingEventDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            MeetingEvent entity = _mapper.Map<MeetingEventDTO, MeetingEvent>(dto);

            _coreDbContext.MeetingEvents.Add(entity);
            await _coreDbContext.SaveChangesAsync();
            return _mapper.Map<MeetingEvent, MeetingEventDTO>(entity);
        }

        public async Task<MeetingEventDTO> Update(MeetingEventDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            MeetingEvent entity = _mapper.Map<MeetingEventDTO, MeetingEvent>(dto);

            _coreDbContext.MeetingEvents.Update(entity);
            await _coreDbContext.SaveChangesAsync();
            return _mapper.Map<MeetingEvent, MeetingEventDTO>(entity);
        }

        public async Task<PagedResponseDTO<MeetingEventDTO>> GetAll(int page, int limit)
        {
            //reference https://vmsdurano.com/asp-net-core-5-implement-web-api-pagination-with-hateoas-links/
            var events = await _coreDbContext.MeetingEvents.AsNoTracking().PaginateAsync(page, limit);
            List<MeetingEventDTO> eventsDto = _mapper.Map<List<MeetingEvent>, List<MeetingEventDTO>>(events.Items);
            return new PagedResponseDTO<MeetingEventDTO>
            {
                CurrentPage = events.CurrentPage,
                TotalPages = events.TotalPages,
                TotalItems = events.TotalItems,
                Items = eventsDto
            };
        }
    }
}