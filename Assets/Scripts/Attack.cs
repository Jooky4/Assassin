using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private CheckWeapon[] Bots;

    [SerializeField]
    [Header("����������������")]
    private float speedAttack = 0.1f;

    [Header("������ ������")]
    [SerializeField]
    private Transform prefabWeapon;

    [Header("����� ������ ������")]
    [SerializeField]
    private Transform spawnWeapon;

    [SerializeField]
    private Transform parentObject;    // ������ �� �������� 

    private Animator animator;

    [SerializeField]
    private Transform targetAttack;

    private bool isAttack;

    void Start()
    {
        FindBots();
        animator = parentObject.GetComponent<Animator>();
        // StartCoroutine(VisuallAttack());
        StartCoroutine(TimerAttack());
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

    void AttackHero(Transform target)
    {

        if (animator)
        {
            //animator.SetBool("Attack", true);
            print("Animation Attack");
        }

        VisuallAttack(target);
        //Destroy(transformObj.parent.gameObject);

        //targetAttack = target;
    }

    void VisuallAttack(Transform targetObject)
    {
        if (isAttack)
        {
            Transform tempObj = Instantiate(prefabWeapon, spawnWeapon.position, Quaternion.identity);

            tempObj.GetComponent<Weapon>().targetAttack = targetObject;

            Destroy(tempObj.gameObject, 1);

        }

        isAttack = false;
    }


    IEnumerator TimerAttack()
    {
        while (true)
        {
            isAttack = true;
            yield return new WaitForSeconds(speedAttack);
        }
    }


    IEnumerator VisuallAttack()
    {
        while (true)
        {
            if (targetAttack)
            {
                if (targetAttack.gameObject.activeInHierarchy)
                {
                    Transform tempObj = Instantiate(prefabWeapon, spawnWeapon.position, Quaternion.identity);

                    tempObj.GetComponent<Weapon>().targetAttack = targetAttack;

                    Destroy(tempObj.gameObject, 2);
                }
            }
            yield return new WaitForSeconds(speedAttack);
        }
    }



    void FindBots()
    {
        Bots = FindObjectsOfType(typeof(CheckWeapon)) as CheckWeapon[];
    }

}
