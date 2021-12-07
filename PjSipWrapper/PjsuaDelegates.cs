using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PjSipWrapper
{

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_call_state(int call_id, ref IntPtr e);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_typing2(
            int call_id, ref pj_str_t from,
        ref pj_str_t to,
        ref pj_str_t contact,
        [MarshalAs(UnmanagedType.I1)] bool is_typing,
            IntPtr rdata, int acc_id);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_pager_status2(
        int call_id, ref pj_str_t to,
    ref pj_str_t body,
    IntPtr user_data, pjsip_status_code status,
    ref pj_str_t reason,
        IntPtr tdata, IntPtr rdata, int acc_id);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_pager2(
        int call_id, 
        ref pj_str_t from,
        ref pj_str_t to,
        ref pj_str_t contact,
        ref pj_str_t mime_type,
        ref pj_str_t body,
        IntPtr rdata, int acc_id);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_srv_subscribe_state(
        int acc_id, IntPtr srv_pres, ref pj_str_t remote_uri,
    pjsip_evsub_state state, IntPtr @event);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_incoming_subscribe(
        int acc_id, IntPtr srv_pres, int buddy_id,
    ref pj_str_t from,
    IntPtr rdata, ref pjsip_status_code code,
    ref pj_str_t reason, pjsua_msg_data msg_data);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_call_replace_request(
        int call_id, IntPtr rdata, ref int st_code,
    ref pj_str_t st_text);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_stream_destroyed(int call_id, IntPtr sess, uint stream_idx);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_stream_created(
        int call_id, IntPtr sess, uint stream_idx, [In][Out] ref pjmedia_port p_port);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_call_tsx_state(int call_id, IntPtr tsx, ref IntPtr e);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_incoming_call(int acc_id, int call_id, IntPtr rdata);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate pjsip_redirect_op pjsua_callback_on_call_redirected(int call_id, ref pjsip_uri target, IntPtr e);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_mwi_info(int acc_id, IntPtr mwi_info);

    /// Return Type: void
    ///call_id: pjsua_call_id->int
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_call_media_state(int call_id);

    /// Return Type: void
    ///call_id: pjsua_call_id->int
    ///digit: int
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_dtmf_digit(int call_id, int digit);

    /// Return Type: void
    ///call_id: pjsua_call_id->int
    ///dst: pj_str_t*
    ///code: pjsip_status_code*
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_call_transfer_request(int call_id, ref pj_str_t dst, ref pjsip_status_code code);

    /// Return Type: void
    ///call_id: pjsua_call_id->int
    ///st_code: int
    ///st_text: pj_str_t*
    ///final: pj_bool_t->int
    ///p_cont: pj_bool_t*
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_call_transfer_status(int call_id, int st_code, ref pj_str_t st_text, int final, ref int p_cont);

    /// Return Type: void
    ///old_call_id: pjsua_call_id->int
    ///new_call_id: pjsua_call_id->int
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_call_replaced(int old_call_id, int new_call_id);

    /// Return Type: void
    ///acc_id: pjsua_acc_id->int
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_reg_state(int acc_id);

    /// Return Type: void
    ///buddy_id: pjsua_buddy_id->int
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_buddy_state(int buddy_id);

    /// Return Type: void
    ///call_id: pjsua_call_id->int
    ///from: pj_str_t*
    ///to: pj_str_t*
    ///contact: pj_str_t*
    ///mime_type: pj_str_t*
    ///body: pj_str_t*
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_pager(int call_id, ref pj_str_t from, ref pj_str_t to, ref pj_str_t contact, ref pj_str_t mime_type, ref pj_str_t body);

    /// Return Type: void
    ///call_id: pjsua_call_id->int
    ///to: pj_str_t*
    ///body: pj_str_t*
    ///user_data: void*
    ///status: pjsip_status_code
    ///reason: pj_str_t*
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_pager_status(int call_id, ref pj_str_t to, ref pj_str_t body, System.IntPtr user_data, pjsip_status_code status, ref pj_str_t reason);

    /// Return Type: void
    ///call_id: pjsua_call_id->int
    ///from: pj_str_t*
    ///to: pj_str_t*
    ///contact: pj_str_t*
    ///is_typing: pj_bool_t->int
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_typing(int call_id, ref pj_str_t from, ref pj_str_t to, ref pj_str_t contact, int is_typing);

    /// Return Type: void
    ///res: pj_stun_nat_detect_result*
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void pjsua_callback_on_nat_detect(ref pj_stun_nat_detect_result res);



    /// Return Type: pj_status_t->int
    ///this_port: pjmedia_port*
    ///frame: pjmedia_frame*
    public delegate int pjmedia_port_put_frame(ref pjmedia_port this_port, ref pjmedia_frame frame);

    /// Return Type: pj_status_t->int
    ///this_port: pjmedia_port*
    ///frame: pjmedia_frame*
    public delegate int pjmedia_port_get_frame(ref pjmedia_port this_port, ref pjmedia_frame frame);

    /// Return Type: pj_status_t->int
    ///this_port: pjmedia_port*
    public delegate int pjmedia_port_on_destroy(ref pjmedia_port this_port);



    /// Return Type: int
    ///msg_body: pjsip_msg_body*
    ///buf: char*
    ///size: pj_size_t->size_t->unsigned int
    public delegate int pjsip_msg_body_print_body(ref pjsip_msg_body msg_body, System.IntPtr buf, System.IntPtr size);

    /// Return Type: void*
    ///pool: pj_pool_t*
    ///data: void*
    ///len: unsigned int
    public delegate IntPtr pjsip_msg_body_clone_data(ref pj_pool_t pool, System.IntPtr data, uint len);

}
