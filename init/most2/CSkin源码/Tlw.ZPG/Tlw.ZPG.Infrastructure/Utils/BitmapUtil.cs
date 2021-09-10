using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Tlw.ZPG.Infrastructure.Utils
{
    /// <summary>
    /// ����������֤��ͼ�����
    /// </summary>
    public class BitmapUtil
    {
        #region ˽�б���
        private int fontSize = 14;//�����С
        private int offsetX;
        private int offsetY;
        private Color bgColor = Color.Empty;
        private Color borderColor = Color.Empty;
        private ImageFormat imageFormat = ImageFormat.Png;
        private Color foreColor = Color.White;

        #endregion

        #region ��������

        /// <summary>
        /// ��ȡ�������ַ���ɫ����IsRandomforeColor����Ϊtrue��ʱ�򣬸���������Ч
        /// </summary>
        public Color ForeColor
        {
            get
            {
                return foreColor;
            }
            set
            {
                foreColor = value;
            }
        }

        /// <summary>
        /// �ַ���ɫ�Ƿ������Ϊtrue����foreColor������Ч
        /// </summary>
        public bool IsRandomColor { get; set; }

        /// <summary>
        /// ����X��ƫ����
        /// </summary>
        public int OffsetX
        {
            set
            {
                offsetX = value;
            }
        }

        /// <summary>
        /// ����Y��ƫ����
        /// </summary>
        public int OffsetY
        {
            set
            {
                offsetY = value;
            }
        }

        /// <summary>
        /// ����ͼ���ļ���ʽ��Ĭ��ΪPng��ʽ
        /// </summary>
        public ImageFormat ImageFormat
        {
            set
            {
                imageFormat = value;
            }
        }

        /// <summary>
        /// ����ͼ�񱳾�ɫ
        /// </summary>
        public Color BgColor
        {
            set
            {
                this.bgColor = value;
            }
        }

        /// <summary>
        /// ���ñ߿���ɫ
        /// </summary>
        public Color BorderColor
        {
            set
            {
                this.borderColor = value;
            }
        }

        /// <summary>
        /// ���������С
        /// </summary>
        public int FontSize
        {
            set { fontSize = value; }
        }

        #endregion


        /// <summary>
        /// ������֤�������
        /// </summary>
        /// <returns></returns>
        public MemoryStream OutputStream(string code)
        {
            return OutputStream(GetBitmap(code));
        }

        /// <summary>
        /// ������֤�������
        /// </summary>
        /// <returns></returns>
        public MemoryStream OutputStream(Bitmap map)
        {
            MemoryStream memoryStream = new MemoryStream();
            if (map != null)
            {
                map.Save(memoryStream, imageFormat);//���浽��
            }
            return memoryStream;
        }

        //���������ɫ
        private System.Drawing.Color GetRandomColor()
        {
            Random redRandom = new Random((int)DateTime.Now.Ticks);
            System.Threading.Thread.Sleep(redRandom.Next(50));
            Random greenRandom = new Random((int)DateTime.Now.Ticks);
            System.Threading.Thread.Sleep(greenRandom.Next(50));
            Random blueRandom = new Random((int)DateTime.Now.Ticks);

            int red = redRandom.Next(256);
            int green = greenRandom.Next(256);
            int blue = blueRandom.Next(256);

            return System.Drawing.Color.FromArgb(red, green, blue);
        }

        /// <summary>
        /// ��ʼ����֤��ͼ��
        /// </summary>
        /// <returns></returns>
        public Bitmap GetBitmap(string code)
        {
            Bitmap bitmap = null;
            if (!string.IsNullOrEmpty(code))
            {
                int int_ImageWidth = code.Length * fontSize;//����ͼ����
                Random newRandom = new Random();
                Font theFont = new Font("Arial", fontSize);//Ĭ��14px������
                float hight = theFont.GetHeight();//����߶�
                bitmap = new System.Drawing.Bitmap(int_ImageWidth + offsetX, (int)hight + offsetY);//Ĭ��ͼ��Ϊ����߶�
                using (System.Drawing.Graphics theGraphics = System.Drawing.Graphics.FromImage(bitmap))
                {
                    //���ñ���ɫ
                    theGraphics.Clear(bgColor);
                    //�����α߿�
                    theGraphics.DrawRectangle(new Pen(borderColor, 1), 0, 0, int_ImageWidth + offsetX - 2, hight + offsetY - 2);

                    //��ÿ���ַ�
                    for (int int_index = 0; int_index < code.Length; int_index++)
                    {
                        string str_char = code[int_index].ToString();
                        //�ַ���ɫ
                        Brush newBrush = null;
                        if (IsRandomColor)
                        {
                            newBrush = new SolidBrush(GetRandomColor());
                        }
                        else
                        {
                            newBrush = new SolidBrush(foreColor);
                        }
                        //�ַ�λ�����
                        Point thePos = new Point(int_index * (fontSize - 1) + newRandom.Next(offsetX), newRandom.Next(offsetY));
                        theGraphics.DrawString(str_char, theFont, newBrush, thePos);
                    }
                }
            }
            return bitmap;
        }
    }
}
