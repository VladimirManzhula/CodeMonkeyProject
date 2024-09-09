namespace Game.DataHolders
{
    public interface IDataHolder<TModel>
    {
        TModel Model { get; }

        void SetModel(TModel model);
    }
}