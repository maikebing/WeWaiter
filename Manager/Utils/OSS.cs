using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliyun.OSS;
using RestSharp;

namespace WWM.Utils
{
    public static class OSS
    {
        public static bool UploadFile(string fileToUpload, string fileKey)
        {
            bool ok = false;

            // 初始化OssClient
            var client = new OssClient(Properties.Settings.Default.EndPoint, Properties.Settings.Default.AccessKeyID, Properties.Settings.Default.AccessKeySecret);
            try
            {
                var result = client.PutObject(Properties.Settings.Default.BucketName, fileKey, fileToUpload);
                ok = result.HttpStatusCode == System.Net.HttpStatusCode.OK;
                Console.WriteLine("Put object succeeded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Put object failed, {0}", ex.Message);
            }
            return ok;
        }

        public static bool CopyFile(string fileToUpload, string fileKey)
        {
            bool ok = false;

            // 初始化RestClient
            var client = new RestClient(Properties.Settings.Default.ApiBaseUrl);
            try
            {
                var request = new RestRequest("/api/upload", Method.POST);
                //request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("Content-Type", "multipart/form-data");
                request.AddFile("file", fileToUpload);
                request.AddQueryParameter("fileKey", fileKey);

                var result = client.Execute(request);
                ok = result.StatusCode == System.Net.HttpStatusCode.OK;
                Console.WriteLine("Copy object succeeded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Copy object failed, {0}", ex.Message);
            }
            return ok;
        }
    }
}
