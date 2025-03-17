using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GestioneComandi : MonoBehaviour
{
    public Dictionary<string, KeyCode> comandi;
    public static GestioneComandi instance;
    [SerializeField] GameObject Salvataggio;

    private void Awake(){
        instance = this;
    }

    private void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
        comandi = new Dictionary<string, KeyCode>();
        comandi["Avanti"] = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Avanti", "W"));
        comandi["Indietro"] = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Indietro", "S"));
        comandi["Destra"] = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Destra", "D"));
        comandi["Sinistra"] = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Sinistra", "A"));
        comandi["Attacco"] = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Attacco", "Space"));
    }

    public bool GetButtonDown(string comando)
    {
        if (!comandi.ContainsKey(comando))
        {
            return false;
        }
        return Input.GetKeyDown(comandi[comando]);
    }

    public string[] GetButtonNames()
    {
        return comandi.Keys.ToArray();
    }

    public string GetKeyName(string comando)
    {
        if (!comandi.ContainsKey(comando))
        {
            return "N/A";
        }
        return comandi[comando].ToString();
    }

    public void SetButton(string comando, KeyCode kc)
    {
        comandi[comando] = kc;
    }

    public void SetOff()
    {
        Salvataggio.SetActive(false);
    }

    public void SaveKeys()
    {
        foreach (var keys in comandi)
        {
            PlayerPrefs.SetString(keys.Key, keys.Value.ToString());
        }
        Salvataggio.SetActive(true);
        PlayerPrefs.Save();
    }
}