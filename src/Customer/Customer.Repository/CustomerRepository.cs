using Microsoft.EntityFrameworkCore;
using Customer.Repository.Interfaces;
using Generate = Customer.Model.Generate;
using System.Linq.Expressions;
using MongoDB.Driver;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Shared.Repository.MongoDb.Data.Interfaces;

namespace Customer.Repository;
public class CustomerRepository : RepositoryBase<Generate.Customer>, ICustomerRepository
{
    public CustomerRepository(IMongoContext context) : base(context)
    {
       
    }

    //public override void BeforeAdd(Generate.Customer model)
    //{
    //    model.CreatedBy = "unknown";
    //    model.CreatedAt = DateTime.UtcNow;
    //    model.UpdatedBy = "unknown";
    //    model.UpdatedAt = DateTime.UtcNow;
    //}
    //public override void BeforeUpdate(Generate.Customer model)
    //{
    //    model.UpdatedBy = "unknown";
    //    model.UpdatedAt = DateTime.UtcNow;
    //}
    //public override void BeforeDelete(Generate.Customer model)
    //{
    //    model.DeletedBy = "unknown";
    //    model.DeletedAt = DateTime.UtcNow;
    //}
}
