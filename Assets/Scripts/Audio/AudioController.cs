using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioClip[] audioClips;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BGMOff()
    {
        bgmSource.Stop();
    }

    public void BGMOn()
    {
        bgmSource.Play();
    }

    public void BGMChanged(int clipIndex)
    {   
        if (bgmSource.clip != audioClips[clipIndex])
        {
            bgmSource.clip = audioClips[clipIndex];
            BGMOn();
        }

    }
}
