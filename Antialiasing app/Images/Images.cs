using System;
using System.Collections.Generic;
using System.Drawing;
using CustomAntialiasing.Drawing2DMath;
using Editor2D.Interfaces;

public partial class Images
{
    const int ratio = 15;

    const int MAX_X = 600; //592
    const int MAX_Y = 400; //450

    const string c_path = "G:\\Semester 7\\PG\\Semestralne prace\\Bezier a Lietadlo\\Antialiasing app\\Images\\ufo.png";

    string image_local_path;

    Bitmap img;
    Point position;
    float rotation;

    List<Point> path;
    int i_to;

    float krok_x;
    float krok_y;

    public Images()
    {
        image_local_path = c_path;
        img = new Bitmap(image_local_path);

        rotation = 0;
        this.downscale_img(ratio);

        position = new Point(0,0);

        path = new List<Point>();

        path.Add(new Point(0, 0));
        path.Add(new Point(MAX_X, MAX_Y));

        i_to = 1;

        krok_x = krok_y = 0;
        recallc();
    }

    public Images(List<Point> pts)
    {
        image_local_path = c_path;
        img = new Bitmap(image_local_path);

        rotation = 0;
        this.downscale_img(ratio);

        position = new Point(pts[0].X, pts[0].Y);

        path = pts;

        i_to = 1;

        krok_x = krok_y = 0;
        recallc();
    }

    private void upscale_img(int ratio) {
        Bitmap resized = new Bitmap(img, new Size(img.Width * ratio, img.Height * ratio));
        img = resized;
    }

    private void downscale_img(int ratio)
    {
        Bitmap resized = new Bitmap(img, new Size(img.Width / ratio, img.Height / ratio));
        img = resized;
    }

    public void setXY(Point pt) {
        position.X = pt.X;
        position.Y = pt.Y;

    }

    private void rotate(Point pt) {
        float deg=0;

        this.perform_rotation((-1)*rotation);

        if (pt.X > position.X && pt.Y > position.X) {
            deg += 0;
            if(!(pt.X == position.X))
                deg += (float) Math.Tan((pt.Y - position.Y) / (pt.X - position.X));
        }
        if (pt.X < position.X && pt.Y < position.X)
        {
            deg += 270;
            if (!(pt.Y == position.Y))
                deg += (float) Math.Tan((pt.X - position.X) / (pt.Y - position.Y));
        }
        if (pt.X > position.X && pt.Y < position.X)
        {
            deg += 90;
            if (!(pt.Y == position.Y))
                deg += (float) Math.Tan((pt.X - position.X) / (pt.Y - position.Y));
        }
        if (pt.X < position.X && pt.Y > position.X)
        {
            if (!(pt.X == position.X))
                deg += 180;
            deg += (float) Math.Tan((pt.Y - position.Y) / (pt.X - position.X));
        }

        this.perform_rotation(deg);

        rotation = deg;
    }

    private void perform_rotation(float deg) {
        int maxside = (int)(Math.Sqrt(img.Width * img.Width + img.Height * img.Height));

        //create a new empty bitmap to hold rotated image
        Bitmap returnBitmap = new Bitmap(maxside, maxside);

        //make a graphics object from the empty bitmap
        Graphics g = Graphics.FromImage(returnBitmap);

        //move rotation point to center of image
        g.TranslateTransform((float)img.Width / 2, (float)img.Height / 2);

        //rotate
        g.RotateTransform(deg);

        //move image back
        g.TranslateTransform(-(float)img.Width / 2, -(float)img.Height / 2);

        g.DrawImage(img, new Point(0,0));

        img = returnBitmap;
    }

    private int common_divisor(int x, int y)
    {
        int tmp;
        if (x <= y)
        {
            tmp = x;
        }
        else
        {
            tmp = y;
        }

        do
        {
            if (x % tmp == 0 && y % tmp == 0)
                break;
            tmp--;
        } while (true);


        return tmp;
    }

    public void recallc() {
        Point pt_start = path[i_to - 1];
        Point pt_end = path[i_to];
        //Zadaj

        int dx, dy, pomer_x, pomer_y, tau, tau_n, nasobitel_x, nasobitel_y;
        double d;

        if (pt_start.X >= pt_end.X)
        {
            dx = pt_start.X - pt_end.X;
            nasobitel_x = -1;
        }
        else
        {
            dx = pt_end.X - pt_start.X;
            nasobitel_x = 1;
        }

        if (pt_start.Y >= pt_end.Y)
        {
            dy = pt_start.Y - pt_end.Y;
            nasobitel_y = -1;
        }
        else
        {
            dy = pt_end.Y - pt_start.Y;
            nasobitel_y = 1;
        }

        d = tau = tau_n = 0;
        //d = sqrt(dy * dy + dx + dx);
        //tau = int(round((d / dx) * (180.0 / 3.141592653589793238463)));
        //tau_n = 90 - tau;

        int tmp, s = 1;
        //pomer_x = tau;
        //pomer_y = tau_n;
        pomer_x = dx;
        pomer_y = dy;
        if (pomer_x != 0 && pomer_y != 0)
        {
            do
            {
                tmp = common_divisor(pomer_x, pomer_y);
                if (tmp >= 1)
                {
                    s = tmp;
                    pomer_x /= s;
                    pomer_y /= s;
                }
                else
                {
                    break;
                }
            } while (tmp != 1);
        }

        krok_x = pomer_x * nasobitel_x;
        krok_y = pomer_y * nasobitel_y;
    }

    public bool tick() {
        Point new_position = position;

        new_position.X = (int)(new_position.X + krok_x);
        new_position.Y = (int)(new_position.Y + krok_y);

        setXY(new_position);

        if (new_position.ToString() == path[i_to].ToString()) {
            if ((i_to + 1) == path.Count)
            {
                return true;
            }
            else {
                i_to++;
                this.recallc();
                return false;
            }
        }

        return false;
    }

    public bool Draw(Graphics g)
    {
        bool end = tick();
        g.DrawImage(img, position);
        return end;
    }
}