using InvoiceManagementApp.Infrastructure.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Application.Common.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using Domain.Commom;
using System;

namespace InvoiceManagementApp.Infrastructure.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions, ICurrentUserService currentUserService) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set ; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entry.State) 
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);

        }
    }
}