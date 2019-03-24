using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using LoggingService;
using RazorEngine;
using RazorEngine.Templating;

namespace Deventure.Utils
{
    public class RazorTemplateUtil
    {
        private const byte BOM_FIRST = 0xEF;
        private const byte BOM_SECOND = 0xBB;
        private const byte BOM_THIRD = 0xBF;
        private const byte BOM_BYTES_COUNT = 3;

        private static readonly IDictionary<string, ITemplateKey> mRegisteredTemplates = new Dictionary<string, ITemplateKey>();

        public static string GetTextBodyFromHtmlString(string htmlString)
        {
            if (string.IsNullOrWhiteSpace(htmlString))
            {
                return null;
            }

            var allHtmlTagReg = new Regex("<[^>]*>");
            var result = allHtmlTagReg.Replace(htmlString, "");

            return result;
        }

        public static string ParseHtmlTemplateAsString<T>(string fullTemplatePath, T model)
        {
            string templateBody = null;

            if (string.IsNullOrWhiteSpace(fullTemplatePath))
            {
                LogHelper.LogInfo<RazorTemplateUtil>("fullTemplatePath is empty!");
            }
            else
            {
                templateBody = GetBodyFromFilePath(fullTemplatePath);

                if (string.IsNullOrWhiteSpace(templateBody) || model == null)
                {
                    LogHelper.LogInfo<RazorTemplateUtil>("body is empty!");
                }
                else
                {
                    templateBody = CustomFormat(templateBody, fullTemplatePath, model);
                }
            }

            return templateBody;
        }

        public static string ParseHtmlTemplateAsString(string fullTemplatePath)
        {
            string templateBody = null;

            if (string.IsNullOrWhiteSpace(fullTemplatePath))
            {
                LogHelper.LogInfo<RazorTemplateUtil>("fullTemplatePath is empty!");
            }
            else
            {
                templateBody = GetBodyFromFilePath(fullTemplatePath);

                if (string.IsNullOrWhiteSpace(templateBody))
                {
                    LogHelper.LogInfo<RazorTemplateUtil>("body is empty!");
                }
                else
                {
                    templateBody = CustomFormat(templateBody, fullTemplatePath);
                }
            }

            return templateBody;
        }

        private static string ReadAllText(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            string result = null;
            using (var sourceStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
            {
                try
                {
                    var sb = new StringBuilder();

                    string line;

                    // Read the file and display it line by line.  
                    var fileStream = new System.IO.StreamReader(filePath);
                    while ((line = fileStream.ReadLine()) != null)
                    {
                        sb.AppendLine(line);
                    }

                    fileStream.Close();

                    result = sb.ToString();
                }
                catch (Exception e)
                {
                    LogHelper.LogException<RazorTemplateUtil>(e);
                }
            }

            return result;
        }

        /// <summary>
        ///     Gets the body template from a file
        /// </summary>
        /// <param name="templatePath">path to the template</param>
        /// <returns>the template of the body</returns>
        private static string GetBodyFromFilePath(string templatePath)
        {
            string body = null;

            if (string.IsNullOrWhiteSpace(templatePath))
            {
                LogHelper.LogInfo<RazorTemplateUtil>("templatePath is empty!");
            }
            else
            {
                try
                {
                    body =  ReadAllText(templatePath);
                }
                catch (Exception e)
                {
                    LogHelper.LogException<RazorTemplateUtil>(e);
                }
            }

            return body;
        }

        private static string CustomFormat<T>(string templateBody, string fullTemplatePath, T model)
        {
            string body = null;
            try
            {
                var modelType = typeof(T);
                var templateKey = GenerateKey(templateBody, fullTemplatePath, modelType);

                body = Engine.Razor.Run(templateKey, modelType, model);
            }
            catch (Exception ex)
            {
                LogHelper.LogException<RazorTemplateUtil>(ex);
            }

            return body;
        }

        private static string CustomFormat(string templateBody, string fullTemplatePath)
        {
            string body = null;
            try
            {
                var templateKey = GenerateKey(templateBody, fullTemplatePath);

                body = Engine.Razor.Run(templateKey);
            }
            catch (Exception ex)
            {
                LogHelper.LogException<RazorTemplateUtil>(ex);
            }

            return body;
        }

        private static ITemplateKey GenerateKey(string templatebody, string fullTemplatePath, Type modelType = null)
        {
            var startIndex = fullTemplatePath.LastIndexOf(@"\", StringComparison.InvariantCulture) + 1;
            var stopIndex = fullTemplatePath.Length;
            var length = stopIndex - startIndex;

            var template = fullTemplatePath.Substring(startIndex, length);
            if (modelType != null)
            {
                template = $"{template}#{modelType.FullName}";
            }

            if (mRegisteredTemplates.ContainsKey(template))
            {
                return mRegisteredTemplates[template];
            }

            var templateKey = Engine.Razor.GetKey(template, ResolveType.Layout);
            mRegisteredTemplates.Add(template, templateKey);

            Engine.Razor.AddTemplate(templateKey, templatebody);
            Engine.Razor.Compile(templateKey, modelType);

            return templateKey;
        }
    }
}