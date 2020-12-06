using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionGameLibrary
{
    public class Tile
    {
        public int x;
        public int y;
        public int value;

        public Tile(int newx, int newy, int newvalue)
        {
            x = newx;
            y = newy;
            value = newvalue;

            // Console.WriteLine(x.ToString(),y.ToString());
        }
    }
}
