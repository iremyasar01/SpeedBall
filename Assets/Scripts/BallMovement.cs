using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine;

public class BallMovement : MonoBehaviour
    //[obsolete] unity bir şeyi güncellediğinde kodder bilsin diye.
{
    public float Speed = 1;
    public GameObject DeadText;
    public GameObject WonText;
    public GameObject ScoreText;
    int score = 0;
    // Script'i taşıyan game object veya component aktif olduğunda bir kereliğine çalıştırılır.
    void Start()
    {
        DeadText.SetActive(false);
        WonText.SetActive(false);
    }

    // Her bir render döngüsünden sonra otomatik olarak bir kez çalıştırılır.
    void Update()
    { //GetComponent<Transform(class'ın adı)>() normalde bir komponente böyle erişilir. Fakat unity transform için kolaylık sağlıyor.
      //transform.position = transform.position + new Vector3(0, 0, 1); //x,yde değişiklik yapma fakat zde ilerle.
      // transform.position += new Vector3(0, 0, 1);
        transform.position += Vector3.forward * Speed;  //komudu da aynısı.

        if (Speed != 0)
        {
            score += 100;
  
            ScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString().PadLeft(6,'0');
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) && Speed != 0)
        {
            transform.position =new Vector3(-0.216f, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && Speed !=0)
        {
            transform.position = new Vector3(0.216f, transform.position.y, transform.position.z);
        }
        //buraya bir if açıp speed=0 ise return diyip de ölmesini sağlayabilirdim.
    }
   private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        { 
            DeadText.SetActive(true);
            //speed'i 0 yapmak demek oyuncunun öldüğü anlamına gelir.
            Speed = 0;
        }
        if (collision.collider.tag == "Finish")
        {
            WonText.SetActive(true);
            Speed = 0; 
        }
    }
}
