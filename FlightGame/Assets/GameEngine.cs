using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public GameObject enemy;

    private void Start()
    {
        InvokeRepeating("CreateEnemy", 1, 1.5f);
    }

    private void Update()
    {
    }

    private void CreateEnemy()
    {
        float randomHeight = (10.0f * Random.value) - 5;
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = new Vector2(15.0f, randomHeight);
    }
}