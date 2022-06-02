using System.Text;

namespace FilteredCSVGenerator
{
    public class CSVWriter
    {
        public void WriteExcel(DataTable data, string filePath)
        {
            try {
                StringBuilder sb = new StringBuilder();

                IEnumerable<string> columnNames = data.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName);
                sb.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in data.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(string.Join(",", fields));
                }
                File.WriteAllText(filePath+"DataExtractor_Example_Output.csv", sb.ToString());
            }
            catch (Exception ex) 
            {
                throw;
            }
            
        }
    }
}
