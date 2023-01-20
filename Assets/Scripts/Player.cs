using UnityEngine;
using UnityEngine.Events;

namespace Jungle.Minigames.Chase
{
    public class Player : MonoBehaviour
    {
        public event UnityAction AppliedDamage;
        public event UnityAction GameWon;
        
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
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Obstacle obstacle))
                ApplyDamage();
            else if (col.TryGetComponent(out Worker worker))
                GameWon?.Invoke();
        }

        private void ApplyDamage()
        {
            AppliedDamage?.Invoke();
        }
    }
}