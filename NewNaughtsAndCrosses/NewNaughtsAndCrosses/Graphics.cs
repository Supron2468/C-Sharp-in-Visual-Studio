using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace NewNaughtsAndCrosses
{
    public class GFX
    {
        private static Graphics gObject;

        public GFX(Graphics g)
        {
            gObject = g;
            setUpCanvas();
        }

        public static void setUpCanvas()
        {
            Brush bg = new SolidBrush(Color.WhiteSmoke);
            Pen lines = new Pen(Color.Black, 5);
            Pen line = new Pen(Color.Gray, 5);

            gObject.FillRectangle(bg, new Rectangle(0, 0, 500, 600));

            gObject.DrawLine(lines, new Point(167, 0), new Point(167, 500));
            gObject.DrawLine(lines, new Point(334, 0), new Point(334, 500));

            gObject.DrawLine(lines, new Point(0, 167), new Point(500, 167));
            gObject.DrawLine(lines, new Point(0, 334), new Point(500, 334));

            gObject.DrawLine(line, new Point(0, 500), new Point(500, 500));
        }

        public static void drawX(Point loc)
        {
            Pen xPen = new Pen(Color.Peru, 5);
            int xAbs = loc.X * 167;
            int yAbs = loc.Y * 167;

            gObject.DrawLine(xPen, xAbs + 10, yAbs + 10, xAbs + 157, yAbs + 157);
            gObject.DrawLine(xPen, xAbs + 157, yAbs + 10, xAbs + 10, yAbs + 157);
        }

        public static void drawO(Point loc)
        {
            Pen oPen = new Pen(Color.Orchid, 5);
            int xAbs = loc.X * 167;
            int yAbs = loc.Y * 167;

            gObject.DrawEllipse(oPen, xAbs + 10, yAbs + 10, 147, 147);
        }

    }
}
