#define DIR 8
#define STEP 9

bool incommingMessage;
String stringValue;
bool clockwise;

void setup() { 
Serial.begin(9600);
 //Serial.println("Start the program");

pinMode(DIR, OUTPUT);
pinMode(STEP, OUTPUT);
    
 stringValue = "";
 incommingMessage = false;
 clockwise = false;
 digitalWrite(DIR, LOW);
}

void loop() {

  if(incommingMessage){
    parseMessage(stringValue);
    incommingMessage = false;
  }
  
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
  
  else if(commandString == "CTCLK"){
    commandCTCLK(stepsInt);
    String answer = stringToParse + "/DONE\n";
    Serial.print(answer); 
  }
  
  else if(commandString == "HOME0"){

    String answer = stringToParse + "/DONE\n";
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
  delayMicroseconds(1000);
  digitalWrite(STEP, LOW);
  delayMicroseconds(1000);
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
void commandCTCLK(int steps){
  for(int n = 0; n < steps; n++){
  digitalWrite(STEP, HIGH);
  delayMicroseconds(1500);
  digitalWrite(STEP, LOW);
  delayMicroseconds(1500);
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
