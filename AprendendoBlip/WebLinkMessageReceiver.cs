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
    public class WebLinkMessageReceiver : IMessageReceiver
    {
        private readonly IMessagingHubSender _sender;

        public WebLinkMessageReceiver(IMessagingHubSender sender)
        {
            _sender = sender;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken = default(CancellationToken))
        {
            WebLink link = RetornaObjetoWebLink();
            await _sender.SendMessageAsync(link, message.From, cancellationToken);

        }

        private WebLink RetornaObjetoWebLink()
        {
            return new WebLink()
            {
                Uri = new Uri("http://br.leagueoflegends.com/"),
                Text = "Site League of Legends",
                Title = "Site League of Legends",
                PreviewUri = new Uri("http://ddragon.leagueoflegends.com/cdn/7.16.1/img/champion/Kayn.png"),
                PreviewType = $"{MediaType.DiscreteTypes.Image}/{MediaType.SubTypes.JPeg}"
            };
        }
    }
}
