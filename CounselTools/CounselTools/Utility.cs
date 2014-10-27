using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.Data;
using System.Data;

namespace CounselTools
{
   public class Utility
    {
       /// <summary>
        /// 透過學生ID取得輔導-DataRow
       /// </summary>
       /// <param name="StudentIDList"></param>
       /// <returns></returns>
       public static Dictionary<string, List<DataRow>> GetABCardAnswerDataByStudentIDList(List<string> StudentIDList,string Type)
       {
           Dictionary<string, List<DataRow>> retVal = new Dictionary<string, List<DataRow>>();
           string query = "";
           switch (Type)
           { 
               case "multiple_record":
                   query = "select * from $ischool.counsel.multiple_record";
                   break;

               case "priority_data":
                   query = "select * from $ischool.counsel.priority_data";
                   break;

               case "relative":
                   query = "select * from $ischool.counsel.relative";
                   break;

               case "semester_data":
                   query = "select * from $ischool.counsel.semester_data";
                   break;

               case "sibling":
                   query = "select * from $ischool.counsel.sibling";
                   break;

               case "single_record":
                   query = "select * from $ischool.counsel.single_record";
                   break;

               case "yearly_data":
                   query = "select * from $ischool.counsel.yearly_data";
                   break;
           }

           if (query != "")
           {
               query += " where ref_student_id in("+string.Join(",",StudentIDList.ToArray())+")";

               QueryHelper qh = new QueryHelper();
               DataTable dt = qh.Select(query);

               foreach (DataRow dr in dt.Rows)
               {
                   string id = dr["ref_student_id"].ToString();
                   if (!retVal.ContainsKey(id))
                       retVal.Add(id, new List<DataRow>());

                   retVal[id].Add(dr);               
               }
           }

           return retVal;
       }      
    }
}
