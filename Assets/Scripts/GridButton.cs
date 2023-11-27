using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridButton : MonoBehaviour
{
    public GameInstance m_GameInstace;

    public int m_ButtonIndex;

    public GameObject m_OImage;
    public GameObject m_XImage;

    private Button _ButtonComponent;

    private void Awake()
    {
        _ButtonComponent = GetComponent<Button>();
        _ButtonComponent.onClick.AddListener(OnGridButtonClicked);

        m_OImage.gameObject.SetActive(false);
        m_XImage.gameObject.SetActive(false);
    }

    private void OnGridButtonClicked()
    {
        m_GameInstace.SetSymbol(GameTern.PlayerTern, m_ButtonIndex);
    }

    public void SetSymbol(GameTern currentPlayer)
    {
        if(currentPlayer == GameTern.AITern)
        {
            // O 를 표시
            m_OImage.gameObject.SetActive(true);

        }
        else
        {
            // X 를 표시
            m_XImage.gameObject.SetActive(true);

        }
    }

    public bool IsClear()
    {
        if(m_OImage.gameObject.activeSelf || m_XImage.gameObject.activeSelf)
        {
            return false;
        }

        return true;

    }
}
