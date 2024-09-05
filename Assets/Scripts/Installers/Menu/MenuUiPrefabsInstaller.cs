using SimpleUi;
using Ui.Menu.Menu;
using UnityEngine;
using Zenject;

namespace Installers.Menu
{
    [CreateAssetMenu(
        menuName = "Installers/Menu/" + nameof(MenuUiPrefabsInstaller),
        fileName = nameof(MenuUiPrefabsInstaller), order = 0
    )]
    public class MenuUiPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private MenuView menuView;

        public override void InstallBindings()
        {
            var canvasInstance = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasInstance.transform;

            Container.BindUiView<MenuController, MenuView>(menuView, canvasTransform);
        }
    }
}