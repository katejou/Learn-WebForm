using log4net;
public class MessageLog
{
    public ILog log = LogManager.GetLogger("File");
    public MessageLog()
    {
        log4net.Config.XmlConfigurator.Configure();
    }
    public void Errorlog(string strMessage)
    {
        log.Error(strMessage);
    }
    public void Errorlog(string strMessage, string StrTrace)
    {
        try
        {
            log.Error(strMessage + "\r\n" + StrTrace);
        }
        catch { }
    }
    public void DebugLog(string strMessage)
    {
        log.Debug(strMessage);
    }
    public void DebugLog(string strMessage, string StrTrace)
    {
        log.Debug(strMessage + "\r\n" + StrTrace);
    }
    public void InfoLog(string strMessage)
    {
        log.Info(strMessage);
    }
    public void InfoLog(string strMessage, string StrTrace)
    {
        log.Info(strMessage + "\r\n" + StrTrace);
    }
    public void WarnLog(string strMessage)
    {
        log.Warn(strMessage);
    }
    public void WarnLog(string strMessage, string StrTrace)
    {
        log.Warn(strMessage + "\r\n" + StrTrace);
    }
    public void FatalLog(string strMessage)
    {
        log.Fatal(strMessage);
    }
    public void FatalLog(string strMessage, string StrTrace)
    {
        log.Fatal(strMessage + "\r\n" + StrTrace);
    }
}