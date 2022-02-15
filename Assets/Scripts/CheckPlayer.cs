using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    [Header("Командир отряда")]
    [SerializeField]
    private EnemyController teamLead;


    [SerializeField]
    private EnemyController enemyController;

    [Header("Ссыль на Героя")]
    [SerializeField]
    private MoveController moveController;

    [Header("Ссыль на VisuallDistanceAttack")]
    [SerializeField]
    private Transform visuallDistanceAttack;

    //[SerializeField]
    private float valueScaleDistanceAttack;

   // [SerializeField]
    private float distance;

    [SerializeField]
    public bool isPlayer;


    void Start()
    {
        // moveController = GetComponent<MoveController>();
        valueScaleDistanceAttack = visuallDistanceAttack.localScale.x / 2;
    }


    void Update()
    {
        if (!isPlayer) UpdateCheckTarget();

    }


    void UpdateCheckTarget()
    {
        GetTeamLead();
        distance = CheckDistance(transform, moveController.transform);

        if (distance < valueScaleDistanceAttack)
        {
            isPlayer = true;
            SetEnemyTarget();
        }
    }


    public float CheckDistance(Transform firstObj, Transform secondObj)
    {
        float result = 0.0f;
        result = Vector3.Distance(firstObj.position, secondObj.position);

        return result;
    }

    void SetEnemyTarget()
    {
        enemyController.currentTarget = moveController.transform;
    }

    void GetTeamLead()
    {
        if (teamLead)
        {
            if (teamLead.currentTarget)
            {
                enemyController.currentTarget = teamLead.currentTarget;
                isPlayer = true;
            }
        }
    }

}
