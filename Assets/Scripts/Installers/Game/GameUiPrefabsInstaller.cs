using SimpleUi;
using Ui.Game.Pause;
using Ui.Game.RecipeCollection;
using Ui.Game.Start;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
    [CreateAssetMenu(
        menuName = "Installers/Game/" + nameof(GameUiPrefabsInstaller),
        fileName = nameof(GameUiPrefabsInstaller), order = 0
    )]
    public class GameUiPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private RecipeCollectionView recipeCollectionView;
        [SerializeField] private StartView startView;
        [SerializeField] private PauseView pauseView;
        
        public override void InstallBindings()
        {
            var canvasInstance = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasInstance.transform;

            Container.BindUiView<RecipeCollectionController, RecipeCollectionView>(recipeCollectionView, canvasTransform);
            Container.BindUiView<StartController, StartView>(startView, canvasTransform);
            Container.BindUiView<PauseController, PauseView>(pauseView, canvasTransform);
        }
    }
}