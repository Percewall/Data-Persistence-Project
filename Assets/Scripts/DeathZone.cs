using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] UserControl userControl;    

    private void Start() {
        userControl = GameObject.Find("UserControl").GetComponent<UserControl>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        userControl.GameOver();
    }
}
