using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEntityOperation;
using MODEL;

namespace Domain
{
    public class ProjectManager : IEntityOperationProject
    {
        public List<Project> projects = new List<Project>();
        EmployeeManager EM = new EmployeeManager();


        public void AddingProjects(Project project)
        {
            projects.Add(project);
        }

        public void ViewProject(Project project)
        {
            Console.WriteLine("Name of the Project - " + project.projectName + "\n Project ID - " + project.id + "\n Start Date of Project -" + project.startDate + "\n End Date of Project -" + project.endDate);
        }

        public void DisplayAllProjects()
        {
            if(projects.Count == 0)
            {
                Console.WriteLine("The List is Empty!");
            }
            else
            {
                foreach (var i in projects)
                {
                    ViewProject(i);
                }
            }
        }

        public Boolean IfNoEmployeesInProject(int pid)
        {
            for (int i=0; i<projects.Count; i++)
            {
                if(projects[i].id == pid && projects[i].EmployeeListfromEmployeeManager.Count==0)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Employee> SearchingForEmployee (int readingProjectId)
        {
            foreach(Project i in projects)
            {
                i.EmployeeListfromEmployeeManager.Sort();
                if(!IfNoEmployeesInProject(readingProjectId) && i.id == readingProjectId)
                {
                    return i.EmployeeListfromEmployeeManager;
                }
            }
            return null;
        }

        public void Display()
        {
            for (int i=0; i<projects.Count; i++)
            {
                Console.WriteLine("Project Name - " + projects[i].projectName);
                Console.WriteLine(" ****************************************** ");
                Console.WriteLine("Below are the Details of Employees in this Project");
                for(int j=0; j<projects[i].EmployeeListfromEmployeeManager.Count; j++)
                {
                    Console.WriteLine(" ------------------------------------------- ");
                    Console.WriteLine(projects[i].EmployeeListfromEmployeeManager[j].employeefirstName+ " [" +projects[i].EmployeeListfromEmployeeManager[j].roleName + "]");
                    Console.WriteLine(" ------------------------------------------- ");
                }      
            }
        }

        public void DisplayEmployeesInProjectById(int readingProjectId)
        {
            List<Employee> employee = SearchingForEmployee (readingProjectId);
            if(employee != null)
            {
                for(int j=0; j<projects.Count; j++)
                {
                    if(projects[j].id == readingProjectId)
                    {
                        Console.WriteLine("Project Name - " + projects[j].projectName);
                    }
                }
                Console.WriteLine(" ****************************************** ");
                Console.WriteLine("Below are the Details of Employees in this Project");
                for(int i=0; i<employee.Count; i++)
                {
                    Console.WriteLine(" ------------------------------------------- "); 
                    Console.WriteLine(employee[i].employeefirstName + " [" + employee[i].roleName + "]");
                }   
            }

            else
            {
                Console.WriteLine("No Employees in this Project");
            }
        }
        
        public void EmployeeToProject (int pid, Employee ename)
        {
            if(EM.Exist(pid))
            {
                for(int i=0; i<projects.Count; i++)
                {
                    if(projects[i].id == pid)
                    {
                        projects[i].EmployeeListfromEmployeeManager.Add(ename);
                    }
                }
            }

            else
            {
                Console.WriteLine("With this ID the Employee already exists in this Project");
                Console.WriteLine("Enter any key to get Main Menu");
                Console.ReadLine();
            }
        }

        public Project SearchingProject(List<Project> projects, int first , int last, int pid)
        {
            if(first <= last)
            {
                int midpoint = (first+last) / 2;
                if (projects[midpoint].id == pid)
                {
                    return projects[midpoint];
                }
                else if (projects[midpoint].id > pid)
                {
                    return SearchingProject(projects, first, midpoint-1, pid);
                }
                else if (projects[midpoint].id < pid);
                {
                    return SearchingProject(projects, midpoint+1, last, pid);
                }
            }
            return null;
        }

        public void AddingEmployeeToProject(int pid, Employee ename)
        {
            foreach(Project i in projects)
            {
                if(i.id == pid)
                {
                    i.EmployeeListfromEmployeeManager.Add(ename);
                }
            }
        }

        public void DeleteProject(int pid, Project project)
        {
            for (int i=0; i<projects.Count; i++)
            {
                if(projects[i].id == pid)
                {
                    projects.Remove(project);
                }
            }
        }

        public void EmployeeFromProject(int pid, Employee ename)
        {
            for (int i=0; i<projects.Count; i++)
            {
                for(int j=0; j<projects[i].EmployeeListfromEmployeeManager.Count; j++)
                {
                    if(projects[i].id == pid)
                    {
                        if(projects[i].EmployeeListfromEmployeeManager.Count !=0)
                        {
                            projects[i].EmployeeListfromEmployeeManager.Remove(ename);
                        }
                        else
                        {
                            Console.WriteLine("No Employee Found in the Project to Delete");
                        }
                    }
                }
            }
        }

        public void DeleteEmployeeFromProject(int eid, Employee ename)
        {
            for(int i=0; i<projects.Count; i++)
            {
                for(int j=0; j<projects[i].EmployeeListfromEmployeeManager.Count; j++)
                {
                    if(projects[i].EmployeeListfromEmployeeManager[j].employeeID == eid)
                    {
                        projects[i].EmployeeListfromEmployeeManager.Remove(ename);
                    }
                }
            }
        }

        public Boolean Exist(int pid)
        {
            for(int i=0; i<projects.Count; i++)
            {
                if(pid== projects[i].id)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean IfExistsInEmployee(int employeeid)
        {
            for (int i=0; i<projects.Count; i++)
            {
                for (int j=0; j<projects[i].EmployeeListfromEmployeeManager.Count; j++)
                {
                    if(employeeid == projects[i].EmployeeListfromEmployeeManager[j].employeeID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Boolean IfExistsInEmployee(int employeeid, int pid)
        {
            for (int i=0; i<projects.Count; i++)
            {
                if(pid == projects[i].id)
                {
                    for (int j=0; j<projects[i].EmployeeListfromEmployeeManager.Count; j++)
                    {
                        if(employeeid == projects[i].EmployeeListfromEmployeeManager[j].employeeID)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
        public void ShowProject(int eid)
        {
            projects.Sort();
            int first = 0;
            int last = projects.Count -1;
            Project project = SearchingProject(projects, first, last, eid);
            if(project != null)
            {
                ViewProject(project);
            }
            else
            {
                Console.WriteLine("No Project Found with this ID");
            }
        }

        public void SearchProjectByName(string search)
        {
            var match = projects.Where(c => c.projectName.Contains(search));
            foreach(var i in match)
            {
                Console.WriteLine("Name of the Project - " + i.projectName + "\n Project ID - " + i.id + "\n Start Date of Project -" + i.startDate + "\n End Date of Project -" + i.endDate);
            }
        }
    }
    

    public class EmployeeManager : IEntityOperationEmployee
    {
        public List<Employee> employeeList = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employeeList.Add(employee);
        }

        public void ViewEmployee(Employee employee)
        {
            Console.WriteLine("Employee ID -" + employee.employeeID + "\n Employee First Name -" + employee.employeefirstName + "\n Employee Last Name -" + employee.lastName + "\n Employee Email ID -" + employee.email + "\n Employee Mobile Number  -" + employee.mobile + "\n Employee Address -" + employee.address + "\n  Role ID -" + employee.roleId + "\n Role Name -" + employee.roleName);
        }

        public Employee EmployeeDetails(int eid)
        {
            Employee employee = new Employee();
            for(int i=0; i<employeeList.Count; i++)
            {
                if(eid == employeeList[i].employeeID)
                {
                    employee = employeeList[i];
                    return employee;
                }
            }
            return employee;
        }

        public void ShowEmployees() 
        {
            if(employeeList.Count == 0)
            {
                Console.WriteLine("No Employees Available");
            }
            else
            {
                foreach (var i in employeeList)
                {
                    ViewEmployee(i);
                }
            }
        }

        public Employee SerachingEmployeeInEmployeeList(List<Employee>list, int first, int last, int x)
        {
            if (first <= last)
            {
                int midpoint = (first+last) / 2;
                if (list[midpoint].employeeID == x)
                {
                    return list[midpoint];
                }
                else if (list[midpoint].employeeID > x)
                {
                    return SerachingEmployeeInEmployeeList(list, first, midpoint-1, x);
                }
                else if (list[midpoint].employeeID < x)
                {
                    return SerachingEmployeeInEmployeeList(list, midpoint+1 ,last, x);
                }
            }
            return null;
        }

        public void ShowEmployee(int eid)
        {
            employeeList.Sort();
            int first = 0;
            int last = employeeList.Count -1;
            Employee x = SerachingEmployeeInEmployeeList(employeeList, first, last, eid);
            if (x != null)
            {
                Console.WriteLine("Employee ID - " + x.employeeID + "\n Employee First Name - " + x.employeefirstName + "\n Employee Last Name - " + x.lastName + "\n Employee Email ID - " + x.email + "\n Employee Mobile Number - " + x.mobile + "\n Employee Address - " + x.address + "\n Employee Role ID - " + x.roleId + "\n Employee Role Name - " + x.roleName);
            }
            else
            {
                Console.WriteLine("Employee Not Found");
            }     
        }

        public Boolean Exist(int eid)
        {
            for(int i=0; i<employeeList.Count; i++)
            {
                if(employeeList[i].employeeID == eid)
                {
                    return true;
                }       
            }
            return false;
        }

        public void DeleteEmployee(int employeeId, Employee employee)
        {
            for (int i=0; i<employeeList.Count; i++)
            {
                if (employeeList[i].employeeID == employeeId)
                {
                    employeeList.Remove(employee);
                }
            }
        }

        public Boolean IfExistsByRole(int roleId)
        {
            for (int i=0; i<employeeList.Count; i++)
            {
                if (employeeList[i].roleId == roleId)
                {
                    return true;
                }
            }
            return false;
        }
    }

 
    public class RoleManager : IEntityOperationRole
    {
        public List<Role> roleList = new List<Role>();

        public void RoleAdd(Role role)
        {
            roleList.Add(role);
        } 

        public void ViewRole()
        {
            foreach (Role i in roleList)
            {
                Console.WriteLine("Name of the Role -" + i.roleName+ "\n Role ID - " + i.roleId);
            }
        }

        public Role SearchingRole (List<Role> roleList, int first, int last, int roleId)
        {
            if (first <= last)
            {
                int midpoint = (first+last) / 2;
                if (roleList[midpoint].roleId == roleId)
                {
                    return roleList[midpoint];
                }
                else if (roleList[midpoint].roleId < roleId)
                {
                    return SearchingRole(roleList, midpoint+1, last, roleId);
                }
                else if (roleList[midpoint].roleId > roleId)
                {
                    return SearchingRole(roleList, first, midpoint-1, roleId);
                }
            }
            return null;
        }

        public void ListRoleById(int roleId)
        {
            roleList.Sort();
            int first = 0;
            int last = roleList.Count -1;
            Role roleSelect = SearchingRole(roleList, first, last, roleId);
            if (roleSelect != null)
            {
                Console.WriteLine(" Name of the Role - " + roleSelect.roleName + "\n Role ID - " + roleSelect.roleId);
            }
            else
            {
                Console.WriteLine("Role with this roleSelect Id does not Exist");
            }
        }

        public void DeleteRole (int roleId)
        {
            for (int i=0; i<roleList.Count; i++)
            {
                if (roleList[i].roleId == roleId)
                {
                    roleList.RemoveAt(i);
                }
            }
        }

        public Boolean Exist(int roleId)
        {
            for (int i = 0; i < roleList.Count; i++)
            {
                if (roleList[i].roleId == roleId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}