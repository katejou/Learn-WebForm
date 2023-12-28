using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex1.ConfigAlter
{
    public partial class Show_ConfigValue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //https://docs.microsoft.com/zh-tw/dotnet/api/system.web.configuration.webconfigurationmanager.connectionstrings?view=netframework-4.8

            // Get the connectionStrings key,value pairs collection.
            ConnectionStringSettingsCollection connectionStrings =
                WebConfigurationManager.ConnectionStrings
                as ConnectionStringSettingsCollection;

            // Get the collection enumerator.
            IEnumerator connectionStringsEnum =
                connectionStrings.GetEnumerator();

            // Loop through the collection and 
            // display the connectionStrings key, value pairs.
            int i = 0;
            StringBuilder show = new StringBuilder();
            while (connectionStringsEnum.MoveNext())
            {
                string name = connectionStrings[i].Name;
                show.AppendFormat("Name: {0} <br/>-- Value: {1} <br/>",
                name, connectionStrings[name]);
                i += 1;
            }
            Label2.Text = show.ToString();

            //------------------------------------------------------------------------------

            // Get the appSettings key,value pairs collection.
            NameValueCollection appSettings =
                WebConfigurationManager.AppSettings
                as NameValueCollection;

            // Get the collection enumerator.
            IEnumerator appSettingsEnum =
                appSettings.GetEnumerator();

            // Loop through the collection and 
            // display the appSettings key, value pairs.
            i = 0;
            show.Clear();
            while (appSettingsEnum.MoveNext())
            {
                string key = appSettings.AllKeys[i].ToString();
                show.AppendFormat("Key: {0} <br/>-- Value: {1} <br/>",
                key, appSettings[key]);
                i += 1;
            }

            Label4.Text = show.ToString();
        }
    }
}