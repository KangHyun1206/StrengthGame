using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
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
            InitializeGoogleSheetService();  // API 서비스 초기화
            InitializeSheetWithHeaders(); //시트 헤더 초기화
            InitializeTotalSheetWithHeaders(); //Total 시트 헤더 초기화
            PercentLabel.Text = "강화 확률 : " + strPer[characterLevel];
            // FormClosing 이벤트에 핸들러 추가
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            
        }
        private SheetsService service;
        private string ApplicationName = "Google Sheets API .NET TEST";
        private string spreadsheetId = "16nvo9gxFUO_oXqtMxViJhqHTc5epZsNbWX7rzzYx324";

        public string UserId;

        string dateOnly = DateTime.Today.ToString("yyyy-MM-dd");
        int loginNum = 1;
        int characterLevel = 0; //강화 레벨
        int gameMoney = 100000; //시작 금액
        int gameItem = 1; //굉장해엄청나 카드 수
        int gameItemPlus = 0;
        int orderNum = 0; //CSV 처리 번호
        int[] strCost = {100, 500, 1000, 2000, 5000, 7000, 15000, 30000, 50000, 100000, 0 }; //강화 비용
        int[] sellCost = {0, 50, 500, 1000, 3000, 15000, 50000, 100000, 150000, 300000, 9999999 }; //판매 비용
        string[] strPer = { "100", "99", "95", "90", "85", "80", "70", "50", "30", "10", "강화 끝!" };
        string[] alarmName = { "0강","1강", "2강", "3강", "4강", "5강", "6강", "7강", "8강", "9강", "10강", };
        string result;
        string resultD;
        string[] status = { "success", "failure" };
        string[] statusD = { "success", "-" };
        public bool sResult(int perC)
        {
            Random rand = new Random(); // 랜덤 생성 변수 선언
            int percent = (int)rand.Next(1, 101); // 1~100 중 랜덤한 숫자 받아와서 정수형(Int)으로 변환한 값을 저장
            if (percent <= perC) // 확률보다 숫자가 낮으면 강화 성공!
            {
                // 20%의 확률로 2단 강화
                if (characterLevel < 8 && percent <= 15)
                {
                    characterLevel += 2; // 강화 레벨 2단 증가
                    DoubleSCheck.Visible = true;
                }
                else
                {
                    ++characterLevel; // 강화 레벨 증가
                    DoubleSCheck.Visible = false;
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
                DoubleSCheck.Visible = false;
                characterLevel = 0;
                statusText.Text = characterLevel + "강";

                result = status[1];
                return false; // False값을 주면 이미지가 사라짐, 그냥 일단 테스팅용
            }
        }

        private void button1_Click(object sender, EventArgs e) //강화버튼 클릭시
        {
            DoubleSCheck.Visible = false;
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
                        if (sResult(100) == true)
                        {
                            pictureBox1.Image = Properties.Resources.s2;
                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.s1;
                        }
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
                        if (sResult(99) == true)
                        {
                            pictureBox1.Image = Properties.Resources.s3;
                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.s1;
                        }
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
                        if (sResult(95) == true)
                        {
                            pictureBox1.Image = Properties.Resources.s4;
                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.s1;
                        }
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
                        if (sResult(90) == true)
                        {
                            pictureBox1.Image = Properties.Resources.s5;
                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.s1;
                        }
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
                        if (sResult(85) == true)
                        {
                            pictureBox1.Image = Properties.Resources.s6;
                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.s1;
                        }
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
                        if (sResult(80) == true)
                        {
                            pictureBox1.Image = Properties.Resources.s7;
                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.s1;
                        }
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
                        if (sResult(70) == true)
                        {
                            pictureBox1.Image = Properties.Resources.s8;
                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.s1;
                        }
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
                        if (sResult(50) == true)
                        {
                            pictureBox1.Image = Properties.Resources.s9;
                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.s1;
                        }
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
                        if (sResult(30) == true)
                        {
                            pictureBox1.Image = Properties.Resources.s10;
                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.s1;
                        }
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
                        if (sResult(10) == true)
                        {
                            pictureBox1.Image = Properties.Resources.s11;
                        }
                        else
                        {
                            pictureBox1.Image = Properties.Resources.s1;
                        }
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
            itemQuan.Text = "굉장해 엄청나! : " + gameItem.ToString(); //남은 아이템 개수 출력
            StrcostText.Text = "강화 비용 : " + strCost[characterLevel];
            sellCostText.Text = "판매 비용 : " + sellCost[characterLevel];
            PercentLabel.Text = "강화 확률 : " +strPer[characterLevel];
            
        }

        private void btn_Item_Click(object sender, EventArgs e) //아이템(굉장히 엄청나) 사용 버튼 클릭시
        {
            DoubleSCheck.Visible = false;
            if (gameItem == 0) //아이템이 없을 때
            {
                MessageBox.Show("아이템이 없습니다!"); //사용 불가 메시지 출력
            }
            else if (characterLevel == 10)
            {
                MessageBox.Show("최고 강화 레벨입니다."); //강화 불가 메시지 출력(최고 레벨)
            }
            else //아이템이 있을 때
            {
                --gameItem; //아이템 수 감소
                ++characterLevel; //강화 레벨 증가
                WriteItemStrengthCsv();
                statusText.Text = characterLevel + "강"; //강화 레벨 텍스트 출력
                itemQuan.Text = "굉장해 엄청나! : "+gameItem.ToString(); //아이템 개수 출력
                pictureBox1.Visible = true; //사진 보여지게 설정
            }
            switch (characterLevel)
            {
                case 1: //1강 상태
                    pictureBox1.Image = Properties.Resources.s2;
                    break;
                    
                case 2: //2강 상태.. 이하생략
                    pictureBox1.Image = Properties.Resources.s3;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.s4;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources.s5;
                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources.s6;
                    break;
                case 6:
                    pictureBox1.Image = Properties.Resources.s7;
                    break;
                case 7:
                    pictureBox1.Image = Properties.Resources.s8;
                    break;
                case 8:
                    pictureBox1.Image = Properties.Resources.s9;
                    break;
                case 9:
                    pictureBox1.Image = Properties.Resources.s10;
                    break;
                case 10:
                    pictureBox1.Image = Properties.Resources.s11;

                    break;
            }
            StrcostText.Text = "강화 비용 : " + strCost[characterLevel];
            sellCostText.Text = "판매 비용 : " + sellCost[characterLevel];
            PercentLabel.Text = "강화 확률 : " + strPer[characterLevel];

        }

        private void button2_Click(object sender, EventArgs e) //판매 버튼 클릭시
        {
            DoubleSCheck.Visible = false;
            if (characterLevel == 0) //강화하지 않았을 때. 즉, 강화 레벨이 0일때
            {
                MessageBox.Show("판매할 수 없는 강화 단계입니다."); //판매 불가 메시지 출력
            }
            else if(characterLevel == 1) //강화 레벨이 1일 때
            {
                
                gameMoney += sellCost[characterLevel]; //플레이어 재화 증가(판매 비용 획득)
                moneyQuan.Text = "돈 : " + gameMoney.ToString(); //재화 텍스트 출력
                WriteSaleCsv();
                characterLevel = 0; //판매 후 레벨 초기화
                statusText.Text = characterLevel + "강"; //강화 레벨 텍스트 출력
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. "); //판매 완료 메시지 출력
                
            }
            else if (characterLevel == 2) //강화 레벨이 2일 때.. 이하생략
            {
                
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                WriteSaleCsv();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 3)
            {
                
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                WriteSaleCsv();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 4)
            {
                
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                WriteSaleCsv();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 5)
            {
                
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                WriteSaleCsv();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 6)
            {
                
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                WriteSaleCsv();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 7)
            {
                
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                WriteSaleCsv();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 8)
            {
                
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                WriteSaleCsv();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 9)
            {
                
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                WriteSaleCsv();
                characterLevel = 0;
                statusText.Text = characterLevel + "강";
                MessageBox.Show("캐릭터(" + characterLevel + ")를 판매하였습니다. ");

            }
            else if (characterLevel == 10)
            {
                
                gameMoney += sellCost[characterLevel];
                moneyQuan.Text = "돈 : " + gameMoney.ToString();
                WriteSaleCsv();
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
            LogDataToGoogleSheet("강화", resultD);
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
            LogDataToGoogleSheet("아이템 강화");

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
            LogDataToGoogleSheet("판매");
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


        private void InitializeGoogleSheetService()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("strengthgame-427db5002ebd.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(SheetsService.Scope.Spreadsheets);
            }

            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }
        private async void InitializeSheetWithHeaders()
        {
            try
            {
                var range = "DataSheet!A1:Z1";
                var valueRange = new ValueRange();
                var headers = new List<object>() { "No.", "아이디", "시간", "타입", "레벨", "잔금", "아이템 수", "강화 성공 여부", "2단 강화 여부" };
                valueRange.Values = new List<IList<object>> { headers };

                var request = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                await request.ExecuteAsync();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error initializing sheet headers: " + ex.Message);
            }
        }
        
        private async void LogDataToGoogleSheet(string actionType)
        {
            try
            {
                string range = "DataSheet!A2:Z";
                var valueRange = new ValueRange();
                var oblist = new List<object>() { orderNum.ToString(), UserId, DateTime.Now.ToString(), actionType, characterLevel.ToString(), gameMoney.ToString(), gameItem.ToString(), result.ToString(), "-" };
                valueRange.Values = new List<IList<object>> { oblist };

                var request = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, range);
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                await request.ExecuteAsync();  // 비동기 실행
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error logging to Google Sheets: " + ex.Message);
            }

        }
        private async void LogDataToGoogleSheet(string actionType, string statusG)
        {
            try
            {
                string range = "DataSheet!A2:Z";
                var valueRange = new ValueRange();
                var oblist = new List<object>() { orderNum.ToString(), UserId, DateTime.Now.ToString(), actionType, characterLevel.ToString(), gameMoney.ToString(), gameItem.ToString(), result.ToString(), statusG };
                valueRange.Values = new List<IList<object>> { oblist };

                var request = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, range);
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                await request.ExecuteAsync();  // 비동기 실행
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error logging to Google Sheets: " + ex.Message);
            }

        }
        private async void InitializeTotalSheetWithHeaders()
        {
            try
            {
                var range = "TotaluserdataSheet!A1:Z1"; // A1부터 E1까지의 범위 (5개 열)
                var valueRange = new ValueRange();
                var headers = new List<object>() { "아이디", "총 이벤트 수", "로그인 횟수", "최근 방문일", "재화 소모량", "아이템 사용 횟수", "일 방문 수", "평균 플레이 시간" };
                valueRange.Values = new List<IList<object>> { headers };

                var request = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
                request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                await request.ExecuteAsync();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error initializing sheet headers: " + ex.Message);
            }
        }
        private async Task<Dictionary<string, IList<object>>> ReadUserData(string spreadsheetId, string sheetName)
        {
            var userData = new Dictionary<string, IList<object>>();
            try
            {
                string range = $"{sheetName}!A:Z";  // A열부터 Z열까지 읽어옵니다.
                var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
                var response = await request.ExecuteAsync();

                if (response.Values != null)
                {
                    foreach (var row in response.Values)
                    {
                        if (row.Count > 0)
                        {
                            string userId = row[0].ToString(); // 가정: 첫 번째 열이 유저 ID
                            userData[userId] = row;
                        }
                    }
                }
                return userData;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Failed to read user data from spreadsheet: " + ex.Message);
                return null;
            }
        }
        private async void UpdateOrAppendUserData(string spreadsheetId, string sheetName, string userId, IList<object> newData)
        {
            var userData = await ReadUserData(spreadsheetId, sheetName);

            if (userData != null && userData.ContainsKey(userId))
            {
                // 유저 데이터 갱신
                string range = $"{sheetName}!A{userData.Keys.ToList().IndexOf(userId) + 1}:Z";  // 가정: 데이터가 A열부터 시작
                int currentEventCount = int.Parse(userData[userId][1].ToString()) + orderNum;
                int currentLoginCount = int.Parse(userData[userId][2].ToString()) + 1;  // 로그인 횟수는 세 번째 열에 저장되어 있다고 가정
                // 로그인 횟수를 증가시킵니다.
                newData[1] = currentEventCount.ToString();
                newData[2] = currentLoginCount.ToString();

                var valueRange = new ValueRange() { Values = new List<IList<object>> { newData } };
                var updateRequest = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
                updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                await updateRequest.ExecuteAsync();
                MessageBox.Show("User data updated.");
            }
            else
            {
                // 새 유저 데이터 추가
                // 첫 로그인이므로 로그인 횟수를 1로 설정
                newData[1] = orderNum.ToString();
                newData[2] = "1";  // 로그인 횟수 초기값 설정
                string appendRange = $"{sheetName}!A:Z";
                var valueRange = new ValueRange() { Values = new List<IList<object>> { newData } };
                var appendRequest = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, appendRange);
                appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                await appendRequest.ExecuteAsync();
                MessageBox.Show("User data added.");
            }
        }
        private  void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 폼이 닫힐 때 로그 기록
            List<object> userData = new List<object> { UserId, orderNum.ToString(), loginNum, dateOnly};
            UpdateOrAppendUserData(spreadsheetId, "TotaluserdataSheet", UserId, userData);
        }
    }
}
