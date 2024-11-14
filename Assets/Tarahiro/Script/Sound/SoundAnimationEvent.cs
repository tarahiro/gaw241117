using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAnimationEvent:MonoBehaviour
{
    public void PlaySE(string seLabel)
    {
        SoundManager.PlaySE(seLabel);
    }
}
