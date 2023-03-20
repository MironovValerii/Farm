using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator blokAnimator;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform SpawnPoint;
    public int i = 0;
    private int j = 0;
    [SerializeField] private CutBlock CutBlock;
    [SerializeField] private UI UI;
    [SerializeField] private GameObject scythe;
    [SerializeField] private GameObject[] bloks = new GameObject[40];
    private void Start()
    {
        enemy.transform.position = new Vector3(0, 0, 0);
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            animator.SetBool("Run", true);
        }
        if (_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {
            animator.SetBool("Run", false);
        }
    }

    private void OnTriggerEnter(Collider col) 
    {
        if (col.gameObject.CompareTag("Capsule") && i < 40)
        {
            CutBlock.SetParent(this);
            GameObject obj = Instantiate(enemy, SpawnPoint);
            bloks[i] = obj;
            if (bloks[0] != null)
                bloks[0].GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
            i = i + 1;
            UI.SetBlocks(i);
            blokAnimator.SetTrigger("ShakeCoin");
            CutBlock.addblick(i);
        }
        if (col.gameObject.CompareTag("Platform"))
        {
            StartCoroutine(GrowStart(i));
        }
        if (col.gameObject.CompareTag("GardenBed"))
        {
            ActivSikle();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            i = 0;
        }
        if (other.gameObject.CompareTag("GardenBed"))
        {
            OffSikle();
        }
    }
    private IEnumerator GrowStart(int i)
    {
        for (j=i-1; j >= 0; j--)
        {
            bloks[j].GetComponent<CutBlock>().platform = true;
            yield return new WaitForSeconds(0.1f);
            UI.SetBlocks(j);
        }
        yield break;
    }
    public void ActivSikle()
    {
        scythe.SetActive(true);
    }
    public void OffSikle()
    {
        scythe.SetActive(false);
    }
}

