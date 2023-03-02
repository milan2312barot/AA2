using AA2.DAL;
using System;

namespace AA2.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();
            System.Console.WriteLine("Please Enter Value:");
            System.Console.WriteLine("1:Get Category");
            System.Console.WriteLine("2:Add Category");
            System.Console.WriteLine("3:Delete Category");
            System.Console.WriteLine("4:Update Category");
            switch (int.Parse(System.Console.ReadLine()))
            {
                case 1:
                    obj.GetCategory();
                    break;

                case 2:
                    {
                        System.Console.WriteLine("Please provide New Category Name:");
                        obj.AddCategory(System.Console.ReadLine());
                        obj.GetCategory();
                    }
                    break;

                case 3:
                    {
                        obj.GetCategory();
                        System.Console.WriteLine("Please Select Category Id:");
                        obj.DeleteCategory((byte)int.Parse(System.Console.ReadLine()));
                        obj.GetCategory();
                    }
                    break;

                case 4:
                    {
                        obj.GetCategory();
                        System.Console.WriteLine("Please Select Category Id:");
                        obj.UpdateCategory((byte)int.Parse(System.Console.ReadLine()), System.Console.ReadLine());
                        obj.GetCategory();
                    }
                    break;
            }
        }

        void GetCategory()
        {
            QuickKartRepository repository = new QuickKartRepository();
            var categories = repository.GetAllCategories();
            System.Console.WriteLine("----------------------------------");
            System.Console.WriteLine("CategoryId\tCategoryName");
            System.Console.WriteLine("----------------------------------");
            foreach (var category in categories)
            {
                System.Console.WriteLine("{0}\t\t{1}", category.CategoryId, category.CategoryName);
            }
        }
        void GetCategory(byte id)
        {
            QuickKartRepository repository = new QuickKartRepository();
            var category = repository.GetCategoryById(id);
            System.Console.WriteLine("----------------------------------");
            System.Console.WriteLine("CategoryId\tCategoryName");
            System.Console.WriteLine("----------------------------------");

            System.Console.WriteLine("{0}\t\t{1}", category.CategoryId, category.CategoryName);

        }
        void AddCategory(string categoryName)
        {
            QuickKartRepository repository = new QuickKartRepository();
            bool result = repository.AddCategory(categoryName);
            if (result) System.Console.WriteLine("New category added successfully");
            else System.Console.WriteLine("Something went wrong while Adding. Try again!");
        }
        void DeleteCategory(byte id)
        {
            QuickKartRepository repository = new QuickKartRepository();
            bool result = repository.DeleteCategory(id);
            if (result) System.Console.WriteLine("Category deleted successfully");
            else System.Console.WriteLine("Something went wrong while Deleting. Try again!");
        }
        void UpdateCategory(byte id, string name)
        {
            QuickKartRepository repository = new QuickKartRepository();
            DAL.Models.Category c = new DAL.Models.Category();
            c.CategoryId = id;
            c.CategoryName = name;
            bool result = repository.UpdateCategory(c);
            if (result) System.Console.WriteLine("Category update successfully");
            else System.Console.WriteLine("Something went wrong while Updating. Try again!");
        }

    }
}