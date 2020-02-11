using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject _felpudoPlayer;
    private bool _scored;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 0);
        _felpudoPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (transform.position.x < -25)
        {
            Destroy(gameObject);
        }
        else
        {
            if (transform.position.x < _felpudoPlayer.transform.position.x && !_scored)
            {
                _scored = true;
                GetComponent<Rigidbody2D>().isKinematic = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(-7.5f, 5.0f);
                GetComponent<Rigidbody2D>().AddTorque(-50f);
                GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.35f, 0.75f);
                _felpudoPlayer.SendMessage("ScorePoint");
            }
        }
    }
}