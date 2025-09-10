using Lab_1_25;
using Lab_1_25.Models;

using (SapunovaDemoContext db =  new SapunovaDemoContext())
{
    Company c1 = new Company();
    c1.Name = "рога без копыт";
    db.Companies.Add(c1);
    Company c2 = new Company();
    c2.Name = "копыта без рогов";
    db.Companies.Add(c2);
    db.SaveChanges();
}