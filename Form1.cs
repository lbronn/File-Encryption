using System.ComponentModel;

namespace File_Encryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate);
            int[] temp = new int[fs.Length];
            for (int x = 0; x < fs.Length; x++)
            {
                temp[x] = fs.ReadByte();

            }

            for (int x = 0; x < fs.Length; x++)
            {
                temp[x] = temp[x] + 3;

            }
            fs.Close();
            fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate);
            for (int x = 0; x < fs.Length; x++)
            {
                fs.WriteByte((byte)temp[x]);

            }
            fs.Close();


        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            FileStream fs = new FileStream(openFileDialog2.FileName, FileMode.OpenOrCreate);
            int[] temp = new int[fs.Length];
            for (int x = 0; x < fs.Length; x++)
            {
                temp[x] = fs.ReadByte();

            }

            for (int x = 0; x < fs.Length; x++)
            {
                temp[x] = temp[x] - 3;

            }
            fs.Close();
            fs = new FileStream(openFileDialog2.FileName, FileMode.OpenOrCreate);
            for (int x = 0; x < fs.Length; x++)
            {
                fs.WriteByte((byte)temp[x]);

            }
            fs.Close();
        }
    }
}
