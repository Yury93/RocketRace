using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.IO;
using System;
using UnityEditor.ShortcutManagement;
[ExecuteInEditMode]
public class Screenshooter : MonoBehaviour
{

    [Header("Choose build type(ios,pc,android)")]
    [SerializeField] GameViewSizeGroupType buildType;
    [Header("That aspects must SET in the gameWindow")]
    [SerializeField] List<string> screenSizes = new List<string>() { "2436x1125", "2732x2048", "1920x1080" };
    [SerializeField] KeyCode screenBtn = KeyCode.P;
    [Header("Start in (PlayMode) better")]
    static int i;


    void Update()
    {
        if (Input.GetKeyDown(screenBtn))
        {
            Make();
        }
    }
    void Make()
    {
        pathCheck();
        Debug.Log("path " + System.IO.Directory.GetCurrentDirectory());
        StartCoroutine(cor());
    }
    void pathCheck()
    {

        if (!Directory.Exists(Directory.GetCurrentDirectory() + "/Screens"))
        {
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Screens");
        }

    }
    IEnumerator cor()
    {
        foreach (var item in screenSizes)
        {
            GameViewUtils.TrySetSize(item, buildType);
            yield return null;
            ScreenCapture.CaptureScreenshot("Screens/Shot #" + i + " " + +Screen.width + "x" + Screen.height + ".png");
            yield return null;

        }
        i++;
    }
    public static class GameViewUtils
    {

        static object s_GameViewSizes_instance;

        static Type s_GameViewType;
        static MethodInfo s_GameView_SizeSelectionCallback;

        static Type s_GameViewSizesType;
        static MethodInfo s_GameViewSizes_GetGroup;

        static Type s_GameViewSizeSingleType;

        static GameViewUtils()
        {
            s_GameViewType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.GameView");
            s_GameView_SizeSelectionCallback = s_GameViewType.GetMethod("SizeSelectionCallback", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            s_GameViewSizesType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.GameViewSizes");
            s_GameViewSizeSingleType = typeof(ScriptableSingleton<>).MakeGenericType(s_GameViewSizesType);
            s_GameViewSizes_GetGroup = s_GameViewSizesType.GetMethod("GetGroup");

            var instanceProp = s_GameViewSizeSingleType.GetProperty("instance");
            s_GameViewSizes_instance = instanceProp.GetValue(null, null);
        }

        /// <summary>
        /// Try to find and set game view size to specified query.
        /// Size must be already exists in game view setting.
        /// </summary>
        /// <param name="sizeText">Query string such as 1280x720 or 16:9</param>
        public static bool TrySetSize(string sizeText, GameViewSizeGroupType g)
        {
            int foundIndex = FindSize(g, sizeText);
            if (foundIndex < 0)
            {
                Debug.LogError($"Size {sizeText} was not found in game view settings");
                return false;
            }

            SetSizeIndex(foundIndex);
            return true;
        }

        /// <summary>
        /// Set current gameview size to target resolution index.
        /// Index must be known beforehand.
        /// </summary>
        public static void SetSizeIndex(int index)
        {
            EditorWindow currentWindow = EditorWindow.focusedWindow;
            SceneView lastSceneView = SceneView.lastActiveSceneView;

            EditorWindow gv = EditorWindow.GetWindow(s_GameViewType);
            s_GameView_SizeSelectionCallback.Invoke(gv, new object[] { index, null });
            if (lastSceneView != null)
                lastSceneView.Focus();

            if (currentWindow != null)
                currentWindow.Focus();
        }

        /// <summary>
        /// Finding text could be fixed resoluation as WxH "1280x720"
        /// or ratio like W:H "16:9"
        /// </summary>
        public static int FindSize(GameViewSizeGroupType sizeGroupType, string text)
        {
            var group = GetGroup(sizeGroupType); // class GameViewSizeGroup
            var getDisplayTexts = group.GetType().GetMethod("GetDisplayTexts");
            var displayTexts = getDisplayTexts.Invoke(group, null) as string[];
            for (int i = 0; i < displayTexts.Length; i++)
            {
                string display = displayTexts[i];

                bool found = display.Contains(text);
                bool screenPortrait = (Screen.width > Screen.height) ? false : true;

                if (screenPortrait && display.Contains("Landscape")) found = false;
                if (!screenPortrait && display.Contains("Portrait")) found = false;
                if (found)
                    return i;
            }
            return -1;
        }

        static object GetGroup(GameViewSizeGroupType type)
        {
            return s_GameViewSizes_GetGroup.Invoke(s_GameViewSizes_instance, new object[] { (int)type });
        }
    }
}
