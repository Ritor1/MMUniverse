using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropdawnSelect : MonoBehaviour
{
    public Image ClassImg;
    public Sprite[] ImgSprite;
    public TMP_Dropdown dropdown;
   
    public void OnDropDownChanged(TMP_Dropdown dropDown)
    {
        ClassImg.sprite = ImgSprite[dropDown.value];
    }
}
