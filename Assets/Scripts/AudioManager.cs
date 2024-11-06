using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource m_AudioSource;
    public List<AudioClip> audioClips = new List<AudioClip>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int ClipIdx)
    {
        m_AudioSource.clip = audioClips[ClipIdx];
        m_AudioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
