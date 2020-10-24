﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cowsNbulls_client
{
    public partial class menu : Form
    {
        GameLogic g { get; set; }
        public menu(GameLogic g)
        {
            this.g = g;
            InitializeComponent();
            playersNumeric.Maximum = 4;
            playersNumeric.Minimum = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            g.NumOfPlayers = Convert.ToInt32(playersNumeric.Value);
            g.Comp = compCheck.Checked;
            int compInt;
            if (g.Comp)
            {
                compInt = 1;
            }
            else
            {
                compInt = 0;
            }    
            System.Diagnostics.Process.Start("cowsNbulls_server.exe", Convert.ToString(g.NumOfPlayers) + " " + Convert.ToString(compInt));
            ipBox.Text = "127.0.0.1";
            joinButton_Click(sender, e);
        }

        private void joinButton_Click(object sender, EventArgs e)
        {/*ДОБАВИТЬ ПРОВЕРКИ*/
            string ip = ipBox.Text;
            if (ip == "")
            {
                MessageBox.Show("IP is empty!");
                return;
            }
            g.Name = nameBox.Text;
            g.Connect(ip);
            Close();
            //game gameForm = new game(g);
            //gameForm.Show();
        }
    }
}
