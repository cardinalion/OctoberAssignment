using System;
using System.Collections.Generic;

namespace AssignmentTwo
{
    class Color
    {
        public byte red { get; set; }
        public byte green { get; set; }
        public byte blue { get; set; }
        public byte alpha { get; set; }

        public Color(byte r, byte g, byte b, byte a)
        {
            red = r;
            green = g;
            blue = b;
            alpha = a;
        }

        public Color(byte r, byte g, byte b)
        {
            red = r;
            green = g;
            blue = b;
            alpha = 255;
        }

        public byte GetGreyscale()
        {
            return (byte)(((uint)red + green + blue) / 3);
        }

    }

    class Ball
    {
        private int size;
        public Color color { get; }
        public int thrownTimes { get; private set; }

        public Ball(int s, byte r, byte g, byte b, byte a)
        {
            size = s;
            color = new Color(r, g, b, a);
            thrownTimes = 0;
        }

        public Ball(int s, byte r, byte g, byte b)
        {
            size = s;
            color = new Color(r, g, b);
            thrownTimes = 0;
        }

        public void Pop()
        {
            size = 0;
        }

        public void Throw()
        {
            if (size > 0) ++thrownTimes;
        }
    }

}
