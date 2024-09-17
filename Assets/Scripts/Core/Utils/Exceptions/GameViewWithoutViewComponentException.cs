using System;

namespace Core.Exceptions
{
    public class GameViewWithoutViewComponentException : Exception
    {
        private readonly string _viewType;
        
        public GameViewWithoutViewComponentException(string viewType) : base(viewType)
        {
            _viewType = viewType;
        }

        public override string ToString() =>
            $"GameObject by type: {_viewType} doesn't contain component-inherit MonoBehavior.";
    }
}