﻿namespace Game.DataHolders
{
    public class ADataHolder<TModel> : IDataHolder<TModel>
    {
        public TModel Model { get; private set; }
        
        public void SetModel(TModel model) => Model = model;
    }
}