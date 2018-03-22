using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildABot.Core.MessageHandlers;
using BuildABot.Util;
using BuildABot.Core;
using System.ComponentModel.Composition;
using Log;


namespace GenericBotConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Debug("main function");
            try{
                
                Bot bot = new Bot();
                bot.Replied += new ReplyEventHandler(bot_Replied);
                string userMessage = Console.ReadLine();
                while (userMessage != "exit")
                {
                    Logger.Debug("user message : " + userMessage);
                    bot.ProcessMessage(userMessage);
                    userMessage = Console.ReadLine();
                }
            }catch(Exception e){
                
                Logger.Debug("error " + e);
            }
        }
        static void bot_Replied(object sender, ReplyEventArgs e) {
            Logger.Debug("bot_Replied function");
            try {
                foreach (ReplyMessage replyMessage in e.Reply.Messages)
                {
                    Logger.Debug("message from bot " + replyMessage.Content);
                }
            }
            catch (Exception ex) {
                
                Logger.Debug("error " + ex);
            }
          
        }
    }
}
