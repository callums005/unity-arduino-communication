using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class Controller : MonoBehaviour
{
    Thread IOThread = new Thread(DataThread);
    private static SerialPort sp;
    private static string incomingMsg = "";
    private static string outgoingMsg = "";

    private static void DataThread()
    {
        sp = new SerialPort("COM5", 9600);
        sp.Open();

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
