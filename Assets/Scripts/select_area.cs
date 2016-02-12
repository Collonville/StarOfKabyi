﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class select_area : MonoBehaviour
{
    /// <summary>
    /// 選択できる範囲のためのスクリプト。
    /// 範囲に入ったオブジェクトをリストに保存して、リストをUpdate中で回して距離を確認する。
    /// この範囲から出ていったオブジェクトはリストから削除する。
    /// 範囲の中にオブジェクトがあるとき、Enterキーを押すと、プレイヤーから最も近いコライダーとrigitbodyが付いたオブジェクトにエフェクトがでる。
    /// エフェクトが出ているとき、範囲内に別のオブジェクトがあった場合、そのオブジェクトに近づくとエフェクトがそのオブジェクトに切り替わる。（選択対象が変わる）
    /// 範囲外に出ると、選択は解除される。選択が解除されると、再びEnterを押すまでオブジェクトは選択されなくなる。
    /// </summary>
    public GameObject perticle;
    GameObject nowPerticle;
    GameObject nowSelected;
    List<GameObject> intoObjectList = new List<GameObject>();
    GameObject nearistObject;
    GameObject decisionObject;
    void Start()
    {
        nearistObject = null;
        decisionObject = null;
        nowSelected = null;
        nowPerticle = null;
    }
    void Update()
    {
        float nearistDist = -1;
        var myPosition = transform.position;
        var isEnter = Input.GetKey(KeyCode.Return);
        foreach (GameObject obj in intoObjectList)
        {
            if (nearistDist == -1)
            {
                nearistDist = Vector3.Distance(myPosition, obj.transform.position);
                nearistObject = obj;
                if (decisionObject != null)
                {
                    decideObject(true);
                }
            }
            if (nearistDist > Vector3.Distance(myPosition, obj.transform.position))
            {
                nearistDist = Vector3.Distance(myPosition, obj.transform.position);
                nearistObject = obj;
                if (decisionObject != null)
                {
                    decideObject(true);
                }
            }
        }
        if (isEnter == true)
        {
            decideObject(true);
        }
        perticleManager();
        Debug.Log(decisionObject);
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("vehicle"))
        {
            intoObjectList.Add(collision.gameObject);
        }

    }

    void OnTriggerExit(Collider collision)
    {
        intoObjectList.Remove(collision.gameObject);
        if (collision.gameObject == nearistObject)
        {
            nearistObject = null;
            decideObject(false);
        }
    }
    void decideObject(bool isEnter)
    {
        if (isEnter)
        {
            if (nearistObject != null)
            {
                decisionObject = nearistObject;
            }
            else
            {
                decisionObject = null;
            }
        }
        else
        {
            decisionObject = null;
        }
    }
    void perticleManager()
    {
        Vector3 offset = new Vector3(0, 3, 0);
        if (decisionObject != null)
        {
            if (nowPerticle == null)
            {
                nowPerticle = (GameObject)Instantiate(perticle, decisionObject.transform.position + offset, Quaternion.Euler(270, 0, 0));
                nowPerticle.transform.parent = decisionObject.transform;
            }
            if (nowSelected == null)
            {
                nowSelected = decisionObject;
            }
            if (nowSelected != decisionObject)
            {
                Destroy(nowPerticle);
                nowPerticle = (GameObject)Instantiate(perticle, decisionObject.transform.position + offset, Quaternion.Euler(270, 0, 0));
                nowPerticle.transform.parent = decisionObject.transform;
            }
            nowSelected = decisionObject;
        }
        else
        {
            if (nowPerticle != null)
            {
                Destroy(nowPerticle);
                nowPerticle = null;
            }
            nowSelected = null;
        }
    }
}