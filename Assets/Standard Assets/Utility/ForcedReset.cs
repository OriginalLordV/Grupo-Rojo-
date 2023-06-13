using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Image))] // Replace GUITexture with Image
public class ForcedReset : MonoBehaviour
{
    private void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}
