using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPotionCollision : MonoBehaviour
{
    Image _potion;
    [SerializeField]Text _potionNumber;
    int value = 5;
    [SerializeField] HealthBar _healthManager;

    private void Awake()
    {
        _potionNumber.text= ("x" + value);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            value++;
            _potionNumber.text = "x" + value;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (value>0)
            {
                _healthManager.Heal(10);
                value--;
                _potionNumber.text = "x" + value;
            }
        }
    }
}
