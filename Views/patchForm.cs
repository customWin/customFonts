using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace customFonts.Views
{
    public partial class patchForm : Form
    {
        private Dictionary<string, FontFamily> fontPair = new Dictionary<string, FontFamily>();
        public patchForm()
        {
            InitializeComponent();
            loadIcons();
        }

        public void loadIcons()
        {
            InstalledFontCollection fonts = new InstalledFontCollection();
            FontFamily[] fontF = fonts.Families;

            foreach (var font in fontF)
            {
                ListViewItem item = new ListViewItem();
                item.Text = font.Name;
                item.Font = new Font(font, 12);
                fontPair.Add(font.Name, font);

                listView1.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label2.Font = new Font(fontPair[listView1.SelectedItems[0].Text], 20);
                label3.Font = new Font(fontPair[listView1.SelectedItems[0].Text], 15);
                label4.Font = new Font(fontPair[listView1.SelectedItems[0].Text], 10);
                label5.Font = new Font(fontPair[listView1.SelectedItems[0].Text], 9);
            } catch (Exception) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            font = fontPair[listView1.SelectedItems[0].Text];
            Close();
        }

        public static FontFamily font { get; private set; }
    }
}
