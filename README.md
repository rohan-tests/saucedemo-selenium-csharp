# 🧪 Selenium C# NUnit – SauceDemo Automation

This project automates end-to-end test scenarios on [saucedemo.com](https://www.saucedemo.com) using **Selenium WebDriver** with **C# and NUnit**.

## ✅ Features
- Login, cart, and checkout flow
- Add/remove item validations
- NUnit-based test structure
- Parallel test execution via `[FixtureLifeCycle]`
- Console-based time tracking for performance

## 🛠 Tech Stack
- Selenium WebDriver
- C#
- NUnit
- .NET Core

## 🚀 How to Run
```bash
dotnet restore
dotnet test
```
## 📁 Notes
- `bin/` , `obj/` , and test artifacts are excluded via `.gitignore`
- For comparison with Playwright, check [Playwright C# version](https://github.com/rohanash18/saucedemo-playwright-csharp.git)
