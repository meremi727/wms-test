using System.Data;
using System.Linq.Expressions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;


namespace Repository;


public abstract class CrudRepository<T>(ApplicationDbContext context)
    where T : EntityBase
{
    public abstract IEnumerable<T> GetAll();

    public abstract T? GetById(int id);

    public abstract IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

    public abstract T Add(T entity);

    public abstract T Update(T entity);

    public abstract bool Delete(int id);

    public abstract bool Exists(Expression<Func<T, bool>> predicate);

    public IDbContextTransaction BeginTransaction(IsolationLevel level = IsolationLevel.ReadCommitted)
        => transaction = context.Database.BeginTransaction(level);

    public void Commit()
    {
        if (transaction == null)
        {
            context.SaveChanges();
            return;
        }

        try
        {
            context.SaveChanges();
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public void Rollback()
        => transaction?.Rollback();

    private IDbContextTransaction? transaction = null;
}