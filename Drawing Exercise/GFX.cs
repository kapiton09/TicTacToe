using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_Exercise
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
            Pen lines = new Pen(Color.Gray, 5);

            gObject.FillRectangle(bg, new Rectangle(0, 0, 300, 300));
            gObject.DrawLine(lines, new Point(100,0), new Point(100, 300));
            gObject.DrawLine(lines, new Point(200, 0), new Point(200, 300));

            gObject.DrawLine(lines, new Point(0, 100), new Point(300, 100));
            gObject.DrawLine(lines, new Point(0, 200), new Point(300, 200));

            gObject.DrawLine(lines, new Point(0, 300), new Point(300, 300));
            gObject.DrawLine(lines, new Point(0, 0), new Point(0, 300));
            gObject.DrawLine(lines, new Point(0, 0), new Point(300, 0));
            gObject.DrawLine(lines, new Point(300, 0), new Point(300, 300));
        }

        public static void drawX(Point loc)
        {
            Pen xPen = new Pen(Color.Peru, 5);
            int xAbs = loc.X * 100;
            int yAbs = loc.Y * 100;

            gObject.DrawLine(xPen, xAbs + 10, yAbs +10, xAbs + 80, yAbs + 80);
            gObject.DrawLine(xPen, xAbs + 80, yAbs + 10, xAbs + 10, yAbs + 80);
        }

        public static void drawO(Point loc)
        {
            Pen oPen = new Pen(Color.Orchid, 5);
            int xAbs = loc.X * 100;
            int yAbs = loc.Y * 100;

            gObject.DrawEllipse(oPen, xAbs + 10, yAbs + 10, 80, 80);
        }
    }
}
