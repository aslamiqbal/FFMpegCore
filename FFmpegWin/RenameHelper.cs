using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filerenamer
{
    public class RenameHelper
    {
     public static   void Rename2(List<string> files)
        {

            //output_0001
            var nfiles = files.Select(n => int.Parse(Path.GetFileName(n).Replace("output_", "").Replace(".jpg", "").TrimStart('0'))).ToList();
            int i = 1;
            foreach (var file in files)
            {
                try
                {
                    Console.WriteLine($"Renamig: {file}.  {i}/{files.Count}.");
                    File.Move(file, $"src{i}.jpg");
                    Thread.Sleep(5);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                i++;
            }
        }


        public static void Rename1(List<string> files)
        {

            int i = 1;
            foreach (var file in files)
            {
                try
                {
                    Console.WriteLine($"Renamig: {file}.  {i}/{files.Count}.");
                    File.Move(file, $"src{i}.png");
                    Thread.Sleep(20);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                i++;
            }
        }
    }
}
