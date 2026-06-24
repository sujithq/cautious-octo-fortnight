# GitHub Copilot in VS Code — Build 2026 Demo Guide

> **Target audience:** Developers who want to see GitHub Copilot's new agentic features in VS Code introduced at Microsoft Build 2026.
> **Sample project:** The `.NET 10` TodoApi in `src/TodoApi` of this repository.
> **Changelog sources:** [VS Code May 2026 releases](https://github.blog/changelog/2026-06-03-github-copilot-in-visual-studio-code-may-releases/) · [VS Code 1.125 release notes](https://code.visualstudio.com/updates) · [VS Code March 2026 releases](https://github.blog/changelog/2026-04-08-github-copilot-in-visual-studio-code-march-releases/)

---

## Prerequisites

| Requirement | Version |
|-------------|---------|
| Visual Studio Code | ≥ 1.125 |
| GitHub Copilot Chat extension (`github.copilot-chat`) | Latest (auto-updated; `github.copilot` is deprecated) |
| GitHub Copilot subscription | Pro / Pro+ / Business / Enterprise |
| .NET SDK | 10.0 |
| Node.js (optional, for MCP servers) | ≥ 22 LTS |

### Enable agent features

1. Open VS Code Settings (`Ctrl+,` / `Cmd+,`).
2. Search for **`chat.agent`** and enable:
   - `GitHub Copilot: Enable Agents`
   - `GitHub Copilot: Enable Background Agents`
   - `GitHub Copilot: Enable Cloud Agents`
3. Reload VS Code.

---

## Demo 1 — Agent Mode: Autonomous multi-file editing

**What it shows:** Copilot Agent Mode plans and executes multi-file changes autonomously, runs the compiler and tests, then self-corrects without manual intervention.

### Steps

1. Open this repository in VS Code.
2. Open the Copilot Chat panel (`Ctrl+Alt+I` / `Cmd+Alt+I`).
3. Switch mode to **Agent** using the dropdown at the bottom of the chat input.
4. Enter the following prompt:

   ```
   Add a `DueDate` (nullable DateTimeOffset) field to the TodoItem record.
   Update Program.cs so the existing seed data includes sample due dates.
   Add a new GET /todos/overdue endpoint that returns only items where DueDate < now.
   Write an xUnit integration test for the new endpoint.
   Run dotnet build and dotnet test; fix any errors before finishing.
   ```

5. Watch Copilot:
   - Read `Models/TodoItem.cs` and `Program.cs`.
   - Produce a step-by-step plan (shown in chat).
   - Edit both files automatically.
   - Open a terminal, run `dotnet build` and `dotnet test`.
   - Iterate if tests fail.
6. Review the diff in the Source Control panel.
7. Accept or reject individual file changes using the inline toolbar.

> **Key point:** Agent Mode can edit _n_ files and run terminal commands in a loop — you don't have to copy-paste anything.

---

## Demo 2 — GitHub.com Cloud Agent (Moved)

**What it shows:** GitHub.com cloud-agent workflows (assign issue, start browser sessions, iterate in PRs).

This demo has moved to [docs/github.com.md](docs/github.com.md) and was updated to match the latest GitHub Docs flow.

---

## Demo 3 — Remote Agents over SSH / Dev Tunnels (Skip)

**What it shows:** Run an agent session on a remote machine while working on a low-powered laptop.

### Steps

1. Connect VS Code to a remote host:
   - **SSH:** `Ctrl+Shift+P` → `Remote-SSH: Connect to Host`
   - **Dev Tunnel:** `Ctrl+Shift+P` → `Dev Tunnels: Connect to Tunnel`
2. Open the `src/TodoApi` folder on the remote host.
3. Open Copilot Chat and switch to **Agent Mode**.
4. Enter a prompt — the agent runs on the remote machine; you see live output locally.
5. Disconnect your laptop from the network — the agent **keeps running** on the remote host.
6. Reconnect later; resume the session from where it left off.

---

## Demo 4 — Integrated Browser Debugger

**What it shows:** Debug the running TodoApi inside VS Code's embedded browser with breakpoints.

### Steps

1. Start the API in debug mode:
   ```bash
   dotnet restore cautious-octo-fortnight.sln
   dotnet build cautious-octo-fortnight.sln
   ```
   Then open **Run and Debug** (`Ctrl+Shift+D`) and start the TodoApi debug profile (for example **C#: TodoApi** or **.NET Launch (web)**).
2. Open the Command Palette → **`Simple Browser: Show`** → enter the OpenAPI URL shown by the app at startup (for example `http://localhost:5000/openapi/v1.json` or `https://localhost:5001/openapi/v1.json`).
   - If the command is missing, enable the built-in extension **Simple Browser** (`ms-vscode.simple-browser`) from **Extensions: Show Built-in Extensions**.
   - Fallback: open the same URL in your system browser.
3. Open `Program.cs` and set a breakpoint on the `MapGet("/todos", ...)` lambda.
4. In Copilot Chat (Agent Mode), prompt:
   ```
   Call GET /todos using the embedded browser and pause at my breakpoint.
   ```
5. The agent opens the URL; VS Code hits the breakpoint; inspect locals in the Debug panel.

---

## Demo 5 — Custom Copilot Instructions

**What it shows:** `.github/copilot-instructions.md` personalizes every agent session for this project.

### Steps

1. Open `.github/copilot-instructions.md` — notice the coding conventions declared there.
2. In Copilot Chat, type:
   ```
   Add a new endpoint.
   ```
3. Copilot automatically:
   - Uses `.WithName()` and `.WithSummary()` (from the instructions).
   - Targets `net10.0`.
   - Writes an accompanying xUnit test.
4. Temporarily delete a rule from the instructions file and repeat — observe the change in behavior.

---

## Demo 6 — Plan Agent (Plan before you code)

**What it shows:** Collaborate with Copilot on a written implementation plan _before_ any code is generated — introduced in the June 2026 changelog.

### Steps

1. Open Copilot Chat and type `/plan`:

   ```
   /plan Add a pagination feature to GET /todos — support ?page= and ?pageSize= query params with defaults of 1 and 20.
   ```

2. Copilot responds with a Markdown plan saved as a file (e.g. `.github/plans/pagination.md`):

   ```markdown
   ## Plan: Pagination for GET /todos

   ### Approach
   - Read `page` and `pageSize` query params; default 1 and 20 respectively.
   - Validate: page ≥ 1, pageSize 1–100.
   - Return a paginated envelope: `{ items, page, pageSize, total }`.

   ### Files to change
   - `src/TodoApi/Program.cs` — update MapGet handler.
   - `src/TodoApi.Tests/TodoApiTests.cs` — add pagination tests.
   ```

3. Review the plan in the editor. Edit any step — Copilot will adjust subsequent steps automatically.
4. When satisfied, click **Implement Plan** (or type `/implement`) — Copilot executes the steps sequentially.
5. Accept or reject file changes using the inline diff toolbar.

> **Key point:** Planning before coding reduces back-and-forth and gives you an auditable record of intent.

---

## Demo 7 — Agent Skills Management

**What it shows:** Manage Agent Skills from the Agent Customizations editor, then invoke skills with slash commands.

### Steps

1. Open the Command Palette and run **`Chat: Open Customizations`**.
2. In the Agent Customizations editor, open the **Skills** tab.
3. Browse project, personal, and extension-contributed skills; open one to inspect its `SKILL.md` frontmatter and instructions.
4. Create a workspace skill from the dropdown (**New Skill (Workspace)**). VS Code creates a skill folder with `SKILL.md` under `.github/skills/`.
5. Control skill visibility/invocation via frontmatter:
   - `user-invocable: false` hides it from the `/` menu.
   - `disable-model-invocation: true` prevents automatic model loading.
6. In chat, type `/` and invoke your skill (for example `/my-skill`) to verify it is available and behaves as expected.

---

## Demo 8 — Context Usage Visualisation

**What it shows:** A live indicator of how much of the context window is consumed by the current conversation, with a one-click summarisation to recover space.

### Steps

1. Open Copilot Chat and have an extended conversation (paste large code snippets, ask multi-step questions).
2. Watch the context-usage bar at the top of the chat panel fill up.
3. When it reaches ~80 %, a warning badge appears: _"Context window is almost full."_
4. Click **Summarise conversation** — Copilot condenses earlier messages into a compact summary, freeing context budget.
5. Continue the conversation — the bar resets to a lower level.
6. Hover the bar at any time to see a tooltip: tokens used / total tokens available.

---

## Demo 9 — Language Models Editor (BYOK)

**What it shows:** Install additional model providers or use your own API key (BYOK) directly from VS Code, without leaving the editor. Introduced in VS Code 1.125.

### Steps

1. Open the Command Palette → **`Language Models: Open Language Models Editor`**.
2. The editor lists installed model providers (GitHub, Azure OpenAI, Ollama …).
3. Click **+ Install Provider** → browse the marketplace panel on the right.
4. Select **Azure OpenAI** → enter your endpoint URL and API key → click **Save**.
5. In Copilot Chat, click the model picker → you now see your Azure model alongside GitHub-hosted models.
6. Switch to your Azure model and run a prompt — responses come directly from your deployment.

> **Key point:** BYOK lets enterprise teams keep data inside their own Azure tenancy while using the full Copilot UX.

---

## Demo 10 — Multi-file Change Diff & Accept/Reject

**What it shows:** After an agent edits multiple files, review all changes in a consolidated diff before accepting.

### Steps

1. Run an agent task that touches several files (e.g. Demo 1 — adding the `DueDate` field).
2. When the agent finishes, the **Multi-file Diff** panel opens automatically.
3. The panel shows a tree of changed files with line counts.
4. Review each file's diff inline; use the hunk-level **Accept** / **Reject** buttons to cherry-pick changes.
5. Use the top-level **Accept All** or **Undo All** buttons for bulk actions.
6. Use **Ctrl+Z** to undo the last accepted hunk if you change your mind.

---

## Tips

- Use `/fix` in chat to auto-fix compiler errors highlighted in the editor.
- Use `/tests` to generate tests for the currently open file.
- Use `/explain` to get a plain-English explanation of any selected code block.
- Press `Ctrl+I` to open **inline chat** directly in the editor without leaving your context.
- Chronicle your session: type `/chronicle` in chat to get a summary of what Copilot changed today.
- Type `/plan` before a complex task to align on approach before generating code.
- Open the **Skills** panel to control exactly which capabilities agents have.
- Monitor the context-usage bar in long sessions and summarise proactively to avoid hitting the limit.

