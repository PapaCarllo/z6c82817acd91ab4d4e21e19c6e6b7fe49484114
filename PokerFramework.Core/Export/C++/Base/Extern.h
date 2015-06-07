#pragma once

#if POKERFRAMEWORKCORE_EXPORTS

#define PokerFrameworkExtern(returnType) extern "C" __declspec(dllexport) returnType __stdcall

#else

#define PokerFrameworkExtern(returnType) extern "C" __declspec(dllimport) returnType __stdcall

#endif
