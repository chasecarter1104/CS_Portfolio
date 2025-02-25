using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;



namespace Assignment3
{
    /// <summary>
    /// Class for writing data to a file using background thread execution and status callbacks.
    /// Ensures the file does not exist.
    /// </summary>
    public class FileWriter
    {
        public void WriteToFile(string filePath, string data, Action<string> callback)
        {
            try
            {
                if(File.Exists(filePath))
                {
                    throw new IOException("File already exists.");
                }
                try
                {
                    // 2 second delay
                    Thread.Sleep(2000);

                    //Write to file
                    File.WriteAllText(filePath, data);

                    // complete message
                    callback?.Invoke("Finished writing to file");
                }
                catch (Exception ex)
                {
                    // Fail message
                    callback?.Invoke($"Error: {ex.Message}");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
    }
}
