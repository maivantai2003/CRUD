using Microsoft.AspNetCore.Mvc;
using PaginationAndSort.Models.Domain;
using PaginationAndSort.Models;
namespace PaginationAndSort.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public EmployeeController(DatabaseContext _databaseContext) {
            this._databaseContext = _databaseContext;
        }
        public IActionResult AddEmployee()
        {
            var employee = new List<Employee>()
            {
                new Employee()
                {
                    Name="John",Email="john@xyz.com"
                },new Employee()
                {
                    Name="Mary",Email="Mary@xyz.com"
                },new Employee()
                {
                    Name="Max",Email="max@xyz.com"
                },new Employee()
                {
                    Name="jack",Email="jack@xyz.com"
                },
                new Employee()
                {
                    Name="emp5",Email="emp5@xyz.com"
                },
                new Employee()
                {
                    Name="emp6",Email="emp6@xyz.com"
                },
                new Employee()
                {
                    Name="emp7",Email="emp7@xyz.com"
                }, new Employee()
                {
                    Name="emp8",Email="emp8@xyz.com"
                },
                new Employee()
                {
                    Name="emp9",Email="emp9@xyz.com"
                },
                new Employee()
                {
                    Name="emp10",Email="emp10@xyz.com"
                },
                 new Employee()
                {
                    Name="emp11",Email="emp11@xyz.com"
                },
                new Employee()
                {
                    Name="emp12",Email="emp12@xyz.com"
                },
                new Employee()
                {
                    Name="emp13",Email="emp13@xyz.com"
                }
            };
            _databaseContext.AddRange(employee);
            try
            {
                _databaseContext.SaveChanges();
                return Content("Fail");
            }
            catch (Exception ex) {
                return Content("Done");
            } 
        }
        public IActionResult Employees(string term="",string orderBy="",int currentPage=1)
        {
            term= string.IsNullOrEmpty(term)?"":term.ToLower();
            var empData = new EmployeeViewModel();
            empData.NameSort = string.IsNullOrEmpty(orderBy)?"name_desc":"";
            empData.EmailSort = orderBy == "email" ? "email_desc" : "email";
            var employees = (from i in _databaseContext.Employees where term=="" || i.Name.ToLower().StartsWith(term)  select new Employee { 
                Id = i.Id,
                Name = i.Name,
                Email = i.Email,
            });
            switch (orderBy)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(e => e.Name);
                    break;
                case "email_desc":
                    employees = employees.OrderByDescending(e => e.Email);
                    break;
                case "Email":
                    employees = employees.OrderBy(e => e.Email);
                    break;
                default:
                    employees=employees.OrderBy(e=>e.Name);
                    break;
            }
            var totalRecord=employees.Count();
            int PageSize = 5;
            int totalPage =(int)Math.Ceiling(totalRecord /(double)PageSize);
            employees=employees.Skip((currentPage-1)*PageSize).Take(PageSize);
            //current=1 skip=(1-1=0) take=5
            empData.PageSize = PageSize;
            empData.CurrentPage = currentPage;
            empData.TotalPages = totalPage;
            empData.Term=term;
            empData.OrderBy=orderBy;
            empData.Employees = employees;
            return View(empData);
        }

    }
}
