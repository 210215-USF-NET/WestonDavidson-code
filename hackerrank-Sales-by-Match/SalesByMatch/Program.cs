﻿using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


namespace SalesByMatch
{


    class Solution
    {

        // Complete the sockMerchant function below.
        static int sockMerchant(int n, int[] ar)
        {


        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //console read user input value
            int n = Convert.ToInt32(Console.ReadLine());

            //console splits
            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            //int result = sockMerchant(n, ar);

            textWriter.WriteLine(ar);


            //textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }

}