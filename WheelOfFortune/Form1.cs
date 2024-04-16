using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace WheelOfFortune
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            panel1.Dock = DockStyle.None;
            panel1.Hide();
            panel2.Dock = DockStyle.Left;
            panel2.Show();
            this.Height = panel2.Height;
            this.Width = panel2.Width;
            panel3.Dock = DockStyle.None;
            panel3.Hide();
        }
        DB_text dB_Text = new DB_text();

        string sound = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "audio", "mixkit-fast-bike-wheel-spin-1614.wav");
        string added = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "audio", "success-notification-alert-one-shot-fx_A_major.wav");
        string show = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "audio", "chime-notification-alert_C_major.wav");
        private void Form1_Load(object sender, EventArgs e)
        {


        }
        int num = 0;
        int num_p = 0;
        int timer_count = 0;
        bool flag_animation = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                bool flag = true;
                foreach (var cli in dB_Text.texts)
                {
                    if (cli.Text == textBox1.Text)
                    {
                        MessageBox.Show("Already exists");
                        flag = false;
                    }
                }
                if (flag)
                {
                    axWindowsMediaPlayer1.URL = added;
                    listView1.Items.Clear();
                    num++;
                    num_p = num + 1;
                    dB_Text.Text = textBox1.Text;
                    dB_Text.Num = num.ToString();
                    label1.Text = num_p.ToString();
                    dB_Text.texts.Add(new DB_text { Text = dB_Text.Text, Num = dB_Text.Num });

                    foreach (var cli in dB_Text.texts)
                    {

                        ListViewItem lvi = new ListViewItem(cli.Text);
                        lvi.SubItems.Add(cli.Num);
                        lvi.SubItems.Add(cli.Count.ToString());
                        listView1.Items.Add(lvi);


                    }
                    textBox1.Clear();


                }
            }
            else
            {


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 1)
            {
                flag_animation = false;
            }
            else
            {
                flag_animation = true;

            }
            axWindowsMediaPlayer1.URL = sound;
            pictureBox1.Visible = false;
            pictureBox1.Visible = true;
            panel1.Show();
            panel3.Hide();
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dB_Text.texts.Count != 0)
            {
                if (dB_Text.texts.Count == 1)
                {
                    MessageBox.Show("At least 2 items !!");
                }
                else
                {
                    panel1.Hide();
                    panel2.Hide();
                    panel3.Show(); this.Height = panel3.Height;
                    this.Width = panel3.Width;
                }
            }
            else
            {
                MessageBox.Show("List is empty");
            }


        }
        int rand()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int num2 = rnd.Next(1, num + 1);

            return num2;
        }
        void random_task()
        {
            int i = 1;

            while (i <= numericUpDown1.Value)
            {
                int r = rand();
                foreach (var item in dB_Text.texts)
                {
                    if (flag_animation == true)
                    {
                        if (r.ToString() == item.Num)
                        {
                            item.Count++;
                            axWindowsMediaPlayer1.URL = show;
                            pictureBox3.Visible = true;
                            pictureBox4.Visible = true;
                            pictureBox5.Visible = true;
                            pictureBox6.Visible = true;
                            string message = $"\t\t{"  "}{item.Text} \n\n \t\t\tout of {num} items";
                            string title = "Winner";
                            MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                            DialogResult result = MessageBox.Show(message, title, buttons);
                            if (result == DialogResult.Retry)
                            {
                                pictureBox3.Visible = false;
                                pictureBox4.Visible = false;
                                pictureBox5.Visible = false;
                                pictureBox6.Visible = false;
                                pictureBox1.Visible = false;
                                pictureBox1.Visible = true;
                                panel1.Show();

                                panel2.Hide();
                                panel3.Hide();
                                timer1.Start();
                                axWindowsMediaPlayer1.URL = sound;
                            }
                            else
                            {
                                listView1.Items.Clear();
                                foreach (var cli in dB_Text.texts)
                                {

                                    ListViewItem lvi = new ListViewItem(cli.Text);
                                    lvi.SubItems.Add(cli.Num);
                                    lvi.SubItems.Add(cli.Count.ToString());
                                    listView1.Items.Add(lvi);


                                }
                                pictureBox3.Visible = false;
                                pictureBox4.Visible = false;
                                pictureBox5.Visible = false;
                                pictureBox6.Visible = false;
                                panel1.Hide();
                                panel2.Dock = DockStyle.Left;
                                panel2.Show();
                                this.Height = 505;
                                this.Width = 303;
                                panel3.Hide();

                            }

                            break;

                        }
                    }
                    else if (flag_animation == false)
                    {
                        if (r.ToString() == item.Num)
                        {
                            item.Count++;

                            listView1.Items.Clear();
                            foreach (var cli in dB_Text.texts)
                            {

                                ListViewItem lvi = new ListViewItem(cli.Text);
                                lvi.SubItems.Add(cli.Num);
                                lvi.SubItems.Add(cli.Count.ToString());
                                listView1.Items.Add(lvi);


                            }
                            panel1.Hide();
                            panel2.Dock = DockStyle.Left;
                            panel2.Show();
                            this.Height = 505;
                            this.Width = 303;
                            panel3.Hide();
                        }

                      

                    }

                }
                i++;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer_count++;
            if (timer_count == 10)
            {
                timer1.Stop();
                random_task();
                timer_count = 0;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dB_Text.texts.Clear();
            num = 0;
            num_p = 0;
            label1.Text = "1";
            listView1.Items.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
