using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace custom_test
{
    public partial class P2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenBasicGV();

                try // 不一定是 P3 傳來的
                {
                    P3 p3 = (P3)Context.Handler;
                    DataTable item_dt = Context.Items["item_dt"] as DataTable;
                    DataTable box_dt = Context.Items["box_dt"] as DataTable;
                    if (item_dt != null)
                        SetGVData(item_dt, box_dt);
                }
                catch { } // 不是由P3轉頁過來的就算了，又不會怎麼樣

            }
            else
            {
                // 維持多選的按鈕外觀
                if (muti_sele.Checked)
                    On_Off_Sele_Range.CssClass = "btngreen";
                else
                    On_Off_Sele_Range.CssClass = "";
            }


        }


        #region -- About GridView -- 

        /// <summary>
        /// 生成第一條 Item 和 Box 的 DT 和 GV
        /// </summary>
        private void GenBasicGV()
        {
            // 貨物
            DataTable dt = new DataTable();
            dt.Columns.Add("item_no");
            dt.Columns.Add("item_selected");
            dt.Columns.Add("box_no");
            dt.Columns.Add("askey_pn");
            dt.Columns.Add("desc_good");
            dt.Columns.Add("pack_qty");
            dt.Columns.Add("cart_qty");
            dt.Columns.Add("remark");
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);

            ViewState["item_dt"] = dt;
            Item_GV.DataSource = dt;
            Item_GV.DataBind();

            // 箱子
            dt.Clear();
            dt.Columns.Add("box_selected");
            dt.Columns.Add("nw");
            dt.Columns.Add("gw");
            dt.Columns.Add("size");
            dt.Columns.Add("boxs_item_no");
            dr = dt.NewRow();
            dt.Rows.Add(dr);

            ViewState["box_dt"] = dt;
            Box_GV.DataSource = dt;
            Box_GV.DataBind();

        }

        /// <summary>
        /// 取 TextBox 輸入，更新到 DataTable 
        /// </summary>
        private void SynDts(ref DataTable item_dt, ref DataTable box_dt)
        {

            // 貨物
            for (int i = 0; i < item_dt.Rows.Count; i++)
            {
                // 取得前端
                CheckBox item_selected = (CheckBox)Item_GV.Rows[i].Cells[1].FindControl("item_selected");
                Label box_no = (Label)Item_GV.Rows[i].Cells[0].FindControl("box_no");
                TextBox askey_pn = (TextBox)Item_GV.Rows[i].Cells[2].FindControl("askey_pn");
                TextBox desc_good = (TextBox)Item_GV.Rows[i].Cells[3].FindControl("desc_good");
                TextBox pack_qty = (TextBox)Item_GV.Rows[i].Cells[4].FindControl("pack_qty");
                TextBox cart_qty = (TextBox)Item_GV.Rows[i].Cells[5].FindControl("cart_qty");
                TextBox remark = (TextBox)Item_GV.Rows[i].Cells[6].FindControl("remark");

                // 接收資料
                item_dt.Rows[i]["item_selected"] = item_selected.Checked == true ? "1" : "0";
                item_dt.Rows[i]["box_no"] = box_no.Text.Trim();
                item_dt.Rows[i]["askey_pn"] = askey_pn.Text.Trim();
                item_dt.Rows[i]["pack_qty"] = pack_qty.Text.Trim();
                item_dt.Rows[i]["cart_qty"] = cart_qty.Text.Trim();
                item_dt.Rows[i]["remark"] = remark.Text.Trim();
            }

            // 箱子
            for (int i = 0; i < box_dt.Rows.Count; i++)
            {
                // 取得前端
                CheckBox box_selected = (CheckBox)Box_GV.Rows[i].Cells[1].FindControl("box_selected");
                TextBox nw = (TextBox)Box_GV.Rows[i].Cells[2].FindControl("nw");
                TextBox gw = (TextBox)Box_GV.Rows[i].Cells[3].FindControl("gw");
                TextBox size = (TextBox)Box_GV.Rows[i].Cells[4].FindControl("size");
                Label boxs_item_no = (Label)Box_GV.Rows[i].Cells[5].FindControl("boxs_item_no");

                // 接收資料
                box_dt.Rows[i]["box_selected"] = box_selected.Checked == true ? "1" : "0";
                box_dt.Rows[i]["nw"] = nw.Text.Trim();
                box_dt.Rows[i]["gw"] = gw.Text.Trim();
                box_dt.Rows[i]["size"] = size.Text.Trim();
                box_dt.Rows[i]["boxs_item_no"] = boxs_item_no.Text.Trim();
            }
        }

        /// <summary>
        /// 繫結 GV 並 填入資料
        /// </summary>
        private void SetGVData(DataTable item_dt, DataTable box_dt)
        {
            // ------ 給予行數 -------
            ViewState["item_dt"] = item_dt;
            Item_GV.DataSource = item_dt;
            Item_GV.DataBind();

            ViewState["box_dt"] = box_dt;
            Box_GV.DataSource = box_dt;
            Box_GV.DataBind();

            // ------- 填入資料 -------

            // 貨物
            for (int i = 0; i < item_dt.Rows.Count; i++)
            {
                // 取得前端
                CheckBox item_selected = (CheckBox)Item_GV.Rows[i].Cells[1].FindControl("item_selected");
                Label box_no = (Label)Item_GV.Rows[i].Cells[0].FindControl("box_no");
                TextBox askey_pn = (TextBox)Item_GV.Rows[i].Cells[2].FindControl("askey_pn");
                TextBox desc_good = (TextBox)Item_GV.Rows[i].Cells[3].FindControl("desc_good");
                TextBox pack_qty = (TextBox)Item_GV.Rows[i].Cells[4].FindControl("pack_qty");
                TextBox cart_qty = (TextBox)Item_GV.Rows[i].Cells[5].FindControl("cart_qty");
                TextBox remark = (TextBox)Item_GV.Rows[i].Cells[6].FindControl("remark");

                // 放入資料
                item_selected.Checked = (item_dt.Rows[i]["item_selected"].ToString() == "1");
                box_no.Text = item_dt.Rows[i]["box_no"].ToString();
                askey_pn.Text = item_dt.Rows[i]["askey_pn"].ToString();
                desc_good.Text = item_dt.Rows[i]["desc_good"].ToString();
                pack_qty.Text = item_dt.Rows[i]["pack_qty"].ToString();
                cart_qty.Text = item_dt.Rows[i]["cart_qty"].ToString();
                remark.Text = item_dt.Rows[i]["remark"].ToString();
            }

            // 箱子
            for (int i = 0; i < box_dt.Rows.Count; i++)
            {
                // 取得前端
                CheckBox box_selected = (CheckBox)Box_GV.Rows[i].Cells[1].FindControl("box_selected");
                TextBox nw = (TextBox)Box_GV.Rows[i].Cells[2].FindControl("nw");
                TextBox gw = (TextBox)Box_GV.Rows[i].Cells[3].FindControl("gw");
                TextBox size = (TextBox)Box_GV.Rows[i].Cells[4].FindControl("size");
                Label boxs_item_no = (Label)Box_GV.Rows[i].Cells[5].FindControl("boxs_item_no");

                // 放入資料
                box_selected.Checked = (box_dt.Rows[i]["box_selected"].ToString() == "1");
                nw.Text = box_dt.Rows[i]["nw"].ToString();
                gw.Text = box_dt.Rows[i]["gw"].ToString();
                size.Text = box_dt.Rows[i]["size"].ToString();
                boxs_item_no.Text = box_dt.Rows[i]["boxs_item_no"].ToString();
            }

        }

        #endregion

        /// <summary>
        /// 匯入資料
        /// </summary>
        protected void load_data(object sender, EventArgs e)
        {
            try
            {
                // 取上次(增加/減少一行時)的DataTable 
                DataTable box_dt = (DataTable)ViewState["box_dt"];
                DataTable item_dt = (DataTable)ViewState["item_dt"];
                //  同步
                SynDts(ref item_dt, ref box_dt);

                // 找 按按鈕 的 這一行
                Button thisBtn = sender as Button;
                GridViewRow row = thisBtn.NamingContainer as GridViewRow;
                int selectedRowIndex = row.RowIndex; // 取行號
                // 帶入資料
                item_dt.Rows[selectedRowIndex]["desc_good"] = item_dt.Rows[selectedRowIndex]["askey_pn"];

                // 真正的話應該去資料庫...

                // 重新繫結 GridView 和 設定 ViewState
                SetGVData(item_dt, box_dt);
            }
            catch (Exception ex)
            {
                //Helper.Alert(ex.Message, Page);
                //Helper.WriteLog(ex, ErrorLogFileName);
            }

        }
        
        #region add/del , box/item

        /// <summary>
        /// 刪除這一個貨物
        /// </summary>
        protected void del_item(object sender, EventArgs e)
        {
            if (Item_GV.Rows.Count == 1)
            {
                //Do.Alert("不能刪最後一行", Page);
                return;
            }

            try
            {
                // 取上次(增加/減少一行時)的DataTable 
                DataTable box_dt = (DataTable)ViewState["box_dt"];
                DataTable item_dt = (DataTable)ViewState["item_dt"];
                //  同步
                SynDts(ref item_dt, ref box_dt);

                // 刪 按 按鈕 的 這一行
                Button thisBtn = sender as Button;  // 把 sender 召喚者，轉回為 Button 的物件。
                GridViewRow row = thisBtn.NamingContainer as GridViewRow;   // 找這個 Button 所在的行
                int selectedRowIndex = row.RowIndex; // 取行號
                item_dt.Rows.RemoveAt(selectedRowIndex);


                foreach (DataRow dr in box_dt.Rows)
                {
                    // 每一個箱子都有什麼貨號
                    List<string> dr_items = dr["boxs_item_no"].ToString().Split(',').ToList();

                    // 具這個「被刪貨號」的箱子..
                    if (dr_items.Contains((selectedRowIndex + 1).ToString()))
                    {
                        dr_items.Remove((selectedRowIndex + 1).ToString());
                        dr["boxs_item_no"] = string.Join(",", dr_items);
                    }

                    // 所有具這個「被刪貨號」之後的貨號的箱子…
                    List<string> new_dr_items = new List<string>();
                    foreach (string item in dr_items)
                    {
                        if (!string.IsNullOrEmpty(item) && int.Parse(item) > selectedRowIndex + 1)
                        {
                            new_dr_items.Add((int.Parse(item) - 1).ToString());
                            continue;
                        }
                        new_dr_items.Add(item);
                    }
                    dr["boxs_item_no"] = string.Join(",", new_dr_items);
                }


                // 重新繫結 GridView 和 設定 ViewState
                SetGVData(item_dt, box_dt);
            }
            catch (Exception ex)
            {
                //Helper.Alert(ex.Message, Page);
                //Helper.WriteLog(ex, ErrorLogFileName);
            }

        }

        /// <summary>
        /// 刪除這一個箱子
        /// </summary>
        protected void del_box(object sender, EventArgs e)
        {
            if (Box_GV.Rows.Count == 1)
            {
                //Do.Alert("不能刪最後一行", Page);
                return;
            }

            try
            {
                // 取上次(增加/減少一行時)的DataTable 
                DataTable box_dt = (DataTable)ViewState["box_dt"];
                DataTable item_dt = (DataTable)ViewState["item_dt"];
                //  同步
                SynDts(ref item_dt, ref box_dt);

                // 刪按按鈕 的 這一行
                Button thisBtn = sender as Button;
                GridViewRow row = thisBtn.NamingContainer as GridViewRow;
                int selectedRowIndex = row.RowIndex;
                box_dt.Rows.RemoveAt(selectedRowIndex);

                foreach (DataRow dr in item_dt.Rows)
                {
                    // 所有具這個「被刪的箱號」的貨物都沒有了箱號
                    if (dr["box_no"].ToString() == (selectedRowIndex + 1).ToString())
                        dr["box_no"] = "";
                    // 這個箱號「之後」的箱號都會被挪前
                    if (!string.IsNullOrEmpty(dr["box_no"].ToString()) // 排除本身沒有箱子
                        &&
                        int.Parse(dr["box_no"].ToString()) > selectedRowIndex + 1)
                        dr["box_no"] = int.Parse(dr["box_no"].ToString()) - 1;
                }
                // 重新繫結 GridView 和 設定 ViewState
                SetGVData(item_dt, box_dt);
            }
            catch (Exception ex)
            {
                //Helper.Alert(ex.Message, Page);
                //Helper.WriteLog(ex, ErrorLogFileName);
            }

        }

        /// <summary>
        /// 新增貨物
        /// </summary>
        protected void add_item(object sender, EventArgs e)
        {
            try
            {
                // 取上次(增加/減少一行時)的DataTable 
                DataTable box_dt = (DataTable)ViewState["box_dt"];
                DataTable item_dt = (DataTable)ViewState["item_dt"];
                // 同步
                SynDts(ref item_dt, ref box_dt);

                // 開新的一行 
                DataRow dr = item_dt.NewRow();
                item_dt.Rows.Add(dr);
                // 重新繫結 GridView 和 設定 ViewState
                SetGVData(item_dt, box_dt);
            }
            catch (Exception ex)
            {
                //Helper.Alert(ex.Message, Page);
                //Helper.WriteLog(ex, ErrorLogFileName);
            }
        }

        /// <summary>
        /// 新增一個箱子
        /// </summary>
        protected void add_box(object sender, EventArgs e)
        {
            try
            {
                // 取上次(增加/減少一行時)的DataTable 
                DataTable box_dt = (DataTable)ViewState["box_dt"];
                DataTable item_dt = (DataTable)ViewState["item_dt"];
                // 同步
                SynDts(ref item_dt, ref box_dt);

                // 開新的一行 
                DataRow dr = box_dt.NewRow();
                box_dt.Rows.Add(dr);
                // 重新繫結 GridView 和 設定 ViewState
                SetGVData(item_dt, box_dt);
            }
            catch (Exception ex)
            {
                //Helper.Alert(ex.Message, Page);
                //Helper.WriteLog(ex, ErrorLogFileName);
            }
        }

        #endregion
        
        /// <summary>
        /// 餘下的全部獨立包裝
        /// </summary>
        protected void all_in_div(object sender, EventArgs e)
        {
            try
            {
                // 取上次(增加/減少一行時)的DataTable 
                DataTable box_dt = (DataTable)ViewState["box_dt"];
                DataTable item_dt = (DataTable)ViewState["item_dt"];
                // 同步
                SynDts(ref item_dt, ref box_dt);

                // 沒有箱號的item 有多少個 ? 它們分別的index是？
                List<int> need_item_index = new List<int>();
                for (int i = 0; item_dt.Rows.Count > i; i++)
                    if (item_dt.Rows[i]["box_no"].ToString() == "")
                        need_item_index.Add(i);

                // 下一個箱號
                int next_box_no = box_dt.Rows.Count + 1;

                // 按貨號數目增加箱子 
                for (int i = 0; need_item_index.Count > i; i++)
                {
                    // 增加箱子
                    DataRow dr = box_dt.NewRow();
                    // 箱子中的貨號寫入
                    dr["boxs_item_no"] = need_item_index[i] + 1;

                    box_dt.Rows.Add(dr);
                }

                // 貨物給予相應的箱號
                for (int i = 0; item_dt.Rows.Count > i; i++)
                {
                    if (item_dt.Rows[i]["box_no"].ToString() == "")
                        item_dt.Rows[i]["box_no"] = next_box_no++;
                }

                // 重新繫結 GridView 和 設定 ViewState
                SetGVData(item_dt, box_dt);
            }
            catch (Exception ex)
            {
                //Helper.Alert(ex.Message, Page);
                //Helper.WriteLog(ex, ErrorLogFileName);
            }
        }

        /// <summary>
        /// 餘下的全部打包一箱
        /// </summary>
        protected void all_in_one(object sender, EventArgs e)
        {
            try
            {
                // 取上次(增加/減少一行時)的DataTable 
                DataTable box_dt = (DataTable)ViewState["box_dt"];
                DataTable item_dt = (DataTable)ViewState["item_dt"];
                // 同步
                SynDts(ref item_dt, ref box_dt);

                // 沒有箱號的 item 都加入該新箱，並記錄貨號
                List<int> need_item_no = new List<int>();
                for (int i = 0; item_dt.Rows.Count > i; i++)
                {
                    if (item_dt.Rows[i]["box_no"].ToString() == "")
                    {
                        item_dt.Rows[i]["box_no"] = box_dt.Rows.Count + 1;
                        need_item_no.Add(i + 1);
                    }
                }

                // 增加一個箱子
                if (need_item_no.Count != 0)
                {
                    DataRow dr = box_dt.NewRow();
                    dr["boxs_item_no"] = string.Join(",", need_item_no);
                    box_dt.Rows.Add(dr);
                }
                // 重新繫結 GridView 和 設定 ViewState
                SetGVData(item_dt, box_dt);
            }
            catch (Exception ex)
            {
                //Helper.Alert(ex.Message, Page);
                //Helper.WriteLog(ex, ErrorLogFileName);
            }
        }

        /// <summary>
        /// 選中的放入選中的箱子
        /// </summary>
        protected void sele_to_sele(object sender, EventArgs e)
        {
            try
            {
                DataTable box_dt = (DataTable)ViewState["box_dt"];
                DataTable item_dt = (DataTable)ViewState["item_dt"];
                // 同步
                SynDts(ref item_dt, ref box_dt);

                // 迴圈找出目前有勾選的貨號
                List<int> item_check_no = new List<int>();
                for (int i = 0; i < item_dt.Rows.Count; i++)
                {
                    if (item_dt.Rows[i]["item_selected"].ToString() == "1")
                    {
                        item_check_no.Add(i + 1);
                        item_dt.Rows[i]["item_selected"] = "0";
                    }
                }

                // 迴圈找出目前有勾選的箱號
                int box_check_no = -1;
                for (int i = 0; i < box_dt.Rows.Count; i++)
                {
                    if (box_dt.Rows[i]["box_selected"].ToString() == "1")
                    {
                        box_check_no = i + 1;
                        box_dt.Rows[i]["box_selected"] = "0";
                    }
                }

                if (item_check_no.Count == 0 || box_check_no == -1)
                {
                    // Do.Alert("沒有選箱子或貨物",Page);
                    return;
                }

                // ---------- 給值 ------------------

                // 把箱號給貨物
                foreach (int i in item_check_no)
                    item_dt.Rows[i - 1]["box_no"] = box_check_no;

                // 把貨號給箱子
                if (box_dt.Rows[box_check_no - 1]["boxs_item_no"].ToString() == "") // 原本沒有貨號的單純加入
                    box_dt.Rows[box_check_no - 1]["boxs_item_no"] = string.Join(",", item_check_no);
                else
                {   // 原本有貨號的要先排序
                    List<int> boxs_item_no = box_dt.Rows[box_check_no - 1]["boxs_item_no"].ToString().Split(',').Select(int.Parse).ToList();
                    boxs_item_no = boxs_item_no.Except(item_check_no).ToList(); // 先排除如果選中，但是原本就在這個箱子裡的
                    boxs_item_no = boxs_item_no.Concat(item_check_no).ToList(); // 再和這次選中的合併
                    boxs_item_no.Sort();
                    box_dt.Rows[box_check_no - 1]["boxs_item_no"] = string.Join(",", boxs_item_no);
                }

                // 如果這些貨號在其他箱子出現過要刪除
                for (int i = 0; i < box_dt.Rows.Count; i++)
                {
                    if (i != box_check_no - 1) // 如非選中的那一行
                    {
                        string items_str = box_dt.Rows[i]["boxs_item_no"].ToString();
                        if (items_str != "") // 該行的貨號不是空的
                        {
                            List<int> boxs_item_no = items_str.Split(',').Select(int.Parse).ToList();
                            boxs_item_no = boxs_item_no.Except(item_check_no).ToList();
                            box_dt.Rows[i]["boxs_item_no"] = string.Join(",", boxs_item_no);
                        }
                    }
                }

                // 寫回
                SetGVData(item_dt, box_dt);
            }
            catch (Exception ex)
            {
                //Helper.Alert(ex.Message, Page);
                //Helper.WriteLog(ex, ErrorLogFileName);
            }

        }

        #region -- 轉頁用 --

        /// <summary>
        /// 資料檢查
        /// </summary>
        private string checkData(DataTable item_dt, DataTable box_dt)
        {
            // 目前只是舉個例子，沒有要測

            var errMsg = string.Empty;
            //string col1 = "", col2 = "", col3 = "", col4 = "";
            //for (int i = 0; i < dt1.Rows.Count; i++)
            //{
            //    col1 = dt1.Rows[i]["A"].ToString();
            //    col2 = dt1.Rows[i]["C"].ToString();
            //    col3 = dt1.Rows[i]["D"].ToString();
            //    col4 = dt1.Rows[i]["E"].ToString();

            //    // 不能為空
            //    if (string.IsNullOrEmpty(col1))
            //        errMsg += "xxxx";
            //    // 數字
            //    if (!(col2.All(char.IsDigit) & col3.All(char.IsDigit) & col4.All(char.IsDigit)))
            //        errMsg += "xxxx";

            //}
            //for (int i = 0; i < dt2.Rows.Count; i++)
            //{
            //    col1 = dt2.Rows[i]["BoxNo"].ToString();
            //    col2 = dt2.Rows[i]["Size"].ToString();
            //    col3 = dt2.Rows[i]["MakeOf"].ToString();
            //    col4 = dt2.Rows[i]["Weigth"].ToString();
            //}

            return errMsg;
        }

        /// <summary>
        /// 上一頁
        /// </summary>
        protected void Last_Page(object sender, EventArgs e)
        {
            // 取上次(增加/減少一行時)的DataTable
            DataTable box_dt = (DataTable)ViewState["box_dt"];
            DataTable item_dt = (DataTable)ViewState["item_dt"];
            // 更新為目前輸入的資料
            SynDts(ref item_dt, ref box_dt);
            // 帶到Context
            Context.Items["box_dt"] = box_dt;
            Context.Items["item_dt"] = item_dt;
            Context.Items["add_dt"] = (DataTable)ViewState["add_dt"];
            Context.Items["oth_dt"] = (DataTable)ViewState["oth_dt"];
            Context.Items["inv_dt"] = (DataTable)ViewState["inv_dt"];
            // 傳送到上一頁
            Server.Transfer("P1.aspx");
        }

        /// <summary>
        /// 下一頁
        /// </summary>
        protected void Next_Page(object sender, EventArgs e)
        {
            // 取上次(增加/減少一行時)的DataTable
            DataTable box_dt = (DataTable)ViewState["box_dt"];
            DataTable item_dt = (DataTable)ViewState["item_dt"];
            // 更新為目前輸入的資料
            SynDts(ref item_dt, ref box_dt);
            // 驗証 (不過的話 Alert)
            string errMsg = checkData(item_dt, box_dt);
            // 帶到Context
            Context.Items["box_dt"] = box_dt;
            Context.Items["item_dt"] = item_dt;
            Context.Items["add_dt"] = (DataTable)ViewState["add_dt"];
            Context.Items["oth_dt"] = (DataTable)ViewState["oth_dt"];
            Context.Items["inv_dt"] = (DataTable)ViewState["inv_dt"];
            // 傳送到下一頁
            Server.Transfer("P3.aspx");
        } 

        #endregion

    }
}