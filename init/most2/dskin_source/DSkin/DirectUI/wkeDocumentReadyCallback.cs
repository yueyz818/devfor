﻿namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void wkeDocumentReadyCallback(IntPtr webView, ref DSkin.DirectUI.wkeDocumentReadyInfo info);
}

