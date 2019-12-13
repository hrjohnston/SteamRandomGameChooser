using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Game_Chooser
{
    public partial class Form1 : Form
    {
        List<string> gamelist = new List<string>();
        Random r = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        public void btnBrowse_Click_1(object sender, EventArgs e)
        {
            GetWordList();
            GetNewWord();
        }

        public void GetWordList()
        { 
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Choose a Text File to Load From";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = false;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                tbAddress.Text = fdlg.FileName;
                StreamReader sr = new StreamReader(fdlg.FileName);
                gamelist.Clear();
                // Seed a random number in the range 0 to your count
                var glist = File.ReadAllLines(fdlg.FileName);
                foreach (var s in glist)
                {
                    gamelist.Add(s);
                }
            }
        }

        public void GetNewWord()
        { 
            int count = gamelist.Count;
            int randomNumber = r.Next(0, count);
            string game = gamelist[randomNumber];
            lbGame.Text = game;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            GetNewWord();
        }
    }
}

