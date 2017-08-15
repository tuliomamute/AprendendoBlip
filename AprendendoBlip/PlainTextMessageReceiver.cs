using System;
using System.Threading;
using System.Threading.Tasks;
using Lime.Protocol;
using Takenet.MessagingHub.Client;
using Takenet.MessagingHub.Client.Listener;
using Takenet.MessagingHub.Client.Sender;
using System.Diagnostics;
using Lime.Messaging.Contents;

namespace AprendendoBlip
{
    public class PlainTextMessageReceiver : IMessageReceiver
    {
        private readonly IMessagingHubSender _sender;

        public PlainTextMessageReceiver(IMessagingHubSender sender)
        {
            _sender = sender;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
        {
            PlainText texto = RetornaObjetoPlainText();

            Trace.TraceInformation($"From: {message.From} \tContent: {message.Content}");
            await _sender.SendMessageAsync(texto, message.From, cancellationToken);
        }

        private PlainText RetornaObjetoPlainText()
        {
            return new PlainText() { Text = "Retornando um texto simples, utilizando a classe PlainText" };
        }
    }
}
