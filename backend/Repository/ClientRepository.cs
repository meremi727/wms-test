using System.Data;
using System.Linq.Expressions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ClientRepository(ApplicationDbContext context)
    : CrudRepository<Client>(context)
{
    public override Client Add(Client entity)
    {
        var addedEntity = context.Clients.Add(entity);
        return addedEntity.Entity;
    }

    public override bool Delete(int id)
    {
        var client = context.Clients.Find(id);
        if (client == null)
            return false;

        context.Clients.Remove(client);
        return true;
    }

    public override bool Exists(Expression<Func<Client, bool>> predicate)
    {
        return context.Clients
            .Where(predicate)
            .Any();
    }

    public override IEnumerable<Client> Find(Expression<Func<Client, bool>> predicate)
    {
        return context.Clients
            .Where(predicate)
            .Include(c => c.OutgoingDocuments)
            .AsNoTracking();
    }

    public override IEnumerable<Client> GetAll()
    {
        return context.Clients
            .AsNoTracking();
    }

    public override Client? GetById(int id)
    {
        return context.Clients
            .Find(id);
    }

    public override Client Update(Client entity)
    {
        var updatedEntity = context.Clients.Update(entity);
        return updatedEntity.Entity;
    }
}