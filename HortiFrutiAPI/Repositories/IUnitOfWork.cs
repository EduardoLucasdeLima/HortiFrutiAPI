namespace HortiFrutiAPI.Repositories;

public interface IUnitOfWork
{
    IFrutaRepository FrutaRepository { get; }

    ICategoriaRepository CategoriaRepository { get; }

    void Commit();

}
