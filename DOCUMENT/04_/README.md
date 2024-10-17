# 모듈 테스트

INPUT
---
> 입력받기 <br>

|-|
|-|
|![01 입력받기](https://github.com/EM-ORG-2023-12-27/09_EMBEDDED/assets/84259104/7a339c4d-0983-4444-9ec3-357b4431962a)|

```
int led[7] = {0,1,2,3,4,5,6};
void setup()
{
  Serial.begin(115200);
}

void loop()
{
  int num=0;
  if(Serial.available()){ 
   	char userInput = Serial.read();
   
    if (isdigit(userInput)) {  // 입력된 문자가 숫자인지 확인
      num = num * 10 + (userInput - '0');  // 숫자를 구성
    }
    switch(num)
    {
      case 2:
      	 digitalWrite(led[2],HIGH);
		 delay(10);
      	 break;
      case 3:
      	 digitalWrite(led[3],HIGH);
		 delay(10);
      	 break;
      case 4:
      	 digitalWrite(led[4],HIGH);
		 delay(10);
      	 break;    
      case 5:
      	 digitalWrite(led[5],HIGH);
		 delay(10);
      	 break;      
      case 6:
      	 digitalWrite(led[6],HIGH);
		 delay(10);
      	 break;       
    }
	 digitalWrite(led[num],LOW);
  }
}
```

> PUSH 버튼 <br>

|-|
|-|
|![02 PUSH 버튼](https://github.com/EM-ORG-2023-12-27/09_EMBEDDED/assets/84259104/588823be-9cfc-43b8-b8ee-2020c1e69ca7)|

```
const int Pin = 2;
void setup()
{
  Serial.begin(115200);
  pinMode(Pin,INPUT);
}

void loop()
{
   int val = digitalRead(Pin);
   Serial.println(val);
  
}
```

> PUSH버튼 + LED<br>

|-|
|-|
|![03 PUSH_LED](https://github.com/EM-ORG-2023-12-27/09_EMBEDDED/assets/84259104/3b6ca776-4136-4def-904c-9d4ebc281135)|

```
const int Button = 8;
const int Led = 2;
void setup()
{
 
  pinMode(Button,INPUT);
  pinMode(Led,OUTPUT);
}

void loop()
{
  
  digitalWrite(Led,LOW);	 
  int val = digitalRead(Button);
  Serial.println(val);
  if(val==HIGH)
  {
    digitalWrite(Led,HIGH);	   
  }
  
}
```

---
#
---

가변저항
---
>1 가변저항_LED<br>

|-|
|-|
|![04 가변저항_LED](https://github.com/EM-ORG-2023-12-27/09_EMBEDDED/assets/84259104/c24cb5d2-ec24-4e5d-96fd-1c563fdbf704)|

```
const int ledPin = 10;
const int analogPin = A0;

void setup()
{

}
void loop()
{
  int sensorInput = analogRead(analogPin);
  Serial.println(sensorInput);
  analogWrite(ledPin,sensorInput/4);
}
```

> <br>

|-|
|-|
|![05 가변저항_LED](https://github.com/EM-ORG-2023-12-27/09_EMBEDDED/assets/84259104/e2d85dc8-85f5-4a5a-a5a4-527e3283ec2d)|

```
const int led[4] = {3,5,6,9};
const int analogPin = A0;

void setup()
{
  for(int x=0;x<4;x++){
  	pinMode(led[x], OUTPUT);
  }
}

void loop()
{
 	int sensorInput = analogRead(analogPin);
  
  	if(sensorInput > 1024/7*(1+0))	//146
      digitalWrite(led[0],HIGH);
  	else digitalWrite(led[0],LOW);
  	
 	if(sensorInput > 1024/7*(1+1))	//292
      digitalWrite(led[1],HIGH);
  	else digitalWrite(led[1],LOW);  
  	
  	if(sensorInput > 1024/7*(1+2))	//438
      digitalWrite(led[2],HIGH);
  	else digitalWrite(led[2],LOW);
  	
  	if(sensorInput > 1024/7*(1+3))	//584
      digitalWrite(led[3],HIGH);
  	else digitalWrite(led[3],LOW);  
  
}
```



---
#
---
