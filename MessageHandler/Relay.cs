using System;
using System.ComponentModel.Composition;
using BuildABot.Core.MessageHandlers;
using Log;
using System.Configuration;
using Newtonsoft.Json;
namespace PocBotLib
{
    [Export(typeof(MessageHandler))]
    public class Relay : SingleStateMessageHandler
    {
        public Relay() :base(".*"){ 
        }
        protected override string GetInitialHandlingText()
        {
            Logger.Debug("GetInitialHandlingText function");
            return base.GetInitialHandlingText();
        }

        public override Reply Handle(Message message) {
            Logger.Debug("Handle function");
            Reply reply = new Reply();
            try
            {
                RequestApi.RequestApi request = new RequestApi.RequestApi();
                String endpointBot = ConfigurationManager.AppSettings["endpoint"];
                Logger.Debug("endpoint string " + endpointBot);
                String messageJson = JsonConvert.SerializeObject(message);
                Logger.Debug(messageJson);
                String response = request.post(endpointBot,messageJson);
                dynamic responseJson = JsonConvert.DeserializeObject(response);
                Logger.Debug(responseJson.message);
                reply.Add((string)responseJson.message);
                Logger.Debug("bot message = " + message.Content);
            }
            catch (Exception e)
            {
                reply.Add("je recontre un problème dans mon système... contactez mes développeurs");
                Logger.Debug("error :" + e);
            }
            return reply; 
        }
       
    }
}
