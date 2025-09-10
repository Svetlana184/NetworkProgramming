using Lab_1_25;
using Lab_1_25.Models;

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

using (SapunovaDemoContext db = new SapunovaDemoContext())
{
    List<Company> companies = db.Companies.ToList();
    foreach (Company company in companies) Console.WriteLine(company.IdCompany + " " + company.Name);

}

using (SapunovaDemoContext db = new SapunovaDemoContext())
{
    List<string> companiesNames = db.Companies.Select(p=>p.Name).ToList();
    foreach(string name in companiesNames) Console.WriteLine(name);
}