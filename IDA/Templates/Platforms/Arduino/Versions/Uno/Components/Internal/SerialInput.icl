Version=Uno
Name=Serial Input
Description=Allows the board to RECIEVE serial input.
Options=Analog,Digital
Icon=serial-port.png
Images=SerialInput
Setup=Serial.begin(9600);                       // initialize serial communication at 9600 bits per second:
Digital Setup= pinMode(pushButton, INPUT);                // make the pushbutton's pin an input:
Analog Loop=int sensorValue = analogRead(A0);   // read the input on analog pin 0:
Analog Loop=Serial.println(sensorValue);        // print out the value you read:
Analog Loop=delay(1);                           // delay in between reads for stability
Digital Loop=int buttonState = digitalRead(pushButton);   // read the input pin:
Digital Loop=Serial.println(buttonState);                 // print out the state of the button:
Digital Loop=delay(1);                                    // delay in between reads for stability