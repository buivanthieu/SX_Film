using AutoMapper;
using WebBackend.Dtos.Series;
using WebBackend.Models;
using WebBackend.Repositories.Series;

namespace WebBackend.Services.Series
{
    public class SeriService : ISeriService
    {
        private readonly ISeriRepository _seriRepository;
        private readonly IMapper _mapper;
        public SeriService(ISeriRepository seriRepository, IMapper mapper)
        {
            _seriRepository = seriRepository;
            _mapper = mapper;
        }
        public async Task AddSeri(CreateSeriDto seriDto)
        {
            var seri = _mapper.Map<Seri>(seriDto);
            await _seriRepository.AddSeri(seri);

        }
        public async Task UpdateSeri(int seriId, UpdateSeriDto seriDto)
        {
            var seri = _mapper.Map<Seri>(seriDto);
            await _seriRepository.UpdateSeri(seriId, seri);
        }
        public async Task DeleteSeri(int id)
        {
            await _seriRepository.DeleteSeri(id);

        }
        public async Task<ICollection<GetSeriDto>> GetAllSeries()
        {
            var series = await _seriRepository.GetAllSeries();
            return _mapper.Map<ICollection<GetSeriDto>>(series);
        }
        public async Task<GetSeriDto> GetSeriById(int id)
        {
            var seri = await _seriRepository.GetSeriById(id);
            return _mapper.Map<GetSeriDto>(seri);
        }
    }
}
