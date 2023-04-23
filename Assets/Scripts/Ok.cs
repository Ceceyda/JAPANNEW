using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ok : MonoBehaviour
{
    Rigidbody2D rb;
    Transform playerTrans;
    
    HealthBar _hb;
    private void Awake()
    {
        
        rb =GetComponent<Rigidbody2D>();
        _hb = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        Invoke("Destroy", 5);
      
    }
    private void Destroy()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _hb.TakeDamage(5);
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;

        rb.velocity = transform.right * -5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
