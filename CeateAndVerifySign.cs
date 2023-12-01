using System;
using System.Linq;
using System.Security.Cryptography;
using EllipticCurveCompoents;

namespace SigningInterface
{
    public static class CreateAndVerifySign
    {
        public static string ConcatTwoString(string r, string s)
        {
            var r_length = r.Length;
            var s_length = s.Length;
            if (r.Length > s.Length)
                s = s.PadLeft(r_length, '0');
            else
                r = r.PadLeft(s_length, '0');
            return String.Concat(r, s);
        }

        public static BigInteger GenerateK(BigInteger q, Random rnd, RandomNumberGenerator RNG)
        {
            BigInteger k;
            do
            {
                var byteSize = rnd.Next(1, 64);//здесь ограничение, потому что bytesize!=0
                byte[] bytes = new byte[byteSize];
                RNG.GetBytes(bytes);
                var bitString = string.Concat(bytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
                k = new BigInteger(bitString, 2);
            } while (k < 0 || k > q);

            return k;
        }
        public static string GenerateSign(BigInteger p, BigInteger d, (IEllipticCurve, IPoint) curve, BigInteger q, byte [] h)
        {
            //byte[] message = Encoding.Default.GetBytes(File.ReadAllText("Book.pdf"));//пока не решила, как лучше читать биты из сообщения
           

            var result = string.Concat(h.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));

            BigInteger binary_alpha = new BigInteger(result, 2);
            BigInteger e = binary_alpha % q;
            if (e == 0)
                e = 1;

            RandomNumberGenerator RNG = RandomNumberGenerator.Create();
            var rnd = new Random();
            BigInteger r = 0;
            BigInteger k;
            BigInteger s;
            do
            {
                k = GenerateK(q, rnd, RNG);
                var C = new CartesianPoint();
                if (curve.Item2 is ProectivPoint)
                {
                    C = ((ProectivPoint)curve.Item1.MultiplyPoint(curve.Item2, k)).GetCartesianPointFromProject(p);
                }
                else if (curve.Item2 is CartesianPoint)
                {
                    C = (CartesianPoint)curve.Item1.MultiplyPoint(curve.Item2, k);
                }
                r = C.x % q;
                s = (r * d + k * e) % q;
            } while (r == 0 || s == 0);

            string r_binary = r.ToString(2);
            string s_binary = s.ToString(2);

            var sign = ConcatTwoString(r_binary, s_binary);
            return sign;
        }

        public static bool VerifySign
            (string sign, BigInteger q, (IEllipticCurve, IPoint) Pcurve, (IEllipticCurve, IPoint) Qcurve, BigInteger p, byte [] h)
        {
            var r_binaryStr = sign.Substring(0, sign.Length / 2);
            var s_binaryStr = sign.Substring(sign.Length / 2);
            var r = new BigInteger(r_binaryStr, 2);
            var s = new BigInteger(s_binaryStr, 2);
            if (r > q || r < 0 || s < 0 || s > q)
                return false;

            var result = string.Concat(h.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));

            BigInteger binary_alpha = new BigInteger(result, 2);
            BigInteger e = binary_alpha % q;
            if (e == 0)
                e = 1;

            var v = Operations.ExtendedEuclid(q, e);
            var z1 = s * v % q;
            var z2 = q + ((-(r * v)) % q);
            BigInteger R = 0;
            var C = new CartesianPoint();

            if (Pcurve.Item2 is ProectivPoint)
            {
                var A = Pcurve.Item1.MultiplyPoint(Pcurve.Item2, z1);
                var B = Qcurve.Item1.MultiplyPoint(Qcurve.Item2, z2);
                C = ((ProectivPoint)Pcurve.Item1.AddPoint(A, B)).GetCartesianPointFromProject(p);
            }
            else if (Pcurve.Item2 is CartesianPoint)
            {
                var A = Pcurve.Item1.MultiplyPoint(Pcurve.Item2, z1);
                var B = Qcurve.Item1.MultiplyPoint(Qcurve.Item2, z2);
                C = (CartesianPoint)Pcurve.Item1.AddPoint(A, B);

            }

            R = C.x % q;
            if (R == r)
                return true;
            else return false;
        }
    }
}
