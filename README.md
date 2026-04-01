<p align=center>
  <img width=256 height=256 src="https://github.com/belowaverage-org/SuperSeek/blob/master/SuperSeek/Resources/logo.png?raw=true">
</p>

# Super Seek
A High‑Performance File & Content Search Tool for Windows

# OVERVIEW
SuperSeek is a fast, modern Windows desktop application for searching files and file contents using regular expressions, extension filtering, and parallel scanning. It is designed for power users, developers, and IT professionals who need a lightweight but powerful alternative to traditional file search tools.
SuperSeek is built with .NET 10 (Windows) and Windows Forms, with a strong focus on performance, responsiveness, and low system impact.

# FEATURES
* High‑Speed Scanning
  * Asynchronous, multi‑threaded directory scanning designed to scale to large folder trees.
* Regex Search
  * Full regular expression support for searching file contents and file paths.
* Extension Filtering
  * Live, searchable extension filter panel with per‑extension file counts and checkboxes.
* File Operations
  * Open files directly, reveal them in Explorer, or open with a chosen application.
* Configurable Performance
  * Adjustable scan aggressiveness, memory limits, and maximum file size thresholds.
* Live Status & Metrics
  * Real‑time progress bar, scanned file count, result count, CPU usage, and memory usage.
* Modern Windows UI
  * Resizable layout with split panels, keyboard navigation, and real‑time updates.

# SCREENSHOTS
Main Window layout:
* Extension filter panel on the left
* Search results on the right
* Regex search bar at the top
* Status bar with progress, CPU, and memory usage at the bottom

<img width="985" height="693" alt="image" src="https://github.com/user-attachments/assets/5c05bdc6-c2a9-402e-9dd3-66438b827d1c" />

# REQUIREMENTS
* Windows 7 or higher
* .NET 10.0 Runtime (Windows)
* x64 architecture recommended

# INSTALLATION
SuperSeek is portable and does not require installation.

# USAGE
1. Open a Folder
  * Click “Open Folder…” to select the root directory for searching.
2. Filter File Extensions
  * Use the extension list to include or exclude file types. The extension search box filters the list instantly.
3. Enter Search Pattern
  * Enter a regular expression. Choose whether to search file paths, file contents, or both.
4. Start Searching
  * Click “Search”. Progress and results update live.

## Work With Results
Double‑click a file to open it.
Use “Show Folder” or “Open With…” for additional actions.
Keyboard navigation is fully supported.

# SETTINGS
Accessible via File → Settings…

Available options include:
* Scan Aggressiveness
  * Controls concurrency and scan throughput.
* Memory Ceiling
  * Caps memory usage to prevent system slowdown.
* Maximum File Size
  * Skips large files for improved performance.

# BUILDING FROM SOURCE
Prerequisites:
* Visual Studio 2022 or newer
* .NET 10 SDK (Windows)

Steps:
1. Clone the repository
2. Open SuperSeek.sln in Visual Studio
3. Restore NuGet packages
4. Build and run

# TECHNOLOGIES USED
* .NET 10 (Windows)
* C#
* Windows Forms
* Microsoft.Windows.CsWin32
* Native Win32 API interop

# LICENSE
Copyright (c) 2026 below average
All rights reserved.

# DISCLAIMER
SuperSeek is provided “as is”, without warranty of any kind.
Use at your own risk.
