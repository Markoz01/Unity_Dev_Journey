using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHungerBar : MonoBehaviour
{
    
    [SerializeField] private Slider slider;
    
    private AnimalHunger animalHunger;

    private void Start()
    {
        if(animalHunger == null)
        {
            animalHunger = GetComponentInParent<AnimalHunger>();
        }

        if(slider == null)
        {
            slider = GetComponent<Slider>();
        }

        if(animalHunger != null && slider != null)
        {
            slider.maxValue = animalHunger.MaxFeed;
            slider.value = animalHunger.CurrentFeed;
        }

    }


    private void Update()
    {
        if(animalHunger != null && slider != null)
        {
            slider.value = animalHunger.CurrentFeed;
        }
    }


}
