/////////////////////////////////////////////////////////////////////
// TypeAnalysis.cs - This package is the Executive                    //
//                It Provides code to demonstrate you meet all     // 
//                requirements.                                    //
// version      - 1.0                                              //
// Language     - C#,Visual Studio 2017                            //
// Platform     - Macbook Pro ,Windows 10                          //
// Application  - Type-Based Package Dependency Analysis           //
//                                                                 //
//Source: Dr. Jim Fawcett                                          //
//Author Name: Ganesh Mamatha Sheshappa                            //
//SUID : 35888-1097                                                //
//Email_Id : gmamatha@syr.edu                                      //
//CSE681 - Software Modeling and Analysis, Fall 2018               //
/////////////////////////////////////////////////////////////////////
/*
 * Package Operations:
 * -------------------
 * Demonstrates how to build a Executive for the 
 * Type-Based Package Dependency Analysis
 * 
 * Required Files:
 * -------------------
 *   DAnalysis.cs
 *   Display.cs
 *   Element.cs
 *   IRulesAndActions.cs, RulesAndActions.cs, Parser.cs, ScopeStack.cs
 *   ITokenCollection.cs, Semi.cs
 *   Graph.cs
 *   
 * Maintenance History:
 * --------------------
 * ver 1.1 : 05 Nov 2018
 * - Changed the executive file to satisfy the project-3 requirement
 * ver 1.0 : 09 Oct 2018
 * - first release
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeTable;

namespace TypeAnalysis
{
    public class TpAnl
    {
        string namespaceString = null;
        public void analyseType(string semi0,string semi1,string crrFileName,TTable tptable)
        {
            List<string> functions = new List<string>();
            functions.Add("class");
            functions.Add("interface");
            functions.Add("struct");
            functions.Add("enum");
            functions.Add("delegate");
            if (semi0 == "namespace")
            {
                namespaceString = semi1;
                tptable.add(semi1, crrFileName, null);
            }
            else if (functions.Contains(semi0))
            {
                tptable.add(semi1, crrFileName, namespaceString);
            }
        }
    }
#if (TEST_TYPEANALYSIS)
    class TestTypeAnalysis
    {
        static void checkTypeAnalysis()
        {
            TpAnl tp = new TpAnl();
            TTable tt = new TTable();
            tt.add("Type_X", "File_A", "Namespace_Test1");
            tt.add("Type_X", "File_B", "Namespace_Test2");
            tt.add("Type_Y", "File_A", "Namespace_Test1");
            tt.add("Type_Z", "File_C", "Namespace_Test3");
            string semiExp0 = "SemiExp - 0";
            string semiExp1 = "SemiExp - 1";
            string currName = "CurrentFileName";
            tp.analyseType(semiExp0, semiExp1, currName, tt);
        }
        static void Main()
        {
            checkTypeAnalysis();
        }
}
#endif
}
