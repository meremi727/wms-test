using System.Linq.Expressions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class BalanceRepository(ApplicationDbContext context) 
    : CrudRepository<Balance>(context)
{
    public override Balance Add(Balance entity)
    {
        var addedEntity = context.Balances.Add(entity);
        return addedEntity.Entity;
    }

    public override bool Delete(int id)
    {
        var entity = context.Balances.Find(id);
        if (entity == null)
            return false;
        
        context.Balances.Remove(entity);
        return true;
    }

    public override bool Exists(Expression<Func<Balance, bool>> predicate)
    {
        return context.Balances
            .Where(predicate)
            .Any();
    }

    public override IEnumerable<Balance> Find(Expression<Func<Balance, bool>> predicate)
    {
        return context.Balances
            .Where(predicate)
            .Include(b => b.Resource)
            .Include(b => b.Measure)
            .AsNoTracking();
    }

    public override IEnumerable<Balance> GetAll()
    {
        return context.Balances
            .Include(b => b.Resource)
            .Include(b => b.Measure)
            .AsNoTracking();
    }

    public override Balance? GetById(int id)
    {
        return context.Balances
            .Find(id);
    }

    public override Balance Update(Balance entity)
    {
        var updatedEntity = context.Balances.Update(entity);
        return updatedEntity.Entity;
    }
}