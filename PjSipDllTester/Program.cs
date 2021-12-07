using PjSipWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PjSipDllTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Interop.PjSipLogCallback logMessageDelegate = OnPjSipLogCallback;
            Interop.SetPjSipLogging(logMessageDelegate, 3);
            Interop.SendTestLog(2);
            pjsua_cnf setting = new pjsua_cnf();
            setting.nameserver_cnt = 4;
            setting.nameserver = new pj_str_t[4];
            for (int index = 0; index < setting.nameserver_cnt; index++)
            {
                var str = "service-00" + index;
                setting.nameserver[index] = new pj_str_t(str);
            }

            setting.outbound_proxy_cnt = 3;
            setting.outbound_proxy = new pj_str_t[4];
            for (int index = 0; index < setting.outbound_proxy_cnt; index++)
            {
                var str = "outbound_proxy-00" + index;
                setting.outbound_proxy[index] = new pj_str_t(str);
            }

            setting.stunServer_cnt = 5;
            setting.stunServer = new pj_str_t[8];
            for (int index = 0; index < setting.stunServer_cnt; index++)
            {
                var str = "stunServer_cnt-00" + index;
                setting.stunServer[index] = new pj_str_t(str);
            }
            setting.userAgent = new pj_str_t("testAgent");
            Interop.LogPjStr(setting.userAgent);

            setting.maxCalls = 100;
            setting.threadCnt = 5;
            setting.mainThreadOnly = true;
            setting.stunTryIpv6 = true;
            setting.stunIgnoreFailure = true;
            setting.natTypeInSdp = 3;
            setting.mwiUnsolicitedEnabled = true;
            //setting.test = 25;

            Interop.SetPjsuaSettings(setting);

            InitPjsua(setting);

            var media_cnf = new pjsua_media_cnf();
            Interop.Media.get_pjsua_media_config_default(media_cnf);
        }

        static void OnPjSipLogCallback(int level, string msg, int len)
        {
            Console.WriteLine($"c# {level} - len:{len} msg:{msg}");
        }
        public static void InitPjsua(pjsua_cnf uaCfg)
        {
            pjsua_logging_cnf logCfg;
            pjsua_media_cnf mediaCfg;
            //var ua_cfg = _mapper.Map(uaCfg, _uaCfg);
            //var l_cfg = _mapper.Map(logCfg, _lCfg);

            //ua_cfg.cb.on_reg_state = OnRegState;
            //uaCfg = new pjsua_cnf();
            logCfg = new pjsua_logging_cnf();
            uaCfg.cb.on_call_state = OnCallState;
            //ua_cfg.cb.on_call_media_state = OnCallMediaState;
            //ua_cfg.cb.on_incoming_call = OnIncomingCall;
            //ua_cfg.cb.on_stream_destroyed = OnStreamDestroyed;
            //ua_cfg.cb.on_dtmf_digit = OnDtmfDigit;
            //ua_cfg.cb.on_call_transfer_request = OnCallTransfer;
            //ua_cfg.cb.on_call_transfer_status = OnCallTransferStatus;
            //ua_cfg.cb.on_call_redirected = OnCallRedirect;

            //ua_cfg.cb.on_nat_detect = OnNatDetect;

            //ua_cfg.cb.on_buddy_state = OnBuddyState;
            //ua_cfg.cb.on_incoming_subscribe = OnIncomingSubscribe;
            //ua_cfg.cb.on_pager = OnPager;
            //ua_cfg.cb.on_pager_status = OnPagerStatus;
            //ua_cfg.cb.on_typing = OnTyping;

            logCfg.cb = OnPjSipLogCallback;

            //etc;
            mediaCfg = new pjsua_media_cnf();
            Interop.Media.get_pjsua_media_config_default(mediaCfg);
            Interop.InitPjSip(uaCfg, logCfg, mediaCfg);
        }

        private static void OnCallState(int call_id, ref IntPtr e)
        {
            OnPjSipLogCallback(3, $"Call state change: {call_id}", 100);
        }
    }

}
