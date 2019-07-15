using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Client
{
    class Program
    {
        /// <summary>
        /// The encoding
        /// </summary>
        private static UTF8Encoding encoding = new UTF8Encoding();
        /// <summary>
        /// The operators
        /// </summary>
        private static readonly string[] Operators = { "a", "s", "m", "d" };
        /// <summary>
        /// The count
        /// </summary>
        private static int Count = 10;
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
            Connect("ws://localhost/WS").Wait();
            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();
        }
        /// <summary>
        /// Called when [timed event].
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (Count == 0)
            {
                TerminateClient();
            }
            Count--;
        }
        /// <summary>
        /// Terminates the client.
        /// </summary>
        private static void TerminateClient()
        {
            Environment.Exit(0);
        }
        /// <summary>
        /// Connects the specified URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        public static async Task Connect(string uri)
        {
            Thread.Sleep(1000); //wait for a sec, so server starts and ready to accept connection..

            ClientWebSocket webSocket = null;
            try
            {
                webSocket = new ClientWebSocket();
                await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
                await Task.WhenAll(Receive(webSocket), Send(webSocket));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex);
            }
            finally
            {
                if (webSocket != null)
                    webSocket.Dispose();
                Console.WriteLine();
                Console.WriteLine("WebSocket closed.");
            }
        }
        /// <summary>
        /// Sends the specified web socket.
        /// </summary>
        /// <param name="webSocket">The web socket.</param>
        /// <returns></returns>
        private static async Task Send(ClientWebSocket webSocket)
        {
            while (webSocket.State == WebSocketState.Open)
            {
                Console.WriteLine("Write an equation to send to the server..");
                int iNum1 = 0, iNum2 = 0, iTemp = 0;
                string txtInput = string.Empty, txtOperator = string.Empty;
                Console.WriteLine("\nConsole Calculator in C#\r");
                Console.WriteLine("--------------------------\n");
                Console.WriteLine("Type a number, and then press Enter");
                while (!int.TryParse(Console.ReadLine(), out iTemp))
                {
                    Console.WriteLine("You entered an invalid number");
                    Console.WriteLine("Type a number, and then press Enter");
                }
                iNum1 = iTemp;
                Console.WriteLine("Type another number, and then press Enter");
                while (!int.TryParse(Console.ReadLine(), out iTemp))
                {
                    Console.WriteLine("You entered an invalid number");
                    Console.WriteLine("Type another number, and then press Enter");
                }
                iNum2 = iTemp;
                bool bCorrectMathOperator = true;
                AskQuestion();
                while (bCorrectMathOperator)
                {
                    txtOperator = Console.ReadLine();
                    if (Operators.Contains(txtOperator))
                        bCorrectMathOperator = false;
                    else
                    {
                        Console.WriteLine("You entered an invalid operator");
                        AskQuestion();
                    }
                }

                txtInput = GetInputEquation(iNum1,iNum2,txtOperator);
                string txtServerRequest = ($"{iNum1},{iNum2},{txtOperator}");
                byte[] buffer = encoding.GetBytes(txtServerRequest);
                await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Binary, false, CancellationToken.None);
                Console.WriteLine("Question:     " + txtInput);
                await Task.Delay(1000);
            }
        }

        /// <summary>
        /// Receives the specified web socket.
        /// </summary>
        /// <param name="webSocket">The web socket.</param>
        /// <returns></returns>
        private static async Task Receive(ClientWebSocket webSocket)
        {
            byte[] buffer = new byte[1024];
            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
                else
                {
                    Console.WriteLine("Answer:  " + Encoding.UTF8.GetString(buffer).TrimEnd('\0'));
                }
            }
        }

        /// <summary>
        /// Asks the question.
        /// </summary>
        static void AskQuestion()
        {
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");
        }
        /// <summary>
        /// Gets the input equation.
        /// </summary>
        /// <param name="num1">The num1.</param>
        /// <param name="num2">The num2.</param>
        /// <param name="txtOperator">The text operator.</param>
        /// <returns></returns>
        static string GetInputEquation(int num1, int num2, string txtOperator)
        {
            string rstText = string.Empty;
            switch (txtOperator)
            {
                case "a":
                    rstText = ($"What is  {num1} + {num2} ?");
                    break;
                case "s":
                    rstText = ($"What is  {num1} - {num2} ?");
                    break;
                case "m":
                    rstText = ($"What is  {num1} * {num2} ?");
                    break;
                case "d":
                    rstText = ($"What is  {num1} / {num2} ?");
                    break;
            }
            return rstText;
        }
    }
}
