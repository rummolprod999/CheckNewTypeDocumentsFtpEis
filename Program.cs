using System;
using static System.Console;
namespace CheckNewTypeDocumentsFtpEis
{
    class Program
    {
        private static string arguments = "44, 223";
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                WriteLine($"too many arguments,  please use {arguments}");
            }

            switch (args[0])
            {
                  case "44":
                      var a = new Ftp44(Arguments.Type44);
                      a.CheckFtp();
                      break;
                  case "223":
                      var b = new Ftp223(Arguments.Type223);
                      b.CheckFtp();
                      break;
                  
                  default:
                      throw new ArgumentOutOfRangeException(nameof(args), args[0], null);
            }
        }
    }
}