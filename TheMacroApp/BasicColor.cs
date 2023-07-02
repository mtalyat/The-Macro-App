using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;

namespace TheMacroApp
{
    public struct BasicColor
    {
        private const int A_SHAMT = 24;
        private const int R_SHAMT = 16;
        private const int G_SHAMT = 8;
        private const int B_SHAMT = 0;

        /// <summary>
        /// The ARGB value.
        /// </summary>
        public uint Argb;

        /// <summary>
        /// Alpha.
        /// </summary>
        public int A
        {
            get => GetChannel(A_SHAMT);
            set => SetChannel(A_SHAMT, value);
        }

        /// <summary>
        /// Red.
        /// </summary>
        public int R
        {
            get => GetChannel(R_SHAMT);
            set => SetChannel(R_SHAMT, value);
        }

        /// <summary>
        /// Green.
        /// </summary>
        public int G
        {
            get => GetChannel(G_SHAMT);
            set => SetChannel(G_SHAMT, value);
        }

        /// <summary>
        /// Blue.
        /// </summary>
        public int B
        {
            get => GetChannel(B_SHAMT);
            set => SetChannel(B_SHAMT, value);
        }

        public static implicit operator Color(BasicColor c) => Color.FromArgb(c.A, c.R, c.G, c.B);
        public static implicit operator BasicColor(Color c) => new BasicColor(c.A, c.R, c.G, c.B);

        /// <summary>
        /// Creates an empty color.
        /// </summary>
        public BasicColor()
        {
            Argb = 0;
        }

        /// <summary>
        /// Creates a new color with the given values.
        /// </summary>
        /// <param name="a">Alpha.</param>
        /// <param name="r">Red.</param>
        /// <param name="g">Green.</param>
        /// <param name="b">Blue.</param>
        public BasicColor(int a, int r, int g, int b)
        {
            Argb = 0;
            A = a;
            R = r;
            G = g;
            B = b;
        }

        /// <summary>
        /// Gets the value of a color channel.
        /// </summary>
        /// <param name="shamt">The amount to shift by in the argb value.</param>
        /// <returns>The value in the color channel.</returns>
        private int GetChannel(int shamt)
        {
            return (int)((Argb >> shamt) & 0xff);
        }

        /// <summary>
        /// Sets the value of a color channel.
        /// </summary>
        /// <param name="shamt">The amount to shift by in the argb value.</param>
        /// <param name="value">The new value for the color channel.</param>
        private void SetChannel(int shamt, int value)
        {
            Argb = (Argb & ~(0xffu << shamt)) | ((uint)value << shamt);
        }

        /// <summary>
        /// Gets black or white, based on how light or dark this color is.
        /// </summary>
        /// <param name="color">The color to test.</param>
        /// <returns>Black if the color is light, or white if the color is dark.</returns>
        public BasicColor GetTextColor()
        {
            // 256 * 4 = max, divide that by 2 to get half = 512, if above, light, if below, dark
            if (R + G + B >= 200)
            {
                return new BasicColor(255, 0, 0, 0);
            }
            else
            {
                return new BasicColor(255, 255, 255, 255);
            }
        }

        /// <summary>
        /// Creates a bright and vivid version of this color.
        /// </summary>
        /// <returns>A vivid version of this color.</returns>
        public BasicColor Vivid()
        {
            // get color channels
            int r = R;
            int g = G;
            int b = B;

            // find min and max
            int min = Math.Min(Math.Min(r, g), b);
            int max = Math.Max(Math.Max(r, g), b);

            // expand from min and max to 0 and 255
            r = (int)Math.Floor((r - min) / (float)(max - min) * 0xff);
            g = (int)Math.Floor((g - min) / (float)(max - min) * 0xff);
            b = (int)Math.Floor((b - min) / (float)(max - min) * 0xff);

            // use those colors
            return new BasicColor(A, r, g, b);
        }

        public override string ToString()
        {
            return ((Color)this).ToString();
        }
    }
}
