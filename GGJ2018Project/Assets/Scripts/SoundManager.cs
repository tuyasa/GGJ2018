using Managers;
using UnityEngine;

namespace Managers
{
    public class SoundManager : PersistentSingleton<SoundManager>
    {
        public GameObject SFXPrefab;
        public GameObject BackgroundMusicPrefab;
        private BackgroundMusic _music;

        public void PlaySoundSFX(AudioClip audioClip)
        {
            GameObject go = Instantiate(SFXPrefab);
            AudioSource audioSource = go.GetComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();
            if (audioClip != null)
                Destroy(go.gameObject, audioClip.length);
        }

        public void PlayeBackgroundMusic(AudioClip audioClip)
        {
            //remove old bg music
            if (_music != null)
                Destroy(_music.gameObject);
            GameObject go = Instantiate(BackgroundMusicPrefab);
            AudioSource audioSource = go.GetComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();
            _music = go.GetComponent<BackgroundMusic>();
        }

    }
}