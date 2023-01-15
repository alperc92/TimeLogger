using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timelogger.Entities;

namespace Timelogger.Persistence
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly ApiContext _context;

        public ProjectRepository(ApiContext apiContext)
        {
            _context = apiContext;
        }

        #region GET
        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            var result = await Task.FromResult(_context.Projects
                                            .Include(p => p.Weeks)
                                            .ThenInclude(w=>w.Days));
            return result;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsOrderedByDeadline()
        {
            var result = await Task.FromResult(_context.Projects
                                        .Include(p => p.Weeks)
                                        .ThenInclude(w => w.Days)
                                        .OrderByDescending(p=>p.Deadline));
            return result;
        }

        public async Task<Project> GetSingleProject(int projectId)
        {
            var result = await _context.Projects
                                .Include(p=>p.Weeks)
                                .ThenInclude(w => w.Days)
                                .Where(p=>p.Id == projectId)
                                .FirstOrDefaultAsync();
            return result;
        }
        #endregion

        #region POST
        public async Task<int> RegisterProject(Project project)
        {
            _ = await _context.Projects.AddAsync(project);
            var result = await _context.SaveChangesAsync();
            return result;
        }
        #endregion
    }
}
