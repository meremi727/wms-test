using System.Linq.Expressions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class IncomingDocumentRepository(ApplicationDbContext context) 
    : CrudRepository<IncomingDocument>(context)
{
    public override IncomingDocument Add(IncomingDocument entity)
    {
        var addedEntity = context.IncomingDocuments.Add(entity);
        return addedEntity.Entity;
    }

    public override bool Delete(int id)
    {
        var entity = context.IncomingDocuments.Find(id);
        if (entity == null)
            return false;
        
        context.IncomingDocuments.Remove(entity);
        return true;
    }

    public override bool Exists(Expression<Func<IncomingDocument, bool>> predicate)
    {
        return context.IncomingDocuments
            .Where(predicate)
            .Any();
    }

    public override IEnumerable<IncomingDocument> Find(Expression<Func<IncomingDocument, bool>> predicate)
    {
        return context.IncomingDocuments
            .Where(predicate)
            .Include(d => d.Resouces)
            .AsNoTracking();
    }

    public override IEnumerable<IncomingDocument> GetAll()
    {
        return context.IncomingDocuments
            .Include(d => d.Resouces)
            .AsNoTracking();
    }

    public override IncomingDocument? GetById(int id)
    {
        return context.IncomingDocuments
            .Find(id);
    }

    public override IncomingDocument Update(IncomingDocument entity)
    {
        var updatedEntity = context.IncomingDocuments.Update(entity);
        return updatedEntity.Entity;
    }
}