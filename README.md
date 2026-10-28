# Aula 4 — Solução de referência do professor

Esta pasta contém a versão funcional de referência para demonstração e
validação pelo docente. A versão dos alunos foi distribuída separadamente e
mantém os esqueletos dos scripts.

## Começar

1. Abrir este projeto no Unity **6000.3.10f1**.
2. Abrir `Assets/Scenes/Aula4_ComunicacaoSistemas.unity` (não `SampleScene`).
3. Executar e validar em **Play Mode**; não é necessária uma build.
4. Consultar a [Ficha de Trabalho — Aula 4](./docs/ficha_aluno.md) para os
   requisitos, a sequência de implementação e os testes esperados.

## Soluções incluídas

| Script | Papel |
| --- | --- |
| `IInteractable.cs`, `PlayerInteraction.cs` | Contrato de interação e chamada sem dependência de `Collectible`. |
| `Collectible.cs`, `ScoreSystem.cs` | Recolha, atualização da pontuação e emissão de `ScoreChanged`. |
| `ScoreDisplay.cs`, `ScoreDoor.cs` | Subscritores independentes para HUD e regra de abertura da porta. |
| `VictoryScreen.cs` | Exercício extra: apresentação reage ao evento de entrada na porta. |
| `PlayerMovement.cs`, `Health.cs`, `UIManager.cs` | Movimento e HUD de vida já funcionais. |
| `Aula3EnemyMovement.cs`, `DamageZone.cs` | Inimigo reutilizado da aula anterior, mantido como exemplo. |

O Singleton e a Event Queue permanecem como comparação/aprofundamento
conceptual; não fazem parte da implementação principal da ficha.

Os colliders dos collectibles são triggers para que o Player os possa tocar
sem ficar bloqueado. A área de interação também é trigger; evita contabilizar
uma recolha mais do que uma vez.

O inimigo conservou componentes de UI do projeto anterior. São contexto
reutilizado e não fazem parte da tarefa de UI Toolkit da aula 4. Não o
reimplementes; ativa-o em Play Mode apenas quando indicado. Na cena funcional
de referência, o inimigo causa dano quando apanha o Player e a vida a zero
apresenta Game Over.
