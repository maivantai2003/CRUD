﻿using PaginationAndSort.Models.Domain;

namespace PaginationAndSort.Models
{
    public class EmployeeViewModel
    {
        public IQueryable<Employee> Employees { get; set; }  
        public string NameSort {  get; set; }
        public string EmailSort {  get; set; }
        public int PageSize {  get; set; }  
        public int CurrentPage {  get; set; }
        public int TotalPages { get; set; } 
        public string Term {  get; set; }  
        public string OrderBy {  get; set; }
    }
}
