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
    public class UserInputMessageReceiver : IMessageReceiver
    {
        private readonly IMessagingHubSender _sender;
        public UserInputMessageReceiver(IMessagingHubSender sender)
        {
            _sender = sender;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken = default(CancellationToken))
        {
            Input input = RetornaObjetoInput();
            await _sender.SendMessageAsync(input, message.From, cancellationToken);
        }

        private Input RetornaObjetoInput()
        {
            return new Input()
            {
                Label = new DocumentContainer()
                {
                    Value = "Qual sua localização?"
                },
                Validation = new InputValidation()
                {
                    Rule = InputValidationRule.Type,
                    Type = Location.MediaType
                }
            };
        }
    }
}
