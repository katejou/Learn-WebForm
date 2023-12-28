using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test
{

    public interface ICustomControl2
    {
        string txt_ASSIGNED_ID { set; get; }
        string txt_QUANTITY_ORDERED { set; get; }
        string txt_UNIT_OF_MEASURE_CODE { set; get; }
        string txt_UNIT_PRICE { set; get; }
        string val_PRODUCT_ID_QUAL1 { set; get; }
        string txt_PRODUCT_ID1 { set; get; }
        string val_PRODUCT_ID_QUAL2 { set; get; }
        string txt_PRODUCT_ID2 { set; get; }
        string txt_PRODUCT_DESCRIPTION { set; get; }
        string val_QUOTE_QUAL { set; get; }
        string txt_QUOTE_NUMBER { set; get; }
        string txt_QUANTITY { set; get; }
        string txt_ARRIVALDATE { set; get; }
        string txt_ITEM_DESCRIPTION { set; get; }
        string txt_ITEM_MSG { set; get; }
    }

    public partial class uc2 : System.Web.UI.UserControl, ICustomControl2
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string txt_ASSIGNED_ID
        {
            set { tb_ASSIGNED_ID.Text = value; }
            get { return tb_ASSIGNED_ID.Text; }
        }
        public string txt_QUANTITY_ORDERED
        {
            set { tb_QUANTITY_ORDERED.Text = value; }
            get { return tb_QUANTITY_ORDERED.Text; }
        }
        public string txt_UNIT_OF_MEASURE_CODE
        {
            set { tb_UNIT_OF_MEASURE_CODE.Text = value; }
            get { return tb_UNIT_OF_MEASURE_CODE.Text; }
        }
        public string txt_UNIT_PRICE
        {
            set { tb_UNIT_PRICE.Text = value; }
            get { return tb_UNIT_PRICE.Text; }
        }
        public string val_PRODUCT_ID_QUAL1
        {
            set { ddl_PRODUCT_ID_QUAL1.SelectedValue = value; }
            get { return ddl_PRODUCT_ID_QUAL1.SelectedValue; }
        }
        public string txt_PRODUCT_ID1
        {
            set { tb_PRODUCT_ID1.Text = value; }
            get { return tb_PRODUCT_ID1.Text; }
        }
        public string val_PRODUCT_ID_QUAL2
        {
            set { ddl_PRODUCT_ID_QUAL2.SelectedValue = value; }
            get { return ddl_PRODUCT_ID_QUAL2.SelectedValue; }
        }
        public string txt_PRODUCT_ID2
        {
            set { tb_PRODUCT_ID2.Text = value; }
            get { return tb_PRODUCT_ID2.Text; }
        }
        public string txt_PRODUCT_DESCRIPTION
        {
            set { tb_PRODUCT_DESCRIPTION.Text = value; }
            get { return tb_PRODUCT_DESCRIPTION.Text; }
        }
        public string val_QUOTE_QUAL
        {
            set { ddl_QUOTE_QUAL.SelectedValue = value; }
            get { return ddl_QUOTE_QUAL.SelectedValue; }
        }
        public string txt_QUOTE_NUMBER
        {
            set { tb_QUOTE_NUMBER.Text = value; }
            get { return tb_QUOTE_NUMBER.Text; }
        }
        public string txt_QUANTITY
        {
            set { tb_QUANTITY.Text = value; }
            get { return tb_QUANTITY.Text; }
        }
        public string txt_ARRIVALDATE
        {
            set { tb_ARRIVALDATE.Text = value; }
            get { return tb_ARRIVALDATE.Text; }
        }
        public string txt_ITEM_DESCRIPTION
        {
            set { tb_ITEM_DESCRIPTION.Text = value; }
            get { return tb_ITEM_DESCRIPTION.Text; }
        }
        public string txt_ITEM_MSG
        {
            set { tb_ITEM_MSG.Text = value; }
            get { return tb_ITEM_MSG.Text; }
        }

    }
}