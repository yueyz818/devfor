/********************************************************************
 * *
 * * 使本项目源码或本项目生成的DLL前请仔细阅读以下协议内容，如果你同意以下协议才能使用本项目所有的功能，
 * * 否则如果你违反了以下协议，有可能陷入法律纠纷和赔偿，作者保留追究法律责任的权利。
 * *
 * * 1、你可以在开发的软件产品中使用和修改本项目的源码和DLL，但是请保留所有相关的版权信息。
 * * 2、不能将本项目源码与作者的其他项目整合作为一个单独的软件售卖给他人使用。
 * * 3、不能传播本项目的源码和DLL，包括上传到网上、拷贝给他人等方式。
 * * 4、以上协议暂时定制，由于还不完善，作者保留以后修改协议的权利。
 * *
 * * Copyright (C) 2013-? cskin Corporation All rights reserved.
 * * 网站：CSkin界面库 http://www.cskin.net
 * * 作者： 乔克斯 QQ：345015918 .Net项目技术组群：306485590
 * * 请保留以上版权信息，否则作者将保留追究法律责任。
 * *
 * * 创建时间：2013-12-08
 * * 说明：SBM.cs
 * *
********************************************************************/

using System;

namespace CCWin.Win32.Const
{
    public class SBM
    {
        private SBM() { }

        public const int SBM_SETPOS = 0x00E0;
        public const int SBM_GETPOS = 0x00E1;
        public const int SBM_SETRANGE = 0x00E2;
        public const int SBM_SETRANGEREDRAW = 0x00E6;
        public const int SBM_GETRANGE = 0x00E3;
        public const int SBM_ENABLE_ARROWS = 0x00E4;
        public const int SBM_SETSCROLLINFO = 0x00E9;
        public const int SBM_GETSCROLLINFO = 0x00EA;
        public const int SBM_GETSCROLLBARINFO = 0x00EB;
    }
}
