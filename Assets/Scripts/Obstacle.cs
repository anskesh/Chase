using UnityEngine;

namespace Jungle.Minigames.Chase
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer;
        private void OnTriggerEnter2D(Collider2D col)
        {
            /*Debug.Log(col.name);*/
            if (col.CompareTag("ObstacleDisabler"))
                gameObject.SetActive(false);
        }
    }
}
