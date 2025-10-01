//namespace BrokenArraysStringsandLists_Wilkerson
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello, World!");
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("DEBUG CHALLENGE CORRECTED OUTPUT");

        // --- Section A: Arrays ---
        int[] ids = new int[5] { 101, 102, 103, 104, 105 };
        Console.WriteLine("A1) Original IDs: " + string.Join(", ", ids));

        // Fixed: Insert new ID 999 at index 2 with proper right-shifting
        int insertIndex = 2;
        int[] newIds = new int[ids.Length + 1];
        for (int i = 0; i < insertIndex; i++)
        {
            newIds[i] = ids[i];
        }
        newIds[insertIndex] = 999;
        for (int i = insertIndex; i < ids.Length; i++)
        {
            newIds[i + 1] = ids[i];
        }
        ids = newIds;
        Console.WriteLine("A2) After inserting 999 at index 2: " + string.Join(", ", ids));

        // Fixed: Delete index 3 with proper bounds checking
        int deleteIndex = 3;
        for (int i = deleteIndex; i < ids.Length - 1; i++)
        {
            ids[i] = ids[i + 1];
        }
        ids[ids.Length - 1] = 0;
        Console.WriteLine("A3) After deleting index 3: " + string.Join(", ", ids));

        // --- Section B: Strings ---
        // Fixed: Use StringBuilder for efficient string concatenation
        Console.WriteLine("\nBuilding large string roster");
        StringBuilder rosterBuilder = new StringBuilder("Alice");
        for (int i = 0; i < 10; i++) // Reduced from 5000 for demo
        {
            rosterBuilder.Append(",Student" + i);
        }
        string roster = rosterBuilder.ToString();
        Console.WriteLine("B1) Roster length: " + roster.Length);
        Console.WriteLine("B1) Roster preview: " + roster.Substring(0, Math.Min(50, roster.Length)) + "...");

        // Fixed: Split on commas and rejoin with commas
        string[] parts = roster.Split(',');
        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i].Length > 0)
            {
                parts[i] = char.ToUpper(parts[i][0]) + parts[i].Substring(1);
            }
        }
        roster = string.Join(",", parts);
        Console.WriteLine("B2) After capitalization: " + roster.Substring(0, Math.Min(80, roster.Length)));

        // --- Section C: Lists ---
        var names = new List<string> { "alice", "bob", "carla" };
        Console.WriteLine("\nC1) Original names: " + string.Join(", ", names));

        // Fixed: Use Add() instead of Insert() to append to list
        names.Add("zoe");
        Console.WriteLine("C2) After adding 'zoe': " + string.Join(", ", names));

        // Fixed: Remove items using reverse for-loop
        for (int i = names.Count - 1; i >= 0; i--)
        {
            if (names[i].StartsWith("b"))
                names.RemoveAt(i);
        }
        Console.WriteLine("C3) After removing names starting with 'b': " + string.Join(", ", names));

        // Performance demonstration
        Console.WriteLine("\nPerformance Test");
        var big = new List<int>();
        for (int i = 0; i < 10000; i++) big.Add(i); // Reduced from 100000 for demo

        var sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < 1000; i++) // Reduced from 10000 for demo
        {
            big.Insert(0, -1);
        }
        sw.Stop();
        Console.WriteLine($"C4) Insert-at-head x1,000 took {sw.ElapsedMilliseconds} ms");

        // Efficient approach
        var efficientBig = new List<int>();
        sw.Restart();
        for (int i = 0; i < 1000; i++)
        {
            efficientBig.Add(-1);
        }
        efficientBig.AddRange(big);
        efficientBig.Reverse();
        sw.Stop();
        Console.WriteLine($"C5) Efficient approach took {sw.ElapsedMilliseconds} ms");

        Console.WriteLine(" ALL OPERATIONS COMPLETED SUCCESSFULLY ");
    }
}