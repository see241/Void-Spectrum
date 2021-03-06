﻿using System.Collections;
using UnityEngine;

public class PanelSort : MonoBehaviour
{
    public int index;
    public RectTransform rt;

    // Use this for initialization
    private void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        StartCoroutine(SortPos());
    }

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (index == 0)
        {
            Selector.instance.key.button = transform.GetChild(1).GetComponent<UnityEngine.UI.Button>();
        }
    }

    private IEnumerator SortPos()
    {
        Vector2 sortingPos = new Vector2(index * 768, 0);
        for (int i = 0; i < 15; i++)
        {
            rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, sortingPos, 0.5f);
            yield return new WaitForSeconds(0.02f);
        }
    }
}