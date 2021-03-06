#define DIR 8
#define STEP 9
#define SCL A5
#define SDA A4

#include <Wire.h>
#include "SparkFun_VL53L1X.h"

SFEVL53L1X distanceSensor;

bool incommingMessage;
String stringValue;
bool clockwise;

void setup() { 
Wire.begin();
Serial.begin(9600);
//Serial.println("Start the program");

pinMode(DIR, OUTPUT);
pinMode(STEP, OUTPUT);
    
stringValue = "";
incommingMessage = false;
clockwise = false;
digitalWrite(DIR, LOW);

if (distanceSensor.begin() != 0) //Begin returns 0 on a good init
{
  Serial.println("Sensor failed to begin. Please check wiring. Freezing...");
  while (1);
}

distanceSensor.setTimingBudgetInMs(500);
distanceSensor.setIntermeasurementPeriod(100);
Serial.println(distanceSensor.getIntermeasurementPeriod());
}

void loop() {

  if(incommingMessage){
    parseMessage(stringValue);
    incommingMessage = false;
  }

  //String distance = measureDistance();
  //Serial.println(distance);
  //delay(500);
}


void parseMessage(String stringToParse){
  String commandString = stringToParse.substring(0,5);
  String stepsString = stringToParse.substring(6,11); 
  int stepsInt = stepsString.toInt();
  //Serial.println(stringToParse);
  //Serial.println(stepsInt);
  stringValue = "";
  
  if(commandString == "START"){
    startCommand();        
    String answer = stringToParse + "/DONE\n";
    Serial.print(answer);
  }
  else if(commandString == "CLK00"){
    commandCLK00(stepsInt);
    String answer = stringToParse + "/DONE\n";
    Serial.print(answer);    
  }
  else if(commandString == "MEASR"){
     String distance = measureDistance();
     String answer = commandString + "/" + distance + "/DONE\n";
     Serial.print(answer); 
  }
  else{
    //Serial.println("Unknown command");
  }
  incommingMessage = false;
}

void startCommand(){
  for(int i = 0; i <1600; i++){
  digitalWrite(STEP, HIGH);
  delayMicroseconds(1500);
  digitalWrite(STEP, LOW);
  delayMicroseconds(1500);
 }
}

void commandCLK00(int steps){
  for(int n = 0; n < steps; n++){
  digitalWrite(STEP, HIGH);
  delayMicroseconds(1500);
  digitalWrite(STEP, LOW);
  delayMicroseconds(1500);
  }
}

String measureDistance(){
   int distance = 0;
   int total = 0;
   for(int i = 0; i < 30; i++){
    distanceSensor.startRanging();
    while (!distanceSensor.checkForDataReady()){
      delay(1);
    }
    distance = distanceSensor.getDistance(); //Get the result of the measurement from the sensor
    total += distance;
    Serial.println(distance); 
    distanceSensor.clearInterrupt();
    distanceSensor.stopRanging();    
  }
  total = total / 20;
  if(total <= 9){
    return "00" + String(total);
  }
  else if(total >= 10 & total <= 99){
    return "0" + String(total);
  }
  else{
    return String(total);
  }
}

void serialEvent() {
  while (Serial.available()) {
    char inChar = (char)Serial.read();
    if (inChar == '\n') {
      incommingMessage = true;
      //Serial.println(incommingMessage);
    }
    else{
      stringValue += inChar;
    }
  }
}
