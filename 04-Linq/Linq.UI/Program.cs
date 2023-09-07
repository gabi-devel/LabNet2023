using Linq.Entities;
using Linq.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            int cantQueries = 11;
            bool salir = false;

            do {
                Console.WriteLine($"Por favor, ingrese número de ejercicio: hasta el {cantQueries}. Presione cualquier letra para salir.\n");
                string eleccion = Console.ReadLine();
                if (int.TryParse(eleccion, out int n))
                {
                    if (n <= cantQueries && n > 0)
                    {
                        Elegido(n);
                    }
                    else
                    {
                        salir = true;
                    }
                }
                else
                {
                    salir = true;
                }
                Console.Write("\n");
            } while (!salir);
        }
        static void Elegido(int n)
        {
            CustomersLogic customers = new CustomersLogic();
            IEnumerable<Customers> allCustomers = customers.GetAll();

            OrdersLogic orders = new OrdersLogic();
            IEnumerable<Orders> allOrders = orders.GetAll();

            ProductsLogic products = new ProductsLogic();
            IEnumerable<Products> allProducts = products.GetAll();

            CategoriesLogic categories = new CategoriesLogic();
            IEnumerable<Categories> allCategories = categories.GetAll();
    
            switch (n)
            {
                case 1:
                    Console.WriteLine("1. Query para devolver objeto customer:");
                    Devolver_Objeto_Customer(allCustomers);
                    break;
                case 2:
                    Productos_Sin_Stock(allProducts);
                    break;
                case 3:
                    Productos_Stock_Mas_De_Tres(allProducts);
                    break;
                case 4:
                    Customers_Region_WA(allCustomers);
                    break;
                case 5:
                    Console.WriteLine("5. ProductID 789 existente o nulo");
                    Product_789(allProducts);
                    break;
                case 6:
                    Console.WriteLine("6. Customers en Mayuscula y en Minuscula");
                    Nombre_Customers(allCustomers);
                    break;
                case 7:
                    Join_Customers_Orders(allOrders, allCustomers);
                    break;
                case 8:
                    Customers_WA_Solo3(allCustomers);
                    break;
                case 9:
                    Productos_Ordenados_Nombre(allProducts);
                    break;
                case 10:
                    Productos_Orden_UnitsInStock_Desc(allProducts);
                    break;
                case 11:
                    Join_Categorias_de_Productos(allCategories, allProducts);
                    break;
                    
            }
        }

        static void Devolver_Objeto_Customer(IEnumerable<Customers> allCustomers)
        {
            var query3 = (from customer in allCustomers
                         orderby customer.ContactName ascending
                         select customer).Take(10);

            foreach (var v in query3)
            {
                Console.WriteLine($"{v.ContactName} - {v.Address} - {v.City}");
            }
        }
        static void Productos_Sin_Stock(IEnumerable<Products> allProducts)
        {
            Console.WriteLine("2. Productos sin stock");
            var query = allProducts.Where(e => e.UnitsInStock == 0)
                                    .OrderBy(e => e.UnitPrice)
                                    .Select(e => e);
            foreach (var p in query)
            {
                Console.WriteLine($"{p.ProductName} - Precio: {p.UnitPrice}");
            }
        }
        static void Productos_Stock_Mas_De_Tres(IEnumerable<Products> allProducts)
        {
            Console.WriteLine("3. Productos que tienen stock y que cuestan más de 3 por unidad");
            var query2 = allProducts.Take(10)
                                    .Where(e => e.UnitsInStock > 0)
                                    .Where(e => e.UnitPrice > 3)
                                    .Select(e => new
                                     {
                                         e.ProductName,
                                         e.UnitPrice,
                                         e.QuantityPerUnit
                                     });
            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }
        }

        static void Customers_Region_WA(IEnumerable<Customers> allCustomers)
        {
            Console.WriteLine("4. Customers de la Región WA");
            var query4 = allCustomers.Where(x => x.Region == "WA");

            foreach (var v in query4)
            {
                Console.WriteLine($"{v.CompanyName} - {v.ContactName} - {v.Address}");
            }
        }
        static void Product_789(IEnumerable<Products> allProducts)
        {
            var query5 = allProducts.FirstOrDefault(e => e.ProductID == 789);

            try
            {
                if (query5 != null) Console.WriteLine(query5.ProductName);
                else throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("Se ha producido una Excepción: El ID no se encuentra en la base de datos");
            }
        }

        static void Nombre_Customers(IEnumerable<Customers> allCustomers)
        {
            var query6 = (from c in allCustomers
                         select c.ContactName.ToLower())
                         .Take(10);
            foreach (var c in query6)
            {
                Console.WriteLine($"{c.ToUpper()} - {c}");
            }
        }

        static void Join_Customers_Orders(IEnumerable<Orders> allOrders, IEnumerable<Customers> allCustomers)
        {
            Console.WriteLine("7. Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1 / 1 / 1997.");
            var orderWA = from custom in allCustomers
                          join ord in allOrders
                          on custom.CustomerID equals ord.CustomerID
                          where custom.Region == "WA"
                          && ord.OrderDate > new DateTime(1997, 1, 1)
                          select new
                          {
                              Customer = custom,
                              OrderID = ord.OrderID,
                              OrderDate = ord.OrderDate
                          };
            foreach (var o in orderWA)
            {
                Console.WriteLine($"Cliente: {o.Customer.CustomerID} - Id orden: {o.OrderID} - Fecha: {o.OrderDate}");
            }
        }

        static void Customers_WA_Solo3(IEnumerable<Customers> allCustomers)
        {
            Console.WriteLine("8.Query para devolver los primeros 3 Customers de la Región WA");
            var query = allCustomers.Where(x => x.Region == "WA")
                                     .OrderBy(x => x.CustomerID)
                                     .Take(3).ToList();

            foreach (var v in query)
            {
                Console.WriteLine($"{v.CompanyName} - {v.ContactName} - {v.Address}");
            }
        }

        static void Productos_Ordenados_Nombre(IEnumerable<Products> allProducts)
        {
            Console.WriteLine("9.Query para devolver lista de productos ordenados por nombre");
            var query2 = allProducts.Take(10)
                                    .OrderBy(e => e.ProductName)
                                    .Select(e => e);
            foreach (var item in query2)
            {
                Console.WriteLine($"{item.ProductName} - {item.UnitPrice}");
            }
        }
        static void Productos_Orden_UnitsInStock_Desc(IEnumerable<Products> allProducts)
        {
            Console.WriteLine("10.Query para devolver lista de productos ordenados por unit in stock de mayor a menor.");
            var query = (from products in allProducts
                        orderby products.UnitsInStock descending
                        select products).Take(10);
            foreach (var p in query)
            {
                Console.WriteLine($"{p.ProductName} - {p.UnitsInStock} ");
            }
        }

        static void Join_Categorias_de_Productos(IEnumerable<Categories> allCategories, IEnumerable<Products> allProducts)
        {
            Console.WriteLine("11.Query para devolver las distintas categorías asociadas a los productos");
            var catProd = from categories in allCategories
                          join products in allProducts
                          on categories.CategoryID equals products.CategoryID
                          select new
                          {
                              Categ = categories.CategoryName,
                              Prod = products.ProductName
                          };
            foreach (var item in catProd)
            {
                Console.WriteLine($"{item.Categ} - {item.Prod}");
            }
        }
    }
}
