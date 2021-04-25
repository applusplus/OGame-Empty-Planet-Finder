using System.Drawing;
using System.Windows.Forms;
using OGameEmptyPlanetFinder.OGame;
using OGameEmptyPlanetFinder.Properties;

namespace OGameEmptyPlanetFinder.GUI
{
    public class AlertVisualManager
    {
        public void setStatus(Label labAlertStatus, PictureBox pictureBox, MissionType missionType, MissionPictureStatus missionPictureStatus, bool isForeignFleet)
        {
            setStatusDescription(labAlertStatus, missionType, missionPictureStatus, isForeignFleet);
            setAlertPicture(pictureBox, missionType, missionPictureStatus);
        }

        public void setStatusDescription(Label labAlertStatus, MissionType missionType, MissionPictureStatus missionPictureStatus, bool isForeignFleet)
        {
            labAlertStatus.Text = isForeignFleet ? getStatusTextFromTypeOnForeignFleet(missionType, missionPictureStatus) : "";
        }

        public void setAlertPicture(PictureBox pictureBox, MissionType missionType, MissionPictureStatus pictureState)
        {
            pictureBox.Image = setAlertPicture((int)getMissionPictureFromType(missionType), (int)pictureState);
        }

        private Bitmap setAlertPicture(int xPos, int yPos)
        {
            Bitmap source = Resources.fleet_commands;
            Bitmap target = new Bitmap(54, 54);
            Graphics graphics = Graphics.FromImage(target);
            graphics.DrawImage(source, 0, 0, new Rectangle(new Point(calcAlertPicturePos(xPos), calcAlertPicturePos(yPos)), new Size(54, 54)), GraphicsUnit.Pixel);
            return target;
        }

        private int calcAlertPicturePos(int pos)
        {
            return pos < 1 ? 0 : pos * 54;
        }

        public MissionPicture getMissionPictureFromType(MissionType missionType)
        {
            MissionPicture missionPicture = MissionPicture.Spying;
            switch (missionType)
            {
                case MissionType.Expedition:
                    missionPicture = MissionPicture.Expedition;
                    break;
                /*case MissionType.CollectSettings:
                    missionPicture = MissionPicture.CollectSettings;
                    break;  */                  
                case MissionType.Colonising:
                    missionPicture = MissionPicture.Colonising;
                    break;
                case MissionType.Station:
                    missionPicture = MissionPicture.Station;
                    break;
                case MissionType.Recycle:
                    missionPicture = MissionPicture.Recycle;
                    break;
                case MissionType.Transport:
                    missionPicture = MissionPicture.Transport;
                    break;
                case MissionType.Spying:
                    missionPicture = MissionPicture.Spying;
                    break;
                case MissionType.Hold:
                    missionPicture = MissionPicture.Hold;
                    break;
                case MissionType.Attack:
                    missionPicture = MissionPicture.Attack;
                    break;
                case MissionType.Destroy:
                    missionPicture = MissionPicture.Destroy;
                    break;
                case MissionType.AKS:
                    missionPicture = MissionPicture.AKS;
                    break;
            }
            return missionPicture;
        }

        private string getStatusTextFromTypeOnForeignFleet(MissionType missionType, MissionPictureStatus missionPictureStatus)
        {
            string statusBuilder = "Standby";
            if (!(MissionPictureStatus.Disabled.Equals(missionPictureStatus) || MissionPictureStatus.DisabledChosen.Equals(missionPictureStatus)))
            {
                if (MissionPictureStatus.Normal.Equals(missionPictureStatus))
                {
                    switch(missionType)
                    {
                        case MissionType.Attack:
                            statusBuilder = "You are under attack!";
                            break;
                        case MissionType.AKS:
                            statusBuilder = "They want you!";
                            break;
                        case MissionType.Destroy:
                            statusBuilder = "Your mond is in danger!";
                            break;
                        case MissionType.Spying:
                            statusBuilder = "Somebody wants to know...";
                            break;
                        default:
                            statusBuilder = "*Chewing bubble gum*";
                            break;
                    }
                }
                else if (MissionPictureStatus.Chosen.Equals(missionPictureStatus))
                {
                    switch(missionType)
                    {
                        case MissionType.Attack:
                            statusBuilder = "You are under heavy attack!";
                            break;
                        case MissionType.AKS:
                            statusBuilder = "Holy sh*t, they must be mad!";
                            break;
                        case MissionType.Destroy:
                            statusBuilder = "They want your mond!";
                            break;
                        case MissionType.Spying:
                            statusBuilder = "Prepare to fight!";
                            break;
                        default:
                            statusBuilder = "*Chilling around*";
                            break;
                    }
                }
            }
            return statusBuilder;
        }

        private string getStatusTextFromTypeOnOwnFleet(MissionType missionType, MissionPictureStatus missionPictureStatus)
        {
            string statusBuilder = "Standby";
            if (!(MissionPictureStatus.Disabled.Equals(missionPictureStatus) || MissionPictureStatus.DisabledChosen.Equals(missionPictureStatus)))
            {
                switch (missionType)
                {
                case MissionType.Attack:
                    statusBuilder = "You want to own someone?";
                    break;
                case MissionType.AKS:
                    statusBuilder = "Teaming up is always a good idea.";
                    break;
                case MissionType.Destroy:
                    statusBuilder = "Rip this mond off.";
                    break;
                case MissionType.Spying:
                    statusBuilder = "Scanning...";
                    break;
                default:
                    statusBuilder = "Your fleet is moving around.";
                    break;
                }
            }
            return statusBuilder;
        }
    }

    public enum MissionPicture
    {
        Expedition,
        CollectSettings,
        Colonising,
        Station,
        Recycle,
        Transport,
        Spying,
        Hold,
        Attack,
        Destroy,
        AKS
    }

    public enum MissionPictureStatus
    {
        Normal,
        Chosen,
        Disabled,
        DisabledChosen
    }
}
