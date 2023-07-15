using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class serverForm : Form
    {
        private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static List<loginUser> ClientLoginUsers = new List<loginUser>();
        private static List<room> gameRoomList = new List<room>();
        private static List<user> userList = new List<user>();
        private static byte[] Buffer = new byte[1024];
        XmlSerializer xm; //תקן לקידוד וייצוג נתונים במחשבים.

        public serverForm()
        {
            InitializeComponent();
            StartServer();
            xm = new XmlSerializer(typeof(List<user>));
        }
        private void StartServer()
        {
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 50000));
            serverSocket.Listen(2);
            serverSocket.BeginAccept(new AsyncCallback(waitForNewConnection), serverSocket);
        }
        private void waitForNewConnection(IAsyncResult AR)
        {
            Socket socket = serverSocket.EndAccept(AR);
            socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(RecieveInformation), socket);
            serverSocket.BeginAccept(new AsyncCallback(waitForNewConnection), serverSocket);
        }
        private void RecieveInformation(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int recieve = socket.EndReceive(AR);
            byte[] dataBuff = new byte[recieve];
            Array.Copy(Buffer, dataBuff, recieve);
            string text = Encoding.Unicode.GetString(dataBuff);
            string[] ClientInformation = text.Split(';');

            returnInformationToClient(socket, ClientInformation);
        }
        private void returnInformationToClient(Socket socket, string[] ClientInformation)
        {
            string result = string.Empty;
            byte[] data;
            if(ClientInformation[0].Equals("GAME"))
            {
                if(ClientInformation[1].Equals("intru"))
                {
                    string roomName = ClientInformation[2].ToString();
                    room gameRoom = FindRoomByName(roomName);
                    List<loginUser> roomUsers = gameRoom.roomUsers;
                    gameRoom.clearRoomBordGame();
                   
                    result = "GAME;intru;" + ClientInformation[2];
                    data = Encoding.Unicode.GetBytes(result);
                    for (int i=0;i<roomUsers.Count;i++)
                    {
                        if(socket != roomUsers[i].socket)
                           roomUsers[i].socket.Send(data);
                    }
                }
                if (ClientInformation[1].Equals("step"))
                {
                    string roomName = ClientInformation[2].ToString();
                    int col = int.Parse(ClientInformation[3].ToString());
                    int val = int.Parse(ClientInformation[4].ToString());
                    room selctedRoom = FindRoomByName(roomName);
                    List<loginUser> roomUsers = selctedRoom.roomUsers;
                    int row = selctedRoom.getRow(col,val);
                    bool checkWin = selctedRoom.checkColRow(row, col,val);
                    int win = 0;
                    if (checkWin)
                        win = 1;
                    result = "GAME;step;" + col+";"+row+";"+win;
                   
                    data = Encoding.Unicode.GetBytes(result);
                    for (int i = 0; i < roomUsers.Count; i++)
                    {
                        if (socket != roomUsers[i].socket)
                            roomUsers[i].socket.Send(data);
                    }

                }
            }
            // the server get the command registraion
            if (ClientInformation[0].Equals("registraion")) 
            {
                result = addUserToXmlFile(ClientInformation);
            }
            // the server get the command login
            if (ClientInformation[0].Equals("login")) 
            {
                result = checkLoginUser(ClientInformation);
                if(result.Equals("login;ok"))
                    ClientLoginUsers.Add(new loginUser(ClientInformation[1],socket));
            }
            if (ClientInformation[0].Equals("user"))
            {
                if (ClientInformation[1].Equals("new"))
                {
                    string lastUser = ClientLoginUsers[ClientLoginUsers.Count - 1].userName;
                    result = "user;add;" + lastUser+";0";
                    byte[] temp = Encoding.Unicode.GetBytes(result);
                    for (int i = 0; i < ClientLoginUsers.Count; i++)
                    {
                        if (ClientLoginUsers[i].socket != socket)
                            ClientLoginUsers[i].socket.Send(temp);
                    }

                    result = "user;new";
                    for (int i=0;i<ClientLoginUsers.Count;i++)
                    {
                        result += ";" + ClientLoginUsers[i].userName + ";0";
                    }
                    result = result + ";room";
                    for (int i = 0; i < gameRoomList.Count; i++)
                    {
                        result += ";" + gameRoomList[i].roomName + ";" + gameRoomList[i].roomOwner;
                    }


                }
            }
            if (ClientInformation[0].Equals("room"))
            {
                if (ClientInformation[1].Equals("new"))
                {
                    result = "room;new";
                    for (int i = 0; i < gameRoomList.Count; i++)
                    {
                        result += ";" + gameRoomList[i].roomName + ";" + gameRoomList[i].roomOwner;
                    }
                }
                if (ClientInformation[1].Equals("creat"))
                {
                    string roomName = ClientInformation[2];
                    string roomOwner = ClientInformation[3]; 
                    int index = 0;
                    bool roomExist = false;
                    while (!roomExist && index < gameRoomList.Count)
                    {
                        if (gameRoomList[index].roomName.Equals(roomName))
                            roomExist = true;
                        index++;
                    }
                    if (roomExist)
                    {
                        result = "room;exist";
                    }
                    else
                    {
                        room newRoom = new room(roomName, roomOwner);
                        newRoom.addUserToRoom(roomOwner, socket);
                        gameRoomList.Add(newRoom);

                        result = "room;one;" + roomName + ";" + roomOwner;
                        byte[] temp = Encoding.Unicode.GetBytes(result);
                        for (int i = 0; i < ClientLoginUsers.Count; i++)
                        {
                            if (ClientLoginUsers[i].socket != socket)
                                ClientLoginUsers[i].socket.Send(temp);
                        }
                    }
                   
                }
                if(ClientInformation[1].Equals("join"))
                {
                    string userName = ClientInformation[2];
                    int roomIndex = int.Parse(ClientInformation[3]);
                    if (userName != gameRoomList[roomIndex].roomOwner)
                       gameRoomList[roomIndex].addUserToRoom(userName, socket);
                    // add the new user to all users are allready in the room
                    string roomOwner = gameRoomList[roomIndex].roomOwner;
                    string roomName = gameRoomList[roomIndex].roomName;
                    result = "user;join;add;" + userName + ";0;"+roomOwner+";"+ roomName;
                    byte[] temp = Encoding.Unicode.GetBytes(result);
                    for (int i = 0; i < gameRoomList[roomIndex].roomUsers.Count; i++)
                    {
                        if (gameRoomList[roomIndex].roomUsers[i].socket != socket)
                            gameRoomList[roomIndex].roomUsers[i].socket.Send(temp);
                    }
                    // add the all the room users to the new user how join the room
                    result = "user;join;new";
                    for (int i = 0; i < gameRoomList[roomIndex].roomUsers.Count; i++)
                    {
                        result += ";" + gameRoomList[roomIndex].roomUsers[i].userName + ";0";
                    }
                }
            }
            if (ClientInformation[0].Equals("chat"))
            {
                if (ClientInformation[1].Equals("global"))
                {
                   // string lastUser = ClientLoginUsers[ClientLoginUsers.Count - 1].userName;
                    result = "chat;global;" + ClientInformation[2]+";"+ ClientInformation[3];
                    byte[] temp = Encoding.Unicode.GetBytes(result);
                    for (int i = 0; i < ClientLoginUsers.Count; i++)
                    {
                        if(ClientLoginUsers[i].socket != socket)
                          ClientLoginUsers[i].socket.Send(temp);
                    }
                }
                if (ClientInformation[1].Equals("room"))
                {
                    string userName = ClientInformation[2];
                    string roomName = ClientInformation[3];
                    string message = ClientInformation[4];
                    room roomMessage = FindRoomByName(roomName);
                    result = "chat;room;"+userName+";"+message;
                    byte[] temp = Encoding.Unicode.GetBytes(result);
                    for (int i=0;i<roomMessage.roomUsers.Count;i++)
                    {
                        if (roomMessage.roomUsers[i].socket != socket)
                            roomMessage.roomUsers[i].socket.Send(temp);
                    }
                }
            }
            
            data = Encoding.Unicode.GetBytes(result);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(EndRecieveInformation), socket);
            socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(RecieveInformation), socket);
        }

        private room FindRoomByName(string roomName)
        {
            bool foundTheRoom = false;
            int index = 0;
            while (!foundTheRoom && index<gameRoomList.Count)
            {
                if (gameRoomList[index].roomName == roomName)
                {
                    foundTheRoom = true;
                }
                else
                    index++;
            }
            return gameRoomList[index];
        }
        private string checkLoginUser(string[] clientInformation)
        {
            string result = "";
            ReaduserListFromXmlFile();
            bool flag = false;
            int index = 0;
            while (index<userList.Count && ! flag)
            {
                if ((userList[index]._password.Equals(clientInformation[2])) &&
                    (userList[index]._userName.Equals(clientInformation[1])))
                    flag = true;
                index++;
            }
            if (flag)
                result = "login;ok";
            else
                result = "login;not exist";
            return result;

        }
        private string addUserToXmlFile(string[] clientInformation)
        {
            FileStream fs;
            string result = "";
            try
            {
                ReaduserListFromXmlFile();
            }
            catch (Exception)
            {
                MessageBox.Show("קובץ  משתמשים לא קיים בונה קובץ חדש");
            }

            fs = new FileStream(@"data/users.xml", FileMode.Create, FileAccess.Write);
            user info = new user(clientInformation[1],
                                 clientInformation[2],
                                 clientInformation[3],
                                 clientInformation[4],
                                 clientInformation[5]);
            bool flag = true;
            int index = 0;
            while(index<userList.Count && flag)
            {
                if (userList[index]._userName.Equals(clientInformation[4]))
                    flag = false;
                index++;
            }
            if (flag)
            {
                userList.Add(info);
                xm.Serialize(fs, userList);
                result = "registraion;ok";
            }
            else
            {
                result = "registraion;exist";
            }
            fs.Close();
            return result;
        }
        private void ReaduserListFromXmlFile()
        {
            FileStream fs = new FileStream(@"data/users.xml", FileMode.Open, FileAccess.Read);
            userList = (List<user>)xm.Deserialize(fs);
            fs.Close();
        }
        private static void EndRecieveInformation(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }
    }
}