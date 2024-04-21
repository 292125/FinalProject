using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField] private AventurePlayer player;
    [SerializeField] private SpriteRenderer[] playerSprites;
    [SerializeField] private Color[] AvenColor;
    [SerializeField] private int colorIndex;
    // Start is called before the first frame update
    void Start()
    {
        HandleplayerColorChanged(0,player.PlayerColorIndex.Value);
        player.PlayerColorIndex.OnValueChanged += HandleplayerColorChanged;
    }

    private void HandleplayerColorChanged(int oldIndex, int newIndex)
    {
        colorIndex = newIndex;
        foreach (var sprite in playerSprites)
        {
            sprite.color = AvenColor[colorIndex];
        }
    }

    private void OnDestroy()
    {
        player.PlayerColorIndex.OnValueChanged -= HandleplayerColorChanged;
    }
}
