#!/bin/bash

# Ensure the submodule is initialized
git submodule update --init

# Generate the C# bindings
mkdir -p src/gen
wit-bindgen csharp --runtime native-aot --out-dir src/gen -w plugin wit/repo/pumpkin-plugin-wit/v0.1

echo "Bindings generated successfully in src/gen/"
