using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public bool isBlock = false;
    public ParticleSystem _ps;
    public AudioSource _ac;
    public AudioClip _audioClip,_blockClip;
    public Image emptyHealthBar;
    public Image fullHealthBar;
    public float maxHealth = 100f;
    public float currentHealth;
    public float healthBarSmooth = 0.05f;
    [SerializeField] Animator _playerAnim;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _panel;

    private void Start()
    {
        isBlock = false;
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float ratio = Mathf.Lerp(fullHealthBar.rectTransform.localScale.x, currentHealth / maxHealth, healthBarSmooth * Time.deltaTime);
        fullHealthBar.rectTransform.pivot = new Vector2(0, 0.5f);
        fullHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        if (currentHealth>1)
        {
            //_playerAnim.SetBool("__isHurt", false);

        }
        if (currentHealth <=1)
        {

            _playerAnim.Play("Player_death");
            Invoke("Death", 1);
            //Time.timeScale = 0;
        }
    }
    void Death()
    {
        _panel.SetActive(true);
        _player.GetComponent<PlayerController>().enabled = false;
        Time.timeScale = 0;
    }
    public void TakeDamage(float damage)
    {
        
            _ps.Play();
            _ac.PlayOneShot(_audioClip);
            _playerAnim.SetBool("__isHurt", true);
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            Invoke("StopHurt", .4f);
            isBlock = false;
        
    }
    void StopHurt()
    {
        _playerAnim.SetBool("__isHurt", false);
        _ps.Stop();

    }
    public void Heal(float healAmount)
    {
        if (currentHealth<100f)
        {
            currentHealth += healAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        }
        
    }
    private void FixedUpdate()
    {
        //isBlock = false;
    }
    private void Update()
    {
        UpdateHealthBar();

        

        
    }


}
