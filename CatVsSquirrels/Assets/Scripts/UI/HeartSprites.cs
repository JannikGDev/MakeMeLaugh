using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSprites : MonoBehaviour
{
    [SerializeField] private Sprite fullheart;
    [SerializeField] private Sprite halfheart;
    [SerializeField] private Sprite emptyheart;
    
    private Image origSprite;
    private void Start()
    {
        origSprite = this.gameObject.GetComponent<Image>();
    }
    public void showFullHeart()
    {
        origSprite.sprite = fullheart;
    }

    public void showHalfHeart()
    {
        origSprite.sprite = halfheart;
    }

    public void showEmptyHeart()
    {
        origSprite.sprite = emptyheart;
    }
}
