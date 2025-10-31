using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // 파일스트림
using System.Windows.Forms; // OpenFileDialog
using System.Runtime; // Trim

namespace IniProgram
{
    public partial class Test : Form
    {
        // < 변수 모음 >
        string filePath; // 파일경로 (다양한 함수에서 써야하니 전역으로 둔다)
        int lineCount; // 파일이 총 몇줄인지 카운트

        // 파싱한걸 담을 변수들
        string allFile; // 데이터를 전체 담을 배열

        string[] data; // 한줄씩 담을 배열

        char section; // 섹션을 저장하는 변수
        char key; // 키를 저장하는 변수
        char value; // 값을 저장하는 변수

        List<char> sections; // char형 리스트 배열 (동적할당)
        List<char> keys;
        List<char> values;

        string stringSection = "";
        string stringKey = "";
        string stringValue;

        string mainValue; // 유저가 고른 Value

        int keyIndex = new int();

        //

        public Test()
        {
            InitializeComponent();
        }


        // [ 1. 파일열기 ] //////////////////////////////////////////////////////////////////////////
        private void btn_open_Click(object sender, EventArgs e)
        {
            // sender = 이벤트를 보내는 객체
            // e = 이벤트 핸들러가 사용하는 파라미터
            // 이벤트 핸들러를 추가하는 가장 간단한 방식 = 더블클릭

            OpenFileDialog ofd = new OpenFileDialog(); // 파일 대화상자 객체 생성

            if (ofd.ShowDialog() == DialogResult.OK) // ofd가 대화상자를 띄움
            {
                filePath = ofd.FileName; // 경로를 저장하는 변수에 파일명 저장
                //MessageBox.Show("선택한 파일: " + filePath);
            }

            allFile = readFile();

            tb_allFile.Text = allFile; // ui에 파일내용 띄우기

            pasingFile(filePath, allFile); // 파일 읽었으니까 이제 파싱


        }

        // [파일읽기]
        private string readFile()
        {
            allFile = File.ReadAllText(filePath); // 변수에 파일내용 다 넣기
            lineCount = File.ReadAllLines(filePath).Length; // 파일이 몇줄인지

            return allFile;
        }

        // [ 2. 파싱하기 ] //////////////////////////////////////////////////////////////////////////
        private void pasingFile(string filePath, string allFile)
        {
            //Console.WriteLine($"(전)allFile=" + '\n'  + allFile); // 현재 담은 데이터 찍어보기 (뭐들어있나)

            // 인스턴스 생성 (메모리 할당)
            sections = new List<char>();
            keys = new List<char>(); 
            values = new List<char>();

            string[] data = allFile.Split('\n'); //한줄씩 배열에 저장(인덱스로 꺼내쓰기

            // 본격 파싱 조건문
            for (int i=0; i<lineCount; i++) // 줄수만큼 반복 (한줄한줄 읽기)
            {
                data[i].Trim(); // 한줄씩 앞뒤 공백 제거
                data[i].Replace(" ", " "); // 한줄씩 개행있으면 제거

                if (string.IsNullOrWhiteSpace(data[i])) // 빈줄 제거 시도
                {
                    continue;
                }

                // (1). 섹션 파싱
                if (data[i][0] == '[') // [ 로 시작하는 줄이면 섹션임
                {
                    section = data[i][1]; // 섹션의 경우 [0],[1],[2] 중 [1]만 추출
                    //Console.WriteLine("추출한 섹션값: " + section);
                    sections.Add(section); // 섹션 리스트에 추가
                }

                else
                {
                    // (2). 키,값 파싱
                    //if (data[i][1] == '=' && data[i][0] != ' ') // 가운데에 = 이 있고, 첫번째가 공백이 아님
                    if (data[i][1] == '=') // 가운데에 = 이 있음
                    {
                        key = data[i][0]; // = 앞에가 키
                        keys.Add(key);

                        value = data[i][2]; // = 뒤에가 값
                        values.Add(value);

                        //Console.WriteLine("추출한 키/값: " + key + '/' + value);

                    }
                }
            }

            // char형 리스트를 string으로 변환
            stringSection = string.Join("", sections);
            stringKey = string.Join("", keys);
            stringValue = string.Join("", values);
            //tb_section.Text = stringSection;

            // 굳이 ui에 각각 띄울 필요 없을 것 같음
            // 원하는 값 수정하는거 바로 하면 될듯
        }

        // [ 3. 수정하기 ] //////////////////////////////////////////////////////////////////////////
        // 1.섹션을 입력한다.
        // 2.키를 입력한다.
        // 3.유효하면 밸류값이 나온다.
        // 4.밸류값을 수정한다.
        // 5.성공하면 성공했다고 메세지박스

        // ~~~ 섹션 입력창에 값이 들어왔을 때 ~~~
        private void tb_section_TextChanged(object sender, EventArgs e)
        {
            string userInputSection = tb_section.Text; // 유저가 검색한 섹션값 저장
            string userInputKey = tb_key.Text;

            verifySection(userInputSection);  // 1. 섹션 검사
            //tb_key_TextChanged(sender, e); // 2. 키 검사
        }
        // feed: 섹션이 바뀌면 섹션만 검사해라. 키까지 검사하지말고. 

        private void verifySection(string userInputSection) // Value 수정 전, 섹션&키 유효한지 검사하는 함수
        {

            if (stringSection.Contains(userInputSection) != true) // 섹션 거르기
            {
                MessageBox.Show("해당 섹션은 존재하지 않습니다.");
            }
        }

        // ~~~ 키 입력창에 값이 들어왔을 때 ~~~
        private void tb_key_TextChanged(object sender, EventArgs e)
        {
            //tb_value.Clear();

            string userInputSection = tb_section.Text;
            string userInputKey = tb_key.Text;

            Console.WriteLine($"key 입력 들어옴({tb_key.Text})");
            verifyKey(userInputKey);

            keyIndex = showValue(userInputSection, userInputKey, allFile);

        }


        private void verifyKey(string userInputKey)
        {
            if (stringKey.Contains(userInputKey) != true) // 키 거르기
            {
                MessageBox.Show("해당 Key는 존재하지 않습니다.");
            }
        }


        // 유저가 입력한 섹션&key로 value 찾기
        private int showValue(string userInputSection, string userInputKey, string allFile)
        {
            // 존재한다면? 밸류값 띄우기
            // A 섹션의 1번 Key의 값은 a 이다.
            // 키의 인덱스와 같은 인덱스를 가진 밸류값을 찾으면 됨
            // 아 근데 이거 어떤 섹션인지 어떻게 구분하지?
            // 클래스를 만들어야하나?
            // 일단 유저가 입력한 섹션의 인덱스번호에 +1,+2,+3을 해서 찾자
            // ini 데이터를 한줄씩 담은 배열 = data
            // 유저가 입력한 섹션이 data에서 몇번째 인덱스인지 찾자

            allFile = readFile();
            data = allFile.Split('\n'); //한줄씩 배열에 저장(인덱스로 꺼내쓰기

            Console.WriteLine($"showValue 들어왔나?");

            // 인덱스번호 저장할 변수들
            int userSectionIndex = new int();
            int userKeyIndex = new int();
            char userValue = new char(); // 나중에 수정하려면 저장해둬야하니 변수 생성

            // [섹션의 인덱스 찾기]
            for (int i = 0; i < data.Length+1; i++) // Value를 찾으려면 특정 인덱스를 찾아야하니 for문..
            {
                if (data[i].Contains(userInputSection)) // i번 데이터에 유저가 입력한 세션이 들어있는지?
                {
                    userSectionIndex = i; // 인덱스번호 저장
                    Console.WriteLine($"섹션 인덱스: {userSectionIndex}");
                    break; // 저장 후 바로 탈출 
                }
            }
            Console.WriteLine($"유저가 입력한 Key: {tb_key.Text}");

            // [키의 인덱스]
            for (int i = userSectionIndex+1; i < userSectionIndex+4; i++) // 섹션 다음으로 3쌍의 키/값이 있음
            {
                string mainKey = data[i][0].ToString(); // i번 데이터의 0번째 글자 = key

                if (mainKey == userInputKey) // 섹션과 같은 인덱스의 key와 유저가 입력한 key가 같으면
                {
                    userKeyIndex = i;
                    Console.WriteLine($"Key 인덱스: {userKeyIndex}");

                    userValue = data[i][2];
                    //Console.WriteLine($"해당 Value값: {userValue}");

                    string mainValues = userValue.ToString(); // string화

                    //break;
                }
                //break; 브레이크 끄니까 된다!!!!!!!!!

            }
            
            Console.WriteLine($"최종 Value: {userValue}");
            tb_value.Text = userValue.ToString(); // ui에 value 띄우기 > 아니 왜 여기서 터짐 ?????

            return userKeyIndex; // 나중에 밸류 수정하려면 인덱스 필요하니까 반환
        }


        // Value 수정하기.. 10/31
        private void tb_value_TextChanged(object sender, EventArgs e)
        {
            mainValue = tb_value.Text; // 유저가 입력한 value값 저장
            //modifyValue(); // 지금 이 함수 이상함..
        }

        private void modifyValue() // Value 수정하는 함수
        {
            Console.WriteLine($"modify함수 들어왔나?");
            // 섹션,키는 고정이니까 저장할 필요없고
            // 밸류값만 저장하면 되겠다.
            // 수정된 벨류값을 저장할 변수

            string modifydValues = tb_value.Text;

            // 어차피 위에서 밸류 위치 찾으니까, 이거 재활용하자
            // 그게 userKeyIndex 임 (어차피 key랑 value랑 같은 위치니까) 
            // showValue 함수에서 userKeyIndex를 반환하도록 바꾸자 = retrun int

            int userKeyIndex = showValue(tb_section.Text, tb_key.Text, allFile); // 키 인덱스 값 가져오기

            allFile = readFile();
            data = allFile.Split('\n'); //한줄씩 배열에 저장(인덱스로 꺼내쓰기

            Console.WriteLine($"수정할 인덱스: {userKeyIndex}");
            Console.WriteLine($"수정할 값: {modifydValues}");


        }

        // 4. 저장하기 //////////////////////////////////////////////////////////////////////////
        private void btn_save_Click(object sender, EventArgs e)
        {
            stringValue = tb_value.Text; // 유저가 수정한 value값 저장
            Console.WriteLine($"저장할 값: {stringValue}");

            saveFile(filePath, stringValue);
        }


        private void saveFile(string filePath, string stringValue)
        {
            data = allFile.Split('\n');

            // 수정
            data[keyIndex] = data[keyIndex].Replace(data[keyIndex][2], stringValue[0]);
            data[keyIndex] = data[keyIndex];
            //data[keyIndex].Replace(data[keyIndex][2], stringValue[0]);

            Console.WriteLine($"기존 값: {data[keyIndex][2]}");
            Console.WriteLine($"저장된 값: {stringValue[0]}");
            Console.WriteLine($"수정된 data: {data[keyIndex]}");

            allFile = string.Join("\n", data); // 다시 전체 파일로 합치기
            Console.WriteLine($"수정된 allFile: {allFile}");

            tb_allFile.Text = allFile; // ui에 수정된 파일내용 띄우기

            StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine(allFile);
            sw.Close();

            MessageBox.Show("파일이 저장되었습니다.");

            // ExternalProcess.Start(); // 이거
        }


        private void clearAll()
        {
            tb_section.Clear();
            tb_key.Clear();
            tb_value.Clear();
        }


        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
