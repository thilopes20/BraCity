using UnityEngine;

public class ColocadorDePredios : MonoBehaviour
{
    [Header("Referencias")]
    public Camera cameraPrincipal;
    public LayerMask camadaTerreno = ~0;

    [Header("Predios (prefabs opcionais; vazio = cubo provisorio)")]
    public GameObject[] predios;

    [Header("Controles")]
    public KeyCode teclaGirar = KeyCode.R;

    private int indice;
    private float giro;

    private void Awake()
    {
        if (cameraPrincipal == null) cameraPrincipal = Camera.main;
    }

    private void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) && predios != null && i < predios.Length)
            {
                indice = i;
                giro = 0f;
            }
        }
        if (Input.GetKeyDown(teclaGirar)) giro += 90f;
        if (Input.GetMouseButtonDown(1) && ApontarTerreno(out Vector3 ponto)) Colocar(ponto);
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

    private void Colocar(Vector3 ponto)
    {
        if (predios == null || predios.Length == 0)
        {
            GameObject cubo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            float altura = Random.Range(6f, 20f);
            cubo.transform.localScale = new Vector3(10f, altura, 10f);
            cubo.transform.position = ponto + Vector3.up * (altura * 0.5f);
            cubo.transform.rotation = Quaternion.Euler(0f, giro, 0f);
            cubo.name = "Predio";
            return;
        }
        Instantiate(predios[Mathf.Min(indice, predios.Length - 1)], ponto, Quaternion.Euler(0f, giro, 0f));
    }
}
