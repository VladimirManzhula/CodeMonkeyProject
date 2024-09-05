using Zenject;

namespace Core.Exceptions.ZenjectUtil.Database
{
    public static class ZenjectBindDatabaseExtensions
    {
        public static void BindDatabaseWithDao<TDao, TBase>(
            this DiContainer container,
            TDao instance
        )
        {
            container.Bind<TDao>().FromSubstitute(instance).WhenInjectedInto<TBase>();
            container.BindInterfacesTo<TBase>().AsSingle();
        }
    }
}