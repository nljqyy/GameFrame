﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class UIManager
{
    private Transform normalUI;
    private Transform hideUI;
    private Transform tiptopUI;
    private static UIManager instance;
    public static UIManager Instance
    {
        get { return instance; }
    }
    private UIManager()
    {
        GameObject canves = GameObject.Find("UICanvas");
        if (canves)
        {
            //GameObject.DontDestroyOnLoad(canves);
            normalUI = canves.transform.Find("uiRoot/normalUI");
            hideUI = canves.transform.Find("uiRoot/hideUI");
            tiptopUI = canves.transform.Find("uiRoot/tiptopUI");
        }
    }
    static UIManager()
    {
        instance = new UIManager();
    }
    private Dictionary<string, UIDataBase> dicDlg = new Dictionary<string, UIDataBase>();

    private UIDataBase GetDigLog(string dlgName)
    {
        if (string.IsNullOrEmpty(dlgName))
            return null;
        UIDataBase dlg = null;
        GameObject uiRoot = null;
        bool isHas= dicDlg.TryGetValue(dlgName, out dlg);
        if (isHas)
        {
            uiRoot = dlg.gameObject;
        }
        else
        {
           dlg= RegisterDlgScripte(dlgName, out uiRoot);
        }
        SetUIRootParent(uiRoot,dlg.ShowPos);
        return dlg;
    }
    private void SetUIRootParent(GameObject uiRoot,UIShowPos type)
    {
        Transform Parent = null;
        if (type == UIShowPos.Normal)
            Parent = normalUI;
        else if (type == UIShowPos.TipTop)
            Parent = tiptopUI;
        else
            Parent = hideUI;
        uiRoot.transform.SetParent( Parent);
        uiRoot.transform.localPosition = Vector3.zero;
        uiRoot.transform.localScale = Vector3.one;
        uiRoot.transform.localRotation = Quaternion.identity;
    }

    private void SaveUIRoot(string dlgName,UIDataBase dlg)
    {
        if (dlg)
            dicDlg.Add(dlgName, dlg);
        else
            GameObject.Destroy(dlg.gameObject);
    }
    //需要手动注册脚本
    private UIDataBase RegisterDlgScripte(string dlgName,out GameObject uiRoot)
    {
        UIDataBase dlg = null;
        uiRoot = null;
        if (!string.IsNullOrEmpty(dlgName))
        {
            uiRoot = SetRootPro(dlgName);
            switch (dlgName)
            {
                case "":break;
            }
            SaveUIRoot(dlgName,dlg);
        }
        return dlg;
    }


    private GameObject SetRootPro(string dlgName)
    {
        GameObject uiRoot = new GameObject(dlgName);
        uiRoot.SetActive(true);
        uiRoot.layer = LayerMask.NameToLayer("UI");
        return uiRoot;
    }
    public void ShowUI(string dlgName,bool isShow,object data=null, Action<GameObject> act=null)
    {
        UIDataBase dlg;
        dlg= GetDigLog(dlgName);
        if (dlg)
        {
            if (isShow)
            {
                dlg.OnOpen();
                dlg.OnShow(data);
            }
            else
            {
                if (dlg.hidePage == HidePage.Hide)
                {
                    dlg.OnHide();
                    SetUIRootParent(dlg.gameObject, UIShowPos.Hide);
                }
                else
                {
                    GameObject.Destroy(dlg.gameObject);
                    dicDlg.Remove(dlgName);
                    return;
                }
            }
            dlg.gameObject.SetActive(isShow);
            if (act != null)
                act(dlg.gameObject);
        }
    }

    public void Clear()
    {
        foreach (var item in dicDlg)
        {
            if (item.Value != null)
                GameObject.Destroy(item.Value.gameObject);
        }
        dicDlg.Clear();
    }

}
