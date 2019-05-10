/////////////////////////////////////////////////////////////////////
// DAnalysis.cs - This package is the Dependency Analysis          //
// version      - 1.0                                              //
// Language     - C#,Visual Studio 2017                            //
// Platform     - Macbook Pro ,Windows 10                          //
// Application  - Type-Based Package Dependency Analysis           //
//                                                                 //
//Author     : Ganesh Mamatha Sheshappa                            //
//SUID : 35888-1097                                                //
//Email_Id : gmamatha@syr.edu                                      //
//CSE681 - Software Modeling and Analysis, Fall 2018               //
/////////////////////////////////////////////////////////////////////
/*
 * Package Operations:
 * -------------------
 * This package is responsible for finding the dependency analysis using 
 * Type-Based Package Dependency Analysis
 * 
 * Required Files:
 * -------------------
 *   Display.cs
 *   TypeTable.cs
 *   DAnalysis.cs
 *   Display.cs
 *   Element.cs
 *   IRulesAndActions.cs, RulesAndActions.cs, Parser.cs, ScopeStack.cs
 *   ITokenCollection.cs, Semi.cs
 *   Graph.cs
 *   
 * Maintenance History:
 * --------------------
 * ver 1.1 : 06 Nov 2018
 * - Changed the executive file to satisfy the project-3 requirement
 * ver 1.0 : 09 Oct 2018
 * - first release
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeAnalysis;
using Lexer;
using TypeTable;
using StrongComponent;
namespace DepAnalysis
{
    public class DAnalysis
    {
        public static Dictionary<string, int> FileNames = new Dictionary<string, int>();
        public static List<string> filesDepAnalysis { get; set; }
        public static void setDictionary()
        {
            int fileCount = 0;
            foreach (string file in filesDepAnalysis)
            {
                FileNames.Add(System.IO.Path.GetFileName(file),fileCount);
                fileCount++;
            }
        }


        List<string> namespacesUsed = new List<string>();
        public void dependencyAnalysis()
        {
            Console.WriteLine("  Dependency analysed");
        }
        public void parse(Lexer.ITokenCollection semi,string currentFile) 
        {
            DetectUsing dusing = new DetectUsing();
            if (dusing.test(semi))
            {
                namespacesUsed.Add(semi[1]);
            }
            if (semi.ToString().ToLower().Contains('='))
            {
                string classType = null;
                classType = (semi.ToString().Split('=')[0]).ToString().Split(' ')[0];            
                if (TypeTable.TTable.table.ContainsKey(classType))
                {
                    List<TypeItem> function_list = new List<TypeItem>();
                    TypeTable.TTable.table.TryGetValue(classType, out function_list);
                    for(var i = 0; i< function_list.Count;i++)
                    {
                        if(namespacesUsed.Contains(function_list[i].namesp))
                        {
                            Console.WriteLine("    Dependency : " + function_list[i].file);
                            string fullPathParent = System.IO.Path.GetFileName(currentFile);
                            string fullPathChild = System.IO.Path.GetFileName(function_list[i].file);
                            int parent,child;
                            FileNames.TryGetValue(fullPathChild, out child);
                            FileNames.TryGetValue(fullPathParent, out parent);
                            Graph.setDependency(parent, child);
                        }
                    }
                }
            }
            
        }
    }
#if (TEST_DANALYSIS)
    class TestDepAnalysis
    {
        static void testDepAnlPackage()
        {
            DAnalysis depAnls = new DAnalysis();
            Lexer.ITokenCollection semi = null;
            string currentFile = "../../../TestFile.testZero.cs";
            depAnls.parse(semi, currentFile);
        }
        static void Main(string[] args)
        {
            TestDepAnalysis.testDepAnlPackage();
        }
    }
#endif
}
