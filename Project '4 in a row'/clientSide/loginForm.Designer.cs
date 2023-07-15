
namespace clientSide
{
    partial class loginForm
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
            this.BTlogin = new System.Windows.Forms.Button();
            this.BTreset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBusername = new System.Windows.Forms.TextBox();
            this.TBpassword = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBerrorpassword = new System.Windows.Forms.Label();
            this.LBerroruser = new System.Windows.Forms.Label();
            this.BTregister = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTlogin
            // 
            this.BTlogin.Location = new System.Drawing.Point(355, 276);
            this.BTlogin.Margin = new System.Windows.Forms.Padding(4);
            this.BTlogin.Name = "BTlogin";
            this.BTlogin.Size = new System.Drawing.Size(136, 35);
            this.BTlogin.TabIndex = 0;
            this.BTlogin.Text = "login";
            this.BTlogin.UseVisualStyleBackColor = true;
            this.BTlogin.Click += new System.EventHandler(this.BTlogin_Click);
            // 
            // BTreset
            // 
            this.BTreset.Location = new System.Drawing.Point(700, 310);
            this.BTreset.Margin = new System.Windows.Forms.Padding(4);
            this.BTreset.Name = "BTreset";
            this.BTreset.Size = new System.Drawing.Size(100, 27);
            this.BTreset.TabIndex = 1;
            this.BTreset.Text = "reset";
            this.BTreset.UseVisualStyleBackColor = true;
            this.BTreset.Click += new System.EventHandler(this.BTreset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 141);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 200);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // TBusername
            // 
            this.TBusername.Location = new System.Drawing.Point(160, 136);
            this.TBusername.Margin = new System.Windows.Forms.Padding(4);
            this.TBusername.Name = "TBusername";
            this.TBusername.Size = new System.Drawing.Size(513, 22);
            this.TBusername.TabIndex = 4;
            // 
            // TBpassword
            // 
            this.TBpassword.Location = new System.Drawing.Point(160, 196);
            this.TBpassword.Margin = new System.Windows.Forms.Padding(4);
            this.TBpassword.Name = "TBpassword";
            this.TBpassword.Size = new System.Drawing.Size(513, 22);
            this.TBpassword.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.LBerrorpassword);
            this.panel1.Controls.Add(this.LBerroruser);
            this.panel1.Controls.Add(this.BTregister);
            this.panel1.Controls.Add(this.TBpassword);
            this.panel1.Controls.Add(this.TBusername);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BTreset);
            this.panel1.Controls.Add(this.BTlogin);
            this.panel1.Location = new System.Drawing.Point(110, 62);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 413);
            this.panel1.TabIndex = 6;
            // 
            // LBerrorpassword
            // 
            this.LBerrorpassword.AutoSize = true;
            this.LBerrorpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBerrorpassword.ForeColor = System.Drawing.Color.Red;
            this.LBerrorpassword.Location = new System.Drawing.Point(681, 201);
            this.LBerrorpassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBerrorpassword.Name = "LBerrorpassword";
            this.LBerrorpassword.Size = new System.Drawing.Size(63, 17);
            this.LBerrorpassword.TabIndex = 8;
            this.LBerrorpassword.Text = "ERROR";
            this.LBerrorpassword.Visible = false;
            // 
            // LBerroruser
            // 
            this.LBerroruser.AutoSize = true;
            this.LBerroruser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LBerroruser.ForeColor = System.Drawing.Color.Red;
            this.LBerroruser.Location = new System.Drawing.Point(681, 140);
            this.LBerroruser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBerroruser.Name = "LBerroruser";
            this.LBerroruser.Size = new System.Drawing.Size(63, 17);
            this.LBerroruser.TabIndex = 7;
            this.LBerroruser.Text = "ERROR";
            this.LBerroruser.Visible = false;
            // 
            // BTregister
            // 
            this.BTregister.Location = new System.Drawing.Point(355, 332);
            this.BTregister.Margin = new System.Windows.Forms.Padding(4);
            this.BTregister.Name = "BTregister";
            this.BTregister.Size = new System.Drawing.Size(136, 30);
            this.BTregister.TabIndex = 6;
            this.BTregister.Text = "register";
            this.BTregister.UseVisualStyleBackColor = true;
            this.BTregister.Click += new System.EventHandler(this.BTregister_Click);
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "loginForm";
            this.Text = "login Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Button BTlogin;
        private System.Windows.Forms.Button BTreset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBusername;
        private System.Windows.Forms.TextBox TBpassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTregister;
        private System.Windows.Forms.Label LBerrorpassword;
        private System.Windows.Forms.Label LBerroruser;
    }
}

