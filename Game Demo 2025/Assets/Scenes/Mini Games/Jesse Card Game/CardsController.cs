using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Will handle the pairing mechanics
public class CardsController : MonoBehaviour
{
    [SerializeField] Card cardPrefab;
    [SerializeField] Transform gridTransform;
    [SerializeField] Sprite[] sprites;

    private List<Sprite> spritePairs;

    Card firstSelected;
    Card secondSelected;

    int matchCounts;

    private void Start()
    {
        PrepareSprites();
        CreateCards();
    }

     private void PrepareSprites()
     {
        spritePairs = new List<Sprite>();
        for (int i = 0; i < sprites.Length; i++)
        {
            // Help create sprite 2 times to make a pair :)))
            spritePairs.Add(sprites[i]);
            spritePairs.Add(sprites[i]);
        }
        ShuffleSprites(spritePairs);
     }

    void CreateCards()
    {
        for (int i = 0; i < spritePairs.Count; i++)
        {
            Card card = Instantiate(cardPrefab, gridTransform);
            card.SetIconSprite(spritePairs[i]);
            card.controller = this;
        }
    }

    public void SetSelected(Card card)
    {
        if(card.isSelected == false)
        {
            card.Show();

            if(firstSelected == null)
            {
                firstSelected = card;
                return;
            }

            if(secondSelected == null)
            {
                secondSelected = card;
                StartCoroutine(CheckMatching(firstSelected,secondSelected));
                firstSelected = null;
                secondSelected = null;
            }
        }
    }
    // ur code stink, your momma stink, get gud
    IEnumerator CheckMatching(Card a, Card b)
    {
        yield return new WaitForSeconds(0.3f);
        if(a.iconSprite == b.iconSprite)
        {
            // matched!
            matchCounts++;
            if(matchCounts>= spritePairs.Count/2)
            {
                //level completed
                PrimeTween.Sequence.Create()
                    .Chain(PrimeTween.Tween.Scale(gridTransform,Vector3.one*1.2f, 0.2f, ease: PrimeTween.Ease.OutBack))
                    .Chain(PrimeTween.Tween.Scale(gridTransform,Vector3.one, 0.1f));
               
                        /*
                           Start new level after animation(3/6/25)
                            yield return new WaitForSeconds(0.5f);
                            StartNewLevel(); 
                        */
            }
        }
        else
        {
            // Flips the cards back ;(
            a.Hide();
            b.Hide();
        }
    }

    /*(3/6/25)
    void StartNewLevel()
    {
        //reset match counts
        matchCounts = 0;

        //shuffle and reset the cards
        ResetCards();

        //later, add to update MORE CARDS and UI update or display level
    }

    //(3/6/25)
    void ResetCards()
    {
        foreach(Card card in allCards)
        {
            card.Reset();
        }

        //add new cards and change layout?
        ShuffleCards();
    }*/


    // Method to Shuffle sprites (CHAT GPT/ AI)

    void ShuffleSprites(List<Sprite> spriteList)
    {
        for (int i = spriteList.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range (0, i + 1);

            //Swaping the elements at i and randomIndex (CHAT GPT)
            Sprite temp = spriteList[i];
            spriteList[i] = spriteList[randomIndex];
            spriteList[randomIndex] = temp;
        }
    }
}
