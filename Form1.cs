using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections;
using endmystem.Models;
using System.Data.Entity;

namespace endmystem
{
    public partial class Form1 : Form
    {           
        StringBuilder receivedOutput;
        Process mystem;
        System.Reflection.Assembly path = System.Reflection.Assembly.GetEntryAssembly();
        private SynchronizationContext SyncContext;
        private List<string> keywordsList = new List<string>();
        private Dictionary<string, List<string>> BookDictionary = new Dictionary<string, List<string>>();


        public void OnReceivedDataping(object state)
        {
            var result = (string)state;
            if (result != "" && result != null)
            {
                var resultList = result.Split(new char[] { '|' });
                if (resultList.Count() > 0)
                {
                    keywordsList.AddRange(resultList);
                }               
            }
        }
                                                                                                                                                    
        public void mystemprocess()
        {
            keywordsList.Clear();
            textBox2.Clear();
            BookDictionary = new Dictionary<string, List<string>>();
            string baseDir = System.IO.Path.GetDirectoryName(path.Location);
            receivedOutput = new StringBuilder();
            mystem = new Process();
            mystem.StartInfo.WorkingDirectory = baseDir;
            mystem.StartInfo.FileName = "mystem.exe";
            mystem.Exited += delegate(object osender, EventArgs args)
            {
                SyncContext.Post(OnExited, args);
            }; 
            mystem.StartInfo.Arguments = "-nl";
            mystem.StartInfo.UseShellExecute = false;
            mystem.StartInfo.RedirectStandardOutput = true;
            mystem.StartInfo.RedirectStandardInput = true;
            mystem.StartInfo.CreateNoWindow = true;
            mystem.EnableRaisingEvents = true;
            mystem.OutputDataReceived += delegate(object osender, DataReceivedEventArgs oe)
            {
                SyncContext.Post(OnReceivedDataping, oe.Data);
            };
            mystem.Start();
            StreamWriter inputmystem = mystem.StandardInput;
            inputmystem.Write(textBox1.Text);
            inputmystem.Close();
            mystem.BeginOutputReadLine();
            mystem.WaitForExit();              
        }

        private void OnExited(object state)
        {
            using (MystemContext _db = new MystemContext())
            {
                var keywords = _db.Keywords.Include("Books")
                                            .Where(k => keywordsList.Contains(k.Name))
                                            .OrderByDescending(m => m.Books.Count())                                                                                       
                                            .ToList();                                              
                foreach (var keyword in keywords)
                {
                    ICollection<Book> books = keyword.Books;                    
                    foreach (var book in books)
                    {
                        if (BookDictionary.Any(d => d.Key == book.Title))
                        {
                            BookDictionary[book.Title].Add(keyword.Name);                       
                        }
                        else
                        {
                            BookDictionary.Add(book.Title, new List<string>{keyword.Name});
                        }      
                    }
                                                                                           
                }

                foreach (var item in BookDictionary)
                {
                    string NewText = item.Key + " (";                    
                    NewText += String.Join(", ",item.Value);                    
                    NewText += ")";
                    textBox2.AppendText(NewText + Environment.NewLine);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();                              
            SyncContext = SynchronizationContext.Current;   
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mystemprocess();                                               
        }
    }
}
