using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    public GameInstance m_GameInstance;

    public void Play(int emptyButtonIndex)
    {
        m_GameInstance.SetSymbol(GameTern.AITern, emptyButtonIndex);
    }

}
