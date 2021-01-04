// ***************************************************************************************
// 
//  Copyright © 2019-2021 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System;
using System.Windows.Forms;

namespace SdkAPIWinFormClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Open Discover is x64 build. Make sure your Visual Studio solution platform is set to x64 before building.\n\nException:\n" + ex.Message, "Run Error");
            }
        }
    }
}
