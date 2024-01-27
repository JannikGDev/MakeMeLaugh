using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSprites : MonoBehaviour
{
    [SerializeField] private Sprite fullheart;
    [SerializeField] private Sprite halfheart;
    [SerializeField] private Sprite emptyheart;

    private Sprite origSprite;
    private void Start()
    {
        origSprite = this.gameObject.GetComponent<Image>().sprite;
    }
    public void showFullHeart()
    {
        origSprite = fullheart;
    }

    public void showHalfHeart()
    {
        origSprite = halfheart;
    }

    public void showEmptyHeart()
    {
        origSprite = emptyheart;
    }
}
