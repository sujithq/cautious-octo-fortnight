# GitHub Copilot Instructions

## Project context
This is a **demo repository** showcasing GitHub Copilot features announced at Microsoft Build 2026.
It contains a minimal .NET 10 Minimal-API (TodoApi) used as the target codebase for all demos.

## Coding conventions
- Use **C# 14** language features where appropriate.
- Target **net10.0** for all projects.
- Prefer `record` types for immutable data transfer objects.
- Use Minimal API patterns (no Controllers).
- All new endpoints must include `.WithName()` and `.WithSummary()`.
- Nullable reference types are **enabled** — never suppress with `!` without a comment.
- Write xUnit tests for every new endpoint. Use `WebApplicationFactory<Program>`.

## Commit message format
```
<type>(<scope>): <short description>
```
Types: `feat`, `fix`, `docs`, `refactor`, `test`, `chore`.

## Agent guidance
- When creating a new endpoint, also create the corresponding xUnit test.
- When fixing a bug, add a regression test.
- Prefer small, focused pull requests — one feature per PR.
- Always run `dotnet build` and `dotnet test` before opening a pull request.
