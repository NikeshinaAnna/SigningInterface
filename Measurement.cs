using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using EllipticCurveCompoents;

namespace SigningInterface
{
    public static class Measurement
    {
        public static void generateSign(List<(IEllipticCurve, IPoint)> curvesAndPoints)
        {
            var directories = getDirectories();
            string path = "../results/results_sign_" + DateTime.Today.Day.ToString() + ".txt";
            using (var sw = new StreamWriter(path))
            {
                string filepath = "../fillDataGrid/tableData.txt";
                File.WriteAllText(filepath, string.Empty);
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (var table_sw = new StreamWriter(filepath, true, Encoding.GetEncoding(1251)))
                {
                    table_sw.Write("Имя файла, ");
                    for (int i = 0; i < curvesAndPoints.Count; i++)
                    {
                        table_sw.Write(curvesAndPoints[i].Item1.getCurveName());
                        if (i + 1 != curvesAndPoints.Count)
                        {
                            table_sw.Write(", ");
                        }
                        else
                        {
                            table_sw.WriteLine();
                        }
                    }
                    foreach (var dir in directories)
                    {
                        var files = dir.GetFiles("*", SearchOption.AllDirectories);
                        SignExperimentWithFiles(InitializeCurves.p, InitializeCurves.d, InitializeCurves.q, curvesAndPoints, files, sw, table_sw);
                    }
                }
            }
        }

        public static void verifySign(List<(IEllipticCurve, IPoint)> curvesAndPoints, List<(IEllipticCurve, IPoint)> QCurvesPoints)
        {
            var directories = getDirectories();
            string path= "../results/verify_sign_" + DateTime.Today.Day.ToString() + ".txt";
            using (var sw = new StreamWriter(path))
            {
                string filepath = "../fillDataGrid/tableData.txt";
                File.WriteAllText(filepath, string.Empty);
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (var table_sw = new StreamWriter(filepath, true, Encoding.GetEncoding(1251)))
                {
                    table_sw.Write("Имя файла, ");
                    for (int i = 0; i < curvesAndPoints.Count; i++)
                    {
                        table_sw.Write(curvesAndPoints[i].Item1.getCurveName());
                        if (i + 1 != curvesAndPoints.Count)
                        {
                            table_sw.Write(", ");
                        }
                        else
                        {
                            table_sw.WriteLine();
                        }
                    }
                    foreach (var dir in directories)
                    {
                        var files = dir.GetFiles("*", SearchOption.AllDirectories);
                        VerifyExperimentWithFiles(InitializeCurves.p, InitializeCurves.q, curvesAndPoints, QCurvesPoints, files, sw, table_sw);
                    }
                }
            }
        }

        private static DirectoryInfo[] getDirectories()
        {
            var configReader = new AppSettingsReader();
            string pathToFiles = configReader.GetValue("path", typeof(string)).ToString();

            var root_directory = new DirectoryInfo(pathToFiles);
            return root_directory.GetDirectories();
        }

        private static void SignExperimentWithFiles(BigInteger p, BigInteger d,
            BigInteger q, List<(IEllipticCurve, IPoint)> curves, FileInfo[] files, StreamWriter sw, StreamWriter table_sw)
        {
            string filename;
            foreach (var file in files)
            {
                filename = file.DirectoryName + "\\" + file.Name;
                sw.WriteLine("----------------------------------------------");
                sw.WriteLine("---Файл: " + filename);
                sw.WriteLine("----------------------------------------------");
                var stopWatch = new Stopwatch();
                byte[] message = File.ReadAllBytes(filename);
                Streebog streebog = new Streebog(256);
                var hash = streebog.GetHash(message);

                List<TimeSpan> time = new List<TimeSpan>();
                foreach (var curve in curves)
                {
                    string fileWithGeneratedSign = String.Empty;
                    stopWatch.Reset();
                    string sign;
                    if (curve.Item1 is WeierstrassCurveCartesianCoordinate)
                    {
                        fileWithGeneratedSign = "Weir_cartes" + Path.GetFileNameWithoutExtension(filename) + ".txt";
                    }
                    else if (curve.Item1 is WeierstrassCurveProectiveCoordinate)
                    {
                        fileWithGeneratedSign = "Weir_projective" + Path.GetFileNameWithoutExtension(filename) + ".txt";
                    }
                    else if (curve.Item1 is EdwardsCurveCartesianCoordinate)
                    {
                        fileWithGeneratedSign = "Edw_cartes" + Path.GetFileNameWithoutExtension(filename) + ".txt";
                    }
                    else if (curve.Item1 is EdwardsCurveProectiveCoordinate)
                    {
                        fileWithGeneratedSign = "Edw_projective" + Path.GetFileNameWithoutExtension(filename) + ".txt";
                    }
                    stopWatch.Start();
                    sign = CreateAndVerifySign.GenerateSign(p, d, curve, q, hash);
                    stopWatch.Stop();
                    string path = "../signs/" + fileWithGeneratedSign;
                    using (var sw_sign = new StreamWriter(path))
                        sw_sign.Write(sign);
                    sw.WriteLine(curve.Item1.getCurveName() + ": " + stopWatch.Elapsed);
                    time.Add(stopWatch.Elapsed);
                }
                table_sw.Write('\u0022' + file.Name + '\u0022' + ", ");
                for (int i = 0; i < time.Count; i++)
                {
                    table_sw.Write(time[i]);
                    if (i + 1 != time.Count)
                    {
                        table_sw.Write(", ");
                    }
                    else
                    {
                        table_sw.WriteLine();
                    }
                }
            }
        }

        private static void VerifyExperimentWithFiles
            (BigInteger p, BigInteger q, List<(IEllipticCurve, IPoint)> Pcurves, List<(IEllipticCurve, IPoint)> Qcurves, FileInfo[] files,
            StreamWriter sw, StreamWriter table_sw)
        {
            string filename;
                
            foreach (var file in files)
            {
                filename = file.DirectoryName + "\\" + file.Name;
                sw.WriteLine("----------------------------------------------");
                sw.WriteLine("---Файл: " + filename);
                sw.WriteLine("----------------------------------------------");
                var stopWatch = new Stopwatch();
                byte[] message = File.ReadAllBytes(filename);
                Streebog streebog = new Streebog(256);
                var hash = streebog.GetHash(message);

                List<TimeSpan> time = new List<TimeSpan>();
                for (int i = 0; i < Pcurves.Count; i++)
                {
                    string fileWithGeneratedSign = String.Empty;
                    stopWatch.Reset();
                    if (Pcurves[i].Item1 is WeierstrassCurveCartesianCoordinate)
                    {
                        fileWithGeneratedSign = "Weir_cartes" + Path.GetFileNameWithoutExtension(filename) + ".txt";
                    }
                    else if (Pcurves[i].Item1 is WeierstrassCurveProectiveCoordinate)
                    {
                        fileWithGeneratedSign = "Weir_projective" + Path.GetFileNameWithoutExtension(filename) + ".txt";
                    }
                    else if (Pcurves[i].Item1 is EdwardsCurveCartesianCoordinate)
                    {
                        fileWithGeneratedSign = "Edw_cartes" + Path.GetFileNameWithoutExtension(filename) + ".txt";
                    }
                    else if (Pcurves[i].Item1 is EdwardsCurveProectiveCoordinate)
                    {
                        fileWithGeneratedSign = "Edw_projective" + Path.GetFileNameWithoutExtension(filename) + ".txt";
                    }

                    string path = "../signs/" + fileWithGeneratedSign;
                    var str_sign_onWeirshtras = File.ReadAllText(path);
                    stopWatch.Start();
                    Console.WriteLine(CreateAndVerifySign.VerifySign(str_sign_onWeirshtras, q, Pcurves[i], Qcurves[i], p, hash));
                    stopWatch.Stop();
                    sw.WriteLine(Pcurves[i].Item1.getCurveName() + ": " + stopWatch.Elapsed);
                    time.Add(stopWatch.Elapsed);
                }

                table_sw.Write('\u0022' + file.Name + '\u0022' + ", ");
                for (int i = 0; i < time.Count; i++)
                {
                    table_sw.Write(time[i]);
                    if (i + 1 != time.Count)
                    {
                        table_sw.Write(", ");
                    }
                    else
                    {
                        table_sw.WriteLine();
                    }
                }
            }
        }
    }
}
