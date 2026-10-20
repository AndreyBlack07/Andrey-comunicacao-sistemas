# Entregar o trabalho através de um Pull Request

## O que vamos fazer

O projeto está num repositório público do GitHub. Cada aluno vai criar uma
cópia própria desse repositório, chamada **fork**, e trabalhar nessa cópia.
No fim, vai propor o trabalho ao docente através de um **Pull Request (PR)**.

O PR é um pedido para rever as alterações. **Não publica as alterações no
repositório original automaticamente**: o docente revê o pedido e decide se o
aceita.

O repositório original é público e só o docente tem permissão para escrever
nele. Não precisas de pedir acesso nem de enviar o teu endereço de e-mail ao
docente. Como o projeto original é público, o teu fork, os commits e o PR
também serão públicos. Não incluas palavras-passe, tokens, dados pessoais ou
outros conteúdos que não queiras tornar públicos.

## O que faremos na aula e o que farás depois

Na aula, vamos praticar os primeiros passos: criar o fork, obter uma cópia no
computador e criar um ramo de trabalho. A implementação e a entrega do
trabalho serão feitas durante a semana, fora da aula, até à data indicada
pelo docente.

## 1. Criar o teu fork

1. Inicia sessão no GitHub com a tua conta.
2. Abre o [repositório da Aula 4](https://github.com/pedroSilva4/pdj2-comunicacao-sistemas).
3. Carrega em **Fork** e depois em **Create fork**. Mantém o nome sugerido.
4. Confirma que o endereço do fork começa pelo teu nome de utilizador,
   por exemplo `https://github.com/o-teu-utilizador/pdj2-comunicacao-sistemas`.

O fork é a tua cópia no GitHub. O repositório do docente continua a ser o
original.

## 2. Clonar o teu fork e criar um ramo

Clonar significa copiar o repositório do GitHub para o teu computador. Copia
o endereço do **teu fork** (não o do docente) e executa no Terminal:

```bash
git clone https://github.com/{{o-teu-utilizador}}/pdj2-comunicacao-sistemas.git
cd pdj2-comunicacao-sistemas
git switch -c aula4-comunicacao-sistemas
```

Substitui `{{o-teu-utilizador}}` pelo teu nome de utilizador do GitHub. O comando
`git switch -c` cria e seleciona um ramo novo. Um ramo é um espaço de trabalho
separado: permite preparar as alterações sem as misturar com a versão
principal do teu fork.

Confirma que estás no ramo certo:

```bash
git status
```

Deverás ver `On branch aula4-comunicacao-sistemas`. Se usares GitHub Desktop,
podes clonar o URL do teu fork e criar o ramo através dos menus **Current
Repository** e **New Branch**.

## 3. Trabalhar e guardar alterações

Durante a semana:

1. Abre no Unity a pasta que clonaste e trabalha na cena e nos scripts da
   ficha.
2. Testa o projeto em Play Mode e confirma que não há erros de compilação.
3. Guarda pontos de progresso com **commits**. Um commit é um registo das
   alterações que escolheste guardar; usa uma mensagem curta que diga o que
   fizeste.
4. Antes de cada commit, consulta `git status` e confirma que só vais incluir
   ficheiros do trabalho. Não envies a pasta `Library`, ficheiros temporários,
   palavras-passe ou tokens.

Exemplo de sequência no Terminal, depois de reveres a lista de ficheiros:

```bash
git status
git add Assets/Scripts
git commit -m "Completa comunicação da pontuação"
```

Se também alteraste outros ficheiros necessários, adiciona-os explicitamente
com `git add caminho/do/ficheiro`. Se alteraste cenas ou ficheiros de UI,
inclui também esses ficheiros e os respetivos `.meta`. O `.gitignore` do
projeto já exclui pastas geradas como `Library`, `Temp` e `Build`, mas confirma
sempre a lista antes de guardar o commit. Evita adicionar tudo sem rever as
alterações.

## 4. Enviar o ramo para o teu fork

Quando tiveres alterações guardadas num commit, envia o ramo para o teu fork:

```bash
git push -u origin aula4-comunicacao-sistemas
```

`origin` é o nome que o Git atribui normalmente ao endereço do repositório
clonado — neste caso, o teu fork. Este comando não envia alterações para o
repositório do docente.

Se continuares a trabalhar depois, repete os passos de rever `git status`,
criar um commit e executar:

```bash
git push
```

## 5. Abrir o Pull Request

1. Abre o teu fork no GitHub. O GitHub poderá mostrar o botão **Compare &
   pull request**; também podes abrir **Pull requests** e escolher **New
   pull request**. O pedido deve ser criado no repositório do docente, tendo
   o teu fork como origem.
2. Confirma os repositórios e ramos:
   - **base repository:** `pedroSilva4/pdj2-comunicacao-sistemas`;
   - **base branch:** `main`;
   - **head repository:** o teu fork;
   - **compare branch:** `aula4-comunicacao-sistemas`.
3. O título do PR deve seguir este formato, substituindo os campos pelo teu
   nome e número de aluno:
   `Entrega {{nome_aluno}} {{numero_aluno}}`
   Exemplo: `Entrega Ana Silva 12345`.
4. Na descrição, escreve brevemente o que completaste e que testes fizeste.
   Indica, por exemplo, se testaste a recolha dos itens, atualização da
   pontuação e abertura da porta em Play Mode.
5. Carrega em **Create pull request** e confirma que o PR aparece no
   repositório do docente com o título no formato indicado.

O PR deve ser aberto até à data indicada pelo docente. Abrir um PR não apaga
nem altera o teu fork; podes continuar a enviar commits para o mesmo ramo
enquanto o PR estiver aberto.

## Como confirmar o sentido do PR

Antes de o criar, lê a direção apresentada no GitHub. Deve dizer que o ramo
do teu fork quer ser integrado em `main` do repositório do docente. Se a
direção estiver invertida, não cries o PR: volta à página do teu fork e
escolhe **New pull request**, confirmando os quatro campos acima.

## Vocabulário essencial

| Termo                | Significado neste trabalho                                                                               |
| -------------------- | -------------------------------------------------------------------------------------------------------- |
| Repositório original | Projeto do docente no GitHub.                                                                            |
| Fork                 | Cópia do repositório original na tua conta GitHub.                                                       |
| Clone                | Cópia local do teu fork no computador.                                                                   |
| Ramo (branch)        | Linha de trabalho separada onde fazes as alterações.                                                     |
| Commit               | Registo das alterações que decidiste guardar.                                                            |
| Push                 | Envio dos commits locais para o teu fork no GitHub.                                                      |
| Pull Request         | Pedido para o docente rever as alterações do teu ramo e, se estiverem corretas, integrá-las no original. |

## Se algo correr mal

- **Não consigo fazer push:** confirma que clonaste o teu fork e que estás a
  usar a conta GitHub correta.
- **Não vejo o botão para abrir o PR:** abre o teu fork, escolhe **Pull
  requests** e depois **New pull request**.
- **O repositório ou ramo base parece errado:** não cries o PR até confirmares
  que o destino é `pedroSilva4/pdj2-comunicacao-sistemas`, ramo `main`.
- **O PR já foi aberto e fiz mais alterações:** cria um commit no mesmo ramo e
  faz `git push`; o PR atualiza-se.

Para dúvidas sobre os comandos, pede ajuda indicando o comando executado e a
mensagem de erro. Nunca partilhes palavras-passe ou tokens.

## Referências

- GitHub Docs, [Criar um fork de um repositório](https://docs.github.com/en/pull-requests/how-tos/work-with-forks/fork-a-repo).
- GitHub Docs, [Criar um Pull Request a partir de um fork](https://docs.github.com/en/pull-requests/how-tos/create-pull-requests/creating-a-pull-request-from-a-fork).
