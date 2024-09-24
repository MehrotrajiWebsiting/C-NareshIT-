using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NareshIT
{
    /*
     * ALL THIS IS DONE IN Windows Form Application (not console application)
        For Linq to SQL we have to -
        CONVERT ALL THE RELATIONAL OBJECTS INTO OBJECT ORIENTED TYPES 
            (ORM - Object Relational Mapping)
                Table             -> Class
                Columns           -> Property
                Rows (or records) -> Instance
                Stored Procedures -> Methods
        To perform ORM we are provided with a tool known as 
                OR (Object Relational) Designer.

        //STEPS for ORM
            1)Perform ORM by adding OR Designer.
            2)Adding a reference for an assembly i.e., System.Data.Linq.dll
            3)We need to write the connection string into the Config File
    */
    internal class LinqToSql
    {
    }
}
