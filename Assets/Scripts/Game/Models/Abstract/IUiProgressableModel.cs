using UniRx;

namespace Game.Models.Abstract
{
    public interface IUiProgressableModel
    {
        float MaxProgress { get; set; }
        
        IReactiveProperty<float> CurrentProgress { get; }
    }
}