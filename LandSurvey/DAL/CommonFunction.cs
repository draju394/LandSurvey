using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Collections.Specialized;
using System.Data;
using System.Web.UI;

namespace LandSurvey.DAL
{
    public class CommonFunction
    {

        public void MergePDFs(string outPutFilePath, params string[] filesPath)
        {
            List<PdfReader> readerList = new List<PdfReader>();
            foreach (string filePath in filesPath)
            {
                PdfReader pdfReader = new PdfReader(filePath);
                readerList.Add(pdfReader);
            }

            //Define a new output document and its size, type
            Document document = new Document(PageSize.A4, 0, 0, 0, 0);
            //Create blank output pdf file and get the stream to write on it.
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outPutFilePath, FileMode.Create));
            document.Open();

            foreach (PdfReader reader in readerList)
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    PdfImportedPage page = writer.GetImportedPage(reader, i);
                    document.Add(iTextSharp.text.Image.GetInstance(page));
                }
            }
            document.Close();
        }

        public void sendsms(string MobileNo, string Message)
        {

            //String message = HttpUtility.UrlEncode("This is your message From SEZ Thane");
            String message = HttpUtility.UrlEncode(Message);
            using (var wb = new System.Net.WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "MK7fugiPrhQ-7bOiwEjRcBqziqL2eH9r6QITPtS2K6"},
                {"numbers" , MobileNo},
                {"message" , message},
                {"sender" , "SEZTHA"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                //return result;
            }
        }

        public string GenratedOTP()
        {
            string genOTP = "";

            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;
            //if (rbType.SelectedItem.Value == "1")
            //{
            //    characters += alphabets + small_alphabets + numbers;
            //}
            //int length = int.Parse(ddlLength.SelectedItem.Value);
            int length = 6;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            genOTP = otp;

            return genOTP;
        }

        
        //
    }
}