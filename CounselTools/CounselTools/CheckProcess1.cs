using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CounselTools
{
    /// <summary>
    /// 檢查本人概況資料
    /// </summary>
    public class CheckProcess1:ICheckProcess
    {
        string _GroupName, _StudentID;
        int _ErrorCount = 0, _TotalCount = 0;
        Dictionary<string, string> _ErrorDict = new Dictionary<string, string>();
        public void SetGroupName(string GroupName)
        {
            _GroupName = GroupName;
        }

        public void SetStudentID(string StudentID)
        {
            _StudentID = StudentID;
        }

        public Dictionary<string, string> GetErrorData()
        {
            return _ErrorDict;
        }

        public int GetErrorCount()
        {
            return _ErrorCount;
        }

        public int GetTotalCount()
        {
            return _TotalCount;
        }

        public void Start()
        {
            // 本人概況	生理缺陷	MULTI_ANSWER
            // 本人概況	血型	SINGLE_ANSWER
            // 本人概況	身高	SEMESTER
            // 本人概況	宗教	SINGLE_ANSWER
            // 本人概況	原住民血統	SINGLE_ANSWER
            // 本人概況	曾患特殊疾病	MULTI_ANSWER
            // 本人概況	體重	SEMESTER

            if (Gobal._single_recordDict.ContainsKey(_StudentID))
            {
                foreach (DataRow dr in Gobal._single_recordDict[_StudentID])
                {
                    string key=dr["key"].ToString();

                    if (key == _GroupName + "_血型")
                    {
                        if (dr["data"].ToString().Trim() == "")
                        {
                            _ErrorCount++;

                        }
                        _TotalCount++;
                    }


                    if (key == _GroupName + "_宗教")
                    {
                        if (dr["data"].ToString().Trim() == "")
                        {
                            _ErrorCount++;

                        }
                        _TotalCount++;
                    }


                    if (key == _GroupName + "_原住民血統")
                    {
                        if (dr["data"].ToString().Trim() == "")
                        {
                            _ErrorCount++;

                        }
                        _TotalCount++;
                    }
                }
            }

        }

        public string GetMessage()
        {
            if (_ErrorCount > 0)
            {
                return "" + _ErrorCount + "/" + _TotalCount;
            }
            else
                return "";
        }
    }
}
