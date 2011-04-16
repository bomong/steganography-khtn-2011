using System;
using System.Collections.Generic;
using System.Text;

namespace WL
{
    public class Word
    {
        public string sContent;
        public int nApproach;
        public List<float> WL {get; set;}
        public float SD;
        public Word()
        {
            sContent = "";
            nApproach = 1;
            WL = new List<float>();
        }
        //-------tính giá trị WL trung bình của 1 từ-------------------------------------------------
        public float Cal_AvgWL()
        {
            float totalWL;
            totalWL = 0;
            foreach (float temp in this.WL)
            {
                totalWL += temp;
            }
            return totalWL / this.WL.Count; // Avg_Wl 
        }

        //------tính giá trị SD của 1 từ------------------------------------------------------------
        public float SD_value()
        {
            float totalSD1;
            totalSD1 = 0;
            for (int i = 0; i < WL.Count; i++ )
            {
                totalSD1 += (WL[i] - this.Cal_AvgWL()) * (WL[i] - this.Cal_AvgWL());
            }
            return totalSD1 / WL.Count;
        }
    }
    class Program
    {
        //-----Khởi tạo danh sách (S), tính WL cho từng Wi------------------------------------------
        static void InitListofWord(string[] ListTemp, List<Word>ListofWords)
        {
            foreach (string word in ListTemp)
            {
                Word wtemp = new Word();
                wtemp.sContent = word;
                 if (wtemp.sContent != "")
                 {
                     ListofWords.Add(wtemp);
                 }
            }
            for (int i = 1; i <= ListofWords.Count; i++)
            {
                float wlTemp = new float();
                wlTemp = (float)i / ListofWords.Count;
                ListofWords[i - 1].WL.Add(wlTemp);
            }
        }
        //--

        //------ Hiệu chỉnh danh sách từ lần 1 : gom nhóm các từ giống nhau ( S -> S')---------------
        static void ModifyList_V1(List<Word> ListWords)
        {            
        startPoint1:
            for (int i = 1; i < ListWords.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (ListWords[i].sContent == ListWords[j].sContent)
                    {
                        ListWords[j].nApproach++;
                        ListWords[j].WL.Add(ListWords[i].WL[0]);
                        ListWords.Remove(ListWords[i]);
                        goto startPoint1;
                    }
                }
            }
        }
        //--

        //--------- Tính SD của 1 từ trong danh sách---------------------------------------------------
        static void Cal_SD(List<Word> ListofWords)
        {
            foreach (Word item in ListofWords)
            {
                item.SD = item.SD_value();
            }
        }
        //--

        //-------Hiệu chỉnh danh sách từ lần 2: Loại bỏ những từ có độ dàn trải SD = 0----------------
        static void ModifyList_V2(List<Word> ListWords)
        {
            starPoint2:
            for (int i = 1; i < ListWords.Count; i++)
            {
                if (ListWords[i].SD ==0)
                {
                    ListWords.Remove(ListWords[i]);
                    goto starPoint2;
                }
            }
        }
        //--

        //---------- Tính giá trị SD trung bình của danh sách còn lại-------------------------------
        static float Cal_AvgSD (List<Word> ListofWords, float N)
        {
            float totalSD2;
            totalSD2 = 0;
            for (int i = 0; i < ListofWords.Count; i++ )
            {
                totalSD2 += ListofWords[i].SD * ((ListofWords[i].WL.Count) / N);
            }
            return totalSD2;
        }
        static float Cal_VarSD(List<Word> ListofWords)
        {
            int N; // giá trị N' trong công thứ (c)
            N = 0;
            foreach (Word item in ListofWords)
            {
                N += item.WL.Count;
            }
            float fN = (float)N;
            float avg_SD;
            avg_SD = Cal_AvgSD(ListofWords,fN);

            float total_VarSD;
            total_VarSD = 0;
            for (int i = 0; i < ListofWords.Count; i++ )
            {
                total_VarSD += ((ListofWords[i].SD - avg_SD) * (ListofWords[i].SD - avg_SD)) * (ListofWords[i].WL.Count / fN);
            }
            return total_VarSD;
        }
        //--------MAIN-------------------------------------------------------------------------------
        static void Main(string[] args)
        {
            List<Word> ListofWords = new List<Word>();

            string text = System.IO.File.ReadAllText("text.txt");
            string[] ListTemp = text.Split(' ', ',', ' ', '.', '!', ';','\r', '\n');
            InitListofWord(ListTemp, ListofWords);
            ModifyList_V1(ListofWords);
            Cal_SD(ListofWords);
            ModifyList_V2(ListofWords);
            float VarSD = Cal_VarSD(ListofWords);
        }
    }
}
