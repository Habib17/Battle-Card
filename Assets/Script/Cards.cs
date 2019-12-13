using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cards : MonoBehaviour
{
    public int cardId;
    public int value;
    public Sprite image;
    private Skill skill;
    public enumerable.skillNames skillName;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().sprite = image;
        skill = this.GetComponent<Skill>();
        if(skillName == enumerable.skillNames.none){
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void useSkill(){
        Debug.Log(skillName);
        skill.execute(skillName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
