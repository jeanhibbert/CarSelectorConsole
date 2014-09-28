# Car Selector for a predefined race track

 - [Problem Overview](#Problem-Overview)
 - [General Throughts](#General-Thoughts)

# Problem Overview

# Implementation Specifics

- The main assembly is the CarSelector C# library which only references Microsoft.CSharp.dll
- 2 other libraries were created, a console application that displays performance test results
and a Unit test project what has unit tests around the 3 key features of the Car selector assembly
which are:
	- The ability to determine the completion time of a car configuration given a specific race track.
	- The ability to order a list of car configurations using quick sort using tier completion times.

# General thoughts

- Only need to expose methods that are going to be used in CarSelector Assembly
- Decided to make CarEvaluatorService an instance class with a interface so that 
an external assembly can instantiate multiple instances and use it in a multi-threaded manner.
The interface will allow the implementation to be pluggable also via dependency injection.
- The CarEvaluationService methods are virtual so that it can be inherited from and either of the methods can be overridden by calling assembly.
	- This will allow the calling assembly to customise either the evaluation or sorting functionality
- Decided to use doubles for CarConfiguration properties because they are accurate enough and perform better than floats
- Evaluated various sorting algorithms and quick sort seemed to be the best fit.
- Initially the CarGenerator was part of the CarSelector assembly but I took it out since it's not a requirement.
	- The SimpleRNG random number generator would have been used to prevent usage of any "using"  & System references in the CarSelector assembly

# References

- Quick Sort algorithm taken from 