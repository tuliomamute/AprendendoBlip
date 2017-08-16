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
    public class DocumentListMessageReceiver : IMessageReceiver
    {
        private readonly IMessagingHubSender _sender;
        public DocumentListMessageReceiver(IMessagingHubSender sender)
        {
            _sender = sender;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken = default(CancellationToken))
        {
            DocumentList list = RetornaObjetoDocumentList();
           await _sender.SendMessageAsync(list, message.From, cancellationToken);
        }

        private DocumentList RetornaObjetoDocumentList()
        {
            return new DocumentList()
            {
                Header = new DocumentContainer()
                {
                    Value = new WebLink()
                    {
                        Uri = new Uri("http://br.leagueoflegends.com/"),
                        Text = "Site League of Legends",
                        Title = "Site League of Legends",
                        PreviewUri = new Uri("http://ddragon.leagueoflegends.com/cdn/7.16.1/img/champion/Kayn.png"),
                        PreviewType = $"{MediaType.DiscreteTypes.Image}/{MediaType.SubTypes.JPeg}"
                    }
                },
                Items = new DocumentContainer[] {
                   new DocumentContainer(){
                       Value = new WebLink(){
                           Title ="Localiza",
                           Uri =new Uri("https://www.localiza.com/"),
                           Text ="Bot Oficial da Localiza"
                       }
                   },
                   new DocumentContainer(){
                       Value = new WebLink(){
                           Title ="Santander",
                           Uri =new Uri("https://santander.com.br"),
                           Text ="Bot Oficial do Santander Brasil"
                       }
                   },
                }
            };
        }
    }
}
