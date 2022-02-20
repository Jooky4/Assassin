using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDamage : MonoBehaviour
{
    [SerializeField]
    public int currentHealthPlayer;

    void Start()
    {
        currentHealthPlayer = GameController.Instance.maxHealthPlayer;
        GameController.Instance.currentHealthPlayer = currentHealthPlayer;
    }

    void Update()
    {
        ChangeHealthPlayer(0);
    }

   void ChangeHealthPlayer(int damage)
    {
        currentHealthPlayer -= damage;
        GameController.Instance.currentHealthPlayer = currentHealthPlayer;

    }

}
