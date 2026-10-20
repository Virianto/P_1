using System.IO;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class GitBranchWindow : EditorWindow
{
    static string branch;
    static double nextCheck;

    static GitBranchWindow()
    {
        EditorApplication.update += Poll;
    }

    [MenuItem("Tools/Git/Rama actual")]
    static void ShowWindow()
    {
        var w = GetWindow<GitBranchWindow>("Git");
        w.minSize = new Vector2(100, 30);
    }

    static void Poll()
    {
        if (EditorApplication.timeSinceStartup < nextCheck) return;
        nextCheck = EditorApplication.timeSinceStartup + 2;

        string current = ReadBranch();
        if (current == branch) return;

        branch = current;
        if (IsProtected(branch))
            Debug.LogWarning($"[Git] Rama actual: {branch} (¡cuidado, rama principal!)");
        else
            Debug.Log($"[Git] Rama actual: {branch}");

        foreach (var w in Resources.FindObjectsOfTypeAll<GitBranchWindow>())
            w.Repaint();
    }

    static bool IsProtected(string b) => b == "main" || b == "master";

    void OnGUI()
    {
        string b = branch ?? ReadBranch();
        var color = IsProtected(b) ? new Color(0.75f, 0.2f, 0.2f) : new Color(0.15f, 0.5f, 0.3f);
        EditorGUI.DrawRect(new Rect(0, 0, position.width, position.height), color);

        var style = new GUIStyle(EditorStyles.boldLabel)
        {
            alignment = TextAnchor.MiddleCenter,
            fontSize = 16,
            wordWrap = true
        };
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(0, 0, position.width, position.height), b, style);
    }

    static string ReadBranch()
    {
        try
        {
            var dir = new DirectoryInfo(Application.dataPath).Parent;
            while (dir != null)
            {
                string git = Path.Combine(dir.FullName, ".git");
                string gitDir = null;

                if (Directory.Exists(git)) gitDir = git;
                else if (File.Exists(git))
                {
                    string line = File.ReadAllText(git).Trim();
                    if (line.StartsWith("gitdir:")) gitDir = line.Substring(7).Trim();
                }

                if (gitDir != null)
                {
                    string head = File.ReadAllText(Path.Combine(gitDir, "HEAD")).Trim();
                    const string prefix = "ref: refs/heads/";
                    return head.StartsWith(prefix)
                        ? head.Substring(prefix.Length)
                        : "detached " + head.Substring(0, 7);
                }
                dir = dir.Parent;
            }
            return "sin repositorio";
        }
        catch { return "error"; }
    }
}