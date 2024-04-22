using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using TMPro;

public class GameHUD : MonoBehaviour
{
    public TMP_Text joinCodeText;

    public void Start()
    {
        joinCodeText.text = HostSingleton.Instance.GameManager.JoinCode;
    }
}
