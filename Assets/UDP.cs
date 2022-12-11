using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class UDP : MonoBehaviour
{
    Socket socket;
    EndPoint clientEnd;
    IPEndPoint ipEnd;
    string recvStr;
    string sendStr;
    byte[] recvData = new byte[512];
    byte[] sendData = new byte[512];
    int recvLen;
    Thread connectThread;
    public int port = 52820;
    public string remoteIp = "192.168.0.255";

    public static int remoteRqst = 0;
    public static int first = 0;
    public static int second = 0;

    string tmpSendStr;

    void InitSocket()
    {
        ipEnd = new IPEndPoint(IPAddress.Any, port);
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        socket.Bind(ipEnd);
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, port);
        clientEnd = (EndPoint)sender;
        print("waiting for UDP dgram");
        connectThread = new Thread(new ThreadStart(SocketReceive));
        connectThread.Start();
    }

    void SocketSend(string sendStr)
    {
        sendData = new byte[1024];
        sendData = Encoding.UTF8.GetBytes(sendStr);
        IPEndPoint _ipEnd = new IPEndPoint(IPAddress.Parse(remoteIp), 52820);
        try
        {
            socket.SendTo(sendData, sendData.Length, SocketFlags.None, _ipEnd);
        }
        catch
        {
            //Invoke에 전달하기 위해 복사
            //될때까지 2초마다 재귀로 반복
            tmpSendStr = sendStr;
            Invoke("SocketSendDelay", 2f);
        }
    }

    void SocketSendDelay()
    {
        SocketSend(tmpSendStr);
    }

    void SocketReceive()
    {
        // PPT 프로그램은 통신 데이터를 받을 필요가 없다

        // print("Entering for Receiving");
        // while (true)
        // {
        //     ipEnd = new IPEndPoint(IPAddress.Any, port);
        //     recvData = new byte[512];
        //     recvLen = socket.ReceiveFrom(recvData, ref clientEnd);
        //     recvStr = Encoding.ASCII.GetString(recvData, 0, recvLen);

        //     print("message from: " + clientEnd.ToString());
        //     print(recvStr);
        // }
    }

    void SocketQuit()
    {
        if (connectThread != null)
        {
            connectThread.Interrupt();
            connectThread.Abort();
        }
        if (socket != null)
            socket.Close();
        print("disconnect");
    }

    void Start()
    {
        // Application.targetFrameRate = 60;
        InitSocket();
        StartCoroutine(broadcastAppState());
    }

    IEnumerator broadcastAppState()
    {
        while (true)
        {
            if(FreezeLoadingBar.gameEnd)
            {
                SocketSend($"#ppt,end");
                yield return new WaitForSeconds(2);
                SocketSend($"#ppt,end");
                yield return new WaitForSeconds(2);
                SocketSend($"#ppt,end");
                yield return new WaitForSeconds(2);
                SocketSend($"#ppt,end");
                yield return new WaitForSeconds(2);
                FreezeLoadingBar.gameEnd = false;
            }
            else
            {
                SocketSend($"#ppt,run");
            }
            
            yield return new WaitForSeconds(2);
        }
    }

    void OnApplicationQuit()
    {
        SocketQuit();
    }
}