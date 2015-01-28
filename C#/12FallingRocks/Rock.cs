using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest
{
    public class Rock
    {
        private char image;
        private int x, y;
        private char[] images = new char[] { '!', '@', '#', '$', '%', '^', '&', 'G', '~', '*', '+' };

        public Rock()
        {
            this.setRandomImage();

            this.x = 0;
            this.y = 0;
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public char getImage()
        {
            return this.image;
        }

        public void setRandomImage()
        {
            Random randmGenerator = new Random();
            this.image = images[randmGenerator.Next(0, images.Length - 1)];
        }
    }
}
