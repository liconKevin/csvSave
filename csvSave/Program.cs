
using csvSave;
using System.Configuration;

string? csvPath = ConfigurationManager.AppSettings["pathFile"];


IdataProcess<string> process = new ImpCsvReader();


if (File.Exists(csvPath))
{
    dataManagement<string> dataManagement = new dataManagement<string>(process, csvPath);

    dataManagement.processData();

    dataManagement.saveData();

}
else
{

    Console.WriteLine("Error: File not found or not provide in the App config.");

    System.Environment.Exit(-1);

}
