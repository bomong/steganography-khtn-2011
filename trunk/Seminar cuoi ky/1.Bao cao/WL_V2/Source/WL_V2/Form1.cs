using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace WL_V2
{
    public partial class Form1 : Form
    {
        int flag_confirm = 0;
        public string PathName;
        public string FileName;
        public int iNumber_of_input;

        public class Word
        {
            public string sContent;
            public int nApproach;
            public List<float> WL { get; set; }
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
                for (int i = 0; i < WL.Count; i++)
                {
                    totalSD1 += (WL[i] - this.Cal_AvgWL()) * (WL[i] - this.Cal_AvgWL());
                }
                return totalSD1 / WL.Count;
            }
        }
        //-----Khởi tạo danh sách (S), tính WL cho từng Wi------------------------------------------
        static void InitListofWord(string[] ListTemp, List<Word> ListofWords)
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
            for (int i = 0; i < ListWords.Count; i++)
            {
                if (ListWords[i].SD == 0)
                {
                    ListWords.Remove(ListWords[i]);
                    goto starPoint2;
                }
            }
        }
        //--

        //---------- Tính giá trị SD trung bình của danh sách còn lại-------------------------------
        static float Cal_AvgSD(List<Word> ListofWords, float N)
        {
            float totalSD2;
            totalSD2 = 0;
            for (int i = 0; i < ListofWords.Count; i++)
            {
                totalSD2 += ListofWords[i].SD * ((ListofWords[i].WL.Count) / N);
            }
            return totalSD2;
        }
        static float Cal_VarSD(List<Word> ListofWords, float avg_SD, float fN)
        {
            avg_SD = Cal_AvgSD(ListofWords, fN);

            float total_VarSD;
            total_VarSD = 0;
            for (int i = 0; i < ListofWords.Count; i++)
            {
                total_VarSD += ((ListofWords[i].SD - avg_SD) * (ListofWords[i].SD - avg_SD)) * (ListofWords[i].WL.Count / fN);
            }
            return total_VarSD;
        }
        public Form1()
        {
            InitializeComponent();
            this.label_Chose.Text = "Chọn đường dẫn đến thư mục chứa file đầu vào:";
            this.textBox_FilePath.Text = "Click để chọn file";
            this.label_Number_of_input.Text = "Cho biết số lượng file cần tính (có tên file theo cấu trúc trên)";
            this.button_Confirm.Text= "Xác nhận";
            this.button_Redo.Text = "Làm lại";
            this.button_calculate.Text = "Thực hiện";
            this.label_status.Text = "";

        }

        private void textBox_FilePath_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog opdlg = new OpenFileDialog();
            string file = "";
            opdlg.ShowDialog();
           
            file = opdlg.FileName;
            DirectoryInfo path = new DirectoryInfo(file);
            FileName = path.Name;
            path = new DirectoryInfo(file).Parent;
            PathName = path.FullName;
            string stringFileName = "";

            for (int i = 0; i < FileName.Length; i++)
            {
                if (FileName[i] != '(')
                {
                    stringFileName += FileName[i];
                }
                else
                {
                    break;
                }
            }
            stringFileName = stringFileName + "(xx)" + ".txt";
            this.textBox_FilePath.Text = stringFileName;
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            if (this.textBox_Number_of_input.Text != "" && this.textBox_FilePath.Text != "")
            {
                iNumber_of_input = Convert.ToInt32(this.textBox_Number_of_input.Text);
                string anno = "THÔNG TIN CHƯƠNG TRÌNH  \n" + "- Thư Mục: " + PathName + "\n" + "- Tên file mẫu : " + FileName + "\n" + "- Số lượng file đầu vào: " + iNumber_of_input.ToString();
                this.label_status.Text = anno;
                
                this.flag_confirm = 1;
                this.textBox_FilePath.Enabled = false;
                this.textBox_Number_of_input.Enabled = false;
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin \n Hoặc thông tin đầu vào không chính xác >ii<");
            }

        }

        private void button_Redo_Click(object sender, EventArgs e)
        {
            this.textBox_Number_of_input.Text = "";
            this.textBox_FilePath.Text = "";
            iNumber_of_input = 0;
            this.flag_confirm = 0;
            this.textBox_FilePath.Enabled = true;
            this.textBox_Number_of_input.Enabled = true;
            this.textBox_FilePath.Text = "Click để chọn file";
        }

        private void button_calculate_Click(object sender, EventArgs e)
        {
            

            if ( this.flag_confirm ==1)
            {
                //string anno = "Chương trình đang chạy ....\n Xin vui lòng đợi trong giây lát ^^";
                //this.label_status.Text = anno;
                this.button_calculate.Enabled = false;
                this.button_Confirm.Enabled = false;
                this.button_Redo.Enabled = false;
                StreamWriter outfile;
            
                string outputForFile = "";
                string stringFileName = "";

                for (int i = 0; i < FileName.Length; i++)
                {
                    if (FileName[i] != '(')
                    {
                        stringFileName += FileName[i];
                    }
                    else
                    {
                        break;
                    }
                }

                string outfileFileName = PathName + '\\' + "Result " + stringFileName + ".txt";
                outfile = new StreamWriter(outfileFileName);
            
                for (int i = 1; i <= iNumber_of_input; i++)
                {
                    List<Word> ListofWords = new List<Word>();
                    //textBox_FilePath.Text.Length = textBox_FilePath.Text.Length - 5;

                    string stringTemp;
                    stringTemp = stringFileName + '(' + i.ToString() + ')' + ".txt";
             
                    string text = System.IO.File.ReadAllText(PathName + "\\" + stringTemp);

                

                    string[] ListTemp = text.Split(' ', ',', ' ', '.', '!', ';', '\r', '\n', '?');
                    InitListofWord(ListTemp, ListofWords);
                    ModifyList_V1(ListofWords);
                    Cal_SD(ListofWords);
                    ModifyList_V2(ListofWords);

                    int N; // giá trị N' trong công thứ (c)
                    N = 0;
                    foreach (Word item in ListofWords)
                    {
                        N += item.WL.Count;
                    }
                    float fN = (float)N;
                    float avgSD = Cal_AvgSD(ListofWords, N);
                    string output = "";
                    output += "ID: " + i.ToString() + " avgSD= " + avgSD.ToString() + "\t\t VarSD= ";
                    float VarSD = Cal_VarSD(ListofWords, avgSD, fN);// 
                    output += VarSD.ToString();
                    outfile.WriteLine(output);
                }
                outfile.Flush();
                outfile.Close();
                this.label_status.Text = " Quá trình thực hiện đã hoàn tất";
                this.button_calculate.Enabled = true;
                this.button_Confirm.Enabled = true;
                this.button_Redo.Enabled = true;
            }
            else
            {
                MessageBox.Show(" Hãy xác nhận thông tin đầu vào");
            }
        }
    }
}
