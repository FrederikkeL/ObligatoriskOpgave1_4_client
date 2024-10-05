using System;
using System.IO;
using System.Net.Sockets;

class Program
{
    static void Main(string[] args)
    {

        // Opret forbindelse til serveren på localhost og port 7
        TcpClient client = new TcpClient("127.0.0.1", 7);
        NetworkStream ns = client.GetStream();
        StreamReader reader = new StreamReader(ns);
        StreamWriter writer = new StreamWriter(ns);

      
        // Læs og vis velkomstbeskeden fra serveren
        Console.WriteLine(reader.ReadLine());
        string message;
        // Brugeren indtaster kommandoen
        message = Console.ReadLine();
        writer.WriteLine(message);
        writer.Flush();
        while (message.ToLower().Trim() != "quit")
        {
            // Læs besked fra serveren
            string serverMessage = reader.ReadLine();
            Console.WriteLine(serverMessage);



            // Indtast nummererne 
            string numberInput = Console.ReadLine();
            writer.WriteLine(numberInput);
            writer.Flush();

            // Læs resultatet fra serveren
            serverMessage = reader.ReadLine();
            Console.WriteLine(serverMessage);
            serverMessage = reader.ReadLine();
            Console.WriteLine(serverMessage);

            message = Console.ReadLine();
            writer.WriteLine(message);
            writer.Flush();

        }

        client.Close();

    }
}