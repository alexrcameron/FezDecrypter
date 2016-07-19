using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FezDecrypter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        Image smallSymbols = FezDecrypter.Properties.Resources.FEZ_Alphabet_Medium;
        int tilePixels = 24;
        Bitmap background = new Bitmap(312, 422);
        List<int> inputList = new List<int>();
        string[] characters;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = FezDecrypter.Properties.Resources.decrypter;
            Image symbols = FezDecrypter.Properties.Resources.FEZ_Alphabet_Big;
            
            Image[] tiles = new Bitmap[24];

            int largeTilePixels = 48;

            Button[] buttons = { button1, button2, button3, button4, 
                                button5, button6,  button7, button8, 
                                button9, button10,  button11, button12,
                                button13, button14, button15, button16, 
                                button17, button18,  button19, button20, 
                                button21, button22,  button23, button24 };

            string[] temp = { " ", "A", "B", "C", "D", "E", "F", 
                                   "G", "H", "I", "J", "K", "L", 
                                   "M", "N", "O", "P", "Z", "R", 
                                   "S", "T", "U", "W", "X", "Y" };

            characters = temp;

            int row = 0;
            int column = 0;

            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i] = new Bitmap(largeTilePixels, largeTilePixels);

                row = i / 6;
                column = i % 6;

                using (Graphics g = Graphics.FromImage(tiles[i]))
                {
                    
                    g.DrawImage(symbols, new Rectangle(0, 0, 48, 48), new Rectangle(column*48, row*48, 48, 48), GraphicsUnit.Pixel);

                    buttons[i].Text = "";
                    buttons[i].Image = tiles[i];
                }
            }

            updateImage();

        }

        private void space_btn_Click(object sender, EventArgs e)
        {
            inputList.Add(0);
            updateImage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputList.Add(1);
            updateImage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inputList.Add(2);
            updateImage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            inputList.Add(3);
            updateImage();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            inputList.Add(4);
            updateImage();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            inputList.Add(5);
            updateImage();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            inputList.Add(6);
            updateImage();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            inputList.Add(7);
            updateImage();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            inputList.Add(8);
            updateImage();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            inputList.Add(9);
            updateImage();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            inputList.Add(10);
            updateImage();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            inputList.Add(11);
            updateImage();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            inputList.Add(12);
            updateImage();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            inputList.Add(13);
            updateImage();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            inputList.Add(14);
            updateImage();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            inputList.Add(15);
            updateImage();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            inputList.Add(16);
            updateImage();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            inputList.Add(17);
            updateImage();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            inputList.Add(18);
            updateImage();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            inputList.Add(19);
            updateImage();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            inputList.Add(20);
            updateImage();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            inputList.Add(21);
            updateImage();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            inputList.Add(22);
            updateImage();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            inputList.Add(23);
            updateImage();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            inputList.Add(24);
            updateImage();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            if (inputList.Count > 0)
            {
                inputList.RemoveAt(inputList.Count - 1);
                updateImage();
            }
        }

        private void updateImage()
        {
            string inputString = "";
            int cursorRow = inputList.Count % 17;
            int cursorColumn = (inputList.Count / 17)+1;

            int symbolRow, symbolColumn, row, column;
            using (Graphics g = Graphics.FromImage(background))
            {
                g.FillRectangle(new SolidBrush(Color.Black), 0, 0, 312, 422);

                for (int i = 0; i < inputList.Count; i++)
                {
                    inputString += characters[inputList[i]];

                    symbolRow = i % 17;
                    symbolColumn = i / 17;

                    row = (inputList[i] - 1) / 6;
                    column = (inputList[i] - 1) % 6;

                    g.DrawImage(smallSymbols, new Rectangle(background.Width - (tilePixels * (symbolColumn + 1)), tilePixels * symbolRow, tilePixels, tilePixels), new Rectangle(column * tilePixels, row * tilePixels, tilePixels, tilePixels), GraphicsUnit.Pixel);
                }

                g.DrawRectangle(new Pen(new SolidBrush(Color.Red)),
                                background.Width - (tilePixels*cursorColumn+1),
                                tilePixels*cursorRow, tilePixels, tilePixels);

            }

            cypher_pb.Image = background;
            decyphered_tb.Text = inputString;
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            inputList = new List<int>();
            updateImage();
        }

        private void decyphered_tb_TextChanged(object sender, EventArgs e)
        {
            inputList = new List<int>();
            int code;
            string temp;

            int position = decyphered_tb.SelectionStart;

            temp = decyphered_tb.Text.ToUpper();

            for (int i = 0; i < decyphered_tb.TextLength; i++)
            {
                code = Array.IndexOf(characters, temp[i].ToString());

                if (temp[i] == 'V')
                    code = Array.IndexOf(characters, "U");

                if (temp[i] == 'Q')
                    code = Array.IndexOf(characters, "K");
                    
                if (code >= 0 && code <= 24)
                    inputList.Add(code);
            }

            updateImage();

            decyphered_tb.Select(position, 0);
        }
    }
}
