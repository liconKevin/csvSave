using csvSave.application;
using csvSave.application.implementation;
using csvSave.domain.interfaces;
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

    IdataProcess<ImpPackageData> process = new ImpCsvReader();

    dataManagement<ImpPackageData> dataManagement = new dataManagement<ImpPackageData>(process, filePath);

    dataManagement.processData();

    dataManagement.saveData();

}
