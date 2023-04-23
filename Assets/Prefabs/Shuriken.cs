using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    Rigidbody2D  rb;
    GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(10);
            Destroy(gameObject);
            
        }
    }
    private void FixedUpdate()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        if (player.GetComponent<SpriteRenderer>().flipX
)
        {
            rb.velocity = transform.right * -7;

        }
        else
        {
            rb.velocity = transform.right * 7;

        }

    }
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("Destroy", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
