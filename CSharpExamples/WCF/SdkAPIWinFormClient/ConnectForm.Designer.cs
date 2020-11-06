namespace SdkAPIWinFormClient
{
    partial class ConnectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._connectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _connectButton
            // 
            this._connectButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this._connectButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._connectButton.Location = new System.Drawing.Point(26, 24);
            this._connectButton.Name = "_connectButton";
            this._connectButton.Size = new System.Drawing.Size(162, 32);
            this._connectButton.TabIndex = 0;
            this._connectButton.Text = "Connect to Service";
            this._connectButton.UseVisualStyleBackColor = true;
            // 
            // ConnectForm
            // 
            this.AcceptButton = this._connectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 84);
            this.Controls.Add(this._connectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connect";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _connectButton;
    }
}