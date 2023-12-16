/* Amal Presingu
 * 10/28/2021
 * Programming features for asteroid and counting score
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class AsterController : MonoBehaviour
{
    public float speed = 200f;
    public new Rigidbody2D rigidbody {get; private set; }

    public GameObject explodePrefab;
    //private GameObject test = GameObject.FindWithTag("test");
    public static int score;
    public Text scoreText;

    private void Awake()
    {
        
        rigidbody = GetComponent<Rigidbody2D>();
        
    }
    // Start is called before the first frame update
    private void Start()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.Find("scoreText").GetComponentInChildren<Text>(); 
        }
        this.transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);

        this.transform.localScale = Vector3.one * 1f;
        this.rigidbody.mass = 1f;
        

        Destroy(this.gameObject, 12f); //destroying object after 12 seconds to free up memory


    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
        
        
    }

    public void SetTrajectory(Vector2 direction)
    {
        this.rigidbody.AddForce(direction * this.speed); //adding force towards spaceship
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet") //detecting collisions between bullet and asteroids | counting score
        {
            score++;
            scoreText.text = "" + score.ToString();
            Destroy(this.gameObject);
            Instantiate(explodePrefab, transform.position, transform.rotation); //explosion in location of collision
        }
    }
}
