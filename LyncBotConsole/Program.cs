using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildABot.Core.MessageHandlers;
using BuildABot.Util;
using BuildABot.Core;
using BuildABot.UC;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Configuration;
using PocBotLib;
using Log;


namespace UcmaBot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Logger.Debug("main bot function");
                Debug.Listeners.Add(new ConsoleTraceListener());

                String applicationUserAgent = ConfigurationManager.AppSettings["applicationuseragent"];
                String applicationurn = ConfigurationManager.AppSettings["applicationurn"];
                Logger.Debug("applicationUserAgent : " + applicationUserAgent);
                Logger.Debug("applicationurn : " + applicationurn);
                UCBotHost ucBotHost = new UCBotHost(applicationUserAgent, applicationurn);
                Logger.Debug("ucBotHost init: " + ucBotHost.ToString());
                Logger.Debug("ucBot is running...");
                ucBotHost.Run();
            }
            catch (Exception e) {
                Logger.Debug("error : " + e);
                Console.ReadLine();
            }
            
        }
    }
}
