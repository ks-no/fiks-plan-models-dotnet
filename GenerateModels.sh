#!/bin/bash

GENERATOR_PATH=KS.Fiks.Plan.JsonModelGenerator
MODELS_PATH=../KS.Fiks.Plan.Models.V2
SCHEMA_PATH=../fiks-plan-specification/Schema/V2

cd $GENERATOR_PATH

dotnet run $SCHEMA_PATH $MODELS_PATH