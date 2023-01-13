using UnityEngine;
using UnityEngine.Events;

namespace Jungle.Minigames.Chase
{
    public class Player : MonoBehaviour
    {
        public event UnityAction AppliedDamage;
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

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
                _movement.Jump();
            
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                    _movement.Jump();
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.TryGetComponent(out Obstacle obstacle))
                ApplyDamage();
        }

        private void ApplyDamage()
        {
            AppliedDamage?.Invoke();
        }
        
    }
}