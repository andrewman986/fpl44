﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneData : MonoBehaviour {
    public static string framing;
	public static List<string> damageEquipment;
	public static int damageLevel  = -1;
    GameObject[] poles;
    public string[] testingData;

    //get functions
    public string getFraming(){return framing;}
	public string[] getDamageEquipmentArray(){
        if(damageEquipment == null)
        {
            //this only for development 
            damageEquipment = new List<string>();
            foreach(string t in testingData)
            {
                damageEquipment.Add(t);
            }


        }

        return damageEquipment.ToArray();
    }
	public int getDamageLevel(){ return damageLevel;}
    public GameObject[] getPoles() { return poles; }
    public Transform[] getPolesTransform()
    {
        Transform[] ret = new Transform[poles.Length];
        for(int i = 0; i < poles.Length; i++)
        {
            ret[i] = poles[i].transform;
        }
        return ret;
    }
    //setfunctions
    public void setFraming(string f) {
        if (f == "any")
        {
            framing = null;
        }
        else
        {
            print("set framing" + f);
            framing = f;
        }
    }

    public void setPoles(GameObject[] p) {
        poles = p;
    }

	public void addDamageEquipment(string t){
        if(damageEquipment == null)
        {
            damageEquipment = new List<string>();
        }

        damageEquipment.Add(t);

        //printDamageEquip();
	}

    public void removeDamageEquipment(string t)
    {
        damageEquipment.Remove(t);
        //printDamageEquip();
    }

    public void clearEquip()
    {
        if(damageEquipment != null)
            damageEquipment.Clear();
    }

	public void setDamageLevel(int i){
        damageLevel = i;
	}

    public void loadScene(string sceneName)
    {
        print("button click and  load scene " + sceneName);
        SceneManager.LoadScene(sceneName);
        //SteamVR_LoadLevel.Begin(sceneName);
        //testing
        print("load scene");
        print("framming = "+getFraming() + "\t\t level = "+getDamageLevel());
        string ret = "";
        foreach(string t in getDamageEquipmentArray())
        {
            ret += t + "--";
        }
        print(ret);
    }

    //platform specific compilation: code will run differently depending on if it's being run on Unity or not
    public void quit()
    {
        //if we are running on the editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        //if we are not running in the editor (like the build)
        #else
        Application.Quit();
        
        #endif
    }

    public void printDamageEquip()
    {
        string t = "";
        foreach(string equip in damageEquipment)
        {
            t += equip + "|";
        }
        print(t);
    }

    public void clearData()
    {
        framing = null;
        damageEquipment = null;
        damageLevel = -1;
    }

    public void addDamageEquipment(string[] list)
    {
        foreach(string t in list)
        {
            addDamageEquipment(t);
        }
    }
    public void removeDamageEquipment(string[] list)
    {
        foreach (string t in list)
        {
            removeDamageEquipment(t);
        }
    }
}
