using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraIsometrica : MonoBehaviour
{
    [Header("Alvo (opcional)")]
    public Transform alvo;

    [Header("Zoom")]
    public float zoomInicial = 60f;
    public float zoomMinimo = 15f;
    public float zoomMaximo = 200f;

    [Header("Movimento")]
    public float velocidadePan = 40f;
    public float limiteMapa = 2000f;

    [Header("Rotacao")]
    public KeyCode teclaGirarEsquerda = KeyCode.Q;
    public KeyCode teclaGirarDireita = KeyCode.E;
    public float anguloIsometrico = 35.264f;

    private Camera cam;
    private float tamanhoAtual;
    private float giroAtual;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        cam.orthographic = true;
        tamanhoAtual = zoomInicial;
        giroAtual = 45f;
        Aplicar();
    }

    private void Update()
    {
        if (Input.GetKeyDown(teclaGirarEsquerda)) giroAtual -= 90f;
        if (Input.GetKeyDown(teclaGirarDireita)) giroAtual += 90f;

        float roda = Input.mouseScrollDelta.y;
        if (roda != 0f)
            tamanhoAtual = Mathf.Clamp(tamanhoAtual - roda * tamanhoAtual * 0.1f, zoomMinimo, zoomMaximo);

        Quaternion giro = Quaternion.Euler(0f, giroAtual, 0f);
        Vector3 frente = giro * Vector3.forward;
        Vector3 lateral = giro * Vector3.right;
        float velocidade = velocidadePan * (tamanhoAtual / zoomInicial) * Time.deltaTime;
        Vector3 deslocamento = (frente * Input.GetAxisRaw("Vertical") + lateral * Input.GetAxisRaw("Horizontal")) * velocidade;

        if (alvo != null)
        {
            Vector3 posicao = alvo.position + deslocamento;
            posicao.x = Mathf.Clamp(posicao.x, -limiteMapa, limiteMapa);
            posicao.z = Mathf.Clamp(posicao.z, -limiteMapa, limiteMapa);
            alvo.position = posicao;
        }

        Aplicar();
    }

    private void Aplicar()
    {
        cam.orthographicSize = tamanhoAtual;
        Vector3 centro = alvo != null ? alvo.position : Vector3.zero;
        Quaternion rotacao = Quaternion.Euler(anguloIsometrico, giroAtual, 0f);
        transform.position = centro - rotacao * Vector3.forward * 300f;
        transform.rotation = rotacao;
    }
}
