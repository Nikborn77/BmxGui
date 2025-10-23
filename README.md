# BMX GUI - Visual wrapper for BBC bmx tools

This Windows Forms application provides a graphical front-end to the command-line tools
from the BBC `bmx` project (https://github.com/bbc/bmx). It does **not** include bmx binaries;
you must build or download `bmx` and point the application to the folder containing the executables.

## Features
- Choose which bmx tool to run (raw2bmx, bmxtranswrap, mxf2raw, bmxparse, h264dump, etc.)
- Browse and select input files
- Provide additional command-line arguments in a text box
- View real-time stdout/stderr in the log panel
- Save path-to-bmx in user settings
- Open output folder quickly

## How to use
1. Build or download `bmx` executables for your OS and place them in a folder (e.g. `C:\tools\bmx\`).
2. Open the solution in Visual Studio (requires .NET 6) or build with `dotnet build`.
3. Run the app.
4. Click Settings -> set the path to bmx binaries.
5. Select a tool, choose input file, set extra arguments and click Run.

## Notes & Extensions
- This project is a starting point. You can extend by adding specific option UIs for each tool,
  file drag & drop, batch processing, presets, and metadata parsing UI.
- Error handling for each bmx tool's specific output can be enhanced for better UX.

