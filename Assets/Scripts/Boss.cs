using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] Transform player;
    public bool isFlipped;
    [SerializeField] GameObject _ok;
    [SerializeField] Transform _okTrans;
    Rigidbody2D rb;
    AudioSource _as;
    [SerializeField] AudioClip audioClip;
    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (transform.position.x>player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        
    }

    public void Ok()
    {
        _as.PlayOneShot(audioClip);
            Instantiate(_ok, _okTrans.position, _okTrans.rotation);


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
