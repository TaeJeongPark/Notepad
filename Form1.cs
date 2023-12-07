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

namespace Project4
{
    public partial class Form1 : Form
    {
        private string filePath;

        public Form1()
        {
            InitializeComponent();
        }

        /*private void btn_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "텍스트 파일|*.txt|모든 파일|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                richTextBox1.Text = File.ReadAllText(filePath);
            }
        }*/

        private void btn_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "텍스트 파일|*.txt|모든 파일|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader inFp;
                string inStr;

                filePath = new FileInfo(openFileDialog.FileName).FullName;
                inFp = new StreamReader(filePath); // 파일 오픈

                while (true)
                {
                    inStr = inFp.ReadLine();    // 파일 읽기
                    if (inStr == null) break;
                    richTextBox1.Text += (inStr + "\n");   // 텍스트박스에 출력
                }

                inFp.Close();
            }
        }

        /*private void btn_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "텍스트 파일|*.txt|모든 파일|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                    File.WriteAllText(filePath, richTextBox1.Text);
                }
            }
            else
            {
                File.WriteAllText(filePath, richTextBox1.Text);
            }
        }*/


        private void btn_save_Click(object sender, EventArgs e)
        {
            StreamWriter outFp;
            string outStr;

            outFp = new StreamWriter(filePath);

            outStr = richTextBox1.Text;

            outFp.WriteLine(outStr);

            outFp.Close();
            Console.WriteLine("정상적으로 파일이 저장되었습니다.");
        }

        /*private void btn_new_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "텍스트 파일|*.txt|모든 파일|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, richTextBox1.Text);
            }
        }*/

        private void btn_new_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "텍스트 파일|*.txt|모든 파일|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;

                StreamWriter outFp;
                string outStr;

                outFp = new StreamWriter(filePath);

                outStr = richTextBox1.Text;

                outFp.WriteLine(outStr);

                outFp.Close();
                Console.WriteLine("정상적으로 파일이 저장되었습니다.");
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            filePath = null;
        }
    }
}
