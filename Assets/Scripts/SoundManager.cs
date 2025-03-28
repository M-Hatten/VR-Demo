using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType {
    CLICK,
    SOLVED,
}

public class SoundCollection{
    private AudioClip[] clips;
    private int lastClipIndex;

    public SoundCollection(string[] clipNames) {
        this.clips = new AudioClip[clipNames.Length];
        for (int i = 0; i < clipNames.Length; i++){
            clips[i] = Resources.Load<AudioClip>("solved");
            if (clips[i] == null){
                Debug.Log($"Can't find audio clip {clipNames[i]}");
            }
        }
        lastClipIndex = -1;
    }

    public AudioClip GetRandClip(){
        if (clips.Length == 0){
            return null;
        }
        else if (clips.Length == 1){
            return clips[0];
        }
        else{
            int index = lastClipIndex;
            while (index == lastClipIndex){
                index = Random.Range(0, clips.Length);
            }
            return clips[index];
        }
    }
}

public class SoundManager : MonoBehaviour{
    // Start is called before the first frame update
    public float mainVolume = 1.0f;
    private Dictionary<SoundType, SoundCollection> sounds;
    private AudioSource audioSrc;
    public static SoundManager Instance { get; private set; }

    //unity life cycle
    private void Awake(){
        Instance = this;
        audioSrc = GetComponent<AudioSource>();
        sounds = new(){
            //click_1 thru 4 are example sound audio files
            {SoundType.CLICK, new(new string[] {"clicks/click_1", "clicks/click_2", "clicks/click_3", "clicks/click_3", "clicks/click_4"}) },
            {SoundType.SOLVED, new(new string[] {"solved" }) }, //solved is an example audio file
         };
        
    }

    public void Play(SoundType type, AudioSource audioSrc = null){
        if (sounds.ContainsKey(type)){
            audioSrc ??= this.audioSrc;
            audioSrc.volume = Random.Range(0.70f, 1.0f) * mainVolume;
            audioSrc.pitch = Random.Range(0.75f, 1.25f);
            audioSrc.clip = sounds[type].GetRandClip();
            audioSrc.Play();
        }
    }

}