using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace StringDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Uncomment below to see string type in action

            //StringConversion();
            //EscapeString();
            //StringArray();
            //AppendingStrings();
            //InterpolationAndLiteral();
            //StringBuilderDemo();
            //WorkingWithArrays();
            //PadAndTrim();
            //SearchingStrings();
            //OrderingStrings();
            //TestingEquality();
            //GettingASubstring();
            //ReplacingText();
            //InsertingText();
            //RemovingText();


            Console.ReadLine();
        }

        private static void StringConversion()
        {
            string testString = "tHis iS tHe FBI Calling!";
            TextInfo currentTextInfo = CultureInfo.CurrentCulture.TextInfo;
            TextInfo englishTextInfo = new CultureInfo("fr-FR", false).TextInfo;
            string result;

            result = testString;
            Console.WriteLine();
            Console.WriteLine(result);

            result = testString.ToLower();
            Console.WriteLine();
            Console.WriteLine(result);

            result = testString.ToUpper();
            Console.WriteLine();
            Console.WriteLine(result);

            result = currentTextInfo.ToTitleCase(testString);
            Console.WriteLine();
            Console.WriteLine(result);

            result = englishTextInfo.ToTitleCase(testString);
            Console.WriteLine();
            Console.WriteLine(result);
        }

        private static void StringArray()
        {
            string testString = "Bobby Doran";
            Console.WriteLine();

            for (int i = 0; i < testString.Length; i++)
            {
                Console.Write(testString[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"The number of characters in the string: {testString.Length}");
            Console.WriteLine();
       
        }

        private static void EscapeString()
        {
            string results;

            // using the / as an escape to print the " " 
            results = "This is a \"Test\" file.";
            Console.WriteLine();
            Console.WriteLine(results);
            Console.WriteLine();

            // or...

            // the @ makes this a string literal so you don't have to \escape charcater the \'s.
            results = @"C:\Users\Demo\Programs\Test.txt";
            Console.WriteLine();
            Console.WriteLine(results);
        }

        private static void AppendingStrings()
        {
            // Three ways of using variables in a string

            string firstName = "Donald";
            string lastName = "Trump";
            string results;

            results = firstName + ", my name is " + firstName + " " + lastName;
            Console.WriteLine();
            Console.WriteLine(results);
            Console.WriteLine();

            results = string.Format("{0}, my name is {0} {1}", firstName, lastName);
            Console.WriteLine();
            Console.WriteLine(results);
            Console.WriteLine();

            // obviously the cleanest and most readable way
            results = $"{firstName}, my name is {firstName} {lastName}";
            Console.WriteLine();
            Console.WriteLine(results);
            Console.WriteLine();
        }

        private static void InterpolationAndLiteral()
        {
            string testString = "Darth Vadar";
            string results = $@"C:\Programs\Demos\Strings\{testString}\Test.txt";
            Console.WriteLine();
            Console.WriteLine(results);
        }

        private static void StringBuilderDemo()
        {
            Console.WriteLine();
            //uses memory three times for the same string because of the values. (unused will go to garbage collection)
            //doing this is in this way is weird and not a great idea
            string testString = "Test";
            testString = "Obi Wan Kenobi";
            testString += " is a great Jedi.";

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(testString);

            //times the for loop
            Stopwatch regularStopwatch = new Stopwatch();
            regularStopwatch.Start();

            string test = "";

            for (int i = 0; i < 100000; i++)
            {
                test += i;
            }

            regularStopwatch.Stop();
            Console.WriteLine("Running 100,000 iterations of a string takes: ");
            Console.WriteLine($"Regular Stopwatch: {regularStopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Regular Stopwatch: { regularStopwatch.Elapsed.TotalSeconds} seconds");

            Stopwatch builderStopwatch = new Stopwatch();
            builderStopwatch.Start();

            StringBuilder sb = new();

            for (int i = 0; i < 1000000; i++)
            {
                sb.Append(i);
            }

            builderStopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine("Running the same string but one million times vs 100,000");
            Console.WriteLine($"String Builder Stopwatch: {builderStopwatch.ElapsedMilliseconds} ms");
        }

        private static void WorkingWithArrays()
        {
            int[] ages = new int[] { 6, 7, 8, 3, 5, 13, 44, 9 };
            string results;

            //two ways to print, second gives comma seperated list
            results = String.Concat(ages);
            Console.WriteLine(results);

            results = String.Join(",", ages);
            Console.WriteLine(results);

            Console.WriteLine();

            string testString = "Jon,Tim,Bob,Mary,Jenny,Jane";
            string[] resultsArray = testString.Split(',');

            Array.ForEach(resultsArray, x => Console.WriteLine(x));

            Console.WriteLine();

            //double quotes for two charcaters
            testString = "Jon, Tim, Bob, Mary, Jenny, Jane";
            resultsArray = testString.Split(", ");

            Array.ForEach(resultsArray, x => Console.WriteLine(x));
        }

        private static void PadAndTrim()
        {
            string testString = "     Hello World       ";
            string results;

            Console.WriteLine();
            results = testString;
            Console.WriteLine("No trim on the string");
            Console.WriteLine($"'{results}'");
            Console.WriteLine();

            //trims start
            results = testString.TrimStart();
            Console.WriteLine("Trims the start");
            Console.WriteLine($"'{results}'");
            Console.WriteLine();

            //trims end
            results = testString.TrimEnd();
            Console.WriteLine("Trims the end:");
            Console.WriteLine($"'{results}'");
            Console.WriteLine();

            //trims all
            results = testString.Trim();
            Console.WriteLine("Trims start and end");
            Console.WriteLine($"'{results}'");

            Console.WriteLine();

            testString = "1.15";

            //pads to 10 spaces. adds 6 0's as string is 4 characters.
            results = testString.PadLeft(10, '0');
            Console.WriteLine("Pad Left");
            Console.WriteLine(results);

            Console.WriteLine();

            results = testString.PadRight(10, '0');
            Console.WriteLine("Pad Right");
            Console.WriteLine(results);


        }


        private static void SearchingStrings()
        {
            string testString = "This is a test of the search. Let's see how its testing works out.";
            bool resultsBoolean;
            int resultsInt;

            resultsBoolean = testString.StartsWith("This is");
            Console.WriteLine($"Starts with \"This is\": {resultsBoolean}");

            resultsBoolean = testString.StartsWith("ThIs is");
            Console.WriteLine($"Starts with \"ThIs is\": {resultsBoolean}");

            resultsBoolean = testString.EndsWith("works out.");
            Console.WriteLine($"Ends with \"works out\": {resultsBoolean}");

            resultsBoolean = testString.EndsWith("work out.");
            Console.WriteLine($"Ends with \"work out\": {resultsBoolean}");

            resultsBoolean = testString.Contains("test");
            Console.WriteLine($"Contains \"test\": {resultsBoolean}");

            resultsBoolean = testString.Contains("tests");
            Console.WriteLine($"Contains \"tests\": {resultsBoolean}");

            resultsInt = testString.IndexOf("test");
            Console.WriteLine($"Index of \"test\": {resultsInt}");

            resultsInt = testString.IndexOf("test" , 11);
            Console.WriteLine($"Index of \"test\" after character 10: {resultsInt}");

            resultsInt = testString.IndexOf("test" , 49);
            Console.WriteLine($"Index of \"test\" after character 49: {resultsInt}");

            resultsInt = testString.LastIndexOf("test");
            Console.WriteLine($"Last Index of \"test\": {resultsInt}");

            resultsInt = testString.LastIndexOf("test", 50);
            Console.WriteLine($"Last Index of \"test\" before character 50: {resultsInt}");

            resultsInt = testString.LastIndexOf("test", 10);
            Console.WriteLine($"Last Index of \"test\" before character 10: {resultsInt}");

        }

        private static void OrderingStrings()
        {
            CompareToHelper("Mary", "Bob");
            CompareToHelper("Mary", null);
            CompareToHelper("Adam", "Bob");
            CompareToHelper("Bob", "Bob");
            CompareToHelper("Bob", "Bobby");

            Console.WriteLine();

            CompareHelper("Mary", "Bob");
            CompareHelper("Mary", null);
            CompareHelper("Adam", "Bob");
            CompareHelper(null, "Bob");
            CompareHelper("Bob", "Bob");
            CompareHelper("Bob", "Bobby");
            CompareHelper(null, null);
        }

        private static void CompareToHelper(string testA, string? testB)
        {
            int resultsInt = testA.CompareTo(testB);

            switch (resultsInt)
            {
                case > 0:
                    Console.WriteLine($"CompareTo: {testB ?? "null"} comes before {testA} ");
                    break;

                case < 0:
                    Console.WriteLine($"CompareTo: {testA} comes before {testB} ");
                    break;

                case 0:
                    Console.WriteLine($"CompareTo: {testA} is the same as {testB} ");
                    break;
            }

        }

        private static void CompareHelper(string? testA, string? testB)
        {
            int resultInt = String.Compare(testA, testB);

            switch (resultInt)
            {
                case > 0:
                    Console.WriteLine($"Compare: {testB ?? "null"} comes before {testA} ");
                    break;

                case < 0:
                    Console.WriteLine($"Compare: {testA ?? "null"} comes before {testB} ");
                    break;

                case 0:
                    Console.WriteLine($"Compare: {testA ?? "null"} is the same as {testB ?? "null"} ");
                    break;
            }
        }

        private static void TestingEquality()
        {
            EqualityHelper("Bob", "Mary");
            EqualityHelper(null, "");
            EqualityHelper("", "Mary");
            EqualityHelper("Bob", " ");
            EqualityHelper("Bob", "bob");
        }

        private static void EqualityHelper(string? testA, string? testB)
        {
            bool resultsBoolean;
            resultsBoolean = String.Equals(testA, testB);

            if (resultsBoolean)
            {
                Console.WriteLine($"Equals: '{testA ?? "null"}' equals '{testB ?? "null"}' ");
            }
            else
            {
                Console.WriteLine($"Equals: '{testA ?? "null"}' does not equal '{testB ?? "null"}' ");
            }

            resultsBoolean = String.Equals(testA, testB, StringComparison.InvariantCultureIgnoreCase);

            if (resultsBoolean)
            {
                Console.WriteLine($"Equals (ignore letter case): '{testA ?? "null"}' equals '{testB ?? "null"}' ");
            }
            else
            {
                Console.WriteLine($"Equals (ignore letter case): '{testA ?? "null"}' does not equal '{testB ?? "null"}' ");
            }

            resultsBoolean = testA == testB;

            if (resultsBoolean)
            {
                Console.WriteLine($"== (ignore letter case): '{testA ?? "null"}' equals '{testB ?? "null"}' ");
            }
            else
            {
                Console.WriteLine($"== (ignore letter case): '{testA ?? "null"}' does not equal '{testB ?? "null"}' ");
            }
        }

        private static void GettingASubstring()
        {
            string testString = "This is a test of substring. Let's see how its testing works out.";
            string results;

            results = testString.Substring(5);
            Console.WriteLine(results);

            results = testString.Substring(5, 4);
            Console.WriteLine(results);
        }

        private static void ReplacingText()
        {
            string testString = "This is a test of replace. Let's see how its testing Works out.";
            string results;

            results = testString.Replace("test", "trial");
            Console.WriteLine(results);

            //won't account for end of sentece punctuation. test. test! etc.
            results = testString.Replace(" test ", " trial ");
            Console.WriteLine(results);

            results = testString.Replace("works", "makes", StringComparison.InvariantCultureIgnoreCase);
            Console.WriteLine(results);
        }

        private static void InsertingText()
        {
            string testString = "This is a test of insert. Let's see how its testing Works out.";
            string results;

            results = testString.Insert(5, "(test) ");
            Console.WriteLine(results);
        }

        private static void RemovingText()
        {
            string testString = "This is a test of remove. Let's see how its testing works out for test.";
            string results;

            results = testString.Remove(25);
            Console.WriteLine(results);

            results = testString.Remove(14, 10);
            Console.WriteLine(results);
        }
    }
}
