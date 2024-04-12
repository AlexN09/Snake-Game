using UnityEngine;

using UnityEngine;

public class PlayMultipleSounds : MonoBehaviour
{
    public AudioSource[] audioSources; // Массив компонентов AudioSource
    public static bool canPlayBorder = false;
    public static bool canPlayFood = false;
    void Start()
    {
        // Получаем все компоненты AudioSource, привязанные к этому объекту
        audioSources = GetComponents<AudioSource>();

        // Проверяем, что на объекте есть как минимум два компонента AudioSource
        if (audioSources.Length < 2)
        {
            Debug.LogError("Not enough AudioSources attached to this GameObject.");
            return; // Прерываем выполнение метода, если не хватает AudioSource
        }
    }

    void Update()
    {
        // Проигрываем первый звук при нажатии клавиши Space
        if (canPlayBorder)
        {
            audioSources[0].Play();
            canPlayBorder = false;
        }
        // Проигрываем второй звук при нажатии клавиши Escape
        else if (canPlayFood)
        {
            audioSources[1].Play();
            canPlayFood = false;
        }
    }
}
