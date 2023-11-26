using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [Header("X이미지")]
    public Image m_Image_X;

    [Header("O이미지")]
    public Image m_Image_O;

    private void Awake()
    {
        m_Image_X.GetComponent<Image>().enabled = false;
        m_Image_O.GetComponent<Image>().enabled = false;
    }

    private void Update()
    {
        
    }
}
