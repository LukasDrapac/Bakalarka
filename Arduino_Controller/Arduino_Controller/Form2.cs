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

namespace Arduino_Controller
{
    public partial class galeryForm : Form
    {
        int pageLength = 50;
        int currentPage;
        int maxPage;

        string imagesPath;
        string[] folders;

        DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
        public galeryForm()
        {
            InitializeComponent();
        }

        public galeryForm(string path)
        {
            InitializeComponent();
            gridInit();
            imagesPath = path;
            Console.WriteLine(imagesPath);
            getSubfolders();
            initPage();
        }

        private void gridInit()
        {
            gridView.ColumnCount = 2;

            gridView.Columns[0].Name = "Inventární číslo";
            gridView.Columns[1].Name = "Cesta ke složce";

            gridView.Columns.Add(imageColumn);
            imageColumn.Name = "Úvodní fotka";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

            gridView.Columns[0].Width = 150;
            gridView.Columns[1].Width = 150;
            imageColumn.Width = 210;
            gridView.RowTemplate.Height = 98;
        }

        private void AddDataToGrid(string info)
        {
            string[] hodnota = new string[2];
            hodnota[1] = info;
            
            int index = -1;
            for(int i = 0; i < info.Length; i++)
            {
                if (info[i].Equals(Path.DirectorySeparatorChar))
                {
                    Console.WriteLine(info[i]);
                    index = i;
                }
            }
            hodnota[0] = info.Substring(index + 1);

            //Image img = Image.FromFile(info + Path.DirectorySeparatorChar + "Processed_Image.jpg");

            gridView.Rows.Add(hodnota[0], hodnota[1]/*, img*/);
            
        }

        private void getSubfolders()
        {
            folders = Directory.GetDirectories(imagesPath);
            maxPage = folders.Length / pageLength;
            currentPage = 1;
            if(folders.Length % pageLength > 0)
            {
                maxPage++;
            }            
        }

        private void initPage()
        {
            if(currentPage < maxPage)
            {
                for (int i = (currentPage - 1) * 50; i < currentPage * 50; i++)
                {
                    //Console.WriteLine(folders[i]);
                    AddDataToGrid(folders[i]);
                }
            }
            else
            {
                for (int i = (currentPage - 1) * 50; i < folders.Length; i++)
                {
                    //Console.WriteLine(folders[i]);
                    AddDataToGrid(folders[i]);
                }
            }
        }

        private void deleteRows() { 
            foreach(DataGridViewRow row in gridView.Rows)
            {
                gridView.Rows.Clear();
            }
        }

        private void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(gridView.CurrentRow);
            
        }

        private void previousPage_Click(object sender, EventArgs e)
        {            
            if(currentPage > 1)
            {
                deleteRows();
                currentPage--;
                initPage();
            }
        }

        private void nextPage_Click(object sender, EventArgs e)
        {
            if(currentPage < maxPage)
            {
                deleteRows();
                currentPage++;
                initPage();
            }
        }
    }
}
