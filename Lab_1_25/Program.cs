using Lab_1_25;
using Lab_1_25.Models;
using Microsoft.EntityFrameworkCore;



//добавление записей в базу данных
//using (SapunovaDemoContext db =  new SapunovaDemoContext())
//{
//    Company c1 = new Company();
//    c1.Name = "рога без копыт";
//    db.Companies.Add(c1);
//    Company c2 = new Company();
//    c2.Name = "копыта без рогов";
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
//User user1 = new User();
//user1.Name = "Vasya";
//user1.IdCompany = 1;
//db.Add(user1);
//db.SaveChanges();

//1 способ
//List<User> userList = db.Users.Where(p=>p.IdCompany==1).ToList();
//foreach (User user in userList) Console.WriteLine(user.Name);

//2 способ
//var users = (from user in db.Users where user.IdCompany == 1 select user).ToList();
//foreach (User user in users) Console.WriteLine(user.Name);
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
    var user1 = db.Users.OrderBy(p => p.IdUser);
    foreach (User user in user1) Console.WriteLine(user.Name);

    //2 способ
    var users2 = from u in db.Users orderby u.IdUser select u;
    foreach (User user in users2) Console.WriteLine(user.Name);

    //по убыванию
    var user3 = db.Users.OrderByDescending(p => p.IdUser);
    foreach (User user in user3) Console.WriteLine(user.Name);

    //сортировка по нескольким критериям
    var user4 = db.Users.OrderByDescending(p => p.IdUser).ThenBy(u=>u.IdCompany);
    foreach (User user in user4) Console.WriteLine(user.Name);
}
