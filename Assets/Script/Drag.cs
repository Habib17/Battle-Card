using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform returnTo = null;       //Berinteraksi dengan kelas drop dan dropforopponent berguna untuk memindahkan kartu ke table.
    public Transform previous = null;       //Berinteraksi dengan kelas drop dan dropforopponent berguna untuk mengembalikan kartu ke tempat semula
    public int value;                       //Berinteraksi dengan drop...... berguna untuk perhitungan skor
    public string previousString = null;    //berinteraksi..... berguna untuk seleksi kondisi di kelas bersangkutan diambil dari variabel previous


    public void OnBeginDrag(PointerEventData eventData)             //Method ini dipanggil saat kita memulai untuk drag kartu 
    {                                                                

        returnTo = this.transform.parent;                           //Saat memulai drag maka akan merecord parent dari kartu yang diambil dan akan
        previous = this.transform.parent;                           //Menyimpannya dalam variabel2 diatas.
        previousString = this.transform.parent.name;
        this.transform.SetParent(this.transform.parent.parent);     //Baris kode ini berguna agar kartu yang ditangan tetap rata tengah saat salah satu kartu diambil
        
        GetComponent<CanvasGroup>().blocksRaycasts = false;         //Berguna agar kartu yang diambil tidak menghalangi cursor saat scan raycast, sehingga akan terdeteksi method OnPointerEnter dan OnpointerExit pada kelas drop dan dropopponent tentunya
        this.value = GetComponent<Cards>().value;                   //Mengambil value dari kartu yang diambil
        Debug.Log("Value: " + value);                               //pegecekkan value
    }

    public void OnDrag(PointerEventData eventData)                  //Method ini dipanggil saat kita proses drag kartu
    {
        this.transform.position = eventData.position;               //berguna agar kartu mengikuti arah pergerakan cursor
    }

    public void OnEndDrag(PointerEventData eventData)               //Method dipanggil saat melepas kartu
    {
        this.transform.SetParent(returnTo);                         //Meletakkan kartu sesuai dengan apa yang tertera pada variabel returnTo

        GetComponent<CanvasGroup>().blocksRaycasts = true;          //Dinyalakan lagi raycast block nya agar kartu dapat dipindahkan lagi. Jika tidak dinyalakan kembali maka kartu akan stuck

    }

}
