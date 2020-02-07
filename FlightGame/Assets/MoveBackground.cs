using UnityEngine;

namespace FlightGame
{
    public class MoveBackground : MonoBehaviour
    {
        private float _screenHeight;
        private float _screenWidth;

        private void Start()
        {
            SpriteRenderer graphic = GetComponent<SpriteRenderer>();

            float backgroundHeight = graphic.sprite.bounds.size.y;
            float backgroundWidth = graphic.sprite.bounds.size.x;

            _screenHeight = Camera.main.orthographicSize * 2f;
            _screenWidth = _screenHeight / Screen.height * Screen.width;

            Vector2 newScale = transform.localScale;
            // TODO: Correct the intersect area;
            newScale.y = (_screenHeight / backgroundHeight) + 0.25f;
            newScale.x = _screenWidth / backgroundWidth;

            transform.localScale = newScale;

            if(name == "Background Image B")
            {
                transform.position = new Vector2(_screenWidth, 0f);
            }

            GetComponent<Rigidbody2D>().velocity = new Vector2(-3, 0);
        }

        private void FixedUpdate()
        {
            if (transform.position.x <= -_screenWidth)
            {
                transform.position = new Vector2(_screenWidth, 0f);
            }
        }
    }
}