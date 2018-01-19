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
        public Relay()
        :base(".*"){ 
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
                if (message.Content == "post request")
                {
                    //request_api
                    RequestApi.RequestApi request = new RequestApi.RequestApi();
                    Logger.Debug("request - Handle " + request.ToString());
                    String endpointBot =  ConfigurationManager.AppSettings["endpoint"];
                    Logger.Debug("endpoint string " + endpointBot);
                    String jsonData = "{\"message\":\"hello world\"}";
                    String response  = request.getResponse(endpointBot,jsonData);
                    Logger.Debug("API response : " + response);
                    reply.Add("api : " + response);
                }
                else if (message.Content == "get request") {
                    //request_api
                    RequestApi.RequestApi request = new RequestApi.RequestApi();
                    Logger.Debug("request - Handle " + request.ToString());
                    String endpointBot = ConfigurationManager.AppSettings["endpoint"];
                    Logger.Debug("endpoint string " + endpointBot);
                    String response = request.getResponseGet(endpointBot);
                    Logger.Debug("API response : " + response);
                    reply.Add("api : " + response);
                }
                else
                {
                    RequestApi.RequestApi request = new RequestApi.RequestApi();
                    Logger.Debug("request - Handle " + request.ToString());
                    String endpointBot = ConfigurationManager.AppSettings["endpoint"];
                    Logger.Debug("endpoint string " + endpointBot);
                    String jsonData = "{\"message\":\""+ message.Content +"\"}";
                    String response = request.getResponse(endpointBot,jsonData);
                    dynamic responseJson = JsonConvert.DeserializeObject(response);
                    Logger.Debug(responseJson.message);
                    reply.Add((string)responseJson.message);
                    Logger.Debug("bot message = " + response);
                }

            }
            catch (Exception e)
            {
                reply.Add("error bot : " + e.Message);
                Logger.Debug("error :" + e);
            }
            return reply; 
        }
       
    }
}
