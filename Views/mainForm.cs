using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using customFonts.Models;
using Microsoft.Win32;

namespace customFonts.Views
{
    public partial class mainForm : Form
    {
        private Dictionary<string, FontFamily> fontPair = new Dictionary<string, FontFamily>();
        public mainForm()
        {
            InitializeComponent();
            loadIcons();

            button3.Enabled = IsWindows11();
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

        public static bool IsWindows11()
        {
            try
            {
                var reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");

                var currentBuildStr = (string)reg.GetValue("CurrentBuild");
                var currentBuild = int.Parse(currentBuildStr);

                return currentBuild >= 22000;
            } catch (Exception) { return false; }
        }

        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int uFlags, int dwReason);

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                fontPatchTool.PatchSegoeUI(fontPair[listView1.SelectedItems[0].Text]);
                if (MessageBox.Show(resourceLoader.ConfLogoff(), resourceLoader.WaitString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ExitWindowsEx(0, 0x00000004);
                }
            }
            catch (fontPatchException)
            {
                MessageBox.Show(String.Format(resourceLoader.Problem(), "Segoe UI"), resourceLoader.ProbString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            patchForm patchForm = new patchForm();
            patchForm.ShowDialog();
            if (patchForm.font != null)
            {
                try
                {
                    fontPatchTool.PatchFont(patchForm.font, fontPair[listView1.SelectedItems[0].Text]);
                    if (MessageBox.Show(resourceLoader.ConfLogoff(), resourceLoader.WaitString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ExitWindowsEx(0, 0x00000004);
                    }
                }
                catch (fontPatchException)
                {
                    MessageBox.Show(String.Format(resourceLoader.Problem(), patchForm.font.Name), resourceLoader.ProbString());
                }
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                fontPatchTool.PatchSegoeUIVar(fontPair[listView1.SelectedItems[0].Text]);
                if (MessageBox.Show(resourceLoader.ConfLogoff(), resourceLoader.WaitString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ExitWindowsEx(0, 0x00000004);
                }
            }
            catch (fontPatchException)
            {
                MessageBox.Show(String.Format(resourceLoader.Problem(), "Segoe UI Variable"), resourceLoader.ProbString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                fontPatchTool.PatchMSSansSerif(fontPair[listView1.SelectedItems[0].Text]);
                if (MessageBox.Show(resourceLoader.ConfLogoff(), resourceLoader.WaitString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ExitWindowsEx(0, 0x00000004);
                }
            }
            catch (fontPatchException)
            {
                MessageBox.Show(String.Format(resourceLoader.Problem(), "MS Sans Serif"), resourceLoader.ProbString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                fontPatchTool.PatchConsolas(fontPair[listView1.SelectedItems[0].Text]);
                if (MessageBox.Show(resourceLoader.ConfLogoff(), resourceLoader.WaitString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ExitWindowsEx(0, 0x00000004);
                }
            }
            catch (fontPatchException)
            {
                MessageBox.Show(String.Format(resourceLoader.Problem(), "Consolas"), resourceLoader.ProbString());
            }
        }
    }
}
