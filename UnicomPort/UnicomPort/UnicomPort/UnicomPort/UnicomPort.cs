using SMSCloudHttpSend;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UnicomPort
{
    public class UnicomPort
    {
        //端口参数，必须填写
        public String account; //账号"dh74381";
        public String passWord;//密码 = "uAvb3Qey";
        public String subCode;//短信子码"74431"，接收回馈信息用
        public String sign; //短信签名，！仅在！发送短信时用= "【国家海洋预报台】";
        //短信发送与查询所需参数
        public String phones;//电话号码
        public String smsContent;//短信内容
        public String sendTime;//计划发送时间，为空则立即发送
        public String vipPhones;//VIP的电话号码
        //服务器反馈信息
        public String returnMsg;//接收返回字符串信息
        public String smsId;//该批短信编号(32位UUID)，发送时不用填，发送后会自动填好
        //解读服务器反馈信息后得到的参数
        public String result;//返回状态值
        public String desc;//返回状态中文描述
        public String smsamount;//短信费用余额
        public String smsnumber;//短信余量
        public String smsfreeze;//短信欠费
        public String mmsamount;//彩信费用余额
        public String mmsnumber;//彩信余量
        public String mmsfreeze;//彩信欠费
        public String blacklist;//黑名单
        public String keywords;//敏感词
        //通过模块处理后得到的信息
        public DateTime sendingTime;//短信实际发送时间
        public bool returnValue=true;//返回值
        public String strMsg;//总体返回一句话作为反馈信息
        public String resendMsg;//重发信息的文字反馈
        public String resendVipNumbers;//重发过的号码
        public String[][] sendReportMat;//发送情况查询结果有多项内容时的存储矩阵,包含发送的状态码、状态说明、错误码、时间等4列

        /// <summary>
        /// 发送短信，并检查VIP重发
        /// </summary>
        //发送短信，并检查VIP重发
        public void sendSMS()
        {
            String _data = null;//XML文本
            String _serverURL = "http://wt.3tong.net/http/sms/Submit";//服务器地址
            //判断参数是否足够
            if (account.Length < 1 & passWord.Length < 1 & sign.Length < 1 & phones.Length < 1 & smsContent.Length < 1)
            {
                returnValue = false;//有问题
                strMsg = "参数不全";
                return;
            }
            //合成请求信息
            _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                        + "<message>"
                            + "<account>" + account + "</account>"
                            + "<password>" + md5(passWord) + "</password>"
                            + "<msgid>" + smsId + "</msgid>"
                            + "<phones>" + phones + "</phones>"
                            + "<content>" + smsContent + "</content>"
                            + "<sign>" + sign + "</sign>"
                            + "<subcode>" + subCode + "</subcode>"
                            + "<sendtime>" + sendTime + "</sendtime>"
                        + "</message>";
            //http方式发送
            returnMsg = httpInvoke(_serverURL, _data);
            //解析服务器反馈信息
            if (returnMsg.Length < 1)
            {
                returnValue = false;//有问题
                strMsg = "未收到服务器返回信息";
                return;
            }

            result = xml2str(returnMsg, "response/result");
            desc = xml2str(returnMsg, "response/desc");
            smsId = xml2str(returnMsg, "response/msgid");
            //检测解析时是否有问题
            if (returnValue == false)
            {
                strMsg = "解析异常：" + result + desc;
                return;
            }
            //解析没有错误反馈信息
            strMsg = "短信发送结果：" + desc;
            returnValue = true;
            sendingTime = DateTime.Now;//记录发送时间


            //等待信息发送完成后
            System.Threading.Thread.Sleep(10000);//10秒
            //自动重发
            vipResend();
        }

        /// <summary>
        /// 查询余额
        /// </summary>
        public void getBanlance()
        {
            //判断参数是否足够
            if (account.Length < 1 & passWord.Length < 1)
            {
                returnValue = false;//有问题
                strMsg = "参数不全";
                return;
            }
            String _data = null;//XML文本
            String _serverURL = "http://wt.3tong.net/http/sms/Balance";//服务器地址
            _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<message>"
                    + "<account>" + account + "</account>"
                    + "<password>" + md5(passWord) + "</password>"
                + "</message>";
            //http方式发送
            returnMsg = httpInvoke(_serverURL, _data);
            //解析服务器反馈信息
            if (returnMsg.Length < 1)
            {
                returnValue = false;//有问题
                strMsg = "未收到服务器返回信息";
                return;
            }

            smsamount = xml2str(returnMsg, "response/sms/amount");
            smsnumber = xml2str(returnMsg, "response/sms/number");
            smsfreeze = xml2str(returnMsg, "response/sms/freeze");
            //检测解析时是否有问题
            if (returnValue == false)
            {
                strMsg = "解析异常：" + smsamount + smsnumber + smsfreeze;
                return;
            }
            //解析没有错误反馈信息
            strMsg = "短信剩余金额" + smsamount + "元，" + "共" + smsnumber + "条," + "欠费" + smsfreeze + "元。无彩信信息";
            returnValue = true;
        }

        /// <summary>
        /// 查询黑名单
        /// </summary>
        public void getBlacklist()
        {
            //判断参数是否足够
            if (account.Length < 1 & passWord.Length < 1 & phones.Length < 1)
            {
                returnValue = false;//有问题
                strMsg = "参数不全";
                return;
            }
            String _data = null;//XML文本
            String _serverURL = "http://wt.3tong.net/http/sms/BlackListCheck";//服务器地址
            _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<message>"
                    + "<account>" + account + "</account>"
                    + "<password>" + md5(passWord) + "</password>"
                        + "<phones>"
                        + phones
                        + "</phones>"
                + "</message>";
            //http方式发送
            returnMsg = httpInvoke(_serverURL, _data);
            //解析服务器反馈信息
            if (returnMsg.Length < 1)
            {
                returnValue = false;//有问题
                strMsg = "未收到服务器返回信息";
                return;
            }

            desc = xml2str(returnMsg, "response/desc");
            blacklist = xml2str(returnMsg, "response/blacklist");
            //检测解析时是否有问题
            if (returnValue == false)
            {
                strMsg = "解析异常：" + desc + blacklist;
                return;
            }
            //解析没有错误反馈信息
            strMsg = desc + "。黑名单号码为：" + blacklist;
            returnValue = true;
        }

        /// <summary>
        /// 查询敏感词
        /// </summary>
        public void checkKeyWord()
        {
            //判断参数是否足够
            if (account.Length < 1 & passWord.Length < 1 & smsContent.Length < 1)
            {
                returnValue = false;//有问题
                strMsg = "参数不全";
                return;
            }
            String _data = null;//XML文本
            String _serverURL = "http://wt.3tong.net/http/sms/KeywordCheck";//服务器地址
            _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<message>"
                    + "<account>" + account + "</account>"
                    + "<password>" + md5(passWord) + "</password>"
                    + "<content>"
                    + smsContent
                    + "</content>"
                + "</message>";
            //http方式发送
            returnMsg = httpInvoke(_serverURL, _data);
            //解析服务器反馈信息
            if (returnMsg.Length < 1)
            {
                returnValue = false;//有问题
                strMsg = "未收到服务器返回信息";
                return;
            }

            keywords = xml2str(returnMsg, "response/keywords");
            //检测解析时是否有问题
            if (returnValue == false)
            {
                strMsg = "解析异常：" + keywords;
                return;
            }
            //解析没有错误反馈信息
            strMsg = "该信息中的敏感词如下：" + keywords;
            returnValue = true;
        }

        /// <summary>
        /// 一般的查询发送情况
        /// </summary>
        public void getReport()
        {
            //判断参数是否足够
            if (account.Length < 1 & passWord.Length < 1)
            {
                returnValue = false;//有问题
                strMsg = "参数不全";
                return;
            }
            String[] _status;//接收特定号码特定信息的短信发送反馈状态值
            String[] _desc;//接收特定号码特定信息的短信发送反馈状态说明
            String[] _wgcode;//接收特定号码特定信息的短信发送反馈错误码
            String[] _time;//接收特定号码特定信息的短信发送时间
            String _data = null;//XML文本
            String _serverURL = "http://wt.3tong.net/http/sms/Report";//服务器地址
            _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<message>"
                    + "<account>" + account + "</account>"
                    + "<password>" + md5(passWord) + "</password>"
                    + "<msgid>" + smsId + "</msgid>"
                    + "<phone>" + phones + "</phone>"
                + "</message>";
            //http方式发送
            //returnMsg = httpInvoke(_serverURL, _data);
            //解析服务器反馈信息
            if (returnMsg.Length < 1)
            {
                returnValue = false;//有问题
                strMsg = "未收到服务器返回信息";
                return;
            }
            //解析前一部分
            result = xml2str(returnMsg, "response/result");
            desc = xml2str(returnMsg, "response/desc");
            //检测解析时是否有问题
            if (returnValue == false)
            {
                strMsg = "解析异常：" + result + desc;
                return;
            }

            //前一部分没有问题再解析后一部分
            //先尝试解析第一个值
            _status = xml2strList(returnMsg, "response/report/status");
            //如果第一个值有内容则继续，否则说明没有后续内容
            if (_status!=null)
            {
                _desc = xml2strList(returnMsg, "response/report/desc");
                _wgcode = xml2strList(returnMsg, "response/report/wgcode");
                _time = xml2strList(returnMsg, "response/report/time");
                if (!(_status.Length == _desc.Length | _status.Length == _wgcode.Length | _status.Length == _time.Length))//检查各组长度是否统一
                {
                    strMsg = "多组解析异常";
                    returnValue = false;
                    return;
                }
                strMsg = "反馈结果为：" + desc+"(还有短信发送结果请查看sendReportMat)";
                sendReportMat = new String[_status.Length][];
                for (int i = 0; i < _status.Length; i++)
                {
                    sendReportMat[i] = new String[4];
                    sendReportMat[i][0] = _status[i];
                    sendReportMat[i][1] = _desc[i];
                    sendReportMat[i][2] = _wgcode[i];
                    sendReportMat[i][3] = _time[i];
                }

            }
            strMsg = "反馈结果为：" + desc + "(无其它结果)";

            returnValue = true;
        }

        /// <summary>
        /// 接收短信，解析尚未制作
        /// </summary>
        public void getSMS()
        {
            //判断参数是否足够
            if (account.Length < 1 & passWord.Length < 1)
            {
                returnValue = false;//有问题
                strMsg = "参数不全";
                return;
            }
            String _data = null;//XML文本
            String _serverURL = "http://wt.3tong.net/http/sms/Deliver";//服务器地址
            _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<message>"
                    + "<account>" + account + "</account>"
                    + "<password>" + md5(passWord) + "</password>"
                + "</message>";
            returnMsg = httpInvoke(_serverURL, _data);//http方式发送
                                                      //<?xml version='1.0' encoding='utf-8'?><response><result>0</result><desc></desc></response>
                                                      //<?xml version='1.0' encoding='utf-8'?><response><result>0</result><desc>成功</desc><sms><phone>15210161270</phone><content>这是爸爸的号</content><subcode>74431</subcode><delivertime>2016-03-31 16:24:57</delivertime></sms><sms><phone>13811104406</phone><content>_(ÒωÓ๑ゝ∠)_看我颜艺的一趴！</content><subcode>74431</subcode><delivertime>2016-03-31 16:25:15</delivertime></sms></response>
                                                      //接收解析尚未制作

        }

        /// <summary>
        /// VIP重发
        /// </summary>
        private void vipResend()
        {
            String _data = null;//XML文本
            String _serverURL = "http://wt.3tong.net/http/sms/Report";//服务器地址
            String[] _splitVipPhone = vipPhones.Split(',', ',');
            String _returnMsg;//临时用来读取服务器反馈信息
            String[] _status = new String[_splitVipPhone.Length];//存放状态值0——成功；1——接口处理失败；2——运营商网关失败；
            String[] _desc = new String[_splitVipPhone.Length];//当status为1时，以desc的错误码为准
            String[] _wgcode = new String[_splitVipPhone.Length];//当status为2时，表示运营商网关返回的原始值；
            int _resendNumber=0;//用于记录重发的个数
            for (int i = 0; i < _splitVipPhone.Length; i++)
            {
                _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
               + "<message>"
                   + "<account>" + account + "</account>"
                   + "<password>" + md5(passWord) + "</password>"
                   + "<msgid>" + smsId + "</msgid>"
                   + "<phone>" + _splitVipPhone[i] + "</phone>"
               + "</message>";
                //http方式发送
                _returnMsg = httpInvoke(_serverURL, _data);
                //解析服务器反馈信息
                if (_returnMsg.Length < 1)
                {
                    returnValue = false;//有问题
                    strMsg = strMsg + "对" + _splitVipPhone[i] + "号码进行发送状态检测时，未收到服务器返回信息.";
                    continue;
                }
                _status[i] = xml2str(_returnMsg, "response/report/status");
                _desc[i] = xml2str(_returnMsg, "response/report/desc");
                _wgcode[i] = xml2str(_returnMsg, "response/report/wgcode");
                //判断当前号码的发送状态
                switch (_status[i])
                {
                    case "0"://成功
                        break;
                    case "1"://失败重发
                        //合成请求信息,部分内容与普通发送不同
                        _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                    + "<message>"
                                        + "<account>" + account + "</account>"
                                        + "<password>" + md5(passWord) + "</password>"
                                        + "<msgid>" + "" + "</msgid>"
                                        + "<phones>" + _splitVipPhone[i] + "</phones>"
                                        + "<content>" + smsContent + "</content>"
                                        + "<sign>" + sign + "</sign>"
                                        + "<subcode>" + subCode + "</subcode>"
                                        + "<sendtime>" + "" + "</sendtime>"
                                    + "</message>";
                        //http方式重发
                        httpInvoke(_serverURL, _data);
                        resendMsg = resendMsg + _splitVipPhone[i] + "接口处理失败已重发(desc=" + _desc[i] + ",wgcode=" + _wgcode[i] + ")";
                        if (resendVipNumbers.Length > 0) resendVipNumbers = resendVipNumbers + ",";
                        resendVipNumbers = resendVipNumbers + _splitVipPhone[i];
                        _resendNumber++;
                        break;
                    case "2"://失败重发
                        //合成请求信息,部分内容与普通发送不同
                        _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                    + "<message>"
                                        + "<account>" + account + "</account>"
                                        + "<password>" + md5(passWord) + "</password>"
                                        + "<msgid>" + "" + "</msgid>"
                                        + "<phones>" + _splitVipPhone[i] + "</phones>"
                                        + "<content>" + smsContent + "</content>"
                                        + "<sign>" + sign + "</sign>"
                                        + "<subcode>" + subCode + "</subcode>"
                                        + "<sendtime>" + "" + "</sendtime>"
                                    + "</message>";
                        //http方式重发
                        httpInvoke(_serverURL, _data);
                        resendMsg = resendMsg + _splitVipPhone[i] + "接口处理失败已重发(desc=" + _desc[i] + ",wgcode=" + _wgcode[i] + ")";
                        if (resendVipNumbers.Length > 0) resendVipNumbers = resendVipNumbers + ",";
                        resendVipNumbers = resendVipNumbers + _splitVipPhone[i];
                        _resendNumber++;
                        break;
                    default://未知问题，不管了
                        resendMsg = resendMsg + _splitVipPhone[i] + "未知异常。";
                        returnValue = false;
                        break;
                }
            }
            resendMsg = resendMsg + "共重发" + _resendNumber + "次。";
        }

        //反馈信息读取程序
        /// <summary>
        /// 反馈信息读取单一模式
        /// </summary>
        /// <param name="_returnMsg"></param>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        private String xml2str(String _returnMsg, String treeNode)//单一模式
        {
            XmlDocument xx = new XmlDocument();
            xx.LoadXml(_returnMsg);
            XmlNode nodes = xx.SelectSingleNode(treeNode);
            if (nodes == null)
            {
                returnValue = false;
                return treeNode+"未检测到该标签";
            }
            return nodes.InnerText;
        }



        /// <summary>
        /// 反馈信息读取多组模式
        /// </summary>
        /// <param name="_returnMsg"></param>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        private String[] xml2strList(String _returnMsg, String treeNode)//多组模式
        {
            XmlDocument xx = new XmlDocument();
            xx.LoadXml(_returnMsg);
            XmlNodeList nodes = xx.SelectNodes(treeNode);
            if (nodes.Count == 0)
            {
                return null;
            }
            String[] str = new string[nodes.Count];//传递用的
            for (int i = 0; i < nodes.Count; i++) str[i] = nodes[i].InnerText;

            return str;
        }

        //发送程序
        /// <summary>
        /// 大汉三通提供的发送程序
        /// </summary>
        /// <param name="iServerURL"></param>
        /// <param name="iMessage"></param>
        /// <returns></returns>
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
                msgText = e.Message + "调用异常" + "（。报错位置：UnicomPorts.httpInvoke）";
                //MessageBox.Show(e.Message, "调用异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return msgText;
            }

            return responseText;
        }


        /// <summary>
        /// MD5加密程序（32位小写）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string md5(string str)
        {
            byte[] result = Encoding.Default.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            String md = BitConverter.ToString(output).Replace("-", "");
            return md.ToLower();
        }
    }
}
