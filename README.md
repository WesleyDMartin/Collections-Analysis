# Collections Analysis
## Set Year 2

# Summary
This project was intended to be an analysis of basic collections in C#, but as it was one of my first assignments in the language,
I attempted to be as thorough and graphic as possible. As well as serving as an exccellent jumping point for proper design in C#, 
this project gave me a good jumping point for efficieny analysis.


![alt text](https://github.com/WesleyDMartin/WAMP_A3/blob/master/10000%20Accesses%20-%20Log%20Scale.png "Log Scale - 10000 Accesses")

# Graphed Results
 
The results are not easy to see in this format, I have attached the images along with the document. To achieve the above results,
I performed the following tests:
1.	All four collections were filled with numbers, increasing from zero up to the size of that particular test, 1 to 100000.
2.	On each collection type, I performed 10000 direct accesses, and 100 searches. 
3.	I performed each set of tests in point two 100 times, and then took the averages of all 100 times.
4.	I performed the above combination of tests on each collection type for seven different sizes, ranging from 1 to 1000000. 

The accesses method for each collection type was the contains method for search, and a direct index access for the access test.
Not all four collections contained the same set of functions, so in each case, I looked at the MSDN page for that collection to
find the most similar function.

