using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.IO;

namespace CounselTools
{
    public class ExportNotInputABCardComplete
    {
        List<string> _StudentIDList;
        BackgroundWorker _bgLoadData;

        

        public ExportNotInputABCardComplete(List<string> StudentIDList)
        {            
            _bgLoadData = new BackgroundWorker();
            _bgLoadData.DoWork += _bgLoadData_DoWork;
            _bgLoadData.RunWorkerCompleted += _bgLoadData_RunWorkerCompleted;
            // 學生編號
            _StudentIDList = StudentIDList;

            // 載入資料
            _bgLoadData.RunWorkerAsync();

        }

        void _bgLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error !=null)
            {
                FISCA.Presentation.Controls.MsgBox.Show("產生過程發生錯誤,"+e.Error.Message);
            }
            else
            {
                Workbook wb = e.Result as Workbook;
                if (wb != null)
                {
                    Utility.CompletedXls("輔導綜合紀錄表未輸入完整名單", wb);
                }
            }
            
        }

        void _bgLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Gobal._multiple_recordDict.Clear();
                Gobal._priority_dataDict.Clear();
                Gobal._relativeDict.Clear();
                Gobal._semester_dataDict.Clear();
                Gobal._siblingDict.Clear();
                Gobal._single_recordDict.Clear();
                Gobal._yearly_dataDict.Clear();

                Gobal._multiple_recordDict = Utility.GetABCardAnswerDataByStudentIDList(_StudentIDList, "multiple_record");
                Gobal._priority_dataDict = Utility.GetABCardAnswerDataByStudentIDList(_StudentIDList, "priority_data");
                Gobal._relativeDict = Utility.GetABCardAnswerDataByStudentIDList(_StudentIDList, "relative");
                Gobal._semester_dataDict = Utility.GetABCardAnswerDataByStudentIDList(_StudentIDList, "semester_data");
                Gobal._siblingDict = Utility.GetABCardAnswerDataByStudentIDList(_StudentIDList, "sibling");
                Gobal._single_recordDict = Utility.GetABCardAnswerDataByStudentIDList(_StudentIDList, "single_record");
                Gobal._yearly_dataDict = Utility.GetABCardAnswerDataByStudentIDList(_StudentIDList, "yearly_data");
                                

                // 取得學生資料
                List<ClassStudent> ClassStudents = Utility.GetClassStudentByStudentIDList(_StudentIDList);

                string cp1GName = "本人概況";
                string cp2GName = "家庭狀況";
                string cp3GName = "學習狀況";
                string cp4GName = "自傳";
                string cp5GName = "自我認識";
                string cp6GName = "生活感想";
                string cp7GName = "畢業後計畫";
                string cp8GName = "備註";
                string cp9GName = "適應情形";

                foreach (ClassStudent cs in ClassStudents)
                {
                    // 開始檢查
                    CheckProcess1 cp1 = new CheckProcess1();
                    
                    cp1.SetGroupName(cp1GName);
                    cp1.SetStudentID(cs.StudentID);
                    cp1.Start();
                    if (cp1.GetErrorCount() > 0)
                    {
                        if (!cs.NonInputCompleteDict.ContainsKey(cp1GName))
                            cs.NonInputCompleteDict.Add(cp1GName, cp1.GetMessage());
                                                   
                    }
                
                }


                // 讀取樣版
                Workbook wb = new Workbook(new MemoryStream(Properties.Resources.未輸入完整名單樣版));

                // 綜合紀錄索引
                Dictionary<string, int> gpColIdx = new Dictionary<string, int>();
                gpColIdx.Add(cp1GName, 4);
                gpColIdx.Add(cp2GName, 5);
                gpColIdx.Add(cp3GName, 6);
                gpColIdx.Add(cp4GName, 7);
                gpColIdx.Add(cp5GName, 8);
                gpColIdx.Add(cp6GName, 9);
                gpColIdx.Add(cp7GName, 10);
                gpColIdx.Add(cp8GName, 11);
                gpColIdx.Add(cp9GName, 12);


                // 學號,班級,座號,姓名,本人概況,家庭狀況,學習狀況,自傳,自我認識,生活感想,畢業後計畫,備註,適應情形
                int rowIdx = 1;
                foreach (ClassStudent cs in ClassStudents)
                {
                    // 有缺才填入
                    if (cs.NonInputCompleteDict.Count > 0)
                    {
                        wb.Worksheets[0].Cells[rowIdx, 0].PutValue(cs.StudentNumber);
                        wb.Worksheets[0].Cells[rowIdx,1].PutValue(cs.ClassName);
                        wb.Worksheets[0].Cells[rowIdx, 2].PutValue(cs.SeatNo);
                        wb.Worksheets[0].Cells[rowIdx, 3].PutValue(cs.StudentName);
                        // 填入缺漏資料
                        foreach (string key in cs.NonInputCompleteDict.Keys)
                        {
                            if (gpColIdx.ContainsKey(key))
                                wb.Worksheets[0].Cells[rowIdx, gpColIdx[key]].PutValue(cs.NonInputCompleteDict[key]);
                        }
                        rowIdx++;
                    }                
                }
                wb.Worksheets[0].AutoFitColumns();
                e.Result = wb;
            }
            catch {


                e.Cancel = true;
            }
        }
               
    }
}
