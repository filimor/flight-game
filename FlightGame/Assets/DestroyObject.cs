using UnityEngine;

namespace RollingBall
{
    public class DestroyObject : MonoBehaviour
    {
        private void Start()
        {
            Invoke("DeleteObject", 1.5f);
        }

        private void DeleteObject()
        {
            Destroy(gameObject);
        }
    }
}