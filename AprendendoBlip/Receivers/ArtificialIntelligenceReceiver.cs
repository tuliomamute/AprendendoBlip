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
using Takenet.MessagingHub.Client.Extensions.ArtificialIntelligence;
using Takenet.Iris.Messaging.Resources.ArtificialIntelligence;

namespace AprendendoBlip.Receivers
{
    public class ArtificialIntelligenceReceiver : IMessageReceiver
    {
        public readonly IMessagingHubSender _sender;

        public ArtificialIntelligenceReceiver(IMessagingHubSender sender)
        {
            _sender = sender;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!message.Content.ToString().ToLower().Contains("blip"))
            {
                await _sender.SendMessageAsync("Mensagem Padrão", message.From, cancellationToken);
                return;
            }

            ArtificialIntelligenceExtension ia = new ArtificialIntelligenceExtension(_sender);
            AnalysisResponse resposta = await ia.AnalyzeAsync(new AnalysisRequest() { Text = message.Content.ToString() });

            await _sender.SendMessageAsync(resposta.Intentions.First().Answer.Value, message.From, cancellationToken);
        }
    }
}
