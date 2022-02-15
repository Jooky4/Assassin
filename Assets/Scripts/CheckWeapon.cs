using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWeapon : MonoBehaviour
{
    [SerializeField]
    private Transform parentObject;    // ������ �� �������� 

    [SerializeField]
    [Header("����� �� ������ ����������")]
    private Transform visualEnemy;

    private EnemyController enemyController;

    private Animator animator;

    [Header("��� ����� ������ ����")]
    [SerializeField]
    private int maxHealthBot = 1;

    /// <summary>
    /// ������� �������� ����
    /// </summary>
    [HideInInspector]
    public int currentHealthBot;

    [HideInInspector]
    public bool isDead;


    [SerializeField]
    [Header("������� ������ ������� ����")]
    private ParticleSystem particleSysWound;

    [SerializeField]
    [Header("������� ������ ������ ����")]
    private ParticleSystem particleSys;

    [Header("����� ��������")]
    [SerializeField]
    private float timeAnimDead;

    [Header("����� ��������� ���������")]
    [SerializeField]
    private float timeParticleSystem = 0;



    private void Start()
    {
        currentHealthBot = maxHealthBot;
        animator = visualEnemy.GetComponent<Animator>();
        enemyController = parentObject.GetComponent<EnemyController>();
    }

    void Update()
    {
        
    }


    /// <summary>
    /// ������ ������
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Weapon weapon;
        weapon = other.GetComponent<Weapon>();

        if (weapon)
        {
            TakeDamage(weapon.damage);
        }
    }


    /// <summary>
    /// ��������� �����
    /// </summary>
    /// <param name="damage"></param>
    void TakeDamage(int damage)
    {
        currentHealthBot -= damage;
        if (currentHealthBot < 1)
        {
            Dead();
        }
        else
        {
            Wound();
        }
    }

    /// <summary>
    /// �������
    /// </summary>
    void Wound()
    {
        if (particleSysWound)
        {
            particleSysWound.Play();
        }
    }


    /// <summary>
    /// �������� ������
    /// </summary>
    void Dead()
    {
        isDead = true;
        enemyController.IdleEnemy();

      //  GameController.Instance.currentMoney += enemyController.moneyForBot;  // ������ �� ����������� ����
       // GameController.Instance.countDeadBots++;

        if (animator)
        {
            animator.SetTrigger("Dead");
        }

        StartCoroutine(StartParticleSystem());
    }

    private IEnumerator StartParticleSystem()
    {
        yield return new WaitForSeconds(timeAnimDead);

        if (particleSys)
        {
            particleSys.Play();
        }

        //visualEnemy.gameObject.SetActive(false);

        StartCoroutine(DeActived());
    }


    /// <summary>
    /// ���� ��������� ������
    /// </summary>
    /// <returns></returns>
    private IEnumerator DeActived()
    {
        yield return new WaitForSeconds(timeParticleSystem);
        Debug.Log("DeActived");
       // GameController.Instance.currentCountBots--;
        parentObject.gameObject.SetActive(false);
    }



}
