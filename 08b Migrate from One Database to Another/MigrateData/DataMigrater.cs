using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMigration.MigrateData
{
    internal static class DataMigrater
    {
        private static IEnumerable<Customer> _customers { get; set; } = new List<Customer>();
        private static IEnumerable<Employee> _employees { get; set; } = new List<Employee>();
        private static IEnumerable<Office> _offices { get; set; } = new List<Office>();
        private static IEnumerable<Order> _orders { get; set; } = new List<Order>();
        private static IEnumerable<Orderdetail> _orderdetails { get; set; } = new List<Orderdetail>();
        private static IEnumerable<Payment> _payments { get; set; } = new List<Payment>();
        private static IEnumerable<Product> _products { get; set; } = new List<Product>();
        private static IEnumerable<Productline> _productlines { get; set; } = new List<Productline>();

        private static readonly ClassicmodelsContext _originalDatabaseContext = new ClassicmodelsContext();
        private static readonly MSSQLContext _newDatabaseContext = new MSSQLContext();

        private static void GetData()
        {
            _customers = _originalDatabaseContext.Customers.AsNoTracking().ToList();
            _employees = _originalDatabaseContext.Employees.AsNoTracking().ToList();
            _offices = _originalDatabaseContext.Offices.AsNoTracking().ToList();
            _orders = _originalDatabaseContext.Orders.AsNoTracking().ToList();
            _orderdetails = _originalDatabaseContext.Orderdetails.AsNoTracking().ToList();
            _payments = _originalDatabaseContext.Payments.AsNoTracking().ToList();
            _products = _originalDatabaseContext.Products.AsNoTracking().ToList();
            _productlines = _originalDatabaseContext.Productlines.AsNoTracking().ToList();
        }

        private static void SaveDataToNewDatabase()
        {
            _newDatabaseContext.Customers.AddRange(_customers);
            
            _newDatabaseContext.Employees.AddRange(_employees);
            
            _newDatabaseContext.Offices.AddRange(_offices);
            
            _newDatabaseContext.Orders.AddRange(_orders);

            _newDatabaseContext.Orderdetails.AddRange(_orderdetails);
            
            _newDatabaseContext.Payments.AddRange(_payments);

            _newDatabaseContext.Products.AddRange(_products);

            _newDatabaseContext.Productlines.AddRange(_productlines);

            _newDatabaseContext.SaveChanges();
        }

        public static void MigrateData()
        {
            GetData();
            SaveDataToNewDatabase();
        }
    }
}
