using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class WebServer
    {
        /// <summary>
        /// Starts the specified HTTP listener prefix.
        /// </summary>
        /// <param name="httpListenerPrefix">The HTTP listener prefix.</param>
        public async void Start(string httpListenerPrefix)
        {
            HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add(httpListenerPrefix);
            httpListener.Start();
            Console.WriteLine("Server Started.\nListening for client connections.");

            while (true)
            {
                HttpListenerContext httpListenerContext = await httpListener.GetContextAsync();
                if (httpListenerContext.Request.IsWebSocketRequest)
                {
                    ProcessRequest(httpListenerContext);
                }
                else
                {
                    httpListenerContext.Response.StatusCode = 400;
                    httpListenerContext.Response.Close();
                }
            }
        }
        /// <summary>
        /// Processes the request.
        /// </summary>
        /// <param name="httpListenerContext">The HTTP listener context.</param>
        private async void ProcessRequest(HttpListenerContext httpListenerContext)
        {
            WebSocketContext webSocketContext = null;
            try
            {
                webSocketContext = await httpListenerContext.AcceptWebSocketAsync(subProtocol: null);
                string ipAddress = httpListenerContext.Request.RemoteEndPoint.Address.ToString();
                Console.WriteLine("Handshake initiated.\nConnected: IPAddress {0}", ipAddress);
            }
            catch (Exception e)
            {
                httpListenerContext.Response.StatusCode = 500;
                httpListenerContext.Response.Close();
                Console.WriteLine("Exception: {0}", e);
                return;
            }

            WebSocket webSocket = webSocketContext.WebSocket;
            try
            {

                byte[] receiveBuffer = new byte[1024];
                while (webSocket.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);
                    string txtConverted = Encoding.UTF8.GetString(receiveBuffer, 0, receiveBuffer.Length);
                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                    else
                    {
                        var restult = PerfomCalculation(txtConverted).ToString() ;
                        Console.WriteLine("Value Received: {0}", txtConverted);
                        var rstBuffer = Encoding.UTF8.GetBytes(restult);
                        await webSocket.SendAsync(new ArraySegment<byte>(rstBuffer, 0, rstBuffer.Length), WebSocketMessageType.Binary, receiveResult.EndOfMessage, CancellationToken.None);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
            finally
            {
                if (webSocket != null)
                    webSocket.Dispose();
            }
        }
        /// <summary>
        /// Perfoms the calculation.
        /// </summary>
        /// <param name="txtInput">The text input.</param>
        /// <returns></returns>
        decimal PerfomCalculation(string txtInput)
        {
            var chInput = txtInput.Split(',');
            decimal num1 = 0, num2 = 0;
            string txtOperator = string.Empty;

            num1 = Convert.ToInt32(chInput[0]);
            num2 = Convert.ToInt32(chInput[1]);
            txtOperator = chInput[2].Substring(0, 1);
            
            return doCalculation(num1,num2,txtOperator);
        }
        /// <summary>
        /// Does the calculation.
        /// </summary>
        /// <param name="num1">The num1.</param>
        /// <param name="num2">The num2.</param>
        /// <param name="txtOperator">The text operator.</param>
        /// <returns></returns>
        decimal doCalculation(decimal num1, decimal num2, string txtOperator)
        {
            decimal rst = 0;
            switch (txtOperator)
            {
                case "a":
                    rst = num1 + num2;
                    break;
                case "s":
                    rst = num1 - num2;
                    break;
                case "m":
                    rst = num1 * num2;

                    break;
                case "d":
                    if (num2 > 0)
                        rst = num1 + num2;
                    else
                        rst = 0;
                    break;
                default:
                    rst = 0;
                    break;
            }
            return rst;
        }
    }
}
