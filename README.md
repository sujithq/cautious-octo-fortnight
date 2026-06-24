# GitHub Copilot — Build 2026 Feature Showcase 🚀

> **Demo repository** for the latest GitHub Copilot features announced at **Microsoft Build 2026** across VS Code, the CLI, and the new Copilot desktop App.

## What's new since Build 2026?

| Area | Headline features |
|------|------------------|
| **VS Code** | Multi-agent orchestration · Plan Agent · Skills Management panel · Context usage visualisation · Language Models editor (BYOK) · Remote agents · Integrated browser debugger · Multi-file change diff |
| **CLI** | Rubber Duck cross-model review · Voice input · `/security-review` (all users) · `/worktree` · `/rewind` · `/diff` file tree + search · `/settings` dialog · `/diagnose` · MCP registry · Natural-language scheduling |
| **App** | Agent-native desktop (GA Jun 17 2026) · My Work dashboard · Canvas · Agent Merge · Cloud Automations · BYOK models · Plugin Marketplace · Isolated git worktrees · Sandbox mode |
| **Models** | Project Polaris (Microsoft in-house, replacing GPT-4 Turbo, Aug 2026) · Claude Fable 5 · Gemini 3.5 Flash |
| **SDK** | Generally available in Node.js, Python, Go, .NET, Rust, Java — with OpenTelemetry tracing |
| **Billing** | Usage-based AI Credits model (Jun 1 2026) · User-level budget controls · Copilot Max plan |

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

### Restore dependencies

```bash
dotnet restore cautious-octo-fortnight.sln
```

### Build the solution

```bash
dotnet build cautious-octo-fortnight.sln
```

### Run the sample API

```bash
cd src/TodoApi
dotnet run
# check port and protocol
# → http(s)://localhost:5000
# → OpenAPI UI at http(s)://localhost:5000/openapi/v1.json
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
| 📋 Changelog summary | [docs/changelog-summary.md](docs/changelog-summary.md) |

## References

- [GitHub Blog — Copilot App announcement](https://github.blog/news-insights/product-news/github-copilot-app-the-agent-native-desktop-experience/)
- [Copilot App GA changelog (Jun 17 2026)](https://github.blog/changelog/2026-06-17-github-copilot-app-generally-available/)
- [VS Code May 2026 release notes](https://github.blog/changelog/2026-06-03-github-copilot-in-visual-studio-code-may-releases/)
- [VS Code 1.125 release notes](https://code.visualstudio.com/updates)
- [Copilot CLI changelog (Jun 2 2026)](https://github.blog/changelog/2026-06-02-copilot-cli-improved-ui-rubber-duck-prompt-scheduling-and-voice-input/)
- [github/copilot-cli full changelog](https://github.com/github/copilot-cli/blob/main/changelog.md)
- [Copilot SDK GA (Jun 2 2026)](https://github.blog/changelog/2026-06-02-copilot-sdk-is-now-generally-available/)
- [Updates to Copilot billing and plans (Jun 1 2026)](https://github.blog/changelog/2026-06-01-updates-to-github-copilot-billing-and-plans/)
- [VS Code March 2026 releases](https://github.blog/changelog/2026-04-08-github-copilot-in-visual-studio-code-march-releases/)
