﻿#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include "Word.h"
using namespace std;
vector<Word> ListofWords;
void convert(char* str , string line)
{
	for (unsigned int i=0; i< line.length(); i++)
	{
		str[i] = line[i];
	}
}
bool checkDoublicate(Word temp)
{
	for (int k =0; k< ListofWords.size();k++)
	{
		if (temp.content == ListofWords[k].content)
		{
			ListofWords[k].nApproache++;
			return true;
		}
	}
	return false;
}

void main ()
{
	ifstream infile;
	infile.open("input.txt");
	string line;
	char *str;
	char *temp;

	Word wTemp;
	while (!infile.eof())
	{
		getline(infile, line);
		str = new char[line.length()+1];
		convert(str,line);
		str[line.length()] = '\0';

		temp = strtok (str," ");
		wTemp.content=temp;
		ListofWords.push_back(wTemp);
		while (temp!=NULL)
		{
			temp = strtok (NULL, " ");
			wTemp.content = temp;
			bool Check = checkDoublicate(wTemp);
			if (!Check)
			{
				ListofWords.push_back(wTemp);
				wTemp.content.SetString(_T(""));
			}
		}
	}
	delete [] str;
	infile.close();
}