using System;
using System.Collections.Generic;

namespace HelloWorldApp
{
    internal class Program
    {
        static List<string> nationalities;
        static void initList()
        {
            nationalities = new List<string>
            {
                "Australian",
                "Mongolian",
                "Russian",
                "Austrian",
                "Brazilian"
            };
        }

        static void Main(string[] args)
        {
            initList();
            nationalities.Sort();
            foreach(string nationality in nationalities)
            {
                Console.WriteLine(nationality);
            }
        }
    }
}