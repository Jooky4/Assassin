using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{
    [SerializeField]
    private CheckWeapon[] Bots;

    [SerializeField]
    [Header("Скорострельность")]
    private float speedAttack = 0.1f;

    [Header("Префаб Оружия")]
    [SerializeField]
    private Transform prefabWeapon;

    [Header("Точка спавна Оружия")]
    [SerializeField]
    private Transform spawnWeapon;

    [SerializeField]
    private Transform parentObject;    // ссылка на родителя 

    private Animator animator;

    [SerializeField]
    private Transform targetAttack;

    private bool isAttack;

    void Start()
    {
        FindBots();
        animator = parentObject.GetComponent<Animator>();

        StartCoroutine(VisuallAttack());
        //StartCoroutine(TimerAttack());
    }

    void Update()
    {
        //targetAttack = FindTarget();
    }

    void FindBots()
    {
        Bots = FindObjectsOfType(typeof(CheckWeapon)) as CheckWeapon[];
    }

    private Transform FindTarget()
    {
        Transform currentTarget = null;

        float lastDistance = Vector3.Distance(transform.position, Bots[0].transform.position); ;

        foreach (CheckWeapon checkWeapon in Bots)
        {
            if (checkWeapon.gameObject.activeInHierarchy)
            {
                float currentDistance = Vector3.Distance(transform.position, checkWeapon.transform.position);

                if (lastDistance > currentDistance)
                {
                    if (currentDistance < transform.localScale.x / 2)
                    {
                        currentTarget = checkWeapon.transform;

                        lastDistance = currentDistance;
                    }
                }

               
            }
        }

        return currentTarget;
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
            targetAttack = FindTarget();

            if (targetAttack)
            {
                if (targetAttack.gameObject.activeInHierarchy)
                {
                    Transform tempObj = Instantiate(prefabWeapon, spawnWeapon.position, Quaternion.identity);

                    Debug.DrawLine(transform.position, targetAttack.position,Color.red);

                    tempObj.GetComponent<Weapon>().targetAttack = targetAttack;

                    Destroy(tempObj.gameObject, 2);
                }
            }
            yield return new WaitForSeconds(speedAttack);
        }
    }





}
