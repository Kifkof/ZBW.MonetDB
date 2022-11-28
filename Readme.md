# ZBW MonetDB Demo

## Prerequisites

- Docker Desktop [Download for Windows](https://desktop.docker.com/win/main/amd64/Docker%20Desktop%20Installer.exe?utm_source=docker&utm_medium=webreferral&utm_campaign=dd-smartbutton&utm_location=module)
- dotnet 7 [SDK Download](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.100-windows-x64-installer)
- Visual Studio 2022

## Getting Started

1. Navigation zu Ordner "...\ZBW.MonetDB\compose"
2. Powershell Fenster im aktuellen Verzechniss öffnen
3. Folgenen Befehl ausführen

```
docker compose up -d
```

### Verify Database

Um zu überprüfen ob die Datenbank läuft kann folgender Befehl ausgeführt werden um auf das CLI zuzugreiffen

```
docker exec -it monetdb mclient demo
```

Hier kann dann einfach SQL ausgeführt werden. Als Test kann folgender Befehl ausgeführt werden

```
SELECT 'hello world';
```

## Demo

Nun kann die Solution im Ordner: "...\src\MonetDB" geöffnet werden.
Das Projekt sollte einfach gestartet werden können.

Folgende Schritte werden vom Code durchlaufen:

1. Löschen der Tabelle Person wenn diese bereits existiert
2. Erstellen der Tabelle Person
3. Tabelle Person mit 4 Einträgen befüllen
4. Ausgabe der 4 Einträge auf der Konsole
5. Berechnung der durchschnittlichen Berufserfahrung über alle Personen mit Ausgabe auf der Konsole
