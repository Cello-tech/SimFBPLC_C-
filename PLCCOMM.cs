using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;

namespace SimFBPLC
{
    public class Class_SetTimer
    {
        public System.Windows.Forms.Timer DelayTimer;
        private int TickCount;
        private bool TickCountEnabled;
        private int Control_State;
        private bool Sstatus;
        private bool CycleCount;

        public Class_SetTimer()
        {
            DelayTimer = new System.Windows.Forms.Timer();
            DelayTimer.Interval = 1000;
            DelayTimer.Enabled = true;

            CycleCount = false;                  // 預設不循環計時
            DelayTimer.Tick += TimerTick;
            TickCount = 0;

        }
        private void TimerTick(object sender, EventArgs e)
        {
            if (TickCountEnabled)
            {
                TickCount = TickCount - 1;
                if (TickCount <= 0)
                {
                    TickCount = 0;
                    TickCountEnabled = false;
                }
            }
        }
        public void SetTimerWrodCompToBit(bool On_Cond, int src, int dest, string ope, ref bool target)
        {
            //target = false;
            
            switch (Control_State)
            {
                case 0:
                    {
                        if (On_Cond)
                        {
                            DelayTimer.Enabled = true;
                            Control_State = 1;
                        }
                        break;
                    }

                case 1:
                    {
                        if (On_Cond)
                        {
                            switch (ope)
                            {
                                case "=":
                                    {
                                        target = (src == dest);
                                        break;
                                    }

                                case ">":
                                    {
                                        target = (src > dest);
                                        break;
                                    }

                                case ">=":
                                    {
                                        target = (src >= dest);
                                        break;
                                    }

                                case "<":
                                    {
                                        target = (src < dest);
                                        break;
                                    }

                                case "<=":
                                    {
                                        target = (src <= dest);
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            DelayTimer.Enabled = false;
                            Control_State = 0;
                        }

                        break;
                    }
            }
            //return target;
        }


        public void SetTimerBit(bool On_cond, bool src_Cond, ref bool dest_Cond, bool set_cond, int TimeUp, bool pulse = true)
        {
            //Debug.Print("Control_State=" + Control_State);
            switch (Control_State)
            {
                case 0:
                    {
                        if (On_cond)
                        {
                            DelayTimer.Enabled = true;
                            Control_State = 1;
                        }

                        break;
                    }

                case 1:
                    {
                        if (On_cond)
                        {
                            if (src_Cond & TimeUp > 0)
                            {
                                TickCount = TimeUp;
                                TickCountEnabled = true; //開始計時
                                Control_State = 2;
                            }
                        }
                        else
                        {
                            DelayTimer.Enabled = false;
                            Control_State = 0;
                        }

                        break;
                    }

                case 2:
                    {
                        if (On_cond)
                        {
                            if (src_Cond)
                            {
                                if (TickCountEnabled == false) //計時完畢
                                {
                                    dest_Cond = set_cond;
                                    Control_State = 3;
                                }
                            }
                            else
                                Control_State = 1;
                        }
                        else
                        {
                            DelayTimer.Enabled = false;
                            Control_State = 0;
                        }

                        break;
                    }

                case 3:
                    {
                        if (On_cond)
                        {
                            if (src_Cond)
                            {
                                if (pulse == false)
                                {
                                    if (TickCountEnabled == false)
                                    {
                                        dest_Cond = set_cond;
                                        Control_State = 1;
                                    }
                                }
                            }
                            else
                            {
                                DelayTimer.Enabled = false;
                                Control_State = 0;
                            }
                        }
                        else
                        {
                            DelayTimer.Enabled = false;
                            Control_State = 0;
                        }

                        break;
                    }
            }
            
            //Sstatus = dest_Cond;
            //return Sstatus;
        }
        public int SetTimerBit2Word(bool On_Cond, bool src, ref int dest, int target, int iStep, int TimeUp, bool pulse = true)
        {
            //dest = 0;
            switch (Control_State)
            {
                case 0:
                    {
                        if (On_Cond)
                        {
                            DelayTimer.Enabled = true;
                            Control_State = 1;
                        }

                        break;
                    }

                case 1:
                    {
                        if (On_Cond)
                        {
                            if (src)
                            {
                                if (dest < target)
                                {
                                    TickCount = TimeUp;
                                    TickCountEnabled = true;
                                    Control_State = 2;
                                }
                                if (dest > target)
                                {
                                    TickCount = TimeUp;
                                    TickCountEnabled = true;
                                    Control_State = 3;
                                }
                            }
                        }
                        else
                        {
                            DelayTimer.Enabled = false;
                            Control_State = 0;
                        }

                        break;
                    }

                case 2:
                    {
                        if (On_Cond)
                        {
                            if (src)
                            {
                                if (dest < target)
                                {
                                    if (TickCountEnabled == false)
                                    {
                                        TickCount = TimeUp;
                                        TickCountEnabled = true;
                                        dest += iStep;
                                    }
                                    if (dest == target)
                                    {
                                        if (pulse == false)
                                            Control_State = 1;
                                        else
                                            Control_State = 4;
                                    }
                                }
                                else
                                {
                                    dest = target;
                                    if (pulse == false)
                                        Control_State = 1;
                                    else
                                        Control_State = 4;
                                }
                            }
                            else
                            {
                                TickCountEnabled = false;
                                Control_State = 0;
                            }
                        }
                        else
                        {
                            DelayTimer.Enabled = false;
                            Control_State = 0;
                        }

                        break;
                    }

                case 3:
                    {
                        if (On_Cond)
                        {
                            if (src)
                            {
                                if (dest > target)
                                {
                                    if (TickCountEnabled == false)
                                    {
                                        TickCount = TimeUp;
                                        TickCountEnabled = true;
                                        dest -= iStep;
                                    }
                                    if (dest == target)
                                    {
                                        if (pulse == false)
                                            Control_State = 1;
                                        else
                                            Control_State = 4;
                                    }
                                }
                                else
                                {
                                    dest = target;
                                    if (pulse == false)
                                        Control_State = 1;
                                    else
                                        Control_State = 4;
                                }
                            }
                            else
                            {
                                TickCountEnabled = false;
                                Control_State = 0;
                            }
                        }
                        else
                        {
                            DelayTimer.Enabled = false;
                            Control_State = 0;
                        }

                        break;
                    }

                case 4:
                    {
                        if (On_Cond)
                        {
                            if (src)
                            {
                                if (dest != target)
                                    Control_State = 1;
                            }
                            else
                            {
                                DelayTimer.Enabled = false;
                                Control_State = 0;
                            }
                        }
                        else
                        {
                            DelayTimer.Enabled = false;
                            Control_State = 0;
                        }

                        break;
                    }
            }
            return dest;
        }

    }

    public class SIM_PLC
    {
        public event DataReceivedEventHandler DataReceived;//宣告新event 傳出給給主程式
        public delegate void DataReceivedEventHandler(string Data);//宣告委派傳出參數
        string Rx_Buffer = "";
        public SerialPort PLC_COM;

        public SIM_PLC()
        {
            PLC_COM = new System.IO.Ports.SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            PLC_COM.DataReceived += new SerialDataReceivedEventHandler(PLC_ONComm);//宣告原來 RS232的事件 PLC_ONComm
        }

        public void SetCommSetting(string comport, string setting)
        {
            string[] comset;
            string sstr;
            //var STX = System.Convert.ToChar(2);
            //var ETX = System.ETX;
            //string READ_BIT = "44";
            //string WRITE_BIT = "45";
            //string READ_WORD = "46";
            //string WRITE_WORD = "47";
            //string PLC_ON = "40";
            //string SLAVE_NO = "01";
            //string Rx_Buffer = "";
            comset = setting.Split(',');
            PLC_COM.PortName = comport;
            PLC_COM.BaudRate = Convert.ToInt32(comset[0]);
            sstr = comset[1].ToUpper();
            switch (sstr)
            {
                case "N":
                    {
                        PLC_COM.Parity = System.IO.Ports.Parity.None;
                        break;
                    }

                case "E":
                    {
                        PLC_COM.Parity = System.IO.Ports.Parity.Even;
                        break;
                    }

                case "O":
                    {
                        PLC_COM.Parity = System.IO.Ports.Parity.Odd;
                        break;
                    }
            }
            PLC_COM.DataBits = Convert.ToInt32(comset[2]);
            PLC_COM.StopBits = System.IO.Ports.StopBits.One; // IO.Ports.StopBits.One
            PLC_COM.Handshake = System.IO.Ports.Handshake.None;
            PLC_COM.RtsEnable = false;
            PLC_COM.DtrEnable = false;
            PLC_COM.ReceivedBytesThreshold = 1;
            PLC_COM.Encoding = System.Text.Encoding.ASCII;
            Rx_Buffer = "";
        }

        // PORT 接收事件
        public void PLC_ONComm(object sender, SerialDataReceivedEventArgs e)
        {
            string rstr;

            Rx_Buffer = Rx_Buffer + PLC_COM.ReadExisting();

            if (Rx_Buffer.Contains("\u0003"))
            {
                rstr = Rx_Buffer;
                Rx_Buffer = "";
                DataReceived?.Invoke(rstr);
            }

        }
        public void Port(string port)
        {
            PLC_COM.PortName = port;
        }

        public void Open()
        {
            if (PLC_COM.IsOpen)
                PLC_COM.Close();
            else
            {
                try
                {

                    PLC_COM.Open();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }
        public void Close()
        {
            PLC_COM.Close();
        }
        public void Send(string data)
        {
            PLC_COM.Write(data + "/r");
        }

    }

}

