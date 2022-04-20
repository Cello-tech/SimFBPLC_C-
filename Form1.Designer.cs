
namespace SimFBPLC
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabSimPLC = new System.Windows.Forms.TabControl();
            this.tabPageXInput = new System.Windows.Forms.TabPage();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnCap = new System.Windows.Forms.Button();
            this.lblXName = new System.Windows.Forms.Label();
            this.txtXInputIndex = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.tabPageMOutput = new System.Windows.Forms.TabPage();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.lblMName = new System.Windows.Forms.Label();
            this.txtMOutputIndex = new System.Windows.Forms.TextBox();
            this.btnMOutputNextPage = new System.Windows.Forms.Button();
            this.btnMOutputPrevPage = new System.Windows.Forms.Button();
            this.tabPageYOutput = new System.Windows.Forms.TabPage();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.lblYName = new System.Windows.Forms.Label();
            this.txtYOutputIndex = new System.Windows.Forms.TextBox();
            this.btnYOutputNextPage = new System.Windows.Forms.Button();
            this.btnYOutputPrevPage = new System.Windows.Forms.Button();
            this.tabPageRRead = new System.Windows.Forms.TabPage();
            this.lblRRName = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.btnReadNextPage = new System.Windows.Forms.Button();
            this.btnReadPrevPage = new System.Windows.Forms.Button();
            this.txtReadWordIndex = new System.Windows.Forms.TextBox();
            this.tabPageRWrite = new System.Windows.Forms.TabPage();
            this.lblRWName = new System.Windows.Forms.Label();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.btnWriteNextPage = new System.Windows.Forms.Button();
            this.btnWritePrevPage = new System.Windows.Forms.Button();
            this.txtWriteWordIndex = new System.Windows.Forms.TextBox();
            this.TabPageOption = new System.Windows.Forms.TabPage();
            this.lblActionFileName = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnAction = new System.Windows.Forms.Button();
            this.btnLoadAction = new System.Windows.Forms.Button();
            this.btnSaveAction = new System.Windows.Forms.Button();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTargetValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkMtoY = new System.Windows.Forms.CheckBox();
            this.chkOnTop = new System.Windows.Forms.CheckBox();
            this.btnCloseComm = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnReloadPLCIO = new System.Windows.Forms.Button();
            this.btnOpenComm = new System.Windows.Forms.Button();
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.txtCommSetting = new System.Windows.Forms.TextBox();
            this.cmoCommPort = new System.Windows.Forms.ComboBox();
            this.tpgXTC3 = new System.Windows.Forms.TabPage();
            this.grpPLCOutputSetup = new System.Windows.Forms.GroupBox();
            this.btnPocketGood = new System.Windows.Forms.Button();
            this.txtPowerOutR = new System.Windows.Forms.TextBox();
            this.lblPowerOutRText = new System.Windows.Forms.Label();
            this.txtPockInpositionY = new System.Windows.Forms.TextBox();
            this.lblPockInpositionYText = new System.Windows.Forms.Label();
            this.grpPLCInputSetup = new System.Windows.Forms.GroupBox();
            this.txtCrystalFailX = new System.Windows.Forms.TextBox();
            this.lblCrystalFailXText = new System.Windows.Forms.Label();
            this.txtDepSHX = new System.Windows.Forms.TextBox();
            this.lblDepSHXText = new System.Windows.Forms.Label();
            this.txtDepCompleteX = new System.Windows.Forms.TextBox();
            this.lblDepCompleteXText = new System.Windows.Forms.Label();
            this.txtDepSensor2lX = new System.Windows.Forms.TextBox();
            this.lblDepSensor2lXText = new System.Windows.Forms.Label();
            this.grpIPPortSetup = new System.Windows.Forms.GroupBox();
            this.txtPLCLinkIP = new System.Windows.Forms.TextBox();
            this.lblPLCLinkIPText = new System.Windows.Forms.Label();
            this.txtLinkInPort = new System.Windows.Forms.TextBox();
            this.lblLinkOutPortText = new System.Windows.Forms.Label();
            this.lblLinkInPortText = new System.Windows.Forms.Label();
            this.txtLinkOutPort = new System.Windows.Forms.TextBox();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.Timer2 = new System.Windows.Forms.Timer(this.components);
            this.Help = new System.Windows.Forms.ToolTip(this.components);
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabSimPLC.SuspendLayout();
            this.tabPageXInput.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.tabPageMOutput.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.tabPageYOutput.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.tabPageRRead.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.tabPageRWrite.SuspendLayout();
            this.Panel5.SuspendLayout();
            this.TabPageOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.tpgXTC3.SuspendLayout();
            this.grpPLCOutputSetup.SuspendLayout();
            this.grpPLCInputSetup.SuspendLayout();
            this.grpIPPortSetup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSimPLC
            // 
            this.tabSimPLC.Controls.Add(this.tabPageXInput);
            this.tabSimPLC.Controls.Add(this.tabPageMOutput);
            this.tabSimPLC.Controls.Add(this.tabPageYOutput);
            this.tabSimPLC.Controls.Add(this.tabPageRRead);
            this.tabSimPLC.Controls.Add(this.tabPageRWrite);
            this.tabSimPLC.Controls.Add(this.TabPageOption);
            this.tabSimPLC.Controls.Add(this.tpgXTC3);
            this.tabSimPLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSimPLC.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabSimPLC.ItemSize = new System.Drawing.Size(96, 24);
            this.tabSimPLC.Location = new System.Drawing.Point(0, 0);
            this.tabSimPLC.Margin = new System.Windows.Forms.Padding(0);
            this.tabSimPLC.Multiline = true;
            this.tabSimPLC.Name = "tabSimPLC";
            this.tabSimPLC.SelectedIndex = 0;
            this.tabSimPLC.Size = new System.Drawing.Size(917, 665);
            this.tabSimPLC.TabIndex = 1;
            // 
            // tabPageXInput
            // 
            this.tabPageXInput.Controls.Add(this.Panel1);
            this.tabPageXInput.Location = new System.Drawing.Point(4, 28);
            this.tabPageXInput.Name = "tabPageXInput";
            this.tabPageXInput.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageXInput.Size = new System.Drawing.Size(909, 633);
            this.tabPageXInput.TabIndex = 0;
            this.tabPageXInput.Text = "X 輸入點";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Panel1.Controls.Add(this.btnCap);
            this.Panel1.Controls.Add(this.lblXName);
            this.Panel1.Controls.Add(this.txtXInputIndex);
            this.Panel1.Controls.Add(this.Button1);
            this.Panel1.Controls.Add(this.Button2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel1.Location = new System.Drawing.Point(810, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(96, 627);
            this.Panel1.TabIndex = 0;
            // 
            // btnCap
            // 
            this.btnCap.Location = new System.Drawing.Point(16, 631);
            this.btnCap.Name = "btnCap";
            this.btnCap.Size = new System.Drawing.Size(77, 27);
            this.btnCap.TabIndex = 9;
            this.btnCap.Text = "下一頁";
            this.btnCap.UseVisualStyleBackColor = true;
            // 
            // lblXName
            // 
            this.lblXName.Location = new System.Drawing.Point(3, 99);
            this.lblXName.Name = "lblXName";
            this.lblXName.Size = new System.Drawing.Size(93, 71);
            this.lblXName.TabIndex = 8;
            this.lblXName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtXInputIndex
            // 
            this.txtXInputIndex.Location = new System.Drawing.Point(5, 3);
            this.txtXInputIndex.Name = "txtXInputIndex";
            this.txtXInputIndex.Size = new System.Drawing.Size(61, 27);
            this.txtXInputIndex.TabIndex = 7;
            this.txtXInputIndex.Text = "X0000";
            this.txtXInputIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(5, 69);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(77, 27);
            this.Button1.TabIndex = 6;
            this.Button1.Text = "下一頁";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Visible = false;
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(5, 36);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(77, 27);
            this.Button2.TabIndex = 5;
            this.Button2.Text = "上一頁";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Visible = false;
            // 
            // tabPageMOutput
            // 
            this.tabPageMOutput.Controls.Add(this.Panel2);
            this.tabPageMOutput.Location = new System.Drawing.Point(4, 28);
            this.tabPageMOutput.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageMOutput.Name = "tabPageMOutput";
            this.tabPageMOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMOutput.Size = new System.Drawing.Size(909, 633);
            this.tabPageMOutput.TabIndex = 1;
            this.tabPageMOutput.Text = "M 記憶點";
            this.tabPageMOutput.UseVisualStyleBackColor = true;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Panel2.Controls.Add(this.lblMName);
            this.Panel2.Controls.Add(this.txtMOutputIndex);
            this.Panel2.Controls.Add(this.btnMOutputNextPage);
            this.Panel2.Controls.Add(this.btnMOutputPrevPage);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel2.Location = new System.Drawing.Point(810, 3);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(96, 627);
            this.Panel2.TabIndex = 1;
            // 
            // lblMName
            // 
            this.lblMName.Location = new System.Drawing.Point(2, 109);
            this.lblMName.Name = "lblMName";
            this.lblMName.Size = new System.Drawing.Size(93, 71);
            this.lblMName.TabIndex = 11;
            this.lblMName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMOutputIndex
            // 
            this.txtMOutputIndex.Location = new System.Drawing.Point(5, 3);
            this.txtMOutputIndex.Name = "txtMOutputIndex";
            this.txtMOutputIndex.Size = new System.Drawing.Size(61, 27);
            this.txtMOutputIndex.TabIndex = 10;
            this.txtMOutputIndex.Text = "M0000";
            this.txtMOutputIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMOutputNextPage
            // 
            this.btnMOutputNextPage.Location = new System.Drawing.Point(5, 69);
            this.btnMOutputNextPage.Name = "btnMOutputNextPage";
            this.btnMOutputNextPage.Size = new System.Drawing.Size(77, 27);
            this.btnMOutputNextPage.TabIndex = 9;
            this.btnMOutputNextPage.Text = "下一頁";
            this.btnMOutputNextPage.UseVisualStyleBackColor = true;
            this.btnMOutputNextPage.Visible = false;
            // 
            // btnMOutputPrevPage
            // 
            this.btnMOutputPrevPage.Location = new System.Drawing.Point(5, 36);
            this.btnMOutputPrevPage.Name = "btnMOutputPrevPage";
            this.btnMOutputPrevPage.Size = new System.Drawing.Size(77, 27);
            this.btnMOutputPrevPage.TabIndex = 8;
            this.btnMOutputPrevPage.Text = "上一頁";
            this.btnMOutputPrevPage.UseVisualStyleBackColor = true;
            this.btnMOutputPrevPage.Visible = false;
            // 
            // tabPageYOutput
            // 
            this.tabPageYOutput.Controls.Add(this.Panel3);
            this.tabPageYOutput.Location = new System.Drawing.Point(4, 28);
            this.tabPageYOutput.Name = "tabPageYOutput";
            this.tabPageYOutput.Size = new System.Drawing.Size(909, 633);
            this.tabPageYOutput.TabIndex = 2;
            this.tabPageYOutput.Text = "Y 輸出點";
            this.tabPageYOutput.UseVisualStyleBackColor = true;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Panel3.Controls.Add(this.lblYName);
            this.Panel3.Controls.Add(this.txtYOutputIndex);
            this.Panel3.Controls.Add(this.btnYOutputNextPage);
            this.Panel3.Controls.Add(this.btnYOutputPrevPage);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel3.Location = new System.Drawing.Point(813, 0);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(96, 633);
            this.Panel3.TabIndex = 1;
            // 
            // lblYName
            // 
            this.lblYName.Location = new System.Drawing.Point(2, 112);
            this.lblYName.Name = "lblYName";
            this.lblYName.Size = new System.Drawing.Size(93, 71);
            this.lblYName.TabIndex = 14;
            this.lblYName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtYOutputIndex
            // 
            this.txtYOutputIndex.Location = new System.Drawing.Point(5, 3);
            this.txtYOutputIndex.Name = "txtYOutputIndex";
            this.txtYOutputIndex.Size = new System.Drawing.Size(61, 27);
            this.txtYOutputIndex.TabIndex = 13;
            this.txtYOutputIndex.Text = "Y0000";
            this.txtYOutputIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnYOutputNextPage
            // 
            this.btnYOutputNextPage.Location = new System.Drawing.Point(5, 69);
            this.btnYOutputNextPage.Name = "btnYOutputNextPage";
            this.btnYOutputNextPage.Size = new System.Drawing.Size(77, 27);
            this.btnYOutputNextPage.TabIndex = 12;
            this.btnYOutputNextPage.Text = "下一頁";
            this.btnYOutputNextPage.UseVisualStyleBackColor = true;
            this.btnYOutputNextPage.Visible = false;
            // 
            // btnYOutputPrevPage
            // 
            this.btnYOutputPrevPage.Location = new System.Drawing.Point(5, 36);
            this.btnYOutputPrevPage.Name = "btnYOutputPrevPage";
            this.btnYOutputPrevPage.Size = new System.Drawing.Size(77, 27);
            this.btnYOutputPrevPage.TabIndex = 11;
            this.btnYOutputPrevPage.Text = "上一頁";
            this.btnYOutputPrevPage.UseVisualStyleBackColor = true;
            this.btnYOutputPrevPage.Visible = false;
            // 
            // tabPageRRead
            // 
            this.tabPageRRead.Controls.Add(this.lblRRName);
            this.tabPageRRead.Controls.Add(this.Panel4);
            this.tabPageRRead.Location = new System.Drawing.Point(4, 28);
            this.tabPageRRead.Name = "tabPageRRead";
            this.tabPageRRead.Size = new System.Drawing.Size(909, 633);
            this.tabPageRRead.TabIndex = 3;
            this.tabPageRRead.Text = "讀取暫存器";
            this.tabPageRRead.UseVisualStyleBackColor = true;
            // 
            // lblRRName
            // 
            this.lblRRName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblRRName.Location = new System.Drawing.Point(8, 609);
            this.lblRRName.Name = "lblRRName";
            this.lblRRName.Size = new System.Drawing.Size(297, 22);
            this.lblRRName.TabIndex = 15;
            this.lblRRName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Panel4.Controls.Add(this.btnReadNextPage);
            this.Panel4.Controls.Add(this.btnReadPrevPage);
            this.Panel4.Controls.Add(this.txtReadWordIndex);
            this.Panel4.Location = new System.Drawing.Point(640, 597);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(573, 34);
            this.Panel4.TabIndex = 1;
            this.Panel4.Visible = false;
            // 
            // btnReadNextPage
            // 
            this.btnReadNextPage.Location = new System.Drawing.Point(484, 1);
            this.btnReadNextPage.Name = "btnReadNextPage";
            this.btnReadNextPage.Size = new System.Drawing.Size(77, 27);
            this.btnReadNextPage.TabIndex = 4;
            this.btnReadNextPage.Text = "下一頁";
            this.btnReadNextPage.UseVisualStyleBackColor = true;
            // 
            // btnReadPrevPage
            // 
            this.btnReadPrevPage.Location = new System.Drawing.Point(401, 1);
            this.btnReadPrevPage.Name = "btnReadPrevPage";
            this.btnReadPrevPage.Size = new System.Drawing.Size(77, 27);
            this.btnReadPrevPage.TabIndex = 4;
            this.btnReadPrevPage.Text = "上一頁";
            this.btnReadPrevPage.UseVisualStyleBackColor = true;
            // 
            // txtReadWordIndex
            // 
            this.txtReadWordIndex.Location = new System.Drawing.Point(4, 1);
            this.txtReadWordIndex.Name = "txtReadWordIndex";
            this.txtReadWordIndex.Size = new System.Drawing.Size(88, 27);
            this.txtReadWordIndex.TabIndex = 0;
            this.txtReadWordIndex.Text = "R01000";
            this.txtReadWordIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPageRWrite
            // 
            this.tabPageRWrite.Controls.Add(this.lblRWName);
            this.tabPageRWrite.Controls.Add(this.Panel5);
            this.tabPageRWrite.Location = new System.Drawing.Point(4, 28);
            this.tabPageRWrite.Name = "tabPageRWrite";
            this.tabPageRWrite.Size = new System.Drawing.Size(909, 633);
            this.tabPageRWrite.TabIndex = 4;
            this.tabPageRWrite.Text = "寫入暫存器";
            this.tabPageRWrite.UseVisualStyleBackColor = true;
            // 
            // lblRWName
            // 
            this.lblRWName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblRWName.Location = new System.Drawing.Point(8, 609);
            this.lblRWName.Name = "lblRWName";
            this.lblRWName.Size = new System.Drawing.Size(297, 22);
            this.lblRWName.TabIndex = 16;
            this.lblRWName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel5
            // 
            this.Panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Panel5.Controls.Add(this.btnWriteNextPage);
            this.Panel5.Controls.Add(this.btnWritePrevPage);
            this.Panel5.Controls.Add(this.txtWriteWordIndex);
            this.Panel5.Location = new System.Drawing.Point(646, 603);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(580, 33);
            this.Panel5.TabIndex = 1;
            this.Panel5.Visible = false;
            // 
            // btnWriteNextPage
            // 
            this.btnWriteNextPage.Location = new System.Drawing.Point(495, 3);
            this.btnWriteNextPage.Name = "btnWriteNextPage";
            this.btnWriteNextPage.Size = new System.Drawing.Size(77, 27);
            this.btnWriteNextPage.TabIndex = 6;
            this.btnWriteNextPage.Text = "下一頁";
            this.btnWriteNextPage.UseVisualStyleBackColor = true;
            // 
            // btnWritePrevPage
            // 
            this.btnWritePrevPage.Location = new System.Drawing.Point(402, 3);
            this.btnWritePrevPage.Name = "btnWritePrevPage";
            this.btnWritePrevPage.Size = new System.Drawing.Size(77, 27);
            this.btnWritePrevPage.TabIndex = 5;
            this.btnWritePrevPage.Text = "上一頁";
            this.btnWritePrevPage.UseVisualStyleBackColor = true;
            // 
            // txtWriteWordIndex
            // 
            this.txtWriteWordIndex.Location = new System.Drawing.Point(5, 3);
            this.txtWriteWordIndex.Name = "txtWriteWordIndex";
            this.txtWriteWordIndex.Size = new System.Drawing.Size(88, 27);
            this.txtWriteWordIndex.TabIndex = 4;
            this.txtWriteWordIndex.Text = "R01100";
            this.txtWriteWordIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TabPageOption
            // 
            this.TabPageOption.Controls.Add(this.lblActionFileName);
            this.TabPageOption.Controls.Add(this.btnReload);
            this.TabPageOption.Controls.Add(this.btnAction);
            this.TabPageOption.Controls.Add(this.btnLoadAction);
            this.TabPageOption.Controls.Add(this.btnSaveAction);
            this.TabPageOption.Controls.Add(this.DataGridView1);
            this.TabPageOption.Controls.Add(this.chkMtoY);
            this.TabPageOption.Controls.Add(this.chkOnTop);
            this.TabPageOption.Controls.Add(this.btnCloseComm);
            this.TabPageOption.Controls.Add(this.Label2);
            this.TabPageOption.Controls.Add(this.Label4);
            this.TabPageOption.Controls.Add(this.Label3);
            this.TabPageOption.Controls.Add(this.Label1);
            this.TabPageOption.Controls.Add(this.btnReloadPLCIO);
            this.TabPageOption.Controls.Add(this.btnOpenComm);
            this.TabPageOption.Controls.Add(this.txtDelay);
            this.TabPageOption.Controls.Add(this.txtCommSetting);
            this.TabPageOption.Controls.Add(this.cmoCommPort);
            this.TabPageOption.Location = new System.Drawing.Point(4, 28);
            this.TabPageOption.Name = "TabPageOption";
            this.TabPageOption.Size = new System.Drawing.Size(909, 633);
            this.TabPageOption.TabIndex = 5;
            this.TabPageOption.Text = "選項";
            this.TabPageOption.UseVisualStyleBackColor = true;
            // 
            // lblActionFileName
            // 
            this.lblActionFileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblActionFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblActionFileName.Location = new System.Drawing.Point(3, 135);
            this.lblActionFileName.Name = "lblActionFileName";
            this.lblActionFileName.Size = new System.Drawing.Size(570, 22);
            this.lblActionFileName.TabIndex = 9;
            this.lblActionFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(424, 160);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(95, 25);
            this.btnReload.TabIndex = 8;
            this.btnReload.Text = "更新";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(281, 160);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(95, 25);
            this.btnAction.TabIndex = 7;
            this.btnAction.Text = "動作開始";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnLoadAction
            // 
            this.btnLoadAction.Location = new System.Drawing.Point(3, 160);
            this.btnLoadAction.Name = "btnLoadAction";
            this.btnLoadAction.Size = new System.Drawing.Size(95, 25);
            this.btnLoadAction.TabIndex = 6;
            this.btnLoadAction.Text = "載入動作";
            this.btnLoadAction.UseVisualStyleBackColor = true;
            this.btnLoadAction.Click += new System.EventHandler(this.btnLoadAction_Click);
            // 
            // btnSaveAction
            // 
            this.btnSaveAction.Location = new System.Drawing.Point(146, 160);
            this.btnSaveAction.Name = "btnSaveAction";
            this.btnSaveAction.Size = new System.Drawing.Size(95, 25);
            this.btnSaveAction.TabIndex = 5;
            this.btnSaveAction.Text = "存檔";
            this.btnSaveAction.UseVisualStyleBackColor = true;
            this.btnSaveAction.Click += new System.EventHandler(this.btnSaveAction_Click);
            // 
            // DataGridView1
            // 
            this.DataGridView1.BackgroundColor = System.Drawing.Color.MintCream;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSource,
            this.colMethod,
            this.ColDest,
            this.ColDelay,
            this.ColTargetValue});
            this.DataGridView1.Location = new System.Drawing.Point(0, 191);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowTemplate.Height = 24;
            this.DataGridView1.Size = new System.Drawing.Size(573, 420);
            this.DataGridView1.TabIndex = 4;
            // 
            // colSource
            // 
            this.colSource.HeaderText = "來源元件";
            this.colSource.Name = "colSource";
            // 
            // colMethod
            // 
            this.colMethod.HeaderText = "累加值";
            this.colMethod.Name = "colMethod";
            this.colMethod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMethod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDest
            // 
            this.ColDest.HeaderText = "目的元件";
            this.ColDest.Name = "ColDest";
            this.ColDest.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDest.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDelay
            // 
            this.ColDelay.HeaderText = "延遲時間";
            this.ColDelay.Name = "ColDelay";
            // 
            // ColTargetValue
            // 
            this.ColTargetValue.HeaderText = "目標值(方法)";
            this.ColTargetValue.Name = "ColTargetValue";
            this.ColTargetValue.Width = 120;
            // 
            // chkMtoY
            // 
            this.chkMtoY.AutoSize = true;
            this.chkMtoY.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkMtoY.Location = new System.Drawing.Point(142, 82);
            this.chkMtoY.Name = "chkMtoY";
            this.chkMtoY.Size = new System.Drawing.Size(160, 20);
            this.chkMtoY.TabIndex = 1;
            this.chkMtoY.Text = "M 記憶點輸出到Y";
            this.chkMtoY.UseVisualStyleBackColor = true;
            this.chkMtoY.Click += new System.EventHandler(this.chkMtoY_Click);
            // 
            // chkOnTop
            // 
            this.chkOnTop.AutoSize = true;
            this.chkOnTop.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkOnTop.Location = new System.Drawing.Point(7, 82);
            this.chkOnTop.Name = "chkOnTop";
            this.chkOnTop.Size = new System.Drawing.Size(129, 20);
            this.chkOnTop.TabIndex = 1;
            this.chkOnTop.Text = "永遠在最上層";
            this.chkOnTop.UseVisualStyleBackColor = true;
            this.chkOnTop.Click += new System.EventHandler(this.chkOnTop_Click);
            // 
            // btnCloseComm
            // 
            this.btnCloseComm.Location = new System.Drawing.Point(455, 42);
            this.btnCloseComm.Name = "btnCloseComm";
            this.btnCloseComm.Size = new System.Drawing.Size(106, 27);
            this.btnCloseComm.TabIndex = 3;
            this.btnCloseComm.Text = "關閉通訊埠";
            this.btnCloseComm.UseVisualStyleBackColor = true;
            this.btnCloseComm.Click += new System.EventHandler(this.btnCloseComm_Click);
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(45, 14);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(81, 22);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "通訊埠:";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(189, 49);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(34, 22);
            this.Label4.TabIndex = 1;
            this.Label4.Text = "ms";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(8, 49);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(118, 22);
            this.Label3.TabIndex = 1;
            this.Label3.Text = "通訊延遲:";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(219, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(118, 22);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "通訊設定:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnReloadPLCIO
            // 
            this.btnReloadPLCIO.Location = new System.Drawing.Point(281, 42);
            this.btnReloadPLCIO.Name = "btnReloadPLCIO";
            this.btnReloadPLCIO.Size = new System.Drawing.Size(148, 27);
            this.btnReloadPLCIO.TabIndex = 3;
            this.btnReloadPLCIO.Text = "重新載入IO名稱";
            this.btnReloadPLCIO.UseVisualStyleBackColor = true;
            this.btnReloadPLCIO.Click += new System.EventHandler(this.btnReloadPLCIO_Click);
            // 
            // btnOpenComm
            // 
            this.btnOpenComm.Location = new System.Drawing.Point(457, 11);
            this.btnOpenComm.Name = "btnOpenComm";
            this.btnOpenComm.Size = new System.Drawing.Size(106, 27);
            this.btnOpenComm.TabIndex = 3;
            this.btnOpenComm.Text = "開啟通訊埠";
            this.btnOpenComm.UseVisualStyleBackColor = true;
            this.btnOpenComm.Click += new System.EventHandler(this.btnOpenComm_Click);
            // 
            // txtDelay
            // 
            this.txtDelay.Location = new System.Drawing.Point(132, 44);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(51, 27);
            this.txtDelay.TabIndex = 0;
            this.txtDelay.Text = "30";
            this.txtDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCommSetting
            // 
            this.txtCommSetting.Location = new System.Drawing.Point(343, 11);
            this.txtCommSetting.Name = "txtCommSetting";
            this.txtCommSetting.Size = new System.Drawing.Size(108, 27);
            this.txtCommSetting.TabIndex = 0;
            this.txtCommSetting.Text = "9600,E,7,1";
            this.txtCommSetting.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmoCommPort
            // 
            this.cmoCommPort.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmoCommPort.FormattingEnabled = true;
            this.cmoCommPort.Location = new System.Drawing.Point(132, 14);
            this.cmoCommPort.Name = "cmoCommPort";
            this.cmoCommPort.Size = new System.Drawing.Size(81, 24);
            this.cmoCommPort.TabIndex = 2;
            this.cmoCommPort.SelectedIndexChanged += new System.EventHandler(this.cmoCommPort_SelectedIndexChanged);
            // 
            // tpgXTC3
            // 
            this.tpgXTC3.Controls.Add(this.grpPLCOutputSetup);
            this.tpgXTC3.Controls.Add(this.grpPLCInputSetup);
            this.tpgXTC3.Controls.Add(this.grpIPPortSetup);
            this.tpgXTC3.Location = new System.Drawing.Point(4, 28);
            this.tpgXTC3.Name = "tpgXTC3";
            this.tpgXTC3.Padding = new System.Windows.Forms.Padding(3);
            this.tpgXTC3.Size = new System.Drawing.Size(909, 633);
            this.tpgXTC3.TabIndex = 6;
            this.tpgXTC3.Text = "XTC 3 專用設定";
            this.tpgXTC3.UseVisualStyleBackColor = true;
            // 
            // grpPLCOutputSetup
            // 
            this.grpPLCOutputSetup.Controls.Add(this.btnPocketGood);
            this.grpPLCOutputSetup.Controls.Add(this.txtPowerOutR);
            this.grpPLCOutputSetup.Controls.Add(this.lblPowerOutRText);
            this.grpPLCOutputSetup.Controls.Add(this.txtPockInpositionY);
            this.grpPLCOutputSetup.Controls.Add(this.lblPockInpositionYText);
            this.grpPLCOutputSetup.Font = new System.Drawing.Font("Arial", 11F);
            this.grpPLCOutputSetup.Location = new System.Drawing.Point(259, 166);
            this.grpPLCOutputSetup.Name = "grpPLCOutputSetup";
            this.grpPLCOutputSetup.Size = new System.Drawing.Size(231, 136);
            this.grpPLCOutputSetup.TabIndex = 148;
            this.grpPLCOutputSetup.TabStop = false;
            this.grpPLCOutputSetup.Text = "PLC 連線至XTC/3 輸出點設定";
            // 
            // btnPocketGood
            // 
            this.btnPocketGood.Location = new System.Drawing.Point(129, 90);
            this.btnPocketGood.Name = "btnPocketGood";
            this.btnPocketGood.Size = new System.Drawing.Size(77, 42);
            this.btnPocketGood.TabIndex = 10;
            this.btnPocketGood.Text = "Pocket Good";
            this.btnPocketGood.UseVisualStyleBackColor = true;
            this.btnPocketGood.Click += new System.EventHandler(this.btnPocketGood_Click);
            // 
            // txtPowerOutR
            // 
            this.txtPowerOutR.BackColor = System.Drawing.Color.MediumAquamarine;
            this.txtPowerOutR.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPowerOutR.Location = new System.Drawing.Point(129, 58);
            this.txtPowerOutR.Name = "txtPowerOutR";
            this.txtPowerOutR.Size = new System.Drawing.Size(77, 26);
            this.txtPowerOutR.TabIndex = 145;
            this.txtPowerOutR.Text = "R1165";
            this.txtPowerOutR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPowerOutRText
            // 
            this.lblPowerOutRText.Font = new System.Drawing.Font("Arial", 11F);
            this.lblPowerOutRText.Location = new System.Drawing.Point(7, 58);
            this.lblPowerOutRText.Name = "lblPowerOutRText";
            this.lblPowerOutRText.Size = new System.Drawing.Size(116, 26);
            this.lblPowerOutRText.TabIndex = 146;
            this.lblPowerOutRText.Text = "Power Input:";
            this.lblPowerOutRText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPockInpositionY
            // 
            this.txtPockInpositionY.BackColor = System.Drawing.Color.MediumAquamarine;
            this.txtPockInpositionY.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPockInpositionY.Location = new System.Drawing.Point(129, 23);
            this.txtPockInpositionY.Name = "txtPockInpositionY";
            this.txtPockInpositionY.Size = new System.Drawing.Size(77, 26);
            this.txtPockInpositionY.TabIndex = 143;
            this.txtPockInpositionY.Text = "M0035";
            this.txtPockInpositionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPockInpositionYText
            // 
            this.lblPockInpositionYText.Font = new System.Drawing.Font("Arial", 11F);
            this.lblPockInpositionYText.Location = new System.Drawing.Point(7, 23);
            this.lblPockInpositionYText.Name = "lblPockInpositionYText";
            this.lblPockInpositionYText.Size = new System.Drawing.Size(116, 26);
            this.lblPockInpositionYText.TabIndex = 144;
            this.lblPockInpositionYText.Text = "Pocket In Pos.:";
            this.lblPockInpositionYText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpPLCInputSetup
            // 
            this.grpPLCInputSetup.Controls.Add(this.txtCrystalFailX);
            this.grpPLCInputSetup.Controls.Add(this.lblCrystalFailXText);
            this.grpPLCInputSetup.Controls.Add(this.txtDepSHX);
            this.grpPLCInputSetup.Controls.Add(this.lblDepSHXText);
            this.grpPLCInputSetup.Controls.Add(this.txtDepCompleteX);
            this.grpPLCInputSetup.Controls.Add(this.lblDepCompleteXText);
            this.grpPLCInputSetup.Controls.Add(this.txtDepSensor2lX);
            this.grpPLCInputSetup.Controls.Add(this.lblDepSensor2lXText);
            this.grpPLCInputSetup.Font = new System.Drawing.Font("Arial", 11F);
            this.grpPLCInputSetup.Location = new System.Drawing.Point(259, 6);
            this.grpPLCInputSetup.Name = "grpPLCInputSetup";
            this.grpPLCInputSetup.Size = new System.Drawing.Size(231, 154);
            this.grpPLCInputSetup.TabIndex = 147;
            this.grpPLCInputSetup.TabStop = false;
            this.grpPLCInputSetup.Text = "XTC/3  連線至PLC輸入點設定";
            // 
            // txtCrystalFailX
            // 
            this.txtCrystalFailX.BackColor = System.Drawing.Color.MediumAquamarine;
            this.txtCrystalFailX.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCrystalFailX.Location = new System.Drawing.Point(129, 23);
            this.txtCrystalFailX.Name = "txtCrystalFailX";
            this.txtCrystalFailX.Size = new System.Drawing.Size(77, 26);
            this.txtCrystalFailX.TabIndex = 143;
            this.txtCrystalFailX.Text = "X0013";
            this.txtCrystalFailX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCrystalFailXText
            // 
            this.lblCrystalFailXText.Font = new System.Drawing.Font("Arial", 11F);
            this.lblCrystalFailXText.Location = new System.Drawing.Point(7, 23);
            this.lblCrystalFailXText.Name = "lblCrystalFailXText";
            this.lblCrystalFailXText.Size = new System.Drawing.Size(116, 26);
            this.lblCrystalFailXText.TabIndex = 144;
            this.lblCrystalFailXText.Text = "Crystal Fail:";
            this.lblCrystalFailXText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDepSHX
            // 
            this.txtDepSHX.BackColor = System.Drawing.Color.MediumAquamarine;
            this.txtDepSHX.Font = new System.Drawing.Font("Arial", 12F);
            this.txtDepSHX.Location = new System.Drawing.Point(129, 121);
            this.txtDepSHX.Name = "txtDepSHX";
            this.txtDepSHX.Size = new System.Drawing.Size(77, 26);
            this.txtDepSHX.TabIndex = 141;
            this.txtDepSHX.Text = "X0016";
            this.txtDepSHX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDepSHXText
            // 
            this.lblDepSHXText.Font = new System.Drawing.Font("Arial", 11F);
            this.lblDepSHXText.Location = new System.Drawing.Point(7, 121);
            this.lblDepSHXText.Name = "lblDepSHXText";
            this.lblDepSHXText.Size = new System.Drawing.Size(116, 26);
            this.lblDepSHXText.TabIndex = 142;
            this.lblDepSHXText.Text = "Dep SH:";
            this.lblDepSHXText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDepCompleteX
            // 
            this.txtDepCompleteX.BackColor = System.Drawing.Color.MediumAquamarine;
            this.txtDepCompleteX.Font = new System.Drawing.Font("Arial", 12F);
            this.txtDepCompleteX.Location = new System.Drawing.Point(129, 89);
            this.txtDepCompleteX.Name = "txtDepCompleteX";
            this.txtDepCompleteX.Size = new System.Drawing.Size(77, 26);
            this.txtDepCompleteX.TabIndex = 139;
            this.txtDepCompleteX.Text = "X0015";
            this.txtDepCompleteX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDepCompleteXText
            // 
            this.lblDepCompleteXText.Font = new System.Drawing.Font("Arial", 11F);
            this.lblDepCompleteXText.Location = new System.Drawing.Point(7, 89);
            this.lblDepCompleteXText.Name = "lblDepCompleteXText";
            this.lblDepCompleteXText.Size = new System.Drawing.Size(116, 26);
            this.lblDepCompleteXText.TabIndex = 140;
            this.lblDepCompleteXText.Text = "Dep Complete:";
            this.lblDepCompleteXText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDepSensor2lX
            // 
            this.txtDepSensor2lX.BackColor = System.Drawing.Color.MediumAquamarine;
            this.txtDepSensor2lX.Font = new System.Drawing.Font("Arial", 12F);
            this.txtDepSensor2lX.Location = new System.Drawing.Point(129, 57);
            this.txtDepSensor2lX.Name = "txtDepSensor2lX";
            this.txtDepSensor2lX.Size = new System.Drawing.Size(77, 26);
            this.txtDepSensor2lX.TabIndex = 137;
            this.txtDepSensor2lX.Text = "X0014";
            this.txtDepSensor2lX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDepSensor2lXText
            // 
            this.lblDepSensor2lXText.Font = new System.Drawing.Font("Arial", 11F);
            this.lblDepSensor2lXText.Location = new System.Drawing.Point(7, 57);
            this.lblDepSensor2lXText.Name = "lblDepSensor2lXText";
            this.lblDepSensor2lXText.Size = new System.Drawing.Size(116, 26);
            this.lblDepSensor2lXText.TabIndex = 138;
            this.lblDepSensor2lXText.Text = "Dep Sensor 2:";
            this.lblDepSensor2lXText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpIPPortSetup
            // 
            this.grpIPPortSetup.Controls.Add(this.txtPLCLinkIP);
            this.grpIPPortSetup.Controls.Add(this.lblPLCLinkIPText);
            this.grpIPPortSetup.Controls.Add(this.txtLinkInPort);
            this.grpIPPortSetup.Controls.Add(this.lblLinkOutPortText);
            this.grpIPPortSetup.Controls.Add(this.lblLinkInPortText);
            this.grpIPPortSetup.Controls.Add(this.txtLinkOutPort);
            this.grpIPPortSetup.Location = new System.Drawing.Point(8, 6);
            this.grpIPPortSetup.Name = "grpIPPortSetup";
            this.grpIPPortSetup.Size = new System.Drawing.Size(245, 154);
            this.grpIPPortSetup.TabIndex = 146;
            this.grpIPPortSetup.TabStop = false;
            this.grpIPPortSetup.Text = "IP 位址/通信埠設定";
            // 
            // txtPLCLinkIP
            // 
            this.txtPLCLinkIP.BackColor = System.Drawing.Color.MediumAquamarine;
            this.txtPLCLinkIP.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPLCLinkIP.Location = new System.Drawing.Point(137, 25);
            this.txtPLCLinkIP.Name = "txtPLCLinkIP";
            this.txtPLCLinkIP.Size = new System.Drawing.Size(98, 26);
            this.txtPLCLinkIP.TabIndex = 2;
            this.txtPLCLinkIP.Text = "127.0.0.1";
            this.txtPLCLinkIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPLCLinkIPText
            // 
            this.lblPLCLinkIPText.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPLCLinkIPText.Location = new System.Drawing.Point(11, 24);
            this.lblPLCLinkIPText.Name = "lblPLCLinkIPText";
            this.lblPLCLinkIPText.Size = new System.Drawing.Size(126, 26);
            this.lblPLCLinkIPText.TabIndex = 132;
            this.lblPLCLinkIPText.Text = "XTC/3 連線 IP:";
            this.lblPLCLinkIPText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLinkInPort
            // 
            this.txtLinkInPort.BackColor = System.Drawing.Color.MediumAquamarine;
            this.txtLinkInPort.Font = new System.Drawing.Font("Arial", 12F);
            this.txtLinkInPort.Location = new System.Drawing.Point(137, 57);
            this.txtLinkInPort.Name = "txtLinkInPort";
            this.txtLinkInPort.Size = new System.Drawing.Size(70, 26);
            this.txtLinkInPort.TabIndex = 133;
            this.txtLinkInPort.Text = "8080";
            this.txtLinkInPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLinkOutPortText
            // 
            this.lblLinkOutPortText.Font = new System.Drawing.Font("Arial", 10F);
            this.lblLinkOutPortText.Location = new System.Drawing.Point(11, 88);
            this.lblLinkOutPortText.Name = "lblLinkOutPortText";
            this.lblLinkOutPortText.Size = new System.Drawing.Size(126, 26);
            this.lblLinkOutPortText.TabIndex = 136;
            this.lblLinkOutPortText.Text = "PLC 送出 PORT:";
            this.lblLinkOutPortText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLinkInPortText
            // 
            this.lblLinkInPortText.Font = new System.Drawing.Font("Arial", 10F);
            this.lblLinkInPortText.Location = new System.Drawing.Point(11, 56);
            this.lblLinkInPortText.Name = "lblLinkInPortText";
            this.lblLinkInPortText.Size = new System.Drawing.Size(126, 26);
            this.lblLinkInPortText.TabIndex = 134;
            this.lblLinkInPortText.Text = "PLC連入 PORT:";
            this.lblLinkInPortText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLinkOutPort
            // 
            this.txtLinkOutPort.BackColor = System.Drawing.Color.MediumAquamarine;
            this.txtLinkOutPort.Font = new System.Drawing.Font("Arial", 12F);
            this.txtLinkOutPort.Location = new System.Drawing.Point(137, 89);
            this.txtLinkOutPort.Name = "txtLinkOutPort";
            this.txtLinkOutPort.Size = new System.Drawing.Size(70, 26);
            this.txtLinkOutPort.TabIndex = 135;
            this.txtLinkOutPort.Text = "8081";
            this.txtLinkOutPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Timer1
            // 
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Timer2
            // 
            this.Timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 665);
            this.Controls.Add(this.tabSimPLC);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabSimPLC.ResumeLayout(false);
            this.tabPageXInput.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.tabPageMOutput.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.tabPageYOutput.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.tabPageRRead.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.tabPageRWrite.ResumeLayout(false);
            this.Panel5.ResumeLayout(false);
            this.Panel5.PerformLayout();
            this.TabPageOption.ResumeLayout(false);
            this.TabPageOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.tpgXTC3.ResumeLayout(false);
            this.grpPLCOutputSetup.ResumeLayout(false);
            this.grpPLCOutputSetup.PerformLayout();
            this.grpPLCInputSetup.ResumeLayout(false);
            this.grpPLCInputSetup.PerformLayout();
            this.grpIPPortSetup.ResumeLayout(false);
            this.grpIPPortSetup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl tabSimPLC;
        internal System.Windows.Forms.TabPage tabPageXInput;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button btnCap;
        internal System.Windows.Forms.Label lblXName;
        internal System.Windows.Forms.TextBox txtXInputIndex;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.TabPage tabPageMOutput;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label lblMName;
        internal System.Windows.Forms.TextBox txtMOutputIndex;
        internal System.Windows.Forms.Button btnMOutputNextPage;
        internal System.Windows.Forms.Button btnMOutputPrevPage;
        internal System.Windows.Forms.TabPage tabPageYOutput;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Label lblYName;
        internal System.Windows.Forms.TextBox txtYOutputIndex;
        internal System.Windows.Forms.Button btnYOutputNextPage;
        internal System.Windows.Forms.Button btnYOutputPrevPage;
        internal System.Windows.Forms.TabPage tabPageRRead;
        internal System.Windows.Forms.Label lblRRName;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Button btnReadNextPage;
        internal System.Windows.Forms.Button btnReadPrevPage;
        internal System.Windows.Forms.TextBox txtReadWordIndex;
        internal System.Windows.Forms.TabPage tabPageRWrite;
        internal System.Windows.Forms.Label lblRWName;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.Button btnWriteNextPage;
        internal System.Windows.Forms.Button btnWritePrevPage;
        internal System.Windows.Forms.TextBox txtWriteWordIndex;
        internal System.Windows.Forms.TabPage TabPageOption;
        internal System.Windows.Forms.Label lblActionFileName;
        internal System.Windows.Forms.Button btnReload;
        internal System.Windows.Forms.Button btnAction;
        internal System.Windows.Forms.Button btnLoadAction;
        internal System.Windows.Forms.Button btnSaveAction;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colSource;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colMethod;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ColDest;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ColDelay;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ColTargetValue;
        internal System.Windows.Forms.CheckBox chkMtoY;
        internal System.Windows.Forms.CheckBox chkOnTop;
        internal System.Windows.Forms.Button btnCloseComm;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnReloadPLCIO;
        internal System.Windows.Forms.Button btnOpenComm;
        internal System.Windows.Forms.TextBox txtDelay;
        internal System.Windows.Forms.TextBox txtCommSetting;
        internal System.Windows.Forms.ComboBox cmoCommPort;
        internal System.Windows.Forms.TabPage tpgXTC3;
        internal System.Windows.Forms.GroupBox grpPLCOutputSetup;
        internal System.Windows.Forms.Button btnPocketGood;
        internal System.Windows.Forms.TextBox txtPowerOutR;
        internal System.Windows.Forms.Label lblPowerOutRText;
        internal System.Windows.Forms.TextBox txtPockInpositionY;
        internal System.Windows.Forms.Label lblPockInpositionYText;
        internal System.Windows.Forms.GroupBox grpPLCInputSetup;
        internal System.Windows.Forms.TextBox txtCrystalFailX;
        internal System.Windows.Forms.Label lblCrystalFailXText;
        internal System.Windows.Forms.TextBox txtDepSHX;
        internal System.Windows.Forms.Label lblDepSHXText;
        internal System.Windows.Forms.TextBox txtDepCompleteX;
        internal System.Windows.Forms.Label lblDepCompleteXText;
        internal System.Windows.Forms.TextBox txtDepSensor2lX;
        internal System.Windows.Forms.Label lblDepSensor2lXText;
        internal System.Windows.Forms.GroupBox grpIPPortSetup;
        internal System.Windows.Forms.TextBox txtPLCLinkIP;
        internal System.Windows.Forms.Label lblPLCLinkIPText;
        internal System.Windows.Forms.TextBox txtLinkInPort;
        internal System.Windows.Forms.Label lblLinkOutPortText;
        internal System.Windows.Forms.Label lblLinkInPortText;
        internal System.Windows.Forms.TextBox txtLinkOutPort;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Timer Timer2;
        private System.Windows.Forms.ToolTip Help;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog1;
    }
}

