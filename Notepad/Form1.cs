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

namespace Notepad
{
    public partial class Form1 : Form
    {
        bool isOpen = false;

        bool isSave = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            isSave = false;
        }

        //文件
        private void New_Click(object sender, EventArgs e)
        {
            if (isOpen == true || richTextBox1.Text.Trim() != "")
            {
                // 若文件未保存
                if (isSave == false)
                {
                    string result;
                    result = MessageBox.Show("文件尚未保存,是否保存?",
                        "保存文件", MessageBoxButtons.YesNoCancel).ToString();
                    switch (result)
                    {
                        case "Yes":
                            // 若文件是从磁盘打开的
                            if (isOpen == true)
                            {
                                // 按文件打开的路径保存文件
                                richTextBox1.SaveFile(openFileDialog1.FileName,RichTextBoxStreamType.PlainText);
                            }
                            // 若文件不是从磁盘打开的
                            else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                            }
                            isSave = true;
                            richTextBox1.Text = "";
                            break;
                        case "No":
                            isOpen = false;
                            richTextBox1.Text = "";
                            break;
                    }
                }
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本|*.txt";
            saveFileDialog1.Filter = "文本|*.txt";
            if (isOpen == true || richTextBox1.Text.Trim() != "")
            {
                if (isSave == false)
                {
                    string result;
                    result = MessageBox.Show("文件尚未保存,是否保存?",
                        "保存文件", MessageBoxButtons.YesNoCancel).ToString();
                    switch (result)
                    {
                        case "Yes":
                            if (isOpen == true)
                            {
                               /* StreamWriter writer = new StreamWriter(openFileDialog1.FileName, false, Encoding.Default);   //FileMode.OpenOrCreate
                                writer.WriteLine(richTextBox1.Text);*/

                                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                            }
                            else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                /*StreamWriter writer = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default);   //FileMode.OpenOrCreate
                                writer.WriteLine(richTextBox1.Text);*/

                                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText); //保存为asci
                            }
                            isSave = true;
                            break;
                        case "No":
                            isOpen = false;
                            richTextBox1.Text = "";
                            break;
                    }
                }
            }
            openFileDialog1.RestoreDirectory = true;
            if ((openFileDialog1.ShowDialog() == DialogResult.OK) && openFileDialog1.FileName != "")
            {
                /*StreamReader reader = new StreamReader(openFileDialog1.FileName, System.Text.Encoding.Default);   //FileMode.Open
                richTextBox1.Text = reader.ReadLine();       */   //读出utf-8   
                richTextBox1.LoadFile(openFileDialog1.FileName,RichTextBoxStreamType.PlainText);  //读出asci
                isOpen = true;
            }
            isSave = true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "文本|*.txt";
            if (isOpen == true && richTextBox1.Modified == true)
            {
                richTextBox1.SaveFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                isSave = true;
            }
            else if (isOpen == false && richTextBox1.Text.Trim() != "" && saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                /*FileStream fl = new FileStream(openFileDialog1.FileName, FileMode.Open);
                StreamWriter writer = new StreamWriter(fl, Encoding.Default );   //FileMode.OpenOrCreate
                writer.WriteLine(richTextBox1.Text);*/
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                isSave = true;
                isOpen = true;
                openFileDialog1.FileName = saveFileDialog1.FileName;
            }
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                isSave = true;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();//程序结束
        }

        //编辑
        private void Undo_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();//撤销
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();//复制
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();//剪切
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();//粘贴
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();//全选
        }

        private void Date_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(System.DateTime.Now.ToString());//显示当前日期
        }

        //格式
        private void Auto_Click(object sender, EventArgs e)
        {
            if (Auto.Checked == false)
            {
                Auto.Checked = true;            // 选中该菜单项
                richTextBox1.WordWrap = true;        // 设置为自动换行
            }
            else
            {
                Auto.Checked = false;
                richTextBox1.WordWrap = false;
            }

        }

        private void Font_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = fontDialog1.Color;
                richTextBox1.SelectionFont = fontDialog1.Font;
            }

        }

        //查看
        private void ToolStrip_Click(object sender, EventArgs e)
        {
            Point point;
            if (ToolStrip.Checked == true)
            {
                // 隐藏工具栏时，把坐标设为（0，24）,因为菜单的高度为24
                point = new Point(0, 24);
                ToolStrip.Checked = false;
                toolStrip1.Visible = false;    //toolStrip1工具栏控件
                // 设置多格式文本框左上角位置
                richTextBox1.Location = point;
                // 隐藏工具栏后，增加文本框高度
                richTextBox1.Height += toolStrip1.Height;
            }
            else
            {
                /* 显示工具栏时，多格式文本框左上角位置的位置为（0，49），
                   因为工具栏的高度为25，加上菜单的高度24后为49 */
                point = new Point(0, 49);
                ToolStrip.Checked = true;
                toolStrip1.Visible = true;
                richTextBox1.Location = point;
                richTextBox1.Height -= toolStrip1.Height;
            }

        }

        private void StatusStrip_Click(object sender, EventArgs e)
        {
            if (StatusStrip.Checked == true)
            {
                StatusStrip.Checked = false;
                statusStrip1.Visible = false;    //statusStrip1  状态栏控件
                richTextBox1.Height += statusStrip1.Height;
            }
            else
            {
                StatusStrip.Checked = true;
                statusStrip1.Visible = true;
                richTextBox1.Height -= statusStrip1.Height;
            }

        }

        //帮助
        private void About_Click(object sender, EventArgs e)
        {
            NotepadAbout notepadAbout = new NotepadAbout();
            notepadAbout.Show();
        }

        //工具栏快捷键
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int n;
            // 变量n用来接收按下按钮的索引号从0开始
            n = toolStrip1.Items.IndexOf(e.ClickedItem);
            switch (n)
            {
                case 0:
                    New_Click(sender, e);
                    break;
                case 1:
                    Open_Click(sender, e);
                    break;
                case 2:
                    Save_Click(sender, e);
                    break;
                /*case 3:
                    tsmiCopy_Click(sender, e);
                    break;*/ // 我们不用case3
                case 4:
                    Cut_Click(sender, e);
                    break;
                case 5:
                    Paste_Click(sender, e);
                    break;
                /*case 6:
                    tsmiPaste_Click(sender, e);
                    break; */ // 我们不用case6
                case 7:
                    About_Click(sender, e);
                    break;
            }

        }

        //状态栏 时间控制


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            DateTime.Text = System.DateTime.Now.ToString();
        }
    }
}
