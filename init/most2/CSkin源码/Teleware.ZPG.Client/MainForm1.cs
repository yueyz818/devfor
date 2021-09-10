﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Teleware.ZPG.Client.Module;

namespace Teleware.ZPG.Client
{
    public partial class MainForm1 : SkinForm1
    {
        private NetDisconnectControl netDisconnectControl;
        private TradeUnStartControl tradeUnStartControl;
        private TradeFinishControl tradeFinishControl;
        private TradeReadyControl tradeReadyControl;
        
        public MainForm1()
        {
            InitializeComponent();
            this.Load += new EventHandler(MainForm_Load);
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            this.panel_main.BringToFront();
        }

        private void skinTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (skinTabControl1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    webBrowser_tradeDetail.Navigate(WebUrls.TradeDetailUrl);
                    break;
                case 2:
                    webBrowser_affiche.Navigate(WebUrls.AfficheUrl);
                    break;
                case 3:
                    webBrowser_tradeResult.Navigate(WebUrls.TradeResultUrl);
                    break;
                case 4:
                    webBrowser_applyInfo.Navigate(WebUrls.ApplyInfoUrl);
                    break;
            }

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            Teleware.ZPG.Client.LoadingBox.ShowLoading(null, "正在加载数据，请稍后......");
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            Teleware.ZPG.Client.LoadingBox.CloseLoading();
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show(this, "请您输入密码", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void skinButton4_Click(object sender, EventArgs e)
        {
            NotifyBox.Notify(this, "正在加载正在加", NotifyBoxIcon.Info, 3000);
        }

        private void skinButton5_Click(object sender, EventArgs e)
        {
            if (netDisconnectControl == null)
            {
                netDisconnectControl = new NetDisconnectControl();
                netDisconnectControl.Dock = DockStyle.Fill;
                netDisconnectControl.ForeColor = Color.Black;
                panel_switch.Controls.Add(netDisconnectControl);
            }
            foreach (Control item in panel_switch.Controls)
            {
                if (item != netDisconnectControl)
                {
                    item.Visible = false;
                }
            }
            netDisconnectControl.Visible = true;
            panel_main.Visible = false;
            panel_switch.Visible = true;
            panel_switch.BringToFront();
            skinTabControl1.SelectedIndex = 0;
        }

        private void skinButton6_Click(object sender, EventArgs e)
        {
            if (tradeUnStartControl == null)
            {
                tradeUnStartControl = new TradeUnStartControl();
                tradeUnStartControl.Dock = DockStyle.Fill;
                tradeUnStartControl.ForeColor = Color.Black;
                panel_switch.Controls.Add(tradeUnStartControl);
            }
            foreach (Control item in panel_switch.Controls)
            {
                if (item != tradeUnStartControl)
                {
                    item.Visible = false;
                }
            }
            tradeUnStartControl.Visible = true;
            panel_main.Visible = false;
            panel_switch.Visible = true;
            panel_switch.BringToFront();
            skinTabControl1.SelectedIndex = 0;
        }

        private void skinButton7_Click(object sender, EventArgs e)
        {
            if (tradeFinishControl == null)
            {
                tradeFinishControl = new TradeFinishControl();
                tradeFinishControl.Dock = DockStyle.Fill;
                tradeFinishControl.ForeColor = Color.Black;
                panel_switch.Controls.Add(tradeFinishControl);
            }
            foreach (Control item in panel_switch.Controls)
            {
                if (item != tradeFinishControl)
                {
                    item.Visible = false;
                }
            }
            tradeFinishControl.Visible = true;
            panel_main.Visible = false;
            panel_switch.Visible = true;
            panel_switch.BringToFront();
            skinTabControl1.SelectedIndex = 0;
        }

        private void skinButton8_Click(object sender, EventArgs e)
        {
            if (tradeReadyControl == null)
            {
                tradeReadyControl = new TradeReadyControl();
                tradeReadyControl.Dock = DockStyle.Fill;
                tradeReadyControl.ForeColor = Color.Black;
                panel_switch.Controls.Add(tradeReadyControl);
            }
            foreach (Control item in panel_switch.Controls)
            {
                if (item != tradeReadyControl)
                {
                    item.Visible = false;
                }
            }
            tradeReadyControl.Visible = true;
            panel_main.Visible = false;
            panel_switch.Visible = true;
            panel_switch.BringToFront();
            skinTabControl1.SelectedIndex = 0;
        }

       
    }
}
