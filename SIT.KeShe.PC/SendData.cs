using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.IO;

namespace SIT.KeShe.PC
{
    public class SendData 
    {
        public void SendToWeb(string s)
        {
            WebClient myClient = new WebClient();
            Stream response = myClient.OpenRead("http://192.168.0.107:8312/SendDataP.ashx?"+s);
            // The stream data is used here.
            response.Close();
        }
    }
}
