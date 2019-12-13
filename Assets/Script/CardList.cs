using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardList : MonoBehaviour
{
    public GameObject cardprefab, hidden;
    public Sprite[] cardsimg;
    public int[] cardid;
    public int[] value;
    public enumerable.skillNames[] skills;
    public GameObject Deck;



    // Start is called before the first frame update
    private void Awake() {
        initCard();

    }

    private void Start()
    {

    }

    void initCard()
    {
        for (int j = 0; j < 4; ++j)
        {
            for (int i = 0; i < cardid.Length; ++i)
            {
                GameObject obj = GameObject.Instantiate(cardprefab, this.transform);
                obj.GetComponent<Cards>().cardId = cardid[i];
                obj.GetComponent<Cards>().image = cardsimg[i];
                obj.GetComponent<Cards>().value = value[i];
                obj.GetComponent<Cards>().skillName = skills[i];
            }
        }
        if (this.transform.childCount > 0)
        {
            Shuffle();
        }

    }

    public void Shuffle()
    {
        //Parent Sementara untuk menampung kartu yang diacak
        GameObject tempParent = new GameObject();
        //pemindahan childs secara acak dari cardlist ke temp
        while (this.transform.childCount > 0)
        {
            // Find a random index
            int n = Random.Range(0, this.transform.childCount);
            this.transform.GetChild(n).transform.SetParent(tempParent.transform);
        }
        //pemindahan childs yang sudah diacak dari temp ke cardlist
        for (int i = 0; i < tempParent.transform.childCount; i++)
        {
            tempParent.transform.GetChild(0).transform.SetParent(this.transform);
        }
    }
}
//obj.GetComponent<Cards>().transform.position = hidden.transform.position;