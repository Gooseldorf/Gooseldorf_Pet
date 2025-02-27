using Cysharp.Threading.Tasks;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class EntryPoint
    {
        private static EntryPoint instance;

        private readonly SceneService sceneService;
        private UIRoot uiRoot;
        
        /// <summary>
        /// Global application settings
        /// </summary>
        /*[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void InitialSetUp()
        {
            instance = new EntryPoint();
            instance.Enter();
        }*/

        private EntryPoint()
        {
            sceneService = new SceneService();
        }

        private async void Enter()
        {
#if UNITY_EDITOR
            string sceneName = sceneService.CurrentSceneName;
    
            await LoadAndInstantiateUIRoot();
            uiRoot.Init(sceneService);

            if (sceneName == SceneService.GAME_SCENE_NAME)
            {
                await EnterGame(); 
                return;
            }

            if (sceneName == SceneService.MENU_SCENE_NAME)
            {
                await EnterMenu();
                return;
            }

            if (sceneName != SceneService.ENTRY_SCENE_NAME)
            {
                return;
            }
#endif
            await EnterMenu();
        }

        private async UniTask EnterGame()
        {
            await uiRoot.ShowLoadingScreen;
            
            await sceneService.LoadGameScene();
            //await uiRoot.LoadAndInstantiateGameUI();
            
            await uiRoot.HideLoadingScreen;
        }

        private async UniTask EnterMenu()
        {
            await uiRoot.ShowLoadingScreen;
            
            await sceneService.LoadMenuScene();
            //await uiRoot.LoadAndInstantiateMenuUI();
            await UniTask.Delay(2000);
            
            await uiRoot.HideLoadingScreen;
        }

        private async UniTask LoadAndInstantiateUIRoot()
        {
            UIRoot uiRootPrefab = await AssetManager.LoadAssetAsync<UIRoot>("UIRoot");
            uiRoot = Object.Instantiate(uiRootPrefab);
            Object.DontDestroyOnLoad(uiRoot);
        }
    }
}