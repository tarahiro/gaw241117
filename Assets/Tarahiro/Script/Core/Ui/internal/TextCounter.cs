using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

namespace Tarahiro.Ui
{
    internal class TextCounter : MonoBehaviour
    {

        string m_text = "";
        TextMeshProUGUI m_textMeshProUGUI;
        string m_seLabel;
        KeyCode m_decide;
        float m_textIntervalTime;


        bool isStart = false;
        int textCount = 0;
        float m_Tick = 0;

        public void StartTextCount(string text, TextMeshProUGUI textMeshProUGUI, string SeLabel, KeyCode decide, float textIntervalTime)
        {
            m_text = text;
            m_textMeshProUGUI = textMeshProUGUI;
            m_seLabel = SeLabel;
            m_decide = decide;
            m_textIntervalTime = textIntervalTime;

            isStart = true;
            m_text = text;
            textCount = 0;
            m_Tick = 0;
            m_textMeshProUGUI.text = "";

            SoundManager.PlaySEWithLoop(m_seLabel);

        }

        private void Update()
        {
            if (isStart && !IsEndTextCount)
            {
                if (Input.GetKeyDown(m_decide))
                {
                    SkipText();
                }

                m_Tick += Time.deltaTime;
                if(m_Tick > m_textIntervalTime)
                {
                    m_textMeshProUGUI.text += m_text[textCount];

                    m_Tick = 0;
                    textCount++;

                    if(textCount >= m_text.Length)
                    {
                        End();
                    }
                }
            }
            
        }

        public void SkipText()
        {
            m_textMeshProUGUI.text = m_text;
            End();
        }

        public bool IsEndTextCount { get; private set; } = false;

        void End()
        {
            SoundManager.StopLoopSE();
            IsEndTextCount = true;
        }

    }
}
