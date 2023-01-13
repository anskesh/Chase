using UnityEngine;
using UnityEngine.Events;

namespace Jungle.Minigames.Chase
{
    public class Player : MonoBehaviour
    {
        public event UnityAction AppliedDamage;
        public float Width { get; private set; }
        
        private PlayerMovement _movement;
        private int _health;

        public void DisableMovement()
        {
            _movement.enabled = false;
        }

        public void EnableMovement()
        {
            _movement.enabled = true;
        }
        
        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
            var renderer = GetComponent<SpriteRenderer>();
            Width = renderer.bounds.size.x;
            Debug.Log(Width);
        }


        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Obstacle obstacle))
                ApplyDamage();
        }

        private void ApplyDamage()
        {
            AppliedDamage?.Invoke();
        }
        
    }
}