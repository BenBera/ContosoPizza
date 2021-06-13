using ContosoPizza.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContosoPizza.Services

{
    public static class CustomerService
    {
     static List<Customer> Customers {get;}
    static int nextId = 3;
    static CustomerService()
    {

        Customers = new List<Customer>
        {
            new Customer {Id = 1, First_name = "Ben", Last_name = "Bera", Location = "Nairobi", Gender = "Male"},
            new Customer {Id = 2, First_name = "Tonny", Last_name = "Aesho", Location = "Kitale", Gender = "Male"},
            new Customer {Id = 3, First_name = "Kendy", Last_name = "Molly", Location = "Mombasa", Gender = "Female"}
        };
    }
    public static List<Customer> GetAllCustomers() => Customers;
    public static Customer GetCustomer(int id) => Customers.FirstOrDefault(c => c.Id == id);
    public static void AddCustomer(Customer customer)
    {
        customer.Id = nextId++;
        Customers.Add(customer);
    }
    public static void DeleteCustomer(int id)
    {
        var customer = GetCustomer(id);
        if (customer is null)
        return;
        Customers.Remove(customer);
    }
    public static void UpdateCustomer(Customer customer)
    {
        var index = Customers.FindIndex(c => c.Id == customer.Id);
        if(index == -1)
        return;
        Customers[index] = customer;
    }
    }
}