using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UISample
{
    public class GameManager : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChatUI.Instance.Show();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChatUI.Instance.Close();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                QuestUI.Instance.Show();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                QuestUI.Instance.Close();
            }
        }
    }
}