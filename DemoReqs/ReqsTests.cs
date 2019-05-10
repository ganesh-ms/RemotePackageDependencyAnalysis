/////////////////////////////////////////////////////////////////////
// ReqsTests.cs - Test classes for Project2_InstrSol               //
// ver 1.0                                                         //
// Jim Fawcett, CSE681 - Software Modeling and Analysis, Fall 2018 //
/////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeAnalysis
{
  class FileUtils
  {
    public static bool openFile(string fileSpec, out StreamReader sr)
    {
      sr = File.OpenText(fileSpec);
      return sr != null;
    }
    public static bool fileLines(string fileSpec, int start = 0, int end = 10000)
    {
      StreamReader sr = File.OpenText(fileSpec);
      int count = 0;
      string line;
      while(count < end)
      {
        if(count < end)
        {
          line = sr.ReadLine();
          if (line == null)
            return count > 0;
          Console.Write("\n  {0}", line);
        }
      }
      return true;
    }
  }
  ///////////////////////////////////////////////////////////////////
  // ReqDisplay class
  // - display methods for Requirements testing

  class ReqDisplay
  {
    public static void title(string tle)
    {
      Console.Write("\n  {0}", tle);
      Console.Write("\n {0}", new string('-', tle.Length + 2));
    }
    public static void message(string msg)
    {
      Console.Write("\n  {0}\n", msg);
    }
  }
  ///////////////////////////////////////////////////////////////////
  // Finder class
  // - finds semiExp with specified sequence of tokens in specified file

  class Finder
  {
    public static string file { get; set; } = "";

    public static bool findSequence(bool findAll, params string[] toks)
    {
      bool found = false;
      if(!File.Exists(file))
        return false;
      Lexer.Semi semi = new Lexer.Semi();
      Lexer.Toker toker = new Lexer.Toker();
      toker.open(file);
      semi.toker = toker;
      while(!semi.isDone())
      {
        semi.get();
        if (semi.hasSequence(toks))
        {
          semi.show();
          found = true;
          if(findAll == false)
            return true;
        }
      }
      return found;
    }
  }
  ///////////////////////////////////////////////////////////////////
  // TestReq3 class

  class TestReq3 : ITest
  {
    public string name { get; set; } = "Test Req3";
    public string path { get; set; } = "../../";
    public bool result { get; set; } = false;
    void onFile(string filename)
    {
      Console.Write("\n    {0}", filename);
      result = true;
    }
    void onDir(string dirname)
    {
      Console.Write("\n  {0}", dirname);
    }
    public bool doTest()
    {
      ReqDisplay.title("Requirement #3");
      ReqDisplay.message("C# packages: Toker, SemiExp, ITokenCollection");
      FileUtilities.Navigate nav = new FileUtilities.Navigate();
      nav.Add("*.cs");
      nav.newDir += new FileUtilities.Navigate.newDirHandler(onDir);
      nav.newFile += new FileUtilities.Navigate.newFileHandler(onFile);
      path = "../../../Toker";
      nav.go(path, false);
      path = "../../../SemiExp";
      nav.go(path, false);
      return result;
    }
  }
  ///////////////////////////////////////////////////////////////////
  // TestReq4 class

  class TestReq4 : ITest
  {
    public string name { get; set; } = "Test Req4";
    public string fileSpec { get; set; } = "../../../Toker/Toker.cs";
    public bool result { get; set; } = false;
    public bool doTest()
    {
      ReqDisplay.title("Requirement #4");
      ReqDisplay.message("Toker implements state pattern");
      Finder.file = fileSpec;
      string[] toks = { "class", "{" };
      result = Finder.findSequence(true, toks);
      return result;
    }
  }
  ///////////////////////////////////////////////////////////////////
  // TestReq5 class

  class TestReq5 : ITest
  {
    public string name { get; set; } = "Test Req5";
    public string fileSpec { get; set; } = "../../../Toker/Test.txt";
    public bool result { get; set; } = true;
    public bool doTest()
    {
      ReqDisplay.title("Requirement #5");
      ReqDisplay.message("Toker reads one token with each call to getTok()");
      Lexer.Toker toker = new Lexer.Toker();
      fileSpec = Path.GetFullPath(fileSpec);

      if (!toker.open(fileSpec))
      {
        Console.Write("\n  Toker can't open file \"{0}\"", fileSpec);
        return (result = false);
      }
      else
      {
        Console.Write("\n  tokenizing file \"{0}\"", fileSpec);
      }
      for (int i = 0; i < 5; ++i)
      {
        Console.Write("\n  called Toker.getTok() to get \"{0}\"", toker.getTok());
      }
      return result;
    }
  }
  ///////////////////////////////////////////////////////////////////
  // TestReq6 class

  class TestReq6 : ITest
  {
    public string name { get; set; } = "Test Req6";
    public string fileSpec { get; set; } = "../../../SemiExp/Test.txt";
    public bool result { get; set; } = true;
    public bool doTest()
    {
      ReqDisplay.title("Requirement #6");
      ReqDisplay.message("Semi uses to get tokens until a terminator is retrieved");
      Lexer.Toker toker = new Lexer.Toker();
      fileSpec = Path.GetFullPath(fileSpec);
      if(!toker.open(fileSpec))
      {
        Console.Write("\n  toker can't open \"{0}\"", fileSpec);
        return (result = false);
      }
      else
      {
        Console.Write("\n  processing file \"{0}\"", fileSpec);
      }
      Lexer.Semi semi = new Lexer.Semi();
      semi.toker = toker;
      while(!semi.isDone())
      {
        semi.get();
        semi.show();
      }
      return result;
    }
  }
}
