using System.Linq.Expressions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository;


public class OutgoingResourceRepository(ApplicationDbContext context)
    : CrudRepository<OutgoingResource>(context)
{
    public override OutgoingResource Add(OutgoingResource entity)
    {
        var addedEntity = context.OutgoingResources.Add(entity);
        return addedEntity.Entity;
    }

    public override bool Delete(int id)
    {
        var resource = context.OutgoingResources.Find(id);
        if (resource == null)
            return false;

        context.OutgoingResources.Remove(resource);
        return true;
    }

    public override bool Exists(Expression<Func<OutgoingResource, bool>> predicate)
    {
        return context.OutgoingResources
            .Where(predicate)
            .Any();
    }

    public override IEnumerable<OutgoingResource> Find(Expression<Func<OutgoingResource, bool>> predicate)
    {
        return context.OutgoingResources
            .Where(predicate)
            .Include(r => r.Resource)
            .Include(r => r.Measure)
            .AsNoTracking();
    }

    public override IEnumerable<OutgoingResource> GetAll()
    {
        return context.OutgoingResources
            .Include(r => r.Resource)
            .Include(r => r.Measure)
            .AsNoTracking();
    }

    public override OutgoingResource? GetById(int id)
    {
        return context.OutgoingResources
            .Find(id);
    }

    public override OutgoingResource Update(OutgoingResource entity)
    {
        var updatedEntity = context.OutgoingResources.Update(entity);
        return updatedEntity.Entity;
    }
}