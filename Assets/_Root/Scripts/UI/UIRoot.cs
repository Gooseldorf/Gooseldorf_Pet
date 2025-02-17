using Cysharp.Threading.Tasks;
using Infrastructure;
using UnityEngine;

namespace UI
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private LoadingScreen loadingScreen;
        [SerializeField] private RectTransform layer1Rect;
        [SerializeField] private RectTransform layer2Rect;
        
        private SceneService sceneService;
        //private MenuUI menuUI;
        //private GameUI gameUI;

        public void Init(SceneService sceneService)
        {
            this.sceneService = sceneService;
        }

        public UniTask ShowLoadingScreen => loadingScreen.ShowTask; 
        public UniTask HideLoadingScreen => loadingScreen.HideTask; 
        
        /*public async UniTask LoadAndInstantiateMenuUI()
        {
            /*if (gameUI != null)
            {
                gameUI.Dispose();
                gameUI.GoToMenuEvent -= GoToMenu;
                Destroy(gameUI.gameObject);
            }
            MenuUI menuUIPrefab = await AssetManager.LoadAssetAsync<MenuUI>("MenuUI");
            menuUI = Instantiate(menuUIPrefab, layer1Rect);
            menuUI.Init();
            menuUI.GoToGameEvent += GoToGame;#1#
        }*/
        
        /*public async UniTask LoadAndInstantiateGameUI()
        {
            /*if (menuUI != null)
            {
                menuUI.Dispose();
                menuUI.GoToGameEvent -= GoToGame;
                Destroy(menuUI.gameObject);
            }
            GameUI gameUIPrefab = await AssetManager.LoadAssetAsync<GameUI>("GameUI");
            gameUI = Instantiate(gameUIPrefab, layer1Rect);
            gameUI.Init();
            gameUI.GoToMenuEvent += GoToMenu;#1#
        }*/

        private async void GoToGame()
        {
            await loadingScreen.ShowTask;
            
            await sceneService.LoadGameScene();
            //await LoadAndInstantiateGameUI();
            
            await loadingScreen.HideTask;
        }

        private async void GoToMenu()
        {
            await loadingScreen.ShowTask;
            
            //await LoadAndInstantiateMenuUI();
            //await sceneService.LoadMenuScene();
            
            await loadingScreen.HideTask;
        }
    }
}