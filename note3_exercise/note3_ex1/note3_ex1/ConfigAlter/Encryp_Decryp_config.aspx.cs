using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex1.ConfigAlter
{
    public partial class Encryp_Decryp_config : System.Web.UI.Page
    {
        //string provider = "RSAProtectedConfigurationProvider"; // 這個會在 Save 的時候，出物件已存在的Error
        string provider = "DataProtectionConfigurationProvider";
        string section = "connectionStrings";
        protected void Page_Load(object sender, EventArgs e)
        {
            // https://ylw1125.pixnet.net/blog/post/41610959
        }

        protected void Encrypt_Click(object sender, EventArgs e)
        {
            Configuration confg = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
            ConfigurationSection configSect = confg.GetSection(section);
            if (configSect != null)
            {
                configSect.SectionInformation.ProtectSection(provider);
                confg.Save();
            }
        }

        protected void Decrypt_Click(object sender, EventArgs e)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
            ConfigurationSection configSect = config.GetSection(section);
            if (configSect.SectionInformation.IsProtected)
            {
                configSect.SectionInformation.UnprotectSection();
                config.Save();
            }
        }
    }
}