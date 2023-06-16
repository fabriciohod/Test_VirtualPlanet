using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    [SerializeField] Image img;

    public void SetIcon(Sprite icon) => img.sprite = icon;
}
