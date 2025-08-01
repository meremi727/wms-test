using System.Linq.Expressions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class OutgoingDocumentRepository(ApplicationDbContext context)
    : CrudRepository<OutgoingDocument>(context)
{
public override OutgoingDocument Add(OutgoingDocument entity)
    {
        var addedEntity = context.OutgoingDocuments.Add(entity);
        return addedEntity.Entity;
    }

    public override bool Delete(int id)
    {
        var doc = context.OutgoingDocuments.Find(id);
        if (doc == null)
            return false;

        context.OutgoingDocuments.Remove(doc);
        return true;
    }

    public override bool Exists(Expression<Func<OutgoingDocument, bool>> predicate)
    {
        return context.OutgoingDocuments
            .Where(predicate)
            .Any();
    }

    public override IEnumerable<OutgoingDocument> Find(Expression<Func<OutgoingDocument, bool>> predicate)
    {
        return context.OutgoingDocuments
            .Where(predicate)
            .Include(d => d.Client)
            .Include(d => d.Resources)
            .AsNoTracking();
    }

    public override IEnumerable<OutgoingDocument> GetAll()
    {
        return context.OutgoingDocuments
            .Include(d => d.Client)
            .Include(d => d.Resources)
            .AsNoTracking();
    }

    public override OutgoingDocument? GetById(int id)
    {
        return context.OutgoingDocuments
            .Find(id);
    }

    public override OutgoingDocument Update(OutgoingDocument entity)
    {
        var updatedEntity = context.OutgoingDocuments.Update(entity);
        return updatedEntity.Entity;
    }
}