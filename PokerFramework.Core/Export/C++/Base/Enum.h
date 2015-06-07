#pragma once

#include <type_traits>

#define Enum(enumType) \
__forceinline enumType enumType##From(std::underlying_type<enumType>::type a) { return static_cast<enumType>(a); };\
__forceinline std::underlying_type<enumType>::type enumType##Value(enumType a) { return static_cast<std::underlying_type<enumType>::type>(a); };

#define EnumFlags(enumType) Enum(enumType) \
__forceinline enumType operator~(enumType a) { return enumType##From(~enumType##Value(a)); }; \
__forceinline enumType operator|(enumType a, enumType b) { return enumType##From(enumType##Value(a) | enumType##Value(b)); };\
__forceinline enumType& operator|=(enumType& a, enumType b) { return a = enumType##From(enumType##Value(a) | enumType##Value(b)); };\
__forceinline enumType operator&(enumType a, enumType b) { return enumType##From(enumType##Value(a) & enumType##Value(b)); };\
__forceinline enumType& operator&=(enumType& a, enumType b) { return a = enumType##From(enumType##Value(a) & enumType##Value(b)); };\
__forceinline enumType operator^(enumType a, enumType b) { return enumType##From(enumType##Value(a) ^ enumType##Value(b)); };\
__forceinline enumType& operator^=(enumType& a, enumType b) { return a = enumType##From(enumType##Value(a) ^ enumType##Value(b)); };\
__forceinline enumType operator>>(enumType a, int count) { return enumType##From(enumType##Value(a) >> count); };\
__forceinline enumType& operator>>=(enumType& a, int count) { return a = enumType##From(enumType##Value(a) >> count); };\
__forceinline enumType operator<<(enumType a, int count) { return enumType##From(enumType##Value(a) << count); };\
__forceinline enumType& operator<<=(enumType& a, int count) { return a = enumType##From(enumType##Value(a) << count); };\
__forceinline enumType operator+(enumType a, enumType b) { return enumType##From(enumType##Value(a) + enumType##Value(b)); };\
__forceinline enumType& operator+=(enumType& a, enumType b) { return a = enumType##From(enumType##Value(a) + enumType##Value(b)); };\
__forceinline enumType operator-(enumType a, enumType b) { return enumType##From(enumType##Value(a) - enumType##Value(b)); };\
__forceinline enumType& operator-=(enumType& a, enumType b) { return a = enumType##From(enumType##Value(a) - enumType##Value(b)); };
