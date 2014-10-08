using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProcessManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ProcessManipulator";     
            do
            {
                Console.Write("Введите имя процесса: ");
                string userProcId = Console.ReadLine();
                Console.Write("");

                if (userProcId.ToUpper() == "Q")
                {
                    break;
                }
                try
                {                    
                    EnumModsForPid(GetProcessID(userProcId));
                }
                catch ( Exception exe)
                {
                    Console.WriteLine(exe.Message);
                    Console.Beep();
                }
            } while (true);

            Console.ReadLine();
        }
        static int GetProcessID(string procName)
        {
            int ID = -1;
            var runningProcess = from proc in Process.GetProcessesByName(procName) orderby proc.ProcessName select proc;
            foreach (var p in runningProcess)
            {
                string info = string.Format("-> PID: {0}\tName: {1}", p.Id, p.ProcessName);               
                ID = p.Id;                
                Console.WriteLine(info);
               
            } return ID;
        }

        static void EnumModsForPid(int pId)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pId);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Загружаем модули для процесса {0} {1}", theProc.Id, theProc.ProcessName);
            foreach (ProcessModule pr in theProc.Modules)
            {
                string info = string.Format("-> Имя модуля: {0}", pr.ModuleName);
                Console.WriteLine(info);
            }
            Console.WriteLine("__________________________________________________________\n");
        }
    }
}