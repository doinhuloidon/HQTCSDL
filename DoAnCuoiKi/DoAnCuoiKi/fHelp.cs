using Microsoft.Office.Interop.Word;
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
using Word= Microsoft.Office.Interop.Word;

namespace DoAnCuoiKi
{
    public partial class fHelp : Form
    {
        public fHelp()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Word.Application ap = new Word.Application();
                string path = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\GioiThieu.docx");
                Document document = ap.Documents.Open(path, ReadOnly: false);
                //object objMissing = System.Reflection.Missing.Value;
                //Microsoft.Office.Interop.Word._Application objWord;
                //Microsoft.Office.Interop.Word._Document objDoc;
                //objWord = new Microsoft.Office.Interop.Word.Application();
                //object fileName = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\GioiThieu.docx");
                //objDoc = objWord.Documents.Open(ref fileName,
                //    ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing,
                //    ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing,
                //    ref objMissing, ref objMissing, ref objMissing, ref objMissing, ref objMissing);
            }
            catch
            {
                MessageBox.Show("File không tồn tại !");
            }
            
        }
    }
}
