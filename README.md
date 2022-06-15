# Unity & Arduino Wired Communication

This project is to help set up the basics of communicating between the [Unity](https://unity.com/) Game Engine and an [Arduino](https://www.arduino.cc/). If you find any issues with the program please create an issue [here](https://github.com/callums005/unity-arduino-communication/issues) I will try to respond to any as soon as possible.

## Prerequisites
1. You have a basic understanding of small electronics and the arduino.
2. You have a basic understanding of the Unity Game Engine and C# programming.
3. You are not a beginner to computing science. I will not explain the very basics of how computers work or how to program a game.
4. This is **ONLY** for communication between unity and an arduino, this is not to do anything fancy or make a full game or controller.
---
## You will need
- A computer that can run Unity and an IDE or text editor.
- Arduino IDE (Any version).
- An Arduino that has is supported. (An Arduino Uno was used during the development).
- An LED of any colour.
- Resistors for an LED and a 10K ohm resistor.
- A **momentery**  button.
- Male to Male wires (3 coloured, 2 black).
- A breadboard.
---
## Supported Versions & Hardware

### Unity

| Version | Link |
| ------- | ---- |
| 2021.2.19f1 | [Windows](https://unity3d.com/get-unity/download?thank-you=update&download_nid=65552&os=Win) • [Mac](https://unity3d.com/get-unity/download?thank-you=update&download_nid=65552&os=Mac) • [Linux](https://download.unity3d.com/download_unity/602ecdbb2fb0/UnitySetup-2021.2.19f1) |

### Arduino

| Board | Supported | Buy | Credit |
| ------| --------- | --- | ------ |
| Arduino Uno R3 | <span style="color:lightgreen" >Yes</span> | [store.arduino.cc](https://store.arduino.cc/products/arduino-uno-rev3) | @callums005 |
| Arduino Mega R3 | <span style="color:yellow" >Unknown</span> | [store.arduino.cc](https://store.arduino.cc/products/arduino-mega-2560-rev3) |  |
| Arduino Leonardo | <span style="color:yellow" >Unknown</span> | [store.arduino.cc](https://store.arduino.cc/products/arduino-leonardo-with-headers) |  |
| Arduino Micro | <span style="color:yellow" >Unknown</span> | [store.arduino.cc](https://store.arduino.cc/products/arduino-micro) |  |
| Arduino Zero | <span style="color:yellow" >Unknown</span> | [store.arduino.cc](https://store.arduino.cc/products/arduino-zero) |  |
| Arduino Nano | <span style="color:yellow" >Unknown</span> | [store.arduino.cc](https://store.arduino.cc/products/arduino-nano) |  |
| Raspberry Pi (All Selection) | <span style="color:red" >No</span> | | @callums005 |

If you have any boards on this list that have been given the <span style="color:yellow">Unknown</span> support tag, please try and open an issue telling me the result, I will update the table with your findings and credit (if the username is offensive I will not credit, and I will not take credit myself).
---
## Source Code
| File | Link |
| ---- | ---- |
| Unity Main Script | [Controller.cs](Assets/Controller.cs) |
| Arduino Main Script | [Controller.ino](Controller/Controller.ino) |
---
## How it works
The program takes advantage of the arduino serialization functionality, it will during the arduino's program lifetime, it will read data using the `Serial.readBytes()` functionality, converting it to an array of characters. At the end of each loop it will output any data using the `Serial.println()` functionality.

The Unity project will write any data stored in a string to the arduino making use of `System.IO.Ports`. It will then read in any incoming data to a sepearte string. This is all done on a seperate thread to the main game loop to prevent the game from freezing. The strings are used to send data from the main game thread to the second thread and the other way around.
---
## <span style="color:red">DISCLAIMER</span>
This code is **not** malicious however I am not responsibe for any damage done to your computer. This code was written on the 15th of June 2022, for the Unity Game Engine version 2021.2.19f1. I will try to fix any issues with later version, please open an issue if you find one or need help, I will try to get back to you as soon as possible. This is a community project therefore you are able to write code or maintain the code if you wish. I have no objegation to maintain this program, however I will try to.

---
## Have fun! Thank-You!
