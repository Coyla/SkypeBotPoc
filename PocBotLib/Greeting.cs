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
    public class Greeting : MessageHandler
    {
        public Greeting()
            : base("hello")
        {

        }

        protected override StateHandler InitialStateHandler
        {   
            get
            {
                return AskForGreeting;
            }
        }
        public Reply AskForGreeting(Message message) {
            Logger.Debug("AskForGreeting function");
            Reply reply = new Reply();
            try{
                Logger.Debug(message.Content);
                reply.Add("Hello user");
                
            }catch(Exception e){
                Logger.Debug("error :" + e);
            }
            return reply;
           
        }


    }
}
