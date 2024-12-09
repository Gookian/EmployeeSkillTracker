# EmployeeSkillsTracker

EmployeeSkillTracker — это backend часть одностраничного приложения, предназначенного для управления и отслеживания навыков сотрудников в компании. Приложение позволяет менеджерам и руководителям видеть актуальные данные о компетенциях своей команды, включая уровень владения различными навыками.

## Содержание

- [О проекте](#О-проекте)
- [Технологии](#Технологии)
- [Установка](#Установка)

## Технологии

Список технологий и инструментов, использованных в проекте:

- Язык программирования: `C#`.
- Фреймворк: `ASP.NET Core`.
- База данных: `PostgreSQL`.
- Другие инструменты и библиотеки: `EntityFrameworkCore`, `Swashbuckle.AspNetCore` `Serilog` `Docker`, `Docker-compose`, `NUnit`, `Moq`.

## Установка

1. Клонируйте репозиторий:
   ```bash
   git clone https://github.com/Gookian/EmployeeSkillTracker.git
   ```
2. Создание сети для Docker:
   ```bash
   docker network create employee_skill_tracker_network
   ```
3. Открыть проект в Visual Studio 2022;

4. Запустьть проект docker-compose.
