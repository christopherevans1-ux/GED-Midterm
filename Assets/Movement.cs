using Chapter.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public Rigidbody2D rb;
    public bool isDead = false;
    public bool isGrounded = true;
    public float jumpHeight = 300f;
    public Vector2 jumpForce;
    public GameObject bubble;
    public float shootForce = 50f;
    public GameObject playerBody;
    public Gamemanager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        jumpForce = transform.up * jumpHeight;
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootBubbles();
        if (Input.GetKey(KeyCode.D) && isDead == false && gameManager.isPaused == false)
        {
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.A) && isDead == false && gameManager.isPaused == false)
        {
            rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && isDead == false && gameManager.isPaused == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight*3);
        }

        if (isDead)
        {
            playerBody.SetActive(false);
        }

    }


    public void ShootBubbles()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject spawnedBubble = Instantiate(bubble, gameObject.transform.position, transform.rotation);
            spawnedBubble.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.forward * shootForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<Enemy>().enemyDead == false)
        {
            isDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<Enemy>().enemyDead == false)
        {
            isDead = true;
        }
    }
}
