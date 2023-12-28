
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

public class PreApplicationStart
{
    public static void Start()
    {
        DynamicModuleUtility.RegisterModule(typeof(CopyrightModule));
    }
}