﻿namespace DSkin.Animations
{
    using DSkin;
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    public class FadeinFadeoutEffect : IEffects, IDisposable
    {
        private Bitmap bitmap_0;
        private Bitmap bitmap_1;
        private bool bool_0 = true;
        private bool bool_1 = false;
        private bool bool_2 = false;
        private float float_0 = 0f;
        private float float_1 = 0.05f;

        public void Dispose()
        {
            if (this.bitmap_0 != null)
            {
                this.bitmap_0.Dispose();
                this.bitmap_0 = null;
            }
            GC.SuppressFinalize(this);
        }

        public Bitmap DoEffect(out Point offset)
        {
            offset = new Point();
            if ((this.bitmap_0 == null) || (this.bitmap_0.Size != this.bitmap_1.Size))
            {
                this.bitmap_0 = new Bitmap(this.bitmap_1.Width, this.bitmap_1.Height);
            }
            using (Graphics graphics = Graphics.FromImage(this.bitmap_0))
            {
                graphics.Clear(Color.Transparent);
                if (!this.bool_2)
                {
                    this.bool_2 = true;
                }
                if (!(((this.float_0 >= (1f - this.float_1)) || !this.bool_0) ? ((this.float_0 <= this.float_1) || this.bool_0) : false))
                {
                    this.bool_1 = false;
                    graphics.DrawImage(this.bitmap_1, new Rectangle(0, 0, this.bitmap_1.Width, this.bitmap_1.Height), 0, 0, this.bitmap_1.Width, this.bitmap_1.Height, GraphicsUnit.Pixel, ImageEffects.ChangeOpacity(this.float_0));
                    if (this.bool_0)
                    {
                        this.float_0 += this.float_1;
                    }
                    else
                    {
                        this.float_0 -= this.float_1;
                    }
                }
                else
                {
                    graphics.DrawImage(this.bitmap_1, 0, 0);
                    this.bool_1 = true;
                }
            }
            return this.bitmap_0;
        }

        public void Reset()
        {
            this.bool_2 = false;
            if (this.bool_0)
            {
                this.float_0 = 0f;
            }
            else
            {
                this.float_0 = 1f;
            }
        }

        public bool CanDesc
        {
            get
            {
                return true;
            }
        }

        public bool IsAsc
        {
            get
            {
                return this.IsAsc;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        public bool IsFinal
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
            }
        }

        public string Name
        {
            get
            {
                return "淡入淡出";
            }
        }

        public float OpacityChange
        {
            get
            {
                return this.float_1;
            }
            set
            {
                this.float_1 = value;
            }
        }

        public Bitmap Original
        {
            get
            {
                return this.bitmap_1;
            }
            set
            {
                this.bitmap_1 = value;
            }
        }
    }
}

