using Common;
using System;
using System.Linq;

namespace ConsoleTestApp.specs
{
    public class RouterSpecs
    {
        public static void PrintSample<T>() where T: RouterBase, new()
        {
            Console.WriteLine(Environment.NewLine + "******************** RUNNING ROUTER VALIDATION ********************");
            var deliveryRouter = new T();

            deliveryRouter.AddRoute("Chicago", "San Diego");
            deliveryRouter.AddRoute("San Diego", "Chicago");
            deliveryRouter.AddRoute("Chicago", "Albuquerque");
            deliveryRouter.AddRoute("Albuquerque", "Chicago");
            deliveryRouter.AddRoute("San Diego", "Dallas");
            deliveryRouter.AddRoute("Albuquerque", "Dallas");

            PrintAllRoutes("Albuquerque", "San Diego", deliveryRouter);
            PrintAllRoutes("Albuquerque", "Dallas", deliveryRouter);
            PrintAllRoutes("San Diego", "Chicago", deliveryRouter);
            PrintAllRoutes("San Diego", "Albuquerque", deliveryRouter);
            PrintAllRoutes("San Diego", "Paris", deliveryRouter);

            Console.WriteLine("******************** COMPLETED ********************");
        }

        private static void PrintAllRoutes(string start, string destination, RouterBase router)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"{start} to {destination}");
            var routes = router.GetAllRoutes(start, destination);
            if (routes.Any())
            {
                Console.WriteLine("The route exists from {0} to {1}.", start, destination);
                foreach(var route in routes)
                {
                    Console.WriteLine($"{route.ResultingPath} costs {route.CumulativeWeight}");
                }
            }
            else
            {
                Console.WriteLine("The route does not exist from {0} to {1}.", start, destination);
            }                
        }
    }
}
