using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private GameObject SexPanel;
    [SerializeField] private GameObject HairPanel;
    private GameObject hero;
    private SexConfig config;
   
    
    private void Start()
    {
        SexPanel.SetActive(true);
        HairPanel.SetActive(false);
        
        config = Resources.Load<SexConfig>("SexConfig");
    }

    private void OnEnable()
    {
        ButtonScript.OnChooseButton += LoadObjectName;
    }

    private void OnDisable()
    {
        ButtonScript.OnChooseButton -= LoadObjectName;
    }

    public void SelectHair()
    {
        SexPanel.SetActive(false);
        HairPanel.SetActive(true);
    }
    
    private void LoadObjectName(string sexName)
    {
        var asset = config.GetSex(sexName);
        if(hero!=null) Destroy(hero);
        hero= Instantiate(asset, Vector3.zero, Quaternion.identity);
    }
    
    
}
