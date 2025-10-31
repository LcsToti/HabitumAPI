@echo off
echo 🚀 Iniciando HabitumApi...

pushd %~dp0

echo 🧹 Derrubando containers antigos...
docker compose -p habitumapi down
if errorlevel 1 (
    echo ❌ Erro ao derrubar os containers.
    pause
    exit /b
)

echo 🚧 Construindo e iniciando novos containers...
docker compose -p habitumapi up -d --build
if errorlevel 1 (
    echo ❌ Erro ao iniciar os containers.
    pause
    exit /b
)

echo ✅ HabitumApi iniciado com sucesso!
popd