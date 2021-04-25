using System.ComponentModel;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace OGameEmptyPlanetFinder
{
    partial class FinderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Universe Info", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Player Info", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Alliance Info", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Universe ID");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Universe Name");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Universe Speed");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Player ID");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Player Name");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Alliance ID");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Alliance Tag");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Alliance Name");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinderForm));
            this.labCopyright = new System.Windows.Forms.Label();
            this.listFreePlanets = new System.Windows.Forms.ListView();
            this.colHeaderCoords = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numGalaxyStart = new System.Windows.Forms.NumericUpDown();
            this.numSunSysStart = new System.Windows.Forms.NumericUpDown();
            this.numPlanetStart = new System.Windows.Forms.NumericUpDown();
            this.numGalaxyStop = new System.Windows.Forms.NumericUpDown();
            this.numSunSysStop = new System.Windows.Forms.NumericUpDown();
            this.numPlanetStop = new System.Windows.Forms.NumericUpDown();
            this.labGalaxy = new System.Windows.Forms.Label();
            this.labSunSys = new System.Windows.Forms.Label();
            this.labPlanet = new System.Windows.Forms.Label();
            this.labTo1 = new System.Windows.Forms.Label();
            this.labTo2 = new System.Windows.Forms.Label();
            this.labTo3 = new System.Windows.Forms.Label();
            this.groupSearchRange = new System.Windows.Forms.GroupBox();
            this.butSearch = new System.Windows.Forms.Button();
            this.butStop = new System.Windows.Forms.Button();
            this.tabControlInfo = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.labAutoRefreshMin = new System.Windows.Forms.Label();
            this.numAutoRefreshMin = new System.Windows.Forms.NumericUpDown();
            this.checkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.butSwitchPlanet = new System.Windows.Forms.Button();
            this.comboChosenPlanet = new System.Windows.Forms.ComboBox();
            this.butRefresh = new System.Windows.Forms.Button();
            this.labPlanetCoordsValue = new System.Windows.Forms.Label();
            this.labPlanetNameValue = new System.Windows.Forms.Label();
            this.labPlanetIdValue = new System.Windows.Forms.Label();
            this.labPlanetCoords = new System.Windows.Forms.Label();
            this.labPlanetName = new System.Windows.Forms.Label();
            this.labPlanetId = new System.Windows.Forms.Label();
            this.labDMValue = new System.Windows.Forms.Label();
            this.picMetal = new System.Windows.Forms.PictureBox();
            this.labEnergyValue = new System.Windows.Forms.Label();
            this.picCrystal = new System.Windows.Forms.PictureBox();
            this.labDeutValue = new System.Windows.Forms.Label();
            this.picDeut = new System.Windows.Forms.PictureBox();
            this.labCrystalValue = new System.Windows.Forms.Label();
            this.picEnergy = new System.Windows.Forms.PictureBox();
            this.labMetalValue = new System.Windows.Forms.Label();
            this.picDM = new System.Windows.Forms.PictureBox();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.listInfo = new System.Windows.Forms.ListView();
            this.columnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabAlert = new System.Windows.Forms.TabPage();
            this.butTestStopAlert = new System.Windows.Forms.Button();
            this.butOpenSoundsFolder = new System.Windows.Forms.Button();
            this.textAlertSoundsDir = new System.Windows.Forms.TextBox();
            this.checkAlertSounds = new System.Windows.Forms.CheckBox();
            this.olvFleetMoving = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnMission = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnArrivalTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnOrigin = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnFleet = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnTarget = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnReturns = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.labAlertStatus = new System.Windows.Forms.Label();
            this.picAlertStatus = new System.Windows.Forms.PictureBox();
            this.bgWorkerSearchPlanis = new System.ComponentModel.BackgroundWorker();
            this.butCopyPlanets = new System.Windows.Forms.Button();
            this.checkPlanetsCoordsTags = new System.Windows.Forms.CheckBox();
            this.labSearchEngine = new System.Windows.Forms.Label();
            this.labSEStatus = new System.Windows.Forms.Label();
            this.listDF = new System.Windows.Forms.ListView();
            this.colHeadDFCoords = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadDFMetal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadDFCrys = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadDFRecs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numMinDF = new System.Windows.Forms.NumericUpDown();
            this.labMinDFRes = new System.Windows.Forms.Label();
            this.tabControlSearchList = new System.Windows.Forms.TabControl();
            this.tabPageFreePlanets = new System.Windows.Forms.TabPage();
            this.groupSearchOptions = new System.Windows.Forms.GroupBox();
            this.radioSearchDestroyed = new System.Windows.Forms.RadioButton();
            this.radioSearchEmpty = new System.Windows.Forms.RadioButton();
            this.radioSearchAll = new System.Windows.Forms.RadioButton();
            this.tabPageDF = new System.Windows.Forms.TabPage();
            this.checkDebrisCoordsTags = new System.Windows.Forms.CheckBox();
            this.butCopyDebris = new System.Windows.Forms.Button();
            this.timerAutoRefresh = new System.Windows.Forms.Timer(this.components);
            this.butBrowser = new System.Windows.Forms.Button();
            this.backWorkRefresh = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemSettings = new System.Windows.Forms.MenuItem();
            this.fbdAlertSounds = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numGalaxyStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSunSysStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlanetStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGalaxyStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSunSysStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlanetStop)).BeginInit();
            this.groupSearchRange.SuspendLayout();
            this.tabControlInfo.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoRefreshMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMetal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCrystal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDeut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnergy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDM)).BeginInit();
            this.tabInfo.SuspendLayout();
            this.tabAlert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvFleetMoving)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAlertStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinDF)).BeginInit();
            this.tabControlSearchList.SuspendLayout();
            this.tabPageFreePlanets.SuspendLayout();
            this.groupSearchOptions.SuspendLayout();
            this.tabPageDF.SuspendLayout();
            this.cmsTrayIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // labCopyright
            // 
            this.labCopyright.AutoSize = true;
            this.labCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCopyright.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labCopyright.Location = new System.Drawing.Point(205, 540);
            this.labCopyright.Name = "labCopyright";
            this.labCopyright.Size = new System.Drawing.Size(204, 13);
            this.labCopyright.TabIndex = 99;
            this.labCopyright.Text = "applusplus Copyright (C) 2013-2019";
            // 
            // listFreePlanets
            // 
            this.listFreePlanets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderCoords,
            this.colHeaderStatus});
            this.listFreePlanets.FullRowSelect = true;
            this.listFreePlanets.GridLines = true;
            this.listFreePlanets.Location = new System.Drawing.Point(0, 0);
            this.listFreePlanets.Name = "listFreePlanets";
            this.listFreePlanets.Size = new System.Drawing.Size(238, 250);
            this.listFreePlanets.TabIndex = 14;
            this.listFreePlanets.UseCompatibleStateImageBehavior = false;
            this.listFreePlanets.View = System.Windows.Forms.View.Details;
            // 
            // colHeaderCoords
            // 
            this.colHeaderCoords.Text = "Coordinates";
            this.colHeaderCoords.Width = 100;
            // 
            // colHeaderStatus
            // 
            this.colHeaderStatus.Text = "Status";
            this.colHeaderStatus.Width = 120;
            // 
            // numGalaxyStart
            // 
            this.numGalaxyStart.Location = new System.Drawing.Point(84, 22);
            this.numGalaxyStart.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numGalaxyStart.Name = "numGalaxyStart";
            this.numGalaxyStart.Size = new System.Drawing.Size(40, 20);
            this.numGalaxyStart.TabIndex = 2;
            this.numGalaxyStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGalaxyStart.ValueChanged += new System.EventHandler(this.numGalaxyStart_ValueChanged);
            // 
            // numSunSysStart
            // 
            this.numSunSysStart.Location = new System.Drawing.Point(84, 58);
            this.numSunSysStart.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numSunSysStart.Name = "numSunSysStart";
            this.numSunSysStart.Size = new System.Drawing.Size(40, 20);
            this.numSunSysStart.TabIndex = 3;
            this.numSunSysStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSunSysStart.ValueChanged += new System.EventHandler(this.numSunSysStart_ValueChanged);
            // 
            // numPlanetStart
            // 
            this.numPlanetStart.Location = new System.Drawing.Point(84, 93);
            this.numPlanetStart.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numPlanetStart.Name = "numPlanetStart";
            this.numPlanetStart.Size = new System.Drawing.Size(40, 20);
            this.numPlanetStart.TabIndex = 4;
            this.numPlanetStart.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numPlanetStart.ValueChanged += new System.EventHandler(this.numPlanetStart_ValueChanged);
            // 
            // numGalaxyStop
            // 
            this.numGalaxyStop.Location = new System.Drawing.Point(152, 22);
            this.numGalaxyStop.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numGalaxyStop.Name = "numGalaxyStop";
            this.numGalaxyStop.Size = new System.Drawing.Size(40, 20);
            this.numGalaxyStop.TabIndex = 5;
            this.numGalaxyStop.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGalaxyStop.ValueChanged += new System.EventHandler(this.numGalaxyStop_ValueChanged);
            // 
            // numSunSysStop
            // 
            this.numSunSysStop.Location = new System.Drawing.Point(152, 58);
            this.numSunSysStop.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numSunSysStop.Name = "numSunSysStop";
            this.numSunSysStop.Size = new System.Drawing.Size(40, 20);
            this.numSunSysStop.TabIndex = 6;
            this.numSunSysStop.Value = new decimal(new int[] {
            499,
            0,
            0,
            0});
            this.numSunSysStop.ValueChanged += new System.EventHandler(this.numSunSysStop_ValueChanged);
            // 
            // numPlanetStop
            // 
            this.numPlanetStop.Location = new System.Drawing.Point(152, 93);
            this.numPlanetStop.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numPlanetStop.Name = "numPlanetStop";
            this.numPlanetStop.Size = new System.Drawing.Size(40, 20);
            this.numPlanetStop.TabIndex = 7;
            this.numPlanetStop.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.numPlanetStop.ValueChanged += new System.EventHandler(this.numPlanetStop_ValueChanged);
            // 
            // labGalaxy
            // 
            this.labGalaxy.AutoSize = true;
            this.labGalaxy.Location = new System.Drawing.Point(13, 24);
            this.labGalaxy.Name = "labGalaxy";
            this.labGalaxy.Size = new System.Drawing.Size(65, 13);
            this.labGalaxy.TabIndex = 18;
            this.labGalaxy.Text = "Galaxy from:";
            // 
            // labSunSys
            // 
            this.labSunSys.AutoSize = true;
            this.labSunSys.Location = new System.Drawing.Point(6, 60);
            this.labSunSys.Name = "labSunSys";
            this.labSunSys.Size = new System.Drawing.Size(72, 13);
            this.labSunSys.TabIndex = 19;
            this.labSunSys.Text = "Sun Sys from:";
            // 
            // labPlanet
            // 
            this.labPlanet.AutoSize = true;
            this.labPlanet.Location = new System.Drawing.Point(15, 95);
            this.labPlanet.Name = "labPlanet";
            this.labPlanet.Size = new System.Drawing.Size(63, 13);
            this.labPlanet.TabIndex = 20;
            this.labPlanet.Text = "Planet from:";
            // 
            // labTo1
            // 
            this.labTo1.AutoSize = true;
            this.labTo1.Location = new System.Drawing.Point(130, 24);
            this.labTo1.Name = "labTo1";
            this.labTo1.Size = new System.Drawing.Size(16, 13);
            this.labTo1.TabIndex = 21;
            this.labTo1.Text = "to";
            // 
            // labTo2
            // 
            this.labTo2.AutoSize = true;
            this.labTo2.Location = new System.Drawing.Point(130, 60);
            this.labTo2.Name = "labTo2";
            this.labTo2.Size = new System.Drawing.Size(16, 13);
            this.labTo2.TabIndex = 22;
            this.labTo2.Text = "to";
            // 
            // labTo3
            // 
            this.labTo3.AutoSize = true;
            this.labTo3.Location = new System.Drawing.Point(130, 95);
            this.labTo3.Name = "labTo3";
            this.labTo3.Size = new System.Drawing.Size(16, 13);
            this.labTo3.TabIndex = 23;
            this.labTo3.Text = "to";
            // 
            // groupSearchRange
            // 
            this.groupSearchRange.Controls.Add(this.labTo3);
            this.groupSearchRange.Controls.Add(this.numPlanetStop);
            this.groupSearchRange.Controls.Add(this.labTo2);
            this.groupSearchRange.Controls.Add(this.numGalaxyStart);
            this.groupSearchRange.Controls.Add(this.labTo1);
            this.groupSearchRange.Controls.Add(this.numSunSysStart);
            this.groupSearchRange.Controls.Add(this.labPlanet);
            this.groupSearchRange.Controls.Add(this.numPlanetStart);
            this.groupSearchRange.Controls.Add(this.labSunSys);
            this.groupSearchRange.Controls.Add(this.numGalaxyStop);
            this.groupSearchRange.Controls.Add(this.labGalaxy);
            this.groupSearchRange.Controls.Add(this.numSunSysStop);
            this.groupSearchRange.Location = new System.Drawing.Point(8, 12);
            this.groupSearchRange.Name = "groupSearchRange";
            this.groupSearchRange.Size = new System.Drawing.Size(210, 129);
            this.groupSearchRange.TabIndex = 24;
            this.groupSearchRange.TabStop = false;
            this.groupSearchRange.Text = "Search Range";
            // 
            // butSearch
            // 
            this.butSearch.Location = new System.Drawing.Point(17, 147);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(76, 25);
            this.butSearch.TabIndex = 0;
            this.butSearch.Text = "Search";
            this.butSearch.UseVisualStyleBackColor = true;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // butStop
            // 
            this.butStop.Enabled = false;
            this.butStop.Location = new System.Drawing.Point(124, 147);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(76, 25);
            this.butStop.TabIndex = 1;
            this.butStop.Text = "Stop";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            // 
            // tabControlInfo
            // 
            this.tabControlInfo.Controls.Add(this.tabGeneral);
            this.tabControlInfo.Controls.Add(this.tabInfo);
            this.tabControlInfo.Controls.Add(this.tabAlert);
            this.tabControlInfo.Location = new System.Drawing.Point(224, 2);
            this.tabControlInfo.Multiline = true;
            this.tabControlInfo.Name = "tabControlInfo";
            this.tabControlInfo.SelectedIndex = 0;
            this.tabControlInfo.Size = new System.Drawing.Size(398, 229);
            this.tabControlInfo.TabIndex = 12;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.labAutoRefreshMin);
            this.tabGeneral.Controls.Add(this.numAutoRefreshMin);
            this.tabGeneral.Controls.Add(this.checkAutoRefresh);
            this.tabGeneral.Controls.Add(this.butSwitchPlanet);
            this.tabGeneral.Controls.Add(this.comboChosenPlanet);
            this.tabGeneral.Controls.Add(this.butRefresh);
            this.tabGeneral.Controls.Add(this.labPlanetCoordsValue);
            this.tabGeneral.Controls.Add(this.labPlanetNameValue);
            this.tabGeneral.Controls.Add(this.labPlanetIdValue);
            this.tabGeneral.Controls.Add(this.labPlanetCoords);
            this.tabGeneral.Controls.Add(this.labPlanetName);
            this.tabGeneral.Controls.Add(this.labPlanetId);
            this.tabGeneral.Controls.Add(this.labDMValue);
            this.tabGeneral.Controls.Add(this.picMetal);
            this.tabGeneral.Controls.Add(this.labEnergyValue);
            this.tabGeneral.Controls.Add(this.picCrystal);
            this.tabGeneral.Controls.Add(this.labDeutValue);
            this.tabGeneral.Controls.Add(this.picDeut);
            this.tabGeneral.Controls.Add(this.labCrystalValue);
            this.tabGeneral.Controls.Add(this.picEnergy);
            this.tabGeneral.Controls.Add(this.labMetalValue);
            this.tabGeneral.Controls.Add(this.picDM);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(390, 203);
            this.tabGeneral.TabIndex = 15;
            this.tabGeneral.Text = "Planet";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // labAutoRefreshMin
            // 
            this.labAutoRefreshMin.AutoSize = true;
            this.labAutoRefreshMin.Location = new System.Drawing.Point(354, 175);
            this.labAutoRefreshMin.Name = "labAutoRefreshMin";
            this.labAutoRefreshMin.Size = new System.Drawing.Size(27, 13);
            this.labAutoRefreshMin.TabIndex = 36;
            this.labAutoRefreshMin.Text = "Min.";
            // 
            // numAutoRefreshMin
            // 
            this.numAutoRefreshMin.Location = new System.Drawing.Point(301, 173);
            this.numAutoRefreshMin.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numAutoRefreshMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAutoRefreshMin.Name = "numAutoRefreshMin";
            this.numAutoRefreshMin.Size = new System.Drawing.Size(47, 20);
            this.numAutoRefreshMin.TabIndex = 35;
            this.numAutoRefreshMin.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numAutoRefreshMin.ValueChanged += new System.EventHandler(this.numAutoRefreshMin_ValueChanged);
            // 
            // checkAutoRefresh
            // 
            this.checkAutoRefresh.AutoSize = true;
            this.checkAutoRefresh.Checked = true;
            this.checkAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoRefresh.Location = new System.Drawing.Point(216, 174);
            this.checkAutoRefresh.Name = "checkAutoRefresh";
            this.checkAutoRefresh.Size = new System.Drawing.Size(88, 17);
            this.checkAutoRefresh.TabIndex = 34;
            this.checkAutoRefresh.Text = "Auto Refresh";
            this.checkAutoRefresh.UseVisualStyleBackColor = true;
            this.checkAutoRefresh.CheckedChanged += new System.EventHandler(this.checkAutoRefresh_CheckedChanged);
            // 
            // butSwitchPlanet
            // 
            this.butSwitchPlanet.Location = new System.Drawing.Point(245, 96);
            this.butSwitchPlanet.Name = "butSwitchPlanet";
            this.butSwitchPlanet.Size = new System.Drawing.Size(75, 23);
            this.butSwitchPlanet.TabIndex = 33;
            this.butSwitchPlanet.Text = "Switch";
            this.butSwitchPlanet.UseVisualStyleBackColor = true;
            this.butSwitchPlanet.Click += new System.EventHandler(this.butSwitchPlanet_Click);
            // 
            // comboChosenPlanet
            // 
            this.comboChosenPlanet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboChosenPlanet.FormattingEnabled = true;
            this.comboChosenPlanet.Location = new System.Drawing.Point(9, 96);
            this.comboChosenPlanet.Name = "comboChosenPlanet";
            this.comboChosenPlanet.Size = new System.Drawing.Size(215, 21);
            this.comboChosenPlanet.TabIndex = 32;
            // 
            // butRefresh
            // 
            this.butRefresh.Location = new System.Drawing.Point(9, 165);
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(201, 32);
            this.butRefresh.TabIndex = 11;
            this.butRefresh.Text = "Refresh";
            this.butRefresh.UseVisualStyleBackColor = true;
            this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
            // 
            // labPlanetCoordsValue
            // 
            this.labPlanetCoordsValue.AutoSize = true;
            this.labPlanetCoordsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPlanetCoordsValue.Location = new System.Drawing.Point(326, 65);
            this.labPlanetCoordsValue.Name = "labPlanetCoordsValue";
            this.labPlanetCoordsValue.Size = new System.Drawing.Size(49, 13);
            this.labPlanetCoordsValue.TabIndex = 16;
            this.labPlanetCoordsValue.Text = "0:000:00";
            // 
            // labPlanetNameValue
            // 
            this.labPlanetNameValue.AutoSize = true;
            this.labPlanetNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPlanetNameValue.Location = new System.Drawing.Point(125, 65);
            this.labPlanetNameValue.Name = "labPlanetNameValue";
            this.labPlanetNameValue.Size = new System.Drawing.Size(35, 13);
            this.labPlanetNameValue.TabIndex = 17;
            this.labPlanetNameValue.Text = "empty";
            // 
            // labPlanetIdValue
            // 
            this.labPlanetIdValue.AutoSize = true;
            this.labPlanetIdValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPlanetIdValue.Location = new System.Drawing.Point(23, 65);
            this.labPlanetIdValue.Name = "labPlanetIdValue";
            this.labPlanetIdValue.Size = new System.Drawing.Size(55, 13);
            this.labPlanetIdValue.TabIndex = 18;
            this.labPlanetIdValue.Text = "00000000";
            // 
            // labPlanetCoords
            // 
            this.labPlanetCoords.AutoSize = true;
            this.labPlanetCoords.Location = new System.Drawing.Point(262, 65);
            this.labPlanetCoords.Name = "labPlanetCoords";
            this.labPlanetCoords.Size = new System.Drawing.Size(66, 13);
            this.labPlanetCoords.TabIndex = 19;
            this.labPlanetCoords.Text = "Coordinates:";
            // 
            // labPlanetName
            // 
            this.labPlanetName.AutoSize = true;
            this.labPlanetName.Location = new System.Drawing.Point(91, 65);
            this.labPlanetName.Name = "labPlanetName";
            this.labPlanetName.Size = new System.Drawing.Size(38, 13);
            this.labPlanetName.TabIndex = 20;
            this.labPlanetName.Text = "Name:";
            // 
            // labPlanetId
            // 
            this.labPlanetId.AutoSize = true;
            this.labPlanetId.Location = new System.Drawing.Point(6, 65);
            this.labPlanetId.Name = "labPlanetId";
            this.labPlanetId.Size = new System.Drawing.Size(21, 13);
            this.labPlanetId.TabIndex = 21;
            this.labPlanetId.Text = "ID:";
            // 
            // labDMValue
            // 
            this.labDMValue.AutoSize = true;
            this.labDMValue.Location = new System.Drawing.Point(317, 43);
            this.labDMValue.MinimumSize = new System.Drawing.Size(67, 0);
            this.labDMValue.Name = "labDMValue";
            this.labDMValue.Size = new System.Drawing.Size(67, 13);
            this.labDMValue.TabIndex = 22;
            this.labDMValue.Text = "000.000.000";
            this.labDMValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picMetal
            // 
            this.picMetal.Image = global::OGameEmptyPlanetFinder.Properties.Resources.resource_metal;
            this.picMetal.Location = new System.Drawing.Point(14, 8);
            this.picMetal.Name = "picMetal";
            this.picMetal.Size = new System.Drawing.Size(48, 32);
            this.picMetal.TabIndex = 23;
            this.picMetal.TabStop = false;
            // 
            // labEnergyValue
            // 
            this.labEnergyValue.AutoSize = true;
            this.labEnergyValue.Location = new System.Drawing.Point(235, 43);
            this.labEnergyValue.MinimumSize = new System.Drawing.Size(67, 0);
            this.labEnergyValue.Name = "labEnergyValue";
            this.labEnergyValue.Size = new System.Drawing.Size(67, 13);
            this.labEnergyValue.TabIndex = 24;
            this.labEnergyValue.Text = "000.000.000";
            this.labEnergyValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picCrystal
            // 
            this.picCrystal.Image = global::OGameEmptyPlanetFinder.Properties.Resources.resource_crystal;
            this.picCrystal.Location = new System.Drawing.Point(94, 8);
            this.picCrystal.Name = "picCrystal";
            this.picCrystal.Size = new System.Drawing.Size(48, 32);
            this.picCrystal.TabIndex = 25;
            this.picCrystal.TabStop = false;
            // 
            // labDeutValue
            // 
            this.labDeutValue.AutoSize = true;
            this.labDeutValue.Location = new System.Drawing.Point(157, 43);
            this.labDeutValue.MinimumSize = new System.Drawing.Size(67, 0);
            this.labDeutValue.Name = "labDeutValue";
            this.labDeutValue.Size = new System.Drawing.Size(67, 13);
            this.labDeutValue.TabIndex = 26;
            this.labDeutValue.Text = "000.000.000";
            this.labDeutValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picDeut
            // 
            this.picDeut.Image = global::OGameEmptyPlanetFinder.Properties.Resources.resource_deuterium;
            this.picDeut.Location = new System.Drawing.Point(169, 8);
            this.picDeut.Name = "picDeut";
            this.picDeut.Size = new System.Drawing.Size(48, 32);
            this.picDeut.TabIndex = 27;
            this.picDeut.TabStop = false;
            // 
            // labCrystalValue
            // 
            this.labCrystalValue.AutoSize = true;
            this.labCrystalValue.Location = new System.Drawing.Point(84, 43);
            this.labCrystalValue.MinimumSize = new System.Drawing.Size(67, 0);
            this.labCrystalValue.Name = "labCrystalValue";
            this.labCrystalValue.Size = new System.Drawing.Size(67, 13);
            this.labCrystalValue.TabIndex = 28;
            this.labCrystalValue.Text = "000.000.000";
            this.labCrystalValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picEnergy
            // 
            this.picEnergy.Image = global::OGameEmptyPlanetFinder.Properties.Resources.resource_energy;
            this.picEnergy.Location = new System.Drawing.Point(245, 8);
            this.picEnergy.Name = "picEnergy";
            this.picEnergy.Size = new System.Drawing.Size(48, 32);
            this.picEnergy.TabIndex = 29;
            this.picEnergy.TabStop = false;
            // 
            // labMetalValue
            // 
            this.labMetalValue.AutoSize = true;
            this.labMetalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMetalValue.Location = new System.Drawing.Point(6, 43);
            this.labMetalValue.MinimumSize = new System.Drawing.Size(67, 0);
            this.labMetalValue.Name = "labMetalValue";
            this.labMetalValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labMetalValue.Size = new System.Drawing.Size(67, 13);
            this.labMetalValue.TabIndex = 30;
            this.labMetalValue.Text = "000.000.000";
            this.labMetalValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picDM
            // 
            this.picDM.Image = global::OGameEmptyPlanetFinder.Properties.Resources.resource_DM;
            this.picDM.Location = new System.Drawing.Point(327, 8);
            this.picDM.Name = "picDM";
            this.picDM.Size = new System.Drawing.Size(48, 32);
            this.picDM.TabIndex = 31;
            this.picDM.TabStop = false;
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.listInfo);
            this.tabInfo.Location = new System.Drawing.Point(4, 22);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(390, 203);
            this.tabInfo.TabIndex = 32;
            this.tabInfo.Text = "Info";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // listInfo
            // 
            this.listInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDescription,
            this.columnValue});
            this.listInfo.FullRowSelect = true;
            listViewGroup1.Header = "Universe Info";
            listViewGroup1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup1.Name = "listViewGroupUni";
            listViewGroup2.Header = "Player Info";
            listViewGroup2.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup2.Name = "listViewGroupPlayer";
            listViewGroup3.Header = "Alliance Info";
            listViewGroup3.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup3.Name = "listViewGroupAlliance";
            this.listInfo.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            listViewItem1.Group = listViewGroup1;
            listViewItem1.Tag = "";
            listViewItem2.Group = listViewGroup1;
            listViewItem2.Tag = "";
            listViewItem3.Group = listViewGroup1;
            listViewItem3.Tag = "";
            listViewItem4.Group = listViewGroup2;
            listViewItem4.Tag = "";
            listViewItem5.Group = listViewGroup2;
            listViewItem5.Tag = "";
            listViewItem6.Group = listViewGroup3;
            listViewItem6.Tag = "";
            listViewItem7.Group = listViewGroup3;
            listViewItem7.Tag = "";
            listViewItem8.Group = listViewGroup3;
            listViewItem8.Tag = "";
            this.listInfo.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
            this.listInfo.Location = new System.Drawing.Point(0, 0);
            this.listInfo.Name = "listInfo";
            this.listInfo.Size = new System.Drawing.Size(392, 204);
            this.listInfo.TabIndex = 33;
            this.listInfo.UseCompatibleStateImageBehavior = false;
            this.listInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "Description";
            this.columnDescription.Width = 100;
            // 
            // columnValue
            // 
            this.columnValue.Text = "Value";
            this.columnValue.Width = 250;
            // 
            // tabAlert
            // 
            this.tabAlert.Controls.Add(this.butTestStopAlert);
            this.tabAlert.Controls.Add(this.butOpenSoundsFolder);
            this.tabAlert.Controls.Add(this.textAlertSoundsDir);
            this.tabAlert.Controls.Add(this.checkAlertSounds);
            this.tabAlert.Controls.Add(this.olvFleetMoving);
            this.tabAlert.Controls.Add(this.labAlertStatus);
            this.tabAlert.Controls.Add(this.picAlertStatus);
            this.tabAlert.Location = new System.Drawing.Point(4, 22);
            this.tabAlert.Name = "tabAlert";
            this.tabAlert.Size = new System.Drawing.Size(390, 203);
            this.tabAlert.TabIndex = 33;
            this.tabAlert.Text = "Alert";
            this.tabAlert.UseVisualStyleBackColor = true;
            // 
            // butTestStopAlert
            // 
            this.butTestStopAlert.Location = new System.Drawing.Point(312, 2);
            this.butTestStopAlert.Name = "butTestStopAlert";
            this.butTestStopAlert.Size = new System.Drawing.Size(75, 23);
            this.butTestStopAlert.TabIndex = 42;
            this.butTestStopAlert.Text = "Test Sounds";
            this.butTestStopAlert.UseVisualStyleBackColor = true;
            this.butTestStopAlert.Click += new System.EventHandler(this.butTestStopAlert_Click);
            // 
            // butOpenSoundsFolder
            // 
            this.butOpenSoundsFolder.Font = new System.Drawing.Font("Marlett", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butOpenSoundsFolder.Location = new System.Drawing.Point(351, 39);
            this.butOpenSoundsFolder.Name = "butOpenSoundsFolder";
            this.butOpenSoundsFolder.Size = new System.Drawing.Size(36, 23);
            this.butOpenSoundsFolder.TabIndex = 41;
            this.butOpenSoundsFolder.Text = "...";
            this.butOpenSoundsFolder.UseVisualStyleBackColor = true;
            this.butOpenSoundsFolder.Click += new System.EventHandler(this.butOpenSoundsFolder_Click);
            // 
            // textAlertSoundsDir
            // 
            this.textAlertSoundsDir.Location = new System.Drawing.Point(110, 41);
            this.textAlertSoundsDir.Name = "textAlertSoundsDir";
            this.textAlertSoundsDir.Size = new System.Drawing.Size(235, 20);
            this.textAlertSoundsDir.TabIndex = 40;
            // 
            // checkAlertSounds
            // 
            this.checkAlertSounds.AutoSize = true;
            this.checkAlertSounds.Location = new System.Drawing.Point(65, 43);
            this.checkAlertSounds.Name = "checkAlertSounds";
            this.checkAlertSounds.Size = new System.Drawing.Size(47, 17);
            this.checkAlertSounds.TabIndex = 39;
            this.checkAlertSounds.Text = "Alert";
            this.checkAlertSounds.UseVisualStyleBackColor = true;
            this.checkAlertSounds.CheckedChanged += new System.EventHandler(this.checkAlertSounds_CheckedChanged);
            // 
            // olvFleetMoving
            // 
            this.olvFleetMoving.AllColumns.Add(this.olvColumnMission);
            this.olvFleetMoving.AllColumns.Add(this.olvColumnArrivalTime);
            this.olvFleetMoving.AllColumns.Add(this.olvColumnOrigin);
            this.olvFleetMoving.AllColumns.Add(this.olvColumnFleet);
            this.olvFleetMoving.AllColumns.Add(this.olvColumnTarget);
            this.olvFleetMoving.AllColumns.Add(this.olvColumnReturns);
            this.olvFleetMoving.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnMission,
            this.olvColumnArrivalTime,
            this.olvColumnOrigin,
            this.olvColumnFleet,
            this.olvColumnTarget,
            this.olvColumnReturns});
            this.olvFleetMoving.FullRowSelect = true;
            this.olvFleetMoving.GridLines = true;
            this.olvFleetMoving.Location = new System.Drawing.Point(0, 66);
            this.olvFleetMoving.Name = "olvFleetMoving";
            this.olvFleetMoving.ShowGroups = false;
            this.olvFleetMoving.Size = new System.Drawing.Size(387, 137);
            this.olvFleetMoving.TabIndex = 38;
            this.olvFleetMoving.UseCompatibleStateImageBehavior = false;
            this.olvFleetMoving.View = System.Windows.Forms.View.Details;
            this.olvFleetMoving.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olvFleetMoving_FormatRow);
            this.olvFleetMoving.DoubleClick += new System.EventHandler(this.olvFleetMoving_DoubleClick);
            // 
            // olvColumnMission
            // 
            this.olvColumnMission.AspectName = "Mission";
            this.olvColumnMission.CellPadding = null;
            this.olvColumnMission.Text = "Mission";
            this.olvColumnMission.Width = 57;
            // 
            // olvColumnArrivalTime
            // 
            this.olvColumnArrivalTime.AspectName = "ArrivalTime";
            this.olvColumnArrivalTime.CellPadding = null;
            this.olvColumnArrivalTime.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnArrivalTime.Text = "Arrival Time";
            this.olvColumnArrivalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnArrivalTime.Width = 112;
            // 
            // olvColumnOrigin
            // 
            this.olvColumnOrigin.AspectName = "Origin";
            this.olvColumnOrigin.CellPadding = null;
            this.olvColumnOrigin.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnOrigin.Hideable = false;
            this.olvColumnOrigin.Text = "Origin";
            this.olvColumnOrigin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnOrigin.Width = 55;
            // 
            // olvColumnFleet
            // 
            this.olvColumnFleet.AspectName = "Fleet";
            this.olvColumnFleet.CellPadding = null;
            this.olvColumnFleet.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnFleet.Hideable = false;
            this.olvColumnFleet.Text = "Fleet";
            this.olvColumnFleet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnFleet.ToolTipText = "";
            this.olvColumnFleet.Width = 55;
            // 
            // olvColumnTarget
            // 
            this.olvColumnTarget.AspectName = "Target";
            this.olvColumnTarget.CellPadding = null;
            this.olvColumnTarget.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnTarget.Hideable = false;
            this.olvColumnTarget.Text = "Target";
            this.olvColumnTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnTarget.Width = 55;
            // 
            // olvColumnReturns
            // 
            this.olvColumnReturns.AspectName = "FleetReturns";
            this.olvColumnReturns.CellPadding = null;
            this.olvColumnReturns.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnReturns.Text = "Returns";
            this.olvColumnReturns.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumnReturns.Width = 50;
            // 
            // labAlertStatus
            // 
            this.labAlertStatus.AutoSize = true;
            this.labAlertStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labAlertStatus.ForeColor = System.Drawing.Color.MediumBlue;
            this.labAlertStatus.Location = new System.Drawing.Point(65, 5);
            this.labAlertStatus.Name = "labAlertStatus";
            this.labAlertStatus.Size = new System.Drawing.Size(68, 20);
            this.labAlertStatus.TabIndex = 37;
            this.labAlertStatus.Text = "Standby";
            // 
            // picAlertStatus
            // 
            this.picAlertStatus.Location = new System.Drawing.Point(5, 5);
            this.picAlertStatus.Name = "picAlertStatus";
            this.picAlertStatus.Size = new System.Drawing.Size(54, 55);
            this.picAlertStatus.TabIndex = 0;
            this.picAlertStatus.TabStop = false;
            // 
            // bgWorkerSearchPlanis
            // 
            this.bgWorkerSearchPlanis.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerSearchPlanis_DoWork);
            this.bgWorkerSearchPlanis.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerSearchPlanis_RunWorkerCompleted);
            // 
            // butCopyPlanets
            // 
            this.butCopyPlanets.Enabled = false;
            this.butCopyPlanets.Location = new System.Drawing.Point(244, 224);
            this.butCopyPlanets.Name = "butCopyPlanets";
            this.butCopyPlanets.Size = new System.Drawing.Size(151, 23);
            this.butCopyPlanets.TabIndex = 34;
            this.butCopyPlanets.Text = "Copy Planets to Clipboard";
            this.butCopyPlanets.UseVisualStyleBackColor = true;
            this.butCopyPlanets.Click += new System.EventHandler(this.butCopyPlanets_Click);
            // 
            // checkPlanetsCoordsTags
            // 
            this.checkPlanetsCoordsTags.AutoSize = true;
            this.checkPlanetsCoordsTags.Enabled = false;
            this.checkPlanetsCoordsTags.Location = new System.Drawing.Point(401, 228);
            this.checkPlanetsCoordsTags.Name = "checkPlanetsCoordsTags";
            this.checkPlanetsCoordsTags.Size = new System.Drawing.Size(89, 17);
            this.checkPlanetsCoordsTags.TabIndex = 35;
            this.checkPlanetsCoordsTags.Text = "OGame Tags";
            this.checkPlanetsCoordsTags.UseVisualStyleBackColor = true;
            // 
            // labSearchEngine
            // 
            this.labSearchEngine.AutoSize = true;
            this.labSearchEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSearchEngine.ForeColor = System.Drawing.Color.MediumBlue;
            this.labSearchEngine.Location = new System.Drawing.Point(9, 238);
            this.labSearchEngine.Name = "labSearchEngine";
            this.labSearchEngine.Size = new System.Drawing.Size(118, 20);
            this.labSearchEngine.TabIndex = 36;
            this.labSearchEngine.Text = "Search Engine:";
            // 
            // labSEStatus
            // 
            this.labSEStatus.AutoSize = true;
            this.labSEStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSEStatus.Location = new System.Drawing.Point(150, 239);
            this.labSEStatus.Name = "labSEStatus";
            this.labSEStatus.Size = new System.Drawing.Size(62, 17);
            this.labSEStatus.TabIndex = 32;
            this.labSEStatus.Text = "Waiting";
            // 
            // listDF
            // 
            this.listDF.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeadDFCoords,
            this.colHeadDFMetal,
            this.colHeadDFCrys,
            this.colHeadDFRecs});
            this.listDF.FullRowSelect = true;
            this.listDF.GridLines = true;
            this.listDF.Location = new System.Drawing.Point(0, 3);
            this.listDF.Name = "listDF";
            this.listDF.Size = new System.Drawing.Size(364, 250);
            this.listDF.TabIndex = 38;
            this.listDF.UseCompatibleStateImageBehavior = false;
            this.listDF.View = System.Windows.Forms.View.Details;
            // 
            // colHeadDFCoords
            // 
            this.colHeadDFCoords.Text = "Coordinates";
            this.colHeadDFCoords.Width = 80;
            // 
            // colHeadDFMetal
            // 
            this.colHeadDFMetal.Text = "Metal";
            this.colHeadDFMetal.Width = 100;
            // 
            // colHeadDFCrys
            // 
            this.colHeadDFCrys.Text = "Crystal";
            this.colHeadDFCrys.Width = 100;
            // 
            // colHeadDFRecs
            // 
            this.colHeadDFRecs.Text = "Recs";
            this.colHeadDFRecs.Width = 75;
            // 
            // numMinDF
            // 
            this.numMinDF.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMinDF.Location = new System.Drawing.Point(511, 6);
            this.numMinDF.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numMinDF.Name = "numMinDF";
            this.numMinDF.Size = new System.Drawing.Size(99, 20);
            this.numMinDF.TabIndex = 39;
            this.numMinDF.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // labMinDFRes
            // 
            this.labMinDFRes.AutoSize = true;
            this.labMinDFRes.Location = new System.Drawing.Point(367, 8);
            this.labMinDFRes.Name = "labMinDFRes";
            this.labMinDFRes.Size = new System.Drawing.Size(142, 13);
            this.labMinDFRes.TabIndex = 40;
            this.labMinDFRes.Text = "Min. Debris Field Resources:";
            // 
            // tabControlSearchList
            // 
            this.tabControlSearchList.Controls.Add(this.tabPageFreePlanets);
            this.tabControlSearchList.Controls.Add(this.tabPageDF);
            this.tabControlSearchList.Location = new System.Drawing.Point(4, 258);
            this.tabControlSearchList.Name = "tabControlSearchList";
            this.tabControlSearchList.SelectedIndex = 0;
            this.tabControlSearchList.Size = new System.Drawing.Size(624, 279);
            this.tabControlSearchList.TabIndex = 100;
            // 
            // tabPageFreePlanets
            // 
            this.tabPageFreePlanets.Controls.Add(this.groupSearchOptions);
            this.tabPageFreePlanets.Controls.Add(this.listFreePlanets);
            this.tabPageFreePlanets.Controls.Add(this.butCopyPlanets);
            this.tabPageFreePlanets.Controls.Add(this.checkPlanetsCoordsTags);
            this.tabPageFreePlanets.Location = new System.Drawing.Point(4, 22);
            this.tabPageFreePlanets.Name = "tabPageFreePlanets";
            this.tabPageFreePlanets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFreePlanets.Size = new System.Drawing.Size(616, 253);
            this.tabPageFreePlanets.TabIndex = 0;
            this.tabPageFreePlanets.Text = "Planets";
            this.tabPageFreePlanets.UseVisualStyleBackColor = true;
            // 
            // groupSearchOptions
            // 
            this.groupSearchOptions.Controls.Add(this.radioSearchDestroyed);
            this.groupSearchOptions.Controls.Add(this.radioSearchEmpty);
            this.groupSearchOptions.Controls.Add(this.radioSearchAll);
            this.groupSearchOptions.Location = new System.Drawing.Point(242, 4);
            this.groupSearchOptions.Name = "groupSearchOptions";
            this.groupSearchOptions.Size = new System.Drawing.Size(373, 85);
            this.groupSearchOptions.TabIndex = 37;
            this.groupSearchOptions.TabStop = false;
            this.groupSearchOptions.Text = "Search Options";
            // 
            // radioSearchDestroyed
            // 
            this.radioSearchDestroyed.AutoSize = true;
            this.radioSearchDestroyed.Location = new System.Drawing.Point(110, 20);
            this.radioSearchDestroyed.Name = "radioSearchDestroyed";
            this.radioSearchDestroyed.Size = new System.Drawing.Size(73, 17);
            this.radioSearchDestroyed.TabIndex = 2;
            this.radioSearchDestroyed.Text = "Destroyed";
            this.radioSearchDestroyed.UseVisualStyleBackColor = true;
            this.radioSearchDestroyed.CheckedChanged += new System.EventHandler(this.radioSearchDestroyed_CheckedChanged);
            // 
            // radioSearchEmpty
            // 
            this.radioSearchEmpty.AutoSize = true;
            this.radioSearchEmpty.Location = new System.Drawing.Point(50, 20);
            this.radioSearchEmpty.Name = "radioSearchEmpty";
            this.radioSearchEmpty.Size = new System.Drawing.Size(54, 17);
            this.radioSearchEmpty.TabIndex = 1;
            this.radioSearchEmpty.Text = "Empty";
            this.radioSearchEmpty.UseVisualStyleBackColor = true;
            this.radioSearchEmpty.CheckedChanged += new System.EventHandler(this.radioSearchEmpty_CheckedChanged);
            // 
            // radioSearchAll
            // 
            this.radioSearchAll.AutoSize = true;
            this.radioSearchAll.Checked = true;
            this.radioSearchAll.Location = new System.Drawing.Point(8, 20);
            this.radioSearchAll.Name = "radioSearchAll";
            this.radioSearchAll.Size = new System.Drawing.Size(36, 17);
            this.radioSearchAll.TabIndex = 0;
            this.radioSearchAll.TabStop = true;
            this.radioSearchAll.Text = "All";
            this.radioSearchAll.UseVisualStyleBackColor = true;
            this.radioSearchAll.CheckedChanged += new System.EventHandler(this.radioSearchAll_CheckedChanged);
            // 
            // tabPageDF
            // 
            this.tabPageDF.Controls.Add(this.checkDebrisCoordsTags);
            this.tabPageDF.Controls.Add(this.butCopyDebris);
            this.tabPageDF.Controls.Add(this.labMinDFRes);
            this.tabPageDF.Controls.Add(this.listDF);
            this.tabPageDF.Controls.Add(this.numMinDF);
            this.tabPageDF.Location = new System.Drawing.Point(4, 22);
            this.tabPageDF.Name = "tabPageDF";
            this.tabPageDF.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDF.Size = new System.Drawing.Size(616, 253);
            this.tabPageDF.TabIndex = 1;
            this.tabPageDF.Text = "Debris";
            this.tabPageDF.UseVisualStyleBackColor = true;
            // 
            // checkDebrisCoordsTags
            // 
            this.checkDebrisCoordsTags.AutoSize = true;
            this.checkDebrisCoordsTags.Enabled = false;
            this.checkDebrisCoordsTags.Location = new System.Drawing.Point(524, 228);
            this.checkDebrisCoordsTags.Name = "checkDebrisCoordsTags";
            this.checkDebrisCoordsTags.Size = new System.Drawing.Size(89, 17);
            this.checkDebrisCoordsTags.TabIndex = 42;
            this.checkDebrisCoordsTags.Text = "OGame Tags";
            this.checkDebrisCoordsTags.UseVisualStyleBackColor = true;
            // 
            // butCopyDebris
            // 
            this.butCopyDebris.Enabled = false;
            this.butCopyDebris.Location = new System.Drawing.Point(370, 224);
            this.butCopyDebris.Name = "butCopyDebris";
            this.butCopyDebris.Size = new System.Drawing.Size(151, 23);
            this.butCopyDebris.TabIndex = 41;
            this.butCopyDebris.Text = "Copy Debris to Clipboard";
            this.butCopyDebris.UseVisualStyleBackColor = true;
            this.butCopyDebris.Click += new System.EventHandler(this.butCopyDebris_Click);
            // 
            // timerAutoRefresh
            // 
            this.timerAutoRefresh.Enabled = true;
            this.timerAutoRefresh.Interval = 300000;
            this.timerAutoRefresh.Tick += new System.EventHandler(this.timerAutoRefresh_Tick);
            // 
            // butBrowser
            // 
            this.butBrowser.Location = new System.Drawing.Point(17, 189);
            this.butBrowser.Name = "butBrowser";
            this.butBrowser.Size = new System.Drawing.Size(183, 32);
            this.butBrowser.TabIndex = 101;
            this.butBrowser.Text = "Browser";
            this.butBrowser.UseVisualStyleBackColor = true;
            this.butBrowser.Click += new System.EventHandler(this.butBrowser_Click);
            // 
            // backWorkRefresh
            // 
            this.backWorkRefresh.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorkRefresh_DoWork);
            this.backWorkRefresh.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backWorkRefresh_RunWorkerCompleted);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.cmsTrayIcon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            // 
            // cmsTrayIcon
            // 
            this.cmsTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.cmsTrayIcon.Name = "cmsTrayIcon";
            this.cmsTrayIcon.Size = new System.Drawing.Size(100, 48);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemSettings});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Enabled = false;
            this.menuItemFile.Index = 0;
            this.menuItemFile.Text = "File";
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Enabled = false;
            this.menuItemSettings.Index = 1;
            this.menuItemSettings.Text = "Settings";
            // 
            // fbdAlertSounds
            // 
            this.fbdAlertSounds.Description = "Choose the sounds location...";
            // 
            // FinderForm
            // 
            this.AcceptButton = this.butSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 562);
            this.Controls.Add(this.butBrowser);
            this.Controls.Add(this.labSEStatus);
            this.Controls.Add(this.labSearchEngine);
            this.Controls.Add(this.butStop);
            this.Controls.Add(this.butSearch);
            this.Controls.Add(this.labCopyright);
            this.Controls.Add(this.groupSearchRange);
            this.Controls.Add(this.tabControlInfo);
            this.Controls.Add(this.tabControlSearchList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mainMenu;
            this.Name = "FinderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FinderForm_FormClosing);
            this.Load += new System.EventHandler(this.FinderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numGalaxyStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSunSysStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlanetStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGalaxyStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSunSysStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlanetStop)).EndInit();
            this.groupSearchRange.ResumeLayout(false);
            this.groupSearchRange.PerformLayout();
            this.tabControlInfo.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoRefreshMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMetal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCrystal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDeut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnergy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDM)).EndInit();
            this.tabInfo.ResumeLayout(false);
            this.tabAlert.ResumeLayout(false);
            this.tabAlert.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvFleetMoving)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAlertStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinDF)).EndInit();
            this.tabControlSearchList.ResumeLayout(false);
            this.tabPageFreePlanets.ResumeLayout(false);
            this.tabPageFreePlanets.PerformLayout();
            this.groupSearchOptions.ResumeLayout(false);
            this.groupSearchOptions.PerformLayout();
            this.tabPageDF.ResumeLayout(false);
            this.tabPageDF.PerformLayout();
            this.cmsTrayIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labCopyright;
        private ListView listFreePlanets;
        private NumericUpDown numGalaxyStart;
        private NumericUpDown numSunSysStart;
        private NumericUpDown numPlanetStart;
        private NumericUpDown numGalaxyStop;
        private NumericUpDown numSunSysStop;
        private NumericUpDown numPlanetStop;
        private Label labGalaxy;
        private Label labSunSys;
        private Label labPlanet;
        private Label labTo1;
        private Label labTo2;
        private Label labTo3;
        private GroupBox groupSearchRange;
        private Button butSearch;
        private Button butStop;
        private TabControl tabControlInfo;
        private TabPage tabGeneral;
        private Label labDMValue;
        private PictureBox picMetal;
        private Label labEnergyValue;
        private PictureBox picCrystal;
        private Label labDeutValue;
        private PictureBox picDeut;
        private Label labCrystalValue;
        private PictureBox picEnergy;
        private Label labMetalValue;
        private PictureBox picDM;
        private TabPage tabInfo;
        private ListView listInfo;
        private ColumnHeader columnDescription;
        private ColumnHeader columnValue;
        private BackgroundWorker bgWorkerSearchPlanis;
        private Label labPlanetId;
        private Label labPlanetName;
        private Label labPlanetCoords;
        private Label labPlanetIdValue;
        private Label labPlanetNameValue;
        private Label labPlanetCoordsValue;
        private ColumnHeader colHeaderCoords;
        private Button butRefresh;
        private Button butCopyPlanets;
        private CheckBox checkPlanetsCoordsTags;
        private ColumnHeader colHeaderStatus;
        private Label labSearchEngine;
        private Label labSEStatus;
        private ListView listDF;
        private ColumnHeader colHeadDFCoords;
        private ColumnHeader colHeadDFMetal;
        private ColumnHeader colHeadDFCrys;
        private Label labMinDFRes;
        private ColumnHeader colHeadDFRecs;
        private TabControl tabControlSearchList;
        private TabPage tabPageDF;
        private TabPage tabPageFreePlanets;
        private GroupBox groupSearchOptions;
        private RadioButton radioSearchAll;
        private RadioButton radioSearchEmpty;
        private RadioButton radioSearchDestroyed;
        private Button butCopyDebris;
        private ComboBox comboChosenPlanet;
        private Button butSwitchPlanet;
        private CheckBox checkDebrisCoordsTags;
        private NumericUpDown numMinDF;
        private CheckBox checkAutoRefresh;
        private Timer timerAutoRefresh;
        private Button butBrowser;
        private NumericUpDown numAutoRefreshMin;
        private Label labAutoRefreshMin;
        private BackgroundWorker backWorkRefresh;
        private TabPage tabAlert;
        private PictureBox picAlertStatus;
        private Label labAlertStatus;
        private ObjectListView olvFleetMoving;
        private OLVColumn olvColumnOrigin;
        private OLVColumn olvColumnFleet;
        private OLVColumn olvColumnTarget;
        private OLVColumn olvColumnMission;
        private OLVColumn olvColumnArrivalTime;
        private OLVColumn olvColumnReturns;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip cmsTrayIcon;
        private ToolStripMenuItem hideToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private MainMenu mainMenu;
        private MenuItem menuItemFile;
        private MenuItem menuItemSettings;
        private CheckBox checkAlertSounds;
        private Button butOpenSoundsFolder;
        private TextBox textAlertSoundsDir;
        private FolderBrowserDialog fbdAlertSounds;
        private Button butTestStopAlert;
    }
}