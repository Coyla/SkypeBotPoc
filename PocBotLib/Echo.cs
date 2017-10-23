using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildABot.Core;
using BuildABot.Util;
using System.ComponentModel.Composition;
using BuildABot.Core.MessageHandlers;
using Log;
namespace PocBotLib
{
    [Export(typeof(MessageHandler))]
    public class Echo : SingleStateMessageHandler
    {
        public Echo()
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
                reply.Add("user said : " + message.Content);
                Logger.Debug("bot message = " + message.Content);

            }
            catch (Exception e)
            {
                Logger.Debug("error :" + e);
            }
            return reply;
           
        }  
    }
}
