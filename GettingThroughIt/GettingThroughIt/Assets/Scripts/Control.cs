using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float force;

    bool isGrounded = false;
    bool jumpReady = false;

    public AudioClip[] hits;
    public AudioSource myAud;

    float timer = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0 && jumpReady == false)
        {
            timer -= Time.deltaTime;
        }
        else if(jumpReady == false)
        {
            jumpReady = true;
        }

        bool lmb = Input.GetMouseButtonDown(0);
        if(lmb && isGrounded && jumpReady)
        {
            Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 objPos = Camera.main.ScreenToWorldPoint (mousePos);

            Vector3 dir = objPos - this.transform.position;

            this.GetComponent<Rigidbody> ().AddForce (dir * force, ForceMode.Impulse);

            //this.GetComponent<Rigidbody> ().AddExplosionForce(force, objPos, 50);
            Debug.Log("Applying");

            jumpReady = false;
            timer = 0.5f;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        isGrounded = true;

        if (col.gameObject.tag == "Switch")
        {
            End();
        }
        myAud.PlayOneShot (hits [Random.Range(0, hits.Length)]);

    }
    void OnCollisionStay(Collision col)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision col)
    {
        isGrounded = false;
    }

    void End()
    {

    }
}
