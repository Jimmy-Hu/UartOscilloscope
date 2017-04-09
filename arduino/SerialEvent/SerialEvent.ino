void setup() {
  // initialize serial:
  Serial.begin(9600);
}

void loop()
{
  Serial.print("X");
  Serial.print(analogRead(A0)); 
  Serial.print("Y");
  Serial.print(analogRead(A1));
  Serial.print("Z");
  Serial.print(analogRead(A2));  
}
