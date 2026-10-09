using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyBody;
    public bool enemyDead = false;
    public float speed = 0.0001f;
    public Rigidbody2D rb;
    public BoxCollider2D bc;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = GameObject.Find("Player");
        bc.GetComponent<BoxCollider2D>();
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (enemyDead == false)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (rb.velocity.magnitude > speed)
            {
                rb.velocity = rb.velocity.normalized * speed;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            speed *= -1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bubble")
        {
            bc.enabled = false;
            enemyDead = true;
            enemyBody.SetActive(false);
            Destroy(collision.gameObject);
        }
    }
}
