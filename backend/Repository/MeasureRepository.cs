using System.Linq.Expressions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class MeasureRepository(ApplicationDbContext context)
    : CrudRepository<Measure>(context)
{
    public override Measure Add(Measure entity)
    {
        var addedEntity = context.Measures.Add(entity);
        return addedEntity.Entity;
    }

    public override bool Delete(int id)
    {
        var entity = context.Measures.Find(id);
        if (entity == null)
            return false;

        context.Measures.Remove(entity);
        return true;
    }

    public override bool Exists(Expression<Func<Measure, bool>> predicate)
    {
        return context.Measures
            .Where(predicate)
            .Any();
    }

    public override IEnumerable<Measure> Find(Expression<Func<Measure, bool>> predicate)
    {
        return context.Measures
            .Where(predicate)
            .AsNoTracking();
    }

    public override IEnumerable<Measure> GetAll()
    {
        return context.Measures
            .AsNoTracking();
    }

    public override Measure? GetById(int id)
    {
        return context.Measures
            .Find(id);
    }

    public override Measure Update(Measure entity)
    {
        var updatedEntity = context.Measures.Update(entity);
        return updatedEntity.Entity;
    }
}