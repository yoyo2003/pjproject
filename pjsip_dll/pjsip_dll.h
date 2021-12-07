// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the PJSIP_DLL_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// PJSIP_DLL_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef PJSIP_DLL_EXPORTS
#define PJSIP_DLL_API __declspec(dllexport)
#else
#define PJSIP_DLL_API __declspec(dllimport)
#endif

// modify in pj/config_site.h 
#define PJSUA_MAX_CALLS 1024;

#define STR_MACRO(x) STR_INT(x)
#define STR_INT(x) #x 

//===================================================================
// Callback function definitions
//===================================================================
typedef void(__cdecl *FPSendSipMessage)(int eventCode, const char *message);
typedef void(__cdecl *FPReceivedSipMessage)(int eventCode, const char *message);
typedef void(__cdecl *FPLogMessage)(int level, const char *data, int len);

typedef void(__cdecl *pjsua_on_incoming_call)();

	

extern "C" {
#include <pj/types.h>
#include <pjsua.h>
	
	typedef struct pjsua_settings {
		unsigned 	maxCalls;
		unsigned 	threadCnt;
		int			natTypeInSdp;
		bool		mainThreadOnly;
		bool		stunTryIpv6;
		bool		stunIgnoreFailure;
		bool		mwiUnsolicitedEnabled;

		pj_str_t nameserver[4];
		unsigned nameserver_cnt;
		pj_str_t outbound_proxy[4];
		unsigned outbound_proxy_cnt;
		pj_str_t userAgent;
		pj_str_t stunServer[8];
		unsigned stunServer_cnt;

		pjmedia_srtp_use use_srtp;
		int		         srtp_secure_signaling;
		pj_bool_t	     hangup_forked_call;
		pjsua_callback   cb;
	};

	// This class is exported from the pjsip_dll.dll
	//class PJSIP_DLL_API Cpjsip_dll {
	//public:
	//	Cpjsip_dll(void);
	//	// TODO: add your methods here.
	//};

	extern PJSIP_DLL_API  int __cdecl default_log_level;

	PJSIP_DLL_API int  __cdecl fnpjsip_dll(void);
	PJSIP_DLL_API void __cdecl SendTestLog(int level);
	PJSIP_DLL_API void __cdecl SetPjSipLogging(FPLogMessage onLogMessage, int level);	
	PJSIP_DLL_API void __cdecl SetPjsuaSettings(const pjsua_settings* settings);
	PJSIP_DLL_API void __cdecl LogPjStr(pj_str_t str);
	PJSIP_DLL_API void __cdecl get_pjsua_media_config_default(pjsua_media_config* media_cnf);
	PJSIP_DLL_API int  __cdecl InitPjSip(const pjsua_settings * ua_cfg, const  pjsua_logging_config * log_cfg, const  pjsua_media_config * media_cfg);
}
