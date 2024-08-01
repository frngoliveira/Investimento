using Investimento.Domain._2._1_Interface;
using Investimento.Domain._2._2_Entity;
using Investimento.Infra._3._1_Context;
using Microsoft.EntityFrameworkCore;

namespace Investimento.Infrastructure._3._3_Repository
{
    public class PositionRepository : IPositionRepository
    {        
        protected readonly InvestimentoContext _context;

        public PositionRepository(InvestimentoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Position>> GetAllAsync() => await _context.Positions.ToListAsync();

        public async Task AddRangeAsync(IEnumerable<Position> positions)
        {
            await _context.Positions.AddRangeAsync(positions);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Position>> GetPositionsByClientAsync(string clientId) =>
            await _context.Positions
                .Where(p => p.ClientId == clientId)
                .GroupBy(p => p.PositionId)
                .Select(g => g.OrderByDescending(p => p.Date).First())
                .ToListAsync();

        public async Task<IEnumerable<dynamic>> GetSummaryByClientAsync(string clientId) =>
            await _context.Positions
                .Where(p => p.ClientId == clientId)
                .GroupBy(p => p.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    TotalValue = g.Sum(p => p.Value)
                })
                .ToListAsync();

        public async Task<IEnumerable<Position>> GetTop10PositionsAsync() =>
            await _context.Positions
                .OrderByDescending(p => p.Value)
                .Take(10)
                .ToListAsync();
    }

}
