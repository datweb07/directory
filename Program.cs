using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace directory
{
    internal class Program
    {
        static void DanhSach(string path)
        {
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }    

            foreach (string directory in directories)
            {
                Console.WriteLine(directory);
                DanhSach(directory);
            }    
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DirectoryInfo directoryInfo = new DirectoryInfo("."); //lấy thông tin của thư mục hiện tại
            Console.WriteLine(directoryInfo.FullName);
            Console.WriteLine(directoryInfo.Name);

            DirectoryInfo path = new DirectoryInfo(@"C:\Test directory");
            Console.WriteLine(path.FullName); //in ra toàn bộ đường dẫn
            Console.WriteLine(path.Name); //tên thư mục
            Console.WriteLine(path.Parent); //lấy tên thư mục cha
            Console.WriteLine(path.Attributes); //lấy thuộc tính, ở đây là Directory
            Console.WriteLine(path.CreationTime); //thời gian tạo thư mục
            Console.WriteLine(path.Root); //lấy thư mục gốc

            //create a directory
            DirectoryInfo newDirectory = new DirectoryInfo(@"C:\Thu muc 1");
            //newDirectory.Create();

            //create a directory 2
            string path2 = @"C:\Thu muc 2";
            //Directory.CreateDirectory(path2);


            //exists directory (kiểm tra thư mục có tồn tại hay không)
            DirectoryInfo path3 = new DirectoryInfo(@"C:\Thu muc 2");
            if (Directory.Exists(path2))
            {
                Console.WriteLine($"thư mục {path3.Name} tồn tại");
            }
            else
            {
                Console.WriteLine("thư mục không tồn tại");
            }

            //Delete directory
            //Directory.Delete(path2);


            //lấy file trong thư mục (directory getFile)
            string path4 = @"C:\Thu muc 1";
            string[] listFile = Directory.GetFiles(path4);
            Console.WriteLine($"Danh sách các file của thư mục {Path.GetFileName(path4)} là: ");
            foreach (string file in listFile)
            {
                Console.WriteLine(file);
            }
            Console.WriteLine("\n\n\n");

            //danh sách các thư mục nằm trong đường dẫn (directory getDirectories)
            string path5 = @"C:\";
            string[] listDirectories = Directory.GetDirectories(path5);
            Console.WriteLine($"Danh sách thư mục nằm trong {path5} là: ");
            foreach (string directory in listDirectories)
            {
                Console.WriteLine(directory);
            }
            Console.WriteLine("\n\n\n");


            //xuất cả file và thư mục trong 1 path
            string path6 = @"C:\Test directory";
            Console.WriteLine($"Danh sách file và thư mục của {path6} là: ");
            DanhSach(path6);
            Console.WriteLine("\n\n\n");


            //tìm kiếm file
            DirectoryInfo path7 = new DirectoryInfo(@"C:\Test directory");
            FileInfo[] txtFiles = path7.GetFiles("*.txt", SearchOption.AllDirectories);
            //AllDirectories: duyệt toàn bộ các thư mục (kể cả thư mục con)
            //TopDirectoryOnly: chỉ duyệt thư mục được chỉ định ban đầu
            Console.WriteLine($"tìm thấy {txtFiles.Length} file: ");
            foreach (FileInfo file in txtFiles)
            {
                Console.WriteLine(file.Name);
            }    
            Console.ReadKey();
        }
    }
}
