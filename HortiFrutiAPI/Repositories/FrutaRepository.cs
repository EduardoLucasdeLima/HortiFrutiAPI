using HortiFrutiAPI.Context;
using HortiFrutiAPI.Models;

namespace HortiFrutiAPI.Repositories;

public class FrutaRepository : Repository<Fruta>, IFrutaRepository
{
    public FrutaRepository(AppDbContext context) : base(context)
    {
    }
    public IEnumerable<Fruta> GetFrutasPorCategoria(int id)
    {
        return GetAll().Where(c => c.FrutaId == id);
    }
}