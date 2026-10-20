using System.IO;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class GitBranchWindow : EditorWindow
{
    static string branch;
    static double nextCheck;

    /// <summary>
    /// Constructor estático. Gracias a <c>[InitializeOnLoad]</c> se ejecuta
    /// al abrir Unity y después de cada recompilación de scripts.
    /// Aquí se engancha la comprobación periódica al bucle del editor.
    /// </summary>
    static GitBranchWindow()
    {
        //EditorApplication.update += Poll; //Comentar porque no se usa ni en main ni dev
    }

    /// <summary>
    /// Abre la ventana (o la trae al frente si ya existe) desde el menú
    /// <c>Tools > Git > Rama actual</c>. Una vez abierta se puede acoplar
    /// arrastrando su pestaña.
    /// </summary>
    [MenuItem("Tools/Git/Rama actual")]
    static void ShowWindow()
    {
        var w = GetWindow<GitBranchWindow>("Git");
        w.minSize = new Vector2(100, 30);
    }

    /// <summary>
    /// Se llama en cada tick del editor. Limita la comprobación a una vez
    /// cada 2 segundos, y si la rama ha cambiado escribe en consola
    /// y redibuja las ventanas abiertas.
    /// </summary>
    static void Poll()
    {
        // Intervalo mínimo entre comprobaciones. Cambiar el "2" para ajustarlo.
        if (EditorApplication.timeSinceStartup < nextCheck) return;
        nextCheck = EditorApplication.timeSinceStartup + 2;

        string current = ReadBranch();
        if (current == branch) return; // Sin cambios: no hacer nada.

        branch = current;
        if (IsProtected(branch))
            Debug.LogWarning($"[Git] Rama actual: {branch} (¡cuidado, rama principal!)");
        else
            Debug.Log($"[Git] Rama actual: {branch}");

        // Redibuja las ventanas abiertas para mostrar la nueva rama.
        foreach (var w in Resources.FindObjectsOfTypeAll<GitBranchWindow>())
            w.Repaint();
    }

    static bool IsProtected(string b) => b == "main" || b == "master";

    /// <summary>
    /// Dibuja la ventana: fondo verde con el nombre de la rama,
    /// o rojo si es una rama principal.
    /// </summary>
    /// <remarks>
    /// Si la comprobación automática está desactivada, <c>branch</c> sigue
    /// siendo <c>null</c> y se lee la rama en cada repintado de la ventana.
    /// </remarks>
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

    /// <summary>
    /// Lee el nombre de la rama actual leyendo <c>.git/HEAD</c>.
    /// Busca la carpeta <c>.git</c> subiendo desde la carpeta del proyecto,
    /// y soporta repositorios donde <c>.git</c> es un archivo
    /// (worktrees y submódulos, que contienen <c>gitdir: ruta</c>).
    /// </summary>
    /// <returns>
    /// El nombre de la rama; <c>"detached abc1234"</c> si HEAD apunta a un commit;
    /// <c>"sin repositorio"</c> si no se encuentra <c>.git</c>;
    /// o <c>"error"</c> si falla la lectura (por ejemplo, si Git está escribiendo HEAD en ese instante).
    /// </returns>
    static string ReadBranch()
    {
        try
        {
            // Application.dataPath apunta a /Assets; el proyecto está un nivel por encima.
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
                dir = dir.Parent; // Seguir subiendo hasta encontrar .git.
            }
            return "sin repositorio";
        }
        catch { return "error"; }
    }
}