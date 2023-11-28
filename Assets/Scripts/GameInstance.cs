using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

            m_AIPlayer.Play(emptyButtonIndex); // 빈 공간에 O 심볼을 설정

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
            // -1 을 반환한 경우 무승부 처리
            if(emptyButtonIndex == -1)
            {
                Debug.Log("무승부");
            }

            m_AIPlayer.Play(emptyButtonIndex); // 빈 공간에 O 심볼을 설정

            _CurrentPlayer = GameTern.PlayerTern;
        }

        // TODO
        // 승리 조건 탐색
    }

    public int GetEmptyButtonIndex()
    {
        // 버튼을 순차적을 확인하고, 빈 버튼을 찾은 경우 그 버튼 인덱스를 반환
        //foreach(GridButton button in m_GridButtons)
        //{
        //    if(button.IsClear())
        //    {
        //        return button.m_ButtonIndex;
        //    }
        //}

        // TODO
        // 빈 공간을 랜덤하게 선택하여 그 버튼 인덱스를 반환
        // 로직 작성
        for(int i=0; i<m_GridButtons.Length; ++i)
        {
            int rand = Random.Range(0,m_GridButtons.Length);
            if (m_GridButtons[rand].IsClear())
            {
                
                return rand;
            }
        }

        return -1; // 무승부 처리
    }



}
