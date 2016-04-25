using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication1
{
   public class PortMsg
    {
        //主要用于存储发送模块所发送与反馈的所有信息
        public String opTag;
        public String phones;//电话号码
        public String smsContent;//短信内容
        public DateTime sendTime;//发送时间
        public String returnMsg;//接收返回字符串
        //一下为解读后的参数
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

        public String strMsg;//总体返回一句话作为反馈信息



        public void portMsg(String _opTag,String _phones,String _smsContent,String _returnMsg)
        {
            opTag = _opTag;
            phones = _phones;
            smsContent = _smsContent;
            DateTime sendTime = DateTime.Now;//记录发送时间
            returnMsg = _returnMsg;
            readMsg();
        }

        private void readMsg()
        {
            switch (opTag)
            {
                case "SendSMS"://发送短信
                    result = xml2str(returnMsg, "response/result");
                    desc = xml2str(returnMsg, "response/desc");
                    strMsg = "短信发送结果：" + desc;
                    break;
                case "GetSMS"://获取上行，即接收短信
                              //<?xml version='1.0' encoding='utf-8'?><response><result>0</result><desc></desc></response>
                              //<?xml version='1.0' encoding='utf-8'?><response><result>0</result><desc>成功</desc><sms><phone>15210161270</phone><content>这是爸爸的号</content><subcode>74431</subcode><delivertime>2016-03-31 16:24:57</delivertime></sms><sms><phone>13811104406</phone><content>_(ÒωÓ๑ゝ∠)_看我颜艺的一趴！</content><subcode>74431</subcode><delivertime>2016-03-31 16:25:15</delivertime></sms></response>
                              //接收解析尚未制作
                    strMsg = "接收短信尚未制作";
                    break;
                case "GetBanlance"://查询余额
                    //<?xml version='1.0' encoding='utf-8'?><response><result>0</result><desc></desc><sms><amount>18.9</amount><number>189</number><freeze>0.0</freeze></sms><mms></mms></response>
                    smsamount = xml2str(returnMsg, "response/sms/amount");
                    smsnumber = xml2str(returnMsg, "response/sms/number");
                    smsfreeze = xml2str(returnMsg, "response/sms/freeze");
                    strMsg = "短信剩余金额" + smsamount + "元，" + "共" + smsnumber + "条," + "欠费" + smsfreeze + "元。彩信未制作";
                    break;
                case "GetReport"://获取状态报告
                    //<?xml version='1.0' encoding='utf-8'?><response><result>0</result><desc>成功</desc></response>
                    //读取反馈信息
                    result = xml2str(returnMsg, "response/result");
                    desc = xml2str(returnMsg, "response/desc");
                    strMsg = "反馈结果为：" + desc;
                    break;
                case "GetBlacklist"://查询黑名单
                    //<?xml version='1.0' encoding='utf-8'?><response><result>0</result><desc>提交成功</desc><blacklist></blacklist></response>
                    //读取反馈信息中desc和blacklist部分内容
                    desc = xml2str(returnMsg, "response/desc");
                    blacklist = xml2str(returnMsg, "response/blacklist");
                    strMsg = desc + "。黑名单号码为：" + blacklist;
                    break;
                case "CheckKeyWord"://检测敏感词
                    //<?xml version='1.0' encoding='utf-8'?><response><result>0</result><desc></desc><keywords></keywords></response>
                    //读取keywords
                    keywords = xml2str(returnMsg, "response/keywords");
                    strMsg = "该信息中的敏感词如下：" + keywords;
                    break;
                default:
                    strMsg = "PortMsg报错：错误的发送功能选项,请查询opTag，报错位置：UnicomPorts.sendPort";
                    break;
            }

           
            //return "OK";
        }
    


        //反馈信息读取程序
        private String xml2str(String _returnMsg, String treeNode)
        {
            XmlDocument xx = new XmlDocument();
            xx.LoadXml(_returnMsg);
            XmlNode nodes = xx.SelectSingleNode(treeNode);
            if (nodes != null) return nodes.InnerText;
            else return "xml2str查询结果为空，请检查";
        }
    }
}
