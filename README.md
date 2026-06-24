# GitHub Copilot — Build 2026 Feature Showcase 🚀

> **Demo repository** for the latest GitHub Copilot features announced at **Microsoft Build 2026** across VS Code, the CLI, and the new Copilot desktop App.

## What's new since Build 2026?

| Area | Headline feature |
|------|-----------------|
| **VS Code** | Multi-agent orchestration, remote agents, nested sub-agents, integrated browser debugger |
| **CLI** | Rubber Duck cross-model review, voice input, prompt scheduling, redesigned terminal UI |
| **App** | Agent-native desktop (My Work dashboard, Canvas, Agent Merge, isolated git worktrees) |
| **Models** | Project Polaris (Microsoft in-house model, replacing GPT-4 Turbo from August 2026) |
| **SDK** | Generally available in Node.js, Python, Go, .NET, Rust, Java |

## Repository structure

```
.
├── .github/
│   └── copilot-instructions.md   # Project conventions for Copilot agents
├── docs/
│   ├── vscode-demo.md            # Step-by-step VS Code demo guide
│   ├── cli-demo.md               # Step-by-step CLI demo guide
│   └── app-demo.md               # Step-by-step Copilot App demo guide
└── src/
    ├── TodoApi/                  # .NET 10 Minimal API (demo target)
    └── TodoApi.Tests/            # xUnit integration tests
```

## Quick start

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- GitHub Copilot subscription (Pro / Pro+ / Business / Enterprise)
- VS Code ≥ 1.109 with the **GitHub Copilot** extension
- GitHub CLI ≥ 2.72 (`gh` with Copilot extension: `gh extension install github/gh-copilot`)
- [GitHub Copilot App](https://github.com/features/copilot/copilot-app) (technical preview)

### Run the sample API

```bash
cd src/TodoApi
dotnet run
# → https://localhost:5001
# → OpenAPI UI at https://localhost:5001/openapi/v1.json
```

### Run the tests

```bash
dotnet test
```

## Demo guides

| Platform | Guide |
|----------|-------|
| 🖥️ VS Code | [docs/vscode-demo.md](docs/vscode-demo.md) |
| 💻 CLI | [docs/cli-demo.md](docs/cli-demo.md) |
| 📱 App | [docs/app-demo.md](docs/app-demo.md) |

## References

- [GitHub Blog — Copilot App announcement](https://github.blog/news-insights/product-news/github-copilot-app-the-agent-native-desktop-experience/)
- [VS Code May 2026 release notes](https://github.blog/changelog/2026-06-03-github-copilot-in-visual-studio-code-may-releases/)
- [Copilot CLI changelog (June 2026)](https://github.blog/changelog/2026-06-02-copilot-cli-improved-ui-rubber-duck-prompt-scheduling-and-voice-input/)
- [Copilot SDK GA announcement](https://github.blog/changelog/2026-06-02-expanded-technical-preview-availability-for-the-github-copilot-app/)
