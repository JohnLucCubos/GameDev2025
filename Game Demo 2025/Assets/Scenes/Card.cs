using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PrimeTween;


public class Card : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    public Sprite hiddenIconSprite;
    public Sprite iconSprite;
    public bool isSelected;
    public CardsController controller;
    public void OnCardClick() => controller.SetSelected(this);
    //cut off
    public void SetIconSprite(Sprite sp) => iconSprite = sp;
    public void Show() => SetCard(180f, iconSprite, true);
    public void Hide() => SetCard(0f, hiddenIconSprite, false);
    private void SetCard(float rotation, Sprite icon, bool state)
    {
        Tween.Rotation(transform, new Vector3(0f, rotation, 0f), 0.2f);
        iconImage.sprite = icon;
        isSelected = state;
    }
}
