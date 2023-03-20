using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;
using static System.Collections.Specialized.BitVector32;

public class CutBlock : MonoBehaviour
{
    [SerializeField] private Transform stockPoint;
    [SerializeField] private Transform startPosition;
    private float step = 0.01f;
    private float progress;
    [SerializeField] private PlayerController playerController;
    public bool platform;
    [SerializeField] private GameObject enemy;

    public void addblick(float i)
    {
        i = i*0.4f;
        gameObject.transform.position = new Vector3(0,0,0); 
        gameObject.transform.position = new Vector3(0, gameObject.transform.localPosition.y + i, 0);
    }
    public void SetParent(PlayerController playerController)
    {
        this.playerController = playerController;
    }
    public void Update()
    {
        if (platform)
        {
             transform.position = Vector3.Lerp(transform.position, stockPoint.transform.position, progress);
             progress += step;
        }
        if (transform.position == stockPoint.transform.position)
        {
            Destroy(gameObject);
            GameObject coin = Instantiate(enemy, new Vector3(-6,1,1),new Quaternion(0,45,0,0));
        }
    }
}
