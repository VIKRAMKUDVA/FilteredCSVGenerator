using System;
using System.IO;
public static class ExceptionLogging
{

    private static string
        errorName = string.Empty,
        extype = string.Empty,
        Errormsg = string.Empty,
        ErrorLocation = string.Empty;

    public static void SendErrorToText(Exception ex, string filepath)
    {
        var line = Environment.NewLine + Environment.NewLine;
        errorName = ex.GetType().Name.ToString();
        extype = ex.GetType().ToString();
        Errormsg = ex.Message.ToString();
        ErrorLocation = ex.Source.ToString();

        try
        {
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            string path = filepath + "LoggerFile.txt";
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                string error = "Log Written Date:" + " " + DateTime.Now.ToString() + line + "Error:" + " " + errorName + line + "Exception Type:" + " " + extype + line + "Error Message :" + " " + Errormsg + line + "Error Source :" + ErrorLocation + line;
                sw.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");
                sw.WriteLine("-------------------------------------------------------------------------------------");
                sw.WriteLine(line);
                sw.WriteLine(error);
                sw.WriteLine("--------------------------------*End*------------------------------------------");
                sw.WriteLine(line);
                sw.Flush();
                sw.Close();

            }

        }
        catch (Exception e)
        {
            e.ToString();

        }
    }

}