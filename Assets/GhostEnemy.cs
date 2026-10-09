using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    public override void Update()
    {
        rb.velocity = new Vector2(player.transform.position.x - gameObject.transform.position.x, player.transform.position.y - gameObject.transform.position.y);
        //gameObject.transform.position = player.transform.position;
    }
}
