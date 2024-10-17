//LED
const int ledPin = 10;
char inputVal = 0;
//온도
float temp;
//조도
const int lightPin = A1;
//초음파
const int trig_pin = 11;
const int echo_pin = 12;
void setup() {
  Serial.begin(9600);
  pinMode(ledPin,OUTPUT);
  //초음파
  pinMode(trig_pin , OUTPUT);
  pinMode(echo_pin,INPUT);
}

void loop() {
  if(Serial.available()){
   	inputVal = Serial.read();
    if(inputVal == '1'){
      digitalWrite(ledPin,HIGH);
      Serial.print("LED:");
      Serial.print("ON");
      Serial.print("_");
     }
    else if(inputVal == '0'){
      digitalWrite(ledPin,LOW);
      Serial.print("LED:");
      Serial.print("OFF");
      Serial.print("_");
      
    }
  }
  //온도
  int val = analogRead(A0);
  temp = val*0.48828125;
  Serial.print("TMP:");
  Serial.print(temp);
  Serial.print("_");
  
  //조도
  int lightValue = analogRead(lightPin);
  Serial.print("LIGHT:");
  Serial.print(lightValue);
  Serial.print("_");
  
  //초음파
  digitalWrite(trig_pin,LOW);
  delayMicroseconds(2);
  digitalWrite(trig_pin,HIGH);
  delayMicroseconds(10);
  digitalWrite(trig_pin,LOW);

  long duration = pulseIn(echo_pin,HIGH);
  long distance = (duration/2)/29.1;

  Serial.print("DIS:");
  Serial.println(distance);


  delay(500);


}