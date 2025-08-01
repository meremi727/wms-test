using System.Linq.Expressions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ResourceRepository(ApplicationDbContext context) 
    : CrudRepository<Resource>(context)
{
    public override Resource Add(Resource entity)
    {
        var addedEntity = context.Resources.Add(entity);
        return addedEntity.Entity;
    }

    public override bool Delete(int id)
    {
        var entity = context.Resources.Find(id);
        if (entity == null)
            return false;

        context.Resources.Remove(entity);
        return true;
    }

    public override bool Exists(Expression<Func<Resource, bool>> predicate)
    {
        return context.Resources
            .Where(predicate)
            .Any();
    }

    public override IEnumerable<Resource> Find(Expression<Func<Resource, bool>> predicate)
    {
        return context.Resources
            .Where(predicate)
            .AsNoTracking();
    }

    public override IEnumerable<Resource> GetAll()
    {
        return context.Resources
            .AsNoTracking();
    }

    public override Resource? GetById(int id)
    {
        return context.Resources
            .Find(id);
    }

    public override Resource Update(Resource entity)
    {
        var updatedEntity = context.Resources.Update(entity);
        return updatedEntity.Entity;
    }
}