using System.Collections.Generic;
using System.Threading.Tasks;
using InterviewApplication.Core.Entities;
using InterviewApplication.Core.Interfaces;
using InterviewApplication.Core.Specifications;

namespace InterviewApplication.Core.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IAsyncRepository<Dashboard> _dashboardAsyncRepository;

        public DashboardService(IAsyncRepository<Dashboard> dashboardAsyncRepository)
        {
            _dashboardAsyncRepository = dashboardAsyncRepository;
        }

        public async Task<IReadOnlyList<Dashboard>> GetDashboard(string searchText, int page = 1, int pageSize = 25)
        {
            var spec = new FilterPaginationSpecification(page * pageSize, pageSize, searchText);
            return await _dashboardAsyncRepository.ListAsync(spec);
        }
    }
}
