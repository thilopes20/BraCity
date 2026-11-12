# BraCity (nome provisório)

Construtor de cidade em que o jogador reconstrói bairros reais do Brasil, partindo do traçado verdadeiro das ruas, dos rios e das matas. A cidade cresce do jeito brasileiro: lotes à venda, famílias que chegam aos poucos e levantam a própria casa, e uma população que cobra escola, posto de saúde, mercado, ônibus e segurança.

O gancho é pessoal: o jogador procura a própria rua no mapa e decide como o bairro dele poderia ser. Por cima disso corre uma carreira: começa no bairro, como vereador ou cidadão comum, e sobe até prefeito, governador e presidente, conforme o mapa se amplia.

**Status:** fase de design (GDD v1.1). Protótipo não iniciado.

## Documento de Design (GDD)

| Capítulo | Conteúdo |
|---|---|
| [1. Visão geral e mapas](docs/gdd/01-visao-e-mapas.md) | Ficha de decisões, fontes de dados, escala e divisão de mapas, escada de carreira |
| [2. Crescimento e serviços](docs/gdd/02-crescimento-e-servicos.md) | Loteamento, moradores, comércio espontâneo, catálogo de construções, necessidades, orçamento, comunidades, segurança e desastres |
| [3. Modo civil](docs/gdd/03-modo-civil.md) | Os dois modos, necessidades do personagem, saúde, doenças, moradia |
| [4. Relações e carreiras](docs/gdd/04-relacoes-carreiras.md) | Relacionamentos, estudo e provas, carreiras, empregos, jornada |
| [5. Política e economia](docs/gdd/05-politica-economia.md) | Eleições, carreira política, empresas, finanças dos dois modos, corrupção |
| [6. Tempo, eventos e tecnologia](docs/gdd/06-tempo-eventos-tecnologia.md) | Controle do tempo, clima e estações, economia em números, sistema de eventos, Unity, interface, PC e celular, fases de desenvolvimento |

## Fases de desenvolvimento (resumo)

Cada fase termina com algo jogável. A seguinte só começa quando a anterior estiver funcionando:

1. Protótipo: câmera isométrica, terreno, rua curva, prédio
2. Bairro real: importar um bairro de teste do OpenStreetMap
3. Crescimento: lotes, moradores, obra em etapas, comércio espontâneo
4. Serviços e orçamento, com clima e estações como gatilhos de eventos e desastres
5. Carreira de vereador
6. Comunidades, segurança e desastres
7. Modo vida
8. Online cooperativo

## Licença e créditos

Dados de mapa: © OpenStreetMap contributors (ODbL) — crédito obrigatório no jogo. Limites e comunidades: IBGE. Relevo: SRTM (NASA).
