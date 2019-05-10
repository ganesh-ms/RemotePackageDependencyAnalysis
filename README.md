# Type-Based Package Dependency Analysis
> The project Academic project for the course CSE681. It is focused on building package dependency analyzer in C#. 

The entire Remote Code Page Management is built in 4 stages and the detailed information is as below
>The package with the name DAnalysis, Graph, TypeAnalysis, DemoReqs, Executive and RulesAndActions are built by me and rest of the packags was provided as the helper codes for the implementation. The entire Software was developed in 4 months with the effective utilization of the helper codes by the instructor.

## Project #1 - Lexical Scanner OCD - operational concept document 

### The project was to analyse the requirement and come up with the intial design for the project. This OCD consists of class diagram, package diagram, explination of the individual component etc.


## Project #2 - Lexical Scanner

### Tokenizer
Extracts words, called tokens, from a stream of characters. Token boundaries are white-space characters, transitions between alphanumeric and punctuator characters, and comment and string boundaries. Certain classes of punctuator characters belong to single character or two character tokens so they require special rules for extraction.
### SemiExpression
Groups tokens into sets, each of which contain all the information needed to analyze some grammatical construct without containing extra tokens that have to be saved for subsequent analyses. SemiExpressions are determined by special terminating characters: semicolon, open brace, closed brace, and newline when preceeded on the same line with 'using'.

## Project #3 - Type-Based Package Dependency Analysis

In this third project we will build and test a package dependency analyzer in C# that consists of, at least, these packages:

### Tokenizer
extracts words, called tokens, from a stream of characters. Token boundaries are white-space characters, transitions between alphanumeric and punctuator characters, and comment and string boundaries. Certain classes of punctuator characters belong to single character or two character tokens so they require special rules for extraction.
### SemiExpression
groups tokens into sets, each of which contain all the information needed to analyze some grammatical construct without containing extra tokens that have to be saved for subsequent analyses. SemiExpressions are determined by special terminating characters: semicolon, open brace, closed brace, and newline when preceeded on the same line with 'using'.
### TypeTable
Provides a container that stores type information needed for dependency analysis.
### TypeAnalysis
Finds all the types defined in each of a collection of C# source files. It does this by building rules to detect type definitions - classes, structs, enums, and aliases.
### DepAnalysis
Finds, for each file in a specified collection, all other files from the collection on which they depend. File A depends on file B, if and only if, it uses the name of any type defined in file B. It might do that by calling a method of a type or by inheriting the type. Note that this intentionally does not record dpedndencies of a file on files outsied the file set, e.g., language and platform libraries.
### StrongComponent
A strong component is the largest set of files that are all mutually dependent. That is, all the files whcih can be reached from any other file in the set by following direct or transitive dependency links. The term 'Strong Component' comes from the theory of directed graphs. There are a number of algorithms for finding strong components in graphs. My favorite is the Tarjan Algorithm, nicely described here: Tarjan Algorithm and pseudo code. You will n eed a graph class to implement this. You will find one in the C# Repository: C# graph class.
### Display
Uses information in the TypeTable to build an effective display of the dependency relationships between all files in the selected collection. Note that you are not expected to provide a graphical display. An indented text display will satisfy these requirements.
### Tester
Provides code to demonstrate you meet all requirements.

## Project #4 - Remote Package Dependency Analysis

In this fourth project we will build and test a remote package dependency analyzer in C# that consists of, at least, these packages:

### Project #3 Packages
Most of the packages used for Project #3.
### Comm
The Comm package implements asynchronous message passing communication using the Windows Communication Foundation Framework (WCF), which provides a well-engineered set of communication functionalities wrapping sockets and windows IPC. You will probably find that this communication facility will need to be factored into several packages. That is left up to you to design.
### Server
A package residing on a remote3 machine that exposes an HTTP endpoint for Comm Channel connections. The Server implements all the functionalities developed in Project #3.
### Client
A package, based on Windows Presentation Foundation (WPF), residing on the local machine. This package provides facilities for connecting a channel to the remote Server. This package provides the capabilitiy for sending requests messages for each of the functionalities of Project #3, and for receiving messages with the results, and displaying the resulting information.

Software details - Developed on Windows:

```sh
Microsoft Visual Studio 2017
```

## Developer info

Ganesh Mamamatha Sheshappa, 

ganeshms@live.com

## Instructor
Dr. James W Fawcett, 

Syracuse University, NY
