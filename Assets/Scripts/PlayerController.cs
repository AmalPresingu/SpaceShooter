/* Amal Presingu
 * 10/28/2021
 * Player movement and shooting
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Bullet bulletPrefab;
    public GameObject explodePrefab;
    float rotateSpeed = 210.0f;
    public Vector3 startRotation;
    public Button restartButton;
    public Text overText;

    // Start is called before the first frame update
    void Start()
    {
        overText.text = "";
        transform.eulerAngles = startRotation;
        restartButton.gameObject.SetActive(false); //hiding button until game ends
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) //rotating spaceship left and right based on movements
        {
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space)) //shoot with space
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up); //calling project to shoot bullet
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Aster") //if player collides with asteroid, end game
        {
            overText.text = "Game Over";
            this.gameObject.SetActive(false);
            Instantiate(explodePrefab, transform.position, transform.rotation);
            restartButton.gameObject.SetActive(true); //display restart button after game ends
        }
    }
    public void OnRestartButtonPress()
    {
        SceneManager.LoadScene("SampleScene");
        AsterController.score = 0; //need to reset score from here to prevent counting from previous games
    }
}
