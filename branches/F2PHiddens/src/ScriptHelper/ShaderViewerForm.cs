using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HiddenObjectStudio.Core;

namespace WindowsFormsApplication2
{
    public partial class ShaderViewerForm : Form
    {
        Image[] _images;
        String[] _imagesName;
        string[] pngImageMass;
        Timer _tm;
        Image loadedImage;
        //PictureBox pbBack = new PictureBox();
        int _i = 0;
        int _maxHeight = 120;
        int _maxWidth = 1000;
        
        private bool _isImageMassGenerated = false;
        private bool isDragging = false;
        private bool _isTimer = false;
        private bool _isImageBackground = false;
        private int pb1CurrentX, pb1CurrentY;
        private Point _shaderGamePosition;
        private Point _defaultShaderPos = new Point(0, 0);



        public ShaderViewerForm(string filePath)
        {
            InitializeComponent();
            InitializefolderBrowserDialog(filePath);
           // flowLayoutPanel1.BackColor = System.Drawing.Color.White;
           // pictureBox1.BackColor = System.Drawing.Color.White;
            pb1.MouseDown += new MouseEventHandler(pb1_MouseDown);
            pb1.MouseMove += new MouseEventHandler(pb1_MouseMove);
            pb1.MouseUp += new MouseEventHandler(pb1_MouseUp);
        }

        private void InitializefolderBrowserDialog(string filePath)
        {
            string folderPath = filePath.Replace("\\\\", "\\");
            this.folderBrowserDialog1.SelectedPath = folderPath + "\\textures";
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (_isTimer)
            {
                _tm.Stop();
                _isTimer = false;
            }
            toolStripButton1.Enabled = false;
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = false;
            
            if (_isImageMassGenerated)
            {
                for (int j = 0; j < _images.Length; j++)
                {
                    _images[j].Dispose();
                }
            }
            
            _i = 0;

            DialogResult dr = this.folderBrowserDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string file = folderBrowserDialog1.SelectedPath;
                textBox1.Text = file;
                
                try
                {
                    pngImageMass = Directory.GetFiles(file, "*.png");
                    if (!ArrayElementNameLengthCheck(pngImageMass))
                    {
                        System.Windows.Forms.MessageBox.Show("Warning!!! Имена файлов анимации имеют разную длину!!!");
                    }
                    Array.Sort(pngImageMass);
                   
                    _images = new Image[pngImageMass.Length];
                     
                    _imagesName = new String[pngImageMass.Length];

                    FramesCountDataSet(_images.Length);
                    
                    toolStripProgressBar1.Minimum = 0;
                    
                    toolStripProgressBar1.Maximum = _images.Length;
                    
                    toolStripProgressBar1.Value = 0;
                    for (int i = 0; i < pngImageMass.Length; i++)
                    {
                        _images[i] = Image.FromFile(pngImageMass[i]);
                        _isImageMassGenerated = true;
                        string imageName = AttString(pngImageMass[i], '\\');
                      
                        _imagesName[i] = imageName;
                        //toolStripStatusLabel1.Text = _imagesName[i];
                        
                        toolStripProgressBar1.Value = i;

                        if (_maxHeight < _images[i].Height)
                        {
                            _maxHeight = _images[i].Height;
                        }
                        if (_maxWidth < _images[i].Width)
                        {
                            _maxWidth = _images[i].Width;
                        }

                    }
                    
                    if (!_isImageBackground)
                    {
                        this.Size = new System.Drawing.Size(_maxWidth + 30, _maxHeight + 170);
                    }
                    else
                    {
                        this.Size = new System.Drawing.Size(pbBack.Size.Width + 30, pbBack.Size.Height + 170);
                    }

                    if (_isImageBackground)
                    {
                        pb1.Parent = pbBack;
                    }
                    pb1.Visible = true;
                    pb1.Enabled = true;
                    pb1.BorderStyle = BorderStyle.FixedSingle;
                    pb1.Height = _images[0].Height;
                    pb1.Width = _images[0].Width;
                    SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                    pb1.BackColor = Color.Transparent;
                    pb1.Image = _images[0];
                    //pb1.BringToFront();

                    toolStripButton1.Enabled = true;
                    toolStripButton4.Enabled = true;
                    toolStripButton5.Enabled = true;
                    
                    toolStripProgressBar1.Value = 0;


                    Array.Clear(pngImageMass, 0, pngImageMass.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot select the image: " + file.Substring(file.LastIndexOf('\\') + 1)
                        + ". You may not have permission to read the file, or " +
                        "it may be corrupt.\n\nReported error: " + ex.Message);
                }
            }
            else
            {
                toolStripButton1.Enabled = true;
            }
        }

        private void FramesCountDataSet(int counts)
        {
            List<string> _comboBoxMinValue = new List<string>();
            List<string> _comboBoxMaxValue = new List<string>();
            try
            {
                int framesMaxValue = counts;
                for (int i = 0; i < framesMaxValue; i++)
                {
                    _comboBoxMinValue.Add(Convert.ToString(i));
                }
                comboBoxStartFrame.DataSource = _comboBoxMinValue;
                comboBoxStartFrame.Enabled = true;
                for (int k = comboBoxStartFrame.Items.Count - 1; k < framesMaxValue; k++)
                {
                    _comboBoxMaxValue.Add(Convert.ToString(k));
                }
                comboBoxFinalFrame.DataSource = _comboBoxMaxValue;
                comboBoxFinalFrame.Enabled = true;
            }
            catch { }
        }

        private void comboBoxStartFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> _comboBoxMaxValue = new List<string>();
            int start = comboBoxStartFrame.SelectedIndex;
            for (int k = start; k < _images.Length; k++)
            {
                _comboBoxMaxValue.Add(Convert.ToString(k));
            }
            comboBoxFinalFrame.DataSource = _comboBoxMaxValue;
        }

        private bool ArrayElementNameLengthCheck(string[] inputArray)
        {
            int nameLength = inputArray[0].Length;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i].Length != nameLength)
                {
                    return false;
                }
            }
            return true;
        }
         
        private string AttString(string attName, char spliter)
        {
            string attSubString;
            attSubString = attName.Substring(attName.LastIndexOf(spliter) + 1);
            return attSubString;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!_isImageBackground)
            {
                ColorDialog colorDialog = new ColorDialog();

                if (colorDialog.ShowDialog() != DialogResult.Cancel)
                {
                    pictureBox1.BackColor = colorDialog.Color;
                    splitContainer1.Panel2.BackColor = colorDialog.Color;
                    pb1.BackColor = Color.Transparent;
                }
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            _tm.Interval = trackBar1.Maximum - trackBar1.Value + 1;
            int a = 1000 / _tm.Interval;
            label2.Text = a.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_isImageBackground)
            {
                pb1.Location = new Point(pbBack.Left, pbBack.Top + pbBack.Height - pb1.Height);
                _shaderGamePosition = new Point(pb1.Left - pbBack.Left, ((pbBack.Top + pbBack.Height) - (pb1.Top + pb1.Height)));
                textBoxShPosX.Text = _shaderGamePosition.X.ToString();
                textBoxShPosY.Text = _shaderGamePosition.Y.ToString();
            }
            else
            {
                pb1.Location = new Point(5, 5);
            }
            
        }

        private void pb1_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            Bitmap myBitmap = new Bitmap(pb1.Image);
            Color pixelColor = myBitmap.GetPixel(e.X, e.Y);
            
            pb1CurrentX = e.X;
            pb1CurrentY = e.Y;
        }

        private void pb1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                pb1.Top = pb1.Top + (e.Y - pb1CurrentY);
                pb1.Left = pb1.Left + (e.X - pb1CurrentX);
                if (_isImageBackground)
                {
                    _shaderGamePosition = new Point(pb1.Left - pbBack.Left, ((pbBack.Top + pbBack.Height) - (pb1.Top + pb1.Height)));
                    textBoxShPosX.Text = _shaderGamePosition.X.ToString();
                    textBoxShPosY.Text = _shaderGamePosition.Y.ToString();
                }
                string k = (pbBack.Top + pbBack.Height).ToString();
                this.Text = k + " || " + pbBack.Left;
                if (_isImageBackground)
                {
                    pb1.Parent = pbBack;
                }
                pb1.Invalidate();

            }
        }

        private void pb1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void buttonSelectBackground_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialogPic.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string file = openFileDialogPic.FileName;
                System.Windows.Forms.MessageBox.Show(file);
                try
                {
                    pbBack.Visible = true;

                    loadedImage = Image.FromFile(file);
                    pbBack.BorderStyle = BorderStyle.FixedSingle;
                    pbBack.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                    pbBack.Height = loadedImage.Height;
                    pbBack.Width = loadedImage.Width;
                    
                    if ((pbBack.Height != 768) || (pbBack.Width != 1024))
                    {
                        DialogResult resultSmallSizeError = System.Windows.Forms.MessageBox.Show("Picture size must be 1024 x 768!" + "\n\n" +
                            "Do you want re-select image?", "Error! Incorrect pictures size", MessageBoxButtons.OKCancel);
                        if (resultSmallSizeError == DialogResult.OK)
                        {
                            buttonSelectBackground_Click(sender, e);
                        }
                    }
                    else
                    {
                        int k = pbBack.Size.Width + 30;
                        if ( k < _maxWidth)
                        {
                            k = _maxWidth;
                        }
                        this.Size = new System.Drawing.Size(k, pbBack.Size.Height + 150);
                        //splitContainer1.Panel2.BackgroundImage = loadedImage;
                        pbBack.Image = loadedImage;
                        pbBack.Location = new Point(0, 0);
                        
                        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                        pb1.BackColor = Color.Transparent;
                        
                        pbBack.SendToBack();
                        _isImageBackground = true;
                        checkBoxBack.Checked = true;
                        textBoxShPosX.Enabled = true;
                        textBoxShPosY.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot select the image: " + file.Substring(file.LastIndexOf('\\') + 1)
                        + ". You may not have permission to read the file, or " +
                        "it may be corrupt.\n\nReported error: " + ex.Message);
                }
            }
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!_isTimer)
            {
                _tm = new Timer();
                _tm.Enabled = true;
                _tm.Interval = trackBar1.Value;
                _tm.Tick += new EventHandler(tm_Tick);
                trackBar1.Enabled = true;
                _isTimer = true;
                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;

                toolStripButton4.Enabled = false;
                toolStripButton5.Enabled = false;
            }
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            //_i = Convert.ToInt16(comboBoxStartFrame.SelectedItem);
            if (_images != null)
            {
                _i = _i + 1;
                
                if (_i >= _images.Length)
                {
                    _i = 0;
                }
                toolStripStatusLabel1.Text = "Playing: " + _imagesName[_i];
                if (_isImageBackground)
                {
                    pb1.Parent = pbBack;
                }
                pb1.Height = _images[_i].Height;
                pb1.Width = _images[_i].Width;
                pb1.Image = _images[_i];
                pb1.BorderStyle = BorderStyle.FixedSingle;
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                pb1.BackColor = Color.Transparent;
                //   pb1.BringToFront();
                
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (_isTimer)
            {
                _tm.Stop();
                _isTimer = false;

                toolStripButton4.Enabled = true;
                toolStripButton5.Enabled = true;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (_isTimer)
            {
                _tm.Stop();
            }
            _isTimer = false;
            _i = 0;
            pb1.Height = _images[0].Height;
            pb1.Width = _images[0].Width;
            pb1.BackColor = Color.Transparent;
            pb1.Image = _images[0];

            toolStripButton4.Enabled = true;
            toolStripButton5.Enabled = true;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (!_isTimer)
            {
                if (_i == 0)
                {
                    _i = _images.Length - 1;
                }
                else
                {
                    _i = _i - 1;
                }
                pb1.Height = _images[_i].Height;
                pb1.Width = _images[_i].Width;
                pb1.BackColor = Color.Transparent;
                pb1.Image = _images[_i];
                toolStripStatusLabel1.Text = "Playing: " + _imagesName[_i];
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (!_isTimer)
            {
                _i = _i + 1;
                if (_i >= _images.Length)
                {
                    _i = 0;
                }

                pb1.Height = _images[_i].Height;
                pb1.Width = _images[_i].Width;
                pb1.BackColor = Color.Transparent;
                pb1.Image = _images[_i];
                toolStripStatusLabel1.Text = "Playing: " + _imagesName[_i];
                
            }
        }

        public static Bitmap CombineAndResizeTwoImages(Image image1, Image image2, int width, int height)
        {
            //a holder for the result
            Bitmap result = new Bitmap(width, height);

            //use a graphics object to draw the resized image into the bitmap
            using (Graphics graphics = Graphics.FromImage(result))
            {
                //set the resize quality modes to high quality
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //draw the images into the target bitmap
                graphics.DrawImage(image1, 0, 0, result.Width, result.Height);
                graphics.DrawImage(image2, 0, 0, result.Width, result.Height);
                
            }

            //return the resulting bitmap
            return result;
        }

        private void textBoxShPosX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxShPosY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxShPosX_TextChanged(object sender, EventArgs e)
        {
            if (textBoxShPosX.Text != String.Empty)
            {
                pb1.Left = Convert.ToInt16(textBoxShPosX.Text) + pbBack.Left;
            }
            else
            {
                pb1.Left = pbBack.Left;
            }
        }

        private void textBoxShPosY_TextChanged(object sender, EventArgs e)
        {
            if (textBoxShPosY.Text != String.Empty)
            {
                pb1.Top = pbBack.Top + pbBack.Height - Convert.ToInt16(textBoxShPosY.Text) - pb1.Height;
            }
            else
            {
                pb1.Top = pbBack.Top + pbBack.Height - pb1.Height;
            }
        }

        private void ShaderViewerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isTimer)
            {
                _tm.Stop();
            }
            _isTimer = false;
            _i = 0;
            
            if (_isImageMassGenerated)
            {
                for (int j = 0; j < _images.Length; j++)
                {
                    _images[j].Dispose();
                }
            }
        }

        
        
    }
}
