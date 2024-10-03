using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nemesis
{
    public class Bytebeat1 : WaveProvider32
    {
        private int t = 0;
        private bool switchSound = true;

        public Bytebeat1()
        {
            this.SetWaveFormat(8000, 1); // taxa de amostragem mono
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            for (int i = 0; i < sampleCount; i++)
            {
                byte soundByte = switchSound ? GenerateBytebeatStrong(t) : GenerateBytebeatWeak(t);
                buffer[i + offset] = soundByte / 255f;
                t++;
            }

            switchSound = !switchSound;

            return sampleCount;
        }

        private byte GenerateBytebeatStrong(int t)
        {

            return (byte)(10 * (t >> 7 | 3 * t | t >> (t >> 15)) + (t >> 8 & 5));
        }

        private byte GenerateBytebeatWeak(int t)
        {
            return (byte)(10 * (t >> 7 | 3 * t | t >> (t >> 15)) + (t >> 8 & 5));
        }
    }

    public class Bytebeat2 : WaveProvider32
    {
        private int t = 0;
        private bool switchSound = true;

        public Bytebeat2()
        {
            this.SetWaveFormat(8000, 1); // taxa de amostragem mono
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            for (int i = 0; i < sampleCount; i++)
            {
                byte soundByte = switchSound ? GenerateBytebeatStrong(t) : GenerateBytebeatWeak(t);
                buffer[i + offset] = soundByte / 255f;
                t++;
            }

            switchSound = !switchSound;

            return sampleCount;
        }

        private byte GenerateBytebeatStrong(int t)
        {

            return (byte)(t * ((t >> 12 | t >> 8) & 63 & t >> 4));
        }

        private byte GenerateBytebeatWeak(int t)
        {
            return (byte)(t * ((t >> 12 | t >> 8) & 63 & t >> 4));
        }
    }

    public class Bytebeat3 : WaveProvider32
    {
        private int t = 0;
        private bool switchSound = true;

        public Bytebeat3()
        {
            this.SetWaveFormat(2000, 1); // taxa de amostragem mono
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            for (int i = 0; i < sampleCount; i++)
            {
                byte soundByte = switchSound ? GenerateBytebeatStrong(t) : GenerateBytebeatWeak(t);
                buffer[i + offset] = soundByte / 255f;
                t++;
            }

            switchSound = !switchSound;

            return sampleCount;
        }

        private byte GenerateBytebeatStrong(int t)
        {

            return (byte)(3 * ((t >> 1) + 20) * t >> 14 * t >> 18);
        }

        private byte GenerateBytebeatWeak(int t)
        {
            return (byte)(3 * ((t >> 1) + 20) * t >> 14 * t >> 18);
        }
    }

    public class Bytebeat4 : WaveProvider32
    {
        private int t = 0;
        private bool switchSound = true;

        public Bytebeat4()
        {
            this.SetWaveFormat(8000, 1); // taxa de amostragem mono
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            for (int i = 0; i < sampleCount; i++)
            {
                byte soundByte = switchSound ? GenerateBytebeatStrong(t) : GenerateBytebeatWeak(t);
                buffer[i + offset] = soundByte / 255f;
                t++;
            }

            switchSound = !switchSound;

            return sampleCount;
        }

        private byte GenerateBytebeatStrong(int t)
        {

            return (byte)(((t / 800 | 10) * t & 85) - t & t / 4);
        }

        private byte GenerateBytebeatWeak(int t)
        {
            return (byte)(((t / 800 | 10) * t & 85) - t & t / 4);
        }
    }

    public class Bytebeat5 : WaveProvider32
    {
        private int t = 0;
        private bool switchSound = true;

        public Bytebeat5()
        {
            this.SetWaveFormat(8000, 1); // taxa de amostragem mono
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            for (int i = 0; i < sampleCount; i++)
            {
                byte soundByte = switchSound ? GenerateBytebeatStrong(t) : GenerateBytebeatWeak(t);
                buffer[i + offset] = soundByte / 255f;
                t++;
            }

            switchSound = !switchSound;

            return sampleCount;
        }

        private byte GenerateBytebeatStrong(int t)
        {

            return (byte)(t * (t >> 30 | t >> 13) / 2 >> (t * (t >> 18 | t >> 10) & 7 ^ t >> 7 | t >> 18) | t / 16 >> (t & t / 6));
        }

        private byte GenerateBytebeatWeak(int t)
        {
            return (byte)(t * (t >> 30 | t >> 13) / 2 >> (t * (t >> 18 | t >> 10) & 7 ^ t >> 7 | t >> 18) | t / 16 >> (t & t / 6));
        }
    }

    public class Bytebeat6 : WaveProvider32
    {
        private int t = 0;
        private bool switchSound = true;

        public Bytebeat6()
        {
            this.SetWaveFormat(8000, 1); // taxa de amostragem mono
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            for (int i = 0; i < sampleCount; i++)
            {
                byte soundByte = switchSound ? GenerateBytebeatStrong(t) : GenerateBytebeatWeak(t);
                buffer[i + offset] = soundByte / 255f;
                t++;
            }

            switchSound = !switchSound;

            return sampleCount;
        }

        private byte GenerateBytebeatStrong(int t)
        {

            return (byte)((t * 43532 >> 233) * (t >> 325) | t >> 2543);
        }

        private byte GenerateBytebeatWeak(int t)
        {
            return (byte)((t * 43532 >> 233) * (t >> 325) | t >> 2543);
        }
    }

    public class Bytebeat7 : WaveProvider32
    {
        private int t = 0;
        private bool switchSound = true;

        public Bytebeat7()
        {
            this.SetWaveFormat(6000, 2); // taxa de amostragem mono
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            for (int i = 0; i < sampleCount; i++)
            {
                byte soundByte = switchSound ? GenerateBytebeatStrong(t) : GenerateBytebeatWeak(t);
                buffer[i + offset] = soundByte / 255f;
                t++;
            }

            switchSound = !switchSound;

            return sampleCount;
        }

        private byte GenerateBytebeatStrong(int t)
        {

            return (byte)(((((t >> 10 & 44) % 32 >> 1) + ((t >> 9 & 44) % 32 >> 1)) * (32768 > t % 65536 ? 1 : 4 / 5) * t | t >> 3) * (t | t >> 8 | t >> 6));
        }

        private byte GenerateBytebeatWeak(int t)
        {
            return (byte)(((((t >> 10 & 44) % 32 >> 1) + ((t >> 9 & 44) % 32 >> 1)) * (32768 > t % 65536 ? 1 : 4 / 5) * t | t >> 3) * (t | t >> 8 | t >> 6));
        }
    }

}