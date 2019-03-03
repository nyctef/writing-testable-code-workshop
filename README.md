# Writing Testable Code

## Agenda

- [Introduction](#introduction) _(10 min)_
- [Exercise 1](WritingTestableCode.Tests/Exercise1) _(30 min)_
- Break _(10 min)_
- [Exercise 2](WritingTestableCode.Tests/Exercise2) _(25 min)_
- Discussion _(15 min)_

## Introduction

### TDD vs. unit tests

- TDD is a design tool
- Unit tests are a quality-assurance tool

### Good design

- There's no one right answer
- Guidelines: [SOLID][solid], [Four Rules of Simple Design][four_rules] and [High Cohesion, Low Coupling][cohesion_and_coupling]

### Testable code

- Code for which writing a test is trivial

### Test-driven design

- Tests act as a first client to the code
- Listen to the tests
  - If the tests are difficult to write, fix the _code_
- Refactor tests to drive code refactoring
  - Decouple tests from code

[solid]: http://butunclebob.com/ArticleS.UncleBob.PrinciplesOfOod
[four_rules]: https://www.martinfowler.com/bliki/BeckDesignRules.html
[cohesion_and_coupling]: http://wiki.c2.com/?CouplingAndCohesion
