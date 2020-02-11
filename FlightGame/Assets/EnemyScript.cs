using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 0);
    }

    private void Update()
    {
        if(transform.position.x < -25)
        {
            Destroy(gameObject);
        }
    }
}