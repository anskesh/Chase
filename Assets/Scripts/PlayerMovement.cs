using UnityEngine;

namespace Jungle.Minigames.Chase
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Transform _groundPoint;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float GroundCheckRadius = 0.5f;
        [SerializeField] private float _jumpForce = 7f;
        [SerializeField] private float _movementSpeed = 3f;
        
        private Rigidbody2D _rb;
        
        private void Jump()
        {
            if (OnGround())
                _rb.AddForce(transform.up * _jumpForce);
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                Jump();

            transform.Translate(Vector2.right * _movementSpeed * Time.deltaTime);
        }

        private bool OnGround()
        {
            return Physics2D.OverlapCircle(_groundPoint.position, GroundCheckRadius, _groundLayer);
        }
    }
}
