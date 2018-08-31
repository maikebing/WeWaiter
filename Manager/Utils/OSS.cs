using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliyun.OSS;
namespace WWM.Utils
{
    public static class OSS
    {
        public static  bool UploadFile(string fileToUpload,string keyname)
        {
            bool ok = false;
            // 初始化OssClient
            var client = new OssClient(Properties.Settings.Default.EndPoint, Properties.Settings.Default.AccessKeyID, Properties.Settings.Default.AccessKeySecret);
            try
            {
                
                var result = client.PutObject(Properties.Settings.Default.BucketName, keyname, fileToUpload);
                ok = result.HttpStatusCode == System.Net.HttpStatusCode.OK;
                Console.WriteLine("Put object succeeded");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Put object failed, {0}", ex.Message);
            }
            return ok;
        }
    
    }
}
