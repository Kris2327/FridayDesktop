using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Speech;
using System.IO;
using System.Diagnostics;
using System.Media;
using System.Management;
using AudioSwitcher.AudioApi.CoreAudio;

namespace Friday_1._1
{
    public partial class Form1 : Form
    {
        bool comands = true;
        Timer t = new Timer();
        SpeechRecognitionEngine engine = new SpeechRecognitionEngine();
        SpeechSynthesizer s = new SpeechSynthesizer();
        System.Timers.Timer timer;
        SoundPlayer player = new SoundPlayer();
        PowerStatus pwr = SystemInformation.PowerStatus;
        System.Timers.Timer timer3;
        int ht , mt, st;
        Timer timer4 = new Timer();
        Timer timer5 = new Timer();
        int ht2, mt2, st2;
        CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;

        public Form1()
        {
            GrammarFriday();
            s.SelectVoiceByHints(VoiceGender.Female);
            InitializeComponent();
            
            Console.ReadLine();

            label6.Text = pwr.BatteryLifePercent.ToString("P0");
        }

        private void GrammarFriday()
        {
            engine.RequestRecognizerUpdate();
            engine.SetInputToDefaultAudioDevice();
            engine.LoadGrammar(new DictationGrammar());
            engine.RecognizeAsync(RecognizeMode.Multiple);
            engine.SpeechRecognized += FridaySpeak;
        }

        public void say(string h)
        {
            s.Speak(h);
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();

            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;

            timer3 = new System.Timers.Timer();
            timer3.Interval = 1000;
            timer3.Elapsed += timer2_Tick;

            timer4.Interval = 1000;
            timer4.Tick += new EventHandler(this.UpdateTimer_Tick);
            timer4.Start();

            CPUTimer.Start();

            timer5.Interval = 1000;
            timer5.Tick += new EventHandler(this.WorktimeTimer_Tick);
            timer5.Start();

            double volume = defaultPlaybackDevice.Volume;
            label14.Text = volume.ToString();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            string time = "";

            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            label2.Text = time;
            label3.Text = DateTime.Now.ToShortDateString();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DateTime userTime = dateTimePicker1.Value;
            if (currentTime.Hour == userTime.Hour && currentTime.Minute == userTime.Minute && currentTime.Second == userTime.Second)
            {
                timer.Stop();
                try
                {

                    player.SoundLocation = @"C:\music\alert2.wav";
                    player.PlayLooping();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            double volume = defaultPlaybackDevice.Volume;
            label14.Text = volume.ToString();

            int volume2 = Convert.ToInt16(volume);

            Pen pen13 = new Pen(Color.Red, 5);
            graphics.DrawLine(pen13, 1015, 50, 1015 + volume2 * 1, 50);

            Pen pen12 = new Pen(Color.Red, 2);
            graphics.DrawEllipse(pen12, 655, 180, 140, 140);

            Pen pen11 = new Pen(Color.Red, 7);
            graphics.DrawArc(pen11, 655, 180, 140, 140, 0, 65);
            graphics.DrawArc(pen11, 655, 180, 140, 140, 120, 65);
            graphics.DrawArc(pen11, 655, 180, 140, 140, 240, 65);

            Pen pen10 = new Pen(Color.OrangeRed, 2);
            graphics.DrawEllipse(pen10, 270, 410, 120, 120);

            Pen pen9 = new Pen(Color.OrangeRed, 7);
            graphics.DrawArc(pen9, 268, 408, 120, 120, 310, 65);
            graphics.DrawArc(pen9, 272, 410, 120, 120, 170, 65);
            graphics.DrawArc(pen9, 272, 410, 120, 120, 60, 65);

            Pen pen7 = new Pen(Color.OrangeRed, 5);
            graphics.DrawEllipse(pen7, 270, 190, 120, 120);
            graphics.DrawEllipse(pen7, 665, 190, 120, 120);

            graphics.DrawArc(pen7, 650, 410, 120, 120, 83, 190);
            graphics.DrawArc(pen7, 650, 400, 140, 140, 268, 180);

            Pen pen5 = new Pen(Color.Red, 5);
            Rectangle rect = new Rectangle(330, 160, 1, 20);
            graphics.DrawRectangle(pen5, rect);

            Pen pen6 = new Pen(Color.Red, 5);
            Rectangle rect2 = new Rectangle(315, 155, 30, 1);
            graphics.DrawRectangle(pen6, rect2);

            Pen pen4 = new Pen(Color.OrangeRed, 10);
            graphics.DrawArc(pen4, 835, 65, 150, 150, 160, 300);
            graphics.DrawArc(pen4, 50, 65, 150, 150, 450, 290);
            graphics.DrawArc(pen4, 50, 485, 150, 150, 0, 300);
            graphics.DrawArc(pen4, 845, 485, 150, 150, 250, 300);

            Pen pen3 = new Pen(Color.Red, 4);
            graphics.DrawArc(pen3, 437, 252, 180, 180, 0, 180);
            
            Pen pen2 = new Pen(Color.Blue, 4);
            graphics.DrawArc(pen2, 437, 252, 180, 180, 180, 180);

            Pen pen1 = new Pen(Color.Red, 4);
            graphics.DrawEllipse(pen1, 418, 235, 220, 220);
            graphics.DrawEllipse(pen1, 455, 270, 145, 145);

            Pen pen = new Pen(Color.Red, 5);
            graphics.DrawEllipse(pen, 35, 50, 180, 180);
            graphics.DrawEllipse(pen, 820, 50, 180, 180);
            graphics.DrawEllipse(pen, 35, 470, 180, 180);
            graphics.DrawEllipse(pen, 830, 470, 180, 180);
            graphics.DrawEllipse(pen, 260, 180, 140, 140);            
            graphics.DrawEllipse(pen, 260, 400, 140, 140);

            graphics.DrawArc(pen, 660, 410, 120, 120, 268, 180);
            graphics.DrawArc(pen, 640, 400, 140, 140, 83, 190);
        }

        private void FridaySpeak(object sender, SpeechRecognizedEventArgs e)
        {
            string r = e.Result.Text;
            label4.Text = r;


            // connect/disconnect
  
            if(comands == true)
            {
                // speak
                if (r == "hi" || r == "high")
                {
                    say("Hi");
                }

                if (r == "how are you")
                {
                    say("Great, and you");
                }



                // opening webs
                if (r == "all when you build")
                {
                    say("Ok sir");
                    Process.Start("https://www.youtube.com/");
                }



                if (r == "old one study")
                {
                    say("Ok sir");
                    Process.Start("https://ucha.se/");
                }

                if (r == "all one study")
                {
                    say("Ok sir");
                    Process.Start("https://ucha.se/");
                }
                // opening apps
                if (r == "all one word" || r == "old one was" || r == "alban wood")
                {
                    say("ok sir");
                    Process.Start("WINWORD.exe");
                }

                if (r == "dollar")
                {
                    say("ok sir");
                    Process.Start("POWERPNT.exe");
                }

                if (r == "old one cult leader")
                {
                    say("ok sir");
                    Calculator cal = new Calculator();
                    cal.Show();
                }

                if (r == "and a music")
                {
                    say("ok sir");
                    MusicPlayer mp = new MusicPlayer();
                    mp.Show();
                }

                if (r == "call the mind of the" || r == "all the mind of" || r == "all the mind of the")
                {
                    say("ok sir");
                    Process.Start(@"D:\Minecraft\TLauncher.lnk");
                }


                // closing apps

                
            }

            if (comands == false)
            {
                label16.Text = "disconnected";
                label16.ForeColor = Color.Red;
                
            }
            
            if (r == "disconnect" || r == "and disconnect")
            {
                label16.Text = "disconnected";
                label16.ForeColor = Color.Red;
                comands= false;
            }

            if (r == "to make" || r == "connect")
            {
                comands = true;
                label16.Text = "connected";
                label16.ForeColor = Color.Lime;
            }

            if (r == "walls")
            {
                say("Goodbye sir");
                Application.Exit();
            }

            if (r == "height" || r == "hike" || r == "high")
            {
                Hide();
                ShowInTaskbar = false;
            }

            if (r == "child" || r == "shell" || r == "Scholl")
            {
                Show();
                ShowInTaskbar = true;
            }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
            player.Stop();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        private void CPUTimer_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = (int)(performanceCounter1.NextValue());
            label10.Text = progressBar1.Value.ToString() + "%";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label7.Text = "00:00:00";
            ht = 0;
            mt = 0;
            st = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void WorktimeTimer_Tick(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {

                st2 += 1;

                if (st2 == 60)
                {
                    st2 = 0;
                    mt2 += 1;

                }
                if (mt2 == 60)
                {
                    mt2 = 0;
                    ht2 += 1;
                }
                label12.Text = string.Format("{0}:{1}:{2}", ht2.ToString().PadLeft(2, '0'), mt2.ToString().PadLeft(2, '0'), st2.ToString().PadLeft(2, '0'));

            }));
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if(sender == timer4)
            {
                label6.Text = pwr.BatteryLifePercent.ToString("P0");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {

                st += 1;

                if (st == 60)
                {
                    st = 0;
                    mt += 1;

                }
                if (mt == 60)
                {
                    mt = 0;
                    ht += 1;
                }

                /*if (mt == 0)
                {
                    mt = 60;
                    ht -= 1;
                }*/
                label7.Text = string.Format("{0}:{1}:{2}", ht.ToString().PadLeft(2, '0'), mt.ToString().PadLeft(2, '0'), st.ToString().PadLeft(2, '0'));
            }));
        }
    } 
}
