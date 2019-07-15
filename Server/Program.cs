using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Server
{
    class Program
    {
        private static int Count = 25;
        static void Main(string[] args)
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
            WebServer websocketServer = new WebServer();
            websocketServer.Start("http://localhost:80/WS/");
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
            Console.WriteLine(Count);
            if (Count == 0)
            {
                TerminateServer();
            }
            Count--;
        }
        /// <summary>
        /// Terminates the server.
        /// </summary>
        static void TerminateServer()
        {
            foreach (Process proc in Process.GetProcessesByName("Server"))
            {
                proc.Kill();
            }
        }
    }
}
