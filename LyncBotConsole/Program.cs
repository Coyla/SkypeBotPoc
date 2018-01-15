using System;
using BuildABot.UC;
using System.Diagnostics;
using System.Configuration;
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
