#!/bin/bash
echo "🚀 Iniciando HabitumApi..."

# Ir para a pasta do script
cd "$(dirname "$0")"

echo "🧹 Derrubando containers antigos..."
docker compose -p habitumapi down
if [ $? -ne 0 ]; then
    echo "❌ Erro ao derrubar os containers."
    read -p "Pressione Enter para sair..."
    exit 1
fi

echo "🚧 Construindo e iniciando novos containers..."
docker compose -p habitumapi up -d --build
if [ $? -ne 0 ]; then
    echo "❌ Erro ao iniciar os containers."
    read -p "Pressione Enter para sair..."
    exit 1
fi

echo "✅ HabitumApi iniciado com sucesso!"
read -p "Pressione Enter para sair..."
