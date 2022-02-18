using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float speed = 5.0f;

    [Header("Наносимый урон")]
    public int damage = 1;

    public Transform targetAttack;

    void Start()
    {

    }

    void Update()
    {
        if (targetAttack.gameObject.activeInHierarchy)
        {
            transform.LookAt(targetAttack);
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed);      // огонь и летим
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CheckWeapon>())
        {
            print("Hit");
            Destroy(gameObject);
        }
    }
}
