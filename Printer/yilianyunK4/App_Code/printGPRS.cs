using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography;

/// <summary>
/// printGPRS 的摘要说明
/// </summary>
public class printGPRS
{

    public string SendGprsPrintContent(string text)
    {
        //服务器返回状态
        string staus = "";
        //用户id
        string partner = "6";
        //apikey API 密钥
        string apikey = "d17d7d6cdaaa77a6dba928b6553c665325a033d5";
        //机器码 终端编号
        string machine_code = "4004504155";
        //终端密钥
        string mkey = "itv2732z5bw6";
        //接口地址  
        string IPstr = "open.10ss.net";  
        //接口端口
        string port = "8888";
        //时间戳
        string time = "";
        //签名
        string sign = "";

        #region 开始生成时间戳
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        time = Convert.ToInt64(ts.TotalSeconds).ToString();     //获取时间戳
        #endregion

        #region 参数列表
        Dictionary<string, string> parameters = new Dictionary<string, string>();    
        parameters.Add("machine_code", machine_code);
        parameters.Add("partner", partner);
        parameters.Add("time", time);
        #endregion

        //对apikey+(machine_code+partner+time)+mkey 进行签名加密
        sign = getSign(parameters, apikey, mkey);  

        //提交内容格式
        string postquery = "partner={0}&machine_code={1}&time={2}&sign={3}&content={4}".Replace("{0}", partner).Replace("{1}", machine_code).Replace("{2}", time).Replace("{3}", sign).Replace("{4}", text);
        
        string sendMsg = "POST / HTTP/1.1\r\n" + "Host: " + IPstr +":"+port+ "\r\n" +"Content-Type: application/x-www-form-urlencoded\r\n" +"Content-Length: " + postquery.Length.ToString()+ "\r\n\r\n"+ postquery;
        //try捕获异常
        try
        {
            //WorkerMan接口服务器，使用socket传送数据                                          
            Socket mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            mySocket.Connect(IPstr, int.Parse(port));
            int ctLen = Encoding.UTF8.GetBytes(postquery).Length;

            byte[] buffer = Encoding.UTF8.GetBytes(string.Format(sendMsg, IPstr + ":" + port, ctLen, postquery));
            mySocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
            
            //接收返回数据
            buffer = new byte[2048000];
            int n;
            MemoryStream ms = new MemoryStream();
            while ((n = mySocket.Receive(buffer, 0, buffer.Length, SocketFlags.None)) > 0)
            {
                ms.Write(buffer, 0, n);
                Array.Clear(buffer, 0, buffer.Length);
            }
            string result = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            mySocket.Shutdown(SocketShutdown.Both);
            mySocket.Close();
            staus = result+" &nbsp;<br/>"+DateTime.Now.ToString();
        }
        catch
        {
            staus = "error";
        }
        //返回状态
        return staus;
    }
    
    /// <summary>
    /// 创建本次调用的签名
    /// </summary>       
    /// <param name="parameters">parameters，参数列表</param>
    /// <param name="preKey">preKey，apikey的值</param>
    /// <param name="secKey">secKey，终端密钥的值</param>
    /// <returns>String，签名</returns>
    private static String getSign(IDictionary<string, string> parameters, string preKey, string secKey)
    {
        // 第一步：把字典按Key的字母顺序排序
        IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
        IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();
        // 第二步：把所有参数名和参数值串在一起
        StringBuilder query = new StringBuilder("");

        while (dem.MoveNext())
        {
            string key = dem.Current.Key;
            string value = dem.Current.Value;
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                query.Append(key).Append(value);
            }
        }
        string source = query.ToString();
        source = preKey + source + secKey;
        return GetMD5Hash(source);
    }
    /// <summary>
    /// MD5加密
    /// </summary>
    /// <param name="input"></param>
    /// <returns>MD5 32位大写</returns>
    public static string GetMD5Hash(String input)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] res = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        string md = BitConverter.ToString(res).Replace("-", "");
        return md;
    }


}
