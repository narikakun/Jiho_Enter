using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jiho_Enter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public bool Flag = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            if (checkBox1.Checked)
            {
                dt = dt.AddMilliseconds(Convert.ToInt32(textBox1.Text));
            } else
            {
                dt = dt.AddMilliseconds(-Convert.ToInt32(textBox1.Text));
            }
            Console.WriteLine(dt.Second);
            if (Flag == true && dt.Minute == Convert.ToInt32(textBox2.Text) && dt.Second == Convert.ToInt32(textBox3.Text))
            {
                Flag = false;
                SendKeys.Send("{Enter}");
            }
            else if (dt.Second != 00) Flag = true;
            label1.Text = String.Format("{0:yyyy年MM月dd日(ddd) HH時mm分ss秒fff}", dt);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 制御文字は入力可
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // 数字(0-9)は入力可
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // 小数点は１つだけ入力可
            if (e.KeyChar == '.')
            {
                TextBox target = sender as TextBox;
                if (target.Text.IndexOf('.') < 0)
                {
                    // 複数のピリオド入力はNG
                    e.Handled = false;
                    return;
                }
            }

            // 上記以外は入力不可
            e.Handled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "プラス";
            } else
            {
                checkBox1.Text = "マイナス";
            }
        }
    }
}
