
#define AppName "SimpleNotes"
#define AppVersion "1.0.0"
#define AppPublisher "SimpleNotes"
#define AppExeName "SimpleNotes.exe"
#define AppId "A91C8E35-7B21-4D93-9F14-2A6E8C51B730"

// Ajuste se sua pasta de publicação estiver em outro local.
#define PublishDir "..\SimpleNotes\bin\Release\net10.0-windows\win-x64\publish"

[Setup]
AppId={#AppId}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}

DefaultDirName={autopf}\SimpleNotes
DefaultGroupName=SimpleNotes

OutputDir=..\InstallerOutput
OutputBaseFilename=SimpleNotes-Setup

SetupIconFile=..\SimpleNotes\Assets\icone.ico
UninstallDisplayIcon={app}\{#AppExeName}

ArchitecturesInstallIn64BitMode=x64os
ArchitecturesAllowed=x64
PrivilegesRequired=admin

WizardStyle=modern
Compression=lzma2
SolidCompression=yes

ChangesAssociations=yes

UninstallDisplayName=SimpleNotes

[Tasks]
Name: "desktopicon"; Description: "Criar atalho na área de trabalho"; GroupDescription: "Atalhos adicionais:"; Flags: unchecked

[Files]
Source: "{#PublishDir}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\SimpleNotes"; Filename: "{app}\{#AppExeName}"; IconFilename: "{app}\{#AppExeName}"
Name: "{autodesktop}\SimpleNotes"; Filename: "{app}\{#AppExeName}"; IconFilename: "{app}\{#AppExeName}"; Tasks: desktopicon

[Registry]

; =====================================================
; REGISTRO GERAL DO APLICATIVO
; Permite que o Windows reconheça o SimpleNotes
; como aplicativo capaz de abrir arquivos.
; =====================================================

Root: HKLM; Subkey: "Software\Classes\Applications\{#AppExeName}"; ValueType: string; ValueName: "FriendlyAppName"; ValueData: "SimpleNotes"; Flags: uninsdeletekey

Root: HKLM; Subkey: "Software\Classes\Applications\{#AppExeName}\DefaultIcon"; ValueType: string; ValueData: "{app}\{#AppExeName},0"

Root: HKLM; Subkey: "Software\Classes\Applications\{#AppExeName}\shell\open\command"; ValueType: string; ValueData: """{app}\{#AppExeName}"" ""%1"""

; =====================================================
; PROGID DO SIMPLENOTES
; =====================================================

Root: HKLM; Subkey: "Software\Classes\SimpleNotes.Text"; ValueType: string; ValueData: "Arquivo de texto - SimpleNotes"; Flags: uninsdeletekey

Root: HKLM; Subkey: "Software\Classes\SimpleNotes.Text\DefaultIcon"; ValueType: string; ValueData: "{app}\{#AppExeName},0"

Root: HKLM; Subkey: "Software\Classes\SimpleNotes.Text\shell\open\command"; ValueType: string; ValueData: """{app}\{#AppExeName}"" ""%1"""

; =====================================================
; DISPONIBILIZAÇÃO PARA ARQUIVOS TXT
; =====================================================

Root: HKLM; Subkey: "Software\Classes\.txt\OpenWithProgids"; ValueType: string; ValueName: "SimpleNotes.Text"; ValueData: ""; Flags: uninsdeletevalue

; =====================================================
; AÇÃO DIRETA NO MENU DE CONTEXTO
; Disponibiliza a opção para arquivos de qualquer extensão.
; =====================================================

Root: HKLM; Subkey: "Software\Classes\*\shell\SimpleNotes"; ValueType: string; ValueName: "MUIVerb"; ValueData: "Abrir com SimpleNotes"; Flags: uninsdeletekey

Root: HKLM; Subkey: "Software\Classes\*\shell\SimpleNotes"; ValueType: string; ValueName: "Icon"; ValueData: "{app}\{#AppExeName},0"

Root: HKLM; Subkey: "Software\Classes\*\shell\SimpleNotes\command"; ValueType: string; ValueData: """{app}\{#AppExeName}"" ""%1"""

; =====================================================
; REGISTRO NAS CONFIGURAÇÕES DE APLICATIVOS PADRÃO
; =====================================================

Root: HKLM; Subkey: "Software\SimpleNotes\Capabilities"; ValueType: string; ValueName: "ApplicationName"; ValueData: "SimpleNotes"; Flags: uninsdeletekey

Root: HKLM; Subkey: "Software\SimpleNotes\Capabilities"; ValueType: string; ValueName: "ApplicationDescription"; ValueData: "Editor de texto SimpleNotes"

Root: HKLM; Subkey: "Software\SimpleNotes\Capabilities\FileAssociations"; ValueType: string; ValueName: ".txt"; ValueData: "SimpleNotes.Text"

Root: HKLM; Subkey: "Software\RegisteredApplications"; ValueType: string; ValueName: "SimpleNotes"; ValueData: "Software\SimpleNotes\Capabilities"; Flags: uninsdeletevalue

[Run]
Filename: "{app}\{#AppExeName}"; Description: "Executar SimpleNotes"; Flags: postinstall nowait skipifsilent
