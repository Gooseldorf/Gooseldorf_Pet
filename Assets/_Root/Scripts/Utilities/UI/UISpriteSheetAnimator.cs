using UnityEngine;
using UnityEngine.UI;

namespace Utilities
{
    public class UISpriteSheetAnimator : MonoBehaviour
    {
        [SerializeField] private Image targetImage;
        [SerializeField] private Sprite[] sprites;
        [SerializeField] private float frameDuration;

        private bool isPlaying = false;
        private float timer;
        private int currentFrame;

        private void Update()
        {
            if (isPlaying && gameObject.activeInHierarchy)
            {
                timer += Time.deltaTime;
                if (timer >= frameDuration)
                {
                    currentFrame = (currentFrame + 1) % sprites.Length;
                    targetImage.sprite = sprites[currentFrame];
                    timer = 0;
                }
            }
        }
        
        public void Play() => isPlaying = true;

        public void Pause() => isPlaying = false;

        public void Stop()
        {
            isPlaying = false;
            Reset();
        }

        private void Reset()
        {
            timer = 0;
            currentFrame = 0;
        }
    }
}
