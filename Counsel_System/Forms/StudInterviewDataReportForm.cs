using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Words;
using Campus.Report;
using System.IO;
using Counsel_System.DAO;
using K12.Data;
using System.Xml.Linq;
using Aspose.Words.Reporting;

namespace Counsel_System.Forms
{
    public partial class StudInterviewDataReportForm : FISCA.Presentation.Controls.BaseForm
    {
        private string _ReportName="學生輔導紀錄表樣板";
        private ReportConfiguration _Config;
        UDTTransfer _UDTTransfer;
        BackgroundWorker _bgWorker;
        List<Dictionary<string,string>> _dataDictList;
        public enum SelectType {學生,教師}
        Dictionary<string, StudentRecord> _studDataDict;
        List<string> _studIDList;
        SelectType _UserSelectType;
        List<string> _TeacherIDList;
        // 樣板
        byte[] _DocTemplate;

        public StudInterviewDataReportForm(SelectType type)
        {
            InitializeComponent();
            _UDTTransfer = new UDTTransfer();
            _studIDList = new List<string>();
            _TeacherIDList = new List<string>();
            _studDataDict = new Dictionary<string, StudentRecord>();
            _bgWorker= new BackgroundWorker ();
            _dataDictList= new List<Dictionary<string,string>>();
            _UserSelectType = type;
            _bgWorker.DoWork+=new DoWorkEventHandler(_bgWorker_DoWork);
            _bgWorker.RunWorkerCompleted+=new RunWorkerCompletedEventHandler(_bgWorker_RunWorkerCompleted);
        }

        void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnPrint.Enabled = true;
            Document doc = (Document)e.Result;
            string _FilePathAndName = "";
            // 當沒有設定檔案名稱
            if (string.IsNullOrEmpty(_FilePathAndName))
            {
                SaveFileDialog sd = new SaveFileDialog();
                sd.Title = "另存新檔";
                sd.FileName = "晤談紀錄表.doc";
                sd.Filter = "Word檔案 (*.doc)|*.doc|所有檔案 (*.*)|*.*";
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        doc.Save(sd.FileName, Aspose.Words.SaveFormat.Doc);
                        System.Diagnostics.Process.Start(sd.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("指定路徑無法存取。", "建立檔案失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                try
                {
                    doc.Save(_FilePathAndName, SaveFormat.Doc);
                        System.Diagnostics.Process.Start(_FilePathAndName);
                }
                catch
                {
                    SaveFileDialog sd = new SaveFileDialog();
                    sd.Title = "另存新檔";
                    sd.FileName = "晤談紀錄表1.doc";
                    sd.Filter = "Word檔案 (*.doc)|*.doc|所有檔案 (*.*)|*.*";
                    if (sd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            doc.Save(sd.FileName, Aspose.Words.SaveFormat.Doc);
                            System.Diagnostics.Process.Start(sd.FileName);
                        }
                        catch
                        {
                            MessageBox.Show("指定路徑無法存取。", "建立檔案失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
        }

        void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _studDataDict.Clear();
            _dataDictList.Clear();
            string SchoolName = School.ChineseName;


            Dictionary<int, string> intTeacherNameDict = new Dictionary<int, string>();
            foreach (TeacherRecord tr in Teacher.SelectAll())
            {
                if (tr.Status == TeacherRecord.TeacherStatus.刪除)
                    continue;

                int tid = int.Parse(tr.ID);
                string TName=tr.Name;
                if (!string.IsNullOrWhiteSpace(tr.Nickname))
                    TName = tr.Name + "(" + tr.Nickname + ")";
                
                intTeacherNameDict.Add(tid, TName);
            }

            if (_UserSelectType == SelectType.學生)
            {
                
                // 取得學生資料
                foreach (StudentRecord stud in Student.SelectByIDs(_studIDList))
                    _studDataDict.Add(stud.ID, stud);

                // 取得晤談紀錄
                List<UDT_CounselStudentInterviewRecordDef> dataList = _UDTTransfer.GetCounselStudentInterviewRecordByStudentIDList(_studIDList);

                // 透過 query 依照班級序號、班級名稱、學號座號排序
                _studIDList = Utility.SortStudentID1(_studIDList);

                foreach (string studID in _studIDList)
                {
                    int sid = int.Parse(studID);
                    string studName = "";
                    string StudNumber = "";
                    string ClassName = "";
                    string StudSeatNo = "";
                    if (_studDataDict.ContainsKey(studID))
                    {
                        studName = _studDataDict[studID].Name;
                        StudNumber = _studDataDict[studID].StudentNumber;
                        if (_studDataDict[studID].Class != null)
                            ClassName = _studDataDict[studID].Class.Name;

                        if (_studDataDict[studID].SeatNo.HasValue)
                            StudSeatNo = _studDataDict[studID].SeatNo.Value.ToString();
                    }

                    List<UDT_CounselStudentInterviewRecordDef> studInterviewList = (from da in dataList where da.StudentID == sid orderby da.InterviewDate select da).ToList();

                    //// 當沒有資料顯示一張有名稱空的
                    //if (studInterviewList.Count == 0)
                    //{
                    //    Dictionary<string, string> mapDict1 = new Dictionary<string, string>();
                    //    mapDict1.Add("校名", SchoolName);
                    //    mapDict1.Add("學生姓名", studName);
                    //    mapDict1.Add("學號", StudNumber);
                    //    mapDict1.Add("班級", ClassName);
                    //    mapDict1.Add("座號", StudSeatNo);
                    //    _dataDictList.Add(mapDict1);
                    //}

                    foreach (UDT_CounselStudentInterviewRecordDef data in studInterviewList)
                    {
                        Dictionary<string, string> mapDict = new Dictionary<string, string>();
                        mapDict.Add("校名", SchoolName);
                        mapDict.Add("學生姓名", studName);
                        mapDict.Add("學號", StudNumber);
                        mapDict.Add("班級", ClassName);
                        if (intTeacherNameDict.ContainsKey(data.TeacherID))
                            mapDict.Add("晤談老師", intTeacherNameDict[data.TeacherID]);

                        mapDict.Add("晤談編號", data.InterviewNo);
                        mapDict.Add("座號", StudSeatNo);
                        mapDict.Add("晤談對象", data.IntervieweeType);
                        mapDict.Add("晤談方式", data.InterviewType);
                        if (data.InterviewDate.HasValue)
                            mapDict.Add("晤談日期", data.InterviewDate.Value.ToShortDateString());
                        mapDict.Add("時間", data.InterviewTime);
                        mapDict.Add("地點", data.Place);
                        mapDict.Add("參與人員", ParseUDTXML1(data.Attendees));
                        mapDict.Add("晤談事由", data.Cause);
                        mapDict.Add("輔導方式", ParseUDTXML1(data.CounselType));
                        mapDict.Add("輔導歸類", ParseUDTXML1(data.CounselTypeKind));
                        mapDict.Add("內容要點", data.ContentDigest);
                        mapDict.Add("記錄者姓名", data.AuthorName);
                        _dataDictList.Add(mapDict);
                    }

                }
            }

            if (_UserSelectType == SelectType.教師)
            {
                List<int> sortStudIDList = new List<int>();
                // 透過教師取得所屬晤談紀錄
                List<UDT_CounselStudentInterviewRecordDef> InterviewRecorT = _UDTTransfer.GetCounselStudentInterviewRecordByTeacherIDList(_TeacherIDList);
                // 取得晤談紀錄內學生id
                List<string> InterviewRecorStudIDList = new List<string>();
                foreach (UDT_CounselStudentInterviewRecordDef data in InterviewRecorT)
                {
                    if (!sortStudIDList.Contains(data.StudentID))
                        sortStudIDList.Add(data.StudentID);

                    string key = data.StudentID.ToString();
                    if (!InterviewRecorStudIDList.Contains(key))
                        InterviewRecorStudIDList.Add(key);
                }
                // 取得學生資訊
                Dictionary<int, StudentRecord> InterviewRecorStudDict = new Dictionary<int, StudentRecord>();
                foreach (StudentRecord rec in Student.SelectByIDs(InterviewRecorStudIDList))
                {
                    int sid = int.Parse(rec.ID);
                    if (!InterviewRecorStudDict.ContainsKey(sid))
                        InterviewRecorStudDict.Add(sid, rec);
                }
                
                // 轉換教師ID int 
                List<int> intTeacherIDList = new List<int>();
                foreach (string tid in _TeacherIDList)
                    intTeacherIDList.Add(int.Parse(tid));

                sortStudIDList = Utility.SortStudentID2(sortStudIDList);                
                // 組資料
                foreach (int id in intTeacherIDList)
                {
                
                    List<UDT_CounselStudentInterviewRecordDef> dataTT = (from data in InterviewRecorT where data.TeacherID == id orderby data.StudentID,data.InterviewDate  select data).ToList();
                    // 依班級順序、班級名稱、學生座號排序後加入
                    List<UDT_CounselStudentInterviewRecordDef> dataT = new List<UDT_CounselStudentInterviewRecordDef>();
                    foreach (int ssid in sortStudIDList)
                    {
                        foreach (UDT_CounselStudentInterviewRecordDef data in dataTT.Where(x => x.StudentID == ssid))
                            dataT.Add(data);
                    }

                    foreach (UDT_CounselStudentInterviewRecordDef data in dataT)
                    {
                        string studName = "";
                        string StudNumber = "";
                        string ClassName = "";
                        string StudSeatNo = "";
                        if (InterviewRecorStudDict.ContainsKey(data.StudentID))
                        {
                            studName = InterviewRecorStudDict[data.StudentID].Name;
                            StudNumber = InterviewRecorStudDict[data.StudentID].StudentNumber;
                            if (InterviewRecorStudDict[data.StudentID].Class != null)
                                ClassName = InterviewRecorStudDict[data.StudentID].Class.Name;

                            if (InterviewRecorStudDict[data.StudentID].SeatNo.HasValue)
                                StudSeatNo = InterviewRecorStudDict[data.StudentID].SeatNo.Value.ToString();
                        }

                        Dictionary<string, string> mapDict = new Dictionary<string, string>();
                        mapDict.Add("校名", SchoolName);
                        mapDict.Add("學生姓名", studName);
                        mapDict.Add("學號", StudNumber);
                        mapDict.Add("班級", ClassName);
                        if (intTeacherNameDict.ContainsKey(data.TeacherID))
                            mapDict.Add("晤談老師", intTeacherNameDict[data.TeacherID]);

                        mapDict.Add("晤談編號", data.InterviewNo);
                        mapDict.Add("座號", StudSeatNo);
                        mapDict.Add("晤談對象", data.IntervieweeType);
                        mapDict.Add("晤談方式", data.InterviewType);
                        if (data.InterviewDate.HasValue)
                            mapDict.Add("晤談日期", data.InterviewDate.Value.ToShortDateString());
                        mapDict.Add("時間", data.InterviewTime);
                        mapDict.Add("地點", data.Place);
                        mapDict.Add("參與人員", ParseUDTXML1(data.Attendees));
                        mapDict.Add("晤談事由", data.Cause);
                        mapDict.Add("輔導方式", ParseUDTXML1(data.CounselType));
                        mapDict.Add("輔導歸類", ParseUDTXML1(data.CounselTypeKind));
                        mapDict.Add("內容要點", data.ContentDigest);
                        mapDict.Add("記錄者姓名", data.AuthorName);
                        _dataDictList.Add(mapDict);
                    }
                }

            }

            // word 資料合併
            Document doc = new Document();
            doc.Sections.Clear();
                        
            // 比對欄位名稱放值
            List<string> mapFieldName = new List<string>();
            mapFieldName.Add("校名");
            mapFieldName.Add("學生姓名");
            mapFieldName.Add("學號");
            mapFieldName.Add("班級");
            mapFieldName.Add("晤談老師");
            mapFieldName.Add("晤談編號");
            mapFieldName.Add("座號");
            mapFieldName.Add("晤談對象");
            mapFieldName.Add("晤談方式");
            mapFieldName.Add("晤談日期");
            mapFieldName.Add("時間");
            mapFieldName.Add("地點");
            mapFieldName.Add("參與人員");
            mapFieldName.Add("晤談事由");
            mapFieldName.Add("輔導方式");
            mapFieldName.Add("輔導歸類");
            mapFieldName.Add("內容要點");
            mapFieldName.Add("記錄者姓名");


            foreach (Dictionary<string, string> data in _dataDictList)
            {
                DataTable dt = new DataTable();
                // 建立欄位名稱
                foreach (string name in mapFieldName)
                    dt.Columns.Add(name, typeof(string));

                DataRow dr = dt.NewRow();
                foreach (string name in mapFieldName)
                {
                    if (data.ContainsKey(name))
                        dr[name] = data[name];
                }
                dt.Rows.Add(dr);
               Document docTemplate = new Document(new MemoryStream(_DocTemplate));
               docTemplate.MailMerge.FieldMergingCallback = new InsertDocumentAtMailMergeHandler();
               //DocumentBuilder _builder = new DocumentBuilder(docTemplate);
               //docTemplate.MailMerge.MergeField += new Aspose.Words.Reporting.MergeFieldEventHandler(MailMerge_MergeField);
                docTemplate.MailMerge.RemoveEmptyParagraphs = true;
                docTemplate.MailMerge.Execute(dt);
                docTemplate.MailMerge.DeleteFields();
                doc.Sections.Add(doc.ImportNode(docTemplate.Sections[0], true));
            }
            e.Result = doc;

        }

        private class InsertDocumentAtMailMergeHandler : IFieldMergingCallback
        {
            public void FieldMerging(FieldMergingArgs e)
            {
                DocumentBuilder _builder = new DocumentBuilder(e.Document);

            }

            public void ImageFieldMerging(ImageFieldMergingArgs args)
            {
                
            }
        }

        //void MailMerge_MergeField(object sender, Aspose.Words.Reporting.MergeFieldEventArgs e)
        //{
            
        //}

        /// <summary>
        /// 解析 XML 內資料
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        private string ParseUDTXML1(string strData)
        {
            string str = "";
            List<string> data = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append("<root>");
            sb.Append(strData);
            sb.Append("</root>");
            XElement elmRoot = XElement.Parse(sb.ToString());
            if (elmRoot != null)
            {
                foreach (XElement elm in elmRoot.Elements("Item"))
                {                    
                    if (elm.Attribute("remark") != null)
                    {
                        string rmk = elm.Attribute("name").Value + ":" + elm.Attribute("remark").Value;
                        data.Add(rmk);
                    }
                    else
                        data.Add(elm.Attribute("name").Value);
                }
            }
            if (data.Count > 0)
                str = string.Join("、", data.ToArray());

            return str;
        }

        private void StudInterviewDataReportForm_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            _Config = new ReportConfiguration(_ReportName);
            SetDefaultTemplate();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
            // 樣板
            _DocTemplate = _Config.Template.ToBinary();

            if (_DocTemplate == null)
            {
                FISCA.Presentation.Controls.MsgBox.Show("樣板解析失敗!");
                btnPrint.Enabled = true;
                return;
            }
            if (_UserSelectType == SelectType.學生)
                _studIDList = K12.Presentation.NLDPanels.Student.SelectedSource;
            else
                _TeacherIDList = K12.Presentation.NLDPanels.Teacher.SelectedSource;

            _bgWorker.RunWorkerAsync();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DownloadTemplate()
        { 
             if (_Config.Template == null)
            {
                FISCA.Presentation.Controls.MsgBox.Show("目前沒有任何範本");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Word (*.doc)|*.doc";
            saveDialog.FileName = "晤談紀錄表樣板";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _Config.Template.ToDocument().Save(saveDialog.FileName);
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("儲存失敗。" + ex.Message);
                    return;
                }

                try
                {
                    System.Diagnostics.Process.Start(saveDialog.FileName);
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("開啟失敗。" + ex.Message);
                    return;
                }
            }
        }

        private void UploadTemplate()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Word (*.doc)|*.doc";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openDialog.FileName);
                TemplateType type = TemplateType.Word;
                ReportTemplate template = new ReportTemplate(fileInfo, type);
                _Config.Template = template;
                _Config.Save();
            }        
        }

        /// <summary>
        /// 設定預設樣版
        /// </summary>
        private void SetDefaultTemplate()
        {
            if (_Config.Template == null)
            {
                ReportTemplate rptTmp = new ReportTemplate(Properties.Resources.學生輔導晤談紀錄表_樣版, TemplateType.Word);
                _Config.Template = rptTmp;
                _Config.Save();
            }
        }

        private void lnkDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DownloadTemplate();
        }

        private void lnkUpload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UploadTemplate();
        }
    }
}
