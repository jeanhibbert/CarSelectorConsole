# Car Selector for a predefined race track

 - [Problem Overview](#Problem-Overview)
 - [General Throughts](#General-Thoughts)
 - [Implementation Specifics](#Implementation-Specifics)
 - [General Thoughts Goals](#General-thoughts-Goals)
 - [Outstanding work](#Outstanding-work)
 - [References](#References)

# Problem Overview

"Create a race car setup selector for a car racing team. The purpose of the software is to be able to rank a given set of
car configurations for a particular race track based on the race completion time.
The 2 main entities are: Race Track and Car Configuration"

# Constraints
- This means that your code should not have any using statements or have any references, even to System.

# Implementation Specifics

- The main assembly is the CarSelector C# library which only references Microsoft.CSharp.dll
- 2 other libraries were created, a console application that displays performance test results
and a Unit test project what has unit tests around the 3 key features of the Car selector assembly
which are:
	- The ability to determine the completion time of a car configuration given a specific race track.
	- The ability to order a list of car configurations using quick sort using each car configuration's completion time.
- An additional console application was added CarSelectorConsoleV2 that had NO using statements whatsoever. 
This application accepts a set of arguments on the command line relating to track and car configurations and returns an 
integer indicating which sequence id belongs to the fastest car.

# General thoughts / Goals

- Produce a self documenting simple solution
- Only need to expose methods that are going to be used in CarSelector Assembly
- Decided to make CarEvaluatorService an instance class with a interface so that 
an external assembly can instantiate multiple instances and use it in a multi-threaded manner.
The interface will allow the implementation to be pluggable also via dependency injection.
- The CarEvaluationService methods are virtual so that it can be inherited from and either of the methods can be overridden by calling assembly.
	- This will allow the calling assembly to customise either the evaluation or sorting functionality
- Decided to use doubles for CarConfiguration properties because they are accurate enough and perform better than floats
- Evaluated various sorting algorithms and quick sort seemed to be a good fit.
- Initially the CarGenerator was part of the CarSelector assembly but I took it out since it's not a requirement.
	- The SimpleRNG random number generator would have been used to prevent usage of any "using"  & System references in the CarSelector assembly
- Added XML comments to the ICarEvaluationService API

# Outstanding work
- Determine strategy to handle invalid (zero or negative) Car Configuration and Track properties
	- The current strategy is just to just ignore and continue
- What happens if one of the CarConfiguration objects are null in the CarConfiguration array handed to the CarEvaluationService
	- At the moment a Null Reference exception is thrown

# References

- Quick Sort algorithm taken from 
http://www.codeproject.com/Articles/16115/QuickSort-Algorithm-using-Generics-in-C

- Simple RNG class taken from
http://www.codeproject.com/Articles/25172/Simple-Random-Number-Generation
This class is not used since CarGenerator is for unit tests only
(If CarGenerator was part of the the main CarSelector assembly it would not be able to use System.Random, and would thus use this 
class instead to generate random numbers)