// ***************************************************************************************
// 
//  Copyright © 2019-2025 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System;
using System.Windows;

namespace DocumentIdentifierExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private bool _shownBuildWarning;

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
                base.OnStartup(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Open Discover SDK is x64 build. Make sure your Visual Studio solution platform is set to x64 before building.\n\nException:\n" + ex.Message, "Startup Error");
            }
        }

        void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if (!_shownBuildWarning)
            {
                MessageBox.Show("Open Discover SDK is x64 build. Make sure your Visual Studio solution platform is set to x64 before building.\n\nException:\n" + e.Exception.Message,
                                "App DispatcherUnhandledException...");
                _shownBuildWarning = true;
            }
        }
    }
}
