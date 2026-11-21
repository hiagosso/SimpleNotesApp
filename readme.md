# SimpleNotes

Um editor de texto para Windows, desenvolvido em C# com WPF e .NET 10.

O SimpleNotes tem como objetivo oferecer uma experiência simples e direta para criação, edição e gerenciamento de arquivos de texto, com integração ao sistema operacional Windows.

## Funcionalidades

- Criar novos documentos.
- Abrir arquivos existentes.
- Salvar documentos.
- Salvar documentos utilizando outro nome ou diretório.
- Identificar alterações não salvas.
- Solicitar confirmação antes de descartar alterações.
- Controle de zoom utilizando `Ctrl + roda do mouse`.
- Abertura de arquivos por argumentos de linha de comando.
- Integração com o menu de contexto do Windows.
- Registro como aplicativo compatível com arquivos de diferentes extensões.
- Instalador e desinstalador para Windows.

## Tecnologias utilizadas

- C#
- .NET 10
- WPF
- XAML
- Inno Setup

## Estrutura do projeto

```text
SimpleNotes/
│
├── Assets/
│   └── icone.ico
│
├── Installer/
│   └── SimpleNotes.iss
│
├── Models/
│   └── Document.cs
│
├── Services/
│   ├── DocumentService.cs
│   └── FileService.cs
│
├── utils/
│   └── FileOperations.cs
│
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── AboutWindow.xaml
├── AboutWindow.xaml.cs
├── App.xaml
├── App.xaml.cs
├── SimpleNotes.csproj
└── README.md
```

## Requisitos para desenvolvimento

- Windows 10 ou Windows 11.
- Visual Studio com suporte ao desenvolvimento desktop com .NET.
- .NET 10 SDK.
- Inno Setup para gerar o instalador.

## Executar o projeto

Clone o repositório:

```bash
git clone https://github.com/hiagosso/SimpleNotesApp.git
```

Entre na pasta do projeto:

```bash
cd SimpleNotes
```

Execute:

```bash
dotnet run
```

## Abrir arquivos pela linha de comando

O SimpleNotes aceita o caminho de um arquivo como argumento:

```powershell
dotnet run -- "C:\Documentos\anotacoes.txt"
```

Também é possível executar diretamente o aplicativo:

```powershell
SimpleNotes.exe "C:\Documentos\anotacoes.txt"
```

Esse mecanismo permite que o Windows encaminhe arquivos ao aplicativo por meio do menu de contexto e de associações de arquivos.

## Publicação

Para gerar uma publicação independente de runtime para Windows 64 bits:

```powershell
dotnet publish .\SimpleNotes.csproj -c Release -r win-x64 --self-contained true
```

Os arquivos publicados serão gerados em:

```text
bin/Release/net10.0-windows/win-x64/publish/
```

A publicação self-contained inclui o runtime necessário para executar o aplicativo, dispensando a instalação separada do runtime do .NET 10 pelo usuário.

## Gerar o instalador

O projeto utiliza Inno Setup para empacotar a publicação.

1. Gere a publicação Release.
2. Abra `Installer/SimpleNotes.iss` no Inno Setup.
3. Confira o caminho configurado em `PublishDir`.
4. Compile o script.
5. O instalador será gerado na pasta `InstallerOutput`.

O instalador configura:

- Diretório de instalação.
- Atalho no menu Iniciar.
- Atalho opcional na área de trabalho.
- Registro do aplicativo no Windows.
- Opção de abertura de arquivos pelo menu de contexto.
- Desinstalação do aplicativo.

## Integração com o Windows

O instalador registra o SimpleNotes como aplicativo capaz de abrir arquivos de diferentes extensões e adiciona uma ação de abertura ao menu de contexto.

A associação como aplicativo padrão continua sob controle do usuário, por meio das configurações do Windows.

**Observação:** o SimpleNotes é um editor de texto simples. Embora possa receber arquivos com diferentes extensões, arquivos binários ou formatos estruturados, como imagens, executáveis e documentos do Word, não são interpretados como seus aplicativos especializados.

A posição dos comandos no menu de contexto também pode variar conforme a versão do Windows.

## Git e versionamento

Os arquivos de código-fonte, configurações e scripts do instalador devem ser versionados.

Pastas geradas durante compilação e publicação não devem ser enviadas ao repositório:

```gitignore
bin/
obj/
.vs/
publish/
InstallerOutput/
```
## Licença

Este projeto está licenciado sob a GNU General Public License v3.0 (GPL-3.0).

Você pode utilizar, estudar, modificar e redistribuir este software,
desde que respeite os termos da licença.

Consulte o arquivo [LICENSE](LICENSE) para obter o texto completo.


---

Desenvolvido como projeto de aprendizado e prática de desenvolvimento desktop com C# e WPF.
