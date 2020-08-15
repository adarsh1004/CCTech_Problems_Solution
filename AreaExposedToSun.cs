using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SunlightCalculation
{
    class AreaExposedToSun
    {

        public struct Point
        {
            public  double x;
            public double y;
            public Point(double X, double Y)
            {
                x=X;
                y=Y;
            }
        };
        public static double CalculateAreaExposedToSunlight(List<Point> build,Point Sun)
        {   double LengthExposed=0;
            double minIndex;
            int index = 0;
            double height = 0;
            //int noOfBuildings = build.Count/ 4;// no of buildings provided

            if (build.Count == 0)
            {
                return 0;

            }
            else
            {
                while (build.Count > 0)
                {
                    minIndex = build[0].x - Sun.x;
                    for (int i = 0; i < build.Count; i = i + 4)
                    {
                        if ((build[i].x - Sun.x) < minIndex)
                        {
                            minIndex = build[i].x - Sun.x;
                            index = i;
                        }

                    }

                    if (LengthExposed == 0)
                    {
                        LengthExposed = (Math.Abs((build[index + 2].x) - (build[index].x)) + Math.Abs((build[index].y) - (build[index + 1].y)));
                        height = Math.Abs((build[index].y) - (build[index + 1].y));
                        build.Remove(build[index]);
                        build.Remove(build[index]);
                        build.Remove(build[index]);
                        build.Remove(build[index]);
                        index = 0;

                    }
                    else
                    {
                        
                        if(height<=(Math.Abs((build[index].y) - (build[index + 1].y))))
                        {
                            // if next building is higher than all the previous buildings
                          LengthExposed = LengthExposed+(Math.Abs((build[index + 2].x) - (build[index].x)))+(height/3)+(Math.Abs((build[index].y) - (build[index + 1].y))-height);
                          
                          height = Math.Abs((build[index].y) - (build[index + 1].y));

                        }



                        build.Remove(build[index]);
                        build.Remove(build[index]);
                        build.Remove(build[index]);
                        build.Remove(build[index]);
                        index = 0;
                    }

                }
            }


        



           return LengthExposed;
        }

  
        //static void Main(string[] args)
        //{
        //    List<Point> points = new List<Point>();
        //    //$ [[[4,0],[4,-5],[7,-5],[7,0]]] $[[0.4,-2],[0.4,-5],[2.5,-5],[2.5,-2]]]

        //    points.Add(new Point(4, 0));
        //    points.Add(new Point(4, -5));
        //    points.Add(new Point(7, -5));
        //    points.Add(new Point(7, 0));
        //    points.Add(new Point(0.4, -2));
        //    points.Add(new Point(0.4, -5));
        //    points.Add(new Point(2.5, -5));
        //    points.Add(new Point(2.5, -2));
        //    Point Sun = new Point(-3.5, 1);

        //    Console.WriteLine("TotalExposedArea       "+CalculateAreaExposedToSunlight(points,Sun));
        //    Console.ReadKey();
            
        //}
    }
}
