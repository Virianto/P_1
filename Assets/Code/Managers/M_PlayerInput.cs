using Code.Utils;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class M_PlayerInput : Singleton<M_PlayerInput>
{
    [Header("Keyboard Flight")]
    [SerializeField] private KeyCode hNegativeTiltKey = KeyCode.E;
    [SerializeField] private KeyCode hPositiveTiltKey = KeyCode.Q;

    private int index = 0;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> songsList = new List<AudioClip>();

    // Mouse Input
    public float MouseX { get; private set; }
    public float MouseY { get; private set; }

    // Keyboard Input
    public float KeyboardRoll { get; private set; }

    // Input Action: Pitch
    public void OnPicth(InputValue value)
    {
        MouseY = value.Get<float>();
    }

    // Input Action: Roll
    public void OnRoll(InputValue value)
    {
        MouseX = value.Get<float>();
    }

    private void Update()
    {
        KeyboardRoll = 0f;

        if (Input.GetKey(hNegativeTiltKey))
            KeyboardRoll -= 1f;

        if (Input.GetKey(hPositiveTiltKey))
            KeyboardRoll += 1f;
    }
    void OnChangeSong()
    {
        index = index + 1;
        if (index > songsList.Count)
        {
            index = 0;
        }
        audioSource.clip = songsList[index];
        audioSource.Play();
    }
    void OnActivateRadio()
    {
        audioSource.clip = songsList[index];
        audioSource.Play();
    }

    void OnDesactivateRadio()
    {
        audioSource.Stop();
    }
}
