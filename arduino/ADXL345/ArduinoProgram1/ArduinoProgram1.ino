/*	 Arduino硬體感測器端傳送程式
 *	 Author：Jimmy HU
 *	 This program is licensed under Apache License 2.0.
 *	 電路連接說明：
 *	---關於GY-80加速度計---
 *	GY-80 SCL －＞ Arduino Analog Pin A5
 *	GY-80 SDA －＞ Arduino Analog Pin A4
 *	Original Code Reference：https://github.com/cedtat/GY-80-sensor-samples/blob/master/adxl345/adxl345.ino
 *	3 Axis Accelerometer(Analog Devices ADXL345) Datasheet：http://www.analog.com/media/en/technical-documentation/data-sheets/ADXL345.pdf
 *	Arduino連接G-sensor，傳輸控制上Arduino為Master端，G-sensor為slave端
 *	
 */
//---引用函式庫---
#include <Wire.h>																		//	加入Wire.h函式庫
//---定義常數---
#define Register_ID 0																	//	定義Register_ID常數數值為0
#define GY80_Acc_reg_pwrctrl 0x2D														//	定義GY80_Acc_reg_pwrctrl(加速度計POWER_CTL暫存器位址)常數為0x2D
#define Register_X0 0x32																//	定義Register_X0常數數值為0x32
#define Register_X1 0x33																//	定義Register_X1常數數值為0x33
#define Register_Y0 0x34																//	定義Register_Y0常數數值為0x34
#define Register_Y1 0x35																//	定義Register_Y1常數數值為0x35
#define Register_Z0 0x36																//	定義Register_Z0常數數值為0x36
#define Register_Z1 0x37																//	定義Register_Z1常數數值為0x37
//***全域變數宣告區***
/* 硬體上3 Axis Accelerometer(Analog Devices ADXL345)位址為0x53，轉換至10進位為83，故指定ADXL345_Address數值為83(十進位)
 */
int ADXL345_Address = 83;																//	宣告ADXL345_Address整數變數初始數值為83
double Acc_X,Acc_Y,Acc_Z;																//	宣告X、Y、Z方向加速度數值(以g為單位，1g=9.8m/s)
double Acc_X_array[10],Acc_Y_array[10],Acc_Z_array[10];									//	宣告Acc_X_array[10],Acc_Y_array[10],Acc_Z_array[10]陣列變數，記錄最近十筆X、Y、Z方向加速度數值(以g為單位，1g=9.8m/s)
int Acc_X0,Acc_X1,Acc_X_16bit;															//	宣告Acc_X0(加速度計X方向低位元暫存變數),Acc_X1(加速度計X方向高位元暫存變數),Acc_X_16bit(加速度計X方向16位元完整感測資料輸出變數)
int Acc_Y0,Acc_Y1,Acc_Y_16bit;															//	宣告Acc_Y0(加速度計Y方向低位元暫存變數),Acc_Y1(加速度計Y方向高位元暫存變數),Acc_Y_16bit(加速度計Y方向16位元完整感測資料輸出變數)
int Acc_Z1,Acc_Z0,Acc_Z_16bit;															//	宣告Acc_Z1(加速度計Z方向低位元暫存變數),Acc_Z0(加速度計Z方向高位元暫存變數),Acc_Z_16bit(加速度計Z方向16位元完整感測資料輸出變數)

//***副程式宣告區***
void Read_ADXL345_Data(void);															//	宣告Read_ADXL345_Data(讀取ADXL345資料)副程式
void SerialPrintADX345Data(void);														//	宣告SerialPrintADX345Data(顯示ADXL345數值)副程式
void SerialPrintUIntData(unsigned int);													//	宣告SerialPrintUIntData副程式
void SerialPrintIntData(int);															//	宣告SerialPrintIntData副程式
// the setup function runs once when you press reset or power the board
// setup程式於按下reset按鈕或通電時執行一次
void setup()																			//	setup程式
{																						//	進入setup程式
	//***設定接腳狀態***
	pinMode(13, OUTPUT);																//	設定數位接腳13為輸出
	pinMode(8, INPUT);																	//	設定數位接腳8為輸入
	Wire.begin();																		//	加入I2C串列傳輸匯流排 
	Serial.begin(9600);																	//	開啟 Serial Port，鮑率為 9600bps (Bits Per Second)
	delay(100);																			//	延遲0.1秒
	//***開始測量G sensor資料***
	Wire.beginTransmission(ADXL345_Address);											//	開始對Slave(從端)進行資料傳輸
	//	Wire.beginTransmission(address)函數可參考https://www.arduino.cc/en/Reference/WireBeginTransmission
	Wire.write(GY80_Acc_reg_pwrctrl);													//	傳送暫存器位址0x2D(GY80_Acc_reg_pwrctrl數值)
	Wire.write(8);																		//	設定POWER_CTL暫存器Measure Bit為1
	Wire.endTransmission();																//	I2C傳送結束
}																						//	結束setup程式

// the loop function runs over and over again forever
// loop程式將不斷重複執行
void loop()																				//	loop程式
{																						//	進入loop程式
	Read_ADXL345_Data();																//	呼叫Read_ADXL345_Data副程式
	SerialPrintADX345Data();															//	呼叫SerialPrintADX345Data副程式
	delay(500);
}																						//	結束loop程式

void Read_ADXL345_Data(void)															//	Read_ADXL345_Data(讀取ADXL345資料)副程式
{																						//	進入Read_ADXL345_Data(讀取ADXL345資料)副程式
	//---讀取X方向加速度值---
	Wire.beginTransmission(ADXL345_Address);											//	傳送資料至Slave(從端)
	Wire.write(Register_X0);															//	準備讀取X方向加速度值
	Wire.write(Register_X1);															//	準備讀取X方向加速度值
	Wire.endTransmission();																//	I2C傳送結束
	Wire.requestFrom(ADXL345_Address,2);												//	傳送2位元組要求至Slave端(ADXL345_Address)
	if(Wire.available()<=2)																//	若slave(ADXL345_Address)裝置回傳資料少於要求資料量
	{																					//	進入if敘述
		Acc_X0 = Wire.read();															//	讀取X方向加速度值(低8位元)
		Acc_X1 = Wire.read();															//	讀取X方向加速度值(高8位元)
		Acc_X1=Acc_X1<<8;																//	將Acc_X1(高8位元)左移8位
		Acc_X_16bit=Acc_X0+Acc_X1;														//	將X1與X0組合為16位元的X方向加速度數值填入X_out
	}																					//	結束if敘述
	//---讀取Y方向加速度值---
	Wire.beginTransmission(ADXL345_Address);											//	傳送資料至Slave(從端)
	Wire.write(Register_Y0);															//	準備讀取Y方向加速度值
	Wire.write(Register_Y1);															//	準備讀取Y方向加速度值
	Wire.endTransmission();																															 //	I2C傳送結束
	Wire.requestFrom(ADXL345_Address,2);																									//	傳送2位元組要求至Slave端(ADXL345_Address)
	if(Wire.available()<=2)																															 //	若slave(ADXL345_Address)裝置回傳資料少於要求資料量
	{																																										 //	進入if敘述
		Acc_Y0 = Wire.read();																															 //	讀取Y方向加速度值(低8位元)
		Acc_Y1 = Wire.read();																															 //	讀取Y方向加速度值(高8位元)
		Acc_Y1=Acc_Y1<<8;																																	 //	將Acc_Y1(高8位元)左移8位
		Acc_Y_16bit=Acc_Y0+Acc_Y1;																													//	將Y1與Y0組合為16位元的Y方向加速度數值填入Acc_Y_16bit
	}																																										 //	結束if敘述
	//---讀取Z方向加速度值---
	Wire.beginTransmission(ADXL345_Address);																							//	傳送資料至Slave(從端)
	Wire.write(Register_Z0);																															//	準備讀取Z方向加速度值
	Wire.write(Register_Z1);																															//	準備讀取Z方向加速度值
	Wire.endTransmission();																															 //	I2C傳送結束
	Wire.requestFrom(ADXL345_Address,2);																									//	傳送2位元組要求至Slave端(ADXL345_Address)
	if(Wire.available()<=2)																															 //	若slave(ADXL345_Address)裝置回傳資料少於要求資料量
	{																																										 //	進入if敘述
		Acc_Z0 = Wire.read();																															 //	讀取Z方向加速度值(低8位元)
		Acc_Z1 = Wire.read();																															 //	讀取Z方向加速度值(高8位元)
		Acc_Z1=Acc_Z1<<8;																																	 //	將Acc_Z1(高8位元)左移8位
		Acc_Z_16bit=Acc_Z0+Acc_Z1;																													//	將Z1與Z0組合為16位元的Z方向加速度數值填入Acc_Z_16bit
	}																																										 //	結束if敘述
	//---正規化加速度數值---
	Acc_X=Acc_X_16bit/256.0;
	Acc_Y=Acc_Y_16bit/256.0;
	Acc_Z=Acc_Z_16bit/256.0;
	//---記錄數值---
	int loop_number = 0;																																	//	宣告loop_number區域變數供迴圈使用
	for(loop_number = 10; loop_number > 0; loop_number--)																 //	以for迴圈搬移Acc_X_array、Acc_Y_array、Acc_Z_array陣列歷史資料
	{																																										 //	進入for迴圈
		Acc_X_array[loop_number]=Acc_X_array[loop_number-1];																//	搬移Acc_X_array歷史資料
		Acc_Y_array[loop_number]=Acc_Y_array[loop_number-1];																//	搬移Acc_Y_array歷史資料
		Acc_Z_array[loop_number]=Acc_Z_array[loop_number-1];																//	搬移Acc_Z_array歷史資料
	}																																										 //	結束for迴圈
	Acc_X_array[0]=Acc_X;																																 //	將Acc_X填入Acc_X_array陣列中
	Acc_Y_array[0]=Acc_Y;																																 //	將Acc_Y填入Acc_Y_array陣列中
	Acc_Z_array[0]=Acc_Z;																																 //	將Acc_Z填入Acc_Z_array陣列中
}																																											 //	結束Read_ADXL345_Data(讀取ADXL345資料)副程式

void SerialPrintADX345Data(void)																												//	SerialPrintADX345Data(顯示ADXL345數值)副程式
{																						//	進入SerialPrintADX345Data(顯示ADXL345數值)副程式
	//---輸出ADXL345數值至UART介面---
	Serial.print("X");
	SerialPrintUIntData(Acc_X * 2048 + 2048);
	//Serial.print("			 ");
	//Serial.print("Y");
	//SerialPrintUIntData(Acc_Y * 2048 + 2048);
	//Serial.print("			 ");
	//Serial.print("Z");
	//SerialPrintUIntData(Acc_Z * 2048 + 2048);
	//Serial.println("	");
	Serial.println();
}																																											 //	結束SerialPrintADX345Data(顯示ADXL345數值)副程式

void SerialPrintUIntData(unsigned int InputData)													//	SerialPrintIntData(SerialPort送出int型態資料)副程式
{																						//	進入SerialPrintIntData(SerialPort送出int型態資料)副程式
	Serial.print( ( InputData / 10000 ) % 10 );
	Serial.print( ( InputData / 1000 ) % 10 );
	Serial.print( ( InputData / 100 ) % 10 );
	Serial.print( ( InputData / 10 ) % 10 );
	Serial.print( ( InputData / 1 ) % 10 );
}																						//	結束SerialPrintIntData(SerialPort送出int型態資料)副程式

void SerialPrintIntData(int InputData)													//	SerialPrintIntData(SerialPort送出int型態資料)副程式
{																						//	進入SerialPrintIntData(SerialPort送出int型態資料)副程式
	Serial.print( ( InputData / 10000 ) % 10 );
	Serial.print( ( InputData / 1000 ) % 10 );
	Serial.print( ( InputData / 100 ) % 10 );
	Serial.print( ( InputData / 10 ) % 10 );
	Serial.print( ( InputData / 1 ) % 10 );
}																						//	結束SerialPrintIntData(SerialPort送出int型態資料)副程式


