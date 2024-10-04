using HortiFrutiAPI.Context;

namespace HortiFrutiAPI.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IFrutaRepository? _frutaRepo;

    private ICategoriaRepository? _categoriaRepo;

    public AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IFrutaRepository FrutaRepository
    {
        get
        {
            return _frutaRepo = _frutaRepo ?? new FrutaRepository(_context);
        }
    }

    public ICategoriaRepository CategoriaRepository
    {
        get
        {
            return _categoriaRepo = _categoriaRepo ?? new CategoriaRepository(_context);
        }
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
