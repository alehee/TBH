using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using System.Media;
using System.IO;

namespace TibiaBestHealer2k20
{
    public partial class FORM_Main : Form
    {
        private string VERSION = "1.1.1";

        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        private int healthMaxX = 0;
        private int healthMinX = 0;
        private int healthY = 0;
        private short healLag = 0;

        private double healthPercentageTrigger = 0.5;
        private double healthPercentageX = 0;

        private int greenHealthR = 0;
        private int greenHealthG = 137;
        private int greenHealthB = 0;

        private int halfgreenHealthR = 79;
        private int halfgreenHealthG = 114;
        private int halfgreenHealthB = 3;

        private int orangeHealthR = 144;
        private int orangeHealthG = 110;
        private int orangeHealthB = 6;

        private int redHealthR = 137;
        private int redHealthG = 34;
        private int redHealthB = 34;

        private int manaBarR = 0;
        private int manaBarG = 41;
        private int manaBarB = 91;

        private int manaMinX = 0;
        private int manaMaxX = 0;
        private int manaY = 0;
        private short manaLag = 0;

        private double manaPercentageTrigger = 0.5;
        private double manaPercentageX = 0;

        private int[] healthColors = new int[3];

        private char screenshotKey = '\\';
        private string heal1Key = "";
        private string mana1Key = "";

        private string screenshotLocation = "";

        private bool isRunning = false;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public FORM_Main()
        {
            InitializeComponent();

            this.L_Version.Text = "v. " + VERSION;

            timer.Stop();
            timer.Interval = 300;
            timer.Tick += new EventHandler(TimerTick);

            //BM3LV-SQVU8-28SL5-UBFRJ
        }

        private void FORM_Main_Load(object sender, EventArgs e)
        {
            if(TBH.Properties.Settings.Default["TibiaPath"] == "")
            {
                this.FBDialog_TibiaFolder.ShowDialog();
                TBH.Properties.Settings.Default["TibiaPath"] = this.FBDialog_TibiaFolder.SelectedPath;
                TBH.Properties.Settings.Default.Save();
            }

            screenshotLocation = TBH.Properties.Settings.Default["TibiaPath"] + "\\packages\\Tibia\\screenshots";

            if(TBH.Properties.Settings.Default["HealthMinX"].ToString() != "0")
            {
                healthMinX = Convert.ToInt32(TBH.Properties.Settings.Default["HealthMinX"].ToString());
                healthMaxX = Convert.ToInt32(TBH.Properties.Settings.Default["HealthMaxX"].ToString());
                healthY = Convert.ToInt32(TBH.Properties.Settings.Default["HealthY"].ToString());

                manaMinX = Convert.ToInt32(TBH.Properties.Settings.Default["ManaMinX"].ToString());
                manaMaxX = Convert.ToInt32(TBH.Properties.Settings.Default["ManaMaxX"].ToString());
                manaY = Convert.ToInt32(TBH.Properties.Settings.Default["ManaY"].ToString());
                this.L_Calibration.Text = "Health bar seems to be X:" + healthMinX.ToString() + " Y:" + healthY.ToString() + " - X:" + healthMaxX.ToString() + " Y:" + healthY.ToString() + ", and " +
                    "mana bar X:" + manaMinX + " Y:" + manaY + " - X:" + manaMaxX + " Y:" + manaY;
                this.B_Calibration.Text = "Reset Calibration";
            }

            if(TBH.Properties.Settings.Default["HealPercent"].ToString() != "0")
            {
                this.TB_HealthPercent.Text = TBH.Properties.Settings.Default["HealPercent"].ToString();
            }

            if (TBH.Properties.Settings.Default["ManaPercent"].ToString() != "0")
            {
                this.TB_ManaPercent.Text = TBH.Properties.Settings.Default["ManaPercent"].ToString();
            }

            if (TBH.Properties.Settings.Default["HealKey"].ToString() != "")
            {
                this.CB_HealthKey.Text = TBH.Properties.Settings.Default["HealKey"].ToString();
            }

            if (TBH.Properties.Settings.Default["ManaKey"].ToString() != "")
            {
                this.CB_ManaKey.Text = TBH.Properties.Settings.Default["ManaKey"].ToString();
            }
        }

        private void TimerTick(Object myObject, EventArgs eventArgs)
        {
            string[] tab = Directory.GetFiles(screenshotLocation);
            int[] timerColors = new int[3];

            if(tab.Length > 0) 
            {
                Bitmap screenshot = new Bitmap(Image.FromFile(tab[tab.Length - 1]));
            
                if (tab.Length > 10)
                {
                    foreach(string x in tab)
                    {
                        try
                        {
                            File.Delete(x);
                        }
                        catch { }
                    }
                }

                timerColors = GetPixelColor(Convert.ToInt32(healthPercentageX), healthY, screenshot);

                if ((timerColors[0] != greenHealthR && timerColors[1] != greenHealthG && timerColors[2] != greenHealthB) &&
                    (timerColors[0] != halfgreenHealthR && timerColors[1] != halfgreenHealthG && timerColors[2] != halfgreenHealthB) &&
                    (timerColors[0] != orangeHealthR && timerColors[1] != orangeHealthG && timerColors[2] != orangeHealthB) &&
                    (timerColors[0] != redHealthR && timerColors[1] != redHealthG && timerColors[2] != redHealthB) && healLag == 0)
                {
                    Heal();
                }

                timerColors = GetPixelColor(Convert.ToInt32(manaPercentageX), manaY, screenshot);

                if (timerColors[0] != manaBarR && timerColors[1] != manaBarG && timerColors[2] != manaBarB && manaLag == 0)
                {
                    Mana();
                }

                if(manaLag > 0)
                {
                    manaLag--;
                }

                if (healLag > 0)
                {
                    healLag--;
                }

                screenshot.Dispose();
                screenshot = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            SendKeys.Send("{" + screenshotKey + "}");
        }

        private void B_Run_Click(object sender, EventArgs e)
        {
            this.L_Error.Text = "";

            if (isRunning == false && healthMinX != 0)
            {
                this.TB_HealthPercent.Enabled = false;
                this.TB_ManaPercent.Enabled = false;
                this.CB_HealthKey.Enabled = false;
                this.CB_ManaKey.Enabled = false;
                this.CheckB_SecureHeal.Enabled = false;

                heal1Key = this.CB_HealthKey.Text;
                mana1Key = this.CB_ManaKey.Text;

                TBH.Properties.Settings.Default["HealKey"] = heal1Key;
                TBH.Properties.Settings.Default["ManaKey"] = mana1Key;

                string percentageText = this.TB_HealthPercent.Text;
                healthPercentageTrigger = Convert.ToDouble(percentageText) / 100;
                if(healthPercentageTrigger > 0 && healthPercentageTrigger < 1) { 
                    healthPercentageX = Convert.ToDouble(healthMinX) + (Convert.ToDouble(healthMaxX) - Convert.ToDouble(healthMinX)) * healthPercentageTrigger;
                    healthPercentageX = Convert.ToInt32(healthPercentageX);
                    TBH.Properties.Settings.Default["HealPercent"] = Convert.ToInt32(percentageText);
                }
                else
                {
                    healthPercentageTrigger = 0.5;
                    healthPercentageX = Convert.ToDouble(healthMinX) + (Convert.ToDouble(healthMaxX) - Convert.ToDouble(healthMinX)) * healthPercentageTrigger;
                    healthPercentageX = Convert.ToInt32(healthPercentageX);
                }
                percentageText = this.TB_ManaPercent.Text;
                manaPercentageTrigger = Convert.ToDouble(percentageText) / 100;
                if (manaPercentageTrigger > 0 && manaPercentageTrigger < 1)
                {
                    manaPercentageX = Convert.ToDouble(manaMaxX) - (Convert.ToDouble(manaMaxX) - Convert.ToDouble(manaMinX)) * manaPercentageTrigger;
                    manaPercentageX = Convert.ToInt32(manaPercentageX);
                    TBH.Properties.Settings.Default["ManaPercent"] = Convert.ToInt32(percentageText);
                }
                else
                {
                    manaPercentageTrigger = 0.5;
                    manaPercentageX = Convert.ToDouble(manaMaxX) - (Convert.ToDouble(manaMaxX) - Convert.ToDouble(manaMinX)) * manaPercentageTrigger;
                    manaPercentageX = Convert.ToInt32(manaPercentageX);
                }

                TBH.Properties.Settings.Default.Save();

                Thread.Sleep(1000);

                isRunning = true;
                timer.Start();
                this.L_Running.Text = "Working...";
            }
            else if(isRunning == false && healthMinX == 0)
            {
                this.L_Error.Text = "Calibrate your client first!";
            }
            else
            {
                isRunning = false;
                timer.Stop();
                this.L_Running.Text = "Not working...";

                this.TB_HealthPercent.Enabled = true;
                this.TB_ManaPercent.Enabled = true;
                this.CB_HealthKey.Enabled = true;
                this.CB_ManaKey.Enabled = true;
                this.CheckB_SecureHeal.Enabled = true;
            }
        }

        private void B_Calibration_Click(object sender, EventArgs e)
        {
            this.L_Error.Text = "";

            if (healthMinX == 0)
                GetCalibration();
            else 
            {
                TBH.Properties.Settings.Default["HealthMinX"] = 0;
                TBH.Properties.Settings.Default["HealthMaxX"] = 0;
                TBH.Properties.Settings.Default["HealthY"] = 0;
                TBH.Properties.Settings.Default["ManaMinX"] = 0;
                TBH.Properties.Settings.Default["ManaMaxX"] = 0;
                TBH.Properties.Settings.Default["ManaY"] = 0;
                TBH.Properties.Settings.Default.Save();
                Application.Restart();
            }
        }

        private void B_ResetPath_Click(object sender, EventArgs e)
        {
            this.FBDialog_TibiaFolder.ShowDialog();
            TBH.Properties.Settings.Default["TibiaPath"] = this.FBDialog_TibiaFolder.SelectedPath;
            TBH.Properties.Settings.Default.Save();
            screenshotLocation = TBH.Properties.Settings.Default["TibiaPath"] + "\\packages\\Tibia\\screenshots";
        }

        private void Heal()
        {
            SendKeys.Send("{" + heal1Key + "}");
            if (this.CheckB_SecureHeal.Checked)
                healLag = 3;
            else
                healLag = 5;
        }

        private void Mana()
        {
            SendKeys.Send("{" + mana1Key + "}");
            manaLag = 5;
        }

        private void GetCalibration()
        {
            this.L_Calibration.Text = "Calibration started... Enter Tibia!";

            Thread.Sleep(3000);

            string[] tab = Directory.GetFiles(screenshotLocation);
            if (tab.Length > 0) { 
                foreach (string x in tab)
                {
                    File.Delete(x);
                }
            }

            bool screenshotGet = false;
            string screenshotTab = "";
            short screenshotTries = 0;

            while (screenshotGet == false && screenshotTries < 500){

                SendKeys.Send("{" + screenshotKey + "}");

                try { 
                    screenshotTab = Directory.GetFiles(screenshotLocation)[0];
                    screenshotGet = true;
                }
                catch { }

                screenshotTries++;
            }

            if (screenshotTries < 500) { 
                Bitmap screenshot = new Bitmap(Image.FromFile(screenshotTab));

                bool calibrationAchieved = false;
                bool healthCalibrationAchieved = false;
                int calibrationX = 0;
                int calibrationY = 0;

                while (calibrationAchieved == false){
                    healthColors = GetPixelColor(calibrationX, calibrationY, screenshot);
                    if(healthCalibrationAchieved == false && 
                        (healthColors[0] == greenHealthR && healthColors[1] == greenHealthG && healthColors[2] == greenHealthB) ||
                        (healthColors[0] == halfgreenHealthR && healthColors[1] == halfgreenHealthG && healthColors[2] == halfgreenHealthB) ||
                        (healthColors[0] == orangeHealthR && healthColors[1] == orangeHealthG && healthColors[2] == orangeHealthB) ||
                        (healthColors[0] == redHealthR && healthColors[1] == redHealthG && healthColors[2] == redHealthB))
                    {
                        healthMinX = calibrationX;
                        healthY = calibrationY;

                        int[] healthBarLengthColors = new int[3];
                        bool calibrationLengthGood = false;

                        while(calibrationLengthGood == false)
                        {
                            healthBarLengthColors = GetPixelColor(calibrationX, calibrationY, screenshot);
                            if ((healthBarLengthColors[0] == greenHealthR && healthBarLengthColors[1] == greenHealthG && healthBarLengthColors[2] == greenHealthB) ||
                                (healthBarLengthColors[0] == halfgreenHealthR && healthBarLengthColors[1] == halfgreenHealthG && healthBarLengthColors[2] == halfgreenHealthB) ||
                                (healthBarLengthColors[0] == orangeHealthR && healthBarLengthColors[1] == orangeHealthG && healthBarLengthColors[2] == orangeHealthB) ||
                                (healthBarLengthColors[0] == redHealthR && healthBarLengthColors[1] == redHealthG && healthBarLengthColors[2] == redHealthB))
                            {
                                calibrationX++;
                            }
                            else
                            {
                                healthMaxX = calibrationX;
                                calibrationLengthGood = true;
                            }
                        }
                        healthCalibrationAchieved = true;
                    }
                    else if (healthColors[0] == manaBarR && healthColors[1] == manaBarG && healthColors[2] == manaBarB)
                    {
                        manaMinX = calibrationX;
                        manaY = calibrationY;

                        int[] healthBarLengthColors = new int[3];
                        bool calibrationLengthGood = false;

                        while (calibrationLengthGood == false)
                        {
                            healthBarLengthColors = GetPixelColor(calibrationX, calibrationY, screenshot);
                            if (healthBarLengthColors[0] == manaBarR && healthBarLengthColors[1] == manaBarG && healthBarLengthColors[2] == manaBarB)
                            {
                                calibrationX++;
                            }
                            else
                            {
                                manaMaxX = calibrationX;
                                calibrationLengthGood = true;
                            }
                        }

                        calibrationAchieved = true;
                    }
                    else
                    {
                        if (calibrationY > 100)
                        {
                            calibrationX++;
                            calibrationY = 0;
                        }
                        else
                        {
                            calibrationY++;
                        }
                    }
                }

                this.L_Calibration.Text = "Health bar seems to be X:" + healthMinX.ToString() + " Y:" + healthY.ToString() + " - X:" + healthMaxX.ToString() + " Y:" + healthY.ToString() + ", and " +
                    "mana bar X:" + manaMinX + " Y:" + manaY + " - X:" + manaMaxX + " Y:" + manaY;
                screenshot.Dispose();

                TBH.Properties.Settings.Default["HealthMinX"] = healthMinX;
                TBH.Properties.Settings.Default["HealthMaxX"] = healthMaxX;
                TBH.Properties.Settings.Default["HealthY"] = healthY;
                TBH.Properties.Settings.Default["ManaMinX"] = manaMinX;
                TBH.Properties.Settings.Default["ManaMaxX"] = manaMaxX;
                TBH.Properties.Settings.Default["ManaY"] = manaY;
                TBH.Properties.Settings.Default.Save();

                SystemSounds.Asterisk.Play();

                this.B_Calibration.Text = "Reset Calibration";
            }
            else
            {
                this.L_Calibration.Text = "An error occured!";
                SystemSounds.Asterisk.Play();
            }

            screenshotTries = 0;
        }

        private int[] GetPixelColor(int x, int y, Bitmap bitmap)
        {
            int[] colors = new int[3];

            colors[0] = bitmap.GetPixel(x, y).R;
            colors[1] = bitmap.GetPixel(x, y).G;
            colors[2] = bitmap.GetPixel(x, y).B;

            return colors;
        }
    }
}
