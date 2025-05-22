using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static AudioManager Instance { get; private set; }

    // BGM 오디오 클립을 인스펙터에서 할당
    [SerializeField] private AudioClip bgmClip;

    private void Awake()
    {
        // 싱글톤 인스턴스 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 존재하는 인스턴스가 있으면 파괴
        }
    }

    private void Start()
    {
        // BGM 재생
        PlayBGM(bgmClip);
    }

    public void PlayBGM(AudioClip clip)
    {
        // AudioSource 컴포넌트를 가져오거나 추가
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.loop = true; // BGM은 반복 재생
        audioSource.Play();
    }
}
