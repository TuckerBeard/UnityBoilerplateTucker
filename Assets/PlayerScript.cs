using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public GameObject cam;
    public GameObject coinCounter;
    public Rigidbody2D rb;
    public float jumpForce = 500f;
    public bool canJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(100, 0);
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal"), 0f));
        if(rb.velocity.x >= 5f)
        {
            rb.velocity = new Vector2(5f, rb.velocity.y);
        }
        else if(rb.velocity.x <= -5f)
        {
            rb.velocity = new Vector2(-5f, rb.velocity.y);
        }

        if(Input.GetAxis("Jump") > 0f && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 7);
            //rb.AddForce(new Vector2(10, jumpForce));
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "BoundBox")
        {
            cam.GetComponent<CameraScript>().isFollowing = false;
        }
        else if (other.gameObject.tag == "Coin")
        {
            coinCounter.gameObject.GetComponent<CoinCounterScript>().collect();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Death")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "BoundBox")
        {
            cam.GetComponent<CameraScript>().isFollowing = true;
        }
    }
}
