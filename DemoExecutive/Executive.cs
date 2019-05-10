/////////////////////////////////////////////////////////////////////
// Executive.cs - This package is the Executive                    //
//                It Provides code to demonstrate you meet all     // 
//                requirements.                                    //
// version      - 1.1                                              //
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
 * ver 1.1 : 07 Nov 2018
 * - Changed the executive file to satisfy the project-3 requirement
 * ver 1.0 : 09 Oct 2018
 * - first release
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DepAnalysis;
using StrongComponent;

namespace CodeAnalysis
{
  using Lexer;

  class Executive
  {
        //----< Demonstrating Requirement - 1 on the console >--------------
        public void requirementOne()
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("\n Demonstrating Requirement - 1");
            msg.Append("\n -----------------------------");
            msg.Append("\n The project is implemented with Visual Studio 2017");
            msg.Append("\n The project uses C# Windows Console Projects of VS-2017,");
            msg.Append(" as provided in the ECS computer labs.");
            Console.WriteLine(msg);
        }
        //----< Demonstrating Requirement - 2 on the console >--------------
        public void requirementTwo()
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("\n\n Demonstrating Requirement - 2");
            msg.Append("\n -----------------------------");
            msg.Append("\n The project uses the .Net System.IO and System.Text for all I/O.");
            Console.WriteLine(msg);
        }
        //----< Demonstrating Requirement - 3 on the console >--------------
        public void requirementThree()
        {
            Console.Write("\n\n Demonstrating Requirement - 3");
            Console.Write("\n ------------------------------\n");
            Console.Write(" This Project 3 provides with all C# packages as per the requirement \n");
            Console.Write(" Implemented Packages are as follows: \n");
            Console.Write(" 1.Tokenizer \n 2.SemiExpression \n 3.TypeTable \n 4.TypeAnalysis \n");
            Console.Write(" 5.DepAnalysis \n 6.StrongComponent \n 7. Display \n 8.Tester (Executive)");
        }
        //----< Demonstrating Requirement - 4 and 5 on the console >--------------
        public void requirementFour()
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("\n\n Demonstrating Requirement - 4 and 5");
            msg.Append("\n -------------------------------------");
            msg.Append("\n * The dependancy of the files are analysed according to the requirement\n");
            msg.Append("\n * Type Table is created and showed according to the requirement\n");
            Console.WriteLine(msg);
        }
        //----< Demonstrating Requirement - 6 on the console >--------------
        public void requirementSix()
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("\n\n Demonstrating Requirement - 6");
            msg.Append("\n -------------------------------------");
            msg.Append("\n  The Project3 finds all the strong components, if any, in the file collection, based on the dependennalysis\n");
            msg.Append("\n  The strong Components information for the given input is as follows:\n");
            
            Console.WriteLine(msg);

            Graph.displayStrongComponent();
        }
        //----< Demonstrating Requirement - 7 on the console >--------------
        public void requirementSeven()
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("\n\n Demonstrating Requirement - 7");
            msg.Append("\n -------------------------------------");
            msg.Append("\n  The Project3 is displaying the results in a well formated area of the output\n");
            msg.Append("\n\n Demonstrating Requirement - 8");
            msg.Append("\n -------------------------------------");
            msg.Append("\n  This project includes an automated unit test suite that exercises all of the\n");
            msg.Append("\n  special cases that required for all the implemented package\n");
            Console.WriteLine(msg);
        }
        //----< process commandline to get file references >-----------------
        public void setAllParameters(List<string> files_)
        {
            Console.Write("\n  Dependency Analysis");
            Console.Write("\n ----------------------------");
            Graph.filesGraphs = files_;
            Graph.filenumber = files_.Count();
            Graph.setGraph();
            DAnalysis.filesDepAnalysis = files_;
            Graph.filesGraph = files_;
            DAnalysis.setDictionary();
            Graph.setGraphDictionary();
        }
        public void setAllParams()
        {
            Console.Write("\n  Overall Type Table ");
            Console.Write("\n ----------------------------");
            CodeAnalysis.BuildCodeAnalyzer.displayTable();
            Console.Write("\n\n");
        }
    static List<string> ProcessCommandline(string[] args)
    {
      List<string> files = new List<string>();
      if (args.Length < 1)
      {
        Console.Write("\n  Please enter path and file(s) to analyze\n\n");
        return files;
      }
      string path = args[0];
      if(!Directory.Exists(path))
      {
        Console.Write("\n  invalid path \"{0}\"", System.IO.Path.GetFullPath(path));
        return files;
      }
      path = Path.GetFullPath(path);
      files.AddRange(Directory.GetFiles(path,"*.cs"));
      return files;
    }

    static void ShowCommandLine(string[] args)
    {
      Console.Write(" Commandline args are:\n");
      Console.Write(" ---------------------\n");
      Console.Write("  {0}", args[0]);
      Console.Write("\n\n The test files are being cosidered from this directory");
      Console.Write("\n --------------------------------------------------------\n");
      Console.Write(" {0}", Path.GetFullPath(args[0]));
      Console.Write("\n");
    }

    static void Main(string[] args)
    {
      ShowCommandLine(args);
      Executive test = new Executive();
      test.requirementOne();
      test.requirementTwo();
      test.requirementThree();
      test.requirementFour();
      List<string> files = ProcessCommandline(args);
      foreach (string file in files)
        {
          ITokenCollection semi = Factory.create();
          if (!semi.open(file as string)) {
            Console.Write("\n  Can't open {0}\n\n", args[0]);
            return;
          }
          BuildCodeAnalyzer builder = new BuildCodeAnalyzer(semi);
          Parser parser = builder.build();
          try{
              while (semi.get().Count > 0)
                parser.parse(semi);
             }
        catch (Exception ex){
              Console.Write("\n\n  {0}\n", ex.Message);
            }
        Repository rep = Repository.getInstance();
        List<Elem> table = rep.locations;semi.close();
        }
       test.setAllParameters(files);
      foreach (string file in files)
      {
        Console.Write("\nFilename : {0}\n", System.IO.Path.GetFileName(file));
        DAnalysis depAnls = new DAnalysis();
        ITokenCollection semi = Factory.create();
        if (!semi.open(file as string)){
          Console.Write("\n  Can't open {0}\n\n", args[0]);
          return;
        }
        try{
          while (semi.get().Count > 0)
            depAnls.parse(semi,file);
        }
        catch (Exception ex){
            Console.Write("\n\n  {0}\n", ex.Message);
        }
        semi.close();Graph.addGraph();
      }
      test.setAllParams();
      test.requirementSix();
      test.requirementSeven();
    }
  }
}
