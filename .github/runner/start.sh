#!/bin/bash
set -e

# Validate required environment variables
if [ -z "$GITHUB_REPOSITORY" ]; then
    echo "❌ ERROR: GITHUB_REPOSITORY is not set"
    exit 1
fi

if [ -z "$RUNNER_TOKEN" ]; then
    echo "❌ ERROR: RUNNER_TOKEN is not set"
    exit 1
fi

RUNNER_NAME=${RUNNER_NAME:-"docker-runner-$(hostname)"}
RUNNER_LABELS=${RUNNER_LABELS:-"self-hosted,linux,x64,docker"}
RUNNER_WORKDIR=${RUNNER_WORKDIR:-"/home/runner/actions-runner/_work"}

# Configure DevExpress NuGet Feed if key is provided
if [ -n "$DEVEXPRESS_NUGET_KEY" ]; then
    echo "📦 Configuring DevExpress NuGet feed..."
    dotnet nuget add source "https://nuget.devexpress.com/${DEVEXPRESS_NUGET_KEY}/api/v3/index.json" --name "DevExpress" 2>/dev/null || true
    echo "✅ DevExpress NuGet feed configured"
fi

echo "🚀 Configuring GitHub Actions Runner..."
echo "   Repository: ${GITHUB_REPOSITORY}"
echo "   Runner Name: ${RUNNER_NAME}"
echo "   Labels: ${RUNNER_LABELS}"

cd /home/runner/actions-runner

# Configure the runner
./config.sh \
    --url "https://github.com/${GITHUB_REPOSITORY}" \
    --token "${RUNNER_TOKEN}" \
    --name "${RUNNER_NAME}" \
    --labels "${RUNNER_LABELS}" \
    --work "${RUNNER_WORKDIR}" \
    --unattended \
    --replace

# Cleanup function - remove runner on container stop
cleanup() {
    echo ""
    echo "🛑 Removing runner..."
    ./config.sh remove --token "${RUNNER_TOKEN}" || true
    echo "✅ Runner removed"
}

trap cleanup EXIT INT TERM

echo "✅ Runner configured! Starting..."
echo "================================================"

# Start the runner
./run.sh
