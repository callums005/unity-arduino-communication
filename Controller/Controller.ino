void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(2, OUTPUT);
  pinMode(3, INPUT);
}

const int BUFFER_SIZE = 50;
char buf[BUFFER_SIZE];

void loop() {
  // put your main code here, to run repeatedly:

  // Reading in data from the game project

  if (Serial.available() > 0) {
    int len = Serial.readBytes(buf, BUFFER_SIZE);

    if (buf[0] == '0') {
      digitalWrite(2, LOW);  
    }
    else if (buf[0] == '1') {
      digitalWrite(2, HIGH);  
    }
  }

  // Sending data to the game project

  Serial.println(digitalRead(3));

  delay(200);
}
