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
using System.Diagnostics;

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

        //Inicializace parametru DataGridView 
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

        //Prida radek do DataGridVied
        private void AddDataToGrid(string info)
        {
            string[] hodnota = new string[2];
            hodnota[1] = info;
            
            int index = -1;
            for(int i = 0; i < info.Length; i++)
            {
                if (info[i].Equals(Path.DirectorySeparatorChar))
                {
                    //Console.WriteLine(info[i]);
                    index = i;
                }
            }
            hodnota[0] = info.Substring(index + 1);

            Image img = Image.FromFile(info + Path.DirectorySeparatorChar + "Processed_Image.jpg");

            gridView.Rows.Add(hodnota[0], hodnota[1], img);
            
        }

        //Vrati pole slozek v cilovem adresari
        private void getSubfolders()
        {
            folders = Directory.GetDirectories(imagesPath);
            maxPage = folders.Length / pageLength;
            currentPage = 1;            
            if(folders.Length % pageLength > 0)
            {
                maxPage++;
            }
            page.Text = currentPage + " / " + maxPage;
        }

        //Nacteni zanzamu na jednu stranku
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

        //Odstrani vsechny radky v DataGridView
        private void deleteRows() { 
            foreach(DataGridViewRow row in gridView.Rows)
            {
                gridView.Rows.Clear();
            }
        }

        //Nacteni predchozi stranky
        private void previousPage_Click(object sender, EventArgs e)
        {            
            if(currentPage > 1)
            {
                deleteRows();
                currentPage--;
                page.Text = currentPage + " / " + maxPage;
                initPage();
            }
        }

        //Nacteni dalsi stranky
        private void nextPage_Click(object sender, EventArgs e)
        {
            if(currentPage < maxPage)
            {
                deleteRows();
                currentPage++;
                page.Text = currentPage + " / " + maxPage;
                initPage();
            }
        }

        //Vyfiltruje radky podle stringu
        private void filterButton_Click(object sender, EventArgs e)
        {
            if(filterTextBox.Text != "")
            {
                deleteRows();
                for(int i = 0; i < folders.Length; i++)
                {   if (folders[i].Contains(filterTextBox.Text))
                    {
                        AddDataToGrid(folders[i]);
                    }                    
                }
            }
        }

        //Spusti Processing script a preda argument s adresarem kraslice
        private void runScript_Click(object sender, EventArgs e)
        {
            Console.WriteLine(gridView.CurrentRow.Cells[1].Value.ToString());
            string argument = gridView.CurrentRow.Cells[1].Value.ToString();
            var process = new ProcessStartInfo();
            process.FileName = @"C:/Users/drapa/OneDrive/Plocha/processing-3.5.4/processing-java.exe";
            process.Arguments = $"--sketch=C:/Users/drapa/OneDrive/Plocha/ImageProcess --run " + argument + "/Processed_Image.jpg";
            process.UseShellExecute = false;
            process.CreateNoWindow = true;

            Process.Start(process);
        }
    }
}
