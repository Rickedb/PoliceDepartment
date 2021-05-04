using PoliceDepartment.Domain.Entities;
using PoliceDepartment.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace PoliceDepartment.Domain.Services
{
    public class CriminalCodeService : QueryableDatabaseService<CriminalCode>
    {
        private new IQueryableRepository<CriminalCode> Repository { get => (IQueryableRepository<CriminalCode>)base.Repository; }

        public CriminalCodeService(IQueryableRepository<CriminalCode> repository) : base(repository)
        {

        }

        public override Task<CriminalCode> AddAsync(CriminalCode entity)
        {
            entity.CreateDate = entity.UpdateDate = DateTime.Now;
            return base.AddAsync(entity);
        }

        public override async Task<CriminalCode> UpdateAsync(CriminalCode entity)
        {
            var dbEntity = await Repository.GetAsync(entity.Id);
            dbEntity.Name = entity.Name;
            dbEntity.Description = entity.Description;
            dbEntity.Penalty = entity.Penalty;
            dbEntity.PrisonTime = entity.PrisonTime;
            dbEntity.Status = entity.Status;
            dbEntity.UpdateUserId = entity.UpdateUserId;
            dbEntity.UpdateDate = DateTime.Now;
            return await base.UpdateAsync(dbEntity);
        }
    }
}
