using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using csvSave.domain.interfaces;

namespace csvSave.application.implementation
{
    public class ImpShipReader : IdataProcess<ImpPackageData>
    {
        static int shipIdentifier = 0;
        static int shipType = 1;
        static int weight = 17;

        public List<ImpPackageData> ProcessData(string filePath)
        {

            List<ImpPackageData> result = new List<ImpPackageData>();

            using (var reader = new StreamReader(filePath))
            {
                string? rawData;

                string[] data;

                bool headerLine = true;

                while (!reader.EndOfStream)
                {
                    rawData = reader.ReadLine();

                    if (rawData != null && !headerLine)
                    {
                        data = rawData.Split(',');

                        if (data[8].Substring(0, 10) == "2021-06-20")
                        {
                            result.Add(new ImpPackageData(data[shipIdentifier], data[shipType], data[weight]));
                        }
                    }

                    headerLine = false;

                }
            }

            return result;

        }

        public void saveData(List<ImpPackageData> data)
        {

            foreach (var line in data.GroupBy(identify => identify.getType()).Select(group => new {
                Metric = group.Key,
                Count = group.Count()
            }).OrderBy(x => x.Metric))
            {
                Console.WriteLine(" {0} {1}", line.Metric, line.Count);
            }

        }
    }
}
