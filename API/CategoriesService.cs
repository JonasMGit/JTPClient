using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    class CategoriesService
    {
        public CategoriesService()
        {
        }
        //List with type category. Category takes an id and name
        private static List<Category> database = new List<Category>();
        //read method that returns id from database in any position
        public static Category Read(int id)
        {
            // return single category
            for (int i = 0; i < database.Count; i++)
            {//if the database has ID that is equal to the id. Not sure I get this
                if (database[i].Id == id)
                {
                    return database[i];
                }
            }

            return null;
        }
        //Adds elements of database to Read() list
        public static List<Category> Read()
        {
            List<Category> categories = new List<Category>();
            for (int i = 0; i < database.Count; i++)
            {
                categories.Add(database[i]);
            }
            return categories;
        }
        //Create method that returns a category name
        public static Category Create(string categoryName)
        {
            //in case of empty db make the id 1, because of zero indexing
            int nextId;
            if (database.Count == 0)
            {
                nextId = 1;
            }
            else
            {//if db has two elements count= 2 -1 = 1. Which gives the second element. Then add 1 to get id 2
                //so second element has id 2, but in the list is 1
                nextId = database[database.Count - 1].Id + 1;
            }
            Category category = new Category(nextId, categoryName);
            database.Add(category);
            return Read(category.Id);
        }
    }
}
