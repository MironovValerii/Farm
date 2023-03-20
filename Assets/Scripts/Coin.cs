using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static System.Collections.Specialized.BitVector32;

public class Coin : MonoBehaviour
{
    private int coin;
    private Transform _transform;
    private UI ui;
    private GameObject _gameObject;
    private Tween _tween;
    private float dist= 2;
    private Animator animator;

    private void Update()
    {
        if (dist < 1)
        {
            animator.SetTrigger("ShakeCoin");
            _tween.Kill();
            Delete();
            coin++;
            ui.SetCoin(coin);
        }
        else
        {
            dist = Vector3.Distance(transform.position, _transform.position);
        }
    }
    private void Start()
    {
        _tween = transform.DOMove(_transform.position, 0.1f);
    }
    private void Delete()
    {
        Destroy(gameObject);
    }
    private void Awake()
    {
        _transform = GameObject.Find("point").transform;
        _gameObject = GameObject.Find("Canvas");
        ui = _gameObject.GetComponent<UI>();
        var obj = GameObject.Find("UICoin");
        animator = obj.GetComponent<Animator>();
    }
}
