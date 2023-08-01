using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using Microsoft.Data.SqlClient;
//using AspNetCore;
using Microsoft.AspNetCore;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<Student> students = new List<Student>();
        List<Group> groups = new List<Group>();
        List<Marks> marks = new List<Marks>();
        List<StudentInfo> studentInfos = new List<StudentInfo>( );
        ReportInfo model = new ReportInfo();
        ReportResult res = new ReportResult();
        List<String> listStr = new List<String>();




        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = WebApplication1.Properties.Resources.ConnectionString;
        }

        public IActionResult Index()
        {
            return View();
        }

        private void FetchStudentData()
        {
            if(students.Count > 0)
            {
                students.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (10) [id],[name],[surname] FROM [testing].[dbo].[students]";
                dr = com.ExecuteReader();
                while(dr.Read())
                {
                    students.Add(new Student() {Id = dr["id"].ToString()
                    ,Name = dr["name"].ToString()
                    ,Surname = dr["surname"].ToString()
                    });
                }
                con.Close();
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        private void FetchGroupData()
        {
            if (groups.Count > 0)
            {
                groups.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (10) [id_студента],[id_группы_сент],[id_группы_окт],[id_группы_нояб],[id_группы_дек],[id_группы_янв],[id_группы_февр],[id_группы_март],[id_группы_апр],[id_группы_май]  FROM [testing].[dbo].[Groups_2020_2021]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    groups.Add(new Group()
                    {
                        Id = dr["id_студента"].ToString()       
                        ,Sp = dr["id_группы_сент"].ToString()
                        ,Oct =  dr["id_группы_окт"].ToString()
                        ,Nv =  dr["id_группы_нояб"].ToString()
                        ,Dc = dr["id_группы_дек"].ToString()
                        ,Jn = dr["id_группы_янв"].ToString()
                        ,Fbr =  dr["id_группы_февр"].ToString()
                        ,Mrch = dr["id_группы_март"].ToString()
                        ,Apr =  dr["id_группы_апр"].ToString()
                        ,May = dr["id_группы_май"].ToString() 
                        ,year = "20"
                    });
                }
                con.Close();

                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (10) [id_студента],[id_группы_сент],[id_группы_окт],[id_группы_нояб],[id_группы_дек],[id_группы_янв],[id_группы_февр],[id_группы_март],[id_группы_апр],[id_группы_май]  FROM [testing].[dbo].[Groups_2021_2022]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    groups.Add(new Group()
                    {
                        Id = dr["id_студента"].ToString()
                        ,
                        Sp =  dr["id_группы_сент"].ToString()
                        ,
                        Oct =  dr["id_группы_окт"].ToString()
                        ,
                        Nv =  dr["id_группы_нояб"].ToString()
                        ,
                        Dc =  dr["id_группы_дек"].ToString()
                        ,
                        Jn =  dr["id_группы_янв"].ToString()
                        ,
                        Fbr =  dr["id_группы_февр"].ToString()
                        ,
                        Mrch =  dr["id_группы_март"].ToString()
                        ,
                        Apr =   dr["id_группы_апр"].ToString()
                        ,
                        May = dr["id_группы_май"].ToString()
                        ,
                        year = "21"
                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FetchMarksData()
        {
            if (marks.Count > 0)
            {
                marks.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (10) [Id_студента],[Сентябрь],[Октябрь],[Ноябрь],[Декабрь],[Январь],[Февраль],[Март],[Апрель],[Май] FROM [testing].[dbo].[Marks_2020_2021]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    marks.Add(new Marks()
                    {
                        Id = dr["Id_студента"].ToString()
                        
                        ,Sp = dr["Сентябрь"].ToString()
                        ,
                        Oct = dr["Октябрь"].ToString()
                        ,
                        Nv = dr["Ноябрь"].ToString()
                        ,
                        Dc = dr["Декабрь"].ToString()
                        ,
                        Jn = dr["Январь"].ToString()
                        ,
                        Fbr = dr["Февраль"].ToString()
                        ,
                        Mrch = dr["Март"].ToString()
                        ,
                        Apr = dr["Апрель"].ToString()
                        ,
                        May = dr["Май"].ToString()
                        ,
                        year = "20"
                    });
                }
                con.Close();

                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (10) [id_студента],[Сентябрь],[Октябрь],[Ноябрь],[Декабрь],[Январь],[Февраль],[Март],[Апрель],[Май] FROM [testing].[dbo].[Marks_2021_2022]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    marks.Add(new Marks()
                    {
                        Id = dr["id_студента"].ToString()                        
                        ,Sp = dr["Сентябрь"].ToString()                        
                        ,Oct = dr["Октябрь"].ToString()                        
                        ,Nv = dr["Ноябрь"].ToString()                        
                        ,Dc = dr["Декабрь"].ToString()                       
                        ,Jn = dr["Январь"].ToString()                       
                        ,Fbr = dr["Февраль"].ToString()                      
                        ,Mrch = dr["Март"].ToString()                        
                        ,Apr = dr["Апрель"].ToString()                        
                        ,May = dr["Май"].ToString()                        
                        ,year = "21"
                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FetchStudentsInfoData()
        {
            FetchStudentData();
            FetchGroupData();
            FetchMarksData();

            foreach(var stu in students)
            {
                studentInfos.Add(new StudentInfo(){
                    student = stu
                });
            }
            int count = 0;
            for(int i = 0; i < groups.Count; i++)
            {
                if (groups[i].year == "20")
                {
                    studentInfos[i].group1 = groups[i];
                    count++;
                }
                else
                {
                    studentInfos[i-count].group2 = groups[i];
                }
                
            }
            count = 0;
            for (int i = 0; i < marks.Count; i++)
            {
                if (marks[i].year == "20")
                {
                    studentInfos[i].marks1 = marks[i];
                    count++;
                }
                else
                {
                    studentInfos[i-count].marks2 = marks[i];
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Directory()
        {
            
            return View(model);
        }

        [HttpPost]
        public string Update(ReportInfo model1)
        {
            FetchStudentsInfoData();
            var m1 = model1.month1;
            var m2 = model1.month2;
            var gr = model1.group;
            var years = model1.year;

            float final = 0;
            float fl = 0;
            int len = 0;

            foreach (StudentInfo inf in studentInfos)
            {
                fl = inf.checkInfo(model1);
                final = final + fl;
                if(fl != 0)
                {
                    len++;
                }
            }
            final = final / len;
            float t = final;

            res.Year = years;
            res.Group = gr;
            res.Month1 = m1;
            res.Month2 = m2;
            res.Result =final.ToString();

            listStr.Add(years); 
            listStr.Add(gr);
            listStr.Add(m1);
            listStr.Add(m2);
            listStr.Add(final.ToString());
            return "В  " + years + " c " +  m1 + " по " + m2 + "  средний балл группы " + gr + " равен " + final.ToString();
        }

        public IActionResult Reports()
        {
            
            
            return View(listStr);
        }

        public IActionResult Students()
        {
            FetchStudentData();
            return View(students);
        }

        public IActionResult Groups()
        {
            FetchGroupData();
            return View(groups);
        }

        public IActionResult Courses()
        {
            return View();
        }

        public IActionResult Marks()
        {
            FetchMarksData();
            return View(marks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}