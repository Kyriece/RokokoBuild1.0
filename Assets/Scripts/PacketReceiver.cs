using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class PacketReceiver : MonoBehaviour
{
    // Set your desired port number
    private const int Port = 12345;

    private UdpClient udpClient;

    private void Start()
    {
        // Initialize the UDP client
        udpClient = new UdpClient(Port);
        Debug.Log($"Listening for packets on port {Port}");
    }

    private void Update()
    {
        try
        {
            // Receive data from the UDP client
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, Port);
            byte[] receivedData = udpClient.Receive(ref remoteEndPoint);

            // Convert the received bytes to a string (assuming UTF-8 encoding)
            string receivedMessage = System.Text.Encoding.UTF8.GetString(receivedData);
            Debug.Log($"Received packet: {receivedMessage}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Error receiving packet: {e.Message}");
        }
    }

    private void OnDestroy()
    {
        // Clean up the UDP client
        udpClient.Close();
    }
}
