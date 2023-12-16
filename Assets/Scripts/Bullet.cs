/* Amal Presingu
 * 10/28/2021
 * Programming bullet features
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigidbody2;
    public float speed = 750f;

    private void Awake()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        rigidbody2.AddForce(direction * this.speed); //adding force towards direction
        Destroy(this.gameObject, 5f); //destroying bullet after 5 seconds to free up memory
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject); //destroying bullet with collision of any object (in this case it is only asteroids)
    }
}
