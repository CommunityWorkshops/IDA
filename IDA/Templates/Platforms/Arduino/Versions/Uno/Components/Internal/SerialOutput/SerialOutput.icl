Version=Uno
Name=Serial Output
Description=Allows the board to SEND data via the Serial Port (USB Port)
Options=Analog,Digital
Icon=serial-port.png
Images=SerialOutput
Analog Global=                                                  // These constants won't change.  They're used to give names to the pins used:
Analog Global=const int analogInPin = A0;                       // Analog input pin that the potentiometer is attached to
Analog Global=const int analogOutPin = 9;                       // Analog output pin that the LED is attached to
Analog Global=
Analog Global=int sensorValue = 0;                              // value read from the pot
Analog Global=int outputValue = 0;                              // value output to the PWM (analog out)
Analog Setup=Serial.begin(9600);                                // initialize serial communication at 9600 bits per second:
Analog Loop=sensorValue = analogRead(analogInPin);              // read the analog in value:
Analog Loop=outputValue = map(sensorValue, 0, 1023, 0, 255);    // map it to the range of the analog out:
Analog Loop=analogWrite(analogOutPin, outputValue);             // change the analog out value:
Analog Loop=
Analog Loop=Serial.print("sensor = ");                          // print the results to the serial monitor:
Analog Loop=Serial.print(sensorValue);                          // print the results to the serial monitor:
Analog Loop=Serial.print("\t output = ");                       // print the results to the serial monitor: \t = insert a tab spacing
Analog Loop=Serial.println(outputValue);                        // print the results to the serial monitor:
Analog Loop=
Analog Loop=delay(2);                                           // wait 2 milliseconds before the next loop for the analog-to-digital converter to settle after the last reading:
