using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomPort
{
    class Program
    {
        static void Main(string[] args)
        {
            UnicomPort UniPort = new UnicomPort();
            UniPort.account = "dh74381";//账号
            UniPort.passWord = "uAvb3Qey";//密码
            UniPort.phones = "13811104406,18618167740";//电话号码13811104406,18618167740,13426494401,18610819818,13681211480,1069019874431
            UniPort.smsId = "";//该批短信编号(32位UUID)，暂不用填
            UniPort.smsContent = "本信息为发送系统开发项目测试短信。开发组人员刘思晗、屈远、李飞欢迎各位领导对本系统提出宝贵的指导意见！";//"测长短信，发点段子欢乐一下~昨天吃饭，看见菜单上有乱棍打死猪八戒，就问服务员是什么菜，答说豆角炒肉片。菜上来我一看是肉末炒的，就问服务员怎么回事？服务员说：估计是下手太狠了，打惨了，下次叫他们下手轻点！~下一段~用一句俗语形容国足出线。“小寡妇怀孕，多靠街坊照顾。”~下一段~一男子发消息给女孩：“你说喜欢枚瑰，我给你买1千的荷兰白雪皇后；你说喜欢香水，我给你买5千的香奈儿5号；你说喜欢戒指，我给你买1万的蒂芙尼。为什么还是对我不冷不热？”女孩淡淡地回：“你一开始就错了。”他万分错愕：“到底哪里错了？”她：“玫瑰的‘玫’。”~下一段~某女子整天以泪洗面，被评为节约用水小能手。~下一段~商场试衣间，我推门进去，见一美女正脱一半，我忙说声对不起，及时关上了门。美女瞪着我：“你先出去行吗？”";//短信内容
            //UniPort.opTag = "SendSMS";//"SendSMS"发送短信,GetSMS"获取上行,"GetBanlance"查询余额,"GetReport"获取状态报告, "GetBlacklist"查询黑名单,"CheckKeyWord"检测敏感词
            UniPort.sign = "【国家海洋预报台】";//短信签名，！仅在！发送短信时用
            UniPort.subCode = "74431";//短信子码，接收回馈信息用
            UniPort.sendTime = null;//DateTime.Now.ToString("yyyyMMddHHmm");//定时发送时间
            UniPort.vipPhones = "13811104406,18618167740";


            UniPort.returnMsg = "<?xml version='1.0' encoding='utf-8'?><response><result>0</result><desc>成功</desc><report><msgid>62d812c5660d402e909a3da7e77650c9</msgid><phone>18618167740</phone><status>2</status><desc>未知</desc><wgcode>12</wgcode><time>2016-04-11 09:54:05</time><smsCount>1</smsCount><smsIndex>1</smsIndex></report><report><msgid>27b29e9fc9f04bf3b4b56a9275f41989</msgid><phone>18618167740</phone><status>2</status><desc>未知</desc><wgcode>12</wgcode><time>2016-04-11 09:57:06</time><smsCount>1</smsCount><smsIndex>1</smsIndex></report><report><msgid>11b38ff31ca943c283fbefa8fc81f522</msgid><phone>18618167740</phone><status>2</status><desc>未知</desc><wgcode>12</wgcode><time>2016-04-11 09:57:17</time><smsCount>1</smsCount><smsIndex>1</smsIndex></report></response>";
            UniPort.returnMsg = "<?xml version='1.0' encoding='utf-8'?><response><result>0</result><desc>成功</desc></response>";
            UniPort.getReport();
            //UniPort.sendSMS();
            Console.WriteLine(UniPort.strMsg);

        }
    }
}
