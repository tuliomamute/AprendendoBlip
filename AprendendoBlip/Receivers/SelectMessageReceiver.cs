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
    public class SelectMessageReceiver : IMessageReceiver
    {
        private readonly IMessagingHubSender _sender;

        public SelectMessageReceiver(IMessagingHubSender sender)
        {
            _sender = sender;
        }
        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken = default(CancellationToken))
        {
            Select menu = RetornaObjetoSelect();
            await _sender.SendMessageAsync(menu, message.From, cancellationToken);

        }

        private Select RetornaObjetoSelect()
        {
            SelectOption[] options = new SelectOption[3];

            options[0] = RetornaObjetoSelectOption(1, "Opção 1");
            options[1] = RetornaObjetoSelectOption(2, "Opção 2");
            options[2] = RetornaObjetoSelectOption(3, "Opção 3");

            return new Select()
            {
                Text = "Escolha uma das opções abaixo",
                Options = options
            };
        }
        private SelectOption RetornaObjetoSelectOption(int ordem, string texto)
        {
            return new SelectOption()
            {
                Order = ordem,
                Text = texto
            };
        }
    }
}
