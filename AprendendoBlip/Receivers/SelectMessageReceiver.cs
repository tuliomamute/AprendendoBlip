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
            SelectOption[] options = new SelectOption[10];

            options[0] = RetornaObjetoSelectOption(1, "Opção 1");
            options[1] = RetornaObjetoSelectOption(2, "Opção 2");
            options[2] = RetornaObjetoSelectOption(3, "Opção 3");
            options[3] = RetornaObjetoSelectOption(4, "Opção 4");
            options[4] = RetornaObjetoSelectOption(5, "Opção 5");
            options[5] = RetornaObjetoSelectOption(6, "Opção 6");
            options[6] = RetornaObjetoSelectOption(7, "Opção 7");
            options[7] = RetornaObjetoSelectOption(8, "Opção 8");
            options[8] = RetornaObjetoSelectOption(9, "Opção 9");
            options[9] = RetornaObjetoSelectOption(10, "Opção 10");

            //A opção de Scope que define como será apresentado as opções
            return new Select()
            {
                Scope = SelectScope.Immediate,
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
