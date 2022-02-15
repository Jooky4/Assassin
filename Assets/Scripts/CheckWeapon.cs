using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWeapon : MonoBehaviour
{
    [SerializeField]
    private Transform parentObject;    // ссылка на родителя 

    [SerializeField]
    [Header("Ссыль на визуал противника")]
    private Transform visualEnemy;

    private EnemyController enemyController;

    private Animator animator;

    [Header("Мах колво жизней бота")]
    [SerializeField]
    private int maxHealthBot = 1;

    /// <summary>
    /// текущее здоровье бота
    /// </summary>
    [HideInInspector]
    public int currentHealthBot;

    [HideInInspector]
    public bool isDead;


    [SerializeField]
    [Header("Система частиц ранения Бота")]
    private ParticleSystem particleSysWound;

    [SerializeField]
    [Header("Система частиц смерти Бота")]
    private ParticleSystem particleSys;

    [Header("Время анимации")]
    [SerializeField]
    private float timeAnimDead;

    [Header("Время проигрыша партиклов")]
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
    /// чекаем оружие
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
    /// Получение урона
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
    /// Ранение
    /// </summary>
    void Wound()
    {
        if (particleSysWound)
        {
            particleSysWound.Play();
        }
    }


    /// <summary>
    /// анимация смерти
    /// </summary>
    void Dead()
    {
        isDead = true;
        enemyController.IdleEnemy();

      //  GameController.Instance.currentMoney += enemyController.moneyForBot;  // деньги за уничтожение бота
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
    /// выкл полностью обьект
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
