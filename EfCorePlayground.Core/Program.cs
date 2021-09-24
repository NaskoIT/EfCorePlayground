using EfCorePlayground.Core.Business;
using System;

namespace EfCorePlayground.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataSeeder.Seed();
        }
    }
}
