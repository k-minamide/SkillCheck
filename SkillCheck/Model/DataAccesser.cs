using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SkillCheck.Utility.DB;
using SkillCheck.ViewModel.Data;
using System.Data.SQLite;
using System.Data;

namespace SkillCheck.Model
{
    public static class DataAccesser
    {
        private static DB<SQLiteCommand, SQLiteConnection> command = new DB<SQLiteCommand, SQLiteConnection>();

        static DataAccesser()
        {
            command.ConnectionString = (string)Properties.Settings.Default["SQLiteConnectionString"];
        }

        public static PlaceDataTable GetPlaceData()
        {
            string sql = "SELECT ID, Name, Place FROM Place";

            return command.Select<PlaceDataTable>(sql); ;
        }

        public static BookshelfDataTable GetBookshelfData(long? placeID)
        {
            string sql = "SELECT PlaceID, ID, Name FROM Bookshelf";
            List<SQLiteParameter> param = new List<SQLiteParameter>();
            if (placeID.HasValue)
            {
                sql += " WHERE PlaceID = @PlaceID";
                param.Add(new SQLiteParameter("@PlaceID", placeID.Value));
            }

            return command.Select<BookshelfDataTable>(sql, param.ToArray());
        }

        public static ShelfDataTable GetShelfData(long? placeID, long? bookshelfID)
        {
            string sql = "SELECT BookshelfID, ID, Name FROM Shelf";
            List<SQLiteParameter> param = new List<SQLiteParameter>();

            if (placeID.HasValue || bookshelfID.HasValue)
            { sql += " WHERE "; }
            if (placeID.HasValue)
            {
                sql += "PlaceID = @PlaceID";
                param.Add(new SQLiteParameter("@PlaceID", placeID.Value));
            }
            if (placeID.HasValue && bookshelfID.HasValue)
            { sql += " AND "; }
            if (bookshelfID.HasValue)
            {
                sql += " BookshelfID = @BookshelfID";
                param.Add(new SQLiteParameter("@BookshelfID", bookshelfID.Value));
            }

            return command.Select<ShelfDataTable>(sql, param.ToArray());
        }

        public static BookDataTable GetBookData(long? placeID, long? bookshelfID, long? shelfID)
        {
            BookDataTable ret = null;

            string sql = "SELECT PlaceID, BookshelfID, ShelfID, BookID FROM HoldBook";
            List<SQLiteParameter> param = new List<SQLiteParameter>();

            if (placeID.HasValue || bookshelfID.HasValue)
            { sql += " WHERE "; }
            if (placeID.HasValue)
            {
                sql += "PlaceID = @PlaceID";
                param.Add(new SQLiteParameter("@PlaceID", placeID.Value));
            }
            if (placeID.HasValue && bookshelfID.HasValue)
            { sql += " AND "; }
            if (bookshelfID.HasValue)
            {
                sql += " BookshelfID = @BookshelfID";
                param.Add(new SQLiteParameter("@BookshelfID", bookshelfID.Value));
            }
            if ((placeID.HasValue || bookshelfID.HasValue) && shelfID.HasValue)
            { sql += " AND "; }
            if (bookshelfID.HasValue)
            {
                sql += " ShelfID = @ShelfID";
                param.Add(new SQLiteParameter("@ShelfID", bookshelfID.Value));
            }

            HoldBookDataTable holdBookDataTable = command.Select<HoldBookDataTable>(sql, param.ToArray());

            if (holdBookDataTable.Count > 0)
            {
                sql = "SELECT ID, Name FROM Book";
                param.Clear();

                List<string> paramNames = new List<string>();
                for (int i = 0; i < holdBookDataTable.Count; i++)
                {
                    string paramName = string.Format("@ID{0}", i);
                    paramNames.Add(paramName);
                    param.Add(new SQLiteParameter(paramName, holdBookDataTable[i].BookID));
                }
                sql += string.Format(" WHERE ID IN ({0})", string.Join(", ", paramNames));

                ret = command.Select<BookDataTable>(sql, param.ToArray());
            }

            return ret;
        }

        public static BookDataTable GetBookData(long? categoryID)
        {
            BookDataTable ret = null;

            string sql = "SELECT BoookID, CategoryID FROM BookCategoryMapping";
            List<SQLiteParameter> param = new List<SQLiteParameter>();
            if (categoryID.HasValue)
            {
                sql += " WHERE CategoryID = @CategoryID";
                param.Add(new SQLiteParameter("@CategoryID", categoryID.Value));
            }
            
            BookCategoryMappingTable bookCategoryMappingTable = command.Select<BookCategoryMappingTable>(sql, param.ToArray());

            if (bookCategoryMappingTable.Count > 0)
            {
                sql = "SELECT ID, Name FROM Book";
                param.Clear();

                List<string> paramNames = new List<string>();
                for (int i = 0; i < bookCategoryMappingTable.Count; i++)
                {
                    string paramName = string.Format("@ID{0}", i);
                    paramNames.Add(paramName);
                    param.Add(new SQLiteParameter(paramName, bookCategoryMappingTable[i].BookID));
                }
                sql += string.Format(" WHERE ID IN ({0})", string.Join(", ", paramNames));

                ret = command.Select<BookDataTable>(sql, param.ToArray());
            }

            return ret;
        }

        public static CategoryDataTable GetCategoryData(long? placeID, long? bookshelfID, long? shelfID)
        {
            CategoryDataTable ret = null;

            string sql = "SELECT PlaceID, BookshelfID, ShelfID, BookID FROM HoldBook";
            List<SQLiteParameter> param = new List<SQLiteParameter>();

            if (placeID.HasValue || bookshelfID.HasValue)
            { sql += " WHERE "; }
            if (placeID.HasValue)
            {
                sql += "PlaceID = @PlaceID";
                param.Add(new SQLiteParameter("@PlaceID", placeID.Value));
            }
            if (placeID.HasValue && bookshelfID.HasValue)
            { sql += " AND "; }
            if (bookshelfID.HasValue)
            {
                sql += " BookshelfID = @BookshelfID";
                param.Add(new SQLiteParameter("@BookshelfID", bookshelfID.Value));
            }
            if ((placeID.HasValue || bookshelfID.HasValue) && shelfID.HasValue)
            { sql += " AND "; }
            if (bookshelfID.HasValue)
            {
                sql += " ShelfID = @ShelfID";
                param.Add(new SQLiteParameter("@ShelfID", bookshelfID.Value));
            }

            HoldBookDataTable holdBookDataTable = command.Select<HoldBookDataTable>(sql, param.ToArray());

            if (holdBookDataTable.Count > 0)
            {
                sql = "SELECT BoookID, CategoryID FROM BookCategoryMapping";
                param.Clear();

                List<string> paramNames = new List<string>();
                for (int i = 0; i < holdBookDataTable.Count; i++)
                {
                    string paramName = string.Format("@BookID{0}", i);
                    paramNames.Add(paramName);
                    param.Add(new SQLiteParameter(paramName, holdBookDataTable[i].BookID));
                }
                sql += string.Format(" WHERE BookID IN ({0})", string.Join(", ", paramNames));

                BookCategoryMappingTable bookCategoryMappingTable = command.Select<BookCategoryMappingTable>(sql, param.ToArray());

                if (bookCategoryMappingTable.Count > 0)
                {
                    sql = "SELECT ID, Name FROM Category";

                    paramNames.Clear();
                    for (int i = 0; i < holdBookDataTable.Count; i++)
                    {
                        string paramName = string.Format("@ID{0}", i);
                        paramNames.Add(paramName);
                        param.Add(new SQLiteParameter(paramName, holdBookDataTable[i].BookID));
                    }
                    sql += string.Format(" WHERE ID IN ({0})", string.Join(", ", paramNames));

                    ret = command.Select<CategoryDataTable>(sql, param.ToArray());
                }
            }

            return ret;
        }
    }
}
