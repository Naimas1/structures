using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace structures
{
    struct RGBColor
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }

        public RGBColor(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public string ToHexFormat()
        {
            string hexRed = Red.ToString("X2");
            string hexGreen = Green.ToString("X2");
            string hexBlue = Blue.ToString("X2");
            return $"#{hexRed}{hexGreen}{hexBlue}";
        }

        public void ToHSL(out double hue, out double saturation, out double lightness)
        {
            double r = Red / 255.0;
            double g = Green / 255.0;
            double b = Blue / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));

            double h, s, l;

            l = (max + min) / 2;

            if (max == min)
            {
                h = s = 0; 
            }
            else
            {
                double d = max - min;
                s = l > 0.5 ? d / (2 - max - min) : d / (max + min);

                if (max == r)
                    h = (g - b) / d + (g < b ? 6 : 0);
                else if (max == g)
                    h = (b - r) / d + 2;
                else
                    h = (r - g) / d + 4;

                h /= 6;
            }

            hue = h * 360;
            saturation = s * 100;
            lightness = l * 100;
        }

        public void ToCMYK(out double cyan, out double magenta, out double yellow, out double key)
        {
            double r = Red / 255.0;
            double g = Green / 255.0;
            double b = Blue / 255.0;

            double k = 1 - Math.Max(r, Math.Max(g, b));
            double c = (1 - r - k) / (1 - k);
            double m = (1 - g - k) / (1 - k);
            double y = (1 - b - k) / (1 - k);

            cyan = c * 100;
            magenta = m * 100;
            yellow = y * 100;
            key = k * 100;
        }

        public override string ToString()
        {
            return $"RGB({Red}, {Green}, {Blue})";
        }
    }

    class Programis
    {
        static void Main()
        {
            RGBColor rgbColor = new RGBColor(255, 128, 64);

            Console.WriteLine("RGB Color: " + rgbColor);
            Console.WriteLine("Hex Format: " + rgbColor.ToHexFormat());

            double hue, saturation, lightness;
            rgbColor.ToHSL(out hue, out saturation, out lightness);
            Console.WriteLine($"HSL: H={hue}, S={saturation}%, L={lightness}%");

            double cyan, magenta, yellow, key;
            rgbColor.ToCMYK(out cyan, out magenta, out yellow, out key);
            Console.WriteLine($"CMYK: C={cyan}%, M={magenta}%, Y={yellow}%, K={key}%");
