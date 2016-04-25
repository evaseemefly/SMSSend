using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
//using SMSCloudHttpSend;
using System.Collections.Specialized;
using SMSCloudHttpSend;
using System.Xml;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


            String tips = "<?xml version='1.0' encoding='utf-8'?><response><result>2</result><desc>密码错误</desc><blacklist></blacklist></response>";//http方式发送
            XmlDocument xx = new XmlDocument();
            xx.LoadXml(tips);
            XmlNode nodes = xx.SelectSingleNode("response/desc");
            tips = nodes.InnerText;

            //XmlNodeList nodes = xx.SelectNodes("/response");
            //string uid = (nodes[0].SelectSingleNode("//result")).InnerText;



            //以下为发送系统需要提供的

            String _account = "dh74381";//账号
            String _passWord = "uAvb3Qey";//密码
            String _phones = "13811104406,13426494401,18610819818,13681211480";//电话号码13811104406,18618167740,13426494401,18610819818,13681211480,1069019874431
            String _smsId = "";//该批短信编号(32位UUID)，暂不用填
            String _smsContent = "测长短信，发点段子欢乐一下~昨天吃饭，看见菜单上有乱棍打死猪八戒，就问服务员是什么菜，答说豆角炒肉片。菜上来我一看是肉末炒的，就问服务员怎么回事？服务员说：估计是下手太狠了，打惨了，下次叫他们下手轻点！~下一段~用一句俗语形容国足出线。“小寡妇怀孕，多靠街坊照顾。”~下一段~一男子发消息给女孩：“你说喜欢枚瑰，我给你买1千的荷兰白雪皇后；你说喜欢香水，我给你买5千的香奈儿5号；你说喜欢戒指，我给你买1万的蒂芙尼。为什么还是对我不冷不热？”女孩淡淡地回：“你一开始就错了。”他万分错愕：“到底哪里错了？”她：“玫瑰的‘玫’。”~下一段~某女子整天以泪洗面，被评为节约用水小能手。~下一段~商场试衣间，我推门进去，见一美女正脱一半，我忙说声对不起，及时关上了门。美女瞪着我：“你先出去行吗？”";//短信内容
            String opTag = "SendSMS";//"SendSMS"发送短信,GetSMS"获取上行,"GetBanlance"查询余额,"GetReport"获取状态报告, "GetBlacklist"查询黑名单,"CheckKeyWord"检测敏感词
            String _sign = "【国家海洋预报台】";//短信签名，！仅在！发送短信时用
            String _subCode = "74431";//短信子码，接收回馈信息用
            String _sendTime = null;//DateTime.Now.ToString("yyyyMMddHHmm");//定时发送时间
            //以下是返回值
            PortMsg portMsg = new PortMsg();

            //调用
            UnicomPorts unicomports = new UnicomPorts();
            string temp = null;
            while (true)
            {
                Console.WriteLine("(/≧▽≦)/短信发送系统ヾ(≧∇≦*)ゝ");
                Console.WriteLine("输入工作类型，若为空则不变\n\"SendSMS\"发送短信,\"GetSMS\"获取上行,\"GetReport\"获取状态报告, \"GetBanlance\"查询余额, \"GetBlacklist\"查询黑名单, \"CheckKeyWord\"检测敏感词\n");
                temp = Console.ReadLine();
                if (temp.Length > 0) opTag = temp;
                if (opTag == "Exit") break;
                if (opTag == "SendSMS")
                {
                    Console.WriteLine("输入短信内容，若为空则不变");
                    temp = Console.ReadLine(); if (temp.Length > 0) _smsContent = temp;
                    Console.WriteLine("发送内容如下：\n" + _sign + _smsContent + "\n");
                    Console.WriteLine("发送号码：\n" + _phones + "\n");
                }
                portMsg = unicomports.sendPort(_account, _passWord, _phones, _smsId, _smsContent, _sign, _subCode, _sendTime, opTag);
                Console.WriteLine("反馈信息：\n" + portMsg.strMsg + "\n");
                Console.WriteLine("发送流程完毕( ^_^ )/~~拜拜" + "\n" + "---------------------------------------------------------\n");
            }
        }
    }
}
