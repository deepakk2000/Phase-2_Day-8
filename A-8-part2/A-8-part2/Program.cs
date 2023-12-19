using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace A_8_part2
{
    internal class Program
    {


        static DataTable CreateProductTable()
        {
            DataTable productTable = new DataTable();
            productTable.Columns.Add("PId", typeof(int));
            productTable.Columns.Add("PName", typeof(string));
            productTable.Columns.Add("PPrice", typeof(decimal));
            productTable.Columns.Add("MnfDate", typeof(DateTime));
            productTable.Columns.Add("ExpDate", typeof(DateTime));

            productTable.PrimaryKey = new DataColumn[] { productTable.Columns["PId"] };

            return productTable;
        }

        static void InsertProduct(DataTable productTable, int id, string name, decimal price, DateTime mnfDate, DateTime expDate)
        {
            DataRow newRow = productTable.NewRow();
            newRow["PId"] = id;
            newRow["PName"] = name;
            newRow["PPrice"] = price;
            newRow["MnfDate"] = mnfDate;
            newRow["ExpDate"] = expDate;

            productTable.Rows.Add(newRow);
        }

        static void UpdateProduct(DataTable productTable, int id, string name, decimal price, DateTime mnfDate, DateTime expDate)
        {
            DataRow rowToUpdate = productTable.Rows.Find(id);
            if (rowToUpdate != null)
            {
                rowToUpdate["PName"] = name;
                rowToUpdate["PPrice"] = price;
                rowToUpdate["MnfDate"] = mnfDate;
                rowToUpdate["ExpDate"] = expDate;
            }
            else
            {
                Console.WriteLine($"Product with ID {id} not found.");
            }
        }

        static void DeleteProduct(DataTable productTable, int id)
        {
            DataRow rowToDelete = productTable.Rows.Find(id);
            if (rowToDelete != null)
            {
                productTable.Rows.Remove(rowToDelete);
                Console.WriteLine($"Product with ID {id} deleted.");
            }
            else
            {
                Console.WriteLine($"Product with ID {id} not found.");
            }
        }

        static void SearchProduct(DataTable productTable, int id)
        {
            DataRow foundRow = productTable.Rows.Find(id);
            if (foundRow != null)
            {
                Console.WriteLine("Product found. Details:");
                Console.WriteLine($"ID: {foundRow["PId"]}");
                Console.WriteLine($"Name: {foundRow["PName"]}");
                Console.WriteLine($"Price: {foundRow["PPrice"]}");
                Console.WriteLine($"Manufacture Date: {foundRow["MnfDate"]}");
                Console.WriteLine($"Expiry Date: {foundRow["ExpDate"]}");
            }
            else
            {
                Console.WriteLine($"Product with ID {id} not found.");
            }
        }

        static void Main(string[] args)
        {
            DataTable productTable = CreateProductTable();

            InsertProduct(productTable, 1, "ProductA", 29.99m, new DateTime(2023, 1, 15), new DateTime(2024, 1, 15));
            InsertProduct(productTable, 2, "ProductB", 39.99m, new DateTime(2023, 3, 10), new DateTime(2024, 3, 10));

            DisplayProducts(productTable);

            // Example usage:
            SearchProduct(productTable, 1);
            UpdateProduct(productTable, 2, "ModifiedProductB", 49.99m, new DateTime(2023, 3, 10), new DateTime(2025, 3, 10));
            DeleteProduct(productTable, 1);

            Console.WriteLine("\nAfter operations:");
            DisplayProducts(productTable);

            Console.ReadKey();
        }

        static void DisplayProducts(DataTable productTable)
        {
            Console.WriteLine("Product List:");
            foreach (DataRow row in productTable.Rows)
            {
                Console.WriteLine($"ID: {row["PId"]}, Name: {row["PName"]}, Price: {row["PPrice"]}, MnfDate: {row["MnfDate"]}, ExpDate: {row["ExpDate"]}");
            }

        }

    }
}
