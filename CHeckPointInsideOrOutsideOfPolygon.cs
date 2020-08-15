using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SunlightCalculation
{
    class CHeckPointInsideOrOutsideOfPolygon
    {

        static int INFY = 20000;
        public class Point
        {
            public double x;
            public double y;

            public Point(double X, double Y)
            {
                x = X;
                y = Y;
            }

            // This function checks if 3 points are collinear and point w lies on line segment 'ab' 
            static Boolean PointOnLine(Point a, Point w, Point b)
            {
                double c;

               double  slope;
               
               if ((b.x - a.x) == 0)
                   slope = INFY;

               else
                 slope = (b.y - a.y) / (b.x - a.x);

               c = a.y - (slope * (a.x));

               if (w.y == ((slope * w.x) + c))
                   return true;
               
                  
               
                


                return false;
            }
            // To find if ordered pairs(a, w, b) are clockwise or anti clockwise . 

            public static int CLockWiseAntiClockWiseCheck(Point a, Point w, Point b)
            {
               double  slope1 ;
               double  slope2 ;
                if ((w.x - a.x) == 0)
                   slope1 = INFY;
                else
                 slope1 = (w.y - a.y) / (w.x - a.x);


               if ((b.x - w.x) == 0)
                   slope2 = INFY;
               else
                   slope2 = (b.y - w.y) / (b.x - w.x);
                  
               
                
              
                
  

                if (slope1 == slope2) return 0; // points are colinear 

                return ((slope1/slope2)>1) ? 1 : -1; // clockwise or anticlockwise
                // 1 is Clockwise 
                // -1 is  Anticlockwise 
            }





            //  true if line segment 'a1b1' and 'a2b2' intersect. 
            static Boolean Intersect(Point a1, Point b1, Point a2, Point b2)
            {

                int c1 = CLockWiseAntiClockWiseCheck(a1, b1, a2);
                int c2 = CLockWiseAntiClockWiseCheck(a1, b1, b2);
                int c3 = CLockWiseAntiClockWiseCheck(a2, b2, a1);
                int c4 = CLockWiseAntiClockWiseCheck(a2, b2, b1);


                if (c1 != c2 && c3 != c4)
                    return true;


                if (c1 == 0 && PointOnLine(a1, a2, b1)) return true;


                if (c2 == 0 && PointOnLine(a1, b2, b1)) return true;


                if (c3 == 0 && PointOnLine(a2, a1, b2)) return true;


                if (c4 == 0 && PointOnLine(a2, b1, b2)) return true;

                return false;
            }



            // Returns true if the point p lies inside the polygon[] with n vertices 
            static bool InsidePolygon(Point[] polygon, int n, Point p)
            {
                // for polygon vertices should be greater than 2
                if (n < 3)
                {
                    return false;
                }

                
                Point extreme = new Point(INFY, p.y);

                
                int count = 0, i = 0;
                do
                {
                    int next = (i + 1) % n;

                    if (Intersect(polygon[i],
                                    polygon[next], p, extreme))
                    {
                        
                        if (CLockWiseAntiClockWiseCheck(polygon[i], p, polygon[next]) == 0)
                        {
                            return PointOnLine(polygon[i], p,
                                             polygon[next]);
                        }
                        count++;
                    }
                    i = next;
                } while (i != 0);

               
                return (count % 2 == 1); 
            }


            static void Main(string[] args)
            {
                Point[] polygon1 = {new Point(1, 1), 
                            new Point(20, 1),  
                            new Point(20, 10),  
                            new Point(0, 15)};
                int n = polygon1.Length;
                Point p = new Point(50, 50);
                if (InsidePolygon(polygon1, n, p))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
                 p = new Point(1, 1);
                if (InsidePolygon(polygon1, n, p))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
                

                Console.ReadKey();

            }
        }
    }
}
