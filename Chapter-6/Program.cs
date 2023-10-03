using System;
using System.Threading;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Reflection;


//namespace StreamsAndAsync
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            string testMessage = "Testing writing some arbitrary string to a stream";
//            byte[] messageBytes = Encoding.UTF8.GetBytes(testMessage);
//            using (Stream ioStream = new FileStream(@"stream_demo_file.txt", FileMode.OpenOrCreate))
//            {
//                if (ioStream.CanWrite)
//                {
//                    //We started with our original byte array, navigated to the end
//                    //of the stream of written bytes, and then wrote our message from there; easy as that.
//                    //ioStream.Seek(0, SeekOrigin.End);
//                    ioStream.Write(messageBytes, 0, messageBytes.Length);
//                } else
//                {
//                    Console.WriteLine("Couldn't write to our data stream");
//                }
//                if (ioStream.CanRead)
//                {
//                    byte[] destArray = new byte[10];
//                    ioStream.Read(destArray, 0, 10);
//                    string result = Encoding.UTF8.GetString(destArray);
//                    Console.WriteLine(result);
//                }
//            }
//            Console.WriteLine("Done!");
//            Thread.Sleep(10000);
//        }
//    }
namespace StreamsAndAsync
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ComplexModel testModel = new ComplexModel();
            //string testMessage = JsonConvert.SerializeObject(testModel);
            //byte[] messageBytes = Encoding.UTF8.GetBytes(testMessage);
            //using (Stream ioStream = new FileStream(@"stream_demo_file.txt", FileMode.OpenOrCreate))
            //{
            //    if (ioStream.CanWrite)
            //    {
            //        //In that simple declaration in the second line of our method, we convert our model
            //        //    into a complete string representation fit for serialized transport
            //        ioStream.Write(messageBytes, 0, messageBytes.Length);
            //    } else
            //    {
            //        Console.WriteLine("Couldn't write to our data stream");
            //    }
            //    if (ioStream.CanRead)
            //    {
            //        byte[] destArray = new byte[10];
            //        ioStream.Read(destArray, 0, 10);
            //        string result = Encoding.UTF8.GetString(destArray);
            //        Console.WriteLine(result);
            //        //ComplexModel model = JsonConvert.Deserialize<ComplexModel>(testMessage);
            //    }
            //}
            //Console.WriteLine("Done!");
            //Thread.Sleep(10000);

            // serialize a complex nested object and write it to our output stream 
            //ComplexModel testModel = new ComplexModel();
            //string testMessage = JsonConvert.SerializeObject(testModel);

            //using (Stream ioStream = new FileStream(@"../stream_demo_file.txt", FileMode.OpenOrCreate))
            //{
            //    using (StreamWriter sw = new StreamWriter(ioStream)) {
            //        sw.Write(testMessage);
            //    }
            //}
            //Console.WriteLine("Done!");

            //Writing to a StreamWriter instance from a speccific index by accessing the underlying baseStream property
            // In the book it was said that the first 10 chars would be null, they aren't null 
            //ComplexModel testModel = new ComplexModel();
            //string testMessage = JsonConvert.SerializeObject(testModel);
            //using (Stream ioStream = new FileStream(@"../stream_demo_file1.txt", FileMode.OpenOrCreate))
            //{
            //    using (StreamWriter sw = new StreamWriter(ioStream))
            //    {
            //        sw.BaseStream.Seek(10, SeekOrigin.Begin);
            //        sw.Write(testMessage);
            //    }
            //}
            //Console.WriteLine("Done!");
            //Thread.Sleep(10000);
        }
    }
}
