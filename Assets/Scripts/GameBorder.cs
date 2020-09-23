using UnityEngine;

namespace SpaceWar
{
    public class GameBorder : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var collided = collision.gameObject;

            if (collided.GetComponent<PooledMonoBehaviour>() != null)
            {
                collided.SetActive(false);
            }
            else
            {
                Destroy(collided);
            }
        }
    }
}