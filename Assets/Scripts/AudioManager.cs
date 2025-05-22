using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ�
    public static AudioManager Instance { get; private set; }

    // BGM ����� Ŭ���� �ν����Ϳ��� �Ҵ�
    [SerializeField] private AudioClip bgmClip;

    private void Awake()
    {
        // �̱��� �ν��Ͻ� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject); // �̹� �����ϴ� �ν��Ͻ��� ������ �ı�
        }
    }

    private void Start()
    {
        // BGM ���
        PlayBGM(bgmClip);
    }

    public void PlayBGM(AudioClip clip)
    {
        // AudioSource ������Ʈ�� �������ų� �߰�
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.loop = true; // BGM�� �ݺ� ���
        audioSource.Play();
    }
}
