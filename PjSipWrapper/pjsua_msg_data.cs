using System;
using System.Runtime.InteropServices;
//using static PjSipWrapper.PjsInterop;

namespace PjSipWrapper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct pjsua_msg_data
    {
        /**
         * Optional remote target URI (i.e. Target header). If NULL, the target
         * will be set to the remote URI (To header). This field is used by
         * pjsua_call_make_call(), pjsua_im_send(), pjsua_call_reinvite(),
         * pjsua_call_set_hold(), and pjsua_call_update().
         */
        pj_str_t target_uri;

        /**
         * Additional message headers as linked list. Application can add
         * headers to the list by creating the header, either from the heap/pool
         * or from temporary local variable, and add the header using
         * linked list operation. See pjsua_app.c for some sample codes.
         */
        pjsip_hdr hdr_list;

        /**
         * MIME type of optional message body. 
         */
        pj_str_t content_type;

        /**
         * Optional message body to be added to the message, only when the
         * message doesn't have a body.
         */
        pj_str_t msg_body;

        /**
         * Content type of the multipart body. If application wants to send
         * multipart message bodies, it puts the parts in \a parts and set
         * the content type in \a multipart_ctype. If the message already
         * contains a body, the body will be added to the multipart bodies.
         */
        pjsip_media_type multipart_ctype;

        /**
         * List of multipart parts. If application wants to send multipart
         * message bodies, it puts the parts in \a parts and set the content
         * type in \a multipart_ctype. If the message already contains a body,
         * the body will be added to the multipart bodies.
         */
        pjsip_multipart_part multipart_parts;
    };



    /**
     * This structure describes the individual body part inside a multipart
     * message body. It mainly contains the message body itself and optional
     * headers.
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct pjsip_multipart_part
    {
        public IntPtr PJ_DECL_LIST_MEMBER;
        public pjsip_hdr hdr;
        public IntPtr body;
    };

}
