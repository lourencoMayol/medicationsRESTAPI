using Application.BusinessLayer.Models;
using Application.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.DataLayer.Repositories
{
    public class MedicationRepository : IRepository<Medication>
    {
        private readonly DbSet<Medication> DbSet;

        private readonly AppDbContext Context;

        public MedicationRepository(AppDbContext context) { 
            this.Context = context;
            this.DbSet = Context.Set<Medication>();
        }

        public async Task<IList<Medication>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Medication> FindAsync(params object[] keyValues)
        {
            return await DbSet.FindAsync(keyValues);
        }

        public async Task<Medication> InsertAsync(Medication entity, bool saveChanges = true)
        {
            var createdEntity = await DbSet.AddAsync(entity);
            if (saveChanges)
            {
                await Context.SaveChangesAsync();
            }

            return createdEntity.Entity;
        }

        public async Task<Medication> DeleteAsync(int id, bool saveChanges = true)
        {
            var entityToRemove = await DbSet.FindAsync(id);
            if (entityToRemove == null)
                return null;

            DbSet.Remove(entityToRemove);
            if (saveChanges)
            {
                await Context.SaveChangesAsync();
            }
            return entityToRemove;
        }
    }
}
