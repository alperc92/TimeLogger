using System.Threading.Tasks;
using Timelogger.Entities;

namespace Timelogger.Api.DomainServices
{
    public interface IWeekDomainService
    {
        Task<bool> RegisterWeekValidate(Week week);
    }
}