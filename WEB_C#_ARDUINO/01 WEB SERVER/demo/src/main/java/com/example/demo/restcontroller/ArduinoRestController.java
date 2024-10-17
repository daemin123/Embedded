package com.example.demo.restcontroller;


import com.fazecast.jSerialComm.SerialPort;
import jakarta.servlet.http.HttpServletRequest;
import lombok.extern.slf4j.Slf4j;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;


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
    public void led_Control(@PathVariable("value") String value, HttpServletRequest request) throws IOException {
        log.info("GET /arduino/led/value : " + value + " IP : " + request.getRemoteAddr());
        if(serialPort.isOpen()){
            outputStream.write(value.getBytes());
            outputStream.flush();
        }
    }

}
