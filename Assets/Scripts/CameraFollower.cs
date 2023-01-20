using UnityEngine;

namespace Jungle.Minigames.Chase
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private void Update()
        {
            transform.position = new Vector3(_player.transform.position.x + 1.34f, 0, -10);
        }
    }
}
