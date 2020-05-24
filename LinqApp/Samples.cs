using System;
using System.Collections.Generic;
using System.Linq;


namespace LinqApp
{
    public class Samples
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        public Samples()
        {
            LoadData();
        }

        public void LoadData()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();

            var d1 = new Dept
            {
                Deptno = 1,
                Dname = "HR",
                Loc = "Poznan"
            };

            var d2 = new Dept
            {
                Deptno = 2,
                Dname = "It",
                Loc = "Wroclaw"
            };

            var d3 = new Dept
            {
                Deptno = 3,
                Dname = "Business",
                Loc = "Warsaw"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;

            var e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Krzysztof Nowak",
                HireDate = DateTime.Now.AddMonths(-1),
                Job = "Backend programmer & manager",
                Mgr = null,
                Salary = 6000
            };

            var e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Halina Kowalska",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Grzegorz Staniszewski",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Dev Ops",
                Mgr = e1,
                Salary = 7000
            };

            
            var e4 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Piotr Kowalski",
                HireDate = DateTime.Now.AddMonths(-10),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            var e5 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Marzena Kwiatkowska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = e4,
                Salary = 6000
            };

          
            var e6 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Mariusz Wasilewski",
                HireDate = DateTime.Now.AddMonths(-20),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };


            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            Emps = empsCol;
        }



        public void Zadanie1()
        {
      
            var res = from emp in Emps
                      where emp.Job == "Backend programmer"
                      select new
                      {
                          Nazwisko = emp.Ename,
                          Zawod = emp.Job
                      };


            
            var res1 = Emps
                .Where(emp => emp.Job == "Backend programmer")
                .Select(emp => new
                {
                    Nazwisko = emp.Ename,
                    Zawod = emp.Job
                });
        }

       
        public void Zadanie2()
        {
            var res = Emps
                .Where(emp => emp.Job == "Frontend programmer" && emp.Salary > 1000)
                .OrderByDescending(emp => emp.Ename);
        }

        public void Zadanie3()
        {
            var res = Emps.Max(e => e.Salary);
        }

        public void Zadanie4()
        {
            var res = Emps
                .Where(e => e.Salary == Emps.Max(emp => emp.Salary));
        }

        public void Zadanie5()
        {
            var res = Emps
                .Select(e => new
                {
                    Nazwisko = e.Ename,
                    Praca = e.Job
                });
        }


        public void Zadanie6()
        {
            var res = Emps
                .Join(Depts,
                    e => e.Deptno,
                    d => d.Deptno,
                    (emp, dept) => new
                    {
                        emp.Ename,
                        emp.Job,
                        dept.Dname
                    });
        }

        public void Zadanie7()
        {
            var res = Emps
                .GroupBy(e => e.Job)
                .Select(e => new
                {
                    Praca = e.Key,
                    LiczbaPracownikow = e.Count()
                });
        }

        public void Zadanie8()
        {
            var res = Emps.Any(e => e.Job == "Manager");
        }

        public void Zadanie9()
        {
            var res = Emps
                .OrderByDescending(e => e.HireDate)
                .First(e => e.Job == "Frontend programmer");
        }

        
        public void Zadanie11()
        {
            var res = Emps
                .Aggregate((emp, max) => max.Salary < emp.Salary ? emp : max);
        }

        public void Zadanie12()
        {
            var res = Emps
                .SelectMany(emp => Depts.Where(d => d.Deptno == emp.Deptno),
                    (emp, dept) =>
                        new
                        {
                            emp,
                            dept
                        });
        }
    }
}
}
