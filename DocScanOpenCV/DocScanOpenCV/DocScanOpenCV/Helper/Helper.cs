using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocScanOpenCV.Helper
{
    public static class Helper
    {
        public static List<Point2f> Sort(this List<Point2f> input)
        {
            List<Point2f> returnVal = new List<Point2f>();
            //sort into this order (bl, tl, tr, br)
            if (input.Count == 4)
            {
                //left, sort point by lowest X
                var left2 = input.OrderBy(p => p.X).Take(2);

                //Right, sort by highest X
                var right2 = input.OrderByDescending(p => p.X).Take(2);

                //bl
                returnVal.Add(left2.OrderBy(p => p.Y).First());
                //tl
                returnVal.Add(left2.OrderByDescending(p => p.Y).First());
                //tr
                returnVal.Add(right2.OrderByDescending(p => p.Y).First());
                //br
                returnVal.Add(right2.OrderBy(p => p.Y).First());
            }

            return returnVal;
        }
    }
}
