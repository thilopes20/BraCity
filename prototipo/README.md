# Protótipo da fase 1 — Unity

Scripts da fase 1 do GDD: câmera isométrica, terreno, desenhar rua curva com o mouse e colocar prédio. Não precisa de pacote externo nesta fase — tudo funciona com o Unity puro.

## Instalação (uma vez)

1. Baixe e instale o **Unity Hub**: https://unity.com/pt-br/download
2. No Hub: **Installs → Install Editor → Unity 6 LTS**. Na tela de módulos, marque **Android Build Support** (com OpenJDK e Android SDK & NDK Tools) para testar no celular depois. Pode desmarcar o resto.
3. Na primeira abertura, escolha a licença **Personal** (gratuita).
4. Hub → **New Project** → template **3D (URP)** → nome `BraCity` → Create.

## Colocar os scripts no projeto

1. Copie os três arquivos da pasta `Scripts/` para dentro de `Assets/Scripts/` do projeto (pode arrastar pela janela Project do Unity).
2. Aguarde o Unity compilar (ícone girando no canto inferior direito).

## Montar a cena (5 minutos)

1. **Chão:** Hierarchy → botão direito → 3D Object → **Plane**. No Inspector, mude o Scale para (20, 1, 20) → chão de 200 x 200 m.
2. **Câmera:** selecione a **Main Camera** → Add Component → `CameraIsometrica` (ela já configura a projeção ortográfica sozinha).
3. **Construtor:** Hierarchy → Create Empty → nomeie `Construtor` → Add Component → `DesenhadorDeRuas` e, no mesmo objeto, `ColocadorDePredios`.
4. Pronto — ambos os componentes já acham o chão sozinhos pelo raycast (LayerMask padrão = Everything).
5. (Opcional) Importe o **Kenney City Kit** (gratuito, https://kenney.nl/assets/city-kit) e arraste os modelos que quiser para o array **Prédios** do `ColocadorDePredios`. Sem nada atribuído, o jogo cria cubos de alturas variadas no lugar.

Salve a cena (Ctrl+S) e aperte **Play**.

## Controles

| Tecla / ação | O que faz |
|---|---|
| W A S D / setas | Mover a câmera |
| Q / E | Girar o mapa em 90° |
| Roda do mouse | Zoom |
| Clique esquerdo | Marcar ponto da rua — a curva passa pelos pontos |
| Backspace | Apagar o último ponto marcado |
| Enter | Concluir a rua e gerar o asfalto |
| Esc | Limpar os pontos marcados |
| Clique direito | Colocar prédio (cubo provisório ou prefab do array Prédios) |
| R | Girar o prédio em 90° |

## O que vem depois (fase 2)

Importar um bairro real do OpenStreetMap — ruas, rio, mata e relevo. O importador de OSM é a próxima peça de código.
