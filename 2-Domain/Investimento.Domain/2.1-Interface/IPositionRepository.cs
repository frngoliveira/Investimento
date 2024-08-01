using Investimento.Domain._2._2_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investimento.Domain._2._1_Interface
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAllAsync();
        Task AddRangeAsync(IEnumerable<Position> positions);
        Task<IEnumerable<Position>> GetPositionsByClientAsync(string clientId);
        Task<IEnumerable<dynamic>> GetSummaryByClientAsync(string clientId);
        Task<IEnumerable<Position>> GetTop10PositionsAsync();
    }
}
