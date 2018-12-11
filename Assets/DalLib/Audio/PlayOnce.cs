using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayOnce : MonoBehaviour
    {
        [SerializeField] bool interupt = false;
        [SerializeField] AudioSource source;

        private void Awake()
        {
            if (source == null)
                source = GetComponent<AudioSource>();

            source.loop = false;
        }

        public void Play()
        {
            if (!source.isPlaying && interupt == false)
                source.PlayOneShot(source.clip);
        }

    }

}
