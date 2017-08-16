using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lime.Protocol;
using Takenet.MessagingHub.Client.Listener;
using Takenet.MessagingHub.Client.Sender;
using Takenet.MessagingHub.Client;
using Lime.Messaging.Contents;

namespace AprendendoBlip.Receivers
{
    public class DocumentSelectMessageReceiver : IMessageReceiver
    {
        private readonly IMessagingHubSender _sender;

        public DocumentSelectMessageReceiver(IMessagingHubSender sender)
        {
            _sender = sender;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken = default(CancellationToken))
        {
            DocumentSelect collection = RetornaObjetoDocumentCollection();
            await _sender.SendMessageAsync(collection, message.From, cancellationToken);

            throw new NotImplementedException();
        }

        private DocumentSelect RetornaObjetoDocumentCollection()
        {
            return new DocumentSelect()
            {
                Header = new DocumentContainer()
                {
                    Value = new MediaLink()
                    {
                        Uri = new Uri(@"http://cdn.ndtv.com/tech/gadgets/street-fighter-v-ryu-artwork.jpg"),
                        Title = "Imagem Street Fighter 5",
                        Type = $"{MediaType.DiscreteTypes.Image}/{MediaType.SubTypes.JPeg}"
                    }
                },
                Options = new DocumentSelectOption[]
                {
                    new DocumentSelectOption(){
                        Label = new DocumentContainer(){
                            Value =new PlainText(){
                                Text ="Valor 1"
                            }
                        }
                    },
                     new DocumentSelectOption(){
                        Label = new DocumentContainer(){
                            Value =new PlainText(){
                                Text ="Valor 2"
                            }
                        }
                    },
                     new DocumentSelectOption(){
                        Label = new DocumentContainer(){
                            Value =new PlainText(){
                                Text ="Valor 3"
                            }
                        }
                    }
                }
            };
        }
    }
}
