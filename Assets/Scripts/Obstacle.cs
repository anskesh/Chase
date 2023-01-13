using UnityEngine;

namespace Jungle.Minigames.Chase
{
    public class Obstacle : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.isTrigger)
                enabled = false;
        }
    }
}
