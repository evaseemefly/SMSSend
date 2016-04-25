using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using SMSCloudWebserviceSend.SendSMS;
using System.Web;

namespace SMSCloudWebserviceSend
{
    public partial class FrmWebserviceSend : Form
    {
        SmsService4XMLClient sendSMSClient = null;
        protected String serverURL = null;
        protected String opTag = "SendSMS";
        public FrmWebserviceSend()
        {
            InitializeComponent();
        }

        private void btnInvoke_Click(object sender, EventArgs e)
        {
            btnInvoke.Enabled = false;
            btnExit.Enabled = false;
            if (checkInput())
            {
                Encoding _encodingUTF8 = Encoding.UTF8;
                String _serverURL = txtServerURL.Text.Trim();
                String _data = null;
                String _account = txtUserName.Text.Trim();
                String _passWord = md5(txtPassWord.Text.Trim());
                String _phones = txtPhone.Text.Trim();
                String _smsId = txtSmsId.Text.Trim();
                String _smsContent = txtSMSContent.Text.Trim();
                Boolean _encodeFlag = false;
                Boolean _appendEngTag = false;
                if (_smsContent.IndexOf("<") > -1 || _smsContent.IndexOf("<") > -1
                    || _smsContent.IndexOf("&") > -1 || _smsContent.IndexOf("'") > -1
                    || _smsContent.IndexOf("\"") > -1)
                {
                    _encodeFlag = true;
                    _smsContent = HttpUtility.UrlEncode(_smsContent, _encodingUTF8);
                }
                switch (opTag)
                {
                    case "SendSMS"://发送短信
                        string _sign = this.txtSign.Text.Trim();
                        string _subCode = this.txtSubCode.Text.Trim();
                        string _sendTime = this.txtSendTime.Text.Trim();
                        _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                                    + "<message>"
                                        + "<account>" + _account + "</account>"
                                        + "<password>" + _passWord + "</password>"
                                        + "<msgid>" + _smsId + "</msgid>"
                                        + "<phones>" + _phones + "</phones>"
                                        + "<content>" + _smsContent + "</content>"
                                        + "<sign>" + _sign + "</sign>"
                                        + "<subcode>" + _subCode + "</subcode>"
                                        + "<sendtime>" + _sendTime + "</sendtime>";
                        _appendEngTag = true;
                        break;
                    case "GetSMS"://获取上行
                    case "GetBanlance"://查询余额
                        _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                            + "<message>"
                                + "<account>" + _account + "</account>"
                                + "<password>" + _passWord + "</password>"
                            + "</message>";
                        _encodeFlag = false;
                        break;
                    case "GetReport"://获取状态报告
                        _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                            + "<message>"
                                + "<account>" + _account + "</account>"
                                + "<password>" + _passWord + "</password>"
                                + "<msgid>" + _smsId + "</msgid>"
                                + "<phone>" + _phones + "</phone>"
                            + "</message>";
                        _encodeFlag = false;
                        break;
                    case "GetBlacklist"://查询黑名单
                        _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                            + "<message>"
                                + "<account>" + _account + "</account>"
                                + "<password>" + _passWord + "</password>"
                                    + "<phones>"
                                    + _phones
                                    + "</phones>"
                            + "</message>";
                        _encodeFlag = false;
                        break;
                    case "CheckKeyWord"://检测敏感词
                        _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                            + "<message>"
                                + "<account>" + _account + "</account>"
                                + "<password>" + _passWord + "</password>"
                                + "<content>"
                                + _smsContent
                                + "</content>";
                        _appendEngTag = true;
                        break;
                    default:
                        break;
                }
                if (_encodeFlag)
                {
                    _data += "<encryptionType>URL_UTF8</encryptionType></message>";
                }
                else if (_appendEngTag)
                {
                    _data += "</message>";
                }

                if (!_serverURL.Equals(serverURL))
                {
                    try
                    {
                        sendSMSClient = new SmsService4XMLClient("SmsService4XMLImplPort", _serverURL);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    serverURL = _serverURL;
                }
                webserviceInvoke(_data);
            }
            btnInvoke.Enabled = true;
            btnExit.Enabled = true;
        }

        private void rdo_Click(object sender, EventArgs e)
        {
            RadioButton _rdo = sender as RadioButton;
            opTag = _rdo.Tag.ToString();
            String _str = txtServerURL.Text.Trim().ToString();

            switch (opTag)
            {
                case "SendSMS"://发送短信
                    txtPhone.Enabled = true;
                    txtSmsId.Enabled = true;
                    txtSMSContent.Enabled = true;
                    txtSign.Enabled = true;
                    txtSubCode.Enabled = true;
                    txtSendTime.Enabled = true;
                    if ("".Equals(txtSmsId.Text.Trim()))
                    {
                        generalNewData();
                    }
                    break;
                case "GetSMS"://获取上行
                    txtPhone.Enabled = false;
                    txtSmsId.Enabled = false;
                    txtSMSContent.Enabled = false;
                    txtSign.Enabled = false;
                    txtSubCode.Enabled = false;
                    txtSendTime.Enabled = false;
                    break;
                case "GetBanlance"://查询余额
                    txtPhone.Enabled = false;
                    txtSmsId.Enabled = false;
                    txtSMSContent.Enabled = false;
                    txtSign.Enabled = false;
                    txtSubCode.Enabled = false;
                    txtSendTime.Enabled = false;
                    break;
                case "GetReport"://获取状态报告
                    txtPhone.Enabled = true;
                    txtSmsId.Enabled = true;
                    txtSMSContent.Enabled = false;
                    txtSign.Enabled = false;
                    txtSubCode.Enabled = false;
                    txtSendTime.Enabled = false;
                    break;
                case "GetBlacklist"://查询黑名单
                    txtPhone.Enabled = true;
                    txtSmsId.Enabled = false;
                    txtSMSContent.Enabled = false;
                    txtSign.Enabled = false;
                    txtSubCode.Enabled = false;
                    txtSendTime.Enabled = false;
                    break;
                case "CheckKeyWord"://检测敏感词
                    txtPhone.Enabled = false;
                    txtSmsId.Enabled = false;
                    txtSMSContent.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private Boolean webserviceInvoke(string iMessage)
        {
            String _res = null;
            try
            {
                switch (opTag)
                {
                    case "SendSMS"://发送短信
                        _res = sendSMSClient.submit(iMessage);
                        break;
                    case "GetSMS"://获取上行
                        _res = sendSMSClient.deliver(iMessage);
                        break;
                    case "GetBanlance"://查询余额
                        _res = sendSMSClient.balance(iMessage);
                        break;
                    case "GetReport"://获取状态报告
                        _res = sendSMSClient.report(iMessage);
                        break;
                    case "GetBlacklist"://查询黑名单
                        _res = sendSMSClient.blackListCheck(iMessage);
                        break;
                    case "CheckKeyWord"://检测敏感词
                        _res = sendSMSClient.keywordcheck(iMessage);
                        break;
                    default:
                        break;
                }
               
                txtResponse.Text = _res;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool checkInput()
        {
            if ("".Equals(txtServerURL.Text.Trim()))
            {
                txtServerURL.Focus();
                MessageBox.Show("请输入服务地址！", "输入提示");
                return false;
            }

            if ("".Equals(txtUserName.Text.Trim()))
            {
                txtUserName.Focus();
                MessageBox.Show("请输入账号！", "输入提示");
                return false;
            }

            if ("".Equals(txtPassWord.Text.Trim()))
            {
                txtPassWord.Focus();
                MessageBox.Show("请输入密码！", "输入提示");
                return false;
            }

            return true;
        }

        private void generalNewData()
        {
            if (rdoSendSMS.Checked)
            {
                txtSmsId.Text = Guid.NewGuid().ToString().Replace("-", "");
                txtSendTime.Text = DateTime.Now.ToString("yyyyMMddHHmm");
            }
        }

        //MD5 32位小写加密
        private static string md5(string str)
        {
            byte[] result = Encoding.Default.GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            String md = BitConverter.ToString(output).Replace("-", "");
            return md.ToLower();
        }

        private void FrmWebserviceSend_Load(object sender, EventArgs e)
        {
            generalNewData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult _dr = MessageBox.Show("确定退出？", "操作提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (_dr == DialogResult.Yes)
            {
                this.Close();
                this.Dispose();
                Application.Exit();
            }
        }
    }
}
