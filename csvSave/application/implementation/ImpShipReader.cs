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


        static int shipIdentifierColumn = 0;
        static int shipTypeColumn = 1;
        static int weightColumn = 17;
        static int dateColumn = 8;

        static string targetDate = "2021-06-20";

        public List<ImpPackageData> ProcessData(string filePath)
        {

            List<ImpPackageData> result = new List<ImpPackageData>();

            using (var reader = new StreamReader(filePath))
            {
                string? rawData;

                string[] data;

                string normalDate;

                bool headerLine = true;

                while (!reader.EndOfStream)
                {
                    rawData = reader.ReadLine();

                    if (rawData != null && !headerLine)
                    {
                        data = rawData.Split(',');

                        normalDate = data[dateColumn].Substring(0, 10);

                        if (normalDate == targetDate)
                        {
                            result.Add(new ImpPackageData(data[shipIdentifierColumn], data[shipTypeColumn], data[weightColumn]));
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
