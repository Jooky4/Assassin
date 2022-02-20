using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    [SerializeField]
    private CheckHero checkHero;

    //[SerializeField]
    private EnemyController enemyController;

    // [Header("—сыль на √еро€")]
    // [SerializeField]
    private MoveController moveController;

    
    [SerializeField]
    private Transform visuallDistance;

    //[SerializeField]
    private Transform currentTarget;

    [SerializeField]
    private float valueScaleDistanceAttack;

    [SerializeField]
    private float distance;

    [SerializeField]
    public bool isPlayer;


    void Start()
    {
        moveController = FindObjectOfType(typeof(MoveController)) as MoveController;

        enemyController = GetComponentInParent<EnemyController>();

        checkHero = GetComponentInParent<CheckHero>();

       // visuallDistanceAttack = transform;

        valueScaleDistanceAttack = visuallDistance.localScale.x / 2;
    }


    void Update()
    {
        if (!isPlayer) UpdateCheckTarget();

    }


    void UpdateCheckTarget()
    {
        //GetTeamLead();
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
        //if (teamLead)
        //{
        //    if (teamLead.currentTarget)
        //    {
        //        enemyController.currentTarget = teamLead.currentTarget;
        //        isPlayer = true;
        //    }
        //}
    }

}
