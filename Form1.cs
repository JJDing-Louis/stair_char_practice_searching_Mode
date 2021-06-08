using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace stair_char_practice
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 讀檔路徑
        /// </summary>
        private string path;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_readfile_Click(object sender, EventArgs e)
        {
            readfile(@"D:\Personal-Work-Space\C# Project\stair_char_practice - 複製\ques.txt");
        }

        //readfile(@"");
        private Stopwatch stopwatch = new Stopwatch();

        public StringBuilder judge_function(List<char> ans)
        {
            StringBuilder sentence = new StringBuilder();
            //判定第1個條件，第1個字以及第10字為 !
            if (ans[0].Equals('!') && ans[9].Equals('!'))
            {
                //判定第2個條件，符號不會出現在答案裡面(%,^,+,@,#,*,=)
                //if(ans.All(item => item.Equals(rule.Select(item=> item))))
                if (!(ans.Contains('%') || ans.Contains('^') || ans.Contains('+') || ans.Contains('@') || ans.Contains('#') || ans.Contains('*') || ans.Contains('=')))
                {
                    foreach (char item in ans)
                    {
                        sentence.Append(item);
                    }
                    return sentence.Append(Environment.NewLine);
                }
            }
            return null;
        }

        /// <summary>
        /// 開始讀檔
        /// </summary>
        /// <param name="path">輸入檔案路徑</param>
        private void readfile(string path)
        {
            stopwatch.Restart();
            //此部分讀取
            List<List<char>> content = new List<List<char>>();
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                string word = reader.ReadLine();
                while (!string.IsNullOrWhiteSpace(word))
                {
                    //建立字串List
                    List<char> line1 = word.ToCharArray().ToList();
                    //將讀到的字串轉成array
                    content.Add(line1);
                    word = reader.ReadLine();
                }
            }

            string write_path = @"D:\Personal-Work-Space\C# Project\stair_char_practice - 複製\ans\ans.txt";
            using (StreamWriter streamWriter = new StreamWriter(write_path, false, Encoding.UTF8))
            {
                //方向左上往右下
                //Y方向的平移
                for (int y = 0; y < content.Count; y++)
                {
                    //X方向的平移
                    for (int x = 0; x < content[y].Count; x++)
                    {
                        //取54個字元
                        List<char> ans = new List<char>();
                        for (int i = 0; i < 54; i++)
                        {   //搜尋方式增加if判斷式，判定第一個項目是否為!，節省運算步驟
                            if (((x + i) >= content[y].Count) && ((y + i) >= content.Count))
                            {
                                ans.Add(content[y + i - content.Count][2 * content[y].Count - (x + i) - 2]);
                            }
                            else if (((x + i) >= content[y].Count) && ((y + i) < content.Count))
                            {
                                ans.Add(content[y + i][2 * content[y].Count - (x + i) - 2]);
                            }
                            else if (((x + i) < content[y].Count) && ((y + i) >= content.Count))
                            {
                                ans.Add(content[y + i - content.Count][x + i]);
                            }
                            else
                            {
                                ans.Add(content[y + i][x + i]);
                            }
                        }

                        streamWriter.Write(judge_function(ans));
                    }
                }

                //方向右上往左下
                for (int y = 0; y < content.Count; y++)
                {
                    //X方向的平移
                    for (int x = (content[y].Count - 1); x > 0; x--)
                    {
                        //取54個字元
                        List<char> ans = new List<char>();
                        for (int i = 0; i < 54; i++)
                        {
                            if (((x - i) <= 0) && ((y + i) >= content.Count))
                            {
                                ans.Add(content[y + i - content.Count][i - x]);
                            }
                            else if (((x - i) <= 0) && ((y + i) < content.Count))
                            {
                                ans.Add(content[y + i][i - x]);
                            }
                            else if (((x - i) > 0) && ((y + i) >= content.Count))
                            {
                                ans.Add(content[y + i - content.Count][x - i]);
                            }
                            else
                            {
                                ans.Add(content[y + i][x - i]);
                            }
                        }
                        streamWriter.Write(judge_function(ans));
                    }
                }

                //方向左下至右上
                for (int y = (content.Count - 1); y > 0; y--)
                {
                    //X方向的平移
                    for (int x = 0; x < content[y].Count; x++)
                    {
                        //取54個字元
                        List<char> ans = new List<char>();
                        for (int i = 0; i < 54; i++)
                        {
                            if (((x + i) >= content[y].Count) && ((y - i) <= 0))
                            {
                                ans.Add(content[y - i + (content.Count - 1)][2 * content[y].Count - (x + i) - 2]);
                            }
                            else if (((x + i) >= content[y].Count) && ((y - i) > 0))
                            {
                                ans.Add(content[y - i][2 * content[y].Count - (x + i) - 2]);
                            }
                            else if (((x + i) < content[y].Count) && ((y - i) <= 0))
                            {
                                ans.Add(content[y - i + (content.Count - 1)][x + i]);
                            }
                            else
                            {
                                ans.Add(content[y - i][x + i]);
                            }
                        }

                        streamWriter.Write(judge_function(ans));
                    }
                }
                //方向右下至左上
                for (int y = (content.Count - 1); y > 0; y--)
                {
                    //X方向的平移
                    for (int x = 71; x > 0; x--)
                    {
                        //取54個字元
                        List<char> ans = new List<char>();
                        for (int i = 0; i < 54; i++)
                        {
                            if (((x - i) <= 0) && ((y - i) <= 0))
                            {
                                ans.Add(content[y - i + (content.Count - 1)][i - x]);
                            }
                            else if (((x - i) <= 0) && ((y - i) > 0))
                            {
                                ans.Add(content[y - i][i - x]);
                            }
                            else if (((x - i) > 0) && ((y - i) <= 0))
                            {
                                ans.Add(content[y - i + (content.Count - 1)][x - i]);
                            }
                            else
                            {
                                ans.Add(content[y - i][x - i]);
                            }
                        }
                        streamWriter.Write(judge_function(ans));
                    }
                }
            }
            stopwatch.Stop();
            MessageBox.Show($"{stopwatch.ElapsedMilliseconds}");
        }
    }
}