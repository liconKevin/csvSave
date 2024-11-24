
using csvSave;
using System.Configuration;

string? csvPath = ConfigurationManager.AppSettings["pathFile"];

if (File.Exists(csvPath))
{
    initState(csvPath);
}
else
{

    Console.WriteLine("Error: File not found or not provide in the App config.");

    System.Environment.Exit(-1);

}



void initState(string filePath)
{

    IdataProcess<string> process = new ImpCsvReader();

    dataManagement<string> dataManagement = new dataManagement<string>(process, filePath);

    dataManagement.processData();

    dataManagement.saveData();

}
