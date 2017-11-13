using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Net;
using Log;

namespace RequestApi
{
    public class RequestApi
    {
        public string getResponse(string url)
        {
            Logger.Debug("get Response function");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //prepare data to send
            String messageJson = "{\"message\":\"hello word\"}";
            Logger.Debug("messageJson : " + messageJson);
            byte[] byteArray = Encoding.UTF8.GetBytes(messageJson);
            Logger.Debug("bytes json : " + byteArray);
            
            //prepare request
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            //insert data into request
            using (Stream stream = request.GetRequestStream()) { 
                stream.Write(byteArray,0,byteArray.Length);
            }
            
            //getting response
            try
            {
                Logger.Debug("response object : " + request.GetResponse().ToString());
                WebResponse response = request.GetResponse();
                Logger.Debug("response object : " + response.ToString());
                Logger.Debug("responseStream object : " + response.GetResponseStream());
                //reading response
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    Logger.Debug("reader object : " + reader.ToString());
                    return reader.ReadToEnd();
                }
                
            }
            catch (WebException e)
            {
                WebResponse errorResponse = e.Response;
                Logger.Debug("errorResponse object : " + errorResponse.ToString());
                //reading error response
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    Logger.Debug("responseStream object : " + responseStream.ToString());
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    Logger.Debug("reader object : " + reader.ToString());
                    String error = "error request api" + reader.ReadToEnd();
                    Logger.Debug("error object : " + error);
                    return reader.ReadToEnd();
                }
                throw;
            }
        }
        public string getResponseGet(string url) { 
            Logger.Debug("get Response function");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            //getting response
            try
            {
                Logger.Debug("response object : " + request.GetResponse().ToString());
                WebResponse response = request.GetResponse();
                Logger.Debug("response object : " + response.ToString());
                Logger.Debug("responseStream object : " + response.GetResponseStream());
                //reading response
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    Logger.Debug("reader object : " + reader.ToString());
                    return reader.ReadToEnd();
                }

            }
            catch (WebException e)
            {
                WebResponse errorResponse = e.Response;
                Logger.Debug("errorResponse object : " + errorResponse.ToString());
                //reading error response
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    Logger.Debug("responseStream object : " + responseStream.ToString());
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    Logger.Debug("reader object : " + reader.ToString());
                    String error = "error request api" + reader.ReadToEnd();
                    Logger.Debug("error object : " + error);
                    return reader.ReadToEnd();
                }
                throw;
            }
        }
    }
}
