
namespace LODS.SharePoint.ContentManagement {
    public static class Tracing {
        public static void WriteTraceMessage(string traceMessage, params object[] param) {
            //Context.Trace.Write("LodLauncher", string.Format(traceMessage, param));
            Microsoft.Office.Server.Diagnostics.PortalLog.LogString(traceMessage, param);
        }
    }
}
