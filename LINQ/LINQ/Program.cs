using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Program
    {
        static void PrintArr(int[] arr)  {
            foreach (var item in arr) {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static void PrintList(List<Student> list) {
            foreach (var item in list) {
                item.Show();
            }
            Console.WriteLine("______________End__________");
        }
        static void Main(string[] args)
        {
            var nums = new int[] { 23, 45, 65, 76, 78, 98, 82, 76, 97, 86 };
            var filtered = (from item in nums 
                            where item >= 75 
                            select item).ToArray();
            //var filtered = new int[nums.Length];
            //int count=0;
            //foreach (var i in nums) {
            //    if (i >= 75) { 
            //        filtered[count++] = i;  
            //    }
            //}
            PrintArr(nums);
            PrintArr(filtered);


            var students = new List<Student>();
            Random rand = new Random();
            for (int i = 1; i <= 100; i++) {
                var student = new Student() { 
                    Id = i,
                    Name = "Student "+i,
                    Marks = rand.Next(20,101)
                };
                students.Add(student);
            }
            PrintList(students);
            var scstudents = (from item in students
                              where item.Marks >= 75 && item.Id <11
                              select item).ToList();
            PrintList(scstudents);

        }
    }
}
