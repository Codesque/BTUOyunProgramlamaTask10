using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BuffType { 

    NONE ,
    TRIPLE_SHOT,
    ACCELERATE


}





public class BuffController : MonoBehaviour
{

    public int Speed = 2;
    public float duration = 5f;
    public float PlayerSpeedMultiplier = 1.0f;

    public BuffType Type;



    // TryGetComponent eger degen nesnede BeanController varsa true doner. 
    // BeanController'daki ActivateTripleShot uclu atisi aktif eder. 
    // Daha sonra obje kendini yok eder.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BeanController>(out BeanController player)) {


            player.PlayBuffSound();


            switch (Type) {

                case BuffType.TRIPLE_SHOT:
                    player.ActivateTripleShot(duration);
                    break;

                case BuffType.ACCELERATE:
                    player.ActivateAcceleration(duration , PlayerSpeedMultiplier);
                    break;

                default:
                    Debug.LogWarning("SwitchReturnedNull");
                    break;

            
            
            }
            Destroy(this.gameObject);
        }
            
    }


    // OnTriggerEnter2D fonksiyonu Update'den once calistigi icin
    // Buffin player'a degmesine ragmen -7.1'e degip yok olma gibi bir olayi yok.

    private void FixedUpdate()
    {
        transform.position += Vector3.down * Time.deltaTime * Speed  ;
        if(transform.position.y < -7f) Destroy(this.gameObject);
    }




}
