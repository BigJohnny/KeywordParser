using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeywordParser
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Find Keyword
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            textBox2.Text = ofd.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sContent = textBox1.Text;
            if (string.IsNullOrEmpty(sContent))
            {
                //todo read text file
            }
            //換行的字把它貼起來
            sContent = sContent.Replace("\r\n", "");

            bool isContinued = true;

            //英文取字
            string[] sWordArray = sContent.Split(' ');
            //都轉小寫,標準一致
            sWordArray = (from s in sWordArray
                          select s.ToLower()).ToArray();


            Dictionary<string, Keyword> dicKeyword = new Dictionary<string, Keyword>();
            List<Keyword> lKeyword = new List<Keyword>();
            for (int index = 0; index < sWordArray.Length; index++)
            {
                int iCount = 0;
                string sWord = sWordArray[index];

                //已存在的話不用找
                if (dicKeyword.ContainsKey(sWord))
                    continue;

                var temp = from s in sWordArray
                           where s == sWord
                           select 1;
                iCount = temp.Sum();

                //收入字典
                Keyword kwTemp = new Keyword()
                {
                    Word = sWord,
                    Count = iCount,
                    isIgnored = Keyword.dicIgnoredArray.Contains(sWord)
                };

                dicKeyword.Add(sWord,kwTemp);
                lKeyword.Add(kwTemp);

            }
            //todo 中文取字
            //for (int index = 0; index < sContent.Length;index++)
            //{
            //    //照順序取字
            //    
            //    //比對全文,有找到就繼續往後推,找出單字
            //
            //    //收入字典,已存在的話不用收(ex 可能會必勝客照順序找)
            //
            //
            //}
            //while (isContinued)
            //{
            //
            //
            //
            //    //英文
            //    //中文
            //}

            lKeyword = lKeyword.OrderByDescending(x => x.Count).ToList();
            Form form2 = new Form2(lKeyword);
            form2.ShowDialog();

        }
    }
    public class Keyword
    {
        public string Word { get; set; }
        public int Count { get; set; }
        public bool isIgnored { get; set; }

        public static HashSet<string> dicIgnoredArray { get; set; }
        static Keyword(){
            dicIgnoredArray = new HashSet<string>();
            //todo 可維護,from txt
            dicIgnoredArray.Add("is");
            dicIgnoredArray.Add("of");
            dicIgnoredArray.Add("a");
            dicIgnoredArray.Add("the");
            dicIgnoredArray.Add("is");
            dicIgnoredArray.Add("on");
            dicIgnoredArray.Add("of");
        }
    }
}
