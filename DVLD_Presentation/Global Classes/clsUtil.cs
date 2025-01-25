using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_FullRealProject.Classes
{
    public class clsUtil
    {


        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            
            if(!Directory.Exists(FolderPath))
            {

                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    clsLogger.Log(ex);
                    return false; 
                }

            }

            return true;
        }

        public static string GenerateGUID()
        {
            Guid newGuid = Guid.NewGuid();
            return newGuid.ToString();
        }

        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            FileInfo fileInfo = new FileInfo(sourceFile);
            string extn = fileInfo.Extension;
            return GenerateGUID() + extn;
        }


        public static bool CopyImageToProjectImagesFolder(ref string sourceFile) 
        {
            string DestinationFolder = @"C:\DVLD-People-Images\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }


            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);

            try
            {
                File.Copy(sourceFile, destinationFile, true);

            }
            catch (IOException ex) 
            {
                clsLogger.Log(ex);
                return false;
            }

            sourceFile = destinationFile;

            return true;
        }






    }
}
