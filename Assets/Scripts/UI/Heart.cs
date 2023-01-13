using UnityEngine;

namespace Jungle.Minigames.Chase
{
    public class Heart : MonoBehaviour
    {
        [SerializeField] private Sprite _fullHeart;
        [SerializeField] private Sprite _emptyHeart;

        private SpriteRenderer _renderer;
        public bool IsFull { private set; get; }

        public void EmptyHeart()
        {
            /*_renderer.sprite = _emptyHeart;*/
            gameObject.SetActive(false);
            IsFull = false;
        }

        public void FillHeart()
        {
            /*_renderer.sprite = _fullHeart;*/
            gameObject.SetActive(true);
            IsFull = true;
        }

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }
    }
}