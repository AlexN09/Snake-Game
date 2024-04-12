using UnityEngine;

using UnityEngine;

public class PlayMultipleSounds : MonoBehaviour
{
    public AudioSource[] audioSources; // ������ ����������� AudioSource
    public static bool canPlayBorder = false;
    public static bool canPlayFood = false;
    void Start()
    {
        // �������� ��� ���������� AudioSource, ����������� � ����� �������
        audioSources = GetComponents<AudioSource>();

        // ���������, ��� �� ������� ���� ��� ������� ��� ���������� AudioSource
        if (audioSources.Length < 2)
        {
            Debug.LogError("Not enough AudioSources attached to this GameObject.");
            return; // ��������� ���������� ������, ���� �� ������� AudioSource
        }
    }

    void Update()
    {
        // ����������� ������ ���� ��� ������� ������� Space
        if (canPlayBorder)
        {
            audioSources[0].Play();
            canPlayBorder = false;
        }
        // ����������� ������ ���� ��� ������� ������� Escape
        else if (canPlayFood)
        {
            audioSources[1].Play();
            canPlayFood = false;
        }
    }
}
