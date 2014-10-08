
using System;
using System.Reflection;
using System.IO;

namespace AssemblyLoad
{
	class Program
	{
		public static void DisplayTypesInAsm(Assembly asm){
			Console.WriteLine("\n>{0}",asm.FullName);
			Type[] types = asm.GetTypes();
			foreach (Type t in types){
				Console.WriteLine(">Type: {0}",t);
				}					
			Console.WriteLine("");
		}
		
		
		public static void Main(string[] args)
		{
			string asmPath = "";
			Assembly asm = null;
			do{
				Console.WriteLine(">Введите расположение сборки или Q для выхода: ");
				Console.Write(">");
				asmPath = Console.ReadLine();
			
				if (asmPath.ToUpper() == "Q"){
					break;
				}
				try{
					asm = Assembly.LoadFrom(asmPath);
					DisplayTypesInAsm(asm);
				}
				catch{
					Console.WriteLine(">Извините, сборка не найдена");
					Console.Beep();
				}				
			}while(true);
			
		}
	}
}