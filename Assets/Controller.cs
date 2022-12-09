using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class Controller : MonoBehaviour
{
    // Having data sent and recieved in a seperate thread to the main game thread stops unity from freezing
    Thread IOThread = new Thread(DataThread);
    private static SerialPort sp; 
    // If the serial port class does not exist open your NuGet package manager Project->Manage NuGet Packages->Browse and search for
    // Serial Port. Install System.IO.Ports by Microsoft
    
    // Stores any data that comes in via the serial port
    private static string incomingMsg = "";
    // Stores the data to be sent to the arduino via the serial port
    private static string outgoingMsg = "";

    private static void DataThread()
    {
        // Opens the serial port for reading and writing data
        sp = new SerialPort("COM5", 9600); // Alter the first value to be whatever port the arduino is connected to within the arduino IDE; Alter the second value to be the same as Serial.beign at the start of the arduino program
        sp.Open();

        // Every 200ms, it checks if there is a message stores in the output buffer string to be sent to the arduino,
        // Then recieves any data being sent to the project via the arduino 
        while(true)
        {
            if (outgoingMsg != "")
            {
                sp.Write(outgoingMsg);
                outgoingMsg = "";
            }

            incomingMsg = sp.ReadExisting();
            Thread.Sleep(200);
        }
    }

    private void OnDestroy()
    {
        // Closes the thread and serial port when the game ends
        IOThread.Abort();
        sp.Close();
    }

    // Start is called before the first frame update
    void Start()
    {
        IOThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (incomingMsg != "")
        {
            Debug.Log(incomingMsg);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            outgoingMsg = "0";
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            outgoingMsg = "1";
    }
}
