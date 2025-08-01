using System.Linq.Expressions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class IncomingResourceRepository(ApplicationDbContext context) 
    : CrudRepository<IncomingResouce>(context)
{
    public override IncomingResouce Add(IncomingResouce entity)
    {
        var addedEntity = context.IncomingResouces.Add(entity);
        return addedEntity.Entity;
    }

    public override bool Delete(int id)
    {
        var entity = context.IncomingResouces.Find(id);
        if (entity == null)
            return false;
        
        context.IncomingResouces.Remove(entity);
        return true;
    }

    public override bool Exists(Expression<Func<IncomingResouce, bool>> predicate)
    {
        return context.IncomingResouces
            .Where(predicate)
            .Any();
    }

    public override IEnumerable<IncomingResouce> Find(Expression<Func<IncomingResouce, bool>> predicate)
    {
        return context.IncomingResouces
            .Where(predicate)
            .Include(r => r.Resource)
            .Include(r => r.Measure)
            .AsNoTracking();
    }

    public override IEnumerable<IncomingResouce> GetAll()
    {
        return context.IncomingResouces
            .Include(r => r.Resource)
            .Include(r => r.Measure)
            .AsNoTracking();
    }

    public override IncomingResouce? GetById(int id)
    {
        return context.IncomingResouces
            .Find(id);
    }

    public override IncomingResouce Update(IncomingResouce entity)
    {
        var updatedEntity = context.IncomingResouces.Update(entity);
        return updatedEntity.Entity;
    }
}