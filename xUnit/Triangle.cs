using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    public class Triangle
    {
        public static bool DoesTheTriangleExist(float side_a, float side_b, float side_c)
        {
            if (side_a + side_b <= side_c)
                return false;
            if (side_b + side_c <= side_a)
                return false;
            if (side_c + side_a <= side_b)
                return false;
            if (side_a <= 0)
                return false;
            if (side_b <= 0)
                return false;
            if (side_c <= 0)
                return false;

            return true;
        }
    }
}
