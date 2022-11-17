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

        public Project GetByTitle(string title)
        {
            return
            dbSet.Where(t => t.Title == title)
            .FirstOrDefault();
        }

        public void DeleteById(long id)
        {
            var project = GetByIdAsync(id);
            dbSet.Remove(project.Result);
        }

        public Project GetById(long id)
        {
            return
            dbSet.Find(id);
        }
    }
}
