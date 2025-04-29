using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public GameObject PlatformBlast;
    public GameObject Diamond, Star;



    // Start is called before the first frame update
    void Start()
    {
        int randNumber = Random.Range(1, 21);
        Vector3 temPos= transform.position;
        temPos.y += 1.2f ;
        if (randNumber <4 )
        {
            Instantiate(Star, temPos, Star.transform.rotation);
        }
        if (randNumber == 7)
        {
            Instantiate(Diamond, temPos, Diamond.transform.rotation);
        }
    }//start

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("FallDown",0.2f);
        }
    }//oncolexit

    void FallDown()
    {
        Instantiate(PlatformBlast, transform.position, Quaternion.identity);
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject,0.5f);
    }
}
