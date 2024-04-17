using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace strengthGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PercentLabel.Text = "강화 확률 : " + strPer[characterLevel];
        }
        int characterLevel = 0; //강화 레벨
        int gameMoney = 100000; //시작 금액
        int gameItem = 1; //굉장해엄청나 카드 수
        int gameItemPlus = 0;
        int orderNum = 0; //CSV 처리 번호
        int[] strCost = {100, 500, 1000, 2000, 5000, 7000, 15000, 30000, 50000, 100000 }; //강화 비용
        int[] sellCost = {0, 50, 500, 1000, 3000, 15000, 50000, 100000, 150000, 9999999 }; //판매 비용
        int[] strPer = { 100, 99, 95, 90, 85, 80, 70, 50, 30, 10 };
        string[] alarmName = { "0강","1강", "2강", "3강", "4강", "5강", "6강", "7강", "8강", "9강", "10강", };
        string result;
        string[] status = { "success", "failure" };
        public bool sResult(int perC)
        {
            Random rand = new Random(); // 랜덤 생성 변수 선언
            int percent = (int)rand.Next(1, 101); // 1~100 중 랜덤한 숫자 받아와서 정수형(Int)으로 변환한 값을 저장
            if (percent <= perC) // 확률보다 숫자가 낮으면 강화 성공!
            {
                // 20%의 확률로 2단 강화
                if (characterLevel < 9 && percent <= 15)
                {
                    characterLevel += 2; // 강화 레벨 2단 증가
                }
                else
                {
                    ++characterLevel; // 강화 레벨 증가
                }

                // 강화 레벨이 최대 레벨을 넘어가는지 확인하여 최대 레벨로 조정
                if (characterLevel > 10)
                {
                    characterLevel = 10;
                }

                statusText.Text = characterLevel + "강"; // 강화 레벨 텍스트 표현
                result = status[0];
                return true; // True값을 줘서 실행
            }
            else
            {
                characterLevel = 0;
                statusText.Text = characterLevel + "강";

                result = status[1];
                return false; // False값을 주면 이미지가 사라짐, 그냥 일단 테스팅용
            }
        }

        private void button1_Click(object sender, EventArgs e) //강화버튼 클릭시
        {

            switch (characterLevel) //강화레벨마다 다르게 적용
            {
                case 0: //0강 상태
                    if (gameMoney < strCost[characterLevel]) //재화가 부족할 때
                    {
                        MessageBox.Show("파산하셨습니다. 게임을 종료합니다."); //파산 메시지 출력
                        Application.Exit(); //게임 종료
                    }
                    else //재화가 충분할때
                    {
                        gameMoney -= strCost[characterLevel]; //플레이어 재화 감소
                        pictureBox1.Visible = sResult(100); //성공 시 사진 출력값 :true(보이게). 실패는 false
                        pictureBox1.Image = Properties.Resources.s2;
                        WriteStrengthCsv();
                    }
                    break; //마침표

                case 1: //1강 상태
                    if (gameMoney < strCost[characterLevel])
                    {
                        MessageBox.Show("파산하셨습니다. 게임을 종료합니다.");
                        Application.Exit();
                    }
                    else
                    {
                        gameMoney -= strCost[characterLevel];
                        pictureBox1.Visible = sResult(99);
                        pictureBox1.Image = Properties.Resources.s3;
                        WriteStrengthCsv();
                    }
                    break;
                case 2: //2강 상태.. 이하생략
                    if (gameMoney < strCost[characterLevel])
                    {
                        MessageBox.Show("파산하셨습니다. 게임을 종료합니다.");
                        Application.Exit();
                    }
                    else
                    {
                        gameMoney -= strCost[characterLevel];
                        pictureBox1.Visible = sResult(95);
                        pictureBox1.Image = Properties.Resources.s4;
                        WriteStrengthCsv();
                    }
                    break;
                case 3:
                    if (gameMoney < strCost[characterLevel])
                    {
                        MessageBox.Show("파산하셨습니다. 게임을 종료합니다.");
                        Application.Exit();
                    }
                    else
                    {
                        gameMoney -= strCost[characterLevel];
                        pictureBox1.Visible = sResult(90);
                        pictureBox1.Image = Properties.Resources.s5;
                        WriteStrengthCsv();
                    }
                    break;
                case 4:
                    if (gameMoney < strCost[characterLevel])
                    {
                        MessageBox.Show("파산하셨습니다. 게임을 종료합니다.");
                        Application.Exit();
                    }
                    else
                    {
                        gameMoney -= strCost[characterLevel];
                        pictureBox1.Visible = sResult(85);
                        pictureBox1.Image = Properties.Resources.s6;
                        WriteStrengthCsv();
                    }
                    break;
                case 5:
                    if (gameMoney < strCost[characterLevel])
                    {
                        MessageBox.Show("잔액이 부족합니다! 캐릭터를 판매하세요!"); //이윤을 볼 수 있기 때문에 파산X
                    }
                    else
                    {
                        gameMoney -= strCost[characterLevel];
                        pictureBox1.Visible = sResult(80);
                        pictureBox1.Image = Properties.Resources.s7;
                        WriteStrengthCsv();
                    }
                    break;
                case 6:
                    if (gameMoney < strCost[characterLevel])
                    {
                        MessageBox.Show("잔액이 부족합니다! 캐릭터를 판매하세요!");
                    }
                    else
                    {
                        gameMoney -= strCost[characterLevel];
                        pictureBox1.Visible = sResult(70);
                        pictureBox1.Image = Properties.Resources.s8;
                        WriteStrengthCsv();
                    }
                    break;
                case 7:
                    if (gameMoney < strCost[characterLevel])
                    {
                        MessageBox.Show("잔액이 부족합니다! 캐릭터를 판매하세요!");
                    }
                    else
                    {
                        gameMoney -= strCost[characterLevel];
                        pictureBox1.Visible = sResult(50);
                        pictureBox1.Image = Properties.Resources.s9;
                        WriteStrengthCsv();
                    }
                    break;
                case 8:
                    if (gameMoney < strCost[characterLevel])
                    {
                        MessageBox.Show("잔액이 부족합니다! 캐릭터를 판매하세요!");
                    }
                    else
                    {
                        gameMoney -= strCost[characterLevel];
                        pictureBox1.Visible = sResult(30);
                        pictureBox1.Image = Properties.Resources.s10;
                        WriteStrengthCsv();
                    }
                    break;
                case 9:
                    if (gameMoney < strCost[characterLevel])
                    {
                        MessageBox.Show("잔액이 부족합니다! 캐릭터를 판매하세요!");
                    }
                    else
                    {
                        gameMoney -= strCost[characterLevel];
                        pictureBox1.Visible = sResult(10);
                        pictureBox1.Image = Properties.Resources.s11;
                        WriteStrengthCsv();
                    }
                    break;
                case 10:
                    MessageBox.Show("최고 강화 레벨입니다."); //강화 불가 메시지 출력(최고 레벨)
                    
                    break;
            }
            ++gameItemPlus;
            if(gameItemPlus == 10) 
            {
                gameItemPlus = 0;
                ++gameItem;
            }
            moneyQuan.Text = "돈 : " + gameMoney.ToString(); //남은 재화 출력
            itemQuan.Text = "아이템 : " + gameItem.ToString(); //남은 아이템 개수 출력
            StrcostText.Text = "강화 비용 : " + strCost[characterLevel];
            sellCostText.Text = "판매 비용 : " + sellCost[characterLevel];
            PercentLabel.Text = "강화 확률 : " +strPer[characterLevel];
        }

        private void btn_Item_Click(object sender, EventArgs e) //아이템(굉장히 엄청나) 사용 버튼 클릭시
        {
            if(gameItem == 0) //아이템이 없을 때
            {
                MessageBox.Show("아이템이 없습니다!"); //사용 불가 메시지 출력
            }
            else //아이템이 있을 때
            {
                --gameItem; //아이템 수 감소
                ++characterLevel; //강화 레벨 증가
                WriteItemStrengthCsv();
                statusText.Text = characterLevel + "강"; //강화 레벨 텍스트 출력
                itemQuan.Text = "아이템 : "+gameItem.ToString(); //아이템 개수 출력
                pictureBox1.Visible = true; //사진 보여지게 설정
            }
            StrcostText.Text = "강화 비용 : " + strCost[characterLevel];
            sellCostText.Text = "판매 비용 : " + sellCost[characterLevel];
            PercentLabel.Text = "강화 확률 : " + strPer[characterLevel];

        }

        private void button2_Click(object sender, EventArgs e) //판매 버튼 클릭시
        {
            if(characterLevel == 0) //강화하지 않았을 때. 즉, 강화 레벨이 0일때
            {
                MessageBox.Show("판매할 수 없는 강화 단계입니다."); //판매 불가 메시지 출력
            }
            else if(characterLevel == 1) //강화 레벨이 1일 때
            {
                WriteSaleCsv();
                gameMoney += sellCost[characterLevel]; //플레이어 재화 증가(판매 비용 획득)
                moneyQuan.Text = "돈 : " + gameMoney.ToString(); //재화 텍스트 출력
                characterLevel = 0; //판매 후 레벨 초기화
                statusText.Text = characterLevel + "강"; //강화 레벨 텍스트 출력
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. "); //판매 완료 메시지 출력
                
            }
            else if (characterLevel == 2) //강화 레벨이 2일 때.. 이하생략
            {
                WriteSaleCsv();
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 3)
            {
                WriteSaleCsv();
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 4)
            {
                WriteSaleCsv();
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 5)
            {
                WriteSaleCsv();
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 6)
            {
                WriteSaleCsv();
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 7)
            {
                WriteSaleCsv();
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 8)
            {
                WriteSaleCsv();
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 9)
            {
                WriteSaleCsv();
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 10)
            {
                WriteSaleCsv();
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else //버그 발생시 대응(혹시나 하고)
            {
                MessageBox.Show("오류가 감지되었습니다. 프로그램을 종료합니다.");
                Application.Exit();
            }
            pictureBox1.Image = Properties.Resources.s1;
            StrcostText.Text = "강화 비용 : " + strCost[characterLevel];
            sellCostText.Text = "판매 비용 : " + sellCost[characterLevel];
            PercentLabel.Text = "강화 확률 : " + strPer[characterLevel];
        }
        private void Reset()
        {
            orderNum = 0;
            // 다른 변수들도 초기화하거나 리셋하는 작업 추가
        }
        private void WriteStrengthCsv()
        {
            orderNum += 1;
            if (!File.Exists("GameData.csv"))
            {
                using (StreamWriter sw = new StreamWriter("GameData.csv", false, Encoding.UTF8))
                {
                    sw.WriteLine("No.,Type,Time,AlarmName,Status,quantity_money,quantity_item");
                    sw.WriteLine($"{orderNum},{"Strength"},{DateTime.Now},{alarmName[characterLevel]},{result},{gameMoney},{gameItem}");
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter("GameData.csv", true, Encoding.UTF8))
                {
                    sw.WriteLine($"{orderNum},{"Strength"},{DateTime.Now},{alarmName[characterLevel]},{result},{gameMoney},{gameItem}");
                }
            }
            
        }
        private void WriteItemStrengthCsv()
        {
            orderNum += 1;
            if (!File.Exists("GameData.csv"))
            {
                using (StreamWriter sw = new StreamWriter("GameData.csv", false, Encoding.UTF8))
                {
                    sw.WriteLine("No.,Type,Time,AlarmName,Status,quantity_money,quantity_item");
                    sw.WriteLine($"{orderNum},{"ItemStrength"},{DateTime.Now},{alarmName[characterLevel]},{result},{gameMoney},{gameItem}");
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter("GameData.csv", true, Encoding.UTF8))
                {
                    sw.WriteLine($"{orderNum},{"ItemStrength"},{DateTime.Now},{alarmName[characterLevel]},{result},{gameMoney},{gameItem}");
                }
            }

        }
        private void WriteSaleCsv()
        {
            orderNum += 1;
            if (!File.Exists("GameData.csv"))
            {
                using (StreamWriter sw = new StreamWriter("GameData.csv", false, Encoding.UTF8))
                {
                    sw.WriteLine("No.,Type,Time,AlarmName,Status,quantity_money,quantity_item");
                    sw.WriteLine($"{orderNum},{"Sale"},{DateTime.Now},{alarmName[characterLevel]},{"blank"},{gameMoney},{gameItem}");
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter("GameData.csv", true, Encoding.UTF8))
                {
                    sw.WriteLine($"{orderNum},{"Sale"},{DateTime.Now},{alarmName[characterLevel]},{"blank"},{gameMoney},{gameItem}");
                }
            }

        }

        private void label1_Click(object sender, EventArgs e) //게임설명레이블
        {
            
        }

        private void button3_Click(object sender, EventArgs e) //게임설명 버튼
        {
            if(label1.Visible == true)
            {
                label1.Visible = false;
            }
            else
            {
                label1.Visible = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }


    }
}
