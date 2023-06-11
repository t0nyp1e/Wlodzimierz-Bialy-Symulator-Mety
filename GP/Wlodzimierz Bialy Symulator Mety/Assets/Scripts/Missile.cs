using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public LayerMask layerMask;
    public float radius;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Camera.main.transform.forward * speed, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collider)
    {
        ContactPoint contact = collider.contacts[0];
        Collider[] hitColliders = Physics.OverlapSphere(contact.point, radius, layerMask);

        foreach(Collider col in hitColliders)
        {
            Debug.Log("Boomed" + col.gameObject.name);
        }

        Destroy(this.gameObject);
    }
}
