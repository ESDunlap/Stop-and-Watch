using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class KeepVolumeSliders : MonoBehaviour
{
    private Slider slider;
    public string volumeName;
    public AudioMixer audioMixer;
    void Start()
    {
        float rawFloat;
        slider = GetComponent<Slider>();
        audioMixer.GetFloat(volumeName, out rawFloat);
        Debug.Log(rawFloat);
        slider.value = Mathf.Pow(10, rawFloat / 20);
    }
}
