using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
      public Button buttonPlayerRule;
      public Button buttonCardRule;

      public Button buttonGameStartConditionRule;

      public Button buttonTurnRule;

      public Button buttonDrawConditionRule;

      public Button buttonGameEndConditionRule;

    public GameObject player, card, gameStartCondition, turn, drawCondition, gameEndCondition;


    public void Awake(){
        buttonPlayerRule.onClick.AddListener(PlayerRule);
        buttonCardRule.onClick.AddListener(CardRule);
        buttonGameStartConditionRule.onClick.AddListener(GameStartConditionRule);
        buttonTurnRule.onClick.AddListener(TurnRule);
        buttonDrawConditionRule.onClick.AddListener(DrawConditionRule);
        buttonGameEndConditionRule.onClick.AddListener(GameEndConditionRule);


    }

       public void PlayerRule(){
        Debug.Log("Permainan ini dimainkan oleh 2 orang pemain");
        player.SetActive(true);
    }

         public void CardRule(){
        Debug.Log("Setiap pemain akan diberikan 10 kartu untuk bermain");
        card.SetActive(true);
    }

    
         public void GameStartConditionRule(){
        Debug.Log("Ketika pemain telah pendapatkan 10 kartu awal, setiap pemain akan mengambil/diberikan 1 kartu yang diambil dari deck, kemudian kartu tersebut akan bibuka bersama, pemain yang mendapatkan angka terkecil dapat memulai permainan terlebih dahulu");
        gameStartCondition.SetActive(true);
    }


          public void TurnRule(){
        Debug.Log("Permainan akan dilakukan secara bergiliran antar pemain. Kecuali player menggunakan kartu skill tertentu yg memberikan pemain giliran tambahan");
        turn.SetActive(true);
    }
    
          public void DrawConditionRule(){
        Debug.Log("Draw terjadi apabila kartu player dan lawan di Arena berjumlah sama, dalam kondisi ini kartu dalam Arena akan dibersihkan dan perhitungan dimulai lagi dari 0 dengan kartu yg ada di tangan, apabila kartu ditangan habis maka dianggap seri.");
        drawCondition.SetActive(true);
    }
    

    



          public void GameEndConditionRule(){
        Debug.Log("Permainan akan berakhir apabila salah satu pemain tidak mampu mengeluarkan angka yang lebih tinggi dari lawan dalam gilirannya(Lose & Win), atau salah satu pemain menyatakan menyerah(Lose). Dalam kondisi ini kartu ditangan player pasti habis");
        gameEndCondition.SetActive(true);
    }



}
