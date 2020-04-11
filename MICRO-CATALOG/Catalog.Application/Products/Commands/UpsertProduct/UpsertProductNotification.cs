using MediatR;
using Spk.Catalog.Application.Common.Interfaces;
using Spk.Catalog.Application.Notifications.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Spk.Catalog.Application.Products.Commands.UpsertProduct
{
    public class UpsertProductNotification : INotification
    {
        public long ProductId { get; set; }
        public string Action { get; set; }
        public string Name { get; set; }

        public class UpsertProductNotificationHandler : INotificationHandler<UpsertProductNotification>
        {
            private readonly INotificationService _notification;

            public UpsertProductNotificationHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(UpsertProductNotification notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new MessageDto());
            }
        }
    }
}
