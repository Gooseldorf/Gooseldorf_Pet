using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class SceneService
    {
        public const string ENTRY_SCENE_NAME = "Entry";
        public const string MENU_SCENE_NAME = "Menu";
        public const string GAME_SCENE_NAME = "Game";

        public string CurrentSceneName => SceneManager.GetActiveScene().name;
        
        public async UniTask LoadMenuScene()
        {
            await SceneManager.LoadSceneAsync(ENTRY_SCENE_NAME).ToUniTask();
            await SceneManager.LoadSceneAsync(MENU_SCENE_NAME).ToUniTask();
        }

        public async UniTask LoadGameScene()
        {
            await SceneManager.LoadSceneAsync(ENTRY_SCENE_NAME).ToUniTask();
            await SceneManager.LoadSceneAsync(GAME_SCENE_NAME).ToUniTask();
        }    
    }
}