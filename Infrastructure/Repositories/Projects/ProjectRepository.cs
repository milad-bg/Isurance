using Domain.Domain.Entities.Projects;
using Domain.Interfaces.IRepository.Projects;
using Infrastructure.Context;
using Infrastructure.GenericRepositores;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Projects
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DataBaseDbcontext context) : base(context) { }

        public List<Project> GetProjects(int pageNumber, int pageSize)
        {
            return
                dbSet.Include(c => c.City)
                   .AsParallel()
                   .OrderBy(on => on.CreationDate)
                   .Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize)
                   .ToList();
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            var result = await InsertReturnAsync(project);

            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteListByIds(List<long> ids)
        {
            var getProjects = await GetByIds(ids);

            dbSet.RemoveRange(getProjects);

            return await _context.SaveChangesAsync() > 1;
        }

        public async Task<List<Project>> GetByIds(List<long> ids)
        {
            return await dbSet.Where(w => ids.Contains(w.Id)).ToListAsync();
        }

        public async Task<bool> DeleteProjectAsync(long id)
        {
            await DeleteAsync(id);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Project> EditProjectAsync(Project project)
        {
            var Edit = dbSet.Update(project);

            await _context.SaveChangesAsync();

            return Edit.Entity;
        }

        public async Task<List<Project>> GetAllProjectAsync()
        {
            var projects = await GetAll();

            return projects.ToList();
        }

        public async Task<List<Project>> GetAllProjectWebAsync()
        {
            return dbSet.Where(w => w.IsFeatured == true).ToList();
        }

        public async Task<Project> GetByProjectIdAsync(long id)
        {
            var newscast = await GetByIdAsync(id);

            return newscast;
        }
    }
}
