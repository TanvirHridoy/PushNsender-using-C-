using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PushNsender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initFirebase();
        }

        private void initFirebase()
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential=GoogleCredential.FromFile("Cred.json")
            }); ;
            var m = FirebaseMessaging.DefaultInstance;
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var reg = "eay7rU79RVuWHt093sM1MY:APA91bGe0Y0AysRsS3rA8AiKKarj8zAxpeah8V8X3ubiNUYwf-rCo5-UiGgRmanJGlG5YEJAJ9JtASZS7rQoqOzzc8QDK4U9u5mW9pbZ91MQvuq0_YXVzkWsHObrlalmCS4_9YxBs_01";
            var message = new FirebaseAdmin.Messaging.Message()
            {
                Data= new Dictionary<string, string>()
                {
                    { "myData", "1337" },
                },
                Token=reg,
                Notification=new Notification()
                {
                    Title="testing By hridoy C#",
                    Body="hey There"
                 }
            };

            var res =  FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
            MessageBox.Show(res);
        }
    }
}
