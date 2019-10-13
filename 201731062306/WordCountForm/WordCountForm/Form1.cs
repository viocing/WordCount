using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordCount;
using WordFormUtil;

namespace WordCountForm
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (this.richTextBox1.Text != null)
            {
                string h = Computer.WordGroup(this.richTextBox1.Text, int.Parse(this.group.Text));
                if (h != null)
                {
                    this.output.Text = "";
                    this.output.Text = h;
                }
            }
            else
            {
                ;
            }
            if (this.input.Text != null)
            {
                string res = Computer.WordGroup(this.input.Text, int.Parse(this.group.Text));
                if (res != null)
                {
                    this.output.Text = "";
                    this.output.Text = res;
                }
            }
            else
            {
                ;
            }
           
  
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string res = Computer.WordCount(this.input.Text, int.Parse(this.words.Text), this.input.Lines.Length);
            this.output.Text = res;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog xjOpenFileDialog = new OpenFileDialog();
            xjOpenFileDialog.Filter = "文本文件|*.txt";
            if (xjOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string xjFilePath = xjOpenFileDialog.FileName;
                this.textBox1.Text = xjFilePath;//显示文件路径       
                StreamReader sr = new StreamReader(xjFilePath, Encoding.Default);
                this.richTextBox1.Text = sr.ReadToEnd();//显示内容 
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string lujing = this.textBox4.Text;
            System.IO.StreamWriter swobj = System.IO.File.AppendText(lujing);
            swobj.WriteLine(this.output.Text);
            swobj.Flush();
            swobj.Close();
        }
    }
}
