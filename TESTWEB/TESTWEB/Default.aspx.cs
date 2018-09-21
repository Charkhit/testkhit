using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    public DataTable dt = new DataTable();
    public DataTable dt2 = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        sumtime();
        GridView1.DataSource = dt2;
        GridView1.DataBind();
    }
    public void sumtime()
    {
        string[] strcol = { "Date", "Start time", "End time", "Mobile No", "Promotion" };
        foreach (var cd in strcol)
        {
            dt.Columns.Add(cd);
        }
        dt.Columns.Add("fee", typeof(double));
        DataRow dr;
        string lines = "data.txt";
        var localFilePath = Server.MapPath("\\" + lines);
        string[] text = File.ReadAllLines(localFilePath);
        foreach (var x in text)
        {
            var foos = x.ToString();
            var fooArray = foos.Split('|');  // now you have an array of 3 strings
            foos = String.Join("|", fooArray);
            dr = dt.NewRow();
            dr["Date"] = fooArray[0].ToString();
            dr["Start time"] = fooArray[1].ToString();
            dr["End time"] = fooArray[2].ToString();
            dr["Mobile No"] = fooArray[3].ToString();
            dr["Promotion"] = fooArray[4].ToString();
            DateTime starttime = DateTime.ParseExact(fooArray[0].ToString() + " " + fooArray[1].ToString(), "dd/MM/yyyy HH:mm:ss", null);
            DateTime endtime = DateTime.ParseExact(fooArray[0].ToString() + " " + fooArray[2].ToString(), "dd/MM/yyyy HH:mm:ss", null);
            var sumtime = (starttime - endtime).TotalMinutes;
            double summon = timetomoney(sumtime, fooArray[4].ToString());
            dr["fee"] = summon.ToString();
            dt.Rows.Add(dr);
        }

        DataRow dr2;
        dt2.Columns.Add("telno");
        dt2.Columns.Add("SumTime", typeof(double));
        dt2.Columns.Add("fees", typeof(double));
        for (int z = 0; z < dt.Rows.Count; z++)
        {
            DateTime starttime = DateTime.ParseExact(dt.Rows[z]["Date"].ToString() + " " + dt.Rows[z]["Start time"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
            DateTime endtime = DateTime.ParseExact(dt.Rows[z]["Date"].ToString() + " " + dt.Rows[z]["End time"].ToString().ToString(), "dd/MM/yyyy HH:mm:ss", null);
            var SumTime = ((starttime - endtime).TotalMinutes);
            Console.WriteLine(SumTime);
            if (searchno(dt.Rows[z]["Mobile No"].ToString(), (double)dt.Rows[z]["fee"], SumTime) == false)
            {
                SumTime = SumTime * -1;
                dr2 = dt2.NewRow();
                dr2["telno"] = dt.Rows[z]["Mobile No"].ToString();
                dr2["SumTime"] = SumTime;
                dr2["fees"] = (double)dt.Rows[z]["fee"];
                Console.WriteLine("insert\t" + dt.Rows[z]["Mobile No"].ToString() + " = " + dt.Rows[z]["fee"].ToString());
                dt2.Rows.Add(dr2);
            }
        }
        Console.WriteLine("\n\n\n=======================================SUM=========================================\n");
        for (int z = 0; z < dt2.Rows.Count; z++)
        {
            Console.WriteLine(dt2.Rows[z]["telno"].ToString() + " : " + dt2.Rows[z]["fees"].ToString() + " Bath" + dt2.Rows[z]["SumTime"].ToString() + " Min");
        }
    }
    public bool searchno(string telno, Double fee, double time)
    {
        time = time * -1;
        for (int a = 0; a < dt2.Rows.Count; a++)
        {

            if (dt2.Rows[a]["telno"].ToString() == telno)
            {
                
                dt2.Rows[a]["SumTime"] = (double)dt2.Rows[a]["SumTime"] + time;                
                Console.WriteLine("update\t" + dt2.Rows[a]["telno"].ToString() + " : " + dt2.Rows[a]["fees"].ToString() + " + " + fee.ToString() + " = " + (dt2.Rows[a]["fees"] = (double)dt2.Rows[a]["fees"] + fee).ToString());
                return true;
            }

        }
        return false;
    }
    public double timetomoney(double time, string Pro)
    {
        double Promotion = 0;
        if (Pro == "P1")
        {
            Promotion = 3;
        }
        string sumSatangtoBath = "0";
        string sumSatang = null;
        int TimeSec = 0;
        var strtime = time.ToString();
        var TimeArray = strtime.Split('.');  // now you have an array of 3 strings
        strtime = String.Join(".", TimeArray);
        int TimeMin = int.Parse(TimeArray[0]);
        //string ti = TimeArray[1];
        if (TimeArray[1].ToString() == null)
        {
            TimeArray[1] = ".00";
        }
        if (TimeArray[1].Length > 3)
        {
            TimeSec = int.Parse(TimeArray[1].Substring(0, 2));
            int milli = int.Parse(TimeArray[1].Substring(3, 1));
            if (milli > 5)
            {
                TimeSec++;
            }
        }
        else
        {
            TimeSec = int.Parse(TimeArray[1].ToString());
        }
        if (TimeSec > 60)
        {
            double x = ((double)TimeSec / 60);
            sumSatang = x.ToString();
            sumSatangtoBath = sumSatang.ToString().Substring(0, 1);
            if (sumSatang.Length < 4)
            {
                sumSatang = sumSatang.ToString().Substring(2, 1);
                sumSatang += "0";
            }
            else
            {
                sumSatang = sumSatang.ToString().Substring(2, 2);
            }
        }
        else
        {
            sumSatang = TimeSec.ToString();
            if (sumSatang.Length == 1)
            {
                sumSatang += "0";
            }
        }
        double sum = 1 + TimeMin;
        if (sum < 0)
        {
            sum = (sum * -1) + Promotion;
            string formatmoney = ((sum + int.Parse(sumSatangtoBath)).ToString() + "." + sumSatang);
            return double.Parse(formatmoney);
        }
        else
        {
            return Promotion;
        }
    }
}