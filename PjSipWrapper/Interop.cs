using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PjSipWrapper
{

    public class Interop
    {
        const string PJSIP_DLL = "pjsip_dll.dll";
        #region pjsip callback delegate functions
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PjSipLogCallback(int level, string msg, int len);


        #endregion

        [DllImport(PJSIP_DLL, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPjSipLogging([MarshalAs(UnmanagedType.FunctionPtr)]PjSipLogCallback fnOnLoggingMessage, int level);

        [DllImport(PJSIP_DLL, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SendTestLog(int level);

        [DllImport(PJSIP_DLL, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern int InitPjSip([In][Out] pjsua_cnf ua_cfg, [In][Out] pjsua_logging_cnf log_cfg, [In][Out] pjsua_media_cnf media_cfg);

        [DllImport(PJSIP_DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPjsuaSettings([In][Out] pjsua_cnf settings);

        [DllImport(PJSIP_DLL, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void LogPjStr(pj_str_t str);
        public static class Media
        {

            /// Return Type: void
            ///cfg: pjsua_media_config*
            [System.Runtime.InteropServices.DllImportAttribute(PJSIP_DLL, CallingConvention = CallingConvention.Cdecl)]
            public static extern void get_pjsua_media_config_default([In][Out] pjsua_media_cnf cfg);
        }
    }
}
