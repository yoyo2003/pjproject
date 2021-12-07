// pjsip_dll.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include <string>       // std::string
#include <iostream>
#include <sstream>      // std::stringstream
#include "pjsip_dll.h"
#include "pj/log.h"
#include <pjsip.h>
#include <pjlib-util.h>
#include <pjlib.h>
#include <pjsua-lib/pjsua.h>
#include <pj/types.h>


pj_log_func *orig_log_func;
FPLogMessage current_log_func;
const char* THIS_FILE = "PjSip_Dll";

inline pj_str_t str2Pj(const char * input_str)
{
	pj_str_t output_str;
	output_str.ptr = NULL;
	strcpy(output_str.ptr, input_str);
	output_str.slen = sizeof(input_str);
	return output_str;
}


static void log_msg(int level, const char *data, int len)
{
	if (level <= 3)
		orig_log_func(level, data, len);
	if (current_log_func) {
		current_log_func(level, data, len);
	}
	else if (level <= 3)
		orig_log_func(level, data, len);
}
static void log_msgC(int level, char *data, int len)
{
	log_msg(level, data, len);
}


// This is an example of an exported variable
PJSIP_DLL_API int  __cdecl default_log_level=3;

// This is an example of an exported function.
PJSIP_DLL_API int  __cdecl fnpjsip_dll(void)
{
    return 42;
}

//PJSIP_DLL_API int  __cdecl InitPjSip() {
//	const char* name = "testStringCVT";
//	pj_str_t dest = str2Pj(name);
//	log_msg(3, dest.ptr, dest.slen);
//	return 0;// pjsua_create();
//}
PJSIP_DLL_API void  LogPjStr(pj_str_t str) {

	log_msg(4, "passing in pj_str_t:", 120);
	log_msg(4, str.ptr, str.slen);

}


PJSIP_DLL_API void SetPjsuaSettings(const pjsua_settings* settings)
{
	std::string logmsg, names;
	log_msg(3, "test pjsua_settings:\n", 120);

	logmsg = std::string("maxCalls:" + std::to_string(settings->maxCalls));	
	log_msg(4, logmsg.c_str(), 200);
	logmsg = std::string("threadCnt:" + std::to_string(settings->threadCnt));
	log_msg(4, logmsg.c_str(), 200);
	logmsg = std::string("mainThreadOnly:" + std::to_string(settings->mainThreadOnly));
	log_msg(4, logmsg.c_str(), 200);
	logmsg = std::string("stunTryIpv6:" + std::to_string(settings->stunTryIpv6));
	log_msg(4, logmsg.c_str(), 200);
	logmsg = std::string("stunIgnoreFailure:" + std::to_string(settings->stunIgnoreFailure));
	log_msg(4, logmsg.c_str(), 200);
	logmsg = std::string("natTypeInSdp:" + std::to_string(settings->natTypeInSdp));
	log_msg(4, logmsg.c_str(), 200);
	logmsg = std::string("mwiUnsolicitedEnabled:" + std::to_string(settings->mwiUnsolicitedEnabled));
	log_msg(4, logmsg.c_str(), 200);
	
	logmsg = std::string("UserAgent:");
	logmsg = logmsg + settings->userAgent.ptr;
	log_msg(4, logmsg.c_str(), 100);
/*
	logmsg = std::string("test:");
	logmsg = logmsg + std::to_string(settings->test);
	log_msg(4, logmsg.c_str(), sizeof(logmsg));
	printf("test:%u\n", settings->test);*/

	int len = sizeof(settings->nameserver) / sizeof(settings->nameserver[0]);
	logmsg = std::string("nameservice:" + std::to_string(len));
	log_msg(4, logmsg.c_str(), 25);

	for (int i = 0; i < len && i < settings->nameserver_cnt; ++i)
	{
		log_msg(4, settings->nameserver[i].ptr, strlen(settings->nameserver[i].ptr));
	}

	len = sizeof(settings->outbound_proxy) / sizeof(settings->outbound_proxy[0]);
	logmsg = std::string("outbound_proxy length:" + std::to_string(len));
	log_msg(4, logmsg.c_str(), 25);

	for (int i = 0; i < len && i < settings->outbound_proxy_cnt; ++i)
	{
		log_msg(4, settings->outbound_proxy[i].ptr, settings->outbound_proxy[i].slen);
	}

	len = sizeof(settings->stunServer) / sizeof(settings->stunServer[0]);
	logmsg = std::string("stunServer length:" + std::to_string(len));
	log_msg(4, logmsg.c_str(), 25);

	for (int i = 0; i < len && i < settings->stunServer_cnt; ++i)
	{
		log_msg(4, settings->stunServer[i].ptr, settings->stunServer[i].slen);
	}
}

PJSIP_DLL_API void  __cdecl SetPjSipLogging(FPLogMessage onLogMessage, int level)
{
	current_log_func = onLogMessage;
	pj_log_set_level(level); 	
	orig_log_func = pj_log_get_log_func();
	pj_log_set_log_func(&log_msg);
}
PJSIP_DLL_API void  __cdecl SendTestLog(int level) {
	std::string logmsg, calls;

	logmsg = std::string("test logging message (PJSUA_MAX_CALLS):");	
	calls = std::string(STR_MACRO(PJSUA_MAX_CALLS));
	
	log_msg(level, (logmsg + calls + "\n").c_str(), 20);
}

PJSIP_DLL_API void  __cdecl get_pjsua_media_config_default(pjsua_media_config* media_cnf) {
	pjsua_media_config_default(media_cnf);
}


pjsua_config toPj(pjsua_settings* settings)
{
	unsigned i = 0;
	pjsua_config pua_cfg;

	// Initialize configs with default settings.
	pjsua_config_default(&pua_cfg);

	pua_cfg.max_calls = settings->maxCalls;
	pua_cfg.thread_cnt = settings->threadCnt;
	pua_cfg.user_agent = settings->userAgent;

	int len = sizeof(settings->nameserver) / sizeof(settings->nameserver[0]);
	for (i = 0; i < PJ_ARRAY_SIZE(settings->nameserver); ++i)
	{
		pua_cfg.nameserver[i] = settings->nameserver[i];
	}
	pua_cfg.nameserver_count = i;

	
	for (i = 0; i < PJ_ARRAY_SIZE(settings->stunServer); ++i)
	{
		pua_cfg.stun_srv[i] = settings->stunServer[i];
	}
	pua_cfg.stun_srv_cnt = i;

	for (i = 0; i< PJ_ARRAY_SIZE(settings->outbound_proxy); ++i)
	{
		pua_cfg.outbound_proxy[i] = settings->outbound_proxy[i];
	}
	pua_cfg.outbound_proxy_cnt = i;

	pua_cfg.nat_type_in_sdp = settings->natTypeInSdp;
	pua_cfg.enable_unsolicited_mwi = settings->mwiUnsolicitedEnabled;
	pua_cfg.stun_try_ipv6 = settings->stunTryIpv6;
	pua_cfg.stun_ignore_failure = settings->stunIgnoreFailure;
	pua_cfg.cb = settings->cb;
	return pua_cfg;
}

PJSIP_DLL_API int __cdecl InitPjSip(const pjsua_settings* ua_settings, const  pjsua_logging_config* log_cfg, const  pjsua_media_config* media_cfg)
{
	pj_status_t status;
	// Must create pjsua before anything else!
	status = pjsua_create();
	if (status != PJ_SUCCESS) {
		pjsua_perror(THIS_FILE, "Error initializing pjsua", status);
		return status;
	}
	SetPjsuaSettings(ua_settings);

	pjsua_config ua_cfg;
	ua_cfg = toPj((pjsua_settings*)ua_settings);
	pjsua_logging_config_default((pjsua_logging_config*)log_cfg);
	pjsua_media_config_default((pjsua_media_config*)media_cfg);

	// At the very least, application would want to override
	// the call callbacks in pjsua_config:
	/*ua_cfg.cb.on_incoming_call = ...
		ua_cfg.cb.on_call_state = ..*/
	return pjsua_init(&ua_cfg, log_cfg, media_cfg);
}

// This is the constructor of a class that has been exported.
// see pjsip_dll.h for the class definition
//Cpjsip_dll::Cpjsip_dll()
//{
//    return;
//}






