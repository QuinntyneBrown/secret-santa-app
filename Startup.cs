﻿using Owin;
using System.Web.Http;
using Microsoft.Owin;
using Unity.WebApi;
using Microsoft.Practices.Unity;
using SecretSantaApp.Features.Core;
using Microsoft.ServiceBus.Messaging;
using static Newtonsoft.Json.JsonConvert;
using Newtonsoft.Json.Linq;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNet.SignalR;
using SecretSantaApp.Features.Profiles;
using SecretSantaApp.Features.Recipients;

[assembly: OwinStartup(typeof(SecretSantaApp.Startup))]

namespace SecretSantaApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(config =>
            {
                var container = UnityConfiguration.GetContainer();
                config.DependencyResolver = new UnityDependencyResolver(container);
                ApiConfiguration.Install(config, app);
                
                var client = SubscriptionClient.CreateFromConnectionString(CoreConfiguration.Config.EventQueueConnectionString, CoreConfiguration.Config.TopicName, CoreConfiguration.Config.SubscriptionName);

                var profilesEventBusMessageHandler = container.Resolve<IProfilesEventBusMessageHandler>();
                var recpientsEventBusMessageHandler = container.Resolve<IRecipientsEventBusMessageHandler>();

                client.OnMessage(message =>
                {
                    try
                    {
                        var messageBody = ((BrokeredMessage)message).GetBody<string>();
                        var messageBodyObject = DeserializeObject<JObject>(messageBody, new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                            TypeNameHandling = TypeNameHandling.All,
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        });

                        profilesEventBusMessageHandler.Handle(messageBodyObject);
                        recpientsEventBusMessageHandler.Handle(messageBodyObject);

                        GlobalHost.ConnectionManager.GetHubContext<EventHub>().Clients.All.events(messageBodyObject);
                    }
                    catch (Exception e)
                    {

                    }
                });
            });
        }
    }
}