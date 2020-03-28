using System;

namespace ElectricKettleSingleton
{
    class Program
    {
        static void Main(string[] args)
        {

            RunSingleton();

        }

        private static void RunSingleton()
        {
            KettleEngine s1 = KettleEngine.Instance;

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(s1.Message);
                switch (s1.Status)
                {
                    case KettleStatus.Empty:
                        s1.Fill();
                        break;
                    case KettleStatus.InProgress:
                        s1.Boil();
                        break;
                    case KettleStatus.Boiled:
                        s1.Drain();
                        break;
                    default:
                        break;
                }

            }

            Console.WriteLine("End");
        }
    }


    public sealed class KettleEngine
    {
        private static readonly KettleEngine instance = new KettleEngine();

        static KettleEngine()
        {

        }
        private KettleEngine()
        {

        }

        public static KettleEngine Instance {get { return instance; } }

        public KettleStatus Status { get; set; } = KettleStatus.Empty;
        public string Message { get; set; } = "Starting";

        public void Fill()
        {            
            instance.Status = KettleStatus.InProgress;
            instance.Message = "Filling";
        }

        public void Boil()
        {            
            instance.Message = "Boiling";
            instance.Status = KettleStatus.Boiled;
        }

        public  void Drain()
        {
            instance.Message = "Draining";
            instance.Status = KettleStatus.Empty;
        }

        
    }

    public enum KettleStatus
    {
        Empty,
        InProgress,
        Boiled
    }

   
}
