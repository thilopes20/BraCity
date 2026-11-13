using System.Collections.Generic;
using UnityEngine;

public class DesenhadorDeRuas : MonoBehaviour
{
    [Header("Referencias")]
    public Camera cameraPrincipal;
    public LayerMask camadaTerreno = ~0;

    [Header("Rua")]
    public float largura = 8f;
    public float altura = 0.05f;
    public Color corAsfalto = new Color(0.22f, 0.22f, 0.24f);
    public int subdivisoesPorTrecho = 8;

    [Header("Controles")]
    public KeyCode teclaConcluir = KeyCode.Return;
    public KeyCode teclaCancelar = KeyCode.Escape;

    private readonly List<Vector3> pontos = new List<Vector3>();
    private Material materialAsfalto;
    private LineRenderer preVisualizacao;

    private void Awake()
    {
        if (cameraPrincipal == null) cameraPrincipal = Camera.main;
        materialAsfalto = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        materialAsfalto.color = corAsfalto;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && ApontarTerreno(out Vector3 ponto))
        {
            pontos.Add(ponto);
            AtualizarPrevia();
        }
        if (Input.GetKeyDown(KeyCode.Backspace) && pontos.Count > 0)
        {
            pontos.RemoveAt(pontos.Count - 1);
            AtualizarPrevia();
        }
        if (Input.GetKeyDown(teclaConcluir)) Concluir();
        if (Input.GetKeyDown(teclaCancelar))
        {
            pontos.Clear();
            AtualizarPrevia();
        }
    }

    private bool ApontarTerreno(out Vector3 ponto)
    {
        Ray raio = cameraPrincipal.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(raio, out RaycastHit hit, 5000f, camadaTerreno))
        {
            ponto = hit.point;
            return true;
        }
        ponto = default;
        return false;
    }

    private void AtualizarPrevia()
    {
        if (preVisualizacao == null)
        {
            preVisualizacao = new GameObject("PreviaDaRua").AddComponent<LineRenderer>();
            preVisualizacao.material = new Material(Shader.Find("Sprites/Default"));
            preVisualizacao.startColor = Color.cyan;
            preVisualizacao.endColor = Color.cyan;
            preVisualizacao.startWidth = 0.4f;
            preVisualizacao.endWidth = 0.4f;
        }
        preVisualizacao.positionCount = pontos.Count;
        for (int i = 0; i < pontos.Count; i++)
            preVisualizacao.SetPosition(i, pontos[i] + Vector3.up * 0.3f);
    }

    private void Concluir()
    {
        if (pontos.Count < 2) return;
        List<Vector3> amostras = AmostrarCatmullRom(pontos, subdivisoesPorTrecho);
        GameObject rua = new GameObject("Rua");
        rua.AddComponent<MeshFilter>().sharedMesh = CriarFita(amostras);
        rua.AddComponent<MeshRenderer>().sharedMaterial = materialAsfalto;
        pontos.Clear();
        AtualizarPrevia();
    }

    private static List<Vector3> AmostrarCatmullRom(List<Vector3> pontos, int subdivisoes)
    {
        List<Vector3> amostras = new List<Vector3>();
        int n = pontos.Count;
        for (int i = 0; i < n - 1; i++)
        {
            Vector3 p0 = pontos[Mathf.Max(i - 1, 0)];
            Vector3 p1 = pontos[i];
            Vector3 p2 = pontos[i + 1];
            Vector3 p3 = pontos[Mathf.Min(i + 2, n - 1)];
            for (int s = 0; s < subdivisoes; s++)
            {
                float t = s / (float)subdivisoes;
                float t2 = t * t;
                float t3 = t2 * t;
                amostras.Add(0.5f * (2f * p1 + (-p0 + p2) * t + (2f * p0 - 5f * p1 + 4f * p2 - p3) * t2 + (-p0 + 3f * p1 - 3f * p2 + p3) * t3));
            }
        }
        amostras.Add(pontos[n - 1]);
        return amostras;
    }

    private Mesh CriarFita(List<Vector3> amostras)
    {
        int n = amostras.Count;
        Vector3[] vertices = new Vector3[n * 2];
        Vector2[] uv = new Vector2[n * 2];
        int[] triangulos = new int[(n - 1) * 6];

        for (int i = 0; i < n; i++)
        {
            Vector3 direcao = i < n - 1 ? amostras[i + 1] - amostras[i] : amostras[i] - amostras[i - 1];
            direcao.y = 0f;
            Vector3 lado = Vector3.Cross(Vector3.up, direcao.normalized) * (largura * 0.5f);
            vertices[i * 2] = amostras[i] - lado + Vector3.up * altura;
            vertices[i * 2 + 1] = amostras[i] + lado + Vector3.up * altura;
            uv[i * 2] = new Vector2(0f, i);
            uv[i * 2 + 1] = new Vector2(1f, i);
        }
        for (int i = 0; i < n - 1; i++)
        {
            int a = i * 2;
            triangulos[i * 6] = a;
            triangulos[i * 6 + 1] = a + 2;
            triangulos[i * 6 + 2] = a + 1;
            triangulos[i * 6 + 3] = a + 1;
            triangulos[i * 6 + 4] = a + 2;
            triangulos[i * 6 + 5] = a + 3;
        }

        Mesh malha = new Mesh { name = "Rua" };
        malha.vertices = vertices;
        malha.uv = uv;
        malha.triangles = triangulos;
        malha.RecalculateNormals();
        return malha;
    }
}
