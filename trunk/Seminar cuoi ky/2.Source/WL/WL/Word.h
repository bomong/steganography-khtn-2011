#pragma once
#include "CString"
#include <atlstr.h>
class Word
{
public:
	CString content;
	int nApproache;
	float Wl;
	float SD;
	float VarSD;
	void Cal_WL();
	void Cal_SD();
	void Cal_VarSD();
	Word(void);
	virtual ~Word(void);
public:
};

