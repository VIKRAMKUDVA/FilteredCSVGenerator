using Microsoft.Office.Interop.Excel;

namespace FilteredCSVGenerator.xUnitTest
{
    public class UnitTest1
    {
        string filepath = @"C:\Users\Vikram\source\repos\FilteredCSVGenerator\Source\FilteredCSVGenerator.xUnitTest\Test Samples\";
        [Fact]
        public void FileNotFound()
        {
            //If the Input CSV file is not at the path specified
            CSVReader read = new CSVReader();
            read.ReadExcel(filepath + @"FileNotFoundTestCase\");
            //Check LoggerFile.txt at the above filepath for caught exception message for File Not Found.
        }
        [Fact]
        public void CSVInUse()
        {
            //If the Input/Output CSV file is Open or being used by other operations
            CSVReader read = new CSVReader();
            Application excel = new Application();
            Workbook wb = excel.Workbooks.Open(filepath + @"CSVInUseTestCase\DataExtractor_Example_Input.csv");
            read.ReadExcel(filepath + @"CSVInUseTestCase\");
            wb.Close(false);
            //Check LoggerFile.txt at the above filepath for caught exception message for File is being used by another process.
        }
        [Fact]
        public void CSVEmpty()
        {
            //If the Input CSV file is Empty with only Columns Names
            CSVReader read = new CSVReader();
            read.ReadExcel(filepath + @"CSVEmptyTestCase\");
            //Check LoggerFile.txt at the above filepath for caught exception message for Input CSV file to be emmpty
        }
        [Fact]
        public void CSVStructure()
        {
            //If the Input CSV file Completely Empty without Column Names
            //If the Input CSV doesnt contain required Columns for Operation
            //In this Test Case we have removed ISIN Column to Test if the Input CSV Structure is not as expected then it should log the error
            CSVReader read = new CSVReader();
            read.ReadExcel(filepath + @"CSVStructureTestCase\");
            //Check LoggerFile.txt at the above filepath for caught exception message for Input CSV not following the required Structure
        }
        [Fact]
        public void ComplexColumnEmpty()
        {
            //If the Input CSV files AlgoParams cell value is null or Empty
            CSVReader read = new CSVReader();
            read.ReadExcel(filepath + @"ComplexColumnEmptyTestCase\");
            //Check LoggerFile.txt at the above filepath for caught exception message for AlgoParam Column cell is null or empty
        }
    }
}