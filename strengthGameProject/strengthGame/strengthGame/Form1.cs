using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }
        int characterLevel = 0; //강화 레벨
        int gameMoney = 100000; //시작 금액
        int gameItem = 1; //굉장해엄청나 카드 수
        int gameItemPlus = 0;
        int[] strCost = { 100, 500, 1000, 2000, 5000, 7000, 15000, 30000, 50000, 100000 }; //강화 비용
        int[] sellCost = { 50, 200, 500, 1000, 3000, 15000, 50000, 100000, 150000, 9999999 }; //판매 비용
        
        public bool sResult(int perC)
        {
            Random rand = new Random(); //랜덤 생성 변수 선언
            int percent = (int)rand.Next(1, 101); //1~100중 랜덤한 숫자 받아와서 정수형(Int)으로 변환한 값을 저장
            if(percent<=perC) //확률보다 숫자가 낮으면 강화 성공!
            {
                ++characterLevel; //강화 레벨 증가
                statusText.Text = characterLevel + "강"; //강화 레벨 텍스트 표현
                return true; //True값을 줘서 실행
            }
            else 
            { 
                characterLevel = 0; statusText.Text = "태초마을에 오신 것을 환영합니다."; return false;  //false값을 주면 이미지가 사라짐 그냥 일단 테스팅용
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
                statusText.Text = characterLevel + "강"; //강화 레벨 텍스트 출력
                itemQuan.Text = "아이템 : "+gameItem.ToString(); //아이템 개수 출력
                pictureBox1.Visible = true; //사진 보여지게 설정
            }
            StrcostText.Text = "강화 비용 : " + strCost[characterLevel];
            sellCostText.Text = "판매 비용 : " + sellCost[characterLevel];
        }

        private void button2_Click(object sender, EventArgs e) //판매 버튼 클릭시
        {
            if(characterLevel == 0) //강화하지 않았을 때. 즉, 강화 레벨이 0일때
            {
                MessageBox.Show("판매할 수 없는 강화 단계입니다."); //판매 불가 메시지 출력
            }
            else if(characterLevel == 1) //강화 레벨이 1일 때
            {
                gameMoney += sellCost[characterLevel-1]; //플레이어 재화 증가(판매 비용 획득)
                moneyQuan.Text = "돈 : " + gameMoney.ToString(); //재화 텍스트 출력
                characterLevel = 0; //판매 후 레벨 초기화
                statusText.Text = characterLevel + "강"; //강화 레벨 텍스트 출력
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. "); //판매 완료 메시지 출력
                
            }
            else if (characterLevel == 2) //강화 레벨이 2일 때.. 이하생략
            {
                gameMoney += sellCost[characterLevel - 1];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 3)
            {
                gameMoney += sellCost[characterLevel - 1];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 4)
            {
                gameMoney += sellCost[characterLevel - 1];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 5)
            {
                gameMoney += sellCost[characterLevel - 1];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 6)
            {
                gameMoney += sellCost[characterLevel - 1];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 7)
            {
                gameMoney += sellCost[characterLevel - 1];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 8)
            {
                gameMoney += sellCost[characterLevel - 1];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 9)
            {
                gameMoney += sellCost[characterLevel - 1];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 10)
            {
                gameMoney += sellCost[characterLevel - 1];
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
            StrcostText.Text = "강화 비용 : " + strCost[characterLevel];
            sellCostText.Text = "판매 비용 : " + sellCost[characterLevel];
        }
    }
}
