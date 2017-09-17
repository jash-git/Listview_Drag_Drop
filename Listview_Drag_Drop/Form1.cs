using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Listview_Drag_Drop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.AllowDrop = true;//允許元件拖放
            listView2.AllowDrop = true;

            listView1.Items.Add("123", 0);//初始元素
            listView1.Items.Add("456", 0);
            listView1.Items.Add("789", 0);
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)//來源進行拖放
        {
            int i, j;
            ListViewItem LVI;
            string s;
            LVI = listView1.SelectedItems[0];//紀錄被拖放的元件
            s = LVI.Text;  
            DragDropEffects dde1 = DoDragDrop(s,
                DragDropEffects.All);

            if (dde1 == DragDropEffects.All)//確定已經離開的判斷
            {
                listView1.Items.Remove(LVI);   
            }		
        }

        private void listView2_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))//確定以拖拉到目的區域
            {
                string str = (string)e.Data.GetData(DataFormats.StringFormat);
                listView2.Items.Add(str, 0);
            }
        }

        private void listView2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i,j;
            ListViewItem LVI;
            j = listView2.Items.Count;
            for (i = 0; i < j; i++)
            {
                LVI = listView2.Items[i];
                MessageBox.Show(LVI.Text);   
            }
        }
    }
}
