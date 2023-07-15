using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class room
    {
        public string roomName { get; set; }
        public string roomOwner { get; set; }
        public List<loginUser> roomUsers { get; set; }
        public int[,] gameBord { get; set; }

        public room(string roomName,string roomOwner)
        {
            this.roomName = roomName;
            this.roomOwner = roomOwner;
            this.roomUsers = new List<loginUser>();
            this.gameBord = new int[6, 7];
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 6; j++)
                    gameBord[j, i] = 0;
        }
        public void addUserToRoom(string userName,Socket socket)
        {
            loginUser user = new loginUser(userName, socket);
            this.roomUsers.Add(user);
        }
        public void removeUserFromRoom(string userName)
        {
            bool flag = false;
            int index = 0;
            while (!flag && index < this.roomUsers.Count)
            {
                if (roomUsers[index].userName.Equals(userName))
                    flag = true;
                else
                    index++;
            }
            if (flag)
                roomUsers.Remove(roomUsers[index]);
        }
        public void clearRoomBordGame()
        {
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 6; j++)
                    this.gameBord[j, i] = 0;

        }
        public int getRow (int col, int val)
        {
            int row = 0;
            bool flag = false;
            if (this.gameBord[0, col] == val)
            {
                row = -1;
            }
            else
            {
                while (!flag && row <=5)
                {
                    if (this.gameBord[row, col] == 0)
                        row++;
                    else
                        flag = true;
                }
                row--;
                this.gameBord[row , col] = val;
            }
            return row;
        }
        public int valInRow(int row, int val)
        {
            int counter = 0;
            int col = 0;
            while(col<7  && counter !=4)
            { 
                if (this.gameBord[row, col] != val )
                    counter=0;
                if (this.gameBord[row, col] == val)
                    counter++;
                col++;
            }
          
            return counter;
        }
        public int valInCol(int col, int val)
        {
            int counter = 0;
            int row = 0;
            while (row < 6  && counter != 4)
            {
          
                if (this.gameBord[row, col] != val)
                    counter = 0;

                if (this.gameBord[row, col] == val)
                    counter++;
                row++;
            }
            
       
            return counter;
        }
        public int valInMainSlant(int col, int row, int val)
        {
            int count = 0;
            int c = col;
            int r = row;
            while (col >= 0 && row >= 0 && row < this.gameBord.GetLength(0) && col < this.gameBord.GetLength(1) && this.gameBord[row, col] == val)
            {
                count++;
                col++;
                row++;
            }
            col = c - 1;
            row = r - 1;
            while (col >= 0 && row >= 0 && row < this.gameBord.GetLength(0) && col < this.gameBord.GetLength(1) && this.gameBord[row, col] == val)
            {
                count++;
                col--;
                row--;
            }
            return count;

        }
        public int valInSecondSlant(int col, int row, int val)
        {
            int count=0;
            int c = col;
            int r = row;
            while (col >= 0 && row >= 0 && row < this.gameBord.GetLength(0) && col < this.gameBord.GetLength(1) && this.gameBord[row, col] == val)
            {
                count++;
                col++;
                row--;
            }
            col = c - 1;
            row = r + 1;
            while (col >= 0 && row >= 0 && row < this.gameBord.GetLength(0) && col < this.gameBord.GetLength(1) && this.gameBord[row, col] == val)
            {
                count++;
                col--;
                row++;
            }
            return  count;
            
        }
        public bool checkColRow(int row, int col, int val)
        {
            bool checkCol =  valInCol(col, val) == 4;
            bool checkRow =  valInRow(row, val) == 4;
            bool checkMainSlant = valInMainSlant(col,row,val) == 4; 
            bool checkSecondSlant = valInSecondSlant(col,row,val) == 4;
          
            return(checkCol || checkRow || checkMainSlant || checkSecondSlant);
        }
    }
}
