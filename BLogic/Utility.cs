using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Università.DataModels;

namespace Università.BLogic
{
    internal class Utility
    {
        /// <summary>
        /// It gets the application parameters from app settings
        /// </summary>
        internal void GetSetApplicationParams()
        {            

            string? filePath = ConfigurationManager.AppSettings["FilePath"];
            string? studentiFileName = ConfigurationManager.AppSettings["StudentiFileName"];
            string? docentiFileName = ConfigurationManager.AppSettings["DocentiFileName"];


            if (filePath != null && studentiFileName != null && docentiFileName != null)
            {                
                ConfigParams.AppFilePath = filePath;
                ConfigParams.StudentiFileName = Path.Combine(filePath, studentiFileName);
                ConfigParams.DocentiFileName = Path.Combine(filePath, docentiFileName);
            }
            else
            {
                Console.WriteLine("FilePath, DocentiFileName o StudentiFileName sono nulli in app settings.");
            }
            
        }
    }
}
