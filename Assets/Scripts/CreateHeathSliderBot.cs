using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHeathSliderBot : MonoBehaviour
{

    [Header(" Префаб Слайдера здоровья бота")]
    [SerializeField]
    private Transform prefabHealthSliderBot;

    // Start is called before the first frame update
    void Awake()
    {
        Transform uiHealthSliderBot = Instantiate(prefabHealthSliderBot, Vector3.zero, Quaternion.identity);
        uiHealthSliderBot.transform.SetParent(GameObject.Find("BotsSliders").transform);
        uiHealthSliderBot.GetComponent<UiHealthSliderBot>().bot = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
