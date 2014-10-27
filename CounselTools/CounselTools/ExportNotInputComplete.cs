using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Cells;
using System.ComponentModel;
using System.Text;
using System.Data;

namespace CounselTools
{
    public class ExportNotInputABCardComplete
    {
        List<string> _StudentIDList;
        BackgroundWorker _bgLoadData;

        Dictionary<string, Dictionary<string, string>> _StudentNonInputDict;

        public ExportNotInputABCardComplete(List<string> StudentIDList)
        {
            _StudentNonInputDict = new Dictionary<string, Dictionary<string, string>>();
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

                _StudentNonInputDict.Clear();

                string cp1GName = "本人概況";
                foreach (string studID in _StudentIDList)
                {
                    // 開始檢查
                    CheckProcess1 cp1 = new CheckProcess1();
                    
                    cp1.SetGroupName(cp1GName);
                    cp1.SetStudentID(studID);
                    if (cp1.GetErrorCount() > 0)
                    {
                        if (!_StudentNonInputDict.ContainsKey(studID))
                            _StudentNonInputDict.Add(studID,new Dictionary<string,string>());

                        if (!_StudentNonInputDict[studID].ContainsKey(cp1GName))
                            _StudentNonInputDict[studID].Add(cp1GName, cp1.GetMessage());
                        
                    }
                
                }               
                

            }
            catch {


                e.Cancel = true;
            }
        }

        public void ExportData()
        { 
        
        }
    }
}
