# BmxGui
GUI для bmx (MXF анализ).

## Установка
1. .NET 8.0 SDK.
2. bmx: https://github.com/ebu/bmx (mxf2raw.exe в bin/Debug).
3. MediaInfo.dll (x64): https://mediaarea.net/en/MediaInfo/Download/Windows (в bin/Debug).
4. dotnet build BmxGui.sln (x64).

## Использование
- Выберите инструмент (mxf2raw).
- Задать путь bmx в Settings.
- Run для анализа (лог, проверки A/V/TC).

## Функции
- A/V синхронизация, таймкод continuity.
- P/Invoke MediaInfo для потоков.

## Лицензия
MIT
