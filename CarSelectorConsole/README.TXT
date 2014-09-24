Technical Test – Race Car Setup
March 2014

Create a race car setup selector for a car racing team. The purpose of the software is to be able to rank a given set of
car configurations for a particular race track based on the race completion time.
The 2 main entities are: Race Track and Car Configuration

The Race Track has the following properties:
 Lap Distance
 Number of laps to complete
 Time it takes to make a pitstop

For each Car Configuration, given a particular race track we know:
 Fuel Capacity
 The time it takes to complete a lap
 Average fuel consumption over one lap

We assume that a car is fuelled up completely to its configuration's capacity at the start of a race and that during a pit
stop the car is always completely filled up. We also assume that pitstop times are static across all configurations and
that lap times are constant over a race.
The software should be able to accept an arbitrary number of cars configurations.

Please read the following requirements carefully:
 The solution should consist of a class library written in C#.
 The solution should demonstrate best practises.
 Do not produce a User Interface for your solution.
 The class library may only use features of the language. Do not use any .NET or 3rd party libraries, i.e. your
project should have no external references.
This means that your code should not have any using statements or have any references, even to System.
 Any test projects can use .NET libraries or 3rd party libraries of your choice if the licence allows it. Use NuGet to
manage any these dependencies.
 Send a ZIP file with your solution but remove any binary files.
 There is no time limit. Do not deliver a complicated solution. It should illustrate your capabilities as a capable
but pragmatic engineer.