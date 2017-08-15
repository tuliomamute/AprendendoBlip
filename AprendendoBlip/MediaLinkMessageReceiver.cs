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

namespace AprendendoBlip
{
    public class MediaLinkMessageReceiver : IMessageReceiver
    {
        private readonly IMessagingHubSender _sender;

        public MediaLinkMessageReceiver(IMessagingHubSender sender)
        {
            _sender = sender;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken = default(CancellationToken))
        {
            MediaLink media = RetornaObjetoMediaLink();
            await _sender.SendMessageAsync(media, message.From, cancellationToken);

        }

        public MediaLink RetornaObjetoMediaLink()
        {
            return new MediaLink() { Uri = new Uri(@"http://wallpaperswide.com/street_fighter_v_2015-wallpapers.html"), Title = "Imagem Street Fighter 5", Type = MediaType.ApplicationJson };
        }
    }
}
