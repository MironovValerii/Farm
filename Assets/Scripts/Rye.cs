using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Rye : MonoBehaviour
{
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private GameObject rye;
    [SerializeField] private GameObject capsule;
    [SerializeField] private GameObject effect;
    private void ActivRye()
    {
        boxCollider.enabled = true;
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Instantiate(effect, new Vector3(col.gameObject.transform.position.x, 2, col.gameObject.transform.position.z), Quaternion.identity);
            capsule.SetActive(true);
            rye.SetActive(false);
        }
    }
}
