using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BrightIdeasSoftware;
using NLog;
using OGameEmptyPlanetFinder.Autoplay;
using OGameEmptyPlanetFinder.GUI;
using OGameEmptyPlanetFinder.HTTP;
using OGameEmptyPlanetFinder.OGame;
using OGameEmptyPlanetFinder.OGame.Exceptions;
using OGameEmptyPlanetFinder.Settings;

namespace OGameEmptyPlanetFinder
{
    public partial class FinderForm : Form
    {
        public static class ListViewItemConst
        {
            public static readonly string UNIVERSE_ID = "UniverseID";
            public static readonly string UNIVERSE_NAME = "UniverseName";
            public static readonly string UNIVERSE_SPEED = "UniverseSpeed";
            public static readonly string PLAYER_ID = "PlayerID";
            public static readonly string PLAYER_NAME = "PlayerName";
            public static readonly string ALLIANCE_ID = "AllianceID";
            public static readonly string ALLIANCE_TAG = "AllianceTag";
            public static readonly string ALLIANCE_NAME = "AllianceName";
        }

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static string APPLICATION_DIRACTORY = Path.GetDirectoryName(Application.ExecutablePath);
        private static string DEFAULT_ALERT_DIRACTORY = APPLICATION_DIRACTORY + "\\data";

        private PlayForMe playForMeBot = new PlayForMe();
        private AlertVisualManager alertPictureManager = new AlertVisualManager();

        private DateTime CurrentTime { get; set; }
        private string choisenPlanet = "";
        private SearchChoise searchChoise = SearchChoise.All;
        private bool isRefreshing;
        private bool soundPlaying;

        public FinderForm()
        {
            InitializeComponent();
            Text = LoginForm.CURRENT_VERSION_NAME + Text;
            notifyIcon.Text = LoginForm.CURRENT_VERSION_NAME;
            textAlertSoundsDir.Text = DEFAULT_ALERT_DIRACTORY;
            InitializeFleetMoveListView();
            
        }

        private void FinderForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            if (HTTPConnectionManager.Instance.LoginIntoGameAccount())
            {
                fillPlanetInfos();
                fillInfoListView();
                fillPlanetsChoiser();
                loadSettings();
                setTimerInMin(timerAutoRefresh, (int)numAutoRefreshMin.Value);
                refreshFleetMoving();
            }
            else
            {
                MessageBox.Show("Failed to login into the game account!", "Error");
            }
        }

        private void InitializeFleetMoveListView()
        {
            olvColumnMission.AspectToStringConverter = x => Enum.GetName(typeof(MissionType), (MissionType) x);
            olvColumnArrivalTime.AspectToStringConverter = x => ((DateTime) x).ToString();
        }

        private void refreshFleetMoving()
        {
            if (HTTPConnectionManager.Instance.CheckFleetMoving() > 0)
            {
                olvFleetMoving.SetObjects(PlayerInfo.Instance.FleetMove);
                bool isForeign = FleetMove.isEnemyPresence(PlayerInfo.Instance.FleetMove);
                if (isForeign)
                {
                    tabControlInfo.SelectTab(2);
                    Show();
                    if (checkAlertSounds.Checked)
                    {
                        ToggleRandomAlertSound();
                    }
                }
                alertPictureManager.setStatus(labAlertStatus, picAlertStatus, FleetMove.getMostImportantMission(PlayerInfo.Instance.FleetMove), 
                    MissionPictureStatus.Normal, isForeign);
            }
            else
            {
                alertPictureManager.setStatus(labAlertStatus, picAlertStatus, MissionType.Expedition, MissionPictureStatus.Disabled, false);
            }
        }

        private void ToggleRandomAlertSound()
        {
            if (soundPlaying)
            {
                playForMeBot.GetAlertManager().Stop();
                soundPlaying = false;
                butTestStopAlert.Text = "Test Sounds";
            }
            else
            {
                if (PlaySound())
                {
                    butTestStopAlert.Text = "Stop Sound";
                }
            }
        }

        private bool PlaySound()
        {
            bool result = false;
            if (Directory.Exists(textAlertSoundsDir.Text))
            {
                try
                {
                    playForMeBot.GetAlertManager().PlayRandomSound(textAlertSoundsDir.Text);
                    result = true;
                    soundPlaying = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    Logger.Error(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("The chosen Sound directory does not exist!", "Error");
            }
            return result;
        }

        private void fillPlanetInfos()
        {
            try
            {
                ResourceEntity resources = PlayerInfo.Instance.Resources;
                labMetalValue.Text = $"{resources.Metal:0,0}";
                labCrystalValue.Text = $"{resources.Crystal:0,0}";
                labDeutValue.Text = $"{resources.Deuterium:0,0}";
                labEnergyValue.Text = $"{resources.Energy:0,0}";
                labDMValue.Text = $"{resources.DarkMatter:0,0}";
                PlanetEntity planet = PlayerInfo.Instance.CurrentPlanet;
                labPlanetIdValue.Text = planet.PlanetID;
                labPlanetNameValue.Text = planet.PlanetName;
                labPlanetCoordsValue.Text = planet.Coordinates.ToString();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "fillPlanetInfos failed");
                MessageBox.Show(ex.Message, "Error on fillPlanetInfos");
            }
        }

        private void fillInfoListView()
        {
            try
            {
                searchAndAddSubItem(0, PlayerInfo.Instance.UniverseID);
                searchAndAddSubItem(1, PlayerInfo.Instance.UniverseName);
                searchAndAddSubItem(2, PlayerInfo.Instance.UniverseSpeed);
                searchAndAddSubItem(3, PlayerInfo.Instance.PlayerID);
                searchAndAddSubItem(4, PlayerInfo.Instance.PlayerName);
                searchAndAddSubItem(5, PlayerInfo.Instance.AllianceID);
                searchAndAddSubItem(6, PlayerInfo.Instance.AllianceTag);
                searchAndAddSubItem(7, PlayerInfo.Instance.AllianceName);               
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "fillInfoListView failed");
            }            
        }

        private void fillPlanetsChoiser()
        {
            try
            {
                int indexBackUp = comboChosenPlanet.SelectedIndex;
                List<ComboboxItem> comboboxItems = new List<ComboboxItem>();
                foreach (PlanetEntity planet in PlayerInfo.Instance.Planets)
                {
                    comboboxItems.Add(new ComboboxItem(planet.PlanetName + " [" + planet.Coordinates + "]", planet.PlanetID));
                }
                if (comboboxItems != null && comboboxItems.Count > 0)
                {
                    if (comboChosenPlanet.Items.Count > 0)
                    {
                        comboChosenPlanet.Items.Clear();
                    }
                    comboChosenPlanet.Items.AddRange(comboboxItems.ToArray());
                    comboChosenPlanet.SelectedIndex = (indexBackUp < 0) ? 0 : (indexBackUp > comboboxItems.Count) ? 0 : indexBackUp;
                    choisenPlanet = comboChosenPlanet.Text;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "fillPlanetsChoiser failed");
            } 
        }

        private void searchAndAddSubItem(int index, string value)
        {
            try 
            {
                listInfo.Items[index].SubItems.Add(value);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "searchAndAddSubItem failed");
            }
        }

        private void numGalaxyStart_ValueChanged(object sender, EventArgs e)
        {
            FinderFormCommons.reverseOnMaxAndBack((NumericUpDown)sender);
            FinderFormCommons.smallerThan((NumericUpDown)sender, numGalaxyStop);
        }

        private void numGalaxyStop_ValueChanged(object sender, EventArgs e)
        {
            FinderFormCommons.reverseOnMaxAndBack((NumericUpDown)sender);
            FinderFormCommons.biggerThan(numGalaxyStart, (NumericUpDown)sender);
        }

        private void numSunSysStart_ValueChanged(object sender, EventArgs e)
        {
            FinderFormCommons.reverseOnMaxAndBack((NumericUpDown)sender);
            FinderFormCommons.smallerThan((NumericUpDown)sender, numSunSysStop);
        }

        private void numSunSysStop_ValueChanged(object sender, EventArgs e)
        {
            FinderFormCommons.reverseOnMaxAndBack((NumericUpDown)sender);
            FinderFormCommons.biggerThan(numSunSysStart, (NumericUpDown)sender);
        }

        private void numPlanetStart_ValueChanged(object sender, EventArgs e)
        {
            FinderFormCommons.reverseOnMaxAndBack((NumericUpDown)sender);
            FinderFormCommons.smallerThan((NumericUpDown)sender, numPlanetStop);
        }

        private void numPlanetStop_ValueChanged(object sender, EventArgs e)
        {
            FinderFormCommons.reverseOnMaxAndBack((NumericUpDown)sender);
            FinderFormCommons.biggerThan(numPlanetStart, (NumericUpDown)sender);
        }
        
        private void butSearch_Click(object sender, EventArgs e)
        {
            Coordinates[] coordinates = { 
                new Coordinates((int)numGalaxyStart.Value, (int)numSunSysStart.Value, (int)numPlanetStart.Value), 
                new Coordinates((int)numGalaxyStop.Value, (int)numSunSysStop.Value, (int)numPlanetStop.Value) 
            };
            if ((coordinates[0].differenceTo(coordinates[1])*10) <= PlayerInfo.Instance.Resources.Deuterium)
            {
                try
                {
                    bgWorkerSearchPlanis.RunWorkerAsync(coordinates);
                    searchEnabled(false);
                    labSEStatus.Text = "Searching...";
                    labSEStatus.ForeColor = Color.SteelBlue;
                    if (listFreePlanets.Items.Count > 0)
                    {
                        listFreePlanets.Items.Clear();
                    }
                    if (listDF.Items.Count > 0)
                    {
                        listDF.Items.Clear();
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "butSearch_Click failed");
                    MessageBox.Show("Can not start the Search process", "Error");
                }
            }
            else
            {
                MessageBox.Show("You have not enough Deuterium to do this search!", "Warning!");
            }
        }

        private void butStop_Click(object sender, EventArgs e)
        {
            try
            {
                HTTPConnectionManager.Instance.StopThread();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "butStop_Click");
                MessageBox.Show("Can not stop the Search process.", "Error");
            }
        }

        private void searchEnabled(bool isEnabled)
        {
            butSearch.Enabled = isEnabled;
            butRefresh.Enabled = isEnabled;
            butStop.Enabled = !isEnabled;
            /*numGalaxyStart.Enabled = isEnabled;
            numSunSysStart.Enabled = isEnabled;
            numPlanetStart.Enabled = isEnabled;
            numGalaxyStop.Enabled = isEnabled;
            numSunSysStop.Enabled = isEnabled;
            numPlanetStop.Enabled = isEnabled;*/
            enableCopyPlanets(isEnabled);
            enableCopyDF(isEnabled);
            numMinDF.Enabled = isEnabled;
            groupSearchRange.Enabled = isEnabled;
            groupSearchOptions.Enabled = isEnabled;
            comboChosenPlanet.Enabled = isEnabled;
            butSwitchPlanet.Enabled = isEnabled;
            checkAutoRefresh.Enabled = isEnabled;
            butBrowser.Enabled = isEnabled;
        }

        private void enableCopyPlanets(bool isEnabled)
        {
            butCopyPlanets.Enabled = isEnabled;
            checkPlanetsCoordsTags.Enabled = isEnabled;
        }

        private void enableCopyDF(bool isEnabled)
        {
            butCopyDebris.Enabled = isEnabled;
            checkDebrisCoordsTags.Enabled = isEnabled;
        }

        private void FinderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
            HTTPConnectionManager.Instance.logout();
        }

        private void butRefresh_Click(object sender, EventArgs e)
        {
            refreshGameInfo();
        }

        private void refreshGameInfo()
        {
            string choisenPlanet = (comboChosenPlanet.SelectedIndex > -1) ? ((ComboboxItem)comboChosenPlanet.SelectedItem).Value : "";
            if (!isRefreshing)
            {
                backWorkRefresh.RunWorkerAsync(choisenPlanet);
            }
            isRefreshing = true;
        }

        private void loadSettings()
        {
            try
            {
                numGalaxyStart.Value = SettingsService.Instance.Settings.StartCoordinates.Galaxy;
                numSunSysStart.Value = SettingsService.Instance.Settings.StartCoordinates.SunSys;
                numPlanetStart.Value = SettingsService.Instance.Settings.StartCoordinates.Planet;

                numGalaxyStop.Value = SettingsService.Instance.Settings.StopCoordinates.Galaxy;
                numSunSysStop.Value = SettingsService.Instance.Settings.StopCoordinates.SunSys;
                numPlanetStop.Value = SettingsService.Instance.Settings.StopCoordinates.Planet;

                numMinDF.Value = SettingsService.Instance.Settings.MinDFResources;

                checkAutoRefresh.Checked = SettingsService.Instance.Settings.AutoRefresh;
                numAutoRefreshMin.Value = SettingsService.Instance.Settings.AutoRefreshInterval > 0 ? SettingsService.Instance.Settings.AutoRefreshInterval : 5;
                textAlertSoundsDir.Text = String.IsNullOrEmpty(SettingsService.Instance.Settings.AlertSettings.AlertSoundsDirectory) ? DEFAULT_ALERT_DIRACTORY : Directory.Exists(SettingsService.Instance.Settings.AlertSettings.AlertSoundsDirectory) ? SettingsService.Instance.Settings.AlertSettings.AlertSoundsDirectory : DEFAULT_ALERT_DIRACTORY;
                fbdAlertSounds.SelectedPath = textAlertSoundsDir.Text;
                checkAlertSounds.Checked = SettingsService.Instance.Settings.AlertSettings.AlertSoundsEnabled;

                foreach (PlanetSettingEntity pse in SettingsService.Instance.Settings.PlanetLastSearch)
                {
                    listFreePlanets.Items.Add(new ListViewItem(new[] { pse.Coordinates, pse.Status }));
                }
                if (listFreePlanets.Items.Count > 0)
                {
                    enableCopyPlanets(true);
                }

                foreach (DFSettingsEntity dfse in SettingsService.Instance.Settings.DFLastSearch)
                {
                    listDF.Items.Add(new ListViewItem(new[] { dfse.DFCoordinates, dfse.DFMetal, dfse.DFCrystal, dfse.DFRecyclers }));
                }
                if (listDF.Items.Count > 0)
                {
                    enableCopyDF(true);
                }
            }
            catch (Exception ex)
            {
                Logger.Info(ex, "FinderFormat.loadSettings error");
            }
        }

        private void saveSettings()
        {
            try
            {
                List<PlanetSettingEntity> lastSearch = new List<PlanetSettingEntity>();
                foreach (ListViewItem item in listFreePlanets.Items)
                {
                    lastSearch.Add(new PlanetSettingEntity(item.Text, item.SubItems[1].Text));
                }
                List<DFSettingsEntity> lastDFSearch = new List<DFSettingsEntity>();
                foreach (ListViewItem item in listDF.Items)
                {
                    lastDFSearch.Add(new DFSettingsEntity(item.Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text));
                }
                SettingsService.Instance.Settings.MinDFResources = numMinDF.Value;
                SettingsService.Instance.Settings.DFLastSearch = lastDFSearch;
                SettingsService.Instance.Settings.PlanetLastSearch = lastSearch;
                SettingsService.Instance.Settings.StartCoordinates = new Coordinates((int)numGalaxyStart.Value, (int)numSunSysStart.Value, (int)numPlanetStart.Value);
                SettingsService.Instance.Settings.StopCoordinates = new Coordinates((int)numGalaxyStop.Value, (int)numSunSysStop.Value, (int)numPlanetStop.Value);
                SettingsService.Instance.Settings.AutoRefresh = checkAutoRefresh.Checked;
                SettingsService.Instance.Settings.AutoRefreshInterval = (int)numAutoRefreshMin.Value;
                var alertSettings = new AlertSettingsEntity();
                alertSettings.AlertSoundsEnabled = checkAlertSounds.Checked;
                alertSettings.AlertSoundsDirectory = string.IsNullOrEmpty(textAlertSoundsDir.Text) ? DEFAULT_ALERT_DIRACTORY : textAlertSoundsDir.Text;
                SettingsService.Instance.Settings.AlertSettings = alertSettings;

                SettingsService.Instance.Save();
            }
            catch (Exception ex)
            {
                Logger.Warn(ex, "FinderForm.saveSettings failed");
            }
        }

        private void radioSearchAll_CheckedChanged(object sender, EventArgs e)
        {
            searchChoise = SearchChoise.All;
        }

        private void radioSearchEmpty_CheckedChanged(object sender, EventArgs e)
        {
            searchChoise = SearchChoise.EmptyPlanet;
        }

        private void radioSearchDestroyed_CheckedChanged(object sender, EventArgs e)
        {
            searchChoise = SearchChoise.Debris;
        }

        private void butCopyPlanets_Click(object sender, EventArgs e)
        {
            if (listFreePlanets.Items.Count > 0)
            {
                FinderFormCommons.listToClipboard(listFreePlanets, checkPlanetsCoordsTags, " ");
            }
        }

        private void butCopyDebris_Click(object sender, EventArgs e)
        {
            if (listDF.Items.Count > 0)
            {
                FinderFormCommons.listToClipboard(listDF, checkDebrisCoordsTags);
            }
        }

        private void butSwitchPlanet_Click(object sender, EventArgs e)
        {
            if (!comboChosenPlanet.Text.Equals(choisenPlanet))
            {
                if (!NavigationResult.Failed.Equals(HTTPConnectionManager.Instance.NavigationRequest(((ComboboxItem)comboChosenPlanet.SelectedItem).Value)))
                {
                    fillPlanetInfos();
                    fillInfoListView();
                    choisenPlanet = comboChosenPlanet.Text;
                    refreshFleetMoving();
                }
                else
                {
                    MessageBox.Show("Switch failed, connection failed, please restart the application!", "Error");
                }
            }
        }

        private void checkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAutoRefresh.Checked)
            {
                timerAutoRefresh.Start();
            }
            else
            {
                timerAutoRefresh.Stop();
            }
        }

        private void timerAutoRefresh_Tick(object sender, EventArgs e)
        {
            if (checkAutoRefresh.Enabled && checkAutoRefresh.Checked)
            {
                refreshGameInfo();
            }
        }

        private void butBrowser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboChosenPlanet.Text))
            {
                FinderFormCommons.openBrowser(HTTPConnectionManager.Instance.getPlanetUrl(((ComboboxItem)comboChosenPlanet.SelectedItem).Value), timerAutoRefresh);
            }
            else
            {
                MessageBox.Show("Couldn´t get site Url, connection failed, please restart the application!", "Error");
            }
        }

        private void numAutoRefreshMin_ValueChanged(object sender, EventArgs e)
        {
            setTimerInMin(timerAutoRefresh, (int)numAutoRefreshMin.Value);
        }

        private void setTimerInMin(Timer timer, int min)
        {
            timer.Interval = min * 60 * 1000;
        }

        private void bgWorkerSearchPlanis_DoWork(object sender, DoWorkEventArgs e)
        {
            Exception exception = null;
            try
            {
                Coordinates[] coordinates = (Coordinates[])e.Argument;
                // SplashScreenForm.StartSplashScreen("Searching... Please Wait!");
                CurrentTime = DateTime.Now;
                exception = HTTPConnectionManager.Instance.SearchEmptyPlanets(coordinates, listFreePlanets, listDF, (int)numMinDF.Value, labSEStatus, searchChoise);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("bgWorkerSearchPlanis_DoWork: " + ex);
                Logger.Error(ex.ToString());
            }
            e.Result = exception;
        }

        private void bgWorkerSearchPlanis_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var exc = e.Result as Exception;
            searchEnabled(true);
            if (exc != null)
            {
                labSEStatus.Text = "Aborted";
                labSEStatus.ForeColor = Color.Red;
                MessageBox.Show(exc.Message, "Search Engine");
                if (exc is UnderAttackException)
                {
                    refreshFleetMoving();
                }
            }
            else
            {
                TimeSpan diff = DateTime.Now - CurrentTime;
                labSEStatus.ForeColor = Color.Green;
                MessageBox.Show("Search duration: " + diff, "Search Engine");
            }
        }

        private void backWorkRefresh_DoWork(object sender, DoWorkEventArgs e)
        {            
            e.Result = HTTPConnectionManager.Instance.NavigationRequest((string)e.Argument);
        }

        private void backWorkRefresh_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            isRefreshing = false;
            NavigationResult navigationResult = (NavigationResult)e.Result;
            if (!NavigationResult.Failed.Equals(navigationResult))
            {
                fillPlanetInfos();
                fillInfoListView();
                fillPlanetsChoiser();
                refreshFleetMoving();
            }
            else
            {
                MessageBox.Show("Refresh failed, please restart the application!", "Error");
            }
        }

        private void olvFleetMoving_DoubleClick(object sender, EventArgs e)
        {
            FinderFormCommons.openBrowser(HTTPConnectionManager.Instance.getPlanetUrl("", "movement"), timerAutoRefresh);
        }

        private void olvFleetMoving_FormatRow(object sender, FormatRowEventArgs e)
        {
            var fleetMove = (FleetMove)e.Model;
            if (fleetMove.isCurrentFleetEnemy())
            {
                var timeSpan = fleetMove.ArrivalTime.Subtract(DateTime.Now);
                if (timeSpan.Minutes <= 5)
                {
                    e.Item.BackColor = Color.Red;
                }
                else if (timeSpan.Minutes <= 10)
                {
                    e.Item.BackColor = Color.Orange;
                }
                else
                {
                    e.Item.BackColor = Color.Yellow;
                }
            }
        }

        public new void Show()
        {
            hideToolStripMenuItem.Text = "Hide";
            BringToFront();
            base.Show();
            FormCommons.SetOnTop(this);
        }

        public new void Hide()
        {
            hideToolStripMenuItem.Text = "Show";
            base.Hide();
        }

        private void toggleVisibility()
        {
            if (Visible)
            {
                Hide();                
            }
            else if (!Visible)
            {
                Show();
            }
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleVisibility();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void butOpenSoundsFolder_Click(object sender, EventArgs e)
        {
            if (fbdAlertSounds.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(fbdAlertSounds.SelectedPath))
            {
                textAlertSoundsDir.Text = fbdAlertSounds.SelectedPath;
            }
        }

        private void checkAlertSounds_CheckedChanged(object sender, EventArgs e)
        {            
            if (checkAlertSounds.Checked && !Directory.Exists(textAlertSoundsDir.Text))
            {
                MessageBox.Show("The chosen Sound directory does not exist!", "Error");
            }
        }

        private void butTestStopAlert_Click(object sender, EventArgs e)
        {
            ToggleRandomAlertSound();
        }
    }
}
