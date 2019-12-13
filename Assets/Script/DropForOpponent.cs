using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropForOpponent : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler       
{

    public GameObject OpponentScore, penutup, playerScore, discard, table;                //Untuk melink dengan GameObject OpponentScore

    public int valueNow;                            //Variabel untuk menghitung skor
    public string valueString;                      //Variabel untuk menampilkan skor

    public void OnPointerEnter(PointerEventData eventData)      //Method dipanggil saat kursor memasuki area yang terkait dengan script ini
    {

    }

    public void OnPointerExit(PointerEventData eventData)       //Method dipanggil saat kursor keluar dari area yang terkait dengan script ini
    {

    }

    public void OnDrop(PointerEventData eventData)              //Method dipanggil saat ada item yang di drop(Setelah operasi drag) ke area terkait dengan script ini
    {
        Debug.Log("+++" + " Move To " + gameObject.name);       
        Drag d = eventData.pointerDrag.GetComponent<Drag>();    //Inisiasi objek, agar objek kartu yang didrop dapat dikenali
        if (d != null)
        {
            d.returnTo = this.transform;                        //jika objek tersebut ada nilainya maka kartu tersebut akan ditaruh ke area yang terkait dengan script ini
        }
                                                                
        if(d.previousString == "HandPlayer")                    //Jika kartu berasal dari tangan player
        {
            Debug.Log("From Player");
            d.returnTo = d.previous;                            //Maka akan kembali ke tangan Player
        }

        if (staticVariables.currentTurn == enumerable.Turn.player)        //Jika Giliran player
        {
            Debug.Log("This is Player Turn");
            d.returnTo = d.previous;                                        //Maka kartu akan kembali ke posisi semula
        }

        if (d.previousString == "HandOpponent" && staticVariables.currentTurn == enumerable.Turn.opponent)                 //Jika Kartu berasal dari tangan Opponent dan sekarang gilirannya opponent
        {
            string scorePlayStr = playerScore.GetComponent<UnityEngine.UI.Text>().text;     //transform gameobject ke string
            string scoreOppStr = OpponentScore.GetComponent<UnityEngine.UI.Text>().text;
            int scorePlayer = int.Parse(scorePlayStr);                                      //Lalu dari string ke int
            int scoreOpponent = int.Parse(scoreOppStr);

            if (d.value < Mathf.Abs(scorePlayer - scoreOpponent) && d.value != 0)                           //Jika value dari kartu yang didrop kurang dari selisih skor player dan musuh
            {
                Debug.Log("Card Value is not sufficient");
                d.returnTo = d.previous;                                                    //Maka kartu akan kembali ke tangan opponent
            }
            else
            {
                Debug.Log("From Opponent");
                this.valueNow = d.value + this.valueNow;                            //Maka nilai akan dihitung
                this.valueString = this.valueNow.ToString();
                Debug.Log("Value Now: " + this.valueNow);
                OpponentScore.GetComponent<Text>().text = this.valueString;         //Dan ditampilkan pada GameObject PlayerScore
                penutup.SetActive(true);
            }

            if (d.value + scoreOpponent == scorePlayer)
            {
                Debug.Log("Discarded");
                foreach (Transform child in this.transform)
                {
                    GameObject.Destroy(child.gameObject);
                    
                }

                GameObject.Destroy(d.gameObject);

                foreach (Transform child in table.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }

                valueNow = 0;
                this.valueString = this.valueNow.ToString();
                table.GetComponent<Drop>().valueNow = 0;
                Debug.Log("Value Now: " + this.valueNow);
                playerScore.GetComponent<Text>().text = this.valueString;
                playerScore.GetComponent<Text>().text = "00";
                OpponentScore.GetComponent<Text>().text = "00";
            }
        }

        if (d.previousString == "Table")            //Jika Kartu berasal dari meja player
        {
            Debug.Log("From Player Table");
            d.returnTo = d.previous;                //Maka kartu akan kembali ke meja player
        }
    }

}
