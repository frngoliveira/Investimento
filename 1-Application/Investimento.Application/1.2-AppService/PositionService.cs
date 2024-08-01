using Investimento.Application._1._1_Interface;
using Investimento.Domain._2._1_Interface;
using Investimento.Domain._2._2_Entity;

namespace Investimento.Application._1._2_AppService
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;            
        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync() => await _positionRepository.GetAllAsync();

        public async Task AddPositionsAsync(IEnumerable<Position> positions) => await _positionRepository.AddRangeAsync(positions);

        public async Task<IEnumerable<Position>> GetPositionsByClientAsync(string clientId) => await _positionRepository.GetPositionsByClientAsync(clientId);

        public async Task<IEnumerable<dynamic>> GetSummaryByClientAsync(string clientId) => await _positionRepository.GetSummaryByClientAsync(clientId);

        public async Task<IEnumerable<Position>> GetTop10PositionsAsync() => await _positionRepository.GetTop10PositionsAsync();
    }

   
}
