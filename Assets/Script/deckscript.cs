using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deckscript : MonoBehaviour
{
    public GameObject player1, player2, handPlayer, handOpponent;
    public GameObject Deck, Drop, canvas, playerScore, opponentScore, endTurn, arena, penutup, penutup1, hasil, textHasil, player1Sign, player2Sign;

    private void Start() {

        int temp = Deck.transform.childCount;
        
        for (int i = 0; i < 10; i++)
        {
                Draw();
        } 
     
    }
    public void Draw(){
        if (staticVariables.currentTurn == enumerable.Turn.player){
            //Deck.transform.position = player2.transform.position;
            Deck.transform.GetChild(0).SetParent(handPlayer.transform);
            staticVariables.currentTurn = enumerable.Turn.opponent;
        }else if(staticVariables.currentTurn == enumerable.Turn.opponent){
            //Deck.transform.position = player1.transform.position;
            Deck.transform.GetChild(0).SetParent(handOpponent.transform);
            staticVariables.currentTurn = enumerable.Turn.player;
        }
    }
    public void EndTurn()
    {
        if (staticVariables.currentTurn == enumerable.Turn.player && penutup1.activeSelf == true)
        {
            if (handPlayer.transform.childCount < 1 && handOpponent.transform.childCount < 1)
            {
                hasil.SetActive(true);
                string scorePlayStr = playerScore.GetComponent<UnityEngine.UI.Text>().text;
                string scoreOppStr = opponentScore.GetComponent<UnityEngine.UI.Text>().text;
                int scorePlayer = int.Parse(scorePlayStr);
                int scoreOpponent = int.Parse(scoreOppStr);
                if (scorePlayer > scoreOpponent)
                {
                    textHasil.GetComponent<UnityEngine.UI.Text>().text = "Player 1 win with: " + scorePlayStr + " points";
                }
                else
                {
                    textHasil.GetComponent<UnityEngine.UI.Text>().text = "Player 2 win with: " + scoreOppStr + " points";
                }
            }
            else
            {
                staticVariables.currentTurn = enumerable.Turn.opponent;
                /*canvas.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
                playerScore.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
                opponentScore.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
                endTurn.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
                player1Sign.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
                player2Sign.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
                arena.GetComponent<Transform>().Rotate(new Vector3(0, 0, 180));*/
                penutup1.SetActive(true);
                penutup.SetActive(false);

            }
        }
        else if (staticVariables.currentTurn == enumerable.Turn.opponent && penutup.activeSelf == true)
        {
            staticVariables.currentTurn = enumerable.Turn.player;
            /*canvas.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
            playerScore.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
            opponentScore.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
            endTurn.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
            player1Sign.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
            player2Sign.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 180));
            arena.GetComponent<Transform>().Rotate(new Vector3(0, 0, 180));*/
            penutup1.SetActive(false);
            penutup.SetActive(true);
            if (handPlayer.transform.childCount < 1 && handOpponent.transform.childCount < 1)
            {
                hasil.SetActive(true);
                string scorePlayStr = playerScore.GetComponent<UnityEngine.UI.Text>().text;
                string scoreOppStr = opponentScore.GetComponent<UnityEngine.UI.Text>().text;
                int scorePlayer = int.Parse(scorePlayStr);
                int scoreOpponent = int.Parse(scoreOppStr);
                if (scorePlayer > scoreOpponent)
                {
                    textHasil.GetComponent<UnityEngine.UI.Text>().text = "Player 1 win with: " + scorePlayStr + " points";
                }
                else
                {
                    textHasil.GetComponent<UnityEngine.UI.Text>().text = "Player 2 win with: " + scoreOppStr + " points";
                }
            }
        }
    }
    public void ExitGame()
    {
        Debug.Log("Keluar Dari Game");
        Application.Quit();
    }

    public void Forfeit()
    {
        hasil.SetActive(true);
        string scorePlayStr = playerScore.GetComponent<UnityEngine.UI.Text>().text;
        string scoreOppStr = opponentScore.GetComponent<UnityEngine.UI.Text>().text;
        int scorePlayer = int.Parse(scorePlayStr);
        int scoreOpponent = int.Parse(scoreOppStr);
        if (scorePlayer > scoreOpponent)
        {
            textHasil.GetComponent<UnityEngine.UI.Text>().text = "Player 1 win with: " + scorePlayStr + " points";
        }
        else
        {
            textHasil.GetComponent<UnityEngine.UI.Text>().text = "Player 2 win with: " + scoreOppStr + " points";
        }
    }
}
