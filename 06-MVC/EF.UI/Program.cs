using EF.Entities;
using EF.Logic;
using System;
using System.Linq;

namespace EF.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 4) Realizar una consulta simple de al menos dos Entidades diferentes y mostrar esta información de alguna manera.

            // Empleados ordenados por orden de contratación descendente
            EmployeesLogic employees = new EmployeesLogic();
            var allEmployees = employees.GetAll();
            var descendentHireDate = allEmployees.OrderByDescending(employee => employee.HireDate);

            Console.WriteLine("HireDate descendente:");
            foreach (var employee in descendentHireDate)
            {
                Console.WriteLine($"{employee.EmployeeID} - {employee.FirstName} {employee.LastName} - {employee.HireDate}");
            }

            // Órdenes de la ciudad de "Rio de Janeiro"
            OrdersLogic orders = new OrdersLogic();
            var allOrders = orders.GetAll();
            var placeOrder = allOrders.Where(order => order.ShipCity == "Rio de Janeiro").Take(5);

            Console.WriteLine("Ordenes para Río de Janeiro:");
            foreach (var order in placeOrder)
            {
                Console.WriteLine($"{order.OrderID} - {order.ShipCity} - {order.ShipAddress}");
            }

            // 5) ABM

            /* Permite agregar una fila extra a los datos de origen de la base de Datos Northwind,
            luego decidir si modificar esa fila extra agregada y luego decidir si eliminarla o no. */
            CategoriesLogic categories = new CategoriesLogic();

            string letra;
            bool validate = false;

            Console.WriteLine("Desea agregar una nueva categoría? S / N");
            do
            {
                letra = Console.ReadLine().ToLower();

                if (letra == "s" || letra == "n")
                {
                    validate = true;
                }
                else
                {
                    Console.WriteLine("Por favor, escriba S o N.");
                }
            } while (!validate);

             
            if (letra == "s")
            {
                categories.Add(new Categories
                {
                    CategoryName = "Nueva",
                    Description = "Respectiva Descripción"
                });

                Console.WriteLine("Se ha agregado una nueva categoría por defecto. Desea personalizarla? S/N");
                do
                {
                    letra = Console.ReadLine().ToLower();

                    if (letra == "s" || letra == "n")
                    {
                        validate = true;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, escriba S o N.");
                    }
                } while (!validate);

                if (letra == "s")
                {
                    Console.WriteLine("Ingrese un nombre para la categoría:");
                    string name = Console.ReadLine();
                    
                    Console.WriteLine("Ingrese una descripción para la categoría:");
                    string desc = Console.ReadLine();

                    categories.UpdateLast(name, desc);
                    Console.WriteLine("Estos son los registros de la tabla actuales:");
                    foreach (var category in categories.GetAll())
                    {
                        Console.WriteLine($"{category.CategoryID} - {category.CategoryName} - {category.Description}");
                    }
                Console.WriteLine("Se ha editado la categoría. Desea eliminarla? S/N");
                } 
                else Console.WriteLine("Desea eliminar la última fila creada? S/N");

                do
                {
                    letra = Console.ReadLine().ToLower();

                    if (letra == "s" || letra == "n")
                    {
                        validate = true;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, escriba S o N.");
                    }
                } while (!validate);

                if (letra == "s")
                {
                    categories.DeleteLast();
                    Console.WriteLine("El registro ha sido eliminado.");
                }
            }

            Console.WriteLine("\nPresione una tecla para salir.");
            Console.ReadKey();
        }
    }
}
