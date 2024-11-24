using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvSave
{
    public class ImpCsvReader : IdataProcess<string>
    {
        public List<string> ProcessData(string filePath)
        {
            List<string> result = new List<string>();

            using (var reader = new StreamReader(filePath))
            {
                string? rawData;

                string[] data;

                bool headerLine = true;

                while (!reader.EndOfStream)
                {
                    rawData = reader.ReadLine();

                    if(rawData != null && !headerLine)
                    {
                        data = rawData.Split(',');

                        if (data[8].Substring(0, 10) == "2021-06-20")
                        {
                            result.Add(data[8].Substring(0, 10));
                        }
                    }

                    headerLine = false;

                }
            }

            return result;

        }

        public void saveData(List<string> data)
        {
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
    }
}
