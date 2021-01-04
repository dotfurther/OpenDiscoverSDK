// ***************************************************************************************
// 
//  Copyright © 2019-2021 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System;
using System.Reflection;
using System.Runtime.Versioning;
using System.ServiceModel;
using System.ServiceModel.Description;
using SdkAPI.Common;
using SdkAPIWCFService;

namespace SdkAPIServiceHost
{
    class Program
    {
        /// <summary>
        /// Example: console application that hosts a WCF Open Discover SDK API Service. The hosted services uses a fast 
        /// named pipe for inter-process communication.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                //
                // Set console title with Framework Version:
                //
                var ver = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
                Console.Title = string.Format("SdkAPIServiceHost - SDK API Service Host;      Framework Version = {0}", ver != null ? ver : "Unknown");

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Starting SdkAPIService...");

                // We use a named pipe binding for fast inter-process communication:
                var address    = "net.pipe://localhost/SdkAPIService"; 
                var addressUri = new Uri(address);
                var binding    = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);

                binding.MaxBufferSize          = int.MaxValue;  
                binding.MaxReceivedMessageSize = binding.MaxBufferSize;
                binding.MaxConnections         = 2;
                binding.ReceiveTimeout         = new TimeSpan(1, 0, 0);

                // Create the ServiceHost:
                using (var host = new ServiceHost(typeof(SdkAPIService), new Uri[] { addressUri }))
                {
                    host.AddServiceEndpoint(typeof(ISdkAPIService), binding, address);
                    host.Faulted += Host_Faulted;
                    host.Opened  += Host_Opened;
                    host.Closed  += Host_Closed;
                    host.UnknownMessageReceived += Host_UnknownMessageReceived;

                    var debug = host.Description.Behaviors.Find<ServiceDebugBehavior>();

                    // if not found - add behavior with setting turned on 
                    if (debug == null)
                    {
                        host.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });
                    }
                    else
                    {
                        // make sure setting is turned ON
                        if (!debug.IncludeExceptionDetailInFaults)
                        {
                            debug.IncludeExceptionDetailInFaults = true;
                        }
                    }

                    Console.WriteLine("Opening SdkAPIService...");

                    // Open the ServiceHost to start listening for messages. Since no endpoints are explicitly configured, the runtime will create
                    // one endpoint per base address for each service contract implemented by the service.
                    host.Open();

                    Console.WriteLine("The service is ready at {0}", addressUri);
                    Console.WriteLine("Press <Enter> to stop the service.");
                    Console.ReadLine();

                    // Close the ServiceHost.
                    host.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error starting SdkAPIService. Error:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(ex.StackTrace);

                Console.WriteLine("Press <Enter> to exit console host.");
                Console.ReadLine();
            }
        }

        private static void Host_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("SdkAPIService is now closed.");
        }

        private static void Host_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("SdkAPIService is now open.");
        }

        private static void Host_Faulted(object sender, EventArgs e)
        {
            Console.WriteLine("SdkAPIService faulted.");
        }

        private static void Host_UnknownMessageReceived(object sender, UnknownMessageReceivedEventArgs e)
        {
            Console.WriteLine("SdkAPIService received an unknown message.");
        }
    }
}
