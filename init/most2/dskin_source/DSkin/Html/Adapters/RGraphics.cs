﻿namespace DSkin.Html.Adapters
{
    using DSkin.Html.Adapters.Entities;
    using DSkin.Html.Core.Utils;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public abstract class RGraphics : IDisposable
    {
        protected readonly RAdapter _adapter;
        protected readonly Stack<RRect> _clipStack = new Stack<RRect>();

        protected RGraphics(RAdapter adapter, RRect initialClip)
        {
            ArgChecker.AssertArgNotNull(adapter, "global");
            this._adapter = adapter;
            this._clipStack.Push(initialClip);
        }

        public abstract void Dispose();
        public abstract void DrawImage(RImage image, RRect destRect);
        public abstract void DrawImage(RImage image, RRect destRect, RRect srcRect);
        public abstract void DrawLine(RPen pen, double x1, double y1, double x2, double y2);
        public abstract void DrawPath(RBrush brush, RGraphicsPath path);
        public abstract void DrawPath(RPen pen, RGraphicsPath path);
        public abstract void DrawPolygon(RBrush brush, RPoint[] points);
        public abstract void DrawRectangle(RBrush brush, double x, double y, double width, double height);
        public abstract void DrawRectangle(RPen pen, double x, double y, double width, double height);
        public abstract void DrawString(string str, RFont font, RColor color, RPoint point, RSize size, bool rtl);
        public RRect GetClip()
        {
            return this._clipStack.Peek();
        }

        public abstract RGraphicsPath GetGraphicsPath();
        public RBrush GetLinearGradientBrush(RRect rect, RColor color1, RColor color2, double angle)
        {
            return this._adapter.GetLinearGradientBrush(rect, color1, color2, angle);
        }

        public RPen GetPen(RColor color)
        {
            return this._adapter.GetPen(color);
        }

        public RBrush GetSolidBrush(RColor color)
        {
            return this._adapter.GetSolidBrush(color);
        }

        public abstract RBrush GetTextureBrush(RImage image, RRect dstRect, RPoint translateTransformLocation);
        public abstract RSize MeasureString(string str, RFont font);
        public abstract void MeasureString(string str, RFont font, double maxWidth, out int charFit, out double charFitWidth);
        public abstract void PopClip();
        public abstract void PushClip(RRect rect);
        public abstract void PushClipExclude(RRect rect);
        public abstract void ReturnPreviousSmoothingMode(object prevMode);
        public abstract object SetAntiAliasSmoothingMode();
    }
}

