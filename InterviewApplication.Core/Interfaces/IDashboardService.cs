using System.Collections.Generic;
using System.Threading.Tasks;
using InterviewApplication.Core.Entities;

namespace InterviewApplication.Core.Interfaces
{
    public interface IDashboardService
    {
        Task<IReadOnlyList<Dashboard>> GetDashboard(string searchText, int page = 1, int pageSize = 25);
    }
}
