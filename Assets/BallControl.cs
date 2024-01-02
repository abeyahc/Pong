using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
        private Rigidbody2D rb2d;

        void GoBall()
        {
                float rand = Random.Range(0, 2);
                if (rand < 1)
                {
                        rb2d.AddForce(new Vector2(20, -15));
                }
                else
                {
                        rb2d.AddForce(new Vector2(-20, -15));
                }
        }

        void ResetBall()
        {
                rb2d.velocity = new Vector2(0, 0);
                transform.position = Vector2.zero;
        }

        void RestartGame()
        {
                ResetBall();
                Invoke("GoBall", 1); // waits 1 second to start ball to move
        }

        // Start is called before the first frame update
        void Start()
        {
                rb2d = GetComponent<Rigidbody2D>();
                Invoke("GoBall", 2); // gives players time to get ready for 2 seconds
        }

        void OnCollisionEnter2D(Collision2D coll)
        {
                if (coll.collider.CompareTag("Player"))
                {
                        Vector2 vel;
                        vel.x = rb2d.velocity.x;
                        vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
                        rb2d.velocity = vel;
                }
        }
}
