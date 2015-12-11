using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SIT.KeShe.PC
{
    public partial class Form1 : Form
    {
        private bool stopCommd = false;
        private int FrameLength = 16;
        private byte[] headerPatten;
        private byte[] FrameData;
        private SerialPort comm = new SerialPort();//串口

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
        }
        /// <summary>
        /// 开始接受数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            //ReadAndProcess();
            timer1.Start();
        }
        /// <summary>
        /// 读数据并运行
        /// </summary>
        /// <returns></returns>
        private void ReadAndProcess()
        {
            int retCode = 0;
            //if (cmboPort.Text.Trim() == "")
            //{
            //    MessageBox.Show("请选择一个端口");
            //    return;
            //}

            stopCommd = false;
            btnStart.Enabled = false;

            //comm.PortName = cmboPort.Text;
            //comm.Open();

            //while (true)
            //{
            //    retCode = ReadLine();
            //    if (retCode > 0)
            //    {
            //        ShowMsgBox(retCode);
            //        break;
            //    }
            //    if (stopCommd)
            //    {
            //        break;
            //    }
                ProcessAFrameData();
                Application.DoEvents();
            //}
            //comm.Close();
            btnStart.Enabled = true;
        }
        /// <summary>
        /// 从串口读取一个数据帧
        /// 返回值：0：正确，aFrameData中存放读到的数据（行业编码+应用编码+应用数据类型码+应用数据）
        ///         1：找不到包头
        ///         2：包头校验错
        ///         3：数据包校验错
        ///         4：读超时
        /// </summary>
        /// <returns></returns>
        private int ReadLine()
        {
            int i, count;
            int currentChar;
            int len1, len2, cmd, checkHeader;
            int crc1, crc2;
            try
            {
                i = 0;
                count = 0;
                while (i <= 1)
                {
                    currentChar = comm.ReadByte();
                    if (currentChar == headerPatten[i])
                    {
                        i++;
                    }
                    else
                    {
                        i = 0;
                    }
                    count++;
                    if (count > 200)
                    {
                        return 1;
                    }
                }
                cmd = comm.ReadByte();
                len1 = comm.ReadByte();
                len2 = comm.ReadByte();
                checkHeader = comm.ReadByte();

                if (!(((cmd ^ len1) ^ len2) == checkHeader))
                {
                    return 2;
                }
                FrameLength = len1;
                FrameLength = FrameLength * 256 + len2;

                for (int j = 0; j < FrameLength - 1; j++)
                {
                    FrameData[j] = (byte)comm.ReadByte();
                }

                //crc校验
                crc1 = comm.ReadByte();
                crc2 = comm.ReadByte();
                if (false)
                {
                    return 3;
                }
            }
            catch (Exception ex)
            {
                return 4;
                throw;
            }
            return 0;//成功
        }
        /// <summary>
        /// 运行一帧数据
        /// </summary>
        private void ProcessAFrameData()
        {
            byte typeOfApp;
            ShowFrameData();
            typeOfApp = FrameData[2];
            switch (typeOfApp)
            {
                case 0:
                    NodeReport();//基站报告节点传感器数据
                    break;
                case 0x10:
                    LedRemoteControl();//LED远程控制实验
                    break;
                case 0x11:
                    LedRemoteControl();//LED远程控制实验
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 基站报告节点传感器数据
        /// </summary>
        private void NodeReport()
        {
            int typeOfSensor;
            typeOfSensor = FrameData[3];
            typeOfSensor = (typeOfSensor << 8) + FrameData[4];

            switch (typeOfSensor)
            {
                case 1:
                    TemperAndHumi(); //温湿度
                    break;
                case 3:
                    Light(); //光照
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 温湿度计算
        /// </summary>
        public void TemperAndHumi()
        {
            int node;
            double t, h;
            node = FrameData[7] * 256 + FrameData[8];

            t = FrameData[12] * 256 + FrameData[13];
            h = FrameData[14] * 256 + FrameData[15];

            t = -39.7 + t * 0.01;
            h = (t - 25) * (0.01 + 0.00008 * h) - 2.0468 + 0.0367 * h + (-0.0000015955 * h * h);
            ShowSensorData(1,node,new double[]{ t,h});
        }
        /// <summary>
        /// 光度计算
        /// </summary>
        private void Light()
        {
            int node;
            double l;
            node = FrameData[7] * 256 + FrameData[8];
            l = FrameData[12] * 256 + FrameData[13];
            l = 3.3 * l / 32767;
            ShowSensorData(3, node, new double[] { l });
        }
        private int Sensorcount = 0;
        private int SensortotalCount = 0;
        /// <summary>
        /// show节点数据
        /// </summary>
        /// <param name="sensor"></param>
        /// <param name="node"></param>
        /// <param name="sensorData"></param>
        private void ShowSensorData(int sensor, int node, double[] sensorData)
        {
            SendData sd = new SendData();
            StringBuilder sb = new StringBuilder();
            if (Sensorcount >= 100)
            {
                Sensorcount = 0;
                sensorDataList.Clear();
            }
            SensortotalCount++;
            sb.Clear();
            sb.Append("No:"+ SensortotalCount.ToString("0000000")+" ");
            sb.Append("节点：");
            sb.Append(string.Format("{0:D2}", node));
            StringBuilder sbb = new StringBuilder();
            sbb.Append("node="+node+"&");
            switch (sensor)
            {
                case 1:
                    sb.Append("，温度：");
                    sb.Append(""+sensorData[0]);
                    sb.Append("，湿度：");
                    sb.Append("" + sensorData[1]+" ");
                    sb.Append( DateTime.Now.ToString());

                    sbb.Append("sensor=" + sensor + "&");
                    sbb.Append("v1=" + sensorData[0] + "&");
                    sbb.Append("v2=" + sensorData[1] + "&");
                    sbb.Append("datetime=" + DateTime.Now.ToString());
                    sd.SendToWeb(sbb.ToString());
                    break;
                case 3:
                    sb.Append("，光照：");
                    sb.Append("" + sensorData[0]+" ");
                    sb.Append(DateTime.Now.ToString());

                    sbb.Append("sensor=" + sensor + "&");
                    sbb.Append("v1=" + sensorData[0] + "&");
                    sbb.Append("v2=" + 0 + "&");
                    sbb.Append("datetime=" + DateTime.Now.ToString());
                    sd.SendToWeb(sbb.ToString());
                    break;
                default:
                    break;
            }
            AppendTxtToTxtLog(sb.ToString(), sensorDataList);
            Sensorcount++;
        }
        private int Framecount = 0;
        private int FrametotalCount = 0;
        /// <summary>
        /// show节点数据包
        /// </summary>
        private void ShowFrameData()
        {
            StringBuilder sb = new StringBuilder();
            if (Framecount >= 100)
            {
                Framecount = 0;
                FrameDataList.Clear();
            }
            FrametotalCount++;
            sb.Clear();
            sb.Append("No:" + FrametotalCount.ToString("0000000") + " ");
            for (int i = 0; i < FrameLength; i++)
            {
                sb.Append(string.Format("{0:X2}",Convert.ToInt32( FrameData[i])) +" ");
            }
            AppendTxtToTxtLog(sb.ToString(),FrameDataList);
            Framecount++;
        }
        /// <summary>
        /// 文本输出函数
        /// </summary>
        /// <param name="str"></param>
        public void AppendTxtToTxtLog(string str,TextBox txtShow)
        {

            if (txtShow.InvokeRequired)
            {
                txtShow.Invoke(new Action<string>(s => {
                    txtShow.Text = string.Format("{0}\r\n{1}", s, txtShow.Text);
                }), str);

            }
            else
            {
                txtShow.Text = string.Format("{0}\r\n{1}", str, txtShow.Text);
            }

        }

        /// <summary>
        /// 控制LED灯
        /// </summary>
        private void LedRemoteControl()
        {
            throw new NotImplementedException();
        }

        
        /// <summary>
        /// 展示错误读取数据
        /// </summary>
        /// <param name="retCode"></param>
        private void ShowMsgBox(int retCode)
        {
            switch (retCode)
            {
                case 1: MessageBox.Show("找不到包头"); break;
                case 2: MessageBox.Show("包头校验错"); break;
                case 3: MessageBox.Show("数据包校验错"); break;
                case 4: MessageBox.Show("读超时"); break;
                default:
                    break;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopCommd = false;
            if (comm.IsOpen)
            {
                comm.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitComPort();
            //cmboPort.SelectedIndex = 1;
        }
        /// <summary>
        /// 设置com port
        /// </summary>
        public void InitComPort()
        {
            comm.BaudRate = 9600;
            comm.DataBits = 8;
            comm.StopBits = (StopBits)1;
            comm.Parity = Parity.None;
            comm.ReadBufferSize = 4096;
            comm.ReadTimeout = 5000;
        }
        /// <summary>
        /// 显示通信端口号
        /// </summary>
        /// <param name="comboPort"></param>
        public void ShowCommPort()
        {
            string[] portName = SerialPort.GetPortNames();
            cmboPort.Items.Clear();
            foreach (var item in portName)
            {
                cmboPort.Items.Add(item);
            }
        }

        private void cmboPort_DropDown(object sender, EventArgs e)
        {
            ShowCommPort();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stopCommd = true;
        }

        private void cmboPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmboPort.SelectedIndex+1>0)
            {
                //
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            headerPatten = new byte[] { 0x37, 0xA9 };
            FrameData = new byte[] { 0x27, 0x1, 0x0, 0x0, 0x1, 0x0, 0x2, 0x0, 0x2, 0x0, 0x0, 0x1, 0x1A, 0xE3, 0x6, 0xCB };
            ReadAndProcess();
        }
    }
}
