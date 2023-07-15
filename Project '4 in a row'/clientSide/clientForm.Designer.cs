
namespace clientSide
{
    partial class clientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(clientForm));
            this.LBallUsers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LBroomList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LBusersInRoom = new System.Windows.Forms.ListBox();
            this.TBnewRoomName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BTcreatRoom = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTjoinRoom = new System.Windows.Forms.Button();
            this.BTstartGame = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.RTBglobalChat = new System.Windows.Forms.RichTextBox();
            this.RTBroomChat = new System.Windows.Forms.RichTextBox();
            this.TBtextFoeGlobalChat = new System.Windows.Forms.TextBox();
            this.BTsendToGlobalChat = new System.Windows.Forms.Button();
            this.BTsendToRoomChat = new System.Windows.Forms.Button();
            this.TBtextForRoomChat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PANgame = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBallUsers
            // 
            this.LBallUsers.FormattingEnabled = true;
            this.LBallUsers.ItemHeight = 16;
            this.LBallUsers.Location = new System.Drawing.Point(201, 28);
            this.LBallUsers.Margin = new System.Windows.Forms.Padding(4);
            this.LBallUsers.Name = "LBallUsers";
            this.LBallUsers.Size = new System.Drawing.Size(152, 596);
            this.LBallUsers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(196, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "all login users";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(7, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "room list";
            // 
            // LBroomList
            // 
            this.LBroomList.FormattingEnabled = true;
            this.LBroomList.ItemHeight = 16;
            this.LBroomList.Location = new System.Drawing.Point(12, 30);
            this.LBroomList.Margin = new System.Windows.Forms.Padding(4);
            this.LBroomList.Name = "LBroomList";
            this.LBroomList.Size = new System.Drawing.Size(152, 212);
            this.LBroomList.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(7, 332);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "room users";
            // 
            // LBusersInRoom
            // 
            this.LBusersInRoom.FormattingEnabled = true;
            this.LBusersInRoom.ItemHeight = 16;
            this.LBusersInRoom.Location = new System.Drawing.Point(12, 363);
            this.LBusersInRoom.Margin = new System.Windows.Forms.Padding(4);
            this.LBusersInRoom.Name = "LBusersInRoom";
            this.LBusersInRoom.Size = new System.Drawing.Size(152, 212);
            this.LBusersInRoom.TabIndex = 4;
            // 
            // TBnewRoomName
            // 
            this.TBnewRoomName.Location = new System.Drawing.Point(12, 268);
            this.TBnewRoomName.Margin = new System.Windows.Forms.Padding(4);
            this.TBnewRoomName.Name = "TBnewRoomName";
            this.TBnewRoomName.Size = new System.Drawing.Size(152, 22);
            this.TBnewRoomName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(12, 240);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "new room name";
            // 
            // BTcreatRoom
            // 
            this.BTcreatRoom.Image = ((System.Drawing.Image)(resources.GetObject("BTcreatRoom.Image")));
            this.BTcreatRoom.Location = new System.Drawing.Point(38, 298);
            this.BTcreatRoom.Margin = new System.Windows.Forms.Padding(4);
            this.BTcreatRoom.Name = "BTcreatRoom";
            this.BTcreatRoom.Size = new System.Drawing.Size(40, 37);
            this.BTcreatRoom.TabIndex = 8;
            this.BTcreatRoom.UseVisualStyleBackColor = true;
            this.BTcreatRoom.Click += new System.EventHandler(this.BTcreatRoom_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.BTjoinRoom);
            this.panel1.Controls.Add(this.BTstartGame);
            this.panel1.Controls.Add(this.BTcreatRoom);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TBnewRoomName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.LBusersInRoom);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.LBroomList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LBallUsers);
            this.panel1.Location = new System.Drawing.Point(695, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 636);
            this.panel1.TabIndex = 9;
            // 
            // BTjoinRoom
            // 
            this.BTjoinRoom.Image = ((System.Drawing.Image)(resources.GetObject("BTjoinRoom.Image")));
            this.BTjoinRoom.Location = new System.Drawing.Point(86, 298);
            this.BTjoinRoom.Margin = new System.Windows.Forms.Padding(4);
            this.BTjoinRoom.Name = "BTjoinRoom";
            this.BTjoinRoom.Size = new System.Drawing.Size(40, 37);
            this.BTjoinRoom.TabIndex = 11;
            this.BTjoinRoom.UseVisualStyleBackColor = true;
            this.BTjoinRoom.Click += new System.EventHandler(this.BTjoinRoom_Click);
            // 
            // BTstartGame
            // 
            this.BTstartGame.Location = new System.Drawing.Point(12, 583);
            this.BTstartGame.Margin = new System.Windows.Forms.Padding(4);
            this.BTstartGame.Name = "BTstartGame";
            this.BTstartGame.Size = new System.Drawing.Size(153, 39);
            this.BTstartGame.TabIndex = 9;
            this.BTstartGame.Text = "start game";
            this.BTstartGame.UseVisualStyleBackColor = true;
            this.BTstartGame.Visible = false;
            this.BTstartGame.Click += new System.EventHandler(this.BTstartGame_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(24, 4);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "global chat";
            // 
            // RTBglobalChat
            // 
            this.RTBglobalChat.Location = new System.Drawing.Point(29, 27);
            this.RTBglobalChat.Margin = new System.Windows.Forms.Padding(4);
            this.RTBglobalChat.Name = "RTBglobalChat";
            this.RTBglobalChat.Size = new System.Drawing.Size(628, 224);
            this.RTBglobalChat.TabIndex = 11;
            this.RTBglobalChat.Text = "";
            // 
            // RTBroomChat
            // 
            this.RTBroomChat.Location = new System.Drawing.Point(23, 352);
            this.RTBroomChat.Margin = new System.Windows.Forms.Padding(4);
            this.RTBroomChat.Name = "RTBroomChat";
            this.RTBroomChat.Size = new System.Drawing.Size(628, 244);
            this.RTBroomChat.TabIndex = 12;
            this.RTBroomChat.Text = "";
            // 
            // TBtextFoeGlobalChat
            // 
            this.TBtextFoeGlobalChat.Location = new System.Drawing.Point(29, 267);
            this.TBtextFoeGlobalChat.Margin = new System.Windows.Forms.Padding(4);
            this.TBtextFoeGlobalChat.Name = "TBtextFoeGlobalChat";
            this.TBtextFoeGlobalChat.Size = new System.Drawing.Size(503, 22);
            this.TBtextFoeGlobalChat.TabIndex = 9;
            // 
            // BTsendToGlobalChat
            // 
            this.BTsendToGlobalChat.Location = new System.Drawing.Point(555, 266);
            this.BTsendToGlobalChat.Margin = new System.Windows.Forms.Padding(4);
            this.BTsendToGlobalChat.Name = "BTsendToGlobalChat";
            this.BTsendToGlobalChat.Size = new System.Drawing.Size(104, 25);
            this.BTsendToGlobalChat.TabIndex = 9;
            this.BTsendToGlobalChat.Text = "send";
            this.BTsendToGlobalChat.UseVisualStyleBackColor = true;
            this.BTsendToGlobalChat.Click += new System.EventHandler(this.BTsendToGlobalChat_Click);
            // 
            // BTsendToRoomChat
            // 
            this.BTsendToRoomChat.Location = new System.Drawing.Point(548, 599);
            this.BTsendToRoomChat.Margin = new System.Windows.Forms.Padding(4);
            this.BTsendToRoomChat.Name = "BTsendToRoomChat";
            this.BTsendToRoomChat.Size = new System.Drawing.Size(104, 25);
            this.BTsendToRoomChat.TabIndex = 13;
            this.BTsendToRoomChat.Text = "send";
            this.BTsendToRoomChat.UseVisualStyleBackColor = true;
            this.BTsendToRoomChat.Click += new System.EventHandler(this.BTsendToRoomChat_Click);
            // 
            // TBtextForRoomChat
            // 
            this.TBtextForRoomChat.Location = new System.Drawing.Point(29, 601);
            this.TBtextForRoomChat.Margin = new System.Windows.Forms.Padding(4);
            this.TBtextForRoomChat.Name = "TBtextForRoomChat";
            this.TBtextForRoomChat.Size = new System.Drawing.Size(503, 22);
            this.TBtextForRoomChat.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(24, 328);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "room chat";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.PANgame);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.BTsendToRoomChat);
            this.panel2.Controls.Add(this.TBtextForRoomChat);
            this.panel2.Controls.Add(this.BTsendToGlobalChat);
            this.panel2.Controls.Add(this.TBtextFoeGlobalChat);
            this.panel2.Controls.Add(this.RTBroomChat);
            this.panel2.Controls.Add(this.RTBglobalChat);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(8, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(679, 635);
            this.panel2.TabIndex = 16;
            // 
            // PANgame
            // 
            this.PANgame.Location = new System.Drawing.Point(13, 7);
            this.PANgame.Name = "PANgame";
            this.PANgame.Size = new System.Drawing.Size(646, 327);
            this.PANgame.TabIndex = 16;
            // 
            // clientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 636);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "clientForm";
            this.Text = "client Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LBallUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox LBroomList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox LBusersInRoom;
        private System.Windows.Forms.TextBox TBnewRoomName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BTcreatRoom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox RTBglobalChat;
        private System.Windows.Forms.RichTextBox RTBroomChat;
        private System.Windows.Forms.TextBox TBtextFoeGlobalChat;
        private System.Windows.Forms.Button BTsendToGlobalChat;
        private System.Windows.Forms.Button BTsendToRoomChat;
        private System.Windows.Forms.TextBox TBtextForRoomChat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BTstartGame;
        private System.Windows.Forms.Button BTjoinRoom;
        private System.Windows.Forms.Panel PANgame;
    }
}

