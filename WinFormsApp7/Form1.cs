namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Thread soundThread;
        private Thread textThread;
        private bool stopSound;
        private void PlaySound(int frequency)
        {
            Console.Beep(frequency, 1000);
        }
        private void UpdateLabelText(string text)
        {
            if (label1.InvokeRequired)
            {
                label1.BeginInvoke(new Action(() => label1.Text = text));
            }
            else
            {
                label1.Text = text;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int frequency = 200;
            stopSound = false;
            soundThread = new Thread(() =>
            {
                for (int i = 1; i < 100; i++)
                {
                    if (stopSound == false)
                    {
                        PlaySound(frequency);
                    }
                    frequency += 18;
                }
            });
            soundThread.Start();
            frequency = 200;
            textThread = new Thread(() =>
            {
                for (int i = 1; i < 100; i++)
                {
                    if (stopSound == false)
                    {
                        UpdateLabelText("Частота звучання: " + frequency);
                        Thread.Sleep(1000);
                    }
                    frequency += 25;
                }
            });
            textThread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stopSound = true;
        }
    }
}