/*	Arduino硬體感測器端傳送程式
	Author：Jimmy HU
	This program is licensed under Apache License 2.0.
*/

void setup() 
{
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
