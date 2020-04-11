using Spk.Catalog.Application.Common.Interfaces;
using Spk.Catalog.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Spk.Catalog.Infrastructure.Notifications
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
