using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameTern : sbyte
{
    PlayerTern  = 0b0000,
    AITern      = 0b0001
}


public class GameInstance : MonoBehaviour
{
    public GameTern m_StartPlayer = GameTern.PlayerTern;

    public AIPlayer m_AIPlayer;

    private GameTern _CurrentPlayer;

    public GridButton[] m_GridButtons;

    private void Awake()
    {
        _CurrentPlayer = m_StartPlayer;
    }


    private void Start()
    {
        if(_CurrentPlayer == GameTern.AITern)
        {
            int emptyButtonIndex = GetEmptyButtonIndex();

            m_AIPlayer.Play(emptyButtonIndex); // �� ������ O �ɺ��� ����

            _CurrentPlayer = GameTern.PlayerTern;
        }
    }

    public void SetSymbol(GameTern currentPlayer, int buttonIndex)
    {
        if(_CurrentPlayer != currentPlayer)
        {
            return;
        }

        m_GridButtons[buttonIndex].SetSymbol(currentPlayer);

        if(_CurrentPlayer == GameTern.PlayerTern)
        {
            _CurrentPlayer = GameTern.AITern;

            int emptyButtonIndex = GetEmptyButtonIndex();
            // TODO
            // -1 �� ��ȯ�� ��� ���º� ó��

            m_AIPlayer.Play(emptyButtonIndex); // �� ������ O �ɺ��� ����

            _CurrentPlayer = GameTern.PlayerTern;
        }

        // TODO
        // �¸� ���� Ž��
    }

    public int GetEmptyButtonIndex()
    {
        // ��ư�� �������� Ȯ���ϰ�, �� ��ư�� ã�� ��� �� ��ư �ε����� ��ȯ
        //foreach(GridButton button in m_GridButtons)
        //{
        //    if(button.IsClear())
        //    {
        //        return button.m_ButtonIndex;
        //    }
        //}

        // TODO
        // �� ������ �����ϰ� �����Ͽ� �� ��ư �ε����� ��ȯ
        // ���� �ۼ�

        return -1; // ���º� ó��
    }



}
