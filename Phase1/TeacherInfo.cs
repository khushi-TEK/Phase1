using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Phase1
{
    internal class TeacherInfo
    {
        public bool AddT(TeacherCreds Teacher1, bool append)
        {
            try
            {
                string path = Environment.CurrentDirectory;
                FileInfo fileInfo = new FileInfo(path + "\\Information.txt");
                using (StreamWriter streamWriter = new StreamWriter(fileInfo.FullName, append))
                {
                    streamWriter.WriteLine($"{Teacher1.ID}\t{Teacher1.Name}\t{Teacher1.CandS}");
                    streamWriter.Flush();
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }


        }

        public bool RemoveInfo(int ID)
        {
            List<TeacherCreds> Teachers = new List<TeacherCreds>();
            try
            {
                string path = Environment.CurrentDirectory;
                FileInfo fileInfo = new FileInfo(path + "\\Information.txt");
                string[] lines = File.ReadAllLines(fileInfo.FullName);

                foreach (var line in lines)
                {
                    TeacherCreds Teacher1 = new TeacherCreds();
                    string[] values = line.Split('\t');
                    Teacher1.ID = Convert.ToInt32(values[0]);
                    Teacher1.Name = values[1];
                    Teacher1.CandS = values[2];
                    Teachers.Add(Teacher1);
                }
                if (Teachers != null)
                {

                    var proToDelete = Teachers.Where(x => x.ID == ID).FirstOrDefault();
                    Teachers.Remove(proToDelete);
                    fileInfo.Delete();
                    foreach (var pro in Teachers)
                    {
                        AddT(pro, true);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public void PrintAllInfo()
        {
            try
            {

                string path = Environment.CurrentDirectory;
                FileInfo fileInfo = new FileInfo(path + "\\Information.txt");

                string[] lines = File.ReadAllLines(fileInfo.FullName);
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
