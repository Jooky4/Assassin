using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHealthSliderBot : MonoBehaviour
{
    
    //[HideInInspector]
    public Transform bot;

    private Slider slider;

    [SerializeField]
    private int currentHealthBot;

    [SerializeField]
    private CheckWeapon checkWeapon;

    private RectTransform rectTransform;

    private int maxHealthBot;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        slider = GetComponent<Slider>();
        checkWeapon = bot.GetComponentInChildren<CheckWeapon>();
        maxHealthBot = checkWeapon.maxHealthBot;
        slider.maxValue = maxHealthBot;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateValueSlider();
        if (!bot.gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }

    void UpdateValueSlider()
    {
        Vector3 botPosition = new Vector3(bot.position.x, bot.position.y + 2.0f, bot.position.z);

        rectTransform.position = Camera.main.WorldToScreenPoint(botPosition);

        currentHealthBot = checkWeapon.currentHealthBot;

        slider.value = currentHealthBot;
    } 

}
