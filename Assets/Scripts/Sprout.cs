using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprout : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject rye;
    [SerializeField] private GameObject capsule;
    private void Start()
    {
        gameObject.SetActive(true);
        StartCoroutine(GrowStart());
    }
    public void Corutin()
    {
        StartCoroutine(GrowStart());
    }
    private IEnumerator GrowStart()
    {
        yield return new WaitForSeconds(8);
        animator.SetTrigger("StartFall");
        rye.SetActive(true);
        yield break;
    }
    private void OffActive()
    {
        gameObject.SetActive(false);
    }
}
