using SimpleUi;
using Ui.Game.RecipeCollection;
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

        public override void InstallBindings()
        {
            var canvasInstance = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasInstance.transform;

            Container.BindUiView<RecipeCollectionController, RecipeCollectionView>(recipeCollectionView, canvasTransform);
        }
    }
}