using HealingWorldPacketData;
using System;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public static class Network {   //180528수정 : static class로 변경
    private static TcpClient client = new TcpClient();      //소켓
    private static NetworkStream m_stream = null;           //스트림
    private static Thread reader = null, writer = null;     //스레드
    private static bool Start_Service = false;              //연결중인지 아닌지
    public static bool loginCheck = false;

    static byte[] sendBuffer    = new byte[1024 * 4];
    static byte[] receiveBuffer = new byte[1024 * 4];

    public static void Login(string serverIp, int serverPort)
    {
        try
        {
            client.Connect(serverIp, serverPort);
            m_stream = client.GetStream();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            throw;
        }
        reader = new Thread(new ThreadStart(Receive));
        reader.Start();
    }

    public static void Receive()
    {
        while (!Start_Service){
            try
            {
                int bytesRead = m_stream.Read(receiveBuffer, 0, receiveBuffer.Length);
                if (bytesRead != 0) {
                    HealPacket healPacket = HealPacketSerializeTool.Deserialize(receiveBuffer);
                    HealListener.SmartListener(healPacket);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                Start_Service = true;
                throw;
            }
        }
        Logout();
    }

    public static void Send(int protocol, HealPacket data) {
        data.protocol = protocol;
        Array.Clear(sendBuffer, 0, sendBuffer.Length);
        sendBuffer = HealPacketSerializeTool.Serialize(data);

        m_stream.Write(sendBuffer, 0, sendBuffer.Length);
        m_stream.Flush();
    }

    public static void Logout()
    {
        Start_Service = false;
        m_stream.Dispose();
        m_stream.Close();
        client.Close();
    }
}

