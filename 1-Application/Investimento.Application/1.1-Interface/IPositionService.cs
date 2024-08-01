using Investimento.Domain._2._2_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investimento.Application._1._1_Interface
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> GetAllPositionsAsync();
        Task AddPositionsAsync(IEnumerable<Position> positions);
        Task<IEnumerable<Position>> GetPositionsByClientAsync(string clientId);
        Task<IEnumerable<dynamic>> GetSummaryByClientAsync(string clientId);
        Task<IEnumerable<Position>> GetTop10PositionsAsync();

    }

    
}
