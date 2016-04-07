using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace MinecraftSite.Helpers
{
    public class MojangLogin
    {/*
        public enum LoginResult { OtherError, ServiceUnavailable, SSLError, Success, WrongPassword, AccountMigrated, NotPremium };

        public static LoginResult GetLogin(ref string user, string pass, ref string accesstoken, ref string uuid)
        {
            /* <summary>
            Allows to login to a premium Minecraft account using the Yggdrasil authentication scheme.
            </summary>
            <param name="user">Login</param>
            <param name="pass">Password</param>
            <param name="accesstoken">Will contain the access token returned by Minecraft.net, if the login is successful</param>
            <param name="uuid">Will contain the player's UUID, needed for multiplayer</param>
            <returns>Returns the status of the login (Success, Failure, etc.)</returns>
            try
            {
                string result = "";
                string json_request = "{\"agent\": { \"name\": \"Minecraft\", \"version\": 1 }, \"username\": \"" + jsonEncode(user) + "\", \"password\": \"" + jsonEncode(pass) + "\" }";
                int code = doHTTPSPost("authserver.mojang.com", "/authenticate", json_request, ref result);
                if (code == 200)
                {
                    if (result.Contains("availableProfiles\":[]}"))
                    {
                        return LoginResult.NotPremium;
                    }
                    else
                    {
                        string[] temp = result.Split(new string[] { "accessToken\":\"" }, StringSplitOptions.RemoveEmptyEntries);
                        if (temp.Length >= 2) { accesstoken = temp[1].Split('"')[0]; }
                        temp = result.Split(new string[] { "name\":\"" }, StringSplitOptions.RemoveEmptyEntries);
                        if (temp.Length >= 2) { user = temp[1].Split('"')[0]; }
                        temp = result.Split(new string[] { "availableProfiles\":[{\"id\":\"" }, StringSplitOptions.RemoveEmptyEntries);
                        if (temp.Length >= 2) { uuid = temp[1].Split('"')[0]; }
                        return LoginResult.Success;
                    }
                }
                else if (code == 403)
                {
                    if (result.Contains("UserMigratedException"))
                    {
                        return LoginResult.AccountMigrated;
                    }
                    else return LoginResult.WrongPassword;
                }
                else if (code == 503)
                {
                    return LoginResult.ServiceUnavailable;
                }
                else
                {
                    ConsoleIO.WriteLineFormatted("§8Got error code from server: " + code);
                    return LoginResult.OtherError;
                }
            }
            catch (System.Security.Authentication.AuthenticationException)
            {
                return LoginResult.SSLError;
            }
            catch (System.IO.IOException e)
            {
                if (e.Message.Contains("authentication"))
                {
                    return LoginResult.SSLError;
                }
                else return LoginResult.OtherError;
            }
            catch
            {
                return LoginResult.OtherError;
            }
        }

        private static int doHTTPSPost(string host, string endpoint, string request, ref string result)
        {
            
            /*Manual HTTPS request since we must directly use a TcpClient because of the proxy.
            This method connects to the server, enables SSL, do the request and read the response.
            
            <param name="host">Host to connect to</param>
            <param name="endpoint">Endpoint for making the request</param>
            <param name="request">Request payload</param>
            <param name="result">Request result</param>
            <returns>HTTP Status code</returns>

            TcpClient client = ProxyHandler.newTcpClient(host, 443);
            SslStream stream = new SslStream(client.GetStream());
            stream.AuthenticateAsClient(host);

            List<String> http_request = new List<string>();
            http_request.Add("POST " + endpoint + " HTTP/1.1");
            http_request.Add("Host: " + host);
            http_request.Add("User-Agent: MCC/" + Program.Version);
            http_request.Add("Content-Type: application/json");
            http_request.Add("Content-Length: " + Encoding.ASCII.GetBytes(request).Length);
            http_request.Add("Connection: close");
            http_request.Add("");
            http_request.Add(request);

            stream.Write(Encoding.ASCII.GetBytes(String.Join("\r\n", http_request.ToArray())));
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string raw_result = sr.ReadToEnd();

            if (raw_result.StartsWith("HTTP/1.1"))
            {
                result = raw_result.Substring(raw_result.IndexOf("\r\n\r\n") + 4);
                return Settings.str2int(raw_result.Split(' ')[1]);
            }
            else return 520; //Web server is returning an unknown error
        }

        private static string jsonEncode(string text)
        {
            /*Encode a string to a json string.
            Will convert special chars to \u0000 unicode escape sequences.
            <param name="text">Source text</param>
            <returns>Encoded text</returns>

            StringBuilder result = new StringBuilder();
            foreach (char c in text)
            {
                if (char.IsLetterOrDigit(c))
                {
                    result.Append(c);
                }
                else
                {
                    result.Append("\\u");
                    result.Append(((int)c).ToString("x4"));
                }
            }
            return result.ToString();
        }*/
    }
}