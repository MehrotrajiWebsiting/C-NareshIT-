using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NareshIT
{
    //DEFAULT SCOPE FOR EVERY MEMBER OF THE CLASS IS
    // PRIVATE
    /*
        YOU CANNOT USE PRIVATE, PROTECTED AND PROTECTED INTERNAL 
        on a CLASS
        only INTERNAL and PUBLIC is allowed
    */
    //DEFAULT SCOPE FOR CLASS is INTERNAL
    class accessSpecifiers
    {
        //Access specifiers is used to define scope of a 
        //type and it's members

        /*
            1)public - accessible from anywhere

            2)private - only accessible WITHIN class
                        We cannot declare TYPES (eg- class) as private

            3)protected - accessible within the class and all CHILD classes,i.e,
                          accessible within the class and 
                          ONLY children of the class (in same as well as 
                          different project)

            4)internal - accessible ONLY within the PROJECT ,i.e., 
                         accessible within the class and 
                         children of the class (ONLY IN SAME PROJECT) and 
                         non-child classes (by creating instance of your class) 
                         (ONLY IN SAME PROJECT)
                         
            5)protected internal -  (PROTECTED OR INTERNAL) ,i.e.,
                                    accessible within the class and 
                                    children of the class (in same as well as 
                                    different project) and 
                                    non-child classes 
                                    (by creating instance of your class)
                                    (ONLY IN SAME PROJECT)

            In NON-CHILD CLASS of DIFFERENT PROJECT ONLY
            PUBLIC is accessible
        */
    }
}
