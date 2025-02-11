using System.ComponentModel;
using System.Text;

// XOR ENCRYPTION

namespace File_Encryption
{
    public partial class Form1 : Form
    {

        // Private key for XOR
        private const string key = "GWAPO";
        // Converted to bytes
        private readonly byte[] keyBytes = Encoding.ASCII.GetBytes(key);

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

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate);
            int[] temp = new int[fs.Length];
            for (int x = 0; x < fs.Length; x++)
            {
                temp[x] = fs.ReadByte();

            }

            for (int x = 0; x < fs.Length; x++)
            {
                // Encryption logic of XOR using the private key
                temp[x] = temp[x] ^ keyBytes[x % keyBytes.Length];
            }
            fs.Close();
            fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate);
            for (int x = 0; x < fs.Length; x++)
            {
                fs.WriteByte((byte)temp[x]);

            }
            fs.Close();
        }

        private void openFileDialog2_FileOk_1(object sender, CancelEventArgs e)
        {
            FileStream fs = new FileStream(openFileDialog2.FileName, FileMode.OpenOrCreate);
            int[] temp = new int[fs.Length];
            for (int x = 0; x < fs.Length; x++)
            {
                temp[x] = fs.ReadByte();

            }

            for (int x = 0; x < fs.Length; x++)
            {
                // Decryption logic, just encrpyt it again to return to original data
                temp[x] = temp[x] ^ keyBytes[x % keyBytes.Length];
            }
            fs.Close();
            fs = new FileStream(openFileDialog2.FileName, FileMode.OpenOrCreate);
            for (int x = 0; x < fs.Length; x++)
            {
                fs.WriteByte((byte)temp[x]);

            }
            fs.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
