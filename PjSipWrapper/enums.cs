using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PjSipWrapper
{
    public enum pj_turn_tp_type
    {

        /// PJ_TURN_TP_UDP -> 17
        PJ_TURN_TP_UDP = 17,

        /// PJ_TURN_TP_TCP -> 6
        PJ_TURN_TP_TCP = 6,

        /// PJ_TURN_TP_TLS -> 255
        PJ_TURN_TP_TLS = 255,
    }
    public enum pj_stun_auth_cred_type
    {
        /**
         * The credential data contains a static credential to be matched 
         * against the credential in the message. A static credential can be 
         * used as both client side or server side authentication.
         */
        PJ_STUN_AUTH_CRED_STATIC,

        /**
         * The credential data contains callbacks to be called to verify the 
         * credential in the message. A dynamic credential is suitable when 
         * performing server side authentication where server does not know
         * in advance the identity of the user requesting authentication.
         */
        PJ_STUN_AUTH_CRED_DYNAMIC

    }

    public enum pj_stun_passwd_type
    {
        /**
         * Plain text password.
         */
        PJ_STUN_PASSWD_PLAIN = 0,

        /**
         * Hashed password, valid for long term credential only. The hash value
         * of the password is calculated as MD5(USERNAME ":" REALM ":" PASSWD)
         * with all quotes removed from the username and realm values.
         */
        PJ_STUN_PASSWD_HASHED = 1

    }
    public enum pjsip_status_code
    {

        /// PJSIP_SC_TRYING -> 100
        PJSIP_SC_TRYING = 100,

        /// PJSIP_SC_RINGING -> 180
        PJSIP_SC_RINGING = 180,

        /// PJSIP_SC_CALL_BEING_FORWARDED -> 181
        PJSIP_SC_CALL_BEING_FORWARDED = 181,

        /// PJSIP_SC_QUEUED -> 182
        PJSIP_SC_QUEUED = 182,

        /// PJSIP_SC_PROGRESS -> 183
        PJSIP_SC_PROGRESS = 183,

        /// PJSIP_SC_OK -> 200
        PJSIP_SC_OK = 200,

        /// PJSIP_SC_ACCEPTED -> 202
        PJSIP_SC_ACCEPTED = 202,

        /// PJSIP_SC_MULTIPLE_CHOICES -> 300
        PJSIP_SC_MULTIPLE_CHOICES = 300,

        /// PJSIP_SC_MOVED_PERMANENTLY -> 301
        PJSIP_SC_MOVED_PERMANENTLY = 301,

        /// PJSIP_SC_MOVED_TEMPORARILY -> 302
        PJSIP_SC_MOVED_TEMPORARILY = 302,

        /// PJSIP_SC_USE_PROXY -> 305
        PJSIP_SC_USE_PROXY = 305,

        /// PJSIP_SC_ALTERNATIVE_SERVICE -> 380
        PJSIP_SC_ALTERNATIVE_SERVICE = 380,

        /// PJSIP_SC_BAD_REQUEST -> 400
        PJSIP_SC_BAD_REQUEST = 400,

        /// PJSIP_SC_UNAUTHORIZED -> 401
        PJSIP_SC_UNAUTHORIZED = 401,

        /// PJSIP_SC_PAYMENT_REQUIRED -> 402
        PJSIP_SC_PAYMENT_REQUIRED = 402,

        /// PJSIP_SC_FORBIDDEN -> 403
        PJSIP_SC_FORBIDDEN = 403,

        /// PJSIP_SC_NOT_FOUND -> 404
        PJSIP_SC_NOT_FOUND = 404,

        /// PJSIP_SC_METHOD_NOT_ALLOWED -> 405
        PJSIP_SC_METHOD_NOT_ALLOWED = 405,

        /// PJSIP_SC_NOT_ACCEPTABLE -> 406
        PJSIP_SC_NOT_ACCEPTABLE = 406,

        /// PJSIP_SC_PROXY_AUTHENTICATION_REQUIRED -> 407
        PJSIP_SC_PROXY_AUTHENTICATION_REQUIRED = 407,

        /// PJSIP_SC_REQUEST_TIMEOUT -> 408
        PJSIP_SC_REQUEST_TIMEOUT = 408,

        /// PJSIP_SC_GONE -> 410
        PJSIP_SC_GONE = 410,

        /// PJSIP_SC_REQUEST_ENTITY_TOO_LARGE -> 413
        PJSIP_SC_REQUEST_ENTITY_TOO_LARGE = 413,

        /// PJSIP_SC_REQUEST_URI_TOO_LONG -> 414
        PJSIP_SC_REQUEST_URI_TOO_LONG = 414,

        /// PJSIP_SC_UNSUPPORTED_MEDIA_TYPE -> 415
        PJSIP_SC_UNSUPPORTED_MEDIA_TYPE = 415,

        /// PJSIP_SC_UNSUPPORTED_URI_SCHEME -> 416
        PJSIP_SC_UNSUPPORTED_URI_SCHEME = 416,

        /// PJSIP_SC_BAD_EXTENSION -> 420
        PJSIP_SC_BAD_EXTENSION = 420,

        /// PJSIP_SC_EXTENSION_REQUIRED -> 421
        PJSIP_SC_EXTENSION_REQUIRED = 421,

        /// PJSIP_SC_SESSION_TIMER_TOO_SMALL -> 422
        PJSIP_SC_SESSION_TIMER_TOO_SMALL = 422,

        /// PJSIP_SC_INTERVAL_TOO_BRIEF -> 423
        PJSIP_SC_INTERVAL_TOO_BRIEF = 423,

        /// PJSIP_SC_TEMPORARILY_UNAVAILABLE -> 480
        PJSIP_SC_TEMPORARILY_UNAVAILABLE = 480,

        /// PJSIP_SC_CALL_TSX_DOES_NOT_EXIST -> 481
        PJSIP_SC_CALL_TSX_DOES_NOT_EXIST = 481,

        /// PJSIP_SC_LOOP_DETECTED -> 482
        PJSIP_SC_LOOP_DETECTED = 482,

        /// PJSIP_SC_TOO_MANY_HOPS -> 483
        PJSIP_SC_TOO_MANY_HOPS = 483,

        /// PJSIP_SC_ADDRESS_INCOMPLETE -> 484
        PJSIP_SC_ADDRESS_INCOMPLETE = 484,

        /// PJSIP_AC_AMBIGUOUS -> 485
        PJSIP_AC_AMBIGUOUS = 485,

        /// PJSIP_SC_BUSY_HERE -> 486
        PJSIP_SC_BUSY_HERE = 486,

        /// PJSIP_SC_REQUEST_TERMINATED -> 487
        PJSIP_SC_REQUEST_TERMINATED = 487,

        /// PJSIP_SC_NOT_ACCEPTABLE_HERE -> 488
        PJSIP_SC_NOT_ACCEPTABLE_HERE = 488,

        /// PJSIP_SC_BAD_EVENT -> 489
        PJSIP_SC_BAD_EVENT = 489,

        /// PJSIP_SC_REQUEST_UPDATED -> 490
        PJSIP_SC_REQUEST_UPDATED = 490,

        /// PJSIP_SC_REQUEST_PENDING -> 491
        PJSIP_SC_REQUEST_PENDING = 491,

        /// PJSIP_SC_UNDECIPHERABLE -> 493
        PJSIP_SC_UNDECIPHERABLE = 493,

        /// PJSIP_SC_INTERNAL_SERVER_ERROR -> 500
        PJSIP_SC_INTERNAL_SERVER_ERROR = 500,

        /// PJSIP_SC_NOT_IMPLEMENTED -> 501
        PJSIP_SC_NOT_IMPLEMENTED = 501,

        /// PJSIP_SC_BAD_GATEWAY -> 502
        PJSIP_SC_BAD_GATEWAY = 502,

        /// PJSIP_SC_SERVICE_UNAVAILABLE -> 503
        PJSIP_SC_SERVICE_UNAVAILABLE = 503,

        /// PJSIP_SC_SERVER_TIMEOUT -> 504
        PJSIP_SC_SERVER_TIMEOUT = 504,

        /// PJSIP_SC_VERSION_NOT_SUPPORTED -> 505
        PJSIP_SC_VERSION_NOT_SUPPORTED = 505,

        /// PJSIP_SC_MESSAGE_TOO_LARGE -> 513
        PJSIP_SC_MESSAGE_TOO_LARGE = 513,

        /// PJSIP_SC_PRECONDITION_FAILURE -> 580
        PJSIP_SC_PRECONDITION_FAILURE = 580,

        /// PJSIP_SC_BUSY_EVERYWHERE -> 600
        PJSIP_SC_BUSY_EVERYWHERE = 600,

        /// PJSIP_SC_DECLINE -> 603
        PJSIP_SC_DECLINE = 603,

        /// PJSIP_SC_DOES_NOT_EXIST_ANYWHERE -> 604
        PJSIP_SC_DOES_NOT_EXIST_ANYWHERE = 604,

        /// PJSIP_SC_NOT_ACCEPTABLE_ANYWHERE -> 606
        PJSIP_SC_NOT_ACCEPTABLE_ANYWHERE = 606,

        /// PJSIP_SC_TSX_TIMEOUT -> PJSIP_SC_REQUEST_TIMEOUT
        PJSIP_SC_TSX_TIMEOUT = pjsip_status_code.PJSIP_SC_REQUEST_TIMEOUT,

        /// PJSIP_SC_TSX_TRANSPORT_ERROR -> PJSIP_SC_SERVICE_UNAVAILABLE
        PJSIP_SC_TSX_TRANSPORT_ERROR = pjsip_status_code.PJSIP_SC_SERVICE_UNAVAILABLE,
    }

    public enum pjsip_evsub_state
    {

        PJSIP_EVSUB_STATE_NULL,

        PJSIP_EVSUB_STATE_SENT,

        PJSIP_EVSUB_STATE_ACCEPTED,

        PJSIP_EVSUB_STATE_PENDING,

        PJSIP_EVSUB_STATE_ACTIVE,

        PJSIP_EVSUB_STATE_TERMINATED,

        PJSIP_EVSUB_STATE_UNKNOWN,
    }

    public enum pjsip_hdr_e
    {

        PJSIP_H_ACCEPT,

        PJSIP_H_ACCEPT_ENCODING_UNIMP,

        PJSIP_H_ACCEPT_LANGUAGE_UNIMP,

        PJSIP_H_ALERT_INFO_UNIMP,

        PJSIP_H_ALLOW,

        PJSIP_H_AUTHENTICATION_INFO_UNIMP,

        PJSIP_H_AUTHORIZATION,

        PJSIP_H_CALL_ID,

        PJSIP_H_CALL_INFO_UNIMP,

        PJSIP_H_CONTACT,

        PJSIP_H_CONTENT_DISPOSITION_UNIMP,

        PJSIP_H_CONTENT_ENCODING_UNIMP,

        PJSIP_H_CONTENT_LANGUAGE_UNIMP,

        PJSIP_H_CONTENT_LENGTH,

        PJSIP_H_CONTENT_TYPE,

        PJSIP_H_CSEQ,

        PJSIP_H_DATE_UNIMP,

        PJSIP_H_ERROR_INFO_UNIMP,

        PJSIP_H_EXPIRES,

        PJSIP_H_FROM,

        PJSIP_H_IN_REPLY_TO_UNIMP,

        PJSIP_H_MAX_FORWARDS,

        PJSIP_H_MIME_VERSION_UNIMP,

        PJSIP_H_MIN_EXPIRES,

        PJSIP_H_ORGANIZATION_UNIMP,

        PJSIP_H_PRIORITY_UNIMP,

        PJSIP_H_PROXY_AUTHENTICATE,

        PJSIP_H_PROXY_AUTHORIZATION,

        PJSIP_H_PROXY_REQUIRE_UNIMP,

        PJSIP_H_RECORD_ROUTE,

        PJSIP_H_REPLY_TO_UNIMP,

        PJSIP_H_REQUIRE,

        PJSIP_H_RETRY_AFTER,

        PJSIP_H_ROUTE,

        PJSIP_H_SERVER_UNIMP,

        PJSIP_H_SUBJECT_UNIMP,

        PJSIP_H_SUPPORTED,

        PJSIP_H_TIMESTAMP_UNIMP,

        PJSIP_H_TO,

        PJSIP_H_UNSUPPORTED,

        PJSIP_H_USER_AGENT_UNIMP,

        PJSIP_H_VIA,

        PJSIP_H_WARNING_UNIMP,

        PJSIP_H_WWW_AUTHENTICATE,

        PJSIP_H_OTHER,
    }

    public enum pjmedia_type
    {

        /// PJMEDIA_TYPE_NONE -> 0
        PJMEDIA_TYPE_NONE = 0,

        /// PJMEDIA_TYPE_AUDIO -> 1
        PJMEDIA_TYPE_AUDIO = 1,

        /// PJMEDIA_TYPE_VIDEO -> 2
        PJMEDIA_TYPE_VIDEO = 2,

        /// PJMEDIA_TYPE_UNKNOWN -> 3
        PJMEDIA_TYPE_UNKNOWN = 3,

        /// PJMEDIA_TYPE_APPLICATION -> 4
        PJMEDIA_TYPE_APPLICATION = 4,
    }

    public enum pjmedia_format_id
    {

        /// PJMEDIA_FORMAT_L16 -> 0
        PJMEDIA_FORMAT_L16 = 0,

        /// PJMEDIA_FORMAT_PCM -> PJMEDIA_FORMAT_L16
        PJMEDIA_FORMAT_PCM = pjmedia_format_id.PJMEDIA_FORMAT_L16,

        /// PJMEDIA_FORMAT_PCMA -> ('W'<<24|'A'<<16|'L'<<8|'A')
        PJMEDIA_FORMAT_PCMA = ('W') << ((24 | ('A') << ((16 | ('L') << ((8 | 'A')))))),

        /// PJMEDIA_FORMAT_ALAW -> PJMEDIA_FORMAT_PCMA
        PJMEDIA_FORMAT_ALAW = pjmedia_format_id.PJMEDIA_FORMAT_PCMA,

        /// PJMEDIA_FORMAT_PCMU -> ('W'<<24|'A'<<16|'L'<<8|'u')
        PJMEDIA_FORMAT_PCMU = ('W') << ((24 | ('A') << ((16 | ('L') << ((8 | 'u')))))),

        /// PJMEDIA_FORMAT_ULAW -> PJMEDIA_FORMAT_PCMU
        PJMEDIA_FORMAT_ULAW = pjmedia_format_id.PJMEDIA_FORMAT_PCMU,

        /// PJMEDIA_FORMAT_AMR -> ('R'<<24|'M'<<16|'A'<<8|' ')
        PJMEDIA_FORMAT_AMR = ('R') << ((24 | ('M') << ((16 | ('A') << ((8 | ' ')))))),

        /// PJMEDIA_FORMAT_G729 -> ('9'<<24|'2'<<16|'7'<<8|'G')
        PJMEDIA_FORMAT_G729 = ('9') << ((24 | ('2') << ((16 | ('7') << ((8 | 'G')))))),

        /// PJMEDIA_FORMAT_ILBC -> ('C'<<24|'B'<<16|'L'<<8|'I')
        PJMEDIA_FORMAT_ILBC = ('C') << ((24 | ('B') << ((16 | ('L') << ((8 | 'I')))))),
    }


    public enum pjsip_redirect_op
    {

        PJSIP_REDIRECT_REJECT,

        PJSIP_REDIRECT_ACCEPT,

        PJSIP_REDIRECT_PENDING,

        PJSIP_REDIRECT_STOP,
    }


    public enum pj_stun_nat_type
    {

        PJ_STUN_NAT_TYPE_UNKNOWN,

        PJ_STUN_NAT_TYPE_ERR_UNKNOWN,

        PJ_STUN_NAT_TYPE_OPEN,

        PJ_STUN_NAT_TYPE_BLOCKED,

        PJ_STUN_NAT_TYPE_SYMMETRIC_UDP,

        PJ_STUN_NAT_TYPE_FULL_CONE,

        PJ_STUN_NAT_TYPE_SYMMETRIC,

        PJ_STUN_NAT_TYPE_RESTRICTED,

        PJ_STUN_NAT_TYPE_PORT_RESTRICTED,
    }


    public enum pjmedia_frame_type
    {

        PJMEDIA_FRAME_TYPE_NONE,

        PJMEDIA_FRAME_TYPE_AUDIO,

        PJMEDIA_FRAME_TYPE_EXTENDED,
    }

    public enum pjmedia_srtp_use
    {

        PJMEDIA_SRTP_DISABLED,

        PJMEDIA_SRTP_OPTIONAL,

        PJMEDIA_SRTP_MANDATORY,
    }
}
