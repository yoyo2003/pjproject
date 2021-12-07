using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
//using static PjSipWrapper.PjsInterop;

namespace PjSipWrapper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct pj_str_t
    {
        public IntPtr ptr;
        public int slen;
        public pj_str_t(string s)
        {
            ptr = string.IsNullOrEmpty(s) ? IntPtr.Zero : Marshal.StringToHGlobalAnsi(s);
            slen = string.IsNullOrEmpty(s) ? 0 : s.Length;
        }
        public static implicit operator string(pj_str_t @v)
        {
            return @v.slen == 0 ? string.Empty : Marshal.PtrToStringAnsi(@v.ptr, @v.slen);
        }
    }


    [StructLayout(LayoutKind.Sequential)]
    public class pjsua_cnf
    {
        public uint maxCalls;
        public uint threadCnt;
        public int natTypeInSdp;
        [MarshalAs(UnmanagedType.U1)]
        public bool stunTryIpv6;
        [MarshalAs(UnmanagedType.U1)]
        public bool stunIgnoreFailure;
        [MarshalAs(UnmanagedType.U1)]
        public bool mwiUnsolicitedEnabled;
        [MarshalAs(UnmanagedType.U1)]
        public bool mainThreadOnly;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public pj_str_t[] nameserver;
        public uint nameserver_cnt;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public pj_str_t[] outbound_proxy;
        public uint outbound_proxy_cnt;
        public pj_str_t userAgent;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public pj_str_t[] stunServer;
        public uint stunServer_cnt;

        public pjmedia_srtp_use use_srtp;
        public int srtp_secure_signaling;
        //[MarshalAs(UnmanagedType.I1)]
        public bool hangup_forked_call;
        public pjsua_callback cb;

    }
    ///// Return Type: void
    /////level: int
    /////data: char*
    /////len: int
    /////
    ///**
    //* Optional callback function to be called to write log to
    //* application specific device.This function will be called for
    //* log messages on input verbosity level.
    //*/
    ////void       (* cb)(int level, const char* data, int len);
    //[UnmanagedFunctionPointer(CallingConvention.StdCall)]
    //public delegate void pjsua_logging_config_cb(int level, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPStr)] string data, int len);

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 2)]
    public class pjsua_logging_cnf
    {

        /// pj_bool_t->int
        public int msg_logging;

        /// unsigned int
        public uint level;

        /// unsigned int
        public uint console_level;

        /// unsigned int
        public uint decor;

        /// pj_str_t
        public pj_str_t log_filename;

        /// unsigned int
        public uint log_file_flags;

        /// pjsua_logging_config_cb
        [MarshalAs(UnmanagedType.FunctionPtr)]
        
        public Interop.PjSipLogCallback cb;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct pj_ice_sess_options
    {

        /// pj_bool_t->int
        public int aggressive;

        /// unsigned int
        public uint nominated_check_delay;

        /// int
        public int controlled_agent_want_nom_timeout;
    }
    public struct pj_stun_auth_static_cred {
        /** 
	     * If not-empty, it indicates that this is a long term credential.
	     */
        pj_str_t realm;

        /** 
	     * The username of the credential.
	     */
        pj_str_t username;

        /**
	     * Data type to indicate the type of password in the \a data field.
	     */
        pj_stun_passwd_type data_type;

        /** 
	     * The data, which depends depends on the value of \a data_type
	     * field. When \a data_type is zero, this field will contain the
	     * plaintext password.
	     */
        pj_str_t data;

        /** 
	     * Optional NONCE.
	     */
        pj_str_t nonce;
    }
    struct pj_stun_auth_dyn_cred { }

    public struct pj_stun_auth_cred_data
    {
        public pj_stun_auth_static_cred static_cred;
        //public pj_stun_auth_dyn_cred dyn_cred;
    }

    public struct pj_stun_auth_cred
    {
        
        /**
         * The type of authentication information in this structure.
         */
        pj_stun_auth_cred_type type;

        pj_stun_auth_cred_data data;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public class pjsua_media_cnf
    {

        /// unsigned int
        public uint clock_rate;

        /// unsigned int
        public uint snd_clock_rate;

        /// unsigned int
        public uint channel_count;

        /// unsigned int
        public uint audio_frame_ptime;

        /// unsigned int
        public uint max_media_ports;

        /// pj_bool_t->int
        public int has_ioqueue;

        /// unsigned int
        public uint thread_cnt;

        /// unsigned int
        public uint quality;

        /// unsigned int
        public uint ptime;

        /// pj_bool_t->int
        public int no_vad;

        /// unsigned int
        public uint ilbc_mode;

        /// unsigned int
        public uint tx_drop_pct;

        /// unsigned int
        public uint rx_drop_pct;

        /// unsigned int
        public uint ec_options;

        /// unsigned int
        public uint ec_tail_len;

        /// unsigned int
        public uint snd_rec_latency;

        /// unsigned int
        public uint snd_play_latency;

        /// int
        public int jb_init;

        /// int
        public int jb_min_pre;

        /// int
        public int jb_max_pre;

        /// int
        public int jb_max;

        /// pj_bool_t->int
        public int enable_ice;

        /// int
        public int ice_max_host_cands;

        /// pj_ice_sess_options
        public pj_ice_sess_options ice_opt;

        /// pj_bool_t->int
        public int ice_no_rtcp;

        /// pj_bool_t->int
        public int enable_turn;

        /// pj_str_t
        public pj_str_t turn_server;

        /// pj_turn_tp_type
        public pj_turn_tp_type turn_conn_type;

        /// pj_stun_auth_cred
        public pj_stun_auth_cred turn_auth_cred;

        /// int
        public int snd_auto_close_time;
    }


    [StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct pjsip_hdr
    {

        /// pjsip_hdr*
        public System.IntPtr prev;

        /// pjsip_hdr*
        public System.IntPtr next;

        /// pjsip_hdr_e
        public pjsip_hdr_e type;

        /// pj_str_t
        public pj_str_t name;

        /// pj_str_t
        public pj_str_t sname;

        /// pjsip_hdr_vptr*
        public IntPtr vptr;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct pjsip_media_type
    {

        /// pj_str_t
        public pj_str_t type;

        /// pj_str_t
        public pj_str_t subtype;

        /// pj_str_t
        public pj_str_t param;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct pjmedia_format
    {

        /// pjmedia_format_id
        public pjmedia_format_id id;

        /// pj_uint32_t->unsigned int
        public uint bitrate;

        /// pj_bool_t->int
        public int vad;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct pjmedia_port_info
    {

        /// pj_str_t
        public pj_str_t name;

        /// pj_uint32_t->unsigned int
        public uint signature;

        /// pjmedia_type
        public pjmedia_type type;

        /// pj_bool_t->int
        public int has_info;

        /// pj_bool_t->int
        public int need_info;

        /// unsigned int
        public uint pt;

        /// pjmedia_format
        public pjmedia_format format;

        /// pj_str_t
        public pj_str_t encoding_name;

        /// unsigned int
        public uint clock_rate;

        /// unsigned int
        public uint channel_count;

        /// unsigned int
        public uint bits_per_sample;

        /// unsigned int
        public uint samples_per_frame;

        /// unsigned int
        public uint bytes_per_frame;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct pjmedia_port_port_data
    {

        /// void*
        public System.IntPtr pdata;

        /// int
        public int ldata;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct pjmedia_port
    {

        /// pjmedia_port_info
        public pjmedia_port_info info;

        /// pjmedia_port_port_data
        public pjmedia_port_port_data Struct1;

        /// pjmedia_port_put_frame
        public pjmedia_port_put_frame AnonymousMember2;

        /// pjmedia_port_get_frame
        public pjmedia_port_get_frame AnonymousMember3;

        /// pjmedia_port_on_destroy
        public pjmedia_port_on_destroy AnonymousMember4;
    }



    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct pjsua_callback
    {
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_call_state on_call_state;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_incoming_call on_incoming_call;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_call_tsx_state on_call_tsx_state;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_call_media_state on_call_media_state;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_stream_created on_stream_created;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_stream_destroyed on_stream_destroyed;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_dtmf_digit on_dtmf_digit;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_call_transfer_request on_call_transfer_request;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_call_transfer_status on_call_transfer_status;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_call_replace_request on_call_replace_request;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_call_replaced on_call_replaced;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_reg_state on_reg_state;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_incoming_subscribe on_incoming_subscribe;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_srv_subscribe_state on_srv_subscribe_state;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_buddy_state on_buddy_state;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_pager on_pager;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_pager2 on_pager2;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_pager_status on_pager_status;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_pager_status2 on_pager_status2;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_typing on_typing;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_typing2 on_typing2;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_nat_detect on_nat_detect;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public pjsua_callback_on_call_redirected on_call_redirected;
        //public pjsua_callback_on_mwi_info on_mwi_info;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct pjsip_uri
    {
        /// pjsip_uri_vptr*
        public System.IntPtr vptr;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct pj_stun_nat_detect_result
    {

        /// pj_status_t->int
        public int status;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string status_text;

        /// pj_stun_nat_type
        public pj_stun_nat_type nat_type;

        /// char*
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        public string nat_type_name;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct pjmedia_frame
    {

        /// pjmedia_frame_type
        public pjmedia_frame_type type;

        /// void*
        public System.IntPtr buf;

        /// pj_size_t->size_t->unsigned int
        public uint size;

        /// pj_timestamp
        public pj_timestamp timestamp;

        /// pj_uint32_t->unsigned int
        public uint bit_info;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Anonymous_8f76ed83_b773_414d_aab1_99764d2712ae
    {

        /// pj_uint32_t->unsigned int
        public uint lo;

        /// pj_uint32_t->unsigned int
        public uint hi;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct pj_timestamp
    {

        /// Anonymous_8f76ed83_b773_414d_aab1_99764d2712ae
        [FieldOffset(0)]
        public Anonymous_8f76ed83_b773_414d_aab1_99764d2712ae u32;

        /// pj_uint64_t->unsigned __int64
        [FieldOffset(0)]
        public ulong u64;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct pj_pool_t
    {

        /// pj_pool_mem*
        public System.IntPtr first_mem;

        /// pj_pool_factory*
        public System.IntPtr factory;

        /// char[32]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string obj_name;

        /// pj_size_t->size_t->unsigned int
        public uint used_size;

        /// pj_pool_callback*
        public IntPtr cb;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct pjsip_msg_body
    {

        /// pjsip_media_type
        public pjsip_media_type content_type;

        /// void*
        public IntPtr data;

        /// unsigned int
        public uint len;

        /// pjsip_msg_body_print_body
        public pjsip_msg_body_print_body OnPrintMsgBody;

        /// pjsip_msg_body_clone_data
        public pjsip_msg_body_clone_data OnCloneMsgBody;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class pjsua_media_config
    {

        /// unsigned int
        public uint clock_rate;

        /// unsigned int
        public uint snd_clock_rate;

        /// unsigned int
        public uint channel_count;

        /// unsigned int
        public uint audio_frame_ptime;

        /// unsigned int
        public uint max_media_ports;

        /// pj_bool_t->int
        public int has_ioqueue;

        /// unsigned int
        public uint thread_cnt;

        /// unsigned int
        public uint quality;

        /// unsigned int
        public uint ptime;

        /// pj_bool_t->int
        public int no_vad;

        /// unsigned int
        public uint ilbc_mode;

        /// unsigned int
        public uint tx_drop_pct;

        /// unsigned int
        public uint rx_drop_pct;

        /// unsigned int
        public uint ec_options;

        /// unsigned int
        public uint ec_tail_len;

        /// unsigned int
        public uint snd_rec_latency;

        /// unsigned int
        public uint snd_play_latency;

        /// int
        public int jb_init;

        /// int
        public int jb_min_pre;

        /// int
        public int jb_max_pre;

        /// int
        public int jb_max;

        /// pj_bool_t->int
        public int enable_ice;

        /// int
        public int ice_max_host_cands;

        /// pj_ice_sess_options
        public pj_ice_sess_options ice_opt;

        /// pj_bool_t->int
        public int ice_no_rtcp;

        /// pj_bool_t->int
        public int enable_turn;

        /// pj_str_t
        public pj_str_t turn_server;

        /// pj_turn_tp_type
        public pj_turn_tp_type turn_conn_type;

        /// pj_stun_auth_cred
        public pj_stun_auth_cred turn_auth_cred;

        /// int
        public int snd_auto_close_time;
    }
}
