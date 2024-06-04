#include "DHT11.h"
const int POTENTIOMETER = A0;
const int RED_LED = 4;
const int GREEN_LED = 5;
const int BLUE_LED = 6;
const int YELLOW_LED = 7;
const int PIN_KEY1 = 8;
const int PIN_KEY2 = 9;
const int LDR = A2;

int val;
int temperature;
int light;

const int TRESHOLD_HIGH = 600;
const int TRESHOLD_LOW = 350;

int buttonState1 = 0;
int lastButtonState1 = 0;

int buttonState2 = 0;
int lastButtonState2 = 0;

unsigned long lasttimeRedLed;
unsigned long lasttimeBlueLed;
unsigned long lasttimeGreenLed;

const int BLINK_INTERVAL = 1000;

bool ledstateRedLed = false;
bool ledstateBlueLed = false;
bool ledstateGreenLed = false;

bool turnLeft = false;
bool turnRight = false;

int yellowLedState;
int oldYellowLedState;

bool hazard = false;
String command;

unsigned long timer = millis();

void setup() {
  // put your setup code here, to run once:
  pinMode(PIN_KEY1, INPUT_PULLUP);
  pinMode(PIN_KEY2, INPUT_PULLUP);
  pinMode(LDR, INPUT);
  pinMode(RED_LED, OUTPUT);
  pinMode(GREEN_LED, OUTPUT);
  pinMode(BLUE_LED, OUTPUT);
  pinMode(YELLOW_LED, OUTPUT);
  pinMode(POTENTIOMETER, INPUT);

  lasttimeRedLed = millis();
  lasttimeBlueLed = millis();
  lasttimeGreenLed = millis();

  Serial.begin(9600);
}

void loop() {
  if (hazard == false)
  {
    blinker();
  }
  button1();
  button2();
  headlights();
  hazardButton();
  alarm();
  fetchTemperature();
}
//method for blinking the leds
//and mimicking the car wheel with the potentiometer
void blinker()
{
  val = analogRead(POTENTIOMETER);
  int scale = map(val, 0, 1023, 0, 100);

  if (scale >= 0 && scale <= 40)
  {
    turnRight = false;
    digitalWrite (GREEN_LED, LOW);

    if (turnLeft == true)
    {
      blinkBlueLed();

    }
  }
  //this if is created as a dead zone for the wheel
  if (scale > 40 && scale < 60)
  {
    if (turnLeft == true)
    {
      blinkBlueLed();
    }
    if (turnRight == true)
    {
      blinkGreenLed();
    }
  }

  else if (scale >= 60 && scale <= 100)
  {
    turnLeft = false;
    digitalWrite(BLUE_LED, LOW);

    if (turnRight == true)
    {
      blinkGreenLed();

    }
  }
}

void headlights()
{
  light = analogRead(LDR);

  if (light <= TRESHOLD_LOW)
  {
    digitalWrite(YELLOW_LED, HIGH);
  }
  else if (light >= TRESHOLD_HIGH)
  {
    digitalWrite(YELLOW_LED, LOW);
  }

  //here we carefully read the state of the yellow led
  //and make sure that we only print the value once
  //as to not flood the serial port
  yellowLedState = digitalRead(YELLOW_LED);

  if (yellowLedState != oldYellowLedState)
  {
    yellowLedState = digitalRead(YELLOW_LED);

    if (yellowLedState == HIGH)
    {
      Serial.println("ON");
    }
    else if (yellowLedState == LOW)
    {
      Serial.println("OFF");
    }
  }
  oldYellowLedState = yellowLedState;

}


//this void is made to activate the right turn blinker
void button1()
{
  buttonState1 = digitalRead(PIN_KEY1);

  if (buttonState1 != lastButtonState1)
  {
    if (buttonState1 == LOW)
    {
      delay(80);
      buttonState1 = digitalRead(PIN_KEY1);

      if (buttonState1 == LOW)
      {
        turnRight = true;
        turnLeft = false;
        if (hazard == false)
        {
          digitalWrite(BLUE_LED, LOW);
        }
      }
    }
  }
  lastButtonState1 = buttonState1;
}

//this void is made to activate the left turn blinker
void button2()
{
  buttonState2 = digitalRead(PIN_KEY2);

  if (buttonState2 != lastButtonState2)
  {
    if (buttonState2 == LOW)
    {
      delay(80);
      buttonState2 = digitalRead(PIN_KEY2);

      if (buttonState2 == LOW)
      {
        turnLeft = true;
        turnRight = false;
        if (hazard == false)
        {
          digitalWrite(GREEN_LED, LOW);
        }
      }
    }
  }
  lastButtonState2 = buttonState2;
}

void blinkRedLed()
{
  unsigned long currenttime = millis();
  if (currenttime - lasttimeRedLed > BLINK_INTERVAL)
  {
    ledstateRedLed = !ledstateRedLed;
    digitalWrite(RED_LED, ledstateRedLed);
    lasttimeRedLed = currenttime;
  }
}

void blinkBlueLed()
{
  unsigned long currenttime = millis();
  if (currenttime - lasttimeBlueLed > BLINK_INTERVAL)
  {
    ledstateBlueLed = !ledstateBlueLed;
    digitalWrite(BLUE_LED, ledstateBlueLed);
    lasttimeBlueLed = currenttime;
  }
}

void blinkGreenLed()
{
  unsigned long currenttime = millis();
  if (currenttime - lasttimeGreenLed > BLINK_INTERVAL)
  {
    ledstateGreenLed = !ledstateGreenLed;
    digitalWrite(GREEN_LED, ledstateGreenLed);
    lasttimeGreenLed = currenttime;
  }
}

//this void lets us communicate with the computer and activate the hazard mode
void hazardButton()
{
  if (Serial.available() > 0 )
  {
    command = Serial.readStringUntil('\n');
    if (command == "AlarmOn")
    {
      //if we read "AlarmOn" through the serial port we activate the alarm
      //and reset the timers and states of the leds as to not make them overlap
      hazard = true;
      ledstateRedLed = false;
      ledstateBlueLed = false;
      ledstateGreenLed = false;
      lasttimeRedLed = 0;
      lasttimeBlueLed = 0;
      lasttimeGreenLed = 0;

    }
    if (command == "AlarmOff")
    {
      hazard = false;
      digitalWrite(RED_LED, LOW);

      if (turnRight == false)
      {
        digitalWrite(GREEN_LED, LOW);
      }
      if (turnLeft == false)
      {
        digitalWrite(BLUE_LED, LOW);
      }
    }
  }
}
//we use this void only in hazard mode
//I created this void to be able to blink the leds when hazard mode is activated
void alarm()
{
  if (hazard == true)
  {
    blinkRedLed();
    blinkBlueLed();
    blinkGreenLed();
  }
}

//this void is created to send the temperature to the computer
void fetchTemperature()
{
  if(millis() - timer >= 5000)
  {
      float temperature = DHT11.getTemperature();
      Serial.println("degrees:" + String (temperature));
      timer = millis();
  }
    }
