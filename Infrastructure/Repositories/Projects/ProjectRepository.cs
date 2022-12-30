using Domain.Domain.Entities.Projects;
using Domain.Interfaces.IRepository.Projects;
using Domain.Interfaces.IRepository.Projects.Dtos;
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

        public async Task<List<Project>> GetProjects(int pageNumber, int pageSize)
        {
            return
                dbSet.Where(w => w.IsFeatured == true)
                   .Include(c => c.City)
                   .AsParallel()
                   .OrderBy(o => o.Priority)
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
            return await dbSet.Include(i => i.City).ToListAsync();
        }

        public async Task<List<Project>> GetAllProjectWebAsync()
        {
            return dbSet.Where(w => w.IsFeatured == true).ToList();
        }

        public async Task<Project> GetByProjectIdAsync(long id)
        {
            return await dbSet.Include(i => i.City).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<List<SearchProjectsDto>> SearchInContentAsync(string key)
        {
            return await dbSet
                .Include(i => i.City)
                .Where(w => w.IsFeatured == true && (w.UpperContent.Contains(key) || w.DownContent.Contains(key)))
                .OrderBy(model => model.Title)
                .Take(10)
                .Select(model => new SearchProjectsDto
                {
                    Id = model.Id,
                    Title = model.Title,
                    UpperContent = model.UpperContent,
                    DownContent = model.DownContent,
                    Description = model.Description,
                    State = model.State,
                    Type = model.Type,
                    CityTitle = model.City.Title
                })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
