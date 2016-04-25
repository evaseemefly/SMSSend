using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SMSCloudHttpSend
{
    public partial class FrmHttpSend : Form
    {
        protected String opTag = "SendSMS";
        public FrmHttpSend()
        {
            InitializeComponent();
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

        private void btnInvoke_Click(object sender, EventArgs e)
        {
            btnInvoke.Enabled = false;
            btnExit.Enabled = false;
            if (checkInput())
            {
                String _serverURL = txtServerURL.Text.Trim();
                String _data = null;
                String _account = txtUserName.Text.Trim();
                String _passWord = md5(txtPassWord.Text.Trim());
                String _phones = txtPhone.Text.Trim();
                String _smsId = txtSmsId.Text.Trim();
                String _smsContent = txtSMSContent.Text.Trim();
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
                                        + "<sendtime>" + _sendTime + "</sendtime>"
                                    + "</message>";
                        break;
                    case "GetSMS"://获取上行
                    case "GetBanlance"://查询余额
                        _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                            + "<message>"
                                + "<account>" + _account + "</account>"
                                + "<password>" + _passWord + "</password>"
                            + "</message>";
                        break;
                    case "GetReport"://获取状态报告
                        _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                            + "<message>"
                                + "<account>" + _account + "</account>"
                                + "<password>" + _passWord + "</password>"
                                + "<msgid>" + _smsId + "</msgid>"
                                + "<phone>" + _phones + "</phone>"
                            + "</message>";
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
                        break;
                    case "CheckKeyWord"://检测敏感词
                        _data = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                            + "<message>"
                                + "<account>" + _account + "</account>"
                                + "<password>" + _passWord + "</password>"
                                + "<content>"
                                + _smsContent
                                + "</content>"
                            + "</message>";
                        break;
                    default:
                        break;
                }
                httpInvoke(_serverURL, _data);
            }
            btnInvoke.Enabled = true;
            btnExit.Enabled = true;
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

        private void rdo_Click(object sender, EventArgs e)
        {
            RadioButton _rdo = sender as RadioButton;
            opTag = _rdo.Tag.ToString();
            String _str = txtServerURL.Text.Trim().ToString();
            Boolean _isBlank = "".Equals(_str);

            int _idxHttp = -1;
            if (_str.Length > 7)
            {
                _idxHttp = _str.IndexOf("/http/", 7);
            }

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
                    if (!_isBlank && _idxHttp > -1)
                    {
                        txtServerURL.Text = _str.Substring(0, _str.IndexOf("/http/", 7)) + "/http/sms/Submit";
                    }
                    else
                    {
                        txtServerURL.Text = "http://wt.3tong.net/http/sms/Submit";
                    }
                    break;
                case "GetSMS"://获取上行
                    txtPhone.Enabled = false;
                    txtSmsId.Enabled = false;
                    txtSMSContent.Enabled = false;
                    txtSign.Enabled = false;
                    txtSubCode.Enabled = false;
                    txtSendTime.Enabled = false;
                    if (!_isBlank && _idxHttp > -1)
                    {
                        txtServerURL.Text = _str.Substring(0, _str.IndexOf("/http/", 7)) + "/http/sms/Deliver";
                    }
                    else
                    {
                        txtServerURL.Text = "http://wt.3tong.net/http/sms/Deliver";
                    }
                    break;
                case "GetBanlance"://查询余额
                    txtPhone.Enabled = false;
                    txtSmsId.Enabled = false;
                    txtSMSContent.Enabled = false;
                    txtSign.Enabled = false;
                    txtSubCode.Enabled = false;
                    txtSendTime.Enabled = false;

                    if (!_isBlank && _idxHttp > -1)
                    {
                        txtServerURL.Text = _str.Substring(0, _str.IndexOf("/http/", 7)) + "/http/sms/Balance";
                    }
                    else
                    {
                        txtServerURL.Text = "http://wt.3tong.net/http/sms/Balance";
                    }
                    break;
                case "GetReport"://获取状态报告
                    txtPhone.Enabled = true;
                    txtSmsId.Enabled = true;
                    txtSMSContent.Enabled = false;
                    txtSign.Enabled = false;
                    txtSubCode.Enabled = false;
                    txtSendTime.Enabled = false;

                    if (!_isBlank && _idxHttp > -1)
                    {
                        txtServerURL.Text = _str.Substring(0, _str.IndexOf("/http/", 7)) + "/http/sms/Report";
                    }
                    else
                    {
                        txtServerURL.Text = "http://wt.3tong.net/http/sms/Report";
                    }
                    break;
                case "GetBlacklist"://查询黑名单
                    txtPhone.Enabled = true;
                    txtSmsId.Enabled = false;
                    txtSMSContent.Enabled = false;
                    txtSign.Enabled = false;
                    txtSubCode.Enabled = false;
                    txtSendTime.Enabled = false;

                    if (!_isBlank && _idxHttp > -1)
                    {
                        txtServerURL.Text = _str.Substring(0, _str.IndexOf("/http/", 7)) + "/http/sms/BlackListCheck";
                    }
                    else
                    {
                        txtServerURL.Text = "http://wt.3tong.net/http/sms/BlackListCheck";
                    }
                    break;
                case "CheckKeyWord"://检测敏感词
                    txtPhone.Enabled = false;
                    txtSmsId.Enabled = false;
                    txtSMSContent.Enabled = true;

                    if (!_isBlank && _idxHttp > -1)
                    {
                        txtServerURL.Text = _str.Substring(0, _str.IndexOf("/http/", 7)) + "/http/sms/KeywordCheck";
                    }
                    else
                    {
                        txtServerURL.Text = "http://wt.3tong.net/http/sms/KeywordCheck";
                    }
                    break;
                default:
                    break;
            }
        }

        private Boolean httpInvoke(String iServerURL, String iMessage)
        {
            try
            {
                CTCWebClient _webClient = new CTCWebClient();
                NameValueCollection _postValues = new NameValueCollection();
                _postValues.Add("message", iMessage);
                byte[] _responseArray = _webClient.UploadValues(iServerURL, _postValues);
                //向服务器发送POST数据
                txtResponse.Text = Encoding.UTF8.GetString(_responseArray);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "调用异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (rdoSendSMS.Checked)
            {
               generalNewData();
            }
           
            return true;
        }

        private bool postMethodConnServer(String iServerURL, String iPostData)
        {
            byte[] _buffer = Encoding.GetEncoding("utf-8").GetBytes(iPostData);
            HttpWebRequest _req = (HttpWebRequest)WebRequest.Create(iServerURL);
            _req.Method = "Post";
            _req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            _req.ContentLength = _buffer.Length;
            Stream _stream = null;
            Stream _resStream = null;
            StreamReader _resSR = null;
            try
            {
                _stream = _req.GetRequestStream();
                _stream.Write(_buffer, 0, _buffer.Length);
                _stream.Flush();
                HttpWebResponse _res = (HttpWebResponse)_req.GetResponse();

                //获取响应
                _resStream = _res.GetResponseStream();
                _resSR = new StreamReader(_resStream, Encoding.GetEncoding("utf-8"));
                txtResponse.Text = _resSR.ReadToEnd();
                //MessageBox.Show(_resSR.ReadToEnd());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "调用异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (_stream != null)
                {
                    _stream.Close();
                }
                if (_resSR != null)
                {
                    _resSR.Close();
                }
                if (_resStream != null)
                {
                    _resStream.Close();
                }
            }
            return true;
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

        private void frmHttpSend_Load(object sender, EventArgs e)
        {
            generalNewData();
        }

        private void generalNewData()
        {
            if (rdoSendSMS.Checked)
            {
                txtSmsId.Text = Guid.NewGuid().ToString().Replace("-", "");
                txtSendTime.Text = DateTime.Now.ToString("yyyyMMddHHmm");
            }
        }
    }
}
