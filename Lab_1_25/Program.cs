using System.Linq;
using Lab_1_25;
using Lab_1_25.Models;
using Microsoft.EntityFrameworkCore;



//добавление записей в базу данных
//using (SapunovaDemoContext db = new SapunovaDemoContext())
//{
//    Country russia = new Country { Name = "Russia" };
//    Country usa = new Country { Name = "USA" };
//    db.Countries.Add(russia);
//    db.Countries.Add(usa);
//    db.SaveChanges();

//    Company c1 = new Company();
//    c1.Name = "рога без копыт";
//    c1.IdCountry = db.Countries.FirstOrDefault(p => p.Name == "Russia")!.IdCountry ;
//    db.Companies.Add(c1);

//    Company c2 = new Company();
//    c2.Name = "копыта без рогов";
//    c2.IdCountry = db.Countries.FirstOrDefault(p => p.Name == "Russia")!.IdCountry;
//    db.Companies.Add(c2);

//    db.SaveChanges();
//}



//выборка
//using (SapunovaDemoContext db = new SapunovaDemoContext())
//{
//    List<Company> companies = db.Companies.ToList();
//    foreach (Company company in companies) Console.WriteLine(company.IdCompany + " " + company.Name);
//}
//using (SapunovaDemoContext db = new SapunovaDemoContext())
//{
//    List<string> companiesNames = db.Companies.Select(p=>p.Name).ToList();
//    foreach(string name in companiesNames) Console.WriteLine(name);
//}



//where - фильтр данных
//using (SapunovaDemoContext db = new SapunovaDemoContext())
//{
//    User user1 = new User();
//    user1.Name = "Vasya";
//    user1.IdCompany = 1;
//    db.Add(user1);
//    db.SaveChanges();

//    //1 способ
//    List<User> userList = db.Users.Where(p => p.IdCompany == 1).ToList();
//    foreach (User user in userList) Console.WriteLine(user.Name);

//    //2 способ
//    var users = (from user in db.Users where user.IdCompany == 1 select user).ToList();
//    foreach (User user in users) Console.WriteLine(user.Name);
//}



//like
/* % - любая подстрока
 * _ одиночный символ
 * [ ] один символ в квадратных скобках
 * [-] символ из диапазона
 * [^] не соответствует символ
 */
//1 способ
//using (SapunovaDemoContext db = new SapunovaDemoContext())
//{
//    var like1 = db.Users.Where(p=> EF.Functions.Like(p.Name, "_a%")).ToList();
//    foreach (User l in like1 ) Console.WriteLine(l.Name);
//}
//2 способ
//using (SapunovaDemoContext db = new SapunovaDemoContext())
//{
//    var like2 = from u in db.Users where EF.Functions.Like(u.Name, "_a%") select u;
//    foreach (User l in like2) Console.WriteLine(l.Name);
//}



//Find FindAsync - для выборки одного объекта
//using (SapunovaDemoContext db = new SapunovaDemoContext())
//{
//    User? us = db.Users.Find(2);
//    Console.WriteLine(us!.Name);

//    User? us1 = db.Users.FirstOrDefault(p => p.IdUser == 3)??new User();
//    Console.WriteLine(us1?.Name);
//}


//сортировка
using (SapunovaDemoContext db = new SapunovaDemoContext())
{
    //1 способ
    //var user1 = db.Users.OrderBy(p => p.IdUser);
    //foreach (User user in user1) Console.WriteLine(user.Name);

    //2 способ
    //var users2 = from u in db.Users orderby u.IdUser select u;
    //foreach (User user in users2) Console.WriteLine(user.Name);

    //по убыванию
    //var user3 = db.Users.OrderByDescending(p => p.IdUser);
    //foreach (User user in user3) Console.WriteLine(user.Name);

    //сортировка по нескольким критериям
    //var user4 = db.Users.OrderByDescending(p => p.IdUser).ThenBy(u=>u.IdCompany);
    //foreach (User user in user4) Console.WriteLine(user.Name);



    //соединение таблиц (двух)
    //1 способ
    //var users5 = db.Users.Join(db.Companies, 
    //    u=>u.IdCompany, 
    //    c =>c.IdCompany,
    //    (u,c) => new
    //    {
    //        Name = u.Name,
    //        Company = c.Name
    //    });
    //foreach(var user in users5) Console.WriteLine(user.Name + " " + user.Company);
    //2 способ
    //var users6 = from u in db.Users
    //             join c in db.Companies on u.IdCompany equals c.IdCompany
    //             select new {Id = u.IdUser, Name = u.Name, Company = c.Name};
    //foreach (var user in users6) Console.WriteLine(user.Name + " " + user.Company);


    //соединение таблиц (трех)
    var users7 = from u in db.Users
                 join c in db.Companies on u.IdCompany equals c.IdCompany
                 join r in db.Countries on c.IdCountry equals r.IdCountry
                 select new {Name = u.Name, Company = c.Name, Country = r.Name};
    foreach(var user in users7) Console.WriteLine(user.Name+" " + user.Company + " " + user.Country);


    //группировка данных
    //1 способ
    var groups1 = from u in db.Users
                 group u by u.IdCompany into g
                 select new
                 {
                     g.Key,
                     Count = g.Count(),
                 };
    foreach (var user in groups1) Console.WriteLine(user.Key + " " + user.Count);

    //2 способ
    var groups2 = db.Users.GroupBy(p => p.IdCompany).Select(g => new { g.Key, Count = g.Count() });
    foreach (var user in groups2) Console.WriteLine(user.Key + " " + user.Count);


    //агрегатные операции
    //наличие элемента Any()
    Console.WriteLine(db.Countries.Any(p=>p.Name=="Russia"));

    //все элементы удовлетворяют критерию
    Console.WriteLine(db.Companies.All(c=>c.IdCountry==1));

    //количество элементов в выборке
    Console.WriteLine(db.Users.Count());

    //кол-во пользователей старше 30 лет
    Console.WriteLine(db.Users.Count(p=>p.Age>30));

    //минимальное, максимальное и среднее значение
    Console.WriteLine(db.Users.Max(p=>p.Age));
    Console.WriteLine(db.Users.Min(p => p.Age));
    Console.WriteLine(db.Users.Average(p => p.Age));

    //сумма
    Console.WriteLine(db.Users.Sum(p=>p.Age));
}
