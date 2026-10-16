using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class RememberME
    {
        private static string path = ".rememberme.txt";
        public static string UserName { get; set; }
        public static string HashedPassword { get; set; }
        public static void WriteInFile(string username,string hashedPassword)
        {
            string[] data = { username, hashedPassword };
            File.WriteAllLines(path, data);
        }
        public static string[] ReadInFile()
        {
            try
            {
                return File.ReadAllLines(path);
            } 
            catch {  return null; }
        }
        public static void Logout()
        {
            try {  File.Delete(path); } catch { }
           
        }
    
    
    }
}
