using System;
using System.Collections.Generic;
using System.IO;
using EllipticCurveCompoents;

namespace SigningInterface
{
    public static class InitializeCurves
    {
        //curves
        public static WeierstrassCurveCartesianCoordinate weierstrassCartesianCurve;
        public static EdwardsCurveCartesianCoordinate edwardsCartesianCurve;
        public static WeierstrassCurveProectiveCoordinate weierstrassProjectiveCurve;
        public static EdwardsCurveProectiveCoordinate edwardsProjectiveCurve;
        //P-points
        public static CartesianPoint edwardsCartesianPoint;
        public static CartesianPoint weierstrassCartesianPoint;
        public static ProectivPoint edwardsProjectivePoint;
        public static ProectivPoint weierstrassProjectivePoint;
        //Q-points
        public static CartesianPoint QWeirCartesianPoint;
        public static CartesianPoint QEdwCartesianPoint;
        public static ProectivPoint QWeirProjectivePoint;
        public static ProectivPoint QEdwProjectivePoint;
        
        public static BigInteger p, a, b, d, m, x, y, u, v, q;

        public static void getCurvesAndPoints()
        {
            
            //чтение данных из файла
            using (var sr = new StreamReader("data/parameters.txt"))
            {
                string[] parameters = new string[10];
                for (int i = 0; i < 10; i++)
                {
                    var str = sr.ReadLine().Substring(4);
                    parameters[i] = str;
                }
                p = new BigInteger(parameters[0], 16);
                a = new BigInteger(parameters[1], 16);
                b = new BigInteger(parameters[2], 16);
                m = new BigInteger(parameters[3], 16);
                q = new BigInteger(parameters[4], 16);
                u = new BigInteger(parameters[5], 16);
                v = new BigInteger(parameters[6], 16);
                d = new BigInteger(parameters[7], 10);
                x = new BigInteger(parameters[8], 16);
                y = new BigInteger(parameters[9], 16);
                d = d % p;
            }

            weierstrassCartesianCurve = new WeierstrassCurveCartesianCoordinate(p, a, b);
            edwardsCartesianCurve = new EdwardsCurveCartesianCoordinate
                (p, new BigInteger("1", 10), new BigInteger("0605F6B7C183FA81578BC39CFAD518132B9DF62897009AF7E522C32D6DC7BFFB", 16));
            weierstrassProjectiveCurve = new WeierstrassCurveProectiveCoordinate(p, a, b);
            edwardsProjectiveCurve = new EdwardsCurveProectiveCoordinate
                (p, new BigInteger("1", 10), new BigInteger("0605F6B7C183FA81578BC39CFAD518132B9DF62897009AF7E522C32D6DC7BFFB", 16));
           
            edwardsCartesianPoint = new CartesianPoint(u, v);
            weierstrassCartesianPoint = new CartesianPoint(x, y);
            edwardsProjectivePoint = new ProectivPoint(u, v, 1);
            weierstrassProjectivePoint = new ProectivPoint(x, y, 1);

            QWeirCartesianPoint = (CartesianPoint)weierstrassCartesianCurve.MultiplyPoint(weierstrassCartesianPoint, d);
            QEdwCartesianPoint = (CartesianPoint)edwardsCartesianCurve.MultiplyPoint(edwardsCartesianPoint, d);
            QWeirProjectivePoint = weierstrassProjectiveCurve.MultiplyPoint(weierstrassProjectivePoint, d);
            QEdwProjectivePoint = (ProectivPoint)edwardsProjectiveCurve.MultiplyPoint(edwardsProjectivePoint, d);
        }
    }
}
