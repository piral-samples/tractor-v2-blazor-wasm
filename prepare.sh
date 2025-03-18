#!/bin/bash

yarn build

cd packages/checkout-pilet
dotnet build
cd ../../

cd packages/decide-pilet
dotnet build
cd ../../

cd packages/explore-pilet
dotnet build
cd ../../
