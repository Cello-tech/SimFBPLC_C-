using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;

namespace SimFBPLC
{
    public partial class Form1 : Form
    {
        public static Thread ProcessThread;
        public Button[] X_Status = new Button[1001];
        public Button[] Y_Status = new Button[1001];
        public Button[] M_Status = new Button[1001];
        public TextBox[] R_Write = new TextBox[1001];// show在程式中的Textbox
        public TextBox[] R_Read = new TextBox[1001]; // 位址
        public TextBox X_TEXT;
        public TextBox Y_TEXT;
        public TextBox M_TEXT;
        public TextBox RR_TEXT;
        public TextBox RW_TEXT;
        public int CmdDelay;

        public string X_String;
        public string Y_String;
        public string M_String;
        public string RR_String;
        public string RW_String;
        public string Output_String;

        public bool[] X_Bit = new bool[1000];
        public bool[] X_Bit_old = new bool[1000];
        public bool[] Y_Bit = new bool[1000];
        public bool[] Y_Bit_old = new bool[1000];
        public bool[] M_Bit = new bool[10000];
        public bool[] M_Bit_old = new bool[10000];
        public int[] RR_Word = new int[10000];
        public int[] RR_Word_old = new int[10000];
        public int[] RW_Word = new int[10000];
        public int[] RW_Word_old = new int[10000];
        public int[] RW_Word_Writed = new int[10000];
        public int[] RW_Word_Writed_old = new int[10000];
        public int[] RR_Word_Writed = new int[10000];
        public int[] RR_Word_Writed_old = new int[10000];
        public int[] DD_Word = new int[10000];
        public int[] DD_Word_old = new int[10000];

        public int index;
        public bool FirstFlag = false;
        public string sComport, sCommSetting;
        public string FormCaption;
        public string[] X_Name = new string[1000], Y_Name = new string[1000], M_Name = new string[1000], RR_Name = new string[10000], RW_Name = new string[10000];
        public bool MtoY_Flag, bTopmost;
        public char STX = System.Convert.ToChar(2);
        public char ETX = System.Convert.ToChar(3);
        public int X_Page;
        public int Y_Page;
        public int M_Page;
        public int RR_Page;
        public int RW_Page;
        string INIpath = "";
        private string SecName = "PLCLINK";
        private string IniFile = Application.StartupPath + @"\PLCLINK.INI";
        public string PLC_IP = "127.0.0.1";
        public int PLC_INPORT = 8081;
        public int PLC_OUTPORT = 8080;
        public string PLC_CrystalFailX = "X0013";
        public string PLC_DepSensor2X = "X0014";
        public string PLC_DepCompleteX = "X0015";
        public string PLC_DepSHX = "X0016";
        public string PLC_PockInpositionY = "M0035";
        public string PLC_PowerOutR = "R1165";

        public string ActionReadFileName;
        public string ActionWriteFileName;

        public bool PLC_DiCrystalFail;
        public bool PLC_DiDepSensor2;
        public bool PLC_DiDepCompelete;
        public bool PLC_DiDepSH;
        public bool PLC_DoPockInposition;

        public Stopwatch[] WDog = new Stopwatch[10];
        public bool ActionFlag;
        public int delay = 0;
        public bool threadStop = false;
        //public bool threadStop = false;
        System.Timers.Timer aa = new System.Timers.Timer();
        public SAction[] CAction = new SAction[301];
        public ManyR[] manyR = new ManyR[30];

        public Class_SetTimer[] CSetTimer = new Class_SetTimer[301];
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        CUDPServer UdpServer = new CUDPServer();
        public SIM_PLC simPLC = new SIM_PLC();
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
                WDog[i] = new Stopwatch();
            for (int i = 0; i < 30; i++)
            {
                manyR[i] = new ManyR();
            }
        }
        public class ManyR
        {
            public string R_ch;
            public string R_Value;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (UdpServer != null)
            {
                UdpServer.UPDDataReceived += UDPReceived;
            }
            if (simPLC != null)
            {
                simPLC.DataReceived += PLC_ONComm;
            }


            CheckForIllegalCrossThreadCalls = false;
            int i, j, k;
            ReadPLCLinkData();
            WritePLCLinkData();
            txtPLCLinkIP.Text = PLC_IP;
            txtLinkInPort.Text = PLC_INPORT.ToString();
            txtLinkOutPort.Text = PLC_OUTPORT.ToString();

            txtCrystalFailX.Text = PLC_CrystalFailX;
            txtDepSensor2lX.Text = PLC_DepSensor2X;
            txtDepCompleteX.Text = PLC_DepCompleteX;
            txtDepSHX.Text = PLC_DepSHX;

            txtPockInpositionY.Text = PLC_PockInpositionY;
            txtPowerOutR.Text = PLC_PowerOutR;
            UdpServer.StartServer(PLC_INPORT);//IP

            j = 0;
            k = 0;
            Form.CheckForIllegalCrossThreadCalls = false;
            // Me.Width = 20 * 36
            for (i = 0; i <= 95; i++)
            {
                X_Status[i] = new Button();
                X_Status[i].TabIndex = i;
                SetUpBtnObject(ref X_Status[i], "X" + i.ToString("D2"), "X" + i.ToString("D2"), j * 60, k * 25, 58, 24, Color.Red);
                X_Status[i].Click += X_Status_Click;
                X_Status[i].MouseMove += ShowXName;
                tabPageXInput.Controls.Add(X_Status[i]);
                j = j + 1;
                if (j >= 8)
                {
                    j = 0;
                    k = k + 1;
                }
                M_Bit[i] = false;
                X_Bit[i] = false;
                Y_Bit[i] = false;
            }
            j = 0;
            k = 0;
            for (i = 0; i <= 191; i++)
            {
                Y_Status[i] = new Button();
                SetUpBtnObject(ref Y_Status[i], "Y" + i.ToString("D2"), "Y" + i.ToString("D2"), j * 60, k * 25, 58, 24, Color.Red);
                Y_Status[i].Click += Y_Status_Click;
                Y_Status[i].MouseMove += ShowYName;
                // AddHandler Y_Status[i].MouseEnter, AddressOf ShowToolTip
                tabPageYOutput.Controls.Add(Y_Status[i]);

                M_Status[i] = new Button();
                SetUpBtnObject(ref M_Status[i], "M" + i.ToString("D2"), "M" + i.ToString("D2"), j * 60, k * 25, 58, 24, Color.Red);
                M_Status[i].Click += M_Status_Click;
                M_Status[i].MouseMove += ShowMName;
                // AddHandler M_Status[i].MouseEnter, AddressOf ShowToolTip
                tabPageMOutput.Controls.Add(M_Status[i]);

                j = j + 1;
                if (j >= 8)
                {
                    j = 0;
                    k = k + 1;
                }
                M_Bit[i] = false;
            }
            j = 0;
            k = 0;
            for (i = 0; i <= 191; i++)
            {
                R_Read[i] = new TextBox();
                SetUpTxtObject(ref R_Read[i], "txtRR" + i.ToString("D2"), "0", j * 50, k * 25, 58, 24, Color.LightGreen);
                R_Read[i].KeyPress += R_Read_KeyPress;
                R_Read[i].MouseMove += ShowRRName;
                // AddHandler R_Read[i].MouseEnter, AddressOf ShowToolTip
                tabPageRRead.Controls.Add(R_Read[i]);

                R_Write[i] = new TextBox();
                SetUpTxtObject(ref R_Write[i], "txtRW" + i.ToString("D2"), "0", j * 50, k * 25, 58, 24, Color.AliceBlue);
                R_Write[i].KeyPress += R_Write_KeyPress;
                R_Write[i].MouseMove += ShowRWName;

                // AddHandler R_Write[i].MouseEnter, AddressOf ShowToolTip
                tabPageRWrite.Controls.Add(R_Write[i]);
                j = j + 1;
                if (j >= 10)
                {
                    j = 0;
                    k = k + 1;
                }
                RR_Word[i] = 0;
                RW_Word[i] = 0;
            }

            for (i = 0; i <= 31; i++)
                cmoCommPort.Items.Add("COM" + (i + 1).ToString());
            cmoCommPort.SelectedIndex = 0;
            simPLC.SetCommSetting(cmoCommPort.SelectedItem.ToString(), "57600,e,7,1");

            INIpath = System.IO.Directory.GetParent(System.IO.Path.GetDirectoryName(Application.ExecutablePath)).FullName;
            ReadPLCLog(INIpath + "\\PLCIOSAVE.INI");
            ReadPLCINI(INIpath + "\\SIMFBPLC.INI");
            ReadPLCIOName(INIpath + "\\SIMFBPLC.INI");

            chkOnTop.Checked = bTopmost;
            chkMtoY.Checked = MtoY_Flag;
            this.TopMost = chkMtoY.Checked;

            cmoCommPort.SelectedIndex = Convert.ToInt32(sComport) - 1;
            simPLC.SetCommSetting(cmoCommPort.SelectedItem.ToString(), sCommSetting);
            simPLC.Open();
            FormCaption = this.Text;
            LinkToolTiptext();
            for (i = 0; i <= 300; i++)
                CSetTimer[i] = new Class_SetTimer();


            Timer1.Interval = 100;
            //Timer1.Enabled = true;
            FirstFlag = true;
            Timer2.Interval = 100;
            Timer2.Enabled = true;

            aa.Interval = 100;
            aa.SynchronizingObject = this;
            aa.AutoReset = true;
            aa.Elapsed += RunAction;
            aa.Start();
            //DataClone();
            if (simPLC.PLC_COM.IsOpen)
            {
                btnOpenComm.BackColor = Color.Lime;
                btnCloseComm.BackColor = Color.LightGray;
            }
            else
            {
                btnCloseComm.BackColor = Color.Lime;
                btnOpenComm.BackColor = Color.LightGray;
            }
            InitThread();
        }
        public void SetAction(SAction[] SA)
        {
            int i, istep;
            string srcstr, deststr, ope, TargetDevice;
            int srcindex, destindex, DTime, Target, Mux, MuxIndex, iStepIndex, DIndex;
            bool set_cond, SrcBit;
            int aaindex, bbindex, ccindex, ddindex;
            string subCommand;
            TargetDevice = "";
            srcstr = "";
            deststr = "";
            i = 0;
            DTime = 0;
            Target = 0;
            set_cond = false;

            do
            {
                if (SA[i].Source == null)
                    break;
                // CSetTimer[i].Reset()
                srcindex = Decode(SA[i].Source, out srcstr);
                ope = SA[i].Method;
                destindex = Decode(SA[i].Dest, out deststr);
                //if (Mid(SA[i].Delay, 1, 1) == "R")
                if (SA[i].Delay.Substring(1 - 1, 1) == "R")
                {
                    DIndex = Decode(SA[i].Delay, out TargetDevice);
                    if (DIndex >= 1000 & DIndex < 1100)
                        DTime = RR_Word[DIndex - 1000];
                    else if (DIndex >= 1200 & DIndex < 1300)
                        DTime = RR_Word[DIndex - 1200 + 96];
                    else if (DIndex >= 1100 & DIndex < 1200)
                        DTime = RW_Word[DIndex - 1100];
                    else if (DIndex >= 1300 & DIndex < 1400)
                        DTime = RW_Word[DIndex - 1300 + 96];
                    if (DTime <= 0)
                        DTime = 1;
                }
                else
                {
                    DTime = Convert.ToInt32(SA[i].Delay);
                    if (DTime <= 0)
                        DTime = 1;
                }

                if (SA[i].Method.Substring(1 - 1, 1) == "R")
                {
                    istep = 0;
                    iStepIndex = Decode(SA[i].Method, out TargetDevice);
                    if (iStepIndex >= 1000 & iStepIndex < 1100)
                        istep = RR_Word[iStepIndex - 1000];
                    else if (iStepIndex >= 1200 & iStepIndex < 1300)
                        istep = RR_Word[iStepIndex - 1000 + 96];
                    else if (iStepIndex >= 1100 & iStepIndex < 1200)
                        istep = RW_Word[iStepIndex - 1100];
                    else if (iStepIndex >= 1300 & iStepIndex < 1400)
                        istep = RW_Word[iStepIndex - 1300 + 96];
                    if (istep <= 0)
                        istep = 1;
                }
                else
                {
                    istep = Convert.ToInt32(SA[i].Method);
                    if (istep <= 0)
                        istep = 1;
                }

                if (SA[i].TargetValue.Substring(1 - 1, 1) == "M" || SA[i].TargetValue.Substring(1 - 1, 1) == "D" || SA[i].TargetValue.Substring(1 - 1, 1) == "R")
                {
                    Mux = Convert.ToInt32(SA[i].TargetValue.Substring(2 - 1, SA[i].TargetValue.Length - 1));
                    if (Mux <= 0)
                        Mux = 1;
                    if (SA[i].TargetValue.Substring(1 - 1, 1) == "M")
                        DTime = Mux * DTime;
                    if (SA[i].TargetValue.Substring(1 - 1, 1) == "D")
                        DTime = (int)(Mux / (double)DTime);
                    if (DTime <= 0)
                        DTime = 1;
                }
                else
                //Target = Convert.ToInt32(SA[i].TargetValue);
                {
                    try
                    {
                        Target = Convert.ToInt32(SA[i].TargetValue);
                    }
                    catch
                    {
                        Target = 0;
                    }
                }
                switch (srcstr)
                {
                    case "RR":
                        {
                            switch (deststr)
                            {
                                case "M":
                                    {
                                        CSetTimer[i].SetTimerWrodCompToBit(ActionFlag, RR_Word[srcindex - 1000], Target, ope, ref M_Bit[destindex]);
                                        break;
                                    }

                                case "X":
                                    {
                                        //CSetTimer[i].SetTimerWrodCompToBit(ActionFlag, RR_Word[srcindex - 1000), Target, ope, X_Bit[destindex]);
                                        CSetTimer[i].SetTimerWrodCompToBit(ActionFlag, RR_Word[srcindex - 1000], Target, ope, ref X_Bit[destindex]);
                                        break;
                                    }

                                case "Y":
                                    {
                                        //CSetTimer[i].SetTimerWrodCompToBit(ActionFlag, RR_Word[srcindex - 1000), Target, ope, Y_Bit[destindex]);
                                        CSetTimer[i].SetTimerWrodCompToBit(ActionFlag, RR_Word[srcindex - 1000], Target, ope, ref Y_Bit[destindex]);
                                        break;
                                    }
                            }

                            break;
                        }

                    case "RW":
                        {
                            switch (deststr)
                            {
                                case "M":
                                    {
                                        //CSetTimer[i].SetTimerWrodCompToBit(ActionFlag, RW_Word[srcindex - 1100), Target, ope, M_Bit[destindex]);
                                        CSetTimer[i].SetTimerWrodCompToBit(ActionFlag, RW_Word[srcindex - 1100], Target, ope, ref M_Bit[destindex]);
                                        break;
                                    }

                                case "X":
                                    {
                                        //CSetTimer[i].SetTimerWrodCompToBit(ActionFlag, RW_Word[srcindex - 1100), Target, ope, X_Bit[destindex]);
                                        CSetTimer[i].SetTimerWrodCompToBit(ActionFlag, RW_Word[srcindex - 1100], Target, ope, ref X_Bit[destindex]);
                                        break;
                                    }

                                case "Y":
                                    {
                                        //CSetTimer[i].SetTimerWrodCompToBit(ActionFlag, RW_Word[srcindex - 1100), Target, ope, Y_Bit[destindex]);
                                        CSetTimer[i].SetTimerWrodCompToBit(ActionFlag, RW_Word[srcindex - 1100], Target, ope, ref Y_Bit[destindex]);
                                        break;
                                    }
                            }

                            break;
                        }

                    case "M":
                        {
                            bool Hold = false;
                            SrcBit = M_Bit[srcindex];
                            switch (ope)
                            {
                                case "0":
                                    {
                                        set_cond = false;
                                        break;
                                    }

                                case "1":
                                    {
                                        set_cond = true;
                                        break;
                                    }

                                case "!":
                                    {
                                        set_cond = !M_Bit[destindex];
                                        break;
                                    }

                                case "I":
                                    {
                                        SrcBit = !M_Bit[destindex];
                                        break;
                                    }

                                default:
                                    {
                                        set_cond = M_Bit[destindex];
                                        break;
                                    }
                            }

                            int aa;
                            if (((SA[i].TargetValue).Length - 1) > 0)
                                aa = Convert.ToInt32(SA[i].TargetValue.Substring(2 - 1, SA[i].TargetValue.Length - 1));
                            switch (SA[i].TargetValue.Substring(1 - 1, 1))
                            {
                                case "R":
                                    {
                                        aa = Convert.ToInt32(SA[i].TargetValue.Substring(2 - 1, SA[i].TargetValue.Length - 1));
                                        if (aa >= 1100)
                                        {
                                            if (aa >= 1300)
                                                Target = RW_Word[aa - 1300 + 96];
                                            else
                                                Target = RW_Word[aa - 1100];
                                        }
                                        else if (aa >= 1200)
                                            Target = RR_Word[aa - 1200 + 96];
                                        else
                                            Target = RR_Word[aa - 1000];
                                        break;
                                    }
                            }

                            if (SA[i].Source.Length == 6)
                            {
                                subCommand = SA[i].Source.Substring(5, 1);
                                switch (subCommand.ToUpper())
                                {
                                    case "I":
                                        {
                                            SrcBit = !SrcBit;
                                            break;
                                        }
                                }
                            }

                            switch (deststr)
                            {
                                case "M":
                                    {
                                        CSetTimer[i].SetTimerBit(ActionFlag, SrcBit, ref M_Bit[destindex], set_cond, DTime);
                                        break;
                                    }

                                case "X":
                                    {
                                        CSetTimer[i].SetTimerBit(ActionFlag, SrcBit, ref X_Bit[destindex], set_cond, DTime);
                                        string str = "CSetTimer[" + i + "].SetTimerBit(" + ActionFlag + "," + SrcBit + ", X_Bit[" + destindex + "]," + set_cond + "," + DTime + ")";
                                        //Debug.Print(str);
                                        str = "X_Bit[" + destindex + "] =" + X_Bit[destindex];
                                        //Debug.Print(str);
                                        break;
                                    }

                                case "Y":
                                    {
                                        CSetTimer[i].SetTimerBit(ActionFlag, SrcBit, ref Y_Bit[destindex], set_cond, DTime);
                                        break;
                                    }

                                case "RR":
                                    {
                                        if (destindex - 1000 >= 0)
                                        {
                                            //R_Read[destindex - 1000].Text = CSetTimer[i].SetTimerBit2Word(ActionFlag, SrcBit, ref RR_Word[destindex - 1000], Target, istep, DTime).ToString();
                                            RR_Word[destindex - 1000] = CSetTimer[i].SetTimerBit2Word(ActionFlag, SrcBit, ref RR_Word[destindex - 1000], Target, istep, DTime);
                                            //Debug.Print("R_Read[" + (destindex - 1000) + "].Text=" + R_Read[destindex - 1000].Text);
                                            //Debug.Print("RR_Word[" + (destindex - 1000) + "]=" + RR_Word[destindex - 1000]);
                                        }

                                        //RR_Word[destindex - 1000] = CSetTimer[i].SetTimerBit2Word(ActionFlag, SrcBit, ref RR_Word[destindex - 1000], Target, istep, DTime);
                                        break;
                                    }

                                case "RW":
                                    {
                                        if (destindex - 1000 >= 0)
                                            //R_Write[destindex - 1100].Text = CSetTimer[i].SetTimerBit2Word(ActionFlag, SrcBit, ref RW_Word[destindex - 1100], Target, istep, DTime).ToString();
                                            RW_Word[destindex - 1100] = CSetTimer[i].SetTimerBit2Word(ActionFlag, SrcBit, ref RW_Word[destindex - 1100], Target, istep, DTime);
                                        break;
                                    }
                            }

                            break;
                        }

                    case "X":
                        {
                            bool Hold = false;
                            SrcBit = X_Bit[srcindex];
                            switch (ope)
                            {
                                case "0":
                                    {
                                        set_cond = false;
                                        break;
                                    }

                                case "1":
                                    {
                                        set_cond = true;
                                        break;
                                    }

                                case "!":
                                    {
                                        set_cond = !X_Bit[destindex];
                                        break;
                                    }

                                case "I":
                                    {
                                        SrcBit = !X_Bit[destindex];
                                        break;
                                    }

                                default:
                                    {
                                        set_cond = X_Bit[destindex];
                                        break;
                                    }
                            }

                            int aa;
                            switch (SA[i].TargetValue.Substring(1 - 1, 1))
                            {
                                case "R":
                                    {
                                        aa = Convert.ToInt32(SA[i].TargetValue.Substring(2 - 1, SA[i].TargetValue.Length - 1));
                                        if (aa >= 1100)
                                            Target = RW_Word[aa - 1100];
                                        else
                                            Target = RR_Word[aa - 1000];
                                        break;
                                    }
                            }

                            if (SA[i].Source.Length == 6)
                            {
                                subCommand = SA[i].Source.Substring(5 - 1, 1);
                                switch (subCommand.ToUpper())
                                {
                                    case "I":
                                        {
                                            SrcBit = !SrcBit;
                                            break;
                                        }
                                }
                            }

                            switch (deststr)
                            {
                                case "M":
                                    {
                                        CSetTimer[i].SetTimerBit(ActionFlag, SrcBit, ref M_Bit[destindex], set_cond, DTime);
                                        break;
                                    }

                                case "X":
                                    {
                                        CSetTimer[i].SetTimerBit(ActionFlag, SrcBit, ref X_Bit[destindex], set_cond, DTime);
                                        break;
                                    }

                                case "Y":
                                    {
                                        CSetTimer[i].SetTimerBit(ActionFlag, SrcBit, ref Y_Bit[destindex], set_cond, DTime);
                                        break;
                                    }

                                case "RR":
                                    {
                                        //R_Read[destindex - 1000].Text = CSetTimer[i].SetTimerBit2Word(ActionFlag, SrcBit, ref RR_Word[destindex - 1000], Target, istep, DTime).ToString();
                                        RR_Word[destindex - 1000] = CSetTimer[i].SetTimerBit2Word(ActionFlag, SrcBit, ref RR_Word[destindex - 1000], Target, istep, DTime);
                                        break;
                                    }

                                case "RW":
                                    {
                                        //R_Write[destindex - 1100].Text = CSetTimer[i].SetTimerBit2Word(ActionFlag, SrcBit, ref RW_Word[destindex - 1100], Target, istep, DTime).ToString();
                                        RW_Word[destindex - 1100] = CSetTimer[i].SetTimerBit2Word(ActionFlag, SrcBit, ref RW_Word[destindex - 1100], Target, istep, DTime);
                                        break;
                                    }
                            }

                            break;
                        }

                    case "Y":
                        {
                            bool Hold = false;
                            SrcBit = Y_Bit[srcindex];
                            switch (ope)
                            {
                                case "0":
                                    {
                                        set_cond = false;
                                        break;
                                    }

                                case "1":
                                    {
                                        set_cond = true;
                                        break;
                                    }

                                case "!":
                                    {
                                        set_cond = !Y_Bit[destindex];
                                        break;
                                    }

                                case "I":
                                    {
                                        SrcBit = !Y_Bit[destindex];
                                        break;
                                    }

                                default:
                                    {
                                        set_cond = Y_Bit[destindex];
                                        break;
                                    }
                            }

                            int aa;
                            switch (SA[i].TargetValue.Substring(1 - 1, 1))
                            {
                                case "R":
                                    {
                                        aa = Convert.ToInt32(SA[i].TargetValue.Substring(2 - 1, SA[i].TargetValue.Length - 1));
                                        if (aa >= 1100)
                                            Target = RW_Word[aa - 1100];
                                        else
                                            Target = RR_Word[aa - 1000];
                                        break;
                                    }
                            }

                            if ((SA[i].Source.Length) == 6)
                            {
                                subCommand = SA[i].Source.Substring(5 - 1, 1);
                                switch (subCommand.ToUpper())
                                {
                                    case "I":
                                        {
                                            SrcBit = !SrcBit;
                                            break;
                                        }
                                }
                            }

                            switch (deststr)
                            {
                                case "M":
                                    {
                                        CSetTimer[i].SetTimerBit(ActionFlag, SrcBit, ref M_Bit[destindex], set_cond, DTime);
                                        break;
                                    }

                                case "X":
                                    {
                                        CSetTimer[i].SetTimerBit(ActionFlag, SrcBit, ref X_Bit[destindex], set_cond, DTime);
                                        break;
                                    }

                                case "Y":
                                    {
                                        CSetTimer[i].SetTimerBit(ActionFlag, SrcBit, ref Y_Bit[destindex], set_cond, DTime);
                                        break;
                                    }

                                case "RR":
                                    {
                                        //R_Read[destindex - 1000].Text = CSetTimer[i].SetTimerBit2Word(ActionFlag, SrcBit, ref RR_Word[destindex - 1000], Target, istep, DTime).ToString();
                                        RR_Word[destindex - 1000] = CSetTimer[i].SetTimerBit2Word(ActionFlag, SrcBit, ref RR_Word[destindex - 1000], Target, istep, DTime);
                                        break;
                                    }

                                case "RW":
                                    {
                                        //R_Write[destindex - 1100].Text = CSetTimer[i].SetTimerBit2Word(ActionFlag, SrcBit, ref RW_Word[destindex - 1100], Target, istep, DTime).ToString();
                                        RW_Word[destindex - 1100] = CSetTimer[i].SetTimerBit2Word(ActionFlag, SrcBit, ref RW_Word[destindex - 1100], Target, istep, DTime);
                                        break;
                                    }
                            }

                            break;
                        }
                }

                i = i + 1;
            }
            while (true);
        }
        public int Decode(string sa, out string Mode)
        {
            int i, j;
            int RRindex, RWindex, Mindex, Xindex, Yindex;
            Mode = "";

            if (sa == null)
                return 0;
            switch (sa.Substring(1 - 1, 1).ToUpper())
            {
                case "R":
                    {
                        j = Convert.ToInt32(sa.Substring(2 - 1, 4));
                        if (j >= 1000 & j < 1100)
                        {
                            RRindex = j;
                            Mode = "RR";
                            return RRindex;
                        }
                        if (j >= 1100)
                        {
                            RWindex = j;
                            Mode = "RW";
                            return RWindex;
                        }

                        break;
                    }

                case "M":
                    {
                        Mindex = Convert.ToInt32(sa.Substring(2 - 1, 4));
                        Mode = "M";
                        return Mindex;
                    }

                case "X":
                    {
                        Xindex = Convert.ToInt32(sa.Substring(2 - 1, 4));
                        Mode = "X";
                        return Xindex;
                    }

                case "Y":
                    {
                        Yindex = Convert.ToInt32(sa.Substring(2 - 1, 4));
                        Mode = "Y";
                        return Yindex;
                    }
                default:
                    return 0;

            }
            return 0;
        }

        public void ReadPLCLinkData()
        {
            PLC_IP = ReadProgData(SecName, "PLC_IP", "127.0.0.1", IniFile);
            PLC_INPORT = Convert.ToInt32(ReadProgData(SecName, "PLC_INPORT", "8080", IniFile));
            PLC_OUTPORT = Convert.ToInt32(ReadProgData(SecName, "PLC_OUTPORT", "8081", IniFile));
            PLC_CrystalFailX = ReadProgData(SecName, "PLC_CrystalFailX", "X0013", IniFile);
            PLC_DepSensor2X = ReadProgData(SecName, "PLC_DepSensor2X", "X0014", IniFile);
            PLC_DepCompleteX = ReadProgData(SecName, "PLC_DepCompleteX", "X0015", IniFile);
            PLC_DepSHX = ReadProgData(SecName, "PLC_DepSHX", "X0016", IniFile);

            PLC_PockInpositionY = ReadProgData(SecName, "PLC_PockInpositionY", "M0035", IniFile);
            PLC_PowerOutR = ReadProgData(SecName, "PLC_PowerOutR", "R1165", IniFile);
        }
        private void ReadPLCLog(string sfile)
        {
            int i;
            for (i = 0; i <= 95; i++)
                X_Bit[i] = Str2Bol(ReadProgData("PLC_X", "X" + i.ToString("D2"), "0", sfile));
            for (i = 0; i <= 191; i++)
            {
                Y_Bit[i] = Str2Bol(ReadProgData("PLC_Y", "Y" + i.ToString("D2"), "0", sfile));
                M_Bit[i] = Str2Bol(ReadProgData("PLC_M", "M" + i.ToString("D2"), "0", sfile));
                RR_Word[i] = Convert.ToInt32(ReadProgData("PLC_RR", "R010" + i.ToString("D2"), "0", sfile));
                //R_Read[i].Text = RR_Word[i].ToString();
                //Debug.Print("R_Read[" + i + "]=" + R_Read[i].Text);
                RW_Word[i] = Convert.ToInt32(ReadProgData("PLC_RW", "R011" + i.ToString("D2"), "0", sfile));
                R_Write[i].Text = RW_Word[i].ToString();
                //Debug.Print("R_Write[" + i + "]=" + R_Write[i].Text);
            }
        }
        public bool Str2Bol(string sstr)
        {
            if (sstr == "0")
                return false;
            else
                return true;
        }
        public string ReadProgData(string section, string value, string defval, string ini_File)
        {
            System.Text.StringBuilder strBuffer = new System.Text.StringBuilder(256);
            if ((System.IO.File.Exists(ini_File)))
            {
                GetPrivateProfileString(section, value, defval, strBuffer, 80, ini_File);
                return strBuffer.ToString();
            }
            else
                return defval;
        }
        public void WriteProgData(string section, string value, string val2, string ini_File)
        {
            WritePrivateProfileString(section, value, val2, ini_File);
        }
        public void WritePLCLinkData()
        {
            WriteProgData(SecName, "PLC_IP", PLC_IP, IniFile);
            WriteProgData(SecName, "PLC_INPORT", PLC_INPORT.ToString(), IniFile);
            WriteProgData(SecName, "PLC_OUTPORT", PLC_OUTPORT.ToString(), IniFile);
            WriteProgData(SecName, "PLC_CrystalFailX", PLC_CrystalFailX, IniFile);
            WriteProgData(SecName, "PLC_DepSensor2X", PLC_DepSensor2X, IniFile);
            WriteProgData(SecName, "PLC_DepCompleteX", PLC_DepCompleteX, IniFile);
            WriteProgData(SecName, "PLC_DepSHX", PLC_DepSHX, IniFile);

            WriteProgData(SecName, "PLC_PockInpositionY", PLC_PockInpositionY, IniFile);
            WriteProgData(SecName, "PLC_PowerOutR", PLC_PowerOutR, IniFile);
        }

        public void PLC_ONComm(string rstr)
        {
            string sstr;
            string tstr;
            string devval;
            int dStart;
            int dnum;
            string dev;
            int i = 0;
            string cmd = rstr.Substring(4 - 1, 2);
            switch (cmd)
            {
                case "40":
                    {
                        sstr = "";
                        Output_String = STX + "01400FFFFFF";
                        //Output_String = Output_String + CheckSumFB(Output_String) + ETX;
                        Output_String = Output_String + CheckSumFB("01400FFFFFF") + ETX;
                        TimeDelay(delay);

                        simPLC.PLC_COM.Write(Output_String);
                        break;
                    }

                case "41":
                    {
                        sstr = "";
                        Output_String = STX + "01410";
                        //Output_String = Output_String + CheckSumFB(Output_String) + ETX;
                        Output_String = Output_String + CheckSumFB("01410") + ETX;
                        TimeDelay(delay);
                        simPLC.PLC_COM.Write(Output_String);
                        break;
                    }

                case "44"   // Read Bit
         :
                    {
                        dev = rstr.Substring(8 - 1, 1);
                        dStart = Convert.ToInt32(rstr.Substring(9 - 1, 4));
                        dnum = Convert.ToInt16(rstr.Substring(6 - 1, 2), 16);
                        switch (dev)
                        {
                            case "X":
                                {
                                    sstr = "";
                                    for (i = dStart; i <= dnum - 1; i++)
                                    {
                                        if (X_Bit[i])
                                            sstr = sstr + "1";
                                        else
                                            sstr = sstr + "0";
                                    }
                                    sstr = STX + "01440" + sstr;
                                    tstr = sstr + CheckSumFB(sstr) + ETX;
                                    // X_TEXT.Text = sstr
                                    TimeDelay(delay);
                                    if (simPLC.PLC_COM.IsOpen)
                                        simPLC.PLC_COM.Write(tstr);
                                    break;
                                }

                            case "M":
                                {
                                    sstr = "";
                                    for (i = dStart; i <= (dStart + dnum - 1); i++)
                                    {
                                        if (M_Bit[i])
                                            sstr = sstr + "1";
                                        else
                                            sstr = sstr + "0";
                                    }
                                    sstr = STX + "01440" + sstr;
                                    tstr = sstr + CheckSumFB(sstr) + ETX;

                                    // M_TEXT.Text = sstr
                                    TimeDelay(delay);
                                    if (simPLC.PLC_COM.IsOpen)
                                        simPLC.PLC_COM.Write(tstr);
                                    break;
                                }

                            case "Y":
                                {
                                    sstr = "";
                                    for (i = dStart; i <= dnum - 1; i++)
                                    {
                                        if (Y_Bit[i])
                                            sstr = sstr + "1";
                                        else
                                            sstr = sstr + "0";
                                    }
                                    sstr = STX + "01440" + sstr;
                                    tstr = sstr + CheckSumFB(sstr) + ETX;

                                    // Y_TEXT.Text = sstr
                                    TimeDelay(delay);
                                    if (simPLC.PLC_COM.IsOpen)
                                        simPLC.PLC_COM.Write(tstr);
                                    break;
                                }
                        }

                        break;
                    }

                case "45"   // Set Bit
         :
                    {
                        dev = rstr.Substring(8 - 1, 1);
                        dStart = Convert.ToInt32(rstr.Substring(9 - 1, 4));
                        dnum = Convert.ToInt16(rstr.Substring(6 - 1, 2), 16);
                        switch (dev)
                        {
                            case "M":
                                {
                                    sstr = "";
                                    for (i = 0; i <= dnum - 1; i++)
                                    {
                                        int a;
                                        a = Convert.ToInt32(rstr.Substring(13 + i - 1, 1));
                                        if (a == 0)
                                            M_Bit[dStart + i] = false;
                                        else
                                            M_Bit[dStart + i] = true;
                                    }
                                    sstr = STX + "01450" + sstr;
                                    tstr = sstr + CheckSumFB(sstr) + ETX;

                                    TimeDelay(delay);
                                    // RR_TEXT.Text = sstr
                                    if (simPLC.PLC_COM.IsOpen)
                                        simPLC.PLC_COM.Write(tstr);
                                    break;
                                }
                        }

                        break;
                    }

                case "46" // Read Word
         :
                    {
                        dev = rstr.Substring(8 - 1, 1);

                        dStart = Convert.ToInt32(rstr.Substring(9 - 1, 5));
                        dnum = Convert.ToInt16(rstr.Substring(6 - 1, 2), 16);
                        switch (dev)
                        {
                            case "D":
                                {
                                    string astr;
                                    int tnum;
                                    tnum = DD_Word[i];//claire i =??
                                    astr = HexZero(tnum, 4);
                                    sstr = STX + "01460" + astr;
                                    tstr = sstr + CheckSumFB(sstr) + ETX;
                                    TimeDelay(delay);
                                    if (simPLC.PLC_COM.IsOpen)
                                        simPLC.PLC_COM.Write(tstr);
                                    break;
                                }

                            case "R":
                                {
                                    sstr = "";
                                    string astr;
                                    int tnum = 0;
                                    for (i = 0; i <= dnum - 1; i++)
                                    {
                                        switch (dStart)
                                        {
                                            case 1000:
                                                {
                                                    tnum = Convert.ToInt32(RR_Word[i]);
                                                    break;
                                                }

                                            case 1100:
                                                {
                                                    tnum = Convert.ToInt32(RW_Word[i]);
                                                    break;
                                                }

                                            case 1032:
                                                {
                                                    tnum = Convert.ToInt32(RR_Word[i + 32]);
                                                    break;
                                                }

                                            case 1132:
                                                {
                                                    tnum = Convert.ToInt32(RW_Word[i + 32]);
                                                    break;
                                                }

                                            case 1064:
                                                {
                                                    tnum = Convert.ToInt32(RR_Word[i + 64]);
                                                    break;
                                                }

                                            case 1164:
                                                {
                                                    tnum = Convert.ToInt32(RW_Word[i + 64]);
                                                    break;
                                                }

                                            case 1200:
                                                {
                                                    tnum = Convert.ToInt32(RR_Word[i + 96]);
                                                    break;
                                                }

                                            case 1300:
                                                {
                                                    tnum = Convert.ToInt32(RW_Word[i + 96]);
                                                    break;
                                                }

                                            case 1264:
                                                {
                                                    tnum = Convert.ToInt32(RR_Word[i + 160]);
                                                    break;
                                                }

                                            case 1364:
                                                {
                                                    tnum = Convert.ToInt32(RW_Word[i + 160]);
                                                    break;
                                                }

                                            default:
                                                {
                                                    if (dStart < 1000 & dStart >= 0)
                                                        tnum = Convert.ToInt32(RR_Word[dStart]);
                                                    else if ((dStart - 1000) < 1000 & (dStart - 1000) > -0)
                                                        tnum = Convert.ToInt32(RR_Word[dStart - 1000]);
                                                    break;
                                                }
                                        }
                                        astr = HexZero(tnum, 4);
                                        sstr = sstr + astr;
                                    }
                                    sstr = STX + "01460" + sstr;
                                    tstr = sstr + CheckSumFB(sstr) + ETX;

                                    // If dStart = 1000 Then
                                    // RR_TEXT.Text = sstr
                                    // ElseIf dStart = 1100 Then
                                    // RW_TEXT.Text = sstr
                                    // End If
                                    TimeDelay(delay);
                                    // RW_TEXT.Text = sstr
                                    if (simPLC.PLC_COM.IsOpen)
                                        simPLC.PLC_COM.Write(tstr);
                                    break;
                                }
                        }
                        break;
                    }

                case "47" // Write Word
         :
                    {
                        dev = rstr.Substring(8 - 1, 1);
                        dStart = Convert.ToInt32(rstr.Substring(9 - 1, 5));
                        dnum = Convert.ToInt16(rstr.Substring(6 - 1, 2), 16);
                        switch (dev)
                        {
                            case "D":
                                {
                                    int tnum;
                                    devval = rstr.Substring(14 + i * 4 - 1, 4);
                                    tnum = Convert.ToInt32(devval, 16);
                                    DD_Word[dStart] = tnum;
                                    switch (dStart)
                                    {
                                        case 0 // DOOR
                                       :
                                            {
                                                M_Bit[48] = Convert.ToBoolean(DD_Word[dStart] & 0x1); // 0
                                                M_Bit[49] = Convert.ToBoolean(DD_Word[dStart] & 0x2); // 1
                                                M_Bit[50] = Convert.ToBoolean(DD_Word[dStart] & 0x4); // 2
                                                M_Bit[51] = Convert.ToBoolean(DD_Word[dStart] & 0x8); // 3
                                                                                                      // M_Bit(0) = DD_Word(dStart) And &H10 '4
                                                                                                      // M_Bit(5) = DD_Word(dStart) And &H20 '5
                                                                                                      // M_Bit(6) = DD_Word(dStart) And &H40 '6
                                                M_Bit[47] = Convert.ToBoolean(DD_Word[dStart] & 0x80); // 7
                                                break;
                                            }

                                        case 1 // Convert.ToInt32VE
                                 :
                                            {
                                                M_Bit[4] = Convert.ToBoolean(DD_Word[dStart] & 0x1); // 0
                                                M_Bit[5] = Convert.ToBoolean(DD_Word[dStart] & 0x2); // 1
                                                M_Bit[52] = Convert.ToBoolean(DD_Word[dStart] & 0x4); // 2
                                                M_Bit[53] = Convert.ToBoolean(DD_Word[dStart] & 0x8); // 3
                                                M_Bit[57] = Convert.ToBoolean(DD_Word[dStart] & 0x10); // 4
                                                                                                       // M_Bit[24] = DD_Word[dStart] And &H20 '5
                                                                                                       // M_Bit[6] = DD_Word[dStart] And &H40 '6
                                                                                                       // M_Bit[47] = DD_Word[dStart] And &H80 '7
                                                M_Bit[24] = Convert.ToBoolean(DD_Word[dStart] & 0x100); // 8
                                                M_Bit[25] = Convert.ToBoolean(DD_Word[dStart] & 0x200); // 9
                                                M_Bit[26] = Convert.ToBoolean(DD_Word[dStart] & 0x400); // 10
                                                M_Bit[27] = Convert.ToBoolean(DD_Word[dStart] & 0x800); // 11
                                                M_Bit[28] = Convert.ToBoolean(DD_Word[dStart] & 0x1000); // 12
                                                M_Bit[29] = Convert.ToBoolean(DD_Word[dStart] & 0x2000); // 13
                                                M_Bit[55] = Convert.ToBoolean(DD_Word[dStart] & 0x4000); // 14
                                                break;
                                            }

                                        case 2 // GP390
                                 :
                                            {
                                                M_Bit[59] = Convert.ToBoolean(DD_Word[dStart] & 0x1); // 0
                                                M_Bit[60] = Convert.ToBoolean(DD_Word[dStart] & 0x2); // 1
                                                M_Bit[61] = Convert.ToBoolean(DD_Word[dStart] & 0x4); // 2
                                                                                                      // M_Bit[53] = DD_Word[dStart] And &H8 '3
                                                                                                      // M_Bit[57] = DD_Word[dStart] And &H10 '4
                                                                                                      // M_Bit[24] = DD_Word[dStart] And &H20 '5
                                                                                                      // M_Bit[6] = DD_Word[dStart] And &H40 '6
                                                M_Bit[56] = Convert.ToBoolean(DD_Word[dStart] & 0x80); // 7
                                                break;
                                            }

                                        case 3 // Temp
                                 :
                                            {
                                                M_Bit[0] = Convert.ToBoolean(DD_Word[dStart] & 0x1); // 0
                                                M_Bit[1] = Convert.ToBoolean(DD_Word[dStart] & 0x2); // 1
                                                M_Bit[2] = Convert.ToBoolean(DD_Word[dStart] & 0x4); // 2
                                                M_Bit[3] = Convert.ToBoolean(DD_Word[dStart] & 0x8); // 3
                                                M_Bit[6] = Convert.ToBoolean(DD_Word[dStart] & 0x10); // 4
                                                M_Bit[7] = Convert.ToBoolean(DD_Word[dStart] & 0x20); // 5
                                                M_Bit[8] = Convert.ToBoolean(DD_Word[dStart] & 0x40); // 6
                                                M_Bit[9] = Convert.ToBoolean(DD_Word[dStart] & 0x80); // 7
                                                M_Bit[10] = Convert.ToBoolean(DD_Word[dStart] & 0x100); // 8
                                                M_Bit[11] = Convert.ToBoolean(DD_Word[dStart] & 0x200); // 9
                                                M_Bit[12] = Convert.ToBoolean(DD_Word[dStart] & 0x400); // 10
                                                M_Bit[13] = Convert.ToBoolean(DD_Word[dStart] & 0x800); // 11
                                                break;
                                            }

                                        case 4 // Lock
                                 :
                                            {
                                                M_Bit[35] = Convert.ToBoolean(DD_Word[dStart] & 0x1); // 0
                                                M_Bit[36] = Convert.ToBoolean(DD_Word[dStart] & 0x2); // 1
                                                M_Bit[37] = Convert.ToBoolean(DD_Word[dStart] & 0x4); // 2
                                                M_Bit[38] = Convert.ToBoolean(DD_Word[dStart] & 0x8); // 3
                                                M_Bit[39] = Convert.ToBoolean(DD_Word[dStart] & 0x10); // 4
                                                M_Bit[40] = Convert.ToBoolean(DD_Word[dStart] & 0x20); // 5
                                                M_Bit[41] = Convert.ToBoolean(DD_Word[dStart] & 0x40); // 6
                                                M_Bit[42] = Convert.ToBoolean(DD_Word[dStart] & 0x80); // 7
                                                M_Bit[43] = Convert.ToBoolean(DD_Word[dStart] & 0x100); // 8
                                                M_Bit[44] = Convert.ToBoolean(DD_Word[dStart] & 0x200); // 9
                                                M_Bit[45] = Convert.ToBoolean(DD_Word[dStart] & 0x400); // 10
                                                M_Bit[46] = Convert.ToBoolean(DD_Word[dStart] & 0x800); // 11
                                                break;
                                            }

                                        case 5 // MPS
                                 :
                                            {
                                                M_Bit[16] = Convert.ToBoolean(DD_Word[dStart] & 0x1); // 0
                                                break;
                                            }

                                        case 6 // INDIC LAMP
                                 :
                                            {
                                                M_Bit[23] = Convert.ToBoolean(DD_Word[dStart] & 0x1); // 0
                                                M_Bit[32] = Convert.ToBoolean(DD_Word[dStart] & 0x2); // 1
                                                M_Bit[33] = Convert.ToBoolean(DD_Word[dStart] & 0x4); // 2
                                                M_Bit[34] = Convert.ToBoolean(DD_Word[dStart] & 0x8); // 3
                                                M_Bit[54] = Convert.ToBoolean(DD_Word[dStart] & 0x10); // 4
                                                break;
                                            }
                                    }
                                    sstr = STX + "01470";
                                    tstr = sstr + CheckSumFB(sstr) + ETX;
                                    TimeDelay(delay);
                                    if (simPLC.PLC_COM.IsOpen)
                                        simPLC.PLC_COM.Write(tstr);
                                    break;
                                }

                            case "R":
                                {
                                    sstr = "";
                                    int tnum;
                                    if (dStart >= 1000 & dStart < 1100)
                                    {
                                        for (i = 0; i <= dnum - 1; i++)
                                        {
                                            devval = rstr.Substring(14 + i * 4 - 1, 4);
                                            tnum = Convert.ToInt16(devval);
                                            RR_Word[i + dStart - 1000] = tnum;
                                            RR_Word_Writed[i + dStart - 1000] = 1;
                                            //R_Read[i + dStart - 1000].Text = tnum.ToString();
                                        }
                                        sstr = STX + "01470";
                                        tstr = sstr + CheckSumFB(sstr) + ETX;
                                        TimeDelay(delay);
                                        if (simPLC.PLC_COM.IsOpen)
                                            simPLC.PLC_COM.Write(tstr);
                                    }
                                    else if (dStart >= 1200 & dStart < 1300)
                                    {
                                        for (i = 0; i <= dnum - 1; i++)
                                        {
                                            devval = rstr.Substring(14 + i * 4 - 1, 4);
                                            tnum = Convert.ToInt16(devval);
                                            RR_Word[i + dStart - 1200 + 96] = tnum;
                                            RR_Word_Writed[i + dStart - 1200 + 96] = 1;
                                            //R_Read[i + dStart - 1200 + 96].Text = tnum.ToString();
                                        }
                                        sstr = STX + "01470";
                                        tstr = sstr + CheckSumFB(sstr) + ETX;
                                        TimeDelay(delay);
                                        if (simPLC.PLC_COM.IsOpen)
                                            simPLC.PLC_COM.Write(tstr);
                                    }
                                    else if (dStart >= 1100 & dStart < 1200)
                                    {
                                        for (i = 0; i <= dnum - 1; i++)
                                        {
                                            devval = rstr.Substring(14 + i * 4 - 1, 4);
                                            tnum = Convert.ToInt16(devval, 16);
                                            RW_Word[i + dStart - 1100] = tnum;
                                            RW_Word_Writed[i + dStart - 1100] = 1;
                                            R_Write[i + dStart - 1100].Text = tnum.ToString();
                                        }
                                        sstr = STX + "01470";
                                        tstr = sstr + CheckSumFB(sstr) + ETX;
                                        TimeDelay(delay);
                                        if (simPLC.PLC_COM.IsOpen)
                                            simPLC.PLC_COM.Write(tstr);
                                    }
                                    else if (dStart >= 1300 & dStart < 1400)
                                    {
                                        for (i = 0; i <= dnum - 1; i++)
                                        {
                                            devval = rstr.Substring(14 + i * 4 - 1, 4);
                                            tnum = Convert.ToInt16(devval, 16);
                                            RW_Word[i + dStart - 1300 + 96] = tnum;
                                            RW_Word_Writed[i + dStart - 1300 + 96] = 1;
                                            R_Write[i + dStart - 1300 + 96].Text = tnum.ToString();
                                        }
                                        sstr = STX + "01470";
                                        tstr = sstr + CheckSumFB(sstr) + ETX;
                                        TimeDelay(delay);
                                        if (simPLC.PLC_COM.IsOpen)
                                            simPLC.PLC_COM.Write(tstr);
                                    }

                                    break;
                                }
                        }
                        TimeDelay(delay);
                        break;
                    }
                case "49": // Write many Word    :
                    {
                        dev = rstr.Substring(8 - 1, 1);
                        dStart = Convert.ToInt32(rstr.Substring(9 - 1, 5));
                        dnum = Convert.ToInt16(rstr.Substring(6 - 1, 2), 16);
                        switch (dev)
                        {
                            case "R":
                                {
                                    string[] trmp = new string[30];
                                    //取個數
                                    string num = rstr.Substring(5, 2);
                                    int iNum = Convert.ToInt32(num, 16);

                                    //開始切
                                    for (int ii = 0; ii < iNum; ii++)
                                    {
                                        trmp[ii] = rstr.Substring(7+ 10 * ii, 10);

                                        manyR[ii].R_ch = trmp[ii].Substring(2,4);                                        
                                        manyR[ii].R_Value = trmp[ii].Substring(6, 4);

                                        int intch = Convert.ToInt32(manyR[ii].R_ch);
                                        int intval = Convert.ToInt32(manyR[ii].R_Value,16);
                                        
                                        if (intch >= 1300)
                                        {
                                        intch = intch - 1300 + 96;
                                        }
                                        else
                                        {
                                            intch = intch - 1100;
                                        }
                                        RW_Word_Writed[intch] = 1;
                                        R_Write[intch].Text = intval.ToString();
                                        RW_Word[intch] = intval;
                                    }
                                    sstr = STX + "01490";
                                    tstr = sstr + CheckSumFB(sstr) + ETX;
                                    TimeDelay(delay);
                                    if (simPLC.PLC_COM.IsOpen)
                                        simPLC.PLC_COM.Write(tstr);
                                    break;
                                }
                        }
                        TimeDelay(delay);
                        break;
                    }
            }
        }


        public void UDPReceived(string data)
        {
            string[] aa;
            int value;
            int ID;
            aa = data.Split(',');
            if (aa.Length == 2)
            {
                string cc = aa[0].Substring(1 - 1, 1);
                switch (cc)
                {
                    case "X":
                        {
                            ID = Convert.ToInt32(aa[0].Substring(2 - 1, 4));
                            value = Convert.ToInt32(aa[1]);
                            if (value == 1)
                                X_Bit[ID] = true;
                            else
                                X_Bit[ID] = false;
                            break;
                        }

                    case "M":
                        {
                            ID = Convert.ToInt32(aa[0].Substring(2 - 1, 4));
                            value = Convert.ToInt32(aa[1]);
                            if (value == 1)
                                M_Bit[ID] = true;
                            else
                                M_Bit[ID] = false;
                            break;
                        }

                    case "Y":
                        {
                            ID = Convert.ToInt32(aa[0].Substring(2 - 1, 4));
                            value = Convert.ToInt32(aa[1]);
                            if (value == 1)
                                M_Bit[ID] = true;
                            else
                                M_Bit[ID] = false;
                            break;
                        }

                    case "R":
                        {
                            string dd = aa[0].Substring(2 - 1, 2);
                            ID = Convert.ToInt32(aa[0].Substring(2 - 1, 4));
                            switch (dd)
                            {
                                case "10":
                                    {
                                        ID = Convert.ToInt32(aa[0].Substring(2 - 1, 4));
                                        value = Convert.ToInt32(aa[1]);
                                        RR_Word[ID] = value;
                                        break;
                                    }

                                case "11":
                                    {
                                        ID = Convert.ToInt32(aa[0].Substring(2 - 1, 4));
                                        value = Convert.ToInt32(aa[1]);
                                        RW_Word[ID] = value;
                                        break;
                                    }
                            }

                            break;
                        }
                }
            }
        }


        private void SetUpBtnObject(ref Button obj, string sName, string sText, int iX, int iY, int iW, int iH, Color iC)
        {
            obj.Name = sName;
            obj.Text = sText;
            obj.Top = iY;
            obj.Left = iX;
            obj.Width = iW;
            obj.Height = iH;
            obj.BackColor = iC;

        }
        private void SetUpTxtObject(ref TextBox obj, string sName, string sText, int iX, int iY, int iW, int iH, Color iC)
        {
            obj.Name = sName;
            obj.Text = sText;
            obj.Top = iY;
            obj.Left = iX;
            obj.Width = iW;
            obj.Height = iH;
            obj.BackColor = iC;
            obj.BorderStyle = BorderStyle.Fixed3D;
            obj.TextAlign = (HorizontalAlignment)2;

        }

        private void R_Read_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            int index;
            TextBox ctrl = new TextBox();
            if (e.KeyChar == System.Convert.ToChar(13))
            {
                ctrl = (TextBox)sender;
                int lenght = ctrl.Name.Length;
                //index = Convert.ToInt32(ctrl.Name.Substring(5 - 1, 4));
                index = Convert.ToInt32(ctrl.Name.Substring(5, lenght - 5));
                RR_Word[index] = Convert.ToInt32(ctrl.Text);
            }
        }
        private void R_Write_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            int index;
            TextBox ctrl = new TextBox();
            if (e.KeyChar == System.Convert.ToChar(13))
            {
                ctrl = (TextBox)sender;
                int lenght = ctrl.Name.Length;
                //index = Convert.ToInt32(ctrl.Name.Substring(6 - 1, 4));
                index = Convert.ToInt32(ctrl.Name.Substring(5, lenght - 5));
                RW_Word[index] = Convert.ToInt32(ctrl.Text);
                RW_Word_Writed[index] = 1;
                R_Write[index].Text = ctrl.Text;
            }
        }
        private void ShowXName(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            lblXName.Text = X_Name[btn.TabIndex];
        }
        private void ShowYName(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Button btn = (Button)sender;
            lblYName.Text = Y_Name[btn.TabIndex];
        }

        private void ShowMName(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Button btn = (Button)sender;
            lblMName.Text = M_Name[btn.TabIndex];
        }
        private void ShowRRName(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //Button btn = (Button)sender;
            TextBox text = (TextBox)sender;
            lblRRName.Text = RR_Name[text.TabIndex];
        }
        private void ShowRWName(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            TextBox text = (TextBox)sender;
            lblRWName.Text = RW_Name[text.TabIndex];
            //Debug.Print(text.Text);
        }
        private void X_Status_Click(object sender, System.EventArgs e)
        {
            int index;
            Button ctrl = new Button();
            ctrl = (Button)sender;
            if (ctrl.Text.Length < 2)
                return;
            //index = Convert.ToInt32(ctrl.Name.Substring(2-1, ctrl.Text.Length - 1));
            index = Convert.ToInt32(ctrl.Name.Substring(2 - 1, ctrl.Text.Length - 1));
            X_Bit[index] = !X_Bit[index];
            //if (X_Bit[index])
            //    ctrl.BackColor = Color.Lime;
            //else
            //    ctrl.BackColor = Color.Red;
        }
        private void Y_Status_Click(object sender, System.EventArgs e)
        {
            int index;
            Button ctrl = new Button();
            ctrl = (Button)sender;
            if (ctrl.Text.Length < 2)
                return;
            index = Convert.ToInt32(ctrl.Name.Substring(1, ctrl.Text.Length - 1));
            Y_Bit[index] = !Y_Bit[index];
            //if (Y_Bit[index])
            //    ctrl.BackColor = Color.Lime;
            //else
            //    ctrl.BackColor = Color.Red;
        }
        private void M_Status_Click(object sender, System.EventArgs e)
        {
            int index;
            Button ctrl = new Button();
            ctrl = (Button)sender;

            if (ctrl.Text.Length < 2)
                return;
            index = Convert.ToInt32(ctrl.Name.Substring(1, ctrl.Text.Length - 1));
            M_Bit[index] = !M_Bit[index];
            //if (M_Bit[index])
            //    ctrl.BackColor = Color.Lime;
            //else
            //    ctrl.BackColor = Color.Red;
        }

        private void ReadPLCINI(string sfile)
        {
            sComport = ReadProgData("COMM_SETUP", "COMPORT", "1", sfile);
            sCommSetting = ReadProgData("COMM_SETUP", "SETTING", "9600,E,7,1", sfile);
            txtCommSetting.Text = sCommSetting;
            bTopmost = Str2Bol(ReadProgData("PROGRAM", "TOPMOST", "0", sfile));
            MtoY_Flag = Str2Bol(ReadProgData("PROGRAM", "MTOYFLAG", "0", sfile));
            CmdDelay = System.Convert.ToInt32(ReadProgData("PROGRAM", "DELAY", "30", sfile));
            txtXInputIndex.Text = ReadProgData("PROGRAM", "XINDEX", "X0000", sfile);
            txtMOutputIndex.Text = ReadProgData("PROGRAM", "MINDEX", "M0000", sfile);
            txtYOutputIndex.Text = ReadProgData("PROGRAM", "YINDEX", "Y0000", sfile);
            txtReadWordIndex.Text = ReadProgData("PROGRAM", "RRINDEX", "R01000", sfile);
            txtWriteWordIndex.Text = ReadProgData("PROGRAM", "RWINDEX", "R01100", sfile);
        }
        private void ReadPLCIOName(string sfile)
        {
            int i;
            for (i = 0; i <= 95; i++)
                X_Name[i] = ReadProgData("X_NAME", "lblX" + i.ToString("D2"), "No Define", sfile);
            for (i = 0; i <= 191; i++)
            {
                Y_Name[i] = ReadProgData("Y_NAME", "lblY" + i.ToString("D2"), "No Define", sfile);
                M_Name[i] = ReadProgData("M_NAME", "lblM" + i.ToString("D2"), "No Define", sfile);
                RR_Name[i] = ReadProgData("RR_NAME", "txtRR" + i.ToString("D2"), "No Define", sfile);
                RW_Name[i] = ReadProgData("RW_NAME", "txtRW" + i.ToString("D2"), "No Define", sfile);
                //Debug.Print(RW_Name[i]);
            }
        }
        private void LinkToolTiptext()
        {
            int i;
            Help.IsBalloon = false;
            Help.ShowAlways = false;
            Help.ReshowDelay = 0;
            Help.UseAnimation = false;
            Help.UseFading = false;
            Help.AutomaticDelay = 0;
            Help.AutoPopDelay = 5000;
            Help.InitialDelay = 0;
            for (i = 0; i <= 95; i++)
                Help.SetToolTip(X_Status[i], "X" + i.ToString("D2"));// X_Name[i])
            for (i = 0; i <= 191; i++)
            {
                Help.SetToolTip(Y_Status[i], "Y" + i.ToString("D2")); // Y_Name[i])
                Help.SetToolTip(M_Status[i], "M" + i.ToString("D2")); // M_Name[i])
            }
            for (i = 0; i <= 191; i++)
            {
                if (i < 96)
                {
                    Help.SetToolTip(R_Read[i], "R10" + i.ToString("D2")); // RR_Name[i])
                    Help.SetToolTip(R_Write[i], "R11" + i.ToString("D2")); // RW_Name[i])
                }
                else
                {
                    Help.SetToolTip(R_Read[i], "R12" + (i - 96).ToString("D2")); // RR_Name[i])
                    Help.SetToolTip(R_Write[i], "R13" + (i - 96).ToString("D2")); // RW_Name[i])
                }
            }
        }
        public void RunAction(System.Object sender, System.EventArgs e)
        {
            if (ActionFlag)
                SetAction(CAction);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            {
                int i;
                if (simPLC.PLC_COM.IsOpen)
                {
                    btnOpenComm.BackColor = Color.Lime;
                    btnCloseComm.BackColor = Color.LightGray;
                }
                else
                {
                    btnCloseComm.BackColor = Color.Lime;
                    btnOpenComm.BackColor = Color.LightGray;
                }

                for (i = 0; i <= 95; i++)
                {
                    if (X_Bit[i])
                        X_Status[i].BackColor = Color.Lime;
                    else
                        X_Status[i].BackColor = Color.Red;
                }
                for (i = 0; i <= 191; i++)
                {
                    if (MtoY_Flag)
                        Y_Bit[i] = M_Bit[i];
                    if (Y_Bit[i])
                        Y_Status[i].BackColor = Color.Lime;
                    else
                        Y_Status[i].BackColor = Color.Red;

                    if (M_Bit[i])
                        M_Status[i].BackColor = Color.Lime;
                    else
                        M_Status[i].BackColor = Color.Red;

                    if (M_Bit[35])
                        btnPocketGood.BackColor = Color.Lime;
                    else
                        btnPocketGood.BackColor = Color.WhiteSmoke;


                    if (ActionFlag)
                        R_Write[i].Text = RW_Word[i].ToString();
                    if (RW_Word_Writed[i] > 0)
                    {
                        R_Write[i].BackColor = Color.Pink;
                        RW_Word_Writed[i] += 1;
                        if (RW_Word_Writed[i] > 30)
                        {
                            RW_Word_Writed[i] = 0;
                            R_Write[i].BackColor = Color.White;
                        }
                    }
                    else
                        R_Write[i].BackColor = Color.White;
                }
                for (i = 0; i <= 191; i++)
                {
                    if (RR_Word_Writed[i] > 0)
                    {
                        R_Read[i].BackColor = Color.Pink;
                        RR_Word_Writed[i] += 1;
                        if (RR_Word_Writed[i] > 30)
                        {
                            RR_Word_Writed[i] = 0;
                            R_Read[i].BackColor = Color.Pink;
                        }
                    }
                    else
                        R_Read[i].BackColor = Color.LightGreen;
                }
                if (simPLC.PLC_COM.IsOpen)
                    this.Text = FormCaption + "  (Connected!)";
                else
                    this.Text = FormCaption + "  (Disconnected!)";
                if (ActionFlag)
                    btnAction.BackColor = Color.Lime;
                else
                    btnAction.BackColor = Color.LightGray;
            }
            DataClone();

        }
        private void Timer2_Tick(System.Object sender, System.EventArgs e)
        {
            int i;
            //for (i = 0; i <= 191; i++)
            //    RR_Word[i] = Convert.ToInt32(R_Read[i].Text);
            // WritePLCLog(".\PLCIOSAVE.INI")
            //sComport = (cmoCommPort.SelectedIndex + 1).ToString();
            //sCommSetting = txtCommSetting.Text;
            //bTopmost = chkOnTop.Checked;
            //MtoY_Flag = chkMtoY.Checked;
            //for (i = 0; i < 5; i++)
            //{ 
            //    Debug.Print("R_Write[" + i + "]=" + R_Write[i].Text);
            //    Debug.Print("R_Read[" + i + "]=" + R_Read[i].Text);
            //}

        }
        private void btnOpenComm_Click(object sender, EventArgs e)
        {
            sCommSetting = txtCommSetting.Text;
            try
            {
                simPLC.SetCommSetting(cmoCommPort.SelectedItem.ToString(), sCommSetting);
            }
            catch
            {
                MessageBox.Show("通訊格式不對");
                return;
            }

            simPLC.Open();
            if (simPLC.PLC_COM.IsOpen)
            {
                btnOpenComm.BackColor = Color.Lime;
                btnCloseComm.BackColor = Color.LightGray;
            }
            else
            {
                btnCloseComm.BackColor = Color.Lime;
                btnOpenComm.BackColor = Color.LightGray;
            }
        }

        private void btnCloseComm_Click(object sender, EventArgs e)
        {
            simPLC.Close();
            if (simPLC.PLC_COM.IsOpen)
            {
                btnOpenComm.BackColor = Color.Lime;
                btnCloseComm.BackColor = Color.LightGray;
            }
            else
            {
                btnCloseComm.BackColor = Color.Lime;
                btnOpenComm.BackColor = Color.LightGray;
            }
        }

        private void btnReloadPLCIO_Click(object sender, EventArgs e)
        {
            ReadPLCIOName(INIpath + "\\SIMFBPLC.INI");
        }

        private void cmoCommPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FirstFlag == false)
                return;
            sCommSetting = txtCommSetting.Text;
            try
            {
                simPLC.SetCommSetting(cmoCommPort.SelectedItem.ToString(), sCommSetting);
            }
            catch
            {
                MessageBox.Show("通訊格式不對");
                return;
            }
            sComport = (cmoCommPort.SelectedIndex + 1).ToString();
            simPLC.Close();
            simPLC.Port(cmoCommPort.SelectedItem.ToString());
            simPLC.Open();
            if (simPLC.PLC_COM.IsOpen)
            {
                btnOpenComm.BackColor = Color.Lime;
                btnCloseComm.BackColor = Color.LightGray;
            }
            else
            {
                btnCloseComm.BackColor = Color.Lime;
                btnOpenComm.BackColor = Color.LightGray;
            }
        }

        private void chkOnTop_Click(object sender, EventArgs e)
        {
            this.TopMost = chkOnTop.Checked;
        }

        private void chkMtoY_Click(object sender, EventArgs e)
        {
            MtoY_Flag = chkMtoY.Checked;
        }

        private void btnLoadAction_Click(object sender, EventArgs e)
        {
            OpenFileDialog1.Filter = "ACT Files|*.act";
            //OpenFileDialog1.InitialDirectory = FileSystem.CurDir();
            OpenFileDialog1.Multiselect = false;
            OpenFileDialog1.AddExtension = true;
            OpenFileDialog1.AutoUpgradeEnabled = true;
            OpenFileDialog1.CheckFileExists = true;
            OpenFileDialog1.CheckPathExists = true;
            OpenFileDialog1.DefaultExt = ".act";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(OpenFileDialog1.FileName))
                {
                    ActionReadFileName = OpenFileDialog1.FileName;
                    lblActionFileName.Text = ActionReadFileName;
                    LoadAction(out CAction, ActionReadFileName);
                    ReadPLCIOName(ActionReadFileName);
                    ReadPLCLog(ActionReadFileName);
                }
            }
        }
        public void LoadAction(out SAction[] SA, string sfile)
        {
            int i, j;
            string[] astr = new string[301];
            string[] bstr;
            i = 0;
            SA = new SAction[301];

            DataGridView1.Rows.Clear();
            do
            {
                astr[i] = ReadProgData("ACTION", "ACT" + i.ToString("D3"), "NONE", sfile);
                if (astr[i] == "NONE")
                    break;
                bstr = astr[i].Split(',');
                if (bstr.Length >= 3)
                {
                    if (bstr.Length == 0)
                        break;
                    if (bstr.Length > 0)
                        SA[i].Source = bstr[0];
                    if (bstr.Length > 1)
                        SA[i].Method = bstr[1];
                    if (bstr.Length > 2)
                        SA[i].Dest = bstr[2];
                    if (bstr.Length > 3)
                        SA[i].Delay = bstr[3];
                    if (bstr.Length > 4)
                        SA[i].TargetValue = bstr[4];
                    DataGridView1.Rows.Add(SA[i].Source, SA[i].Method, SA[i].Dest, SA[i].Delay, SA[i].TargetValue);
                }

                i += 1;
            }
            while (true);
        }

        private void btnSaveAction_Click(object sender, EventArgs e)
        {
            SaveFileDialog1.Filter = "ACT Files|*.act";
            //SaveFileDialog1.InitialDirectory = FileSystem.CurDir();
            SaveFileDialog1.AddExtension = true;
            SaveFileDialog1.DefaultExt = ".act";
            SaveFileDialog1.ShowDialog();
            if (System.IO.File.Exists(SaveFileDialog1.FileName))
                System.IO.File.Delete(SaveFileDialog1.FileName);
            ActionWriteFileName = SaveFileDialog1.FileName;
            SaveAction(CAction, ActionWriteFileName);
            WritePLCIOName(ActionWriteFileName);
            WritePLCLog(ActionWriteFileName);
        }
        public void SaveAction(SAction[] SA, string sfile)
        {

            int i;
            string astr;

            i = 0;
            for (i = 0; i <= DataGridView1.RowCount - 2; i++)
            {
                if (DataGridView1.Rows[i].Cells[0].Value.ToString() == "")
                    break;
                SA[i].Source = DataGridView1.Rows[i].Cells[0].Value.ToString();
                SA[i].Method = DataGridView1.Rows[i].Cells[1].Value.ToString();
                SA[i].Dest = DataGridView1.Rows[i].Cells[2].Value.ToString();
                SA[i].Delay = DataGridView1.Rows[i].Cells[3].Value.ToString();
                SA[i].TargetValue = DataGridView1.Rows[i].Cells[4].Value.ToString();
                astr = SA[i].Source + "," + SA[i].Method + "," + SA[i].Dest + "," + SA[i].Delay + "," + SA[i].TargetValue;
                WriteProgData("ACTION", "ACT" + i.ToString("D3"), astr, sfile);
            }
        }

        private void WritePLCIOName(string sfile)
        {
            int i;
            for (i = 0; i <= 95; i++)
                WriteProgData("X_NAME", "lblX" + i.ToString("D2"), X_Name[i], sfile);
            for (i = 0; i <= 191; i++)
            {
                WriteProgData("Y_NAME", "lblY" + i.ToString("D2"), Y_Name[i], sfile);
                WriteProgData("M_NAME", "lblY" + i.ToString("D2"), M_Name[i], sfile);
                WriteProgData("RR_NAME", "txtRR" + i.ToString("D2"), RR_Name[i], sfile);
                WriteProgData("RW_NAME", "txtRW" + i.ToString("D2"), RW_Name[i], sfile);
            }
        }
        private void WritePLCLog(string sfile)
        {
            int i;
            for (i = 0; i <= 95; i++)
                WriteProgData("PLC_X", "X" + i.ToString("D2"), Bol2Str(X_Bit[i]), sfile);
            for (i = 0; i <= 191; i++)
            {
                WriteProgData("PLC_Y", "Y" + i.ToString("D2"), Bol2Str(Y_Bit[i]), sfile);
                WriteProgData("PLC_M", "M" + i.ToString("D2"), Bol2Str(M_Bit[i]), sfile);
                WriteProgData("PLC_RR", "R010" + i.ToString("D2"), R_Read[i].Text, sfile);
                WriteProgData("PLC_RW", "R011" + i.ToString("D2"), R_Write[i].Text, sfile);
            }
        }

        public string Bol2Str(bool bol)
        {
            if (bol)
                return "1";
            else
                return "0";
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            ActionFlag = !ActionFlag;
            if (ActionFlag)
                btnAction.BackColor = Color.Lime;
            else
                btnAction.BackColor = Color.LightGray;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ReloadAction(ref CAction);
        }
        public void ReloadAction(ref SAction[] SA)
        {
            int i;
            i = 0;

            for (i = 0; i <= DataGridView1.RowCount - 1; i++)
            {
                if (DataGridView1.Rows[i].Cells[0].Value == null)
                    break;
                SA[i].Source = DataGridView1.Rows[i].Cells[0].Value.ToString();
                SA[i].Method = DataGridView1.Rows[i].Cells[1].Value.ToString();
                SA[i].Dest = DataGridView1.Rows[i].Cells[2].Value.ToString();
                SA[i].Delay = DataGridView1.Rows[i].Cells[3].Value.ToString();
                SA[i].TargetValue = DataGridView1.Rows[i].Cells[4].Value.ToString();
            }
        }

        private void btnPocketGood_Click(System.Object sender, System.EventArgs e)
        {
            int mm;
            mm = Convert.ToInt32(PLC_PockInpositionY.Substring(2 - 1, 4));
            M_Bit[mm] = !M_Bit[mm];
            string aa;
            if (M_Bit[mm])
                aa = "1";
            else
                aa = "0";
            UDPSendToXTC3(PLC_IP, PLC_OUTPORT, PLC_PockInpositionY, aa);
        }
        public void UDPSendToXTC3(string sIP, int port, string Element, string value)
        {
            UdpClient myUDPClient = new UdpClient();
            IPAddress ServerIpAddress;
            string ip = "127.0.0.1";
            try
            {
                ServerIpAddress = IPAddress.Parse(sIP);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server IP設定錯誤");
                return;
            }
            int iPort;
            iPort = port;
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(ServerIpAddress, iPort);
            byte[] myBytes;
            myBytes = Encoding.GetEncoding(950).GetBytes((Element + "," + value));//Claire 要再加上Trim
            if (myBytes.Length > 0)
                myUDPClient.Send(myBytes, myBytes.Length, RemoteIpEndPoint);
            else
                MessageBox.Show("無資料可傳送!!");
        }

        public void TimeDelay(int t)
        {

            int i;
            for (i = 0; i < 10; i++)
            {
                if (!WDog[i].IsRunning)
                {
                    WDog[i].Restart();
                    break;
                }
            }
            while (true)
            {
                Application.DoEvents();
                if (WDog[i].ElapsedMilliseconds > t)
                    break;
            }
            WDog[i].Stop();

        }
        public string CheckSumFB(string sstr)
        {
            int iCheckSum;
            string sCheckSum;

            //iCheckSum = 0;
            iCheckSum = 2;
            for (int i = 1; i <= sstr.Length; i++)
            {

                string str = sstr.Substring(i - 1, 1);
                byte[] array = System.Text.Encoding.ASCII.GetBytes(str);
                int asciicode = (int)(array[0]);
                iCheckSum = iCheckSum + asciicode;
            }
            //sCheckSum = Strings.Right(iCheckSum.ToString ("X"), 2);
            sCheckSum = iCheckSum.ToString("X").Substring(iCheckSum.ToString("X").Length - 2, 2);


            if (sCheckSum.Length < 2)
                sCheckSum = "0" + sCheckSum;
            return sCheckSum;
        }
        public string HexZero(int nnum, int Lenght)
        {
            int i, llen;
            string sstr;
            sstr = nnum.ToString("X");
            llen = sstr.Length;
            if (llen == Lenght)
                return sstr;
            if (llen > 4)
                sstr = sstr.Substring(llen - 3 - 1, 4);
            for (i = llen; i <= Lenght - 1; i++)
                sstr = "0" + sstr;
            return sstr;
        }

        private void DataClone()
        {
            System.Buffer.BlockCopy(X_Bit, 0, X_Bit_old, 0, 1000);
            System.Buffer.BlockCopy(Y_Bit, 0, Y_Bit_old, 0, 1000);
            if (MtoY_Flag)
                System.Buffer.BlockCopy(M_Bit, 0, Y_Bit, 0, 1000);
            System.Buffer.BlockCopy(M_Bit, 0, M_Bit_old, 0, 1000);
            System.Buffer.BlockCopy(RR_Word, 0, RR_Word_old, 0, 1000);
            System.Buffer.BlockCopy(RW_Word, 0, RW_Word_old, 0, 1000);
            System.Buffer.BlockCopy(RW_Word_Writed, 0, RW_Word_Writed_old, 0, 1000);
            System.Buffer.BlockCopy(RR_Word_Writed, 0, RR_Word_Writed_old, 0, 1000);
            System.Buffer.BlockCopy(DD_Word, 0, DD_Word_old, 0, 1000);
        }
        public struct SAction
        {
            public string Source;
            public string Method;
            public string Delay;
            public string Dest;
            public string TargetValue;
        }

        public void InitThread()
        {
            //建立多執行緒 
            ProcessThread = new Thread(new ThreadStart(StatusThreading));
            ProcessThread.IsBackground = true;
            ProcessThread.Start();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            threadStop = true;
            ReadPLCIOName(INIpath + "\\SIMFBPLC.INI");
            WritePLCLog(INIpath + "\\PLCIOSAVE.INI");
            //WritePLCINI(@".\SIMFBPLC.INI");
            WritePLCINI(INIpath + "\\SIMFBPLC.INI");
            simPLC.Close();
            System.Environment.Exit(0);
        }

        public void StatusThreading()
        {
            while (!threadStop)
            {
                for (int i = 0; i <= 95; i++)
                {
                    if (X_Bit[i] != X_Bit_old[i])
                        UpdateX_Bit(i);
                }
                for (int i = 0; i <= 191; i++)
                {
                    if (Y_Bit[i] != Y_Bit_old[i])
                        UpdateY_Bit(i);
                }
                for (int i = 0; i <= 191; i++)
                {
                    if (M_Bit[i] != M_Bit_old[i])
                        UpdateM_Bit(i);
                    if (M_Bit[35])
                        btnPocketGood.BackColor = Color.Lime;
                    else
                        btnPocketGood.BackColor = Color.WhiteSmoke;
                }
                for (int i = 0; i <= 191; i++)
                {
                    if (RR_Word[i] != RR_Word_old[i])

                        UpdateRR_Word(i);
                }
                for (int i = 0; i <= 191; i++)
                {
                    if (RW_Word[i] != RW_Word_old[i])
                    {
                        UpdateRW_Word(i);

                    }
                    if (RW_Word_Writed[i] > 0)
                    {
                        R_Write[i].BackColor = Color.Pink;
                        RW_Word_Writed[i] += 1;
                        if (RW_Word_Writed[i] > 30)
                        {
                            RW_Word_Writed[i] = 0;
                            R_Write[i].BackColor = Color.White;
                        }
                    }
                }

                DataClone();
                Thread.Sleep(100);
            }
        }
        private void chkMtoY_CheckedChanged(object sender, EventArgs e)
        {
            MtoY_Flag = chkMtoY.Checked;
        }

        private void chkOnTop_CheckedChanged(object sender, EventArgs e)
        {
            bTopmost = chkOnTop.Checked;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
        }

        private void UpdateX_Bit(int index)
        {
            if (X_Status[index].InvokeRequired)
            {
                X_Status[index].Invoke(new Action(() =>
                {
                    UpdateX_Bit(index);

                }
                ));
            }
            else
            {
                if (X_Bit[index])
                    X_Status[index].BackColor = Color.Lime;
                else
                    X_Status[index].BackColor = Color.Red;
            }
        }
        private void UpdateY_Bit(int index)
        {
            if (Y_Status[index].InvokeRequired)
            {
                Y_Status[index].Invoke(new Action(() =>
                {
                    UpdateY_Bit(index);
                }
                ));
            }
            else
            {
                if (Y_Bit[index])
                    Y_Status[index].BackColor = Color.Lime;
                else
                    Y_Status[index].BackColor = Color.Red;
            }

        }
        private void UpdateM_Bit(int index)
        {
            if (M_Status[index].InvokeRequired)
            {
                M_Status[index].Invoke(new Action(() =>
                {
                    UpdateM_Bit(index);
                }
                ));
            }
            else
            {
                if (M_Bit[index])
                    M_Status[index].BackColor = Color.Lime;
                else
                    M_Status[index].BackColor = Color.Red;
                if (index == 35)
                {
                    if (M_Bit[35])
                        btnPocketGood.BackColor = Color.Lime;
                    else
                        btnPocketGood.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void UpdateRR_Word(int index)
        {
            if (R_Read[index].InvokeRequired)
            {
                R_Read[index].Invoke(new Action(() =>
                {
                    UpdateRR_Word(index);
                }
                ));
            }
            else
            {
                R_Read[index].Text = RR_Word[index].ToString();
            }

        }
        private void UpdateRW_Word(int index)
        {
            if (R_Write[index].InvokeRequired)
            {
                R_Write[index].Invoke(new Action(() =>
                {
                    UpdateRW_Word(index);
                }
                ));
            }
            else
            {
                R_Write[index].Text = RW_Word[index].ToString();
            }

        }

        private void WritePLCINI(string sfile)
        {
            WriteProgData("COMM_SETUP", "COMPORT", (cmoCommPort.SelectedIndex + 1).ToString(), sfile);
            WriteProgData("COMM_SETUP", "SETTING", sCommSetting, sfile);
            WriteProgData("PROGRAM", "TOPMOST", Bol2Str(chkOnTop.Checked), sfile);
            WriteProgData("PROGRAM", "MTOYFLAG", Bol2Str(chkMtoY.Checked), sfile);
            WriteProgData("PROGRAM", "XINDEX", txtXInputIndex.Text, sfile);
            WriteProgData("PROGRAM", "MINDEX", txtMOutputIndex.Text, sfile);
            WriteProgData("PROGRAM", "YINDEX", txtYOutputIndex.Text, sfile);
            WriteProgData("PROGRAM", "RRINDEX", txtReadWordIndex.Text, sfile);
            WriteProgData("PROGRAM", "RWINDEX", txtWriteWordIndex.Text, sfile);
            WriteProgData("PROGRAM", "DELAY", CmdDelay.ToString(), sfile);
        }
        //private void Form1_Disposed(object sender, System.EventArgs e)
        //{
        //    ReadPLCIOName(INIpath + "\\SIMFBPLC.INI");
        //    WritePLCLog(INIpath + "\\PLCIOSAVE.INI");
        //    //WritePLCINI(@".\SIMFBPLC.INI");
        //    WritePLCINI(INIpath + "\\SIMFBPLC.INI");
        //    simPLC.Close();
        //    System.Environment.Exit(0);
        //}
    }
}
