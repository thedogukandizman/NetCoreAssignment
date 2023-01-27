using NetCoreAssignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace NetCoreAssignment.DataAccess.Contexts
{
    public class BaseDbContext : DbContext
    {
        //protected readonly IConfiguration Configuration;

        //public BaseDbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database burada hata vardı..
            options.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=NetCoreAssignmentDb;");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Todo> Todos { get; set; }

        //SaveChanges çalışmadan önce yapılan işlemleri yaptırmamızı sağlaycak.
        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAlllChangesOnSuccess)
        {
            OnBeforeSave();
            return base.SaveChanges(acceptAlllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSave()
        {
            //var addedEntities = ChangeTracker.Entries().Where(i => i.State == EntityState.Added).Select(i => (Entity)i.Entity);
            var allEntites = ChangeTracker.Entries();//.Select(i => (Entity)i.Entity);
            foreach (var entity in allEntites)
            {
                var baseEntity = (BaseEntity)entity.Entity;
                switch (entity.State)
                {
                    case EntityState.Added:
                        baseEntity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        baseEntity.UpdatedDate = DateTime.UtcNow;
                        break;
                }
            }
        }

    }
}
