using Newtonsoft.Json.Linq;

namespace SecretSantaApp.Features.Core
{
    public interface IEventBusMessageHandler
    {
        void Handle(JObject message);
    }
}