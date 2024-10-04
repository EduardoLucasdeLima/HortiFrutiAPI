using HortiFrutiAPI.Context;
using HortiFrutiAPI.Models;

namespace HortiFrutiAPI.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{   public CategoriaRepository(AppDbContext context) : base(context)
    { 
    }
}
