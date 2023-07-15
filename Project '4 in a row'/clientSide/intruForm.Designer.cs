
namespace clientSide
{
    partial class intruForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NTlogin = new System.Windows.Forms.Button();
            this.BTregister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NTlogin
            // 
            this.NTlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.NTlogin.Location = new System.Drawing.Point(447, 295);
            this.NTlogin.Margin = new System.Windows.Forms.Padding(4);
            this.NTlogin.Name = "NTlogin";
            this.NTlogin.Size = new System.Drawing.Size(189, 59);
            this.NTlogin.TabIndex = 0;
            this.NTlogin.Text = "LOGIN";
            this.NTlogin.UseVisualStyleBackColor = true;
            this.NTlogin.Click += new System.EventHandler(this.NTlogin_Click);
            // 
            // BTregister
            // 
            this.BTregister.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.BTregister.Location = new System.Drawing.Point(447, 407);
            this.BTregister.Margin = new System.Windows.Forms.Padding(4);
            this.BTregister.Name = "BTregister";
            this.BTregister.Size = new System.Drawing.Size(189, 59);
            this.BTregister.TabIndex = 1;
            this.BTregister.Text = "REGISTER";
            this.BTregister.UseVisualStyleBackColor = true;
            this.BTregister.Click += new System.EventHandler(this.BTregister_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(394, 130);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 81);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome";
//            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // intruForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTregister);
            this.Controls.Add(this.NTlogin);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "intruForm";
            this.Text = "intru Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button NTlogin;
        private System.Windows.Forms.Button BTregister;
        private System.Windows.Forms.Label label1;
    }
}

