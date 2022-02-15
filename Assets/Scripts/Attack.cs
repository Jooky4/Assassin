using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("Префаб Оружия")]
    [SerializeField]
    private Transform prefabWeapon;

    [Header("Точка спавна Оружия")]
    [SerializeField]
    private Transform spawnWeapon;

    [SerializeField]
    private Transform parentObject;    // ссылка на родителя 

    private Animator animator;

    void Start()
    {
        animator = parentObject.GetComponent<Animator>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Collision " + collision.transform.name);

    }

    private void OnTriggerEnter(Collider other)
    {
        CheckWeapon checkWeapon = other.GetComponent<CheckWeapon>();

        if (checkWeapon)
        {
            AttackHero(other.transform);
            print("Attack");
        }

    }

    void AttackHero(Transform targetObject)
    {

        if (animator)
        {
            //animator.SetBool("Attack", true);
            print("Animation Attack");
        }

        VisuallAttack(targetObject);
        //Destroy(transformObj.parent.gameObject);
    }

    void VisuallAttack(Transform targetObject)
    {
        Transform tempObj = Instantiate(prefabWeapon, spawnWeapon.position, Quaternion.identity);

        tempObj.LookAt(targetObject);

        Destroy(tempObj.gameObject, 3);


    }

}
