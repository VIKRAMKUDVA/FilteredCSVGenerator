namespace FilteredCSVGenerator
{
    public class CSVReader
    {
        public void ReadExcel(string filePath)
        {
            string path = filePath + "DataExtractor_Example_Input.csv";
            try
            {
                DataTable dt = new DataTable();
                using (StreamReader sr = new StreamReader(path))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dt.Rows.Add(dr);
                    }
                }
                ModifyDataTable data = new ModifyDataTable();
                CSVWriter write = new CSVWriter();
                write.WriteExcel(data.modifyData(dt),filePath);

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendErrorToText(ex, filePath);
            }
        }
    }
}
