using System;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new WindsorContainer();
            new ContainerInstaller().Install(container, new DefaultConfigurationStore());
            
            var batch = container.Resolve<IDailyItemProcessBatchJob>();
            var gildedRoseStateService = container.Resolve<IGildedRoseStateService>();

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                var itemsFromService = gildedRoseStateService.GetGildedRoseItems();

                foreach (var item in itemsFromService)
                {
                    Console.WriteLine(item);
                }
                
                Console.WriteLine("");
                batch.Run();
            }

            Console.ReadKey();
        }
    }
}
