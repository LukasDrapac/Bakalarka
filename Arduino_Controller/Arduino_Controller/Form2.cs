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
        string imagesPath;
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
        }

        private void gridInit()
        {
            gridView.ColumnCount = 2;

            gridView.Columns[0].Name = "Inventární číslo";
            gridView.Columns[1].Name = "Cesta ke složce";
        }

        private void addDataToGrid(string info)
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

            gridView.Rows.Add(hodnota);
        }
        private void getSubfolders()
        {
            string[] folders = Directory.GetDirectories(imagesPath);
            for(int i = 0; i < folders.Length; i++)
            {
                Console.WriteLine(folders[i]);
                addDataToGrid(folders[i]);
            }
        }
    }
}
