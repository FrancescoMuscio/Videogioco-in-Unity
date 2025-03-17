using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestoreAudio : MonoBehaviour{
    public static GestoreAudio instance;
    private static readonly string FirstPlay = "FirstPlay"; 
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundsPref = "SoundsPref";
    private AudioSource Musica;
    [SerializeField] AudioClip MusicaGioco;
    public Slider MusicaSlider;
    public Slider SoundSlider;
    private float AudioBack;
    private float SoundBack;
    private int First;

    private void Awake(){
        if (instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(gameObject);
        }

        Musica = gameObject.AddComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }

    private void Start(){
        First = PlayerPrefs.GetInt(FirstPlay);
        if (First == 0){
            AudioBack = 1;
            SoundBack = 0.5f;
            MusicaSlider.value = AudioBack;
            SoundSlider.value = SoundBack;

            PlayerPrefs.SetFloat(BackgroundPref, AudioBack);
            PlayerPrefs.SetFloat(SoundsPref, SoundBack);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }else{
            AudioBack = PlayerPrefs.GetFloat(BackgroundPref);
            MusicaSlider.value = AudioBack;
            SoundBack = PlayerPrefs.GetFloat(SoundsPref);
            SoundSlider.value = SoundBack;
        }

        Musica.loop = true;
        Musica.volume = 1;
        Musica.clip = MusicaGioco;
        Musica.playOnAwake = true;
        Musica.Play();
    }

    public void UpdateSound(){
        Musica.volume = MusicaSlider.value;
    }

    public void Distruggi(){
        Destroy(this);
    }
}