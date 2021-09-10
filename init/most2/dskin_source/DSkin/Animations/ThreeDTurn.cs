﻿namespace DSkin.Animations
{
    using DSkin;
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    public class ThreeDTurn : IEffects, IDisposable
    {
        private Bitmap bitmap_0;
        private bool bool_0 = true;
        private bool bool_1 = false;
        private double double_0 = 0.7;
        private double double_1 = 0.01;
        private double double_2 = 0.015;
        private double double_3 = 0.05;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Bitmap DoEffect(out Point offset)
        {
            offset = new Point();
            if (this.bool_0)
            {
                this.double_0 += this.double_2;
                this.double_1 += this.double_3;
                if (this.double_0 >= 1.0)
                {
                    this.double_0 = 1.0;
                    this.IsFinal = true;
                }
                if (this.double_1 >= 1.0)
                {
                    this.double_1 = 1.0;
                }
            }
            else
            {
                this.double_0 -= this.double_2;
                this.double_1 -= this.double_3;
                if (this.double_0 <= 0.7)
                {
                    this.double_0 = 0.7;
                    this.IsFinal = true;
                }
                if (this.double_1 <= 0.01)
                {
                    this.double_1 = 0.01;
                }
            }
            return ImageEffects.TrapezoidTransformation(this.Original, this.double_0, this.double_1, this.bool_0, true);
        }

        public void Reset()
        {
            if (this.bool_0)
            {
                this.double_0 = 0.7;
                this.double_1 = 0.01;
            }
            else
            {
                this.double_0 = 1.0;
                this.double_1 = 1.0;
            }
            this.IsFinal = false;
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
                return this.bool_0;
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
                return "3D翻转特效";
            }
        }

        public Bitmap Original
        {
            get
            {
                return this.bitmap_0;
            }
            set
            {
                this.bitmap_0 = value;
            }
        }
    }
}

