﻿namespace DSkin.DSkinSv
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;

    [DebuggerStepThrough, DesignerCategory("code"), GeneratedCode("System.Web.Services", "4.0.30319.19408")]
    public class guCompletedEventArgs : AsyncCompletedEventArgs
    {
        private object[] object_0;

        internal guCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
        {
            this.object_0 = results;
        }

        public string Result
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return (string) this.object_0[0];
            }
        }
    }
}

