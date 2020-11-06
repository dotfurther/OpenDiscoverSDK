// ***************************************************************************************
// 
//  Copyright © 2019-2020 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System.Windows.Forms;

namespace SdkAPIWinFormClient
{
    public interface IHostUI
    {
        void LogMessage(string message);
        void ShowMessageBox(string message, string caption);
        DialogResult RequestPassword(out string password);
        void         ShowBusy(bool isBusy);
    }
}
