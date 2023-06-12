using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public LayerMask layerMask;
    public float radius;
    public int damage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Camera.main.transform.forward * speed, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.tag != "Enemy")
        {
            ContactPoint contact = collider.contacts[0];
            Collider[] hitColliders = Physics.OverlapSphere(contact.point, radius, layerMask);

            foreach (Collider col in hitColliders)
            {
                float Distance = Vector3.Distance(col.gameObject.transform.position, transform.position);
                float Damage;
                Damage = damage / (Distance / 3);
                if(col.gameObject.tag == "Enemy")
                {
                    col.gameObject.GetComponent<Enemy>().AddDamage(Mathf.RoundToInt(Damage));
                }

                Debug.Log("Boomed" + col.gameObject.name);
            }
        }

        else
        {
            collider.gameObject.GetComponent<Enemy>().AddDamage(100);

            ContactPoint contact = collider.contacts[0];
            Collider[] hitColliders = Physics.OverlapSphere(contact.point, radius, layerMask);

            foreach (Collider col in hitColliders)
            {
                float Distance = Vector3.Distance(col.gameObject.transform.position, transform.position);
                float Damage;
                Damage = damage / Distance;
                col.gameObject.SendMessage("AddDamage", Mathf.RoundToInt(Damage));

                Debug.Log("Boomed" + col.gameObject.name);
            }
        }
        

        Destroy(this.gameObject);
    }
}
