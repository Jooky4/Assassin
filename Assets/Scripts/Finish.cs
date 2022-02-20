using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        MoveController currentObject = other.GetComponent<MoveController>();

        if (currentObject)
        {
            print("Win");
            if (GameController.Instance)
            {
                GameController.Instance.stateGame = StateGame.WinGame;

            }

        }
    }
}
