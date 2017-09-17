using System;
using System.Threading;
using Microsoft.Win32;

namespace mora_not_run
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //  enumerate registry keys
                string keyname = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts";
                foreach (string key in Registry.LocalMachine.OpenSubKey(keyname, false).GetValueNames())
                    Console.WriteLine("{0} {1}", key.Length, key);

                //  create the mutex
                Mutex mutex = new Mutex(false, "28e89a9f-e67d-3028-aa1b-e5ebcde6f3c8");
                bool result = mutex.WaitOne(0);
                Console.WriteLine(result);
                if (result)
                {
                    Thread.Sleep(60 * 1000);
                    mutex.ReleaseMutex();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
