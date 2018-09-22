namespace Counsel_System.Forms
{
    partial class StudABCardReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lnkChkMappingField = new System.Windows.Forms.LinkLabel();
            this.lnkUserDefUpload = new System.Windows.Forms.LinkLabel();
            this.lnkUserDef = new System.Windows.Forms.LinkLabel();
            this.lnkDefaultView = new System.Windows.Forms.LinkLabel();
            this.chkUserDef = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkDefault = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ckBxSinglePrint = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ckBxPDF = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.ckBxDoc = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.AutoSize = true;
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.Location = new System.Drawing.Point(186, 353);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 30);
            this.btnPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "列印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(267, 353);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.lnkChkMappingField);
            this.groupPanel1.Controls.Add(this.lnkUserDefUpload);
            this.groupPanel1.Controls.Add(this.lnkUserDef);
            this.groupPanel1.Controls.Add(this.lnkDefaultView);
            this.groupPanel1.Controls.Add(this.chkUserDef);
            this.groupPanel1.Controls.Add(this.chkDefault);
            this.groupPanel1.Location = new System.Drawing.Point(14, 10);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(327, 94);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 2;
            this.groupPanel1.Text = "範本";
            // 
            // lnkChkMappingField
            // 
            this.lnkChkMappingField.AutoSize = true;
            this.lnkChkMappingField.Location = new System.Drawing.Point(223, 10);
            this.lnkChkMappingField.Name = "lnkChkMappingField";
            this.lnkChkMappingField.Size = new System.Drawing.Size(112, 22);
            this.lnkChkMappingField.TabIndex = 7;
            this.lnkChkMappingField.TabStop = true;
            this.lnkChkMappingField.Text = "檢視合併欄位";
            this.lnkChkMappingField.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChkMappingField_LinkClicked);
            // 
            // lnkUserDefUpload
            // 
            this.lnkUserDefUpload.AutoSize = true;
            this.lnkUserDefUpload.Location = new System.Drawing.Point(223, 37);
            this.lnkUserDefUpload.Name = "lnkUserDefUpload";
            this.lnkUserDefUpload.Size = new System.Drawing.Size(44, 22);
            this.lnkUserDefUpload.TabIndex = 6;
            this.lnkUserDefUpload.TabStop = true;
            this.lnkUserDefUpload.Text = "上傳";
            this.lnkUserDefUpload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUserDefUpload_LinkClicked);
            // 
            // lnkUserDef
            // 
            this.lnkUserDef.AutoSize = true;
            this.lnkUserDef.Location = new System.Drawing.Point(177, 37);
            this.lnkUserDef.Name = "lnkUserDef";
            this.lnkUserDef.Size = new System.Drawing.Size(44, 22);
            this.lnkUserDef.TabIndex = 5;
            this.lnkUserDef.TabStop = true;
            this.lnkUserDef.Text = "檢視";
            this.lnkUserDef.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUserDef_LinkClicked);
            // 
            // lnkDefaultView
            // 
            this.lnkDefaultView.AutoSize = true;
            this.lnkDefaultView.Location = new System.Drawing.Point(177, 10);
            this.lnkDefaultView.Name = "lnkDefaultView";
            this.lnkDefaultView.Size = new System.Drawing.Size(44, 22);
            this.lnkDefaultView.TabIndex = 4;
            this.lnkDefaultView.TabStop = true;
            this.lnkDefaultView.Text = "檢視";
            this.lnkDefaultView.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDefaultView_LinkClicked);
            // 
            // chkUserDef
            // 
            this.chkUserDef.AutoSize = true;
            // 
            // 
            // 
            this.chkUserDef.BackgroundStyle.Class = "";
            this.chkUserDef.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkUserDef.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkUserDef.Location = new System.Drawing.Point(12, 36);
            this.chkUserDef.Name = "chkUserDef";
            this.chkUserDef.Size = new System.Drawing.Size(179, 26);
            this.chkUserDef.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkUserDef.TabIndex = 1;
            this.chkUserDef.Text = "自訂輔導資料紀錄表";
            // 
            // chkDefault
            // 
            this.chkDefault.AutoSize = true;
            // 
            // 
            // 
            this.chkDefault.BackgroundStyle.Class = "";
            this.chkDefault.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkDefault.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkDefault.Location = new System.Drawing.Point(12, 7);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(179, 26);
            this.chkDefault.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkDefault.TabIndex = 0;
            this.chkDefault.Text = "預設輔導資料紀錄表";
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ckBxSinglePrint);
            this.groupPanel2.Location = new System.Drawing.Point(14, 239);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(327, 94);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.Class = "";
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.Class = "";
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.Class = "";
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 3;
            this.groupPanel2.Text = "單檔列印";
            // 
            // ckBxSinglePrint
            // 
            // 
            // 
            // 
            this.ckBxSinglePrint.BackgroundStyle.Class = "";
            this.ckBxSinglePrint.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckBxSinglePrint.Location = new System.Drawing.Point(12, 21);
            this.ckBxSinglePrint.Name = "ckBxSinglePrint";
            this.ckBxSinglePrint.Size = new System.Drawing.Size(316, 23);
            this.ckBxSinglePrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckBxSinglePrint.TabIndex = 0;
            this.ckBxSinglePrint.Text = "使用單檔列印(檔名:學號_身分證_班級_座號_姓名)";
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.ckBxPDF);
            this.groupPanel3.Controls.Add(this.ckBxDoc);
            this.groupPanel3.Location = new System.Drawing.Point(14, 124);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(327, 94);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.Class = "";
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.Class = "";
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.Class = "";
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 4;
            this.groupPanel3.Text = "檔案格式選擇";
            // 
            // ckBxPDF
            // 
            // 
            // 
            // 
            this.ckBxPDF.BackgroundStyle.Class = "";
            this.ckBxPDF.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckBxPDF.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.ckBxPDF.Location = new System.Drawing.Point(180, 19);
            this.ckBxPDF.Name = "ckBxPDF";
            this.ckBxPDF.Size = new System.Drawing.Size(100, 23);
            this.ckBxPDF.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckBxPDF.TabIndex = 1;
            this.ckBxPDF.Text = "PDF(*.pdf)";
            // 
            // ckBxDoc
            // 
            // 
            // 
            // 
            this.ckBxDoc.BackgroundStyle.Class = "";
            this.ckBxDoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckBxDoc.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.ckBxDoc.Checked = true;
            this.ckBxDoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckBxDoc.CheckValue = "Y";
            this.ckBxDoc.Location = new System.Drawing.Point(12, 19);
            this.ckBxDoc.Name = "ckBxDoc";
            this.ckBxDoc.Size = new System.Drawing.Size(104, 23);
            this.ckBxDoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckBxDoc.TabIndex = 0;
            this.ckBxDoc.Text = "Word(*.doc)";
            // 
            // StudABCardReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 389);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(375, 436);
            this.MinimumSize = new System.Drawing.Size(375, 436);
            this.Name = "StudABCardReportForm";
            this.Text = "學生綜合資料紀錄表";
            this.Load += new System.EventHandler(this.StudABCardReportForm_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnPrint;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkDefault;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkUserDef;
        private System.Windows.Forms.LinkLabel lnkDefaultView;
        private System.Windows.Forms.LinkLabel lnkUserDefUpload;
        private System.Windows.Forms.LinkLabel lnkUserDef;
        private System.Windows.Forms.LinkLabel lnkChkMappingField;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckBxSinglePrint;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckBxPDF;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckBxDoc;
    }
}