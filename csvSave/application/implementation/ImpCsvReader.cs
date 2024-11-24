using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csvSave.domain.interfaces;

namespace csvSave.application.implementation
{
    public class ImpCsvReader : IdataProcess<ImpPackageData>
    {
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
                            result.Add(new ImpPackageData(data[0], data[1], data[17]));
                        }
                    }

                    headerLine = false;

                }
            }

            return result;

        }

        public void saveData(List<ImpPackageData> data)
        {
            foreach (ImpPackageData item in data)
            {

                Console.WriteLine(String.Format("Identifier: {0} Type: {1} Weight: {2}", item.getIdentifier(), item.getType(), item.getWeight()));

            }
        }
    }
}
