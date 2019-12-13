using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject PlayerScore, penutup1, opponentScore, discard, tableOpponent;   //Untuk melink dengan GameObject PlayerScore

    public int valueNow;            //Variabel untuk menghitung skor
    public string valueString;      //Variabel untuk menampilkan skor

    public void OnPointerEnter(PointerEventData eventData)      //Method dipanggil saat kursor memasuki area yang terkait dengan script ini
    {

    }

    public void OnPointerExit(PointerEventData eventData)       //Method dipanggil saat kursor keluar dari area yang terkait dengan script ini
    {

    }

    public void OnDrop(PointerEventData eventData)              //Method dipanggil saat ada item yang di drop(Setelah operasi drag) ke area terkait dengan script ini
    {
        Debug.Log("+++" + " Move To " + gameObject.name);       //Pengecekan
        Drag d = eventData.pointerDrag.GetComponent<Drag>();    //Inisiasi objek, agar objek kartu yang didrop dapat dikenali
        if (d != null)
        {
            d.returnTo = this.transform;                        //jika objek tersebut ada nilainya maka kartu tersebut akan ditaruh ke area yang terkait dengan script ini
        }

        if(d.previousString == "HandPlayer" && staticVariables.currentTurn == enumerable.Turn.player)                                //Jika kartu berasal dari tangan player dan sekarang gilirannya player
        {
            string scorePlayStr = PlayerScore.GetComponent<UnityEngine.UI.Text>().text;     //transform gameobject ke string
            string scoreOppStr = opponentScore.GetComponent<UnityEngine.UI.Text>().text;
            int scorePlayer = int.Parse(scorePlayStr);                                      //Lalu dari string ke int
            int scoreOpponent = int.Parse(scoreOppStr);
            
            if (d.value < Mathf.Abs(scorePlayer - scoreOpponent) && d.value != 0)                           //Jika value dari kartu yang didrop kurang dari selisih skor player dan musuh
            {
                Debug.Log("Card Value is not sufficient");
                d.returnTo = d.previous;                                                    //Maka kartu akan kembali ke tangan player
            }
            else
            {
                Debug.Log("From Player");
                this.valueNow = d.value + this.valueNow;                        //Maka nilai akan dihitung
                this.valueString = this.valueNow.ToString();
                Debug.Log("Value Now: " + this.valueNow);
                PlayerScore.GetComponent<Text>().text = this.valueString;       //Dan ditampilkan pada GameObject PlayerScore
                penutup1.SetActive(true);
            }

            if(d.value+scorePlayer == scoreOpponent)
            {
                Debug.Log("Discarded");
                foreach(Transform child in this.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }

                GameObject.Destroy(d.gameObject);

                foreach (Transform child in tableOpponent.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }

                valueNow = 0;
                this.valueString = this.valueNow.ToString();
                tableOpponent.GetComponent<DropForOpponent>().valueNow = 0;
                Debug.Log("Value Now: " + this.valueNow);
                PlayerScore.GetComponent<Text>().text = this.valueString;
                PlayerScore.GetComponent<Text>().text = "00";
                opponentScore.GetComponent<Text>().text = "00";
            }
        }

        if (d.previousString == "HandOpponent")                             //Jika kartu berasal dari tangan lawan
        {
            Debug.Log("From Opponent");
            d.returnTo = d.previous;                                        //Maka kartu akan kembali ke tangan lawan
        }

        if (staticVariables.currentTurn == enumerable.Turn.opponent)        //Jika Giliran lawan
        {
            Debug.Log("This is Opponent Turn");
            d.returnTo = d.previous;                                        //Maka kartu akan kembali ke posisi semula
        }

        if (d.previousString == "TableOpponent")                             //Jika Kartu berasal dari meja lawan
        {
            Debug.Log("From Opponent Table");
            d.returnTo = d.previous;                                        //Maka kartu akan kembali ke meja lawan
        }

    }

}
