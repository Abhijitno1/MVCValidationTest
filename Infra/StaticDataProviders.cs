using MVCValidationTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCValidationTest.Infra
{
    public class StaticDataProviders
    {
        public static IEnumerable<SelectListItem> GetRoleTypesList()
        {
            return Enum.GetValues(typeof(RoleType))
                .Cast<RoleType>()
                .OrderBy(roleType => roleType.ToString())
                .Select(roleType => new SelectListItem()
                {
                    Text = roleType.ToString(),
                    Value = ((int)roleType).ToString()
                });
        }

        public static IEnumerable<Employee> GetEmployeeList()
        {
            return new List<Employee>{ 
                new Employee{Id=1, EmployeeName="Amitabh", Designation="Don"},
                new Employee{Id=2, EmployeeName="Virat", Designation="Captain"},
                new Employee{Id=3, EmployeeName="Subhash", Designation="Director"}
            };
        }

    }
}