# EMBEDDED

INDEX
---
|NAME|LINK|
|-|-|
|**IT기본개념**|[바로가기](DOCUMENT/01_)|-|-|
|**아두이노 우노 실습 환경 만들기**|[바로가기](DOCUMENT/02_)|-|-|
|**아두이노 우노 기본 실습**|[바로가기](DOCUMENT/03_)|-|-|
|**아두이노 우노 모듈 실습[버튼/가변저항]**|[바로가기](DOCUMENT/04_)|-|-|
|**아두이노 우노 모듈 실습[센서]**|[바로가기](DOCUMENT/05_)|-|-|
|**아두이노 우노 모듈 실습[부저(TONE)]**|[바로가기](DOCUMENT/06_)|-|-|
|**아두이노 우노 모듈 실습[LCD_DISPLAY]**|[바로가기](DOCUMENT/07_)|-|-|
|-|-|-|-|
|C# 기본|[바로가기]()|-|-|
|C# 컨트롤(콤보박스)|[바로가기]()|-|-|
|C# 컨트롤(텍스트박스)|[바로가기]()|-|-|
|C# SERIAL 통신|[바로가기]()|-|-|
|C# SERIAL 통신_LED점등 제어|[바로가기]()|-|-|
|-|-|-|-|
|Arduino_C#_SB 연결_01|[바로가기]()|-|-|
|Arduino_C#_SB 연결_02|[바로가기](DOCUMENT/_)|-|-|
|-|-|-|-|
|아두이노 웹 연결|[바로가기](DOCUMENT/15_)|-|-|


---
# C# SERIAL 통신 Control
---
> 회로도<br>

|-|
|-|
|![20240528162450](https://github.com/MY-ALL-LECTURE/EMBEDDED/assets/84259104/634e0a2d-8e50-4c43-b0cc-584e8a5d32f3)|

> 아두이노 코드<br>
```
//LED
const int ledPin = 10;
//조도센서
const int sunPin = A1;
//온도
float temp;
//초음파
const int trig_pin=11;
const int echo_pin=12;


void setup() {
  Serial.begin(9600);
  pinMode(ledPin,OUTPUT);
  //초음파
  pinMode(trig_pin,OUTPUT);
  pinMode(echo_pin,INPUT);

}
void loop() {

  if(Serial.available()){
    char inputVal = Serial.read();
    if(inputVal=='1'){
      digitalWrite(ledPin,HIGH);
      Serial.println("LED:ON");
    }else if(inputVal=='0'){
      digitalWrite(ledPin,LOW);
      Serial.println("LED:OFF");
    }
  }
  //조도
  int sunValue = analogRead(A1);
  Serial.print("SUN:");
  Serial.println(sunValue);
  if(sunValue>800){
    digitalWrite(ledPin,HIGH);
    Serial.println("LED:ON");
  }else{
     digitalWrite(ledPin,LOW);
     Serial.println("LED:OFF");   
  }
  //온도
  int val = analogRead(A0);
  temp = val*0.48828125; //화씨->섭씨 변경
  Serial.print("TEMP:");
  Serial.println(temp);

  //초음파
  digitalWrite(trig_pin,LOW); //초음파 OUT 신호 초기화
  delayMicroseconds(2);       //2 마이크로 초 동안 대기
  digitalWrite(trig_pin,HIGH);//초음파 OUT 발사
  delayMicroseconds(10);      //10 마이크로 초 동안 대기
  digitalWrite(trig_pin,LOW); //초음파 OUT 신호 종료

  long duration = pulseIn(echo_pin,HIGH); //에코핀에서 초음파가 반사되어 돌아오는 시간 측정(HIGH값이 유지되는시간을통한 측정)
  long distance = (duration/2)/29.1;      //측정된 이동 시간을 거리로 반환(초당 초음파의 이동 거리 : 약 29.1cm)

  Serial.print("DIS:");
  Serial.println(distance);
  if(distance<5){ //거리가 5cm 보다 작으면
    digitalWrite(ledPin,HIGH);
    Serial.println("LED:ON");
  }

  delay(500);
}



```

> C# 프로젝트명<br>
```
03_SERIAL_PORT_CONTROLL
```
















