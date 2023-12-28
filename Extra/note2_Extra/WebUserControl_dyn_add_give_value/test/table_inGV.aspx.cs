using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test
{
    public partial class table_inGV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GenBasicGV();
            else 
            {
                // 取上次(增加/減少一行時)的DataTable 
                DataTable dt = (DataTable)ViewState["dt"];
                // 同步
                SynDt(ref dt);
            }

        }

        private void GenBasicGV()
        {
            // 貨物
            DataTable dt = new DataTable();
            dt.Columns.Add("A");
            dt.Columns.Add("B");
            dt.Columns.Add("C");
            dt.Columns.Add("D");
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);

            ViewState["dt"] = dt;
            GV.DataSource = dt;
            GV.DataBind();
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            try
            {
                // 在PageLoad已同步
                DataTable dt = (DataTable)ViewState["dt"];

                // 開新的一行 
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                // 重新繫結 GridView 和 設定 ViewState
                ReSetGV(dt);
            }
            catch (Exception ex)
            {
                //Helper.Alert(ex.Message, Page);
                //Helper.WriteLog(ex, ErrorLogFileName);
            }
        }

        protected void Del_Click(object sender, EventArgs e)
        {
            if (GV.Rows.Count == 1)
            {
                //Do.Alert("不能刪最後一行", Page);
                return;
            }

            try
            {
                // 在PageLoad已同步
                DataTable dt = (DataTable)ViewState["dt"];

                // 刪按按鈕 的 這一行
                Button thisBtn = sender as Button;
                GridViewRow row = thisBtn.NamingContainer as GridViewRow;
                int selectedRowIndex = row.RowIndex;
                dt.Rows.RemoveAt(selectedRowIndex);

                // 重新繫結 GridView 和 設定 ViewState
                ReSetGV(dt);
            }
            catch (Exception ex)
            {
                //Helper.Alert(ex.Message, Page);
                //Helper.WriteLog(ex, ErrorLogFileName);
            }

        }

        private void SynDt(ref DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // 取得前端

                TextBox a = (TextBox)GV.Rows[i].Cells[1].FindControl("A");
                TextBox b = (TextBox)GV.Rows[i].Cells[2].FindControl("B");
                TextBox c = (TextBox)GV.Rows[i].Cells[1].FindControl("C");
                TextBox d = (TextBox)GV.Rows[i].Cells[2].FindControl("D");


                // 接收資料
                //dt.Rows[i]["selected"] = selected.Checked == true ? "1" : "0";
                dt.Rows[i]["A"] = a.Text.Trim();
                dt.Rows[i]["B"] = b.Text.Trim();
                dt.Rows[i]["C"] = c.Text.Trim();
                dt.Rows[i]["D"] = d.Text.Trim();

            }
        }

        private void ReSetGV(DataTable dt)
        {
            ViewState["dt"] = dt;

            // 給予行數，但沒有資料
            GV.DataSource = dt;
            GV.DataBind();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // 取得前端

                TextBox a = (TextBox)GV.Rows[i].Cells[1].FindControl("A");
                TextBox b = (TextBox)GV.Rows[i].Cells[2].FindControl("B");
                TextBox c = (TextBox)GV.Rows[i].Cells[1].FindControl("C");
                TextBox d = (TextBox)GV.Rows[i].Cells[2].FindControl("D");


                // 輸入資料
                //dt.Rows[i]["selected"] = selected.Checked == true ? "1" : "0";
                a.Text = dt.Rows[i]["A"].ToString();
                b.Text = dt.Rows[i]["B"].ToString();
                c.Text = dt.Rows[i]["C"].ToString();
                d.Text = dt.Rows[i]["D"].ToString();

            }
        }

    }
}