/*
AVR HVPP Configurator 2019-02-18
https://github.com/zsccat/HVPP-Configurator

by Shichang Zhuo

This project has includes all HVPP functions except flash and eeprom programming. 
All programming sequences are coming from ATMEL micro-controller datasheets.

It support all arduino compatible chips (28 pins DIP or 32 pins TQFP) which have at least 8K flash memory. (ATMEGA8, ATMEGA168, ATMEGA328)

The target chip need to be connected as follow:

Target Chip Pin | Target Chip Pin Function | Programmer Pin
PD1             | RDY/BSY(-)               | Not connect as not pin left for it
PD2             | OE(-)                    | 2
PD3             | WR(-)                    | 3
PD4             | BS1                      | 4
PD5             | XA0                      | 5
PD6             | XA1                      | 6
PD7             | PAGEL                    | 7
RST             | RST/+12V                 | A4 => Not directly connected, A4 will control a transistor to feed +12V to RST pin
PC2             | BS2                      | 8
XTAL1           | XTAL1                    | 9  
GND             | GND                      | GND
VCC             | VCC                      | A5
AVCC            | AVCC                     | A5
PC1             | DATA7                    | 10
PC0             | DATA6                    | 11
PB5             | DATA5                    | 12
PB4             | DATA4                    | 13
PB3             | DATA3                    | A0
PB2             | DATA2                    | A1
PB1             | DATA1                    | A2
PB0             | DATA0                    | A3 

The +12V can be supplied via a A23 battery or through a step-up module (MT3608) as what I have used.

It accept commands from serial port to perform required functions.

User menu:
In general, 2 digits command + parameters.
00 - Enable HVPP mode (You can use 001 as what have been specified in ATMEGA8 datasheet, but ATMEGA8 also works with 002 which is for ATMEGA48/88/168/328)
01 - Read signature
02 - Read fuses (LLHHEELC, LL-LFUSE HH-HFUSE EE-EXT_FUSE LC-LOCK_BYTE)
03 - Write low fuse (e.g. set LFuse to BF, use 03BF)
04 - Write high fuse (e.g. set HFuse to CC, use 04CC)
05 - Write extended fuse (e.g. set ExtFuse to E1, use 05E1)
06 - Write Lock byte
07 - Erase chip (Erase chip is the only way to remove lock byte)
08 - Read calibration byte
99 - End HVPP mode

Alternatively, you can use the HVPP programmer GUI I have created. (Built in .NET framework 4.0)
The GUI has included all these functions.

GNU Public License V3.0
*/
#define BAUD   57600 

#define OE     2
#define WR     3
#define BS1    4
#define XA0    5
#define XA1    6
#define PAGEL  7
#define BS2    8
#define XTAL1  9
#define RST    A4
#define VCC    A5
#define DATA7  10
#define DATA6  11
#define DATA5  12
#define DATA4  13
#define DATA3  A0
#define DATA2  A1
#define DATA1  A2
#define DATA0  A3

String inStr = ""; // Command and parameter received from serial port
int cmd = -1;      // Command number
int chip = -1;     // Chip mode (ATMEGA8/L or ATMEGA48/88/168/328)

void setup() {
  // Initialise all control pins
  pinMode(OE, OUTPUT);
  pinMode(WR, OUTPUT);
  pinMode(BS1, OUTPUT);
  pinMode(XA0, OUTPUT);
  pinMode(XA1, OUTPUT);
  pinMode(PAGEL, OUTPUT);
  pinMode(BS2, OUTPUT);
  pinMode(XTAL1, OUTPUT);
  pinMode(RST, OUTPUT);
  pinMode(VCC, OUTPUT);

  // Initialise all data pins
  pinMode(DATA0, INPUT);
  pinMode(DATA1, INPUT);
  pinMode(DATA2, INPUT);
  pinMode(DATA3, INPUT);
  pinMode(DATA4, INPUT);
  pinMode(DATA5, INPUT);
  pinMode(DATA6, INPUT);
  pinMode(DATA7, INPUT);

  // Power off the whole chip
  digitalWrite(RST, HIGH);
  digitalWrite(VCC, LOW);

  // Disable both READ and WRITE (OE and WR are negative enabled)
  digitalWrite(OE, HIGH);
  digitalWrite(WR, HIGH);
  
  Serial.begin(BAUD); // Start serial port communication
  delay(50);
}

void loop() 
{
  cmd = -1;    // Clear previous command
  inStr = "";  // Clear previous received command + parameters
  
  // Read command from Serial
  while (Serial.available() > 0)
  {
    inStr = Serial.readString();
  }

  // A command is received
  if (inStr != "")
  {
    cmd = inStr.substring(0, 2).toInt();  // Get the command from the string
    switch (cmd)
    {
      case 0: // Enter programming mode
        if (inStr.length() == 2)
          enter_programming_mode(2);
        else
          enter_programming_mode(inStr.substring(2,3).toInt());
        break;
      case 1: // Read signature
        read_signature();
        break;
      case 2: // Read fuse
        read_fuse();
        break;
      case 3: // Write low fuse
        write_fuse(hex8(inStr.substring(2,4)), 0, 0);
        break;
      case 4: // Write high fuse
        write_fuse(hex8(inStr.substring(2,4)), 1, 0);
        break;
      case 5: // Write ext fuse
        write_fuse(hex8(inStr.substring(2,4)), 0, 1);
        break;
      case 6: // Write lock byte
        write_lock();
        break;
      case 7: // Erase chip
        earse_chip();
        break;
      case 8: // Read calibration byte
        read_calibration();
        break;
      case 99: // End
        finish();
        break;
    }
  }
}

// 00 Enable HVPP
// Mode 1 is implemented the same way as in the datasheet. However, mode 2 can also get ATMEGA8 into HVPP mode.
// You may use Mode 2 only as it will work on all supported chips.
void enter_programming_mode(int mode)
{
  chip = mode;
  switch (mode)
  {
    case 1: //Atmega8
      digitalWrite(VCC, HIGH);     // Apply +5V VCC
      delayMicroseconds(200);      // Wait at least 100 us
      digitalWrite(RST, HIGH);     // Set RST to 0
      for (int i = 0; i < 8; ++i)
      {
        toggle_xtal();             // Toggle XTAL1 at least 6 times
        delay(1);
      }
      digitalWrite(PAGEL, LOW);    // Set Prog_eable to "0000"
      digitalWrite(XA1, LOW);
      digitalWrite(XA0, LOW);
      digitalWrite(BS1, LOW);
      //delayMicroseconds(1);        // Delay at least 100 ns
      delay(1);                    // Delay 1 ms
      digitalWrite(RST, LOW);      // Apply +12V to RESET
      break;

    case 2: //Atmega48/88/168/328
      digitalWrite(VCC, LOW);      // Set VCC to 0
      digitalWrite(RST, HIGH);     // Set RESET to 0
      digitalWrite(PAGEL, LOW);    // Set Prog_eable to "0000"
      digitalWrite(XA1, LOW);
      digitalWrite(XA0, LOW);
      digitalWrite(BS1, LOW);
      digitalWrite(VCC, HIGH);     // Apply +5V to VCC
      delayMicroseconds(50);       // Wait 20us to 60us
      digitalWrite(RST, LOW);      // Apply +12V to RESET
      break;
  }

  Serial.println("0");
}

// 01 Read signature
// All AVR chips have 3 bytes signature
void read_signature()
{
  byte val;
  val = read_signature_byte(0x00, 0); // Read byte 0
  if (val < 0x10)
    Serial.print('0');
  Serial.print(val, HEX);
  //Serial.print(' ');
  val = read_signature_byte(0x01, 0); // Read byte 1
  if (val < 0x10)
    Serial.print('0');
  Serial.print(val, HEX);
  //Serial.print(' ');
  val = read_signature_byte(0x02, 0); // Read byte 2
  if (val < 0x10)
    Serial.print('0');
  Serial.println(val, HEX);
}

// 02 Read fuses
void read_fuse()
{
  byte val;
  load_command(B00000100);     // Read fuse cmd
  digitalWrite(OE, LOW);  
  digitalWrite(BS2, LOW);
  digitalWrite(BS1, LOW);      // Low fuse
  val = read_data();
  if (val < 0x10)
    Serial.print('0');
  Serial.print(val, HEX);
  Serial.print(" ");
  digitalWrite(OE, LOW);  
  digitalWrite(BS2, HIGH);
  digitalWrite(BS1, HIGH);      // High fuse
  val = read_data();
  if (val < 0x10)
    Serial.print('0');
  Serial.print(val, HEX);
  Serial.print(" ");
  if (chip == 2)
  {
    digitalWrite(OE, LOW);  
    digitalWrite(BS2, HIGH);
    digitalWrite(BS1, LOW);      // Ext fuse
    val = read_data();
    if (val < 0x10)
      Serial.print('0');
    Serial.print(val, HEX);
    Serial.print(" ");
  }
  digitalWrite(OE, LOW);  
  digitalWrite(BS2, LOW);
  digitalWrite(BS1, HIGH);      // Lock fuse
  val = read_data();
  if (val < 0x10)
    Serial.print('0');
  Serial.println(val, HEX);
  digitalWrite(OE, HIGH);
}

// 03 04 05 Write fuse
void write_fuse(byte data, int bs1, int bs2)
{
  load_command(B01000000);     // Write fuse cmd
  load_data_low_byte(data);
  digitalWrite(BS1, bs1);
  digitalWrite(BS2, bs2);
  
  delay(1);                    // WR nagative pulse
  digitalWrite(WR, LOW);
  delay(1);
  digitalWrite(WR, HIGH);

  delay(5); // Not enough pins, delay 5 ms

  digitalWrite(BS1, LOW);
  digitalWrite(BS2, LOW);

  Serial.println("0");
}

// 06 Write lock
void write_lock()
{
  load_command(B00100000);     // Write fuse cmd
  load_address_low_byte(0x00); // Program lock

  delay(1);                    // WR nagative pulse
  digitalWrite(WR, LOW);
  delay(1);
  digitalWrite(WR, HIGH);

  delay(5); // Not enough pins, delay 5 ms
  
  Serial.println("0");
}

// 07 Earse chip
void earse_chip()
{
  load_command(B10000000);     // Earse chip command

  delay(1);                    // WR nagative pulse
  digitalWrite(WR, LOW);
  delay(1);
  digitalWrite(WR, HIGH);

  delay(10); // Not enough pins, delay 10 ms

  Serial.println("0");
}

// 08 Read calibration byte
void read_calibration()
{
  byte val = read_signature_byte(0x01, 1);
  if (val < 0x10)
    Serial.print('0');
  Serial.println(val, HEX);
}

// 99 End HVPP
void finish()
{
  digitalWrite(RST, HIGH);
  digitalWrite(VCC, LOW);
  Serial.println("0");
}

// Read 1 byte of chip signature 
byte read_signature_byte(byte addr, int bs1)
{
  load_command(B00001000);     // Read signature cmd
  load_address_low_byte(addr); // Load address low byte
  digitalWrite(OE, LOW);       // Enable read
  digitalWrite(BS1, bs1);      // Enable signature read
  byte val = read_data();
  digitalWrite(OE, HIGH);      // Disable read

  return val;
}

// Read data byte from data pins
byte read_data()
{
  pinMode(DATA0, INPUT); // Set pins as input
  pinMode(DATA1, INPUT);
  pinMode(DATA2, INPUT);
  pinMode(DATA3, INPUT);
  pinMode(DATA4, INPUT);
  pinMode(DATA5, INPUT);
  pinMode(DATA6, INPUT);
  pinMode(DATA7, INPUT);

  // Read bit by bit
  return digitalRead(DATA7) << 7 | 
         digitalRead(DATA6) << 6 |
         digitalRead(DATA5) << 5 |
         digitalRead(DATA4) << 4 |
         digitalRead(DATA3) << 3 |
         digitalRead(DATA2) << 2 |
         digitalRead(DATA1) << 1 |
         digitalRead(DATA0); 
}

// Toggle XTAL1 for a positive pulse
void toggle_xtal()
{
  delay(1);
  digitalWrite(XTAL1, HIGH);
  delay(1);
  digitalWrite(XTAL1, LOW);
}

// Toggle PAGEL for a positive pulse
void toggle_pagel()
{
  delay(1);
  digitalWrite(PAGEL, HIGH);
  delay(1);
  digitalWrite(PAGEL, LOW);
}

// Load HVPP command
void load_command(byte command)  // Send command to target AVR
{
  // Set controls for command mode
  digitalWrite(XA1, HIGH);
  digitalWrite(XA0, LOW);
  digitalWrite(BS1, LOW);

  set_data(command);
}

// Load address low byte
void load_address_low_byte(byte addr)  // Send command to target AVR
{
  // Set controls for command mode
  digitalWrite(XA1, LOW);
  digitalWrite(XA0, LOW);
  digitalWrite(BS1, LOW);
  
  set_data(addr);
}

// Load address high byte
void load_address_high_byte(byte addr)  // Send command to target AVR
{
  // Set controls for command mode
  digitalWrite(XA1, LOW);
  digitalWrite(XA0, LOW);
  digitalWrite(BS1, HIGH);
  
  set_data(addr);
}

// Load data low byte
void load_data_low_byte(byte data)  // Send command to target AVR
{
  // Set controls for command mode
  digitalWrite(XA1, LOW);
  digitalWrite(XA0, HIGH);
  
  set_data(data);
}

// Load data high byte
void load_data_high_byte(byte data)  // Send command to target AVR
{
  // Set controls for command mode
  digitalWrite(BS1, HIGH);
  digitalWrite(XA1, LOW);
  digitalWrite(XA0, HIGH);
  
  set_data(data);
}

// Set received data to data pins
void set_data(byte data)
{
  // Set data pins to the value of command;
  digitalWrite(DATA0, bitRead(data, 0));
  digitalWrite(DATA1, bitRead(data, 1));
  digitalWrite(DATA2, bitRead(data, 2));
  digitalWrite(DATA3, bitRead(data, 3));
  digitalWrite(DATA4, bitRead(data, 4));
  digitalWrite(DATA5, bitRead(data, 5));
  digitalWrite(DATA6, bitRead(data, 6));
  digitalWrite(DATA7, bitRead(data, 7));

  // Set all DATA lines to outputs
  pinMode(DATA0, OUTPUT);
  pinMode(DATA1, OUTPUT);
  pinMode(DATA2, OUTPUT);
  pinMode(DATA3, OUTPUT);
  pinMode(DATA4, OUTPUT);
  pinMode(DATA5, OUTPUT);
  pinMode(DATA6, OUTPUT);
  pinMode(DATA7, OUTPUT);

  toggle_xtal();  // latch DATA
}

// Convert HEX string back to byte
byte hex8(String in)
{
   uint8_t c, h;

   c = in[0];

   if (c <= '9' && c >= '0') {  c -= '0'; }
   else if (c <= 'f' && c >= 'a') { c -= ('a' - 0x0a); }
   else if (c <= 'F' && c >= 'A') { c -= ('A' - 0x0a); }
   else return(-1);

   h = c;

   c = in[1];

   if (c <= '9' && c >= '0') {  c -= '0'; }
   else if (c <= 'f' && c >= 'a') { c -= ('a' - 0x0a); }
   else if (c <= 'F' && c >= 'A') { c -= ('A' - 0x0a); }
   else return(-1);

   return ( h<<4 | c);
}
