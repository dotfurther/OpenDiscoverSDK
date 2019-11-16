// ***************************************************************************************
// 
//  Copyright © 2019-2020 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System;
using System.Windows.Forms;

namespace ContentExtractionExample
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
            this.Shown += PasswordForm_Shown;
        }

        private void PasswordForm_Shown(object sender, EventArgs e)
        {
            _passwordTextBox.Focus();
            _passwordTextBox.SelectionStart = 0;
        }

        public string Password
        {
            get { return _passwordTextBox.Text; }
        }
    }
}
