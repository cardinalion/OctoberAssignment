using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTwo
{
    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string Email { get; set; }
        public List<Order> HistoricOrders { get; set; }
    
        public Customer(string fn, string ln, string e) 
        {
            FirstName = fn;
            LastName = ln;
            Email = e;
            HistoricOrders = new List<Order>();
        }

        public void AddNewOrder()
        {
            Console.WriteLine("Please include ordered products.");
            return;
        }

        public void AddNewOrder(string op)
        {
            HistoricOrders.Add(new Order(this, op));
        }

        public void AddNewOrder(string op, int month, int day, int year)
        {
            DateTime OrderDate = new DateTime(year, month, day);
            if (OrderDate > DateTime.Now) return;
            HistoricOrders.Add(new Order(this, op, OrderDate));
        }

        public void AddNewOrder(string op, int month, int day, int year, int id)
        {
            DateTime OrderDate = new DateTime(year, month, day);
            if (OrderDate > DateTime.Now) return;
            HistoricOrders.Add(new Order(this, op, OrderDate, id));
        }

        public void PrintHistoricOrders()
        {
            foreach (var o in HistoricOrders)
            {
                Console.WriteLine($"{o.OrderNumber} {o.OrderedProduct} {o.OrderDate}");
            }
        }
    }
    class Order 
    {
        static private int CurrentID = 1;
        public int OrderNumber { get; }
        public DateTime OrderDate { get; set; }
        public string OrderedProduct { get; set; }
        public Customer customer { get; }

        public Order(Customer c, string op)
        {
            customer = c;
            OrderedProduct = op;
            OrderDate = DateTime.Now;
            OrderNumber = CurrentID++;
        }

        public Order(Customer c, string op, DateTime od)
        {
            customer = c;
            OrderedProduct = op;
            OrderDate = od;
            OrderNumber = CurrentID++;
        }

        public Order(Customer c, string op, DateTime od, int id)
        {
            for (int i = 0; i < c.HistoricOrders.Count; ++i)
            {
                if (c.HistoricOrders[i].OrderNumber == id)
                {
                    c.HistoricOrders[i].OrderedProduct = op;
                    c.HistoricOrders[i].OrderDate = od;
                    return;
                }
            }
            customer = c;
            OrderedProduct = op;
            OrderDate = od; 
            OrderNumber = id;
            CurrentID = id + 1;
            ++CurrentID;

        }
    }
}
