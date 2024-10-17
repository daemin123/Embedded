# 아두이노 작업하기

실습 이미지
---
> LED 점등 <br>

![ArduinoLogic](https://github.com/MY-ALL-LECTURE/DREAM-LOAD/assets/84259104/7b8bcb72-3be7-4a6d-9a0e-f41e883bc3f7)

 
실습 코드
---
> 점등 제어 코드
```
const int ledPin = 13;
void setup() {
  Serial.begin(9600);
  pinMode(ledPin,OUTPUT);
}

void loop() {
  if(Serial.available()){
   	char inputVal = Serial.read();
    Serial.println(inputVal);
    if(inputVal == '1'){
      digitalWrite(ledPin,HIGH);
      Serial.println("LED:ON");
    }
    else if(inputVal == '0'){
      digitalWrite(ledPin,LOW);
      Serial.println("LED:OFF");
    }
  }
  delay(100);
}

```


# 웹서버 작업하기

웹페이지 코드
---
> src > main > resources > templates > arduino > index.html
```
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
</head>
<body>
<h1>INDEX</h1>
<fieldset style="width:200px;">
    <legend>CONNECTION</legend>
    <input class="com_port">
    <button class="conn_btn">CONN</button>
</fieldset>
<fieldSet style="width:200px;">
    <legend>LED</legend>
    <button class="led_on">LED ON</button>
    |
    <button class="led_off">LED OFF</button>
</fieldSet>

<!-- axios cdn -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/axios/1.5.0/axios.min.js" integrity="sha512-aoTNnqZcT8B4AmeCFmiSnDlc4Nj/KPaZyB5G7JnOnUEkdNpCZs1LCankiYi01sLTyWy+m2P+W4XM+BuQ3Q4/Dg==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
<script>
    const led_on_btn = document.querySelector('.led_on');
    const led_off_btn = document.querySelector('.led_off');

    const conn_btn = document.querySelector('.conn_btn');
    conn_btn.addEventListener('click',function(){

         const port = document.querySelector('.com_port').value;
         axios.get(`/arduino/connection/${port}`)
        .then(response=>{})
        .catch(error=>{});

    });


    led_on_btn.addEventListener('click',function(){

        axios.get('/arduino/led/1')
        .then(response=>{})
        .catch(error=>{});

    });
    led_off_btn.addEventListener('click',function(){
        axios.get('/arduino/led/0')
        .then(response=>{})
        .catch(error=>{});
    });

</script>

</body>
</html>
```


웹페이지 매핑
---
> src > main > java.com.example.demo.controller.ArduinoController
```
@Controller
@Slf4j
@RequestMapping("/arduino")
public class ArduinoController {

    @GetMapping("/index")
    public void index(){
        log.info("GET/arduino/index");
    }
}

```

웹페이지 확인
---
> Browser > http://localhost:8080/arduino/index <br>

![20240425002735](https://github.com/MY-ALL-LECTURE/DREAM-LOAD/assets/84259104/579be866-40a1-4cfc-9e97-e956a8697dce)





웹 점등제어 코드 구현[전체코드]
---
>  src > main > java.com.example.demo.restcontroller.ArduinoRestController
```
package com.example.demo.restcontroller;


import com.fazecast.jSerialComm.SerialPort;
import lombok.extern.slf4j.Slf4j;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.servlet.http.HttpServletRequest;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;

@RestController
@Slf4j
@RequestMapping("/arduino")
public class ArduinoRestController {

    private SerialPort serialPort;
    private OutputStream outputStream;
    private InputStream inputStream;

    @GetMapping("/connection/{COM}")
    public ResponseEntity<String> setConnection(@PathVariable("COM") String COM, HttpServletRequest request) {
        log.info("GET /arduino/connection " + COM  + " IP : " + request.getRemoteAddr());

        if(serialPort!=null){
            serialPort.closePort();
            serialPort=null;
        }

        //Port Setting
        serialPort = SerialPort.getCommPort(COM);

        //Connection Setting
        serialPort.setBaudRate(9600);
        serialPort.setNumDataBits(8);
        serialPort.setNumStopBits(0);
        serialPort.setParity(0);

        boolean isOpen =  serialPort.openPort();
        log.info("isOpen ? " + isOpen);

        if(isOpen){
            this.outputStream   = serialPort.getOutputStream();
            this.inputStream    = serialPort.getInputStream();

            return new ResponseEntity("CONNECTION SUCCESS..!", HttpStatus.OK);
        }
        else{
            return new ResponseEntity("CONNECTION FAIL..!", HttpStatus.BAD_GATEWAY);
        }
    }

    @GetMapping("/led/{value}")
    public void led_Control(@PathVariable String value, HttpServletRequest request) throws IOException {
        log.info("GET /arduino/led/value : " + value + " IP : " + request.getRemoteAddr());
        if(serialPort.isOpen()){
            outputStream.write(value.getBytes());
            outputStream.flush();
        }
    }

}

```

부분코드[속성]
---
> serialPort : 아두이노 COM PORT NO <br>
> outputStream : 출력 스트림 <br>
> inputStream : 입력 스트림 <br>
```
    private SerialPort serialPort;
    private OutputStream outputStream;
    private InputStream inputStream;
```

부분코드[기능]
---
> 아두이노와 웹서버와의 연결을 담당
```
   @GetMapping("/connection/{COM}")
    public ResponseEntity<String> setConnection(@PathVariable("COM") String COM, HttpServletRequest request) {
        log.info("GET /arduino/connection " + COM  + " IP : " + request.getRemoteAddr());

        if(serialPort!=null){
            serialPort.closePort();
            serialPort=null;
        }

        //Port Setting
        serialPort = SerialPort.getCommPort(COM);

        //Connection Setting
        serialPort.setBaudRate(9600);
        serialPort.setNumDataBits(8);
        serialPort.setNumStopBits(0);
        serialPort.setParity(0);

        boolean isOpen =  serialPort.openPort();
        log.info("isOpen ? " + isOpen);

        if(isOpen){
            this.outputStream   = serialPort.getOutputStream();
            this.inputStream    = serialPort.getInputStream();

            return new ResponseEntity("CONNECTION SUCCESS..!", HttpStatus.OK);
        }
        else{
            return new ResponseEntity("CONNECTION FAIL..!", HttpStatus.BAD_GATEWAY);
        }
    }

```

부분코드[기능]
---
> 웹서버 버튼 이벤트에 따른 아두이노 LED 점등 처리
```
    @GetMapping("/led/{value}")
    public void led_Control(@PathVariable String value, HttpServletRequest request) throws IOException {
        log.info("GET /arduino/led/value : " + value + " IP : " + request.getRemoteAddr());
        if(serialPort.isOpen()){
            outputStream.write(value.getBytes());
            outputStream.flush();
        }
    }
```

