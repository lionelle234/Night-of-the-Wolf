using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI torchText;
    [SerializeField] private TextMeshProUGUI keyText;
    [SerializeField] private GameObject waterCrest, thunderCrest, shield, fangs;
    [SerializeField] private Image heartsHUD;
    [SerializeField] private Sprite[] heartsList;
    [SerializeField] private SFXController item;
    private int heartsIndex;
    public int torchCount;
    public int keyCount;
    public bool hasWater;
    public bool hasThunder;
    public bool hasShield;
    public bool hasFangs;
    // Start is called before the first frame update
    void Start()
    {
        heartsIndex = 0;

    }

    // Update is called once per frame
    void Update()
    {   
        if (torchText != null && keyText != null)
        {
            torchText.text = torchCount.ToString();
            keyText.text = keyCount.ToString();
        }
        if (heartsHUD != null)
        {
            heartsHUD.sprite = heartsList[heartsIndex];
        }
    }
    
    public void AddItem(string nameObj)
    {
        item.PlaySFX(0);
        switch (nameObj)
        {
            case "Torch":
                torchCount += 1;
                break;
            case "Key":
                keyCount += 1;
                break;
            case "Crest (Water)":
                hasWater = true;
                waterCrest.SetActive(true);
                break;
            case "Crest (Thunder)":
                hasThunder = true;
                thunderCrest.SetActive(true);
                break;
            case "Shield":
                hasShield = true;
                heartsHUD.color = Color.blue;
                shield.SetActive(true);
                break;
            case "Fangs":
                hasFangs = true;
                fangs.SetActive(true);
                break;
        }       
    }

    public void RemoveAllItems()
    {
        torchCount = 0;
        keyCount = 0;
    }

    public void ChangeHearts(int damage)
    {
        
        if (damage == 0)
        {
            item.PlaySFX(0);
            heartsIndex = 0;
        }
        else if (damage == 1)
        {
            item.PlaySFX(0);
            heartsIndex += damage;
        }
        else if (damage == 2)
        {
            if (heartsIndex < 2)
            {
                item.PlaySFX(0);
                heartsIndex += 2;
            }
            else
            {
                heartsIndex = 3;
            }
        }
        else
        {
            heartsIndex = 3;
        }
    }

    public void ResetHearts()
    {
        heartsIndex = 0;
    }
}
