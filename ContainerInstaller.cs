using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace csharp
{
    public class ContainerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var itemStateService = new GildedRoseStateService();
            container
                .Register(
                    Component
                        .For<IGildedRoseStateService>()
                        .Instance(itemStateService)
                        .LifestyleTransient()
                    )
                .Register(
                    Component
                        .For<IDailyItemProcessBatchJob>()
                        .ImplementedBy<DailyItemProcessBatchJob>()
                        .LifestyleTransient())
                .Register(
                    Component
                        .For<IGildedRoseQualityUpdater>()
                        .ImplementedBy<GildedRoseQualityUpdater>()
                        .LifestyleTransient());
        }
    }
}