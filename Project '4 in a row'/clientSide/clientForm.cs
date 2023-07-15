using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientSide
{ 
    public partial class clientForm : Form
    {
        Thread waitToreciveFromServer;
        Socket _clientSocket;
        string _userName;
        string _roomName;
        Button[] _BTDropCoin;
        Graphics G;
        int col;
        int val;
        bool TOR;
        public clientForm(Socket x, string userName)
        {
            InitializeComponent();
            _clientSocket = x;
            TOR = false;
            val = 2;
            _userName = userName;
            _roomName = "";
            _BTDropCoin = new Button[7];
            PANgame.Visible = false;
            G = PANgame.CreateGraphics();
            waitToreciveFromServer = new Thread(ReceiveThread);
            waitToreciveFromServer.Start();
            SendInfrmaionToServer("user;new"); 
            
        }
        private void ReceiveThread()
        {
            byte[] reciveBuffer = new byte[1024];
            string message = "";
            bool ownerExist = false;
            while (_clientSocket.Connected)
            {
                int rec = _clientSocket.Receive(reciveBuffer);
                byte[] temp = new byte[rec];
                Array.Copy(reciveBuffer, temp, rec);
                string returnFormServer = Encoding.Unicode.GetString(temp);
                string[] messageInfo = returnFormServer.Split(';');
                message += returnFormServer;//ממשיך לקבל הוגעות מהשרת עד שמקבל  סוף הודעה
                if (messageInfo[0].Equals("GAME"))
                {
                    if(messageInfo[1].Equals("intru"))
                    {
                        string gameRoomName = messageInfo[2];
                        startGameForm(_clientSocket, gameRoomName,_userName);
                    }
                    if (messageInfo[1].Equals("step"))
                    {
                        int col = int.Parse(messageInfo[2].ToString());
                        int row = int.Parse(messageInfo[3].ToString());
                        int win = int.Parse(messageInfo[4].ToString());
                        drawGameStep(col,row,win);
                    }
                }
                if (messageInfo[0].Equals("room"))
                {
                    if (messageInfo[1].Equals("exist"))
                    {
                        MessageBox.Show("room with this name allready exist");
                    }
                    if (messageInfo[1].Equals("new"))
                    {
                        for (int i = 2; i < messageInfo.Length; i+=2)
                            addToListBox(LBroomList, messageInfo[i], messageInfo[i + 1]);
                    }
                    if (messageInfo[1].Equals("one"))
                    {
                        addToListBox(LBroomList, messageInfo[2],messageInfo[3]);
                    }
                }
                if (messageInfo[0].Equals("user"))
                {
                    if (messageInfo[1].Equals("new"))
                    {
                        int roomIndex = findRoomIndex(messageInfo);
                        for (int i = 2; i < roomIndex; i+=2)
                            addToListBox(LBallUsers, messageInfo[i], messageInfo[i + 1]);
                        for(int i=roomIndex+1;i<messageInfo.Length;i+=2)
                            addToListBox(LBroomList, messageInfo[i], messageInfo[i + 1]);
                    }
                    if (messageInfo[1].Equals("add"))
                    {
                        addToListBox(LBallUsers, messageInfo[2],messageInfo[3]);
                    }
                    if (messageInfo[1].Equals("join"))
                    {
                        if (messageInfo[2].Equals("add"))
                        {
                            if (_userName == messageInfo[5] && ownerNotInList(messageInfo[5]))
                            {
                                _roomName = messageInfo[6];
                                visibleStartGameButton();
                                if (!ownerExist)
                                {
                                    addToListBox(LBusersInRoom, messageInfo[5], messageInfo[4]);
                                    ownerExist = true;
                                }
                            }
                            addToListBox(LBusersInRoom, messageInfo[3], messageInfo[4]);
                        }
                        if (messageInfo[2].Equals("new"))
                        {
                            for (int i = 3; i < messageInfo.Length; i += 2)
                                addToListBox(LBusersInRoom, messageInfo[i], messageInfo[i + 1]);
                        }
                    }
                }
                if (messageInfo[0].Equals("chat"))
                {
                    string userName = messageInfo[2];
                    message = messageInfo[3];
                    if (messageInfo[1].Equals("global"))
                    {
                        addToRichTextBox(RTBglobalChat, userName, message);
                    }
                    if (messageInfo[1].Equals("room"))
                    {
                        addToRichTextBox(RTBroomChat, userName,message);
                    }
                }
            }
        }

        private void drawGameStep(int col,int row,int win)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate { drawGameStep(col,row,win); }));
                return;
            }
            if (row != -1)
            {
                drowCoin(col, row);

                if (this.TOR && win == 1)
                {
                    MessageBox.Show("you have win this game");
                    SendInfrmaionToServer("GAME;intru;" + _roomName);
                    this.TOR = true;
                }
                    if (!this.TOR && win == 1)
                    MessageBox.Show("you have loss this game");
                this.TOR = !this.TOR;
                
            }
            if (this.TOR && row == -1)
                MessageBox.Show("you have selected a full column, please select ather column");

        }

        private int findRoomIndex(string[] messageInfo)
        {
            int index = 0;
            bool flag = false;
            while (!flag)
            {
                if (messageInfo[index].Equals("room"))
                    flag = true;
                else
                    index++;
            }
            return index;
        }

        private void startGameForm(Socket clientSocket, string gameRoomName,string userName)
        {
            if (InvokeRequired)//אם יש קראיה מפונקצה חיצונית אז 
            {
                Invoke(new MethodInvoker(delegate { startGameForm(clientSocket, gameRoomName,userName); }));//מבצע קריאה נוספת אל לא מבחוץ
                return;
            }
            PANgame.Visible = true;
            if (this.TOR)
                val = 1;
            else
                val = 2;
            drawGameBord(gameRoomName);
        }

        private void drawGameBord(string gameRoomName)
        {

            int BTX = 100;
            int BTY = 1;
            for (int i = 0; i < _BTDropCoin.Length; i++)
            {
                _BTDropCoin[i] = new Button();
                PANgame.Controls.Add(_BTDropCoin[i]);
                _BTDropCoin[i].Size = new Size(40, 15);
                _BTDropCoin[i].Location = new Point(BTX, 5);
                _BTDropCoin[i].Image = Image.FromFile(@"pic\down.png");
                _BTDropCoin[i].Name = "bt" + i;
                _BTDropCoin[i].Tag = i.ToString();
                _BTDropCoin[i].Click += ClientForm_Click;
                BTX += 41;
            }
            int x = 100;
            int y = 20;
            for (int i = 0;i<6;i++)
            {
                for (int j=0;j<7;j++)
                {
                    SolidBrush br = new SolidBrush(Color.Blue);
                    G.FillRectangle(br, x, y, 40, 40);
                    br = new SolidBrush(Color.White);
                    G.FillEllipse(br, x+5, y+5, 30, 30);
                    x = x + 41;

                }
                x = 100;
                y = y + 41;
            }
        }

        private void ClientForm_Click(object sender, EventArgs e)
        {
            if (this.TOR)
            {
                Button clickButton = (Button)sender;
                col = int.Parse(clickButton.Tag.ToString());
                string st = "GAME;step;" + _roomName + ";" + col + ";" + val;
                SendInfrmaionToServer(st);
            }
        }

        private void drowCoin(int col, int row)
        {
            int x = col * 41 + 100;
            int y = row * 41 + 20;
            SolidBrush br;
            if (this.TOR)
                br = new SolidBrush(Color.Red);
            else
                br = new SolidBrush(Color.Yellow);

            G.FillEllipse(br, x+5, y+5, 30, 30);
        }

        private bool ownerNotInList(string v)
        {
            bool userExsit = false;
            int index = 0;
            while (!userExsit && index<LBusersInRoom.Items.Count)
            {
                userExsit = LBusersInRoom.Items[index].ToString() == v;
                index++;
            }
            return !userExsit;
        }
        private void visibleStartGameButton()
        {
            if (InvokeRequired)//אם יש קראיה מפונקצה חיצונית אז 
            {
                Invoke(new MethodInvoker(delegate { visibleStartGameButton(); }));//מבצע קריאה נוספת אל לא מבחוץ
                return;
            }
            BTstartGame.Visible = true;
        }
        private void addToListBox(ListBox listbox, string info1, string info2)
        {
            if (InvokeRequired)//אם יש קראיה מפונקצה חיצונית אז 
            {
                Invoke(new MethodInvoker(delegate { addToListBox(listbox,info1,info2); }));//מבצע קריאה נוספת אל לא מבחוץ
                return;
            }
            listbox.ForeColor = Color.Blue;
            listbox.Items.Add(info1+"---->"+info2);
        }
        private void addToRichTextBox(RichTextBox RTB, string userName, string info)
        {
            if (InvokeRequired)//אם יש קראיה מפונקצה חיצונית אז 
            {
                Invoke(new MethodInvoker(delegate { addToRichTextBox(RTB, userName, info); }));//מבצע קריאה נוספת אל לא מבחוץ
                return;
            }
            RTB.AppendText(userName + "--->" + info+"\n");
        }
        private void SendInfrmaionToServer(string userInfo)
        {
            if (_clientSocket.Connected)
            {
                // 1. convert the form informatino to byte array
                byte[] userData = Encoding.Unicode.GetBytes(userInfo);
                // 2. send data to the server as byte array
                _clientSocket.Send(userData);
            }
        }
        private void BTcreatRoom_Click(object sender, EventArgs e)
        {
            if (TBnewRoomName.Text != "")
            {
                SendInfrmaionToServer("room;creat;" + TBnewRoomName.Text + ";" + _userName);
                TBnewRoomName.Text = "";
            }
        }
        private void BTsendToGlobalChat_Click(object sender, EventArgs e)
        {
            SendInfrmaionToServer("chat;global;" + _userName +";"+ TBtextFoeGlobalChat.Text) ;
            TBtextFoeGlobalChat.Text = "";
        }
        private void BTsendToRoomChat_Click(object sender, EventArgs e)
        {
            SendInfrmaionToServer("chat;room;" + _userName + ";"+_roomName+";" + TBtextForRoomChat.Text);
            TBtextForRoomChat.Text = "";
        }
        private void BTgetRooms_Click(object sender, EventArgs e)
        {
            SendInfrmaionToServer("room;new");
           
        }
        private void BTjoinRoom_Click(object sender, EventArgs e)
        {
            if (_roomName == "")
            {
                if (LBroomList.SelectedIndex == -1)
                    MessageBox.Show("you mast select one of rooms in the list");
                else
                {
                    _roomName = LBroomList.SelectedItem.ToString();
                    string[] getroom = _roomName.Split('-');
                    _roomName = getroom[0];
                    string roomIndex = LBroomList.SelectedIndex.ToString();
                    SendInfrmaionToServer("room;join;" + _userName + ";" + roomIndex);

                }
            }
            else
            {
                MessageBox.Show("you can join only to one room");
            }
        }
        private void BTstartGame_Click(object sender, EventArgs e)
        {
            SendInfrmaionToServer("GAME;intru;" + _roomName);
            this.TOR = true;
        }
    }
}