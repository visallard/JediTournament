using System;
using System.IO;

namespace JediTournamentWPF
{
    public static class LogManager
    {
        private static StreamWriter _writer = File.AppendText("log.txt");

        public static void Writelog(string logMessage)
        {
            _writer.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _writer.WriteLine("{0}", logMessage);
            _writer.WriteLine("-------------------------------");
            _writer.Flush();
        }
    }
}