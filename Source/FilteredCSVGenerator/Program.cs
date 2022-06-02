global using System.Data;
using FilteredCSVGenerator;

string filePath = @"C:\Users\Vikram\Desktop\"; //Add filepath here
CSVReader read = new CSVReader();
read.ReadExcel(filePath);