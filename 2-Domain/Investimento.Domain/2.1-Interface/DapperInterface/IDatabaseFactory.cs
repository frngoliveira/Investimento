using System.Data;

namespace Investimento.Domain._2._1_Interface.DapperInterface
{
    public interface IDatabaseFactory
    {
        IDbConnection GetDbConnection { get; }
    }
}
