using CRUDWebApi.Data;
using CRUDWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDWebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        [Route("Employee/all")]
        [HttpGet]
        public HttpResponseMessage GetAllEmployees()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, dbContext.Employees.ToList());
            }
        }

        [Route("Employee/{id}")]
        [HttpGet]
        public HttpResponseMessage GetEmployeedataById(int id)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var emp = dbContext.Employees.FirstOrDefault(e => e.Id == id);
                if (emp != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employe With Id " + id + "Not found in Database");
                }
            }
        }
        
        [Route("Employee/add")]
        [HttpPost]
        public HttpResponseMessage AddEmployee(Employee emp)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                if (emp != null)
                {
                    dbContext.Employees.Add(emp);
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, emp);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Please provide proper input data");
                }
            }
        }

        [Route("Employee/Update/{id}")]
        [HttpPut]
        public HttpResponseMessage UpdateEmployeeData(int id, Employee emp)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var tempEmp = dbContext.Employees.FirstOrDefault(e => e.Id == id);

                if (tempEmp != null)
                {
                    tempEmp.FirstName = emp.FirstName;
                    tempEmp.LastName = emp.LastName;
                    tempEmp.Gender = emp.Gender;
                    tempEmp.City = emp.City;
                    tempEmp.IsActive = emp.IsActive;
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, tempEmp);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with Id = " + id + " Not Found.");
                }
            }
        }
        
        [Route("DeleteEmployee/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteEmplyeeById(int id)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var emp = dbContext.Employees.FirstOrDefault(e => e.Id == id);
                if (emp != null)
                {
                    dbContext.Employees.Remove(emp);
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id = " + id + " Not found");
                }
            }
        }
    }
}
