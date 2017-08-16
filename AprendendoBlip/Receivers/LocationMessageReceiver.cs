using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lime.Protocol;
using Takenet.MessagingHub.Client.Listener;
using Takenet.MessagingHub.Client.Sender;
using Lime.Messaging.Contents;
using Takenet.MessagingHub.Client;

namespace AprendendoBlip.Receivers
{
    public class LocationMessageReceiver : IMessageReceiver
    {
        private readonly IMessagingHubSender _sender;

        public LocationMessageReceiver(IMessagingHubSender sender)
        {
            _sender = sender;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken = default(CancellationToken))
        {
            Location location = RetornaObjetoLocation();
            await _sender.SendMessageAsync(location, message.From, cancellationToken);
        }

        private Location RetornaObjetoLocation()
        {
            return new Location()
            {
                Latitude = -19.918899,
                Longitude = -43.959275,
                Altitude = 853,
                Text = "Sede da Take.net"
            };
        }
    }
}
