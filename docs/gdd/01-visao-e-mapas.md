# GDD — 1. Visão geral e mapas

## Visão geral

Um construtor de cidade em que o jogador reconstrói bairros reais do Brasil, partindo do traçado verdadeiro das ruas, dos rios e das matas. A cidade cresce do jeito brasileiro: lotes à venda, famílias que chegam aos poucos e levantam a própria casa, e uma população que cobra escola, posto de saúde, mercado, ônibus e segurança.

O gancho é pessoal. O jogador procura a própria rua no mapa e decide como o bairro dele poderia ser. Por cima disso corre uma carreira: começa no bairro, como vereador ou cidadão comum, e sobe até prefeito, governador e presidente, conforme o mapa se amplia.

## Ficha de decisões

| Item | Decisão |
|---|---|
| Gênero | Construtor de cidade com simulação de vida e carreira política |
| Plataforma | PC e celular, no mesmo projeto e com o mesmo save na nuvem |
| Motor | Unity |
| Visual | 3D low-poly com câmera isométrica fixa (substituiu o 2D isométrico por causa das ruas curvas) |
| Mapas | Bairros reais com formato real, escala de 1 unidade = 1 metro |
| Sistemas | Produção e comércio, necessidades da população, segurança e desastres, relações entre bairros e cidades; todos entram, em fases |
| Online | Cooperativo e assíncrono, só depois que o jogo solo estiver divertido |

## Mapas reais

Cada mapa nasce com o contorno real do bairro, as ruas que já existem, os rios, as matas e o relevo. O restante do terreno vem como área verde livre, e é ali que o jogador constrói. Ele pode manter o traçado como está, melhorar ou reconstruir.

### Fontes de dados (gratuitas)

- **OpenStreetMap**: ruas, rios, lagoas, parques, matas e contorno de bairros em boa parte das cidades. A licença exige crédito no jogo.
- **IBGE**: limites oficiais de bairros e distritos, e o levantamento de Favelas e Comunidades Urbanas do Censo 2022.
- **SRTM**: relevo do mundo inteiro, essencial para cidades de morro como Rio, Salvador e Belo Horizonte.

### Limites e escala

- A área fora do limite aparece como cenário de fundo, mostrando os bairros vizinhos, sem permitir construção.
- Todos os mapas usam a mesma escala, 1 unidade do Unity = 1 metro, para que encaixem lado a lado na visão da cidade.

### Regra de divisão

Em vez de um bairro por mapa, existe um tamanho máximo de mapa, ponto de partida entre 2 e 4 km², ajustado nos testes de desempenho. O jogo decide a divisão:

| Situação | O que acontece |
|---|---|
| Bairro cabe no limite | Vira um mapa |
| Bairros pequenos vizinhos | Agrupados num mapa, cada um com nome e limite próprios |
| Bairro grande demais | Dividido em partes por divisas naturais: rio, avenida grande, linha de trem |
| Cidade pequena inteira | Cabe num mapa só, e o jogador começa com a cidade toda |

### Natureza com peso no jogo

- Ocupar a margem do rio aumenta o risco de enchente.
- Ponte custa caro e demora.
- Desmatar área de preservação gera multa e queda de aprovação.
- Morro encarece a obra e restringe o tipo de construção, com risco de deslizamento.

Mais para frente pode entrar um modo "bairro como é hoje", que carrega também o contorno dos prédios existentes.

### Mapas de teste definidos

| Ordem | Mapa | Por quê | Fase |
|---|---|---|---|
| 1 | Maré Mansa + Parque Imperial (Presidente Prudente, SP) | Bairro do próprio time de desenvolvimento — o gancho pessoal do jogo desde o primeiro dia. Terreno plano, que valida o importador OSM sem a variável do relevo. Cercado de pasto, que entra como área verde livre para construir. Um pequeno riacho corta por fora dos dois bairros e já testa água e ponte em escala mínima | 1–2 |
| 2 | Freguesia do Ó (São Paulo, SP) | Rio Tietê na borda (várzea e enchente), relevo moderado, comunidades mapeadas pelo IBGE e traçado antigo orgânico — exerce ruas curvas, enchente, morro e comunidades num território pequeno | 2–3 |
| 3 | Jardim Ângela (São Paulo, SP) | Morros fortes e comunidades grandes; testa o sistema de comunidades e desastres de verdade — e, pelo tamanho, exercita a divisão de mapa por divisa natural | 6 |

## Escada de mapas e carreira política

Só o bairro é um mapa jogável em detalhe. Os níveis acima são mapas de mapas: cada bairro, cidade ou estado aparece como um bloco com números resumidos, e o jogo calcula como um afeta o outro. O cargo político acompanha o nível do mapa.

O jogador começa embaixo, no bairro, e cada cargo novo abre o nível seguinte do mapa. Os níveis que ele ainda não controla são governados por robôs.
