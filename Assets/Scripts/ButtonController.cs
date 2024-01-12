using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject prefHero;
    [SerializeField] private GameObject ContainerHero;
    [SerializeField] private Transform transformInstanHero;
    public void InstanHero(){
        Instantiate(prefHero,ContainerHero.transform).transform.position = transformInstanHero.position;
    }
}
