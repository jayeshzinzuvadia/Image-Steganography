using System;
using System.ServiceModel;

namespace Image_Steganography_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Image_Steganography_Service.HideAndSeek)))
            {
                host.Open();
                Console.WriteLine("Service is Hosted and is Running !");
                Console.ReadLine();
            }
        }
    }
}
