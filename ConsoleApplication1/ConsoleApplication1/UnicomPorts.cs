using SMSCloudHttpSend;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication1
{
    public class UnicomPorts
    {
        //发送接口的函数，输入
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_account"></param>
        /// <param name="_passWord"></param>
        /// <param name="_phones"></param>
        /// <param name="_smsId"></param>
        /// <param name="_smsContent"></param>
        /// <param name="_sign"></param>
        /// <param name="_subCode"></param>
        /// <param name="_sendTime"></param>
        /// <param name="opTag"></param>
        /// <returns></returns>
        public PortMsg sendPort(String _account, String _passWord, String _phones, String _smsId, String _smsContent, String _sign, String _subCode, String _sendTime, String opTag)
        {
            String _data = null;//XML文本
            String _serverURL = null;//服务器地址
            String _returnMsg = null;//保存服务器反馈信息
            PortMsg portMsg = new PortMsg();//存储发送模块所发送与反馈的所有信息
            //XmlDocument xx = new XmlDocument();
            _passWord = md5(_passWord);
            switch (opTag)
            {
                case "SendSMS"://发送短信
                    _serverURL = "http://wt.3tong.net/http/sms/Submit";//服务器地址
                    _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                + "<message>"
                                    + "<account>" + _account + "</account>"
                                    + "<password>" + _passWord + "</password>"
                                    + "<msgid>" + _smsId + "</msgid>"
                                    + "<phones>" + _phones + "</phones>"
                                    + "<content>" + _smsContent + "</content>"
                                    + "<sign>" + _sign + "</sign>"
                                    + "<subcode>" + _subCode + "</subcode>"
                                    + "<sendtime>" + _sendTime + "</sendtime>"
                                + "</message>";
                    _returnMsg = httpInvoke(_serverURL, _data);//http方式发送
                    if (_returnMsg.Length > 0) portMsg.portMsg(opTag, _phones, _smsContent, _returnMsg);//进行发送记录与反馈解析
                    else portMsg.strMsg = "SendSMS未接收到服务器反馈信息";
                    break;
                case "GetSMS"://获取上行，即接收短信
                    _serverURL = "http://wt.3tong.net/http/sms/Deliver";//服务器地址
                    _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                        + "<message>"
                            + "<account>" + _account + "</account>"
                            + "<password>" + _passWord + "</password>"
                        + "</message>";
                    _returnMsg = httpInvoke(_serverURL, _data);//http方式发送
                                                               //<?xml version='1.0' encoding='utf-8'?><response><result>0</result><desc></desc></response>
                                                               //<?xml version='1.0' encoding='utf-8'?><response><result>0</result><desc>成功</desc><sms><phone>15210161270</phone><content>这是爸爸的号</content><subcode>74431</subcode><delivertime>2016-03-31 16:24:57</delivertime></sms><sms><phone>13811104406</phone><content>_(ÒωÓ๑ゝ∠)_看我颜艺的一趴！</content><subcode>74431</subcode><delivertime>2016-03-31 16:25:15</delivertime></sms></response>
                                                               //接收解析尚未制作
                    if (_returnMsg.Length > 0) portMsg.portMsg(opTag, _phones, _smsContent, _returnMsg);//进行发送记录与反馈解析
                    else portMsg.strMsg = "GetSMS未接收到服务器反馈信息";
                    break;
                case "GetBanlance"://查询余额
                    _serverURL = "http://wt.3tong.net/http/sms/Balance";//服务器地址
                    _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                        + "<message>"
                            + "<account>" + _account + "</account>"
                            + "<password>" + _passWord + "</password>"
                        + "</message>";
                    _returnMsg = httpInvoke(_serverURL, _data);//http方式发送
                    if (_returnMsg.Length > 0) portMsg.portMsg(opTag, _phones, _smsContent, _returnMsg);//进行发送记录与反馈解析
                    else portMsg.strMsg = "GetBanlance未接收到服务器反馈信息";
                    break;
                case "GetReport"://获取状态报告
                    _serverURL = "http://wt.3tong.net/http/sms/Report";//服务器地址
                    _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                        + "<message>"
                            + "<account>" + _account + "</account>"
                            + "<password>" + _passWord + "</password>"
                            + "<msgid>" + _smsId + "</msgid>"
                            + "<phone>" + _phones + "</phone>"
                        + "</message>";
                    _returnMsg = httpInvoke(_serverURL, _data);//http方式发送
                    if (_returnMsg.Length > 0) portMsg.portMsg(opTag, _phones, _smsContent, _returnMsg);//进行发送记录与反馈解析
                    else portMsg.strMsg = "GetReport未接收到服务器反馈信息";
                    break;
                case "GetBlacklist"://查询黑名单
                    _serverURL = "http://wt.3tong.net/http/sms/BlackListCheck";//服务器地址
                    _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                        + "<message>"
                            + "<account>" + _account + "</account>"
                            + "<password>" + _passWord + "</password>"
                                + "<phones>"
                                + _phones
                                + "</phones>"
                        + "</message>";
                    _returnMsg = httpInvoke(_serverURL, _data);//http方式发送
                    if (_returnMsg.Length > 0) portMsg.portMsg(opTag, _phones, _smsContent, _returnMsg);//进行发送记录与反馈解析
                    else portMsg.strMsg = "GetBlacklist未接收到服务器反馈信息";
                    break;
                case "CheckKeyWord"://检测敏感词
                    _serverURL = "http://wt.3tong.net/http/sms/KeywordCheck";//服务器地址
                    _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                        + "<message>"
                            + "<account>" + _account + "</account>"
                            + "<password>" + _passWord + "</password>"
                            + "<content>"
                            + _smsContent
                            + "</content>"
                        + "</message>";
                    _returnMsg = httpInvoke(_serverURL, _data);//http方式发送
                    if (_returnMsg.Length > 0) portMsg.portMsg(opTag, _phones, _smsContent, _returnMsg);//进行发送记录与反馈解析
                    else portMsg.strMsg = "CheckKeyWord未接收到服务器反馈信息";
                    break;
                default:
                    portMsg.strMsg = "UnicomPorts报错：错误的发送功能选项,请查询opTag，报错位置：UnicomPorts.sendPort";
                    break;
            }
            
           return portMsg;
            //return "OK";
        }


        private String httpInvoke(String iServerURL, String iMessage)
        {
            String responseText = null;//接收联通服务器反馈的信息
            String msgText = null;//
            try
            {
                CTCWebClient _webClient = new CTCWebClient();
                NameValueCollection _postValues = new NameValueCollection();
                _postValues.Add("message", iMessage);
                byte[] _responseArray = _webClient.UploadValues(iServerURL, _postValues);
                //向服务器发送POST数据
                responseText = Encoding.UTF8.GetString(_responseArray);
            }
            catch (Exception e)//不懂？？？？？？？？？
            {
                msgText = e.Message + "调用异常"+"（。报错位置：UnicomPorts.httpInvoke）";
                //MessageBox.Show(e.Message, "调用异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return msgText;
            }

            return responseText;
        }


        //MD5加密程序（32位小写）
        private static string md5(string str)
        {
            byte[] result = Encoding.Default.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            String md = BitConverter.ToString(output).Replace("-", "");
            return md.ToLower();
        }

        //反馈信息读取程序
        private String xml2str(String _returnMsg,String treeNode)
        {
            XmlDocument xx = new XmlDocument();
            xx.LoadXml(_returnMsg);
            XmlNode nodes = xx.SelectSingleNode(treeNode);
            if (nodes != null) return nodes.InnerText;
            else return "xml2str查询结果为空，请检查";
        }
    }
}
