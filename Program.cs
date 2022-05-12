﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgoritmoCAIM
{
    public class Program
    {
        // Iiris database
        List<Double> sepallenth = new List<double>() {
        5.1, 4.9, 4.7, 4.6, 5.0, 5.4, 4.6, 5.0, 4.4, 4.9, 5.4, 4.8, 4.8, 4.3, 5.8,
        5.7, 5.4, 5.1, 5.7, 5.1, 5.4, 5.1, 4.6, 5.1, 4.8, 5.0, 5.0, 5.2, 5.2, 4.7,
        4.8, 5.4, 5.2, 5.5, 4.9, 5.0, 5.5, 4.9, 4.4, 5.1, 5.0, 4.5, 4.4, 5.0, 5.1,
        4.8, 5.1, 4.6, 5.3, 5.0, 7.0, 6.4, 6.9, 5.5, 6.5, 5.7, 6.3, 4.9, 6.6, 5.2,
        5.0, 5.9, 6.0, 6.1, 5.6, 6.7, 5.6, 5.8, 6.2, 5.6, 5.9, 6.1, 6.3, 6.1, 6.4,
        6.6, 6.8, 6.7, 6.0, 5.7, 5.5, 5.5, 5.8, 6.0, 5.4, 6.0, 6.7, 6.3, 5.6, 5.5,
        5.5, 6.1, 5.8, 5.0, 5.6, 5.7, 5.7, 6.2, 5.1, 5.7, 6.3, 5.8, 7.1, 6.3, 6.5,
        7.6, 4.9, 7.3, 6.7, 7.2, 6.5, 6.4, 6.8, 5.7, 5.8, 6.4, 6.5, 7.7, 7.7, 6.0,
        6.9, 5.6, 7.7, 6.3, 6.7, 7.2, 6.2, 6.1, 6.4, 7.2, 7.4, 7.9, 6.4, 6.3, 6.1,
        7.7, 6.3, 6.4, 6.0, 6.9, 6.7, 6.9, 5.8, 6.8, 6.7, 6.7, 6.3, 6.5, 6.2, 5.9};

        List<Double> sepalwith = new List<double>() {
        3.0, 3.4, 3.0, 2.5, 3.0, 3.3, 3.2, 2.7, 3.1, 3.1, 3.1, 3.0, 3.1, 3.4, 3.0,
        2.6, 2.8, 2.8, 3.8, 2.8, 3.0, 2.8, 3.0, 2.8, 3.2, 3.3, 2.7, 2.8, 2.8, 3.2,
        2.2, 2.6, 3.8, 3.0, 3.2, 2.8, 2.5, 3.0, 2.7, 3.2, 3.6, 2.5, 2.9, 2.5, 3.0,
        3.0, 2.9, 3.0, 2.7, 3.3, 2.8, 2.5, 2.9, 2.9, 3.0, 2.7, 2.3, 2.6, 3.0, 2.6,
        2.5, 3.0, 2.3, 3.1, 3.4, 3.0, 2.7, 2.7, 2.4, 2.4, 2.6, 2.9, 3.0, 2.8, 3.0,
        2.9, 2.8, 2.5, 2.8, 3.2, 2.5, 2.2, 2.7, 3.0, 3.1, 2.9, 2.9, 2.2, 3.0, 2.0,
        2.7, 2.9, 2.4, 3.3, 2.8, 2.8, 2.3, 3.1, 3.2, 3.2, 3.3, 3.7, 3.2, 3.8, 3.0,
        3.8, 3.5, 3.2, 2.3, 3.5, 3.4, 3.0, 3.1, 3.5, 3.2, 3.1, 4.2, 4.1, 3.4, 3.1,
        3.2, 3.4, 3.5, 3.4, 3.0, 3.4, 3.3, 3.6, 3.7, 3.4, 3.8, 3.8, 3.5, 3.9, 4.4,
        4.0, 3.0, 3.0, 3.4, 3.7, 3.1, 2.9, 3.4, 3.4, 3.9, 3.6, 3.1, 3.2, 3.0, 3.5};

        List<Double> petallength = new List<double>() {
        1.4, 1.4, 1.3, 1.5, 1.4, 1.7, 1.4, 1.5, 1.4, 1.5, 1.5, 1.6, 1.4, 1.1, 1.2,
        1.5, 1.3, 1.4, 1.7, 1.5, 1.7, 1.5, 1.0, 1.7, 1.9, 1.6, 1.6, 1.5, 1.4, 1.6,
        1.6, 1.5, 1.5, 1.4, 1.5, 1.2, 1.3, 1.5, 1.3, 1.5, 1.3, 1.3, 1.3, 1.6, 1.9,
        1.4, 1.6, 1.4, 1.5, 1.4, 4.7, 4.5, 4.9, 4.0, 4.6, 4.5, 4.7, 3.3, 4.6, 3.9,
        3.5, 4.2, 4.0, 4.7, 3.6, 4.4, 4.5, 4.1, 4.5, 3.9, 4.8, 4.0, 4.9, 4.7, 4.3,
        4.4, 4.8, 5.0, 4.5, 3.5, 3.8, 3.7, 3.9, 5.1, 4.5, 4.5, 4.7, 4.4, 4.1, 4.0,
        4.4, 4.6, 4.0, 3.3, 4.2, 4.2, 4.2, 4.3, 3.0, 4.1, 6.0, 5.1, 5.9, 5.6, 5.8,
        6.6, 4.5, 6.3, 5.8, 6.1, 5.1, 5.3, 5.5, 5.0, 5.1, 5.3, 5.5, 6.7, 6.9, 5.0,
        5.7, 4.9, 6.7, 4.9, 5.7, 6.0, 4.8, 4.9, 5.6, 5.8, 6.1, 6.4, 5.6, 5.1, 5.6,
        6.1, 5.6, 5.5, 4.8, 5.4, 5.6, 5.1, 5.1, 5.9, 5.7, 5.2, 5.0, 5.2, 5.4, 5.1};

        List<Double> petalwith = new List<double>() {
        0.2, 0.2, 0.2, 0.2, 0.2, 0.4, 0.3, 0.2, 0.2, 0.1, 0.2, 0.2, 0.1, 0.1, 0.2,
        0.4, 0.4, 0.3, 0.3, 0.3, 0.2, 0.4, 0.2, 0.5, 0.2, 0.2, 0.4, 0.2, 0.2, 0.2,
        0.2, 0.4, 0.1, 0.2, 0.1, 0.2, 0.2, 0.1, 0.2, 0.2, 0.3, 0.3, 0.2, 0.6, 0.4,
        0.3, 0.2, 0.2, 0.2, 0.2, 1.4, 1.5, 1.5, 1.3, 1.5, 1.3, 1.6, 1.0, 1.3, 1.4,
        1.0, 1.5, 1.0, 1.4, 1.3, 1.4, 1.5, 1.0, 1.5, 1.1, 1.8, 1.3, 1.5, 1.2, 1.3,
        1.4, 1.4, 1.7, 1.5, 1.0, 1.1, 1.0, 1.2, 1.6, 1.5, 1.6, 1.5, 1.3, 1.3, 1.3,
        1.2, 1.4, 1.2, 1.0, 1.3, 1.2, 1.3, 1.3, 1.1, 1.3, 2.5, 1.9, 2.1, 1.8, 2.2,
        2.1, 1.7, 1.8, 1.8, 2.5, 2.0, 1.9, 2.1, 2.0, 2.4, 2.3, 1.8, 2.2, 2.3, 1.5,
        2.3, 2.0, 2.0, 1.8, 2.1, 1.8, 1.8, 1.8, 2.1, 1.6, 1.9, 2.0, 2.2, 1.5, 1.4,
        2.3, 2.4, 1.8, 1.8, 2.1, 2.4, 2.3, 1.9, 2.3, 2.5, 2.3, 1.9, 2.0, 2.3, 1.8};

        List<double> distinctValues = new List<double>();
        List<Interval> intervals = new List<Interval>();
        List<double> discretizationScheme = new List<double>();
        double minimum = 0.0;
        double maximum = 0.0;
        double globalCAIM = 0.0;
        public int numberOfClasses = 3;

        public void Step1(List<double> attributePerRow)
        {
            Console.WriteLine("|++++++++++++++++++++++++++++++++++++++++++++++++++++++|");
            Console.WriteLine("|++++++++++++++++++++++++++++++++++++++++++++++++++++++|\n");
            // Find the minimum value (d0) and the maximum value (dn)
            this.minimum = attributePerRow.Min();
            this.maximum = attributePerRow.Max();
           
            // Distinct values
            string B = CalculateDistinctValues(attributePerRow);
            Console.WriteLine("> B = " + B + "\n");

            discretizationScheme.Clear();
            discretizationScheme.Add(this.minimum);
            discretizationScheme.Add(this.maximum);

            // Discretization Scheme
            string D = ShowDistinctValues(this.discretizationScheme);
            Console.WriteLine("> D = " + D + "\n");         
            
            // Console.WriteLine("> Global CAIM = " + this.globalCAIM + "\n");

            Step2(attributePerRow);
        }

        public void Step2(List<double> attributePerRow)
        {
            // Initialize a variable K = 1
            int K = 1;
            bool flag = true;

            do
            {
                // Tentatively add some limits of B that are not already in D and compute their corresponding CAIM value
                foreach (double i in this.distinctValues)
                {
                    List<double> auxDiscretizationScheme = new List<double>();

                    foreach (double j in this.discretizationScheme)
                    {
                        auxDiscretizationScheme.Add(j);
                    }

                    if (!auxDiscretizationScheme.Contains(i))
                    {
                        auxDiscretizationScheme.Add(i);
                        ListSort(auxDiscretizationScheme);
                        this.intervals.Add(
                            new Interval(
                                auxDiscretizationScheme,
                                GenerateMatrix(auxDiscretizationScheme, attributePerRow)
                            )
                         );                        
                    }
                    auxDiscretizationScheme.Clear();
                }
                // Accept the limit that has the highest value of CAIM
                // If(CAIM > GlobalCAIM or K < S(where S is the number of existing classes)) then update D with the limit accepted in step 2.3 and set GlobalCAIM = CAIM, else terminate the process
                Interval maxValueOfCAIM = GetMaxValueOfCAIM(this.intervals);

                // Console.WriteLine("\n\n\n\n" + maxValueOfCAIM.caim + "\n\n\n\n");

                if (maxValueOfCAIM.caim > this.globalCAIM || K < numberOfClasses)
                {
                    this.globalCAIM = maxValueOfCAIM.caim;
                    this.discretizationScheme.Clear();
                }
                else
                {
                    flag = false;
                    Console.WriteLine("> Global CAIM: " + this.globalCAIM + "\n");
                    string D = ShowDistinctValues(this.discretizationScheme);
                    Console.WriteLine("> D = " + D + "\n");
                }
                // Sets K = K + 1
                K++;
                this.intervals.Clear();
                foreach (double value in maxValueOfCAIM.discretizationScheme)
                {
                    this.discretizationScheme.Add(value);
                }
            } while (flag);        

            this.distinctValues.Clear();
        }

        // Form a set of all the different values of Fi, placed in ascending order, create a variable B that will contain the following information: d0, all intermediate values without repeating, dn
        public string CalculateDistinctValues(List<double> attributePerRow)
        {
            foreach (double value in attributePerRow.OrderBy(x => x))
            {
                if (!this.distinctValues.Contains(value))
                {
                    this.distinctValues.Add(value);
                }
            }

            // B
            return ShowDistinctValues(this.distinctValues);
        }

        public string ShowDistinctValues(List<double> distinctValues)
        {
            string print = "{ ";
            int size = distinctValues.Count;
            int iterator = 1;
            int count = 0;

            foreach (double value in distinctValues)
            {
                if (iterator == size)
                {
                    print += value + " }";
                } 
                else
                {
                    if (count == 10)
                    {
                        print += "\n";
                        count = 0;
                    }
                    print += value + ", ";
                    count++;
                }
                iterator++;
            }

            return print;
        }

        public void ListSort(List<double> list)
        {
            List<double> auxiliary = new List<double>();

            foreach (double value in list.OrderBy(x => x))
            {
                auxiliary.Add(value);
            }

            list.Clear();

            foreach (double value in auxiliary)
            {
                list.Add(value);
            }
        }

        // Generate matrix for each new interval
        public int[,] GenerateMatrix(List<double> scheme, List<double> attribute)
        {
            int[,] matrix = new int[numberOfClasses, (scheme.Count - 1)];
            int classElements = 0;
            int iterator = 0;

            while(iterator < 3)
            {
                foreach (double value in attribute)
                {
                    for (int j = 0; j < (scheme.Count - 1); j++)
                    {
                        if (j == (scheme.Count - 2))
                        {
                            if (value >= scheme[j] && value <= scheme[j + 1])
                            {
                                matrix[iterator, j] += 1;
                            }
                        }
                        else
                        {
                            if (value >= scheme[j] && value < scheme[j + 1])
                            {
                                matrix[iterator, j] += 1;
                            }
                        }                        
                    }

                    classElements++;

                    if (classElements == 50)
                    {
                        classElements = 0;
                        iterator++;
                    }
                }                
            }

            return matrix;
        }

        // Accept the limit that has the highest value of CAIM      
        public Interval GetMaxValueOfCAIM(List<Interval> intervals)
        {
            Interval max = intervals[0];

            foreach (Interval interval in intervals)
            {
                if (max.caim < interval.caim)
                {
                    max = interval;                  
                }
            }

            return max;
        }

        public static void Main(string[] args)
        {

            Console.WriteLine("|++++++++++++++++++ Caim's Algorithm ++++++++++++++++++|");
            Program algorithm = new Program();
            algorithm.Step1(algorithm.sepallenth);
            algorithm.Step1(algorithm.sepalwith);
            algorithm.Step1(algorithm.petallength);
            algorithm.Step1(algorithm.petalwith);
        }
    }
}
