using HortiFrutiAPI.Models;

namespace HortiFrutiAPI.Repositories;

public interface IFrutaRepository : IRepository<Fruta>
{
    IEnumerable<Fruta> GetFrutasPorCategoria(int id);
}


