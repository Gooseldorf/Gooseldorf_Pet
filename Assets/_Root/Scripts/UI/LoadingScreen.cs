using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Utilities;

namespace UI
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private UISpriteSheetAnimator loadingIconAnimator;
        [SerializeField] private float fadeDuration = 1;
        
        public UniTask ShowTask
        {
            get
            {
                gameObject.SetActive(true);
                loadingIconAnimator.Play();
                return canvasGroup.DOFade(1, fadeDuration).ToUniTask();
            }
        }

        public UniTask HideTask => canvasGroup.DOFade(0, fadeDuration)
            .OnComplete(() =>
            {
                loadingIconAnimator.Stop();
                gameObject.SetActive(false);
            }).ToUniTask();
    }
}