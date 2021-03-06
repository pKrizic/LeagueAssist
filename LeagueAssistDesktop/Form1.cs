﻿using LeagueAssist;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeagueAssistDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Text = "This is the application for The Football Association where you can manage your league and clubs.\n";
            richTextBox1.Text += "Username: Savez, Password: Savez";
            string solutionFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string resourcesFolderPath = Path.Combine(Directory.GetParent(solutionFolder).Parent.FullName, @"Resources\logo.png");
            pictureBox1.ImageLocation = resourcesFolderPath;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_username.Text) || String.IsNullOrEmpty(txt_password.Text))
            {
                MessageBox.Show("Upišite korisničko ime i lozinku");
                return;
            }

            var clas = new DataProcessor();
            var response = clas.ProccesData(txt_username.Text, txt_password.Text, 1);
            if (response == "")
                MessageBox.Show("Krivo korisničko ime ili lozinka");
            else
            {
                this.Hide();
                MainForm mainF = new MainForm();
                mainF.FormClosed += new FormClosedEventHandler(MainForm_FormClosing);
                mainF.IsMdiContainer = true;
                mainF.Show();
            }

        }
        private void MainForm_FormClosing(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
