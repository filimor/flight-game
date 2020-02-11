using UnityEngine;

namespace FlightGame
{
    public class PlayerController : MonoBehaviour
    {
        private bool _started;
        private bool _finished;
        private Rigidbody2D _playerBody;
        private Vector2 _impulseForce = new Vector2(0, 500f);

        public GameObject featherParticle;

        private void Start()
        {
            _playerBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!_finished)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    if (!_started)
                    {
                        _started = true;
                        _playerBody.isKinematic = false;
                    }

                    _playerBody.velocity = new Vector2(0, 0);
                    _playerBody.AddForce(_impulseForce);

                    // GameObject feathers = Instantiate(featherParticle);
                    // Vector3 playerPosition = transform.position + new Vector3(0, 1, 0);
                    Instantiate(featherParticle);
                    transform.position += new Vector3(0, 1, 0);
                    featherParticle.transform.position = transform.position;
                }

                float posFelpudoPx = Camera.main.WorldToScreenPoint(transform.position).y;

                if (posFelpudoPx > Screen.height || posFelpudoPx < 0)
                {
                    Destroy(gameObject);
                }

                transform.rotation = Quaternion.Euler(0, 0, _playerBody.velocity.y * 2.1f); 
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!_finished)
            {
                _finished = true;
                GetComponent<Collider2D>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-300, 0));
                GetComponent<Rigidbody2D>().AddTorque(300f);
            }
        }
    }
}