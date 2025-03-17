using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Keybindings : MonoBehaviour
{
    public GameObject ListaComandi;
    public GameObject KeyList;
    Dictionary<string, Text> ButtonToLabel;
    string KeyToRebind;
    void Start()
    {
        string[] NomeBottoni = GestioneComandi.instance.GetButtonNames();
        ButtonToLabel = new Dictionary<string, Text>();
        for (int i = 0; i < NomeBottoni.Length; i++)
        {
            string ButtonName;
            ButtonName = NomeBottoni[i];
            GameObject go = (GameObject)Instantiate(ListaComandi);
            go.transform.SetParent(KeyList.transform);
            Text ButtonNameText = go.transform.Find("T").GetComponent<Text>();
            ButtonNameText.text = ButtonName;
            Text KeyNameText = go.transform.Find("B/Text").GetComponent<Text>();
            ButtonToLabel[ButtonName] = KeyNameText;
            KeyNameText.text = GestioneComandi.instance.GetKeyName(ButtonName);
            Button Bottone = go.transform.Find("B").GetComponent<Button>();
            Bottone.onClick.AddListener(() => { StartRebind(ButtonName); });
        }
    }
    private void Update()
    {
        if (KeyToRebind != null)
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode kc in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kc))
                    {
                        GestioneComandi.instance.SetButton(KeyToRebind, kc);
                        ButtonToLabel[KeyToRebind].text = kc.ToString();
                        KeyToRebind = null;
                        break;
                    }
                }
            }
        }
    }
    void StartRebind(string comando)
    {
        KeyToRebind = comando;
    }
}