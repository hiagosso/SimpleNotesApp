
#define AppName "SimpleNotes"
#define AppVersion "1.0.0"
#define AppPublisher "SimpleNotes"
#define AppExeName "SimpleNotes.exe"

// Ajuste este caminho para a sua pasta publish.
#define PublishDir "C:\Projetos\SimpleNotesApp\SimpleNotes\bin\Release\net10.0-windows\win-x64"

[Setup]
AppId={{A91C8E35-7B21-4D93-9F14-2A6E8C51B730}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}

DefaultDirName={autopf}\SimpleNotes
DefaultGroupName={#AppName}

OutputDir= C:\Users\hiago\Downloads\
OutputBaseFilename=SimpleNotes-Setup

SetupIconFile= "C:\Projetos\SimpleNotesApp\SimpleNotes\Assets\icone.ico"
UninstallDisplayIcon={app}\{#AppExeName}

ArchitecturesInstallIn64BitMode=x64os
PrivilegesRequired=admin

WizardStyle=modern
Compression=lzma2
SolidCompression=yes

ChangesAssociations=yes

[Tasks]
Name: "desktopicon"; \
    Description: "Criar atalho na área de trabalho"; \
    GroupDescription: "Atalhos adicionais:"; \
    Flags: unchecked

[Files]
Source: "{#PublishDir}\*"; \
    DestDir: "{app}"; \
    Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\SimpleNotes"; \
    Filename: "{app}\{#AppExeName}"

Name: "{autodesktop}\SimpleNotes"; \
    Filename: "{app}\{#AppExeName}"; \
    Tasks: desktopicon

[Registry]

// Registra o ProgID do SimpleNotes.
Root: HKLM; \
    Subkey: "Software\Classes\SimpleNotes.Text"; \
    ValueType: string; \
    ValueData: "Documento de texto - SimpleNotes"; \
    Flags: uninsdeletekey

Root: HKLM; \
    Subkey: "Software\Classes\SimpleNotes.Text\DefaultIcon"; \
    ValueType: string; \
    ValueData: "{app}\{#AppExeName},0"

Root: HKLM; \
    Subkey: "Software\Classes\SimpleNotes.Text\shell\open\command"; \
    ValueType: string; \
    ValueData: """{app}\{#AppExeName}"" ""%1"""

// Disponibiliza o SimpleNotes em "Abrir com".
Root: HKLM; \
    Subkey: "Software\Classes\Applications\{#AppExeName}\SupportedTypes"; \
    ValueType: string; \
    ValueName: ".txt"; \
    ValueData: ""

Root: HKLM; \
    Subkey: "Software\Classes\.txt\OpenWithProgids"; \
    ValueType: string; \
    ValueName: "SimpleNotes.Text"; \
    ValueData: ""

// Registra o aplicativo nas configurações de aplicativos padrão.
Root: HKLM; \
    Subkey: "Software\SimpleNotes\Capabilities"; \
    ValueName: "ApplicationName"; \
    ValueType: string; \
    ValueData: "SimpleNotes"

Root: HKLM; \
    Subkey: "Software\SimpleNotes\Capabilities"; \
    ValueName: "ApplicationDescription"; \
    ValueType: string; \
    ValueData: "Editor de texto SimpleNotes"

Root: HKLM; \
    Subkey: "Software\SimpleNotes\Capabilities\FileAssociations"; \
    ValueName: ".txt"; \
    ValueType: string; \
    ValueData: "SimpleNotes.Text"

Root: HKLM; \
    Subkey: "Software\RegisteredApplications"; \
    ValueName: "SimpleNotes"; \
    ValueType: string; \
    ValueData: "Software\SimpleNotes\Capabilities"

[Run]
Filename: "{app}\{#AppExeName}"; \
    Description: "Executar SimpleNotes"; \
    Flags: postinstall nowait skipifsilent
