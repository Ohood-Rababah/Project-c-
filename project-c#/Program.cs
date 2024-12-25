using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace project_c_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student1> students = new List<Student1>();
            List<Course> courses = new List<Course>();
            List<Score> scores = new List<Score>();


            while (true)
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Edit Student");
                Console.WriteLine("3. Display All Students");
                Console.WriteLine("4. Add Course");
                Console.WriteLine("5. Edit Course");
                Console.WriteLine("6. Display All Courses");
                Console.WriteLine("7. Print Courses To File");
                Console.WriteLine("8. Add Score");
                Console.WriteLine("9. DisplayScores");
                Console.WriteLine("10. Print Scorses To File");

                Console.WriteLine("11. Exit");
                Console.WriteLine("Choose an option: ");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {

                    Student1.AddStudent(students); // إضافة طالب
                }
                else if (choice == 2)
                {

                    Student1.EditStudent(students); // تعديل طالب
                }
                //else if (choice == 3)
                //{
                //    ManageStudents(); 
                //}
                else if (choice == 3)
                {
                    Student1.DisplayAllStudents(students); // عرض جميع الطلاب
                }
                else if (choice == 4)
                {
                    Course.AddCourse(courses); // إضافة مقرر
                }
                else if (choice == 5)
                {
                    Course.EditCourse(courses); // إضافة مقرر
                }
                else if (choice == 6)
                {
                    Course.DisplayAllCourses(courses);
                }
                else if (choice == 8)
                {
                    Score.AddScore(students, courses, scores); // إضافة مقرر
                }
                else if (choice == 9)
                {
                    Score.DisplayScores(students, courses, scores);
                }
                else if (choice == 7)
                {
                    Course.PrintCoursesToFile(courses); // استدعاء الدالة لطباعة الكورسات
                }
                else if (choice ==10)
                {
                    Score.PrintScoresToFile(students, courses, scores); // استدعاء الدالة لطباعة الكورسات
                }
                else if (choice == 11)
                {
                    Console.WriteLine("Close the program.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }
    }






    public class Student1
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }


        public static void AddStudent(List<Student1> students)
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Student Gender (Male/Female): ");
            string gender = Console.ReadLine();

            //AddStudent 
            students.Add(new Student1 { ID = id, Name = name, Gender = gender });

            Console.WriteLine("Student added successfully!");
        }


        public static void EditStudent(List<Student1> students)
        {
            Console.Write("Enter the ID of the student to edit: ");
            int id = int.Parse(Console.ReadLine());

            foreach (var Student1 in students)
            {
                if (Student1.ID == id)
                {
                    Console.WriteLine($"Current Name: {Student1.Name}");
                    Console.Write("Enter new name: ");
                    Student1.Name = Console.ReadLine();

                    Console.WriteLine($"Current Gender: {Student1.Gender}");
                    Console.Write("Enter new gender (Male/Female): ");
                    Student1.Gender = Console.ReadLine();

                    Console.WriteLine("Student information updated successfully!");
                    return;
                }
            }

            // في حال لم يتم العثور على الطالب
            Console.WriteLine("Student not found!");
        }
        public static void DisplayAllStudents(List<Student1> students)
        {


            Console.WriteLine("List of All Students:");
            foreach (var Student1 in students)
            {
                Console.WriteLine($"ID: {Student1.ID}, Name: {Student1.Name}, Gender: {Student1.Gender}");
            }
        }
    }

    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //first methood
        public static void AddCourse(List<Course> courses)
        {
            Console.Write("Enter Course ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Course Name: ");
            string name = Console.ReadLine();

            courses.Add(new Course { ID = id, Name = name });

            Console.WriteLine("Course added successfully!");
        }

        //2 METHOD
        public static void EditCourse(List<Course> courses)
        {
            Console.Write("Enter the ID of the course to edit: ");
            int id = int.Parse(Console.ReadLine());

            foreach (var Course in courses)
            {

                if (Course.ID == id)
                {
                    Console.WriteLine($"Current Name: {Course.Name}");
                    Console.WriteLine("Enter new name: ");
                    Course.Name = Console.ReadLine();


                    Console.WriteLine("Course information updated successfully!");
                    return;
                }
            }

            Console.WriteLine("Course not found!");
        }


        //3 method
        public static void DisplayAllCourses(List<Course> courses)
        {


            Console.WriteLine("List of All Courses:");
            foreach (var Course in courses)
            {
                Console.WriteLine($"ID: {Course.ID}, Name: {Course.Name}");
            }

        }
        //4 method
        public static void PrintCoursesToFile(List<Course> courses)
        {
            try
            {
                string Location = @"C:\Users\ohood\Desktop\Text File C#\test file.text";
                FileInfo fileinfo = new FileInfo(Location);
                using (StreamWriter sw = fileinfo.AppendText())
                {
                    foreach (var course in courses)
                    {
                        sw.WriteLine($"ID: {course.ID}, Name: {course.Name}");
                    }
                }

                Console.WriteLine("Courses have been successfully written to the file.");

            }
            catch (Exception ex)
            {
                // التعامل مع الأخطاء
                Console.WriteLine($"An error occurred: {ex.Message}");
            }


        }


    }


    public class Score
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public double Value { get; set; }

        public static void AddScore(List<Student1> students, List<Course> courses, List<Score> scores)
        {
            Console.Write("Enter Student ID : ");
            int studentID = int.Parse(Console.ReadLine());
            Console.Write("Enter Course ID for the score: ");
            int courseID = int.Parse(Console.ReadLine());
            Console.Write("Enter Score: ");
            double value = double.Parse(Console.ReadLine());

            scores.Add(new Score { StudentID = studentID, CourseID = courseID, Value = value });

            Console.WriteLine("Score added successfully!");

        }



        public static void DisplayScores(List<Student1> students, List<Course> courses, List<Score> scores)
        {
            Console.WriteLine("Scores List:");
            foreach (var Score in scores)
            {
                var Student1 = students.FirstOrDefault(s => s.ID == Score.StudentID);
                var Course = courses.FirstOrDefault(c => c.ID == Score.CourseID);

                if (Student1 != null && Course != null)
                {
                    Console.WriteLine($"Student: {Student1.Name}, Course: {Course.Name}, Score: {Score.Value}");
                }
                else
                {
                    Console.WriteLine("Invalid data found.");
                }
            }
        }



        public static void PrintScoresToFile(List<Student1> students, List<Course> courses, List<Score> scores)
        {
            try
            {
                // تحديد موقع الملف
                string Location = @"C:\Users\ohood\Desktop\Text File Score\test file1.text";
                FileInfo fileinfo = new FileInfo(Location);

                using (StreamWriter sw = fileinfo.AppendText())
                {
                    sw.WriteLine("List of Scores:");

                    // تكرار كل عنصر في قائمة العلامات
                    foreach (var score in scores)
                    {
                        // العثور على الطالب والمادة المرتبطين بالعلامة
                        var student = students.FirstOrDefault(s => s.ID == score.StudentID);
                        var course = courses.FirstOrDefault(c => c.ID == score.CourseID);

                        if (student != null && course != null)
                        {
                            // كتابة البيانات في الملف
                            sw.WriteLine($"Student: {student.Name}, Course: {course.Name}, Score: {score.Value}");
                        }
                        else
                        {
                            sw.WriteLine("Invalid data found for a score entry.");
                        }
                    }
                }

                Console.WriteLine("Scores have been successfully written to the file.");
            }
            catch (Exception ex)
            {
                // التعامل مع الأخطاء
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}





    



