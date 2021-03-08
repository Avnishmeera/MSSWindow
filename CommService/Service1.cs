using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CommService
{
    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer m_mainTimer;
        private bool m_timerTaskSuccess;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                //
                // Create and start a timer.
                //
                m_mainTimer = new System.Timers.Timer();
                m_mainTimer.Interval = 60000;   // every one min
                m_mainTimer.Elapsed += m_mainTimer_Elapsed;
                m_mainTimer.AutoReset = false;  // makes it fire only once
                m_mainTimer.Start(); // Start

                m_timerTaskSuccess = false;
            }
            catch (Exception ex)
            {
                // omitted
            }
        }

        private void FinallySendSMS(DataTable DT)
        {
            if (DT.Rows.Count == 0)
            {
                return;
            }
            int NotID;
            string SMSUserID;
            String SMSPassword;
            String SMSSenderID;
            string SMSPriority;
            string SMSType;
            string SMSText;
            string SMSContact;
            string PUristring;
            string ShopName;
            string Customername;
            foreach (DataRow item in DT.Rows)
            {
                NotID = Convert.ToInt32(item["NotID"].ToString());
                SMSUserID = item["SMSUserID"].ToString();
                SMSPassword = item["SMSPassword"].ToString();
                SMSSenderID = item["SMSSenderID"].ToString();
                SMSPriority = item["SMSPriority"].ToString();
                SMSType = item["SMSType"].ToString();
                SMSText = item["MessageText"].ToString();
                SMSContact = item["ContactNo"].ToString();
                PUristring = item["Uristring"].ToString();
                ShopName = item["ShopName"].ToString();
                Customername = item["Customername"].ToString();
                SMSText = string.Format(SMSText,  Customername,ShopName);
                SendSingleSms(NotID, SMSUserID, SMSPassword, SMSSenderID, SMSPriority, SMSType, SMSText, SMSContact, PUristring);
            }
        }
        private void SendSingleSms(int NotID, string SMSUserID, String SMSPassword, String SMSSenderID, string SMSPriority, string SMSType, string SMSText, string SMSContact, string PUristring)
        {

            string a = "user=" + SMSUserID + "";
            string b = "&pass=" + SMSPassword + "";  //password of that sms gateway
            string c = "&sender=" + SMSSenderID + "";  //sender mobile number followed by country code
            string d = "&phone=" + SMSContact + "";  //predefined method from your gateways provider
            string e = "&text=" + SMSText + ""; //your message
            string f = "&priority=" + SMSPriority + "";
            string g = "&stype=" + SMSType + "";

            WebClient client = new WebClient();

            NameValueCollection sendNameValuCollection = new NameValueCollection();

            //"http://bhashsms.com/api/sendmsg.php?user=success&pass=********&sender=Sender ID&phone=Mobile No&text=Test SMS&priority=Priority&stype=smstype"

            string uriString = PUristring + a + b + c + d + e + f + g;

            //string uriString = "http://nimbusit.co.in/api/swsendSingle.asp?" + a + b + c + d + e;
            try
            {


                //sendNameValuCollection.Add("username", "t1vikashtiwari");
                //sendNameValuCollection.Add("password", "100795532");
                //sendNameValuCollection.Add("sender", "Meerat");
                //sendNameValuCollection.Add("sendto", "7838633460");

                sendNameValuCollection.Add("user", SMSUserID);
                sendNameValuCollection.Add("pass", SMSPassword);
                sendNameValuCollection.Add("sender", SMSSenderID);
                sendNameValuCollection.Add("phone", SMSContact);
                sendNameValuCollection.Add("text", SMSText);

                byte[] responseArrey = client.UploadValues(uriString, "POST", sendNameValuCollection);

                string Resp = Encoding.ASCII.GetString(responseArrey);

                sendNameValuCollection.Clear();
                SMSTrans.UpdateSMSSend(NotID, true, false, string.Empty);

            }

            catch (WebException we)
            {

                string responceerror = "Network Error: " + we.Message + "\nStatus Code: " + we.Status;
                SMSTrans.UpdateSMSSend(NotID, false, true, responceerror);
            }

            catch (UriFormatException ufe)
            {

                string sucessError = "URI Format Error: " + ufe.Message;
                SMSTrans.UpdateSMSSend(NotID, false, true, sucessError);

            }

        }
        void m_mainTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                SMS SB = new SMS();
                DataTable DT = new DataTable();
                DT = SMSTrans.InsertSmsNotification();
                if (DT.Rows.Count > 0)
                    FinallySendSMS(DT);

                m_timerTaskSuccess = true;
            }
            catch (Exception ex)
            {
                m_timerTaskSuccess = false;
            }
            finally
            {
                if (m_timerTaskSuccess)
                {
                    m_mainTimer.Start();
                }
            }
        }

        //void timer1_Tick(object sender, EventArgs e)
        //{
        //    SMS SB = new SMS();
        //    SB.ShopID = 5;
        //    SB.SMSTEXT = "Hi customer";
        //    SMSTrans.InsertSmsNotification(SB);

        //}

        protected override void OnStop()
        {
            try
            {
                // Service stopped. Also stop the timer.
                m_mainTimer.Stop();
                m_mainTimer.Dispose();
                m_mainTimer = null;
            }
            catch (Exception ex)
            {
                // omitted
            }
        }
    }
}
