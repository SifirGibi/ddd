using System;
using System.Web;

namespace SifirGibiMakina
{
    public class GetCurrentPage { public override string ToString() { if (null != HttpContext.Current) { return HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath; } return "Sayfa Algılanamadı"; } }
    public class GetCurrentHost { public override string ToString() { if (null != Environment.MachineName) { return Environment.MachineName; } return "Host Algılanamadı"; } }
    public class GetCurrentIPAddress { public override string ToString() { if (null != HttpContext.Current) { return HttpContext.Current.Request.UserHostAddress; } return "IP Algılanamadı"; } }
    public class GetCurrentBrowser { public override string ToString() { if (null != HttpContext.Current) { return HttpContext.Current.Request.Browser.Browser; } return "Browser Algılanamadı"; } }
    public class GetCurrentPlatform { public override string ToString() { if (null != HttpContext.Current) { return HttpContext.Current.Request.Browser.Platform; } return "Platform Algılanamadı"; } }
    public class GetCurrentDevice { public override string ToString() { if (null != HttpContext.Current) { return HttpContext.Current.Request.Browser.MobileDeviceModel; } return "Cihaz Algılanamadı"; } }
}