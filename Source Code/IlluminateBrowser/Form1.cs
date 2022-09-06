using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IlluminateBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e) // Back button
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                if (web.CanGoBack)
                    web.GoBack();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e) // On load
        {
            webBrowser.Navigate("https://bing.com");
            webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl.SelectedTab.Text = webBrowser.DocumentTitle;
        }

        private void btnGo_Click(object sender, EventArgs e) // Search button
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
                web.Navigate(txtUrl.Text);
                tabControl.SelectedTab.Text = webTab.DocumentTitle;
        }

        WebBrowser webTab = null;

        private void btnHome_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://bing.com");
            webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
        }

        private void btnNewTab_Click(object sender, EventArgs e) // New tab
        {
            int openTabs = tabControl.TabCount;

            if (openTabs < 20) // Limits open tab count
            {
                TabPage tab = new TabPage();
                tab.Text = "New Tab";
                tabControl.Controls.Add(tab);
                tabControl.SelectTab(tabControl.TabCount - 1);
                webTab = new WebBrowser() { ScriptErrorsSuppressed = true };
                webTab.Parent = tab;
                webTab.Dock = DockStyle.Fill;
                webTab.Navigate("https://bing.com");
                txtUrl.Text = "https://bing.com";
                webTab.DocumentCompleted += WebTab_DocumentCompleted;
            }
        }

        private void WebTab_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl.SelectedTab.Text = webTab.DocumentTitle;
        }

        private void btnForward_Click(object sender, EventArgs e) // Forward button
        {
            WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                if (web.CanGoForward)
                    web.GoForward();
            }
        }

        private void txtUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                WebBrowser web = tabControl.SelectedTab.Controls[0] as WebBrowser;
                if (web != null)
                {
                    web.Navigate(txtUrl.Text);
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int openTabs = tabControl.TabCount;

            if (openTabs > 1) // Checks to ensure there is at least one tab open
            {
                tabControl.TabPages.Remove(tabControl.SelectedTab);
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            var about = new Form2();
            about.Show();
        }
    }
}
