using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NareshIT
{
    /*LINQ - Language Integrated Query 
        -Desgined by Microsoft and is very much similar to SQL 
                (Structured english Query Language)

      SQL is for Relational Database.

      Using LINQ we can write queries on a wide VARIETY of DATA SOURCES like
      Arrays, Collections, Database Tables, DataSets, XML Data.

      Syntax for DATABASE TABLE - 
      select <Column List> from <table> [as <alias>] [<clauses>]
      [ ] - optional
      Clauses (IN ORDER) - where, group by, having, order by
        
      SYNTAX FOR ARRAY/COLLECTION - (use alias in place of column name
           as arrays do not have column name)
      from <alias> in <collection or array> [<clauses>] select <alias>
        
      IN LINQ -
        Table             -> Class
        Columns           -> Property
        Rows (or records) -> Instance
        Stored Procedures -> Methods
    
      Categories-
      1)Linq to Objects- Write queries on Arrays,Collections,etc
      2)Linq to Databases - Write queries on DataTables,Relational Database tables
            a)Linq to ADO.Net ( for datatables )
            b)Linq to SQL ( for relational database - ONLY SQL Server )
            c)Linq to Entities (for all relational databases- 
                    SQL Server,Oracle....)
      3)Linq to XML - Write queries on XML files

      Linq to SQL - For working relational database,i.e Sql Server (ONLY)
        It allows not only querying of data but also insert, update, delete 
        operations ,i.e., CRUD operations.
       
      CRUD - Create (Insert), Read (Select), Update, Delete
      We can also CALL STORED PROCEDURES by using Linq to Sql

      SQL -> SQL Server - 1)Runtime syntax checking of SQL statements as C#
            compiler does not compiler " " strings so database engines do that
            everytime some new machine runs application causing burden
            2)NOT Type Safe (Verification on server causing burden)
            3)No Intellisense support.
            4)Debugging of SQL statements is NOT possible
            5)Code is combination of Object Oriented and Relational
            eg- Adding values of 2 textbox in table
            "Insert into student Values(" +textBox1.Text+ "," +textBox2.Text+ ")";
            "Relational Code" ObjectOrientedCode

      Linq -> SQL Server - 1)Compiletime syntax checking (done only once by
            C# compiler itself). Thus better.
            2)Type Safe (Verification directly on client system)
            3)Intellisense support is available.
            4)Debugging of Linq statements is possible.
            5)Pure Object Oriented Code (No  "" as code is C# statements)
    */
    class LINQ
    {
        public static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 18, 19, 20, 21, 22, 23, 24, 25, 12, 13, 14, 15, 16, 17, 26, 27, 28, 29, 30, 31, 32 };
            //SELECT * FROM arr
            var b = from i in arr select i; //b is an array
            foreach (int x in b)
            {
                Console.Write(x+" ");
            }
            Console.WriteLine();
            //values greater than 14 only
            b = from i in arr where i>14 select i;
            foreach (int x in b)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
            //ascending
            b = from i in arr where i > 14 orderby i select i;
            foreach (int x in b)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
            //descending
            b = from i in arr where i > 14 orderby i descending select i;
            foreach (int x in b)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }
    }
}
