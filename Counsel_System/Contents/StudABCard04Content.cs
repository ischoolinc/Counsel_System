using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Counsel_System.DAO;
using Campus.Windows;
using DevComponents.DotNetBar.Controls;

namespace Counsel_System.Contents
{
    [FISCA.Permission.FeatureCode(PermissionCode.綜合表現紀錄表_資料項目, "綜合表現紀錄表-自傳")]
    public partial class StudABCard04Content : FISCA.Presentation.DetailContent
    {
        Dictionary<string, string> _txtControlTag;
        Dictionary<string, UDTSingleRecordDef> _dataDict;
        List<string> _StudentIDList;
        int _intStudentID=0;
        private BackgroundWorker _bgWorker;
        ChangeListener _ChangeListener;
        bool _isBusy = false;
        List<UDTSingleRecordDef> _insertDataList;
        List<UDTSingleRecordDef> _updateDataList;

        string GroupName = "自傳";
        public StudABCard04Content()
        {
            InitializeComponent();
            _StudentIDList = new List<string>();
            _dataDict = new Dictionary<string, UDTSingleRecordDef>();
            _txtControlTag = new Dictionary<string, string>();
            _insertDataList = new List<UDTSingleRecordDef>();
            _updateDataList = new List<UDTSingleRecordDef>();
            _bgWorker = new BackgroundWorker();
            
            _bgWorker.DoWork += new DoWorkEventHandler(_bgWorker_DoWork);
            _bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgWorker_RunWorkerCompleted);
            this.Group = "綜合表現紀錄表-自傳";
            
            setTabIndex();
            SetControlTag();
            _ChangeListener = new ChangeListener();
            _ChangeListener.StatusChanged += new EventHandler<ChangeEventArgs>(_ChangeListener_StatusChanged);
            // 加入 listener
            foreach (Control cr in this.Controls)
            {
                if (cr is TextBoxX)
                {
                    TextBoxX tb = cr as TextBoxX;
                    _ChangeListener.Add(new TextBoxSource(tb));
                }
            }        
        }

        void _ChangeListener_StatusChanged(object sender, ChangeEventArgs e)
        {
            this.CancelButtonVisible = (e.Status == ValueStatus.Dirty);
            this.SaveButtonVisible = (e.Status == ValueStatus.Dirty);
        }

        protected override void OnPrimaryKeyChanged(EventArgs e)
        {
            _StudentIDList.Clear();
            _StudentIDList.Add(PrimaryKey);
            _intStudentID = int.Parse(PrimaryKey);
            _BGRun();
        }

        private void _BGRun()
        {
            if (_bgWorker.IsBusy)
                _isBusy = true;
            else
            {
                this.Loading = true;
                _bgWorker.RunWorkerAsync();
            }
        }

        void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_isBusy)
            {
                _isBusy = false;
                _bgWorker.RunWorkerAsync();
                return;
            }
            LoadData();
        }

        void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _dataDict.Clear();
            foreach (UDTSingleRecordDef data in UDTTransfer.ABUDTSingleRecordSelectByStudentIDList(_StudentIDList))
            {
                if(data.Key.Contains(GroupName))
                if (!_dataDict.ContainsKey(data.Key))
                    _dataDict.Add(data.Key, data);
            }
        }

        /// <summary>
        /// 設定 Control Tab Index
        /// </summary>
        private void setTabIndex()
        {
            txt01.TabIndex = 1;
            txt02.TabIndex = 2;            
            txt03.TabIndex = 3;
            txt04_1.TabIndex = 4;
            txt04_2.TabIndex = 5;
            txt05_1.TabIndex = 6;
            txt05_2.TabIndex = 7;
            txt06_1.TabIndex = 8;
            txt06_2.TabIndex = 9;
            txt07_1.TabIndex = 10;
            txt07_2.TabIndex = 11;
            txt08.TabIndex = 12;
            txt09.TabIndex = 13;
            txt10.TabIndex = 14;
            txt11.TabIndex = 15;        
        }

        /// <summary>
        /// 設定 txt 控制項對應 tag
        /// </summary>
        private void SetControlTag()
        {
            _txtControlTag.Add("txt01", "自傳_家中最了解我的人");
            _txtControlTag.Add("txt02", "自傳_常指導我做功課的人");
            _txtControlTag.Add("txt03", "自傳_讀過且印象最深刻的課外書");
            _txtControlTag.Add("txt04_1", "自傳_喜歡的人");
            _txtControlTag.Add("txt04_2", "自傳_喜歡的人_因為");
            _txtControlTag.Add("txt05_1", "自傳_最要好的朋友");
            _txtControlTag.Add("txt05_2", "自傳_他是怎樣的人");
            _txtControlTag.Add("txt06_1", "自傳_最喜歡做的事");
            _txtControlTag.Add("txt06_2", "自傳_最喜歡做的事_因為");
            _txtControlTag.Add("txt07_1", "自傳_最不喜歡做的事");
            _txtControlTag.Add("txt07_2", "自傳_最不喜歡做的事_因為");
            _txtControlTag.Add("txt08", "自傳_國中時的學校生活");
            _txtControlTag.Add("txt09", "自傳_最快樂的回憶");
            _txtControlTag.Add("txt10", "自傳_最痛苦的回憶");
            _txtControlTag.Add("txt11", "自傳_最足以描述自己的幾句話");

            foreach (Control cr in this.Controls)
            {
                if (cr is TextBox)
                {
                    if (_txtControlTag.ContainsKey(cr.Name))
                    {
                        cr.Name = _txtControlTag[cr.Name];
                    }
                }
            
            }
        }

        /// <summary>
        /// 載入資料
        /// </summary>
        private void LoadData()
        {
            _ChangeListener.SuspendListen();
            ClearTxt();

            foreach (Control cr in this.Controls)
            {
                if (cr is TextBoxX)
                {
                    if (_dataDict.ContainsKey(cr.Name))
                    {
                        cr.Text = _dataDict[cr.Name].Data;
                        cr.Tag = _dataDict[cr.Name];
                    }
                }        
            }
            _ChangeListener.Reset();
            _ChangeListener.ResumeListen();
            this.Loading = false;
        }

        private void SetData()
        {
            _insertDataList.Clear();
            _updateDataList.Clear();

            // 取得畫面資料
            foreach (Control cr in this.Controls)
            {
                if (cr is TextBox)
                {
                    UDTSingleRecordDef uData = cr.Tag as UDTSingleRecordDef;
                    if (uData == null)
                    {
                        uData = new UDTSingleRecordDef();
                        uData.Key = cr.Name;
                        uData.StudentID = _intStudentID;
                    }
                        uData.Data = cr.Text;

                        if (string.IsNullOrEmpty(uData.UID))
                            _insertDataList.Add(uData);
                        else
                            _updateDataList.Add(uData);
                }
            }
        }

        protected override void OnSaveButtonClick(EventArgs e)
        {
            SetData();
            if (_insertDataList.Count > 0)
                UDTTransfer.ABUDTSingleRecordInsert(_insertDataList);

            if (_updateDataList.Count > 0)
                UDTTransfer.ABUDTSingleRecordUpdate(_updateDataList);

            this.SaveButtonVisible = this.CancelButtonVisible = false;
            _BGRun();
        }

        protected override void OnCancelButtonClick(EventArgs e)
        {
            this.SaveButtonVisible = this.CancelButtonVisible = false;
            _BGRun();            
        }

        /// <summary>
        ///  將 txt 內容設成空白
        /// </summary>
        private void ClearTxt()
        {
            foreach (Control cr in this.Controls)
                if (cr is TextBox)
                    cr.Text = "";
        }

        

    }
}
