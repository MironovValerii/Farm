using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    [SerializeField] private CapsuleCollider capsuleCollider;
    [SerializeField] private GameObject sprout;
    [SerializeField] private Sprout sprout1;
    [SerializeField] private Transform stockPoint;
    private float step;
    private float progress;
    public bool _bool;

    public void ActivCapsule()
    {
        capsuleCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<PlayerController>().i <=39)
        {
            gameObject.SetActive(false);
            sprout.SetActive(true);
            sprout1.Corutin();
            capsuleCollider.enabled = false;
        }
    }
    private void FixedUpdate()
    {
        if (_bool)
        {
            Debug.Log("11");
            transform.position = Vector3.Lerp(transform.position, stockPoint.transform.position, progress);
            progress += step;
        }
        if (transform.position.x == stockPoint.transform.position.x && transform.position.y == stockPoint.transform.position.y && transform.position.z == stockPoint.transform.position.z)
        {
            gameObject.SetActive(false);
            _bool = false;           
        }
    }
}
