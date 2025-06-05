using ClassLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.DataAccess
{
    public static class FileReader
    {
        private static List<Werknemer> _werknemers;

        static FileReader()
        {
            _werknemers = new List<Werknemer>();
        }

        public static List<Werknemer> ReadFile(string path)
        {
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                string line;
                using (StreamReader sr = new StreamReader(fi.Name))
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if (line.Substring(35, 1) == "K")
                        {
                            Kader kaderMedewerker = new Kader(
                                line.Substring(0, 15).Trim(),
                                line.Substring(15, 20).Trim(),
                                char.Parse(line.Substring(35, 1).Trim()),
                                Convert.ToDecimal(line.Substring(37, 9).Replace(',', '.')));
                            _werknemers.Add(kaderMedewerker);
                        }
                        else if (line.Substring(35, 1) == "B")
                        {
                            Bediende bediende = new Bediende(
                                line.Substring(0, 15).Trim(),
                                line.Substring(15, 20).Trim(),
                                char.Parse(line.Substring(35, 1).Trim()),
                                Convert.ToDecimal(line.Substring(47, 6).Replace(',', '.')),
                                Convert.ToDecimal(line.Substring(53, 7).Replace(',', '.'))
                                );
                            _werknemers.Add(bediende);
                        }
                        else if (line.Substring(35, 1) == "C")
                        {
                            Commissie commissieMedewerker = new Commissie(
                                line.Substring(0, 15).Trim(),
                                line.Substring(15, 20).Trim(),
                                char.Parse(line.Substring(35, 1).Trim()),
                                Convert.ToDecimal(line.Substring(37, 9).Replace(',', '.')),
                                Convert.ToDecimal(line.Substring(62, 5).Replace(',', '.')),
                                Convert.ToDecimal(line.Substring(68, 9).Replace(',', '.'))
                                );
                            _werknemers.Add(commissieMedewerker);
                        }
                    }
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
            return _werknemers;
        }
    }
}
