#include "DHT11.h"

const int LED_RED = 4;
//const int LED_YELLOW = 7;

const int LDR = 16;
int ldrVal;

bool alarmMode = false;
bool tempAlarm = false;

bool lightIsOn = false;
signed long timeLightIsOn;

unsigned long lastTimeTempChecked = 0;

String line;

float temp;

void setup() {
  // put your setup code here, to run once:

  pinMode(LED_RED, OUTPUT);
  //pinMode(LED_YELLOW, OUTPUT);

  pinMode(LDR, INPUT);
  //pinMode(BUZZER, OUTPUT);


  Serial.begin(9600);
  
}

void loop() {
  ldrVal = analogRead(LDR);

  //check and send temperature every 5 seconds to the touch screen
  MonitorRoomTemperature();

}

void MonitorRoomTemperature() {
  if (millis() - lastTimeTempChecked >= 5000) {
    temp = DHT11.getTemperature();
    String msg = "Temp0" + String(temp);
    Serial.println(msg);
    lastTimeTempChecked = millis();
    //Check if temp is too high/low and turn on temperature alarm in that case
    
      if (temp < 16 || temp > 23) {
        //digitalWrite(LED_YELLOW, HIGH);
        tempAlarm = true;
        Serial.println("tempAlarm");
      }
    
  }
}
