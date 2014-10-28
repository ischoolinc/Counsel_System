using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CounselTools
{
    /// <summary>
    /// 檢查資料
    /// </summary>
    public class CheckDataTransfer
    {
        /// <summary>
        /// SINGLE_ANSWER
        /// </summary>
        /// <param name="GroupName"></param>
        /// <param name="Items"></param>
        /// <param name="StudentID"></param>
        /// <returns></returns>
        public static int CheckSINGLE_ANSWER_Error(string GroupName,List<string> Items, string StudentID)
        {
            int retError = 0;
            if (Gobal._single_recordDict.ContainsKey(StudentID))
            {
                Dictionary<string, string> chkDict = new Dictionary<string, string>();

                foreach (DataRow dr in Gobal._single_recordDict[StudentID])
                {
                    string key = dr["key"].ToString();
                    if (!chkDict.ContainsKey(key))
                        chkDict.Add(key, dr["data"].ToString().Trim());
                }

                foreach (string ss in Items)
                {
                    string key = GroupName + "_" + ss;
                    if (chkDict.ContainsKey(key))
                    {
                        if (chkDict[key] == "")
                            retError++;
                    }
                    else
                        retError++;
                }
            }
            else
            {
                retError = Items.Count;
            }

            return retError;
        }

        public static int CheckMULTI_ANSWER_Error(string GroupName, List<string> Items, string StudentID)
        {
            int retError = 0;
            if (Gobal._multiple_recordDict.ContainsKey(StudentID))
            {
                Dictionary<string, string> chkDict = new Dictionary<string, string>();

                foreach (DataRow dr in Gobal._multiple_recordDict[StudentID])
                {
                    string key = dr["key"].ToString();
                    if (!chkDict.ContainsKey(key))
                        chkDict.Add(key, dr["data"].ToString().Trim());
                }

                foreach (string ss in Items)
                {
                    string key = GroupName + "_" + ss;
                    if (chkDict.ContainsKey(key))
                    {
                        if (chkDict[key] == "")
                            retError++;
                    }
                    else
                        retError++;
                }
            }
            else
            {
                retError = Items.Count;
            }

            return retError;
        }

        public static int CheckSEMESTER_Error(string GroupName, List<string> Items, string StudentID)
        {
            int retError = 0;
            if (Gobal._semester_dataDict.ContainsKey(StudentID))
            {
                Dictionary<string, DataRow> chkDict = new Dictionary<string, DataRow>();
                foreach (DataRow dr in Gobal._semester_dataDict[StudentID])
                {
                    string key = dr["key"].ToString();
                    if (!chkDict.ContainsKey(key))
                        chkDict.Add(key, dr);

                    foreach (string ss in Items)
                    {
                        string key1 = GroupName + "_" + ss;
                        if (chkDict.ContainsKey(key))
                        {
                            if (chkDict[key1] ==null)
                                retError++;
                        }
                        else
                            retError++;
                    }
                }
            }
            else
            {
                retError = Items.Count;
            }
            return retError;
        }
    }
}
