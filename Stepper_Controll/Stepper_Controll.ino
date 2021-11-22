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
  String stepsString = stringToParse.substring(7,11); 
  int stepsInt = stepsString.toInt();
  //Serial.println(stringToParse);
  //Serial.println(stepsInt);
  stringValue = "";
  
  if(commandString == "START"){
    startCommand();        
    String answer = stringToParse + "/DONE\n";
    Serial.print(answer);
  }
    
  else if(commandString == "LEFT0"){

    String answer = stringToParse + "/DONE\n";
    Serial.print(answer); 
    
  }
  
  else if(commandString == "RIGHT"){

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
  delayMicroseconds(400);
  digitalWrite(STEP, LOW);
  delayMicroseconds(400);
 }
}

void commandLeft(int steps){
  
}
void commandRight(int steps){
  
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
