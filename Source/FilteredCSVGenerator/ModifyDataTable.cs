using System.Text.RegularExpressions;

namespace FilteredCSVGenerator
{
    public class ModifyDataTable
    {
        public DataTable modifyData(DataTable data)
        {
            DataTable result = new DataTable();
            try
            {
                if (data.Rows.Count >= 0 && data.Columns.Contains("ISIN") && data.Columns.Contains("CFICode") && data.Columns.Contains("Venue") && data.Columns.Contains("AlgoParams"))
                {
                    if (data.Rows.Count > 0)
                    {
                        DataView view = new DataView(data);
                        result = view.ToTable("result", false, "ISIN", "CFICode", "Venue", "AlgoParams");
                        result.Columns[3].ColumnName = "Contract Size";
                        List<string> ContractSize = result.AsEnumerable().Select(r => r.Field<string>("Contract Size")).ToList();
                        for (int i = 0; i < result.Rows.Count; i++)
                        {
                            if (!String.IsNullOrEmpty(ContractSize[i]))
                            {
                                string PriceMultiplier = Regex.Match(ContractSize[i].Split("|")[4], @"\d+").Value;
                                result.Rows[i][3] = String.IsNullOrEmpty(PriceMultiplier) ? "No Data" : PriceMultiplier;
                            }
                            else {
                                Exception ex = new Exception("AlgoParams Column "+ i +" is Null or Empty");
                                throw ex;
                            }
                        }
                    }
                    else
                    {
                        Exception ex = new Exception("No Data Found in CSV File");
                        throw ex;
                    }
                }
                else
                {
                    Exception ex = new Exception("Input Table Structure doesnt match as Expected or Some Required Columns in Input CSV are missing!!");
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }
}
