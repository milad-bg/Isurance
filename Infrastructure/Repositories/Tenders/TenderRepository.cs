using Domain.Domain.Entities.Tendor;
using Domain.Interfaces.IRepository.Tenders;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Tenders
{
    public class TenderRepository : GenericRepository<Tender>, ITenderRepository
    {
        public TenderRepository(DataBaseDbcontext context) : base(context) { }

        public async Task<Tender> AddTenderAsync(Tender project)
        {
            var result = await InsertReturnAsync(project);

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<List<Tender>> GetAllProjectAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Tender> GetById(long id)
        {
            return await dbSet.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
