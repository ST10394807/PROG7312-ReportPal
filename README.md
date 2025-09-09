# PROG7312: ReportPal  
Windows Forms (.NET Framework) - Municipal Citizen Engagement App  

## Description
Windows desktop app to report municipal issues fast and clean. This is Part 1/2 of the POE. “Local Events/Announcements” and “Service Request Tracking” are placeholders for now. The working feature is Report Issues with language/theme switching, validation, and basic attachments.


## Features
- Report Issues: Name, Email, Suburb, Full Address, Category, Description, optional attachments.
- Language: English / Afrikaans / Zulu (Settings → Language). Placeholders and lists update live.
- Theme: Light / Dark / System (Settings → Theme).
- Validation: required fields, basic email format check, description length guard.
- Progress: simple completion indicator.
- Attachments: .png/.jpg/.jpeg/.pdf up to 5 MB each (listed inline).
- Responsive UI: TableLayoutPanel + FlowLayoutPanel; resizes cleanly.

> Current storage is in-memory (`List<Issue>`). No DB, no admin panel, no outgoing email in this submission.

## Requirements
- Windows
- Visual Studio 2019/2022 with .NET desktop development
- .NET Framework 4.7.2 Developer Pack

## Build
### Visual Studio
1. Open `ReportPal.sln`.
2. Set startup project to ReportPal
3. Build - Rebuild Solution (Debug/Release).
4. Run with F5 or start the exe in `bin\Release\`.

## Run
- Launch the app.
- From Main Menu (Form1), click Report Issues.

## Use
- Enter Name and Email.
- Pick Suburb (first item is localized: Select/Kies/Khetha).
- Enter Full Address.
- Choose Category (Water/Electricity/Roads/Sanitation).
- Add a clear Description (15–500 chars).
- (Optional) Upload images/PDFs (≤ 5 MB each). 
- Click Submit. The form validates and confirms.
- Return closes the form.
- Settings → Language/Theme can be changed at any time.
## Project Structure
- Form1 is Main menu.
- ReportIssuesForm: Issue form, menu, language/theme logic, validation, attachments.
- AppSettings: Global Language/Theme with change events.
- Issue model: In-memory list for this submission.
## Data & Privacy (current)
- Data is not persisted to disk or a server in this version.
- Attachments are only selected and listed; no upload.
- Email is validated locally; no emails are sent.
- Known Limitations
- No database/admin panel.
- No email notifications.
- Events/Service Request pages are placeholders.
- In-memory data resets on app restart.

## Roadmap (next)
- Persist issues (SQLite/MySQL/API) + admin view.
- Email receipts to reporter; notifications to admin/councillor map.
- “View Submitted Issues” with filtering.
- Complete Events and Service Request flows.