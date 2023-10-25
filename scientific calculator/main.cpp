#include <iostream>
#include <array>
#include <cmath>
#include <string> 
#include <algorithm>
#include <sstream>
#include <vector>

using namespace std;

enum InputType
{
    Degrees,
    Radians,
    Grads
};

enum Mode {
    Normal,
    Debug
};

vector<double> History;
Mode MD;
double pi = 3.1415926535897932384626433832795;

double Plus(double first, double second) {
    double result = first + second;
    if (MD == Debug) cout << first << " + " << second << " = " << result << "\n";
    return result;
}

double Min(double first, double second) {
    double result = first - second;
    if (MD == Debug) cout << first << " - " << second << " = " << result << "\n";
    return result;
}

double Mul(double first, double second) {
    double result = first * second;
    if (MD == Debug) cout << first << " * " << second << " = " << result << "\n";
    return result;
}

double Div(double first, double second) {
    double result = first / second;
    if (MD == Debug) cout << first << " / " << second << " = " << result << "\n";
    return result;
}

double Int(double Value) { // 정수화
    double result = floor(Value);
    if (MD == Debug) cout << Value << " 정수화 완료. 결과값 : " << result << "\n";
    return result;
}

double Dms(double Value) { // 도분초
    double result;
    double degree, arcminute = 0, arcsecond;
    degree = floor(Value); // 도
    if (MD == Debug) cout << Value << "의 도 연산 완료. 결과값 : " << degree << "\n";
    double A = (Value - degree) * 60;
    int B = 0;
    while (A > 1) { // 분각 분리
        A--;
        arcminute++;
    }
    arcminute *= 0.01; // 분각
    if (MD == Debug) cout << Value << "의 분각 연산 완료. 결과값 : " << arcminute << "\n";
    arcsecond = A * 0.6;
    arcsecond *= 0.01; // 초각
    if (MD == Debug) cout << Value << "의 초각 연산 완료. 결과값 : " << arcsecond << "\n";
    result = degree + arcminute + arcsecond;
    if (MD == Debug) cout << Value << "이상의 값 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double Deg(double Value) { // 호도법
    double result;
    double degree1, degree2 = 0, degree3 = 0;
    degree1 = floor(Value); // 도
    if (MD == Debug) cout << Value << "의 도 연산완료. 결과값 : " << degree1 << "\n";
    double A = Value - degree1;
    cout << A;
    while (A > 0.01) {
        A-= 0.01;
        degree2++;
    }
    degree2 = degree2 / 60;
    if (MD == Debug) cout << Value << "의 분각을 도로 변환완료. 결과값 : " << degree2 << "\n";
    while (A > 0.0001) {
        A -= 0.0001;
        degree3++;
    }
    degree3 = degree3 / 3600;
    if (MD == Debug) cout << Value << "의 초각을 도로 변환완료. 결과값 : " << degree3 << "\n";
    result = degree1 + degree2 + degree3;
    if (MD == Debug) cout << Value << "이상의 값 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double PI() { // 파이
    if (MD == Debug) cout << "현재 값을 PI값으로 변환 완료\n";
    return pi;
}

bool F_E(double Value, bool E) { // 숫자 출력방식 변경
    bool e;
    if (E) {
        if (MD == Debug) cout << "출력 방식 일반 방식으로 변경\n";
        cout.setf(ios::fixed,ios::floatfield);
        cout.unsetf(ios::fixed);
        e = false;
    }
    else {
        if (MD == Debug) cout << "출력 방식 지수 표기법으로 변경\n";
        cout.setf(ios::scientific, ios::floatfield);
        e = true;
    }
    return e;
}

double ChangeDegrees(double Value, InputType It) { // 현재 숫자를 Degree로 변경
    double result;
    if (It == Radians) {
        result = Value * (180 / pi);
        if (MD == Debug) cout << "Radians 값을 Degrees값으로 변환 완료. 결과값 : " << result << "\n";
    }
    else if(It == Grads) {
        result = Value / 10;
        result *= 9;
        if (MD == Debug) cout << "Grads 값을 Degrees값으로 변환 완료. 결과값 : " << result << "\n";
    }
    else {
        return Value;
        if (MD == Debug) cout << "이미 Degrees값이므로 변환 X\n";
    }
    return result;
}

double ChangeRadians(double Value, InputType It) { // 현재 숫자를 Radians로 변경
    double result;
    if (It == Grads) {
        Value = ChangeDegrees(Value, It);
        It = Degrees;
        if (MD == Debug) cout << "Grads 값을 Radians값으로 변환 완료. 결과값 : " << Value << "\n";
    }
    if (It == Degrees) {
        result = Value * (pi / 180);
        if (MD == Debug) cout << "Degrees 값을 Radians값으로 변환 완료. 결과값 : " << result << "\n";
    }
    else {
        if (MD == Debug) cout << "이미 Radians값이므로 변환 X\n";
        return Value;
    }
    return result;
}

double ChangeGrads(double Value, InputType It) { // 현재 숫자를 Gradians로 변경
    double result;
    if (It == Radians) {
        Value = ChangeDegrees(Value, It);
        It = Degrees;
        if (MD == Debug) cout << "Radians 값을 Grads값으로 변환 완료. 결과값 : " << Value << "\n";
    }
    if (It == Degrees) {
        result = Value / 9;
        result *= 10;
        if (MD == Debug) cout << "Degrees 값을 Grads값으로 변환 완료. 결과값 : " << result << "\n";
    }
    else {
        if (MD == Debug) cout << "이미 Grads값이므로 변환 X\n";
        return Value;
    }
    return result;
}

double Sin(double Value, InputType It) { // 삼각함수 sin
    if (It != Radians) { // 값을 radians로 바꿈
        Value = ChangeRadians(Value, It);
    }
    double result = sin(Value);
    if (MD == Debug) cout << Value << "값으로 Sin 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double Cos(double Value, InputType It) { // 삼각함수 cos
    if (It != Radians) { // 값을 radians로 바꿈
        Value = ChangeRadians(Value, It);
    }
    double result = cos(Value);
    if (MD == Debug) cout << Value << "값으로 Cos 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double Tan(double Value, InputType It) { // 삼각함수 tan
    if (It != Radians) { // 값을 radians로 바꿈
        Value = ChangeRadians(Value, It);
    }
    double result = tan(Value);
    if (MD == Debug) cout << Value << "값으로 Tan 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double Sinh(double Value) { // 삼각함수 sinh
    double result = sinh(Value);
    if (MD == Debug) cout << Value << "값으로 Sinh 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double Cosh(double Value) { // 삼각함수 cosh
    double result = cosh(Value);
    if (MD == Debug) cout << Value << "값으로 Cosh 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double Tanh(double Value) { // 삼각함수 tanh
    double result = tanh(Value);
    if (MD == Debug) cout << Value << "값으로 Tanh 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double Asin(double Value, InputType It) { // 역함수 asin
    double result = asin(Value);
    if (MD == Debug) cout << Value << "값으로 aSin 연산 완료. 결과값 : " << result << "\n";
    if (It == Degrees) {
        result = ChangeDegrees(result, Radians);
    }
    else if (It == Grads) {
        result = ChangeGrads(result, Radians);
    }
    return result;
}

double Acos(double Value, InputType It) { // 역함수 acos
    double result = acos(Value);
    if (MD == Debug) cout << Value << "값으로 aCos 연산 완료. 결과값 : " << result << "\n";
    if (It == Degrees) {
        result = ChangeDegrees(result, Radians);
    }
    else if (It == Grads) {
        result = ChangeGrads(result, Radians);
    }
    return result;
}

double Atan(double Value, InputType It) { // 역함수 atan
    double result = atan(Value);
    if (MD == Debug) cout << Value << "값으로 aTan 연산 완료. 결과값 : " << result << "\n";
    if (It == Degrees) {
        result = ChangeDegrees(result, Radians);
    }
    else if (It == Grads) {
        result = ChangeGrads(result, Radians);
    }
    return result;
}

double Asinh(double Value) {// 역함수 asinh
    double result = asinh(Value);
    if (MD == Debug) cout << Value << "값으로 aSinh 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double Acosh(double Value) { // 역함수 acosh
    double result = acosh(Value);
    if (MD == Debug) cout << Value << "값으로 aCosh 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double Atanh(double Value) { // 역함수 atanh
    double result = atanh(Value);
    if (MD == Debug) cout << Value << "값으로 aTanh 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double Log(double Value) { // 자연로그 계산
    double result = log(Value);
    if (MD == Debug) cout << Value << "값으로 자연로그 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double Log10(double Value) { // 상용로그 계산
    double result = log10(Value);
    if (MD == Debug) cout << Value << "값으로 상용로그 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double Exp(double Value) {
    double result = exp(Value);
    if (MD == Debug) cout << Value << "값으로 지수 함수 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double Frac(double Value) {
    while (Value > 1) {
        Value -= 1;
    }
    double result = Value;
    if (MD == Debug) cout << Value << "값의 정수부분 제거 완료. 결과값 : " << result << "\n";
    return result;
}

double Mod(double first, int second) {
    double result = first / second;
    if (MD == Debug) cout << first << "값을" << second << "로 나눈 나머지 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double Square(double first, int second) {
    double Value = first;
    double result = first;
    for (int i = 1; i < second; i++) {
        result *= Value;
    }
    if (second == 0) result = 1;
    if (second == 0 && first == 0) result = 0;
    if (MD == Debug) cout << first << "의 " << second << "제곱 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double Factorial(int Value) {
    double result = Value;
    for (int i = Value-1; i > 0; i--) {
        result *= i;
    }
    if (MD == Debug) cout << Value << "의 팩토리얼 연산 완료. 결과값 : " << result << "\n";
    return result;
}

double Sqrt(double Value) {
    double result = sqrt(Value);
    if (MD == Debug) cout << Value << "의 제곱근 연산 완료. 결과값 : " << result << "\n";
    return result;
}

Mode ModeChange(Mode md) {
    Mode a;
    if (md == Normal) {
        a = Debug;
        cout << "디버그 모드로 변경";
    } 
    else {
        a = Normal;
        cout << "일반 모드로 변경";
    } 
    return a;
}

void ClearHistory() {
    if (!History.empty())
    {
        History.clear();
    }
    if (MD == Debug) cout <<"히스토리 초기화 완료.\n";
}

double BeforeHistory() {
    double result = 0;
    if (!History.empty()) result = History[History.size()-2];
    if (MD == Debug) cout << "최근 값 동기화 완료.\n";
    return result;
}

void ViewHistory() {
    for (int i = 0; i < History.size(); i++) {
        cout << i << ". " << History[i] << "\n";
    }
    if (MD == Debug) cout << "히스토리 출력 완료.\n";
}

double GetHistory() {
    ViewHistory();
    if (MD == Debug) cout << "몇번째 히스토리를 .\n";
    cout << "몇번째 히스토리를 가져올까요?.\n";
    int ip; // 입력값 저장 string
    cin >> ip; // 값 입력
    return History[ip];
}

void Help() {
    cout << "\n\n-----------------------------------------------------------------------------------------------------------------------\n";
    cout << " \n현재 값 : 현재 값은 숫자를 입력하여 변경이 가능합니다. 연산결과는 자동으로 현재 값으로 반영됩니다. \n";
    cout << " 사칙연산을 제외한 커맨드들은 한 번에 한 번씩 대소문자를 구분하여 입력합니다.\n\n";
    cout << " || <커멘드 이름> : 설명 ||\n\n";
    cout << " plus or + : 더하기 || min or - : 빼기 || div or / : 나누기 || mul or * : 곱하기\n\n";
    cout << " int : 정수화 || dms : 도분초 || e : 숫자 출력 방식 변경 || degrees : degrees로 입력모드 변경\n\n";
    cout << " radians : radians로 입력모드 변경 || grads : grads로 입력모드 변경 || sin : Sin 연산 || cos : Cos 연산\n\n";
    cout << " tan : Tan 연산 || sinh : Sinh 연산 || cosh : Cosh 연산 || tanh : Tanh 연산 || log : 자연로그 연산\n\n";
    cout << " log10 : 상용로그 연산 || asin : aSin 연산 || acos : aCos 연산 || atan : aTan 연산 || asinh : aSinh 연산\n\n";
    cout << " acosh : aCosh 연산 || atanh : aTanh 연산 || exp : 지수함수 연산 || frac : 정수 부분 제거 || 2pi : 현재 값을 2pi로 변경\n\n";
    cout << " pi : 현재 값을 pi로 변경 || deg : 호도법 || mod : 나머지 연산 || square2 : 현재 값 2제곱 || square3 : 현재 값 3제곱\n\n";
    cout << " squarey : 현재 값을 지정한 값만큼 제곱 || tensquare : 10을 현재 값만큼 제곱 || factorial : 현재 값의 팩토리얼 연산\n\n";
    cout << " mc : 메모리 값 삭제 || mr : 현재 값에 메모리 값을 붙여넣기 || ms : 현재 값을 메모리 값에 저장\n\n";
    cout << " m+ : 메모리 값을 양수로 변경 || m- : 메모리 값을 음수로 변경 || negate : 현재 값의 부호를 반대로 변경\n\n";
    cout << " sqrt : 현재 값의 제곱근 연산 || reciproc : 현재 값의 분수값 연산 || cm : 일반모드 / 디버그모드 전환\n\n";
    cout << " ch : 모든 히스토리를 삭제 || bh : 직전 값 불러오기 || vh : 히스토리 보기 || gh : 특정 히스토리 불러오기\n\n";
    cout << "-----------------------------------------------------------------------------------------------------------------------\n";
}

void main()
{
    cout.precision(15); // 소수점 아래 15자리까지 표시
    double Now_Value = 0; // 현재
    double Saved_Value = 0; // 세이브 메모리
    bool E = false;
    InputType IT = Degrees; // 현재 입력 타입
    MD = Normal;
    bool is_start = true;
    cout << "문제해결능력 과제로 만든 공학용 계산기입니다.\n";
    while (true)
    {
        string Input; // 입력값 저장 string
        string Type;
        if (IT == Degrees) Type = "Degrees";
        else if (IT == Radians) Type = "Radians";
        else if (IT == Grads) Type = "Grads";
        cout << "\n현재 값 : " << Now_Value << "\n";
        cout << "현재 입력 모드 : " << Type << "\n";
        cout << "\n커맨드, 식, 혹은 입력하고싶은 숫자를 입력하세요." << "\n";
        cout << "커맨드는 '도움말' 또는 'help'라고 입력하시면 조회가 가능합니다." << "\n";
        cin >> Input; // 값 입력
        stringstream ss(Input);
        string tok;
        while (getline(ss, tok, ' ')) {
            if (tok == "int") {
                Now_Value = Int(Now_Value);
            }
            else if (tok == "dms") {
                Now_Value = Dms(Now_Value);
            }
            else if (tok == "e") {
                E = F_E(Now_Value, E);
            }
            else if (tok == "degrees") {
                Now_Value = ChangeDegrees(Now_Value, IT);
                IT = Degrees;
            }
            else if (tok == "radians") {
                Now_Value = ChangeRadians(Now_Value, IT);
                IT = Radians;
            }
            else if (tok == "grads") {
                Now_Value = ChangeGrads(Now_Value, IT);
                IT = Grads;
            }
            else if (tok == "sin") {
                Now_Value = Sin(Now_Value, IT);
            }
            else if (tok == "cos") {
                Now_Value = Cos(Now_Value, IT);
            }
            else if (tok == "tan") {
                Now_Value = Tan(Now_Value, IT);
            }
            else if (tok == "sinh") {
                Now_Value = Sinh(Now_Value);
            }
            else if (tok == "cosh") {
                Now_Value = Cosh(Now_Value);
            }
            else if (tok == "tanh") {
                Now_Value = Tanh(Now_Value);
            }
            else if (tok == "log") {
                Now_Value = Log(Now_Value);
            }
            else if (tok == "log10") {
                Now_Value = Log10(Now_Value);
            }
            else if (tok == "asin") {
                Now_Value = Asin(Now_Value, IT);
            }
            else if (tok == "acos") {
                Now_Value = Acos(Now_Value, IT);
            }
            else if (tok == "atan") {
                Now_Value = Atan(Now_Value, IT);
            }
            else if (tok == "asinh") {
                Now_Value = Asinh(Now_Value);
            }
            else if (tok == "acosh") {
                Now_Value = Acosh(Now_Value);
            }
            else if (tok == "atanh") {
                Now_Value = Atanh(Now_Value);
            }
            else if (tok == "exp") {
                Now_Value = Exp(Now_Value);
            }
            else if (tok == "frac") {
                Now_Value = Frac(Now_Value);
            }
            else if (tok == "2pi") {
                Now_Value = 2 * pi;
            }
            else if (tok == "pi") {
                Now_Value = pi;
            }
            else if (tok == "deg") {
                Now_Value = Deg(Now_Value);
            }
            else if (tok == "mod") {
                Now_Value = Mod(Now_Value, 2);
            }
            else if (tok == "square2") {
                Now_Value = Square(Now_Value, 2);
            }
            else if (tok == "squarey") {
                cout << "제곱할 값을 입력하세요.\n";
                string input;
                cin >> input; // 값 입력
                int i = stoi(input);
                Now_Value = Square(Now_Value, i);
            }
            else if (tok == "square3") {
                Now_Value = Square(Now_Value, 3);
            }
            else if (tok == "tensquare") {
                Now_Value = Square(10, Now_Value);
            }
            else if (tok == "factorial") {
                Now_Value = Factorial(Now_Value);
            }
            else if (tok == "mc") {
                Saved_Value = 0;
                if (MD == Debug) cout << "메모리 값 0으로 초기화.\n";
            }
            else if (tok == "mr") {
                Now_Value = Saved_Value;
                if (MD == Debug) cout << "메모리 값을 불러옴. 결과값 : " << Saved_Value << "\n";
            }
            else if (tok == "ms") {
                Saved_Value = Now_Value;
                if (MD == Debug) cout << "현재 값을 메모리 값에 저장.\n";
            }
            else if (tok == "m-") {
                if (Saved_Value > 0) Saved_Value *= -1;
                if (MD == Debug) cout << "메모리 값을 음수로 변경. 결과값 : " << Saved_Value << ".\n";
            }
            else if (tok == "m+") {
                if (Saved_Value < 0) Saved_Value *= -1;
                if (MD == Debug) cout << "메모리 값을 양수로 변경. 결과값 : " << Saved_Value << ".\n";
            }
            else if (tok == "negate") {
                Now_Value *= -1;
                if (MD == Debug) cout << "현재 값의 부호를 반대로 변경. 결과값 : " << Now_Value << ".\n";
            }
            else if (tok == "sqrt") {
                Now_Value = Sqrt(Now_Value);
            }
            else if (tok == "reciproc") {
                Now_Value = 1 / Now_Value;
                if (MD == Debug) cout << "현재 값의 분수값 연산 완료 결과값 : " << Now_Value << ".\n";
            }
            else if (tok == "cm") {
                MD = ModeChange(MD);
            }
            else if (tok == "ch") {
                ClearHistory();
                is_start = true;
            }
            else if (tok == "bh") {
                Now_Value = BeforeHistory();
            }
            else if (tok == "vh") {
                ViewHistory();
            }
            else if (tok == "gh") {
                Now_Value = GetHistory();
            }
            else if (tok == "plus" || tok == "+") {
                cout << "더할 값을 입력하세요.\n";
                string input;
                cin >> input; // 값 입력
                double i = stod(input);
                Now_Value = Plus(Now_Value, i);
            }
            else if (tok == "min" || tok == "-") {
                cout << "뺄 값을 입력하세요.\n";
                string input;
                cin >> input; // 값 입력
                double i = stod(input);
                Now_Value = Min(Now_Value, i);
            }
            else if (tok == "mul" || tok == "*") {
                cout << "곱할 값을 입력하세요.\n";
                string input;
                cin >> input; // 값 입력
                double i = stod(input);
                Now_Value = Mul(Now_Value, i);
            }
            else if (tok == "div" || tok == "/") {
                cout << "나눌 값을 입력하세요.\n";
                string input;
                cin >> input; // 값 입력
                double i = stod(input);
                Now_Value = Div(Now_Value, i);
            }
            else if (tok == "도움말" || tok == "help") {
                Help();
            }
            else
                Now_Value = stod(tok);
        }
        if (is_start) {
            History.push_back(Now_Value);
            is_start = false;
        }
        else if (History.back() != Now_Value) History.push_back(Now_Value);
    }
}
