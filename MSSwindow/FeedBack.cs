using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSwindow
{
    public partial class FeedBack : UserControl
    {
        string _Rating = string.Empty;
        public FeedBack()
        {
            InitializeComponent();
        }

        private void FeedBack_Load(object sender, EventArgs e)
        {
            _Rating = TxtRatingVal.Text;
        }

        private int SetButtonVal(Button btn)
        {
            int BtnLevel = 0;
            string str = btn.Name;
            switch (str)
            {
                case "button1":
                    BtnLevel = 1;
                    break;
                case "button2":
                    BtnLevel = 2;
                    break;
                case "button3":
                    BtnLevel = 3;
                    break;
                case "button4":
                    BtnLevel = 4;
                    break;
                case "button5":
                    BtnLevel = 5;
                    break;
                default:
                    BtnLevel = 0;
                    break;
            }
            return BtnLevel;

        }
        public int Rating
        {
            
            get
            {
                return Convert.ToInt32(TxtRatingVal.Text == string.Empty?"0": TxtRatingVal.Text);
            }

            set
            {
                TxtRatingVal.Text = value.ToString();

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            TxtRatingVal.Text = SetButtonVal(btn).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            TxtRatingVal.Text = SetButtonVal(btn).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            TxtRatingVal.Text = SetButtonVal(btn).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            TxtRatingVal.Text = SetButtonVal(btn).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            TxtRatingVal.Text = SetButtonVal(btn).ToString();
        }
    }
}
