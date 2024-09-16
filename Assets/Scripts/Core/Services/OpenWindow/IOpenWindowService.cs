using Core.Constants;

namespace Core.Services.OpenWindow
{
    public interface IOpenWindowService
    {
        bool IsWindowCurrentlyOpen(WindowNames.EGameType gameType);
    }
}