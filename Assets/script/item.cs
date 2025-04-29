using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public GameObject starBlast,diamondBlast;
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 100f)*Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            if(gameObject.tag=="Star")
            {
                GameManager.Instance.GetStar();
                Instantiate (starBlast, transform.position, Quaternion.identity);
            }
            if (gameObject.tag == "Diamond")
            {
                GameManager.Instance.GetDiamond();
                Instantiate(diamondBlast, transform.position, Quaternion.identity);
            }
            Destroy (gameObject);
        }
    }
}
