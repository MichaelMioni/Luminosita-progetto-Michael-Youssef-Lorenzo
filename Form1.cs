namespace Luminosita_progetto
{
    public partial class Form1 : Form
    {
        Bitmap immagine;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files (*.jpg; *.jpeg; *.bmp; *.png) | *jpg; *.jpeg; *.bmp; *.png";
            open.ShowDialog();


            immagine = new Bitmap(open.FileName);

            float fatform = (float)immagine.Width / (float)pictureBox1.Width;
            float highform = (float)immagine.Height / (float)pictureBox1.Height;

            Bitmap Lorenzo = new Bitmap(immagine, new Size((int)(immagine.Width / fatform), (int)(immagine.Height / highform)));

            pictureBox1.Image = Lorenzo;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBarLuminosita.Value.ToString();

            float fatform = (float)immagine.Width / (float)pictureBox1.Width;
            float highform = (float)immagine.Height / (float)pictureBox1.Height;
            Bitmap Lorenzo = new Bitmap(immagine, new Size((int)(immagine.Width / fatform), (int)(immagine.Height / highform)));
            Bitmap NewImage = new Bitmap(Lorenzo.Width, Lorenzo.Height);

            int x, y;

            for (x = 0; x < Lorenzo.Width; x++)
            {
                for (y = 0; y < Lorenzo.Height; y++)
                {

                    Color pixel = Lorenzo.GetPixel(x, y);

                    int R = pixel.R + trackBarLuminosita.Value - 255;
                    int G = pixel.G + trackBarLuminosita.Value - 255;
                    int B = pixel.B + trackBarLuminosita.Value - 255;

                    if (R < 0) R = 0;
                    if (R > 255) R = 255;

                    if (G < 0) G = 0;
                    if (G > 255) G = 255;

                    if (B < 0) B = 0;
                    if (B > 255) B = 255;

                    Color newpixel = Color.FromArgb(R, G, B);
                    NewImage.SetPixel(x, y, newpixel);
                }
            }
            pictureBox1.Image = NewImage;
        }
    }
}