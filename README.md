# Priority-calculator

What it does
-----------
The priority calculator is a calculator with a GUI which supports the order of operations.


Plan
============

How it will work
-----------
The calculator is supposed to work like an RPN calculator with priority of parentheses. The user input will be converted 
to RPN and the functions will operate with RPN. To convert the calculatur will be using the algorithm shunting yard to convert a 
string input to RPN. A stack will be used to handle priorities. 

Features to be implemented
-----------
Support of the operators: +, -, *, /

Parentheses will have priority.

Graphical user interface to make the application user friendly.

Language
-----------
The programming languages used are C# and XAML.

Build system
-----------
.NET

How to compile and run
=======
Install/open Visual Studio. In the Calculator folder dubble click on the `Calculator.sln` file

Unit testing
-----------
To run unit tests, open visual studio and open prodject, then hover over test in the topbar and click run all tests.


How to create a xml report:
Run the following command in the test projects terminal in Visual Studio: dotnet test --collect:"XPlat Code Coverage"


Coverlet: Convert xml to a cmd report.
Run the following command in the test projects terminal: dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover



reportgenerator: Convert xml to html report
reportgenerator -reports:"**\TestResults\**\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
1. Use above command
2. Open index in CoverageReport folder and open Index.html



Project management
=======
[Kanban board](https://github.com/users/Sneakycloud/projects/1)


List of members
=======
Github handle - Firstname Lastname

* Sneakycloud - Eddie Olofsgård
* sodqv - Sara Odqvist
* ebbabrage - Ebba Brage
* sandzan - Sandra Karlssån



Declaration section
=======

I, Eddie Olofsgård, declare that I am the sole author of the content I add to this repository.

I, Ebba Brage, declare that I am the sole author of the content I add to this repository.

I, Sara Odqvist, declare that I am the sole author of the content I add to this repository.

I, Sandra Carlsson, declare that I am the sole author of the content I add to this repository


External assets used
=======
[FluentAssertions](https://github.com/fluentassertions/fluentassertions)

[ReportGenertor](https://github.com/danielpalme/ReportGenerator)

[Coverlet](https://github.com/coverlet-coverage/coverlet)
