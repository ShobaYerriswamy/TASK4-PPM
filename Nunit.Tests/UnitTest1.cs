using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MODEL;

namespace PPM.Tests
{
    [TestFixture]
    public class Test
    {
        
        [Test]
        public void TestCase1()
        {
            ProjectManager projectManager = new ProjectManager();
            Project project = new Project("Test", "17/08/2022", "17/09/2023",5);
            projectManager.AddingProjects(project);
            Assert.True(projectManager.Exist(5));
        }

        [Test]
        public void TestCase2()
        {
            EmployeeManager employeeManager=new EmployeeManager();
            Employee employee = new Employee(4,"Roopa","Mandlole","roopa@gmail.com","9870675432","D-home",2,"TeamLead");
            employeeManager.AddEmployee(employee);
            Assert.True(employeeManager.Exist(4));
            Assert.False(employeeManager.Exist(1));  
        }

        [Test]
        public void TestCase3()
        {
            RoleManager roleManager=new RoleManager();
            Role role = new Role(8,"Software Engineer");
            roleManager.RoleAdd(role);
            Assert.True(roleManager.Exist(8));
        }


        [Test]
        public void TestAddingProjects()
        {
            List<Project> addingprojectList =new List<Project>();
            Project project1 = new Project("Test", "17/08/2022", "17/09/2023",5);
            addingprojectList.Add(project1);
        }


        [Test]
        public void TestAddEmployee()
        {
            List<Employee> addingemployeeList = new List<Employee>();
            Employee employee1 = new Employee(2,"Roopa","Mandlole","roopa@gmail.com","9870675432","D-home",2,"TeamLead");
            addingemployeeList.Add(employee1);
        }


        [Test]
        public void TestRoleAdd()
        {
            List<Role> addingroleList = new List<Role>();
            Role role1 = new Role(8,"Software Engineer");
            addingroleList.Add(role1);
        }
    }
}

