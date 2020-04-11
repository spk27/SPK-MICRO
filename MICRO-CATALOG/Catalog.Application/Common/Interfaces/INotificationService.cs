using Spk.Catalog.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Spk.Catalog.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
