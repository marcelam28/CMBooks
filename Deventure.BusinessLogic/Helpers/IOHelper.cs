using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deventure.BusinessLogic.Helpers
{
    public class IOHelper
    {
        public static string PDF_EXTENSION = ".pdf";
        public static string DOC_EXTENSION = ".doc";
        public static string DOCX_EXTENSION = ".docx";
        public static string JPG_EXTENSION = ".jpg";
        public static string PNG_EXTENSION = ".png";
        public static string HTML_EXTENSION = ".html";
        public static string JPEG_EXTENSION = ".jpeg";

        public static byte[] GetByteArrayFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // Read the source file into a byte array.
                    byte[] contentBytes = new byte[fileStream.Length];
                    int contentLength = (int)fileStream.Length;
                    int numberofBytesToRead = 0;

                    while (contentLength > 0)
                    {
                        //this is the number of bytes that are read from the file which equals to contentLength in this case
                        int numberOfBytesRead = fileStream.Read(contentBytes, numberofBytesToRead, contentLength);

                        //stop if no bytes left to read from file
                        if (numberOfBytesRead == 0)
                        {
                            break;
                        }

                        numberofBytesToRead += numberOfBytesRead;
                        contentLength -= numberOfBytesRead;
                    }

                    return contentBytes;
                }
            }
            return new byte[0];
        }

        public static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.Default.GetBytes(value ?? string.Empty));
        }

        //public static byte[] TransformHtmlToPdfFile(string htmlContent)
        //{
        //    var converter = new HtmlToPdf();
        //    converter.Options.PdfPageSize = PdfPageSize.A4;
        //    converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;

        //    return GetPdfAsByteArrayFromHtmlString(htmlContent, converter);

        //}

        public static bool CheckIfEligibleExtension(string extension)
        {
            if (string.IsNullOrWhiteSpace(extension))
            {
                return false;
            }
            extension = extension.ToLower();

            if (extension == JPG_EXTENSION ||
                extension == PNG_EXTENSION ||
                extension == DOCX_EXTENSION ||
                extension == DOC_EXTENSION ||
                extension == JPEG_EXTENSION ||
                extension == PDF_EXTENSION ||
                extension == HTML_EXTENSION )
            {
                return true;
            }

            return false;
        }

        public string GetExtensionFromMIMEContentType(string contentType)
        {
            switch (contentType)
            {
                case "image/png":
                    return ".png";

                case "image/jpeg":
                    return ".jpeg";

                case "application/pdf":
                    return ".pdf";

                case "application/msword":
                    return ".doc";

                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                    return "docx";
            }

            LoggingService.LogHelper.LogException($"UNKNOWN MIME CONTENT TYPE [{contentType}] FN[GetExtensionFromMIMEContentType]");
            return "";
        }

        public string GetMIMEContentTypeFromExtension(string extension)
        {
            switch (extension)
            {
                case ".png":
                    return "image/png";

                case ".jpeg":
                    return "image/jpeg";

                case ".pdf":
                    return "application/pdf";

                case ".doc":
                    return "application/msword";

                case "docx":
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            }

            LoggingService.LogHelper.LogException($"UNKNOWN EXTENSION [{extension}] FN[GetMIMEContentTypeFromExtension]");
            return "";
        }


        #region private methods

        //private static byte[] GetPdfAsByteArrayFromHtmlString(string htmlString, HtmlToPdf converter = null)
        //{
        //    if (converter == null)
        //    {
        //        converter = new HtmlToPdf();
        //        converter.Options.MaxPageLoadTime = 3600;
        //    }
        //    var document = converter.ConvertHtmlString(htmlString);

        //    var memoryStream = ConvertPdfDocumentToMemoryStream(document);
        //    return memoryStream.ToArray();
        //}

        //private static MemoryStream ConvertPdfDocumentToMemoryStream(PdfDocument document)
        //{
        //    var memoryStream = new MemoryStream();
        //    document.Save(memoryStream);
        //    document.Close();

        //    return memoryStream;
        //}

        #endregion
    }

    public static class DocumentConstants
    {
        public const string XML_FILE_NAME = "Users.xml";
        public const string PDF_FILE_NAME = "Users.pdf";
        public const string CSV_FILE_NAME = "Users.csv";

        public const string CERTIFICATE_NAME = "Certificate.pdf";

        public const string XML_CONTENT_TYPE = "application/xml";
        public const string PDF_CONTENT_TYPE = "application/pdf";
        public const string CSV_CONTENT_TYPE = "application/csv";

        public const string CV_FILE_NAME_WITH_DOTS = "C.V.";
        public const string CV_FILE_NAME = "CV";
    }
}
