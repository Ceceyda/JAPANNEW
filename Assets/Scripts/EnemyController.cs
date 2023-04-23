using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{



    [SerializeField] int maxHealth = 100;
    [SerializeField] AudioSource _as;
    [SerializeField] AudioClip audioClip;
    [SerializeField] ParticleSystem _ps;
    public Image emptyHealthBar;
    public Image fullHealthBar;
    [SerializeField] Animator _enemyAnim;
    Rigidbody2D _rb;
    Collider2D _col;
    public int currentHealth;
    public float healthBarSmooth = 0.05f;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }
    
    public void TakeDamage(int damage)
    {
        _ps.Play();
        _as.PlayOneShot(audioClip);
        _enemyAnim.SetBool("__isHit", true);
        currentHealth -= damage;
        
        

        if (currentHealth <= 1)
        {

            Die();
            _rb.gravityScale = 0;
            _col.enabled = false;
            Invoke("Destroy", 5f);

        }
        Invoke("StopHurt", .3f);

    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
    void StopHurt()
    {
        _ps.Stop();

        _enemyAnim.SetBool("__isHit", false);
    }

    void Die()
    {
        _enemyAnim.SetBool("__isDead", true);
        Debug.Log("Enemy died");
        //GetComponent<Collider2D>().enabled = false;

        this.enabled = false;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
